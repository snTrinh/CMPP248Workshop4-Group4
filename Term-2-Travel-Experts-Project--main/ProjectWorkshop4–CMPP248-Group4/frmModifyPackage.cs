using Packages_Products_SuppliersData;
using PackagesData;
using Products_SuppliersData;
using ProductsData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWorkshop4_CMPP248_Group4
{
    public partial class frmModifyPackage : Form
    {
        public List<ProductSupplierAll> prodSup; //for modifying
        public List<ProductSupplierAll> allProdSup; //for modifying
        public List<ProductSupplierAll> addProdSup; //for adding

        public frmModifyPackage()
        {
            InitializeComponent();
        }
        public bool addPackage = true; // true if user wants to add product; false if modify
        public Packages newPackage;
        public Packages package = new Packages();
        public List<int> addPackageSupplierIdList = new List<int>();
        public List<int> removePackageSupplierIdList = new List<int>();

        // if modifying a package, display these values
        private void DisplaySelectedPackage()
        {
            packageIdTextBox.Text = package.PackageId.ToString();
            pkgNameTextBox.Text = package.PkgName;
            pkgDescTextBox.Text = package.PkgDesc;
            pkgBasePriceTextBox.Text = package.PkgBasePrice.ToString();
            pkgAgencyCommissionTextBox.Text = package.PkgAgencyCommission.ToString();
            pkgStartDateDateTimePicker.Value = package.PkgStartDate;
            pkgEndDateDateTimePicker.Value = package.PkgEndDate;
        }


        private List<Products_Suppliers> checkRegEx(CheckedListBox checkedListBox)
        {
            List<Products_Suppliers> selectedList = new List<Products_Suppliers>();

            string str = "";
            string pattern = "\\d+(?=:)"; //regex gets numbers that are before a colon
            Regex regex = new Regex(pattern);

            Products_Suppliers productAndSupplier = new Products_Suppliers();
            //checks for when regex matches
            for (int x = 0; x < 1; x++)
            {
                str = checkedListBox.SelectedItems[x].ToString();
                MatchCollection matched = regex.Matches(str);
                //for each match, return a Products_Suppliers list
                for (int count = 0; count < 1; count++)
                {
                    var list = matched.Cast<Match>().Select(match => match.Value).ToList();
                    int productSupplierId = Convert.ToInt32(list[0]);
                    int productId = Convert.ToInt32(list[1]);
                    int supplierId = Convert.ToInt32(list[2]);

                    productAndSupplier.ProductId = productId;
                    productAndSupplier.SupplierId = supplierId;
                    productAndSupplier.ProductSupplierId = productSupplierId;
                    selectedList.Add(productAndSupplier);
                }
            }
            return selectedList;
        }

        private void PackageData(Packages package)
        {
            package.PkgName = pkgNameTextBox.Text;
            package.PkgDesc = pkgDescTextBox.Text;
            package.PkgBasePrice = Convert.ToDecimal(pkgBasePriceTextBox.Text);
            package.PkgAgencyCommission = Convert.ToDecimal(pkgAgencyCommissionTextBox.Text);
            package.PkgStartDate = (DateTime)pkgStartDateDateTimePicker.Value;
            package.PkgEndDate = (DateTime)pkgEndDateDateTimePicker.Value;

        }

        private void frmModifyPackage_Load(object sender, EventArgs e)
        {
            if (addPackage)
            {
                pnlAdd.Visible = true;
                pnlModify.Visible = false;
                btnModify.Visible = false;
                checkListExistingProdSupplier.Visible = false;
                this.Text = "Add Package";
                // display all available products for the new package
                addProdSup = Products_SuppliersDB.GetAllProductSupplierName();
                for (int i = 0; i < addProdSup.Count; i++)
                {
                    checkListAddNewProductSupplier.Items.Insert(i, "Product Supplier ID " + addProdSup[i].ProductSupplierId + ": " + addProdSup[i].ProductId + ": " + addProdSup[i].ProdName + "  " + addProdSup[i].SupplierId + ": " + addProdSup[i].SupName);
                    checkListAddNewProductSupplier.SetItemChecked(i, false);
                }
            }
            else
            {
                //if package is selected, then load selected packages
                if (package != null)
                {
                    pnlAdd.Visible = false;
                    pnlModify.Visible = true;
                    DisplaySelectedPackage();
                    packageIdTextBox.Text = package.PackageId.ToString();
                    int packageID = Convert.ToInt32(packageIdTextBox.Text);
                    prodSup = Products_SuppliersDB.GetProductSupplierName(packageID);
                    //displays all products and suppliers that are not already part of a package
                    allProdSup = Products_SuppliersDB.NotAssociatedProductSupplier(packageID);
                    btnAdd.Visible = false; //hides add button
                    this.Text = "Modify Package"; //shows modify 
                                                  //displays the associated products and suppliers that is associated AN EXISTING package
                    for (int i = 0; i < prodSup.Count; i++)
                    {
                        checkListExistingProdSupplier.Items.Insert(i, "Product Supplier ID " + prodSup[i].ProductSupplierId + ": " + prodSup[i].ProductId + ": " + prodSup[i].ProdName + "  " + prodSup[i].SupplierId + ": " + prodSup[i].SupName);
                        checkListExistingProdSupplier.SetItemChecked(i, true);
                    }

                    for (int i = 0; i < allProdSup.Count; i++)
                    {
                        checkListAddProductSupplier.Items.Insert(i, "Product Supplier ID " + allProdSup[i].ProductSupplierId + ": " + allProdSup[i].ProductId + ": " + allProdSup[i].ProdName + "  " + allProdSup[i].SupplierId + ": " + allProdSup[i].SupName);
                        checkListAddProductSupplier.SetItemChecked(i, false);
                    }
                }//retrieve products and suppliers by packageID
            }

        }


        //Modify button event handler 
        //Created by Julie Tran on January 31 2021
        private void btnModify_Click_1(object sender, EventArgs e)
        {

            if (Validator.IsPresent(pkgNameTextBox, "Package Name") &&
            Validator.IsPresent(pkgDescTextBox, "Package Description") &&
            Validator.IsPresent(pkgBasePriceTextBox, "Package Base Price") &&
            Validator.IsNonNegativeDecimal(pkgBasePriceTextBox, "Package Base Price") &&
            Validator.IsAfterStartDate(pkgEndDateDateTimePicker, pkgStartDateDateTimePicker, "Package End Date") &&
            Validator.IsLessThanBase(pkgAgencyCommissionTextBox, pkgBasePriceTextBox, "Agency Commission"))
            {
                //select package that will be modified 
                //Packages newPkg = new Packages();
                //newPkg.PackageId = package.PackageId;
                //this.PackageData(newPkg);
                newPackage = new Packages();
                newPackage.PackageId = package.PackageId;
                this.PackageData(newPackage);

                try
                {
                    //if not updating
                    if (!PackagesDB.UpdatePackage(package, newPackage))
                    {
                        MessageBox.Show("Another user has updated or deleted this package", "DataBase Error");
                        this.DialogResult = DialogResult.Retry;
                    }
                    //if updating 
                    else
                    {

                        package = newPackage;
                        if (checkListAddProductSupplier.CheckedItems.Count > 0)
                        {
                            int checkCount = checkListAddProductSupplier.CheckedItems.Count;
                            for (var i = 0; i < checkCount; i++)
                            {
                                Packages_Products_Suppliers pkgProdSup = new Packages_Products_Suppliers();
                                pkgProdSup.ProductSupplerId = addPackageSupplierIdList[i];
                                pkgProdSup.PackageId = Convert.ToInt32(packageIdTextBox.Text);
                                //connecting and adding to DB
                                Packages_Products_SuppliersDB.AddPackageProductSupplier(pkgProdSup);
                            }
                        }

                        //unchecking box and removing association with package
                        int checkedCount = checkListExistingProdSupplier.CheckedItems.Count;
                        int totalCount = checkListExistingProdSupplier.Items.Count;
                        int uncheckedCount = totalCount - checkedCount;
                        if (uncheckedCount > 0)
                        {
                            for (var i = 0; i < uncheckedCount; i++)
                            {
                                //deleting item that was unchecked
                                Packages_Products_Suppliers pkgProdSup = new Packages_Products_Suppliers();
                                pkgProdSup.ProductSupplerId = removePackageSupplierIdList[i];
                                pkgProdSup.PackageId = Convert.ToInt32(packageIdTextBox.Text);
                                //connecting and adding to DB
                                Packages_Products_SuppliersDB.DeletePackProdSuppAssociation(pkgProdSup);
                            }
                        }
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating data " + ex.Message, ex.GetType().ToString());
                }
            }
        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //Add button event handler 
        //Created by Julie Tran on January 31, 2021
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            //create package to be added to DB
            newPackage = new Packages();
            newPackage.PkgName = pkgNameTextBox.Text;

            if (Validator.IsPresent(pkgNameTextBox, "Package Name") &&
            Validator.IsPresent(pkgDescTextBox, "Package Description") &&
            Validator.IsPresent(pkgBasePriceTextBox, "Package Base Price") &&
            Validator.IsNonNegativeDecimal(pkgBasePriceTextBox, "Package Base Price") &&
            Validator.IsAfterStartDate(pkgEndDateDateTimePicker, pkgStartDateDateTimePicker, "Package End Date") &&
            Validator.IsLessThanBase(pkgAgencyCommissionTextBox, pkgBasePriceTextBox, "Agency Commission"))
            {
                //checks to see if products/suppliers have been added
                this.PackageData(newPackage);
                //Add new package 
                newPackage.PackageId = PackagesDB.AddPackage(newPackage);
                if (checkListAddNewProductSupplier.CheckedItems.Count > 0)
                {
                    //int[] distinctAddPackageSupplierIdList = addPackageSupplierIdList.Distinct().ToArray();
                    //int checkListCount = distinctAddPackageSupplierIdList.Count();
                    int checkedCount = checkListAddNewProductSupplier.CheckedItems.Count;
                    for (var i = 0; i < checkedCount; i++)
                    {
                        Packages_Products_Suppliers pkgProdSup = new Packages_Products_Suppliers();
                        pkgProdSup.ProductSupplerId = addPackageSupplierIdList[i];
                        pkgProdSup.PackageId = Convert.ToInt32(newPackage.PackageId);
                        //connecting and adding to DB
                        Packages_Products_SuppliersDB.AddPackageProductSupplier(pkgProdSup);
                    }
                }
                DialogResult = DialogResult.OK;

            }
        }



        private void checkListExistingProdSupplier_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            if (e.NewValue == CheckState.Unchecked)
            {
                List<Products_Suppliers> selectedProduct = checkRegEx(checkListExistingProdSupplier);
                int ProductSupplierId = Convert.ToInt32(selectedProduct[0].ProductSupplierId);
                removePackageSupplierIdList.Add(ProductSupplierId);
            }
        }

        private void checkListAddProductSupplier_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<Products_Suppliers> selectedProduct = checkRegEx(checkListAddProductSupplier);
            int ProductSupplierId = Convert.ToInt32(selectedProduct[0].ProductSupplierId);
            addPackageSupplierIdList.Add(ProductSupplierId);

        }

        private void checkListAddNewProductSupplier_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<Products_Suppliers> selectedProduct = checkRegEx(checkListAddNewProductSupplier);
            int ProductSupplierId = Convert.ToInt32(selectedProduct[0].ProductSupplierId);
            addPackageSupplierIdList.Add(ProductSupplierId);
        }
    }
}




