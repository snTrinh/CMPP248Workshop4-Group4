using Packages_Products_SuppliersData;
using PackagesData;
using Products_SuppliersData;
using ProductsData;
using SuppliersData;
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
        public List<ProductSupplierAll> allProdSup = new List<ProductSupplierAll>();//for modifying
        public List<ProductSupplierAll> addProdSup; //for adding
        List<string> productNameList = new List<string>();
        List<string> distinctProductNameList = new List<string>();
        List<Packages_Products_Suppliers> pkgProdSupList = new List<Packages_Products_Suppliers>();
        public frmModifyPackage()
        {
            InitializeComponent();
        }
        public bool addPackage = true; // true if user wants to add product; false if modify
        public Packages newPackage;
        public Packages package = new Packages();
        public List<Products_Suppliers> addPackageSupplierIdList = new List<Products_Suppliers>();
        public List<Products_Suppliers> removePackageSupplierIdList = new List<Products_Suppliers>();
       // private IEnumerable<string> distinctProductNameList;

        // if modifying a package, display these values
        private void DisplaySelectedPackage()
        {
            packageIdTextBox.Text = package.PackageId.ToString();
            pkgNameTextBox.Text = package.PkgName;
            pkgDescTextBox.Text = package.PkgDesc;
            pkgBasePriceTextBox.Text = package.PkgBasePrice.ToString("c");
            pkgAgencyCommissionTextBox.Text = package.PkgAgencyCommission.ToString("c");
            pkgStartDateDateTimePicker.Value = package.PkgStartDate;
            pkgEndDateDateTimePicker.Value = package.PkgEndDate;
        }


        private List<Products_Suppliers> checkRegEx(CheckedListBox checkedListBox)
        {
            List<Products_Suppliers> selectedList = new List<Products_Suppliers>();

            string str = "";
            string pattern = "\\d+(?=:)"; //regex text before regex
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
            package.PkgBasePrice = Convert.ToDecimal(pkgBasePriceTextBox.Text.Replace(@"$", string.Empty));
            package.PkgAgencyCommission = Convert.ToDecimal(pkgAgencyCommissionTextBox.Text.Replace(@"$", string.Empty));
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
                    checkListAddNewProductSupplier.Items.Insert(i, addProdSup[i].ProdName + " : " + addProdSup[i].SupName);
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

                    btnAdd.Visible = false; //hides add button
                    this.Text = "Modify Package"; //shows modify 
                                                  //displays the associated products and suppliers that is associated AN EXISTING package
                    List<string> productNameExistingList = new List<string>();
                    for (int i = 0; i < prodSup.Count; i++)
                    {
                        checkListExistingProdSupplier.Items.Insert(i, prodSup[i].ProdName + " : " + prodSup[i].SupName);
                        checkListExistingProdSupplier.SetItemChecked(i, true);
                        productNameExistingList.Add(prodSup[i].ProdName);
                    }
                    
                    List<string> allProductNameList = ProductsDB.GetProductName();
                    List<string> remainingProductNameList = allProductNameList.Except(productNameExistingList).ToList();
                    foreach (string productName in remainingProductNameList)
                    {
   
                        //string selectedProdSupp = checkListExistingProdSupplier.CheckedItems[i].ToString();
                        List<ProductSupplierAll> allProdSup = Products_SuppliersDB.GetFilteredProductSupplier(productName);
                        for (int i = 0; i < allProdSup.Count; i++)
                        {
                            checkListAddProductSupplier.Items.Insert(i, allProdSup[i].ProdName + " : " + allProdSup[i].SupName);
                            checkListAddProductSupplier.SetItemChecked(i, false);
                        }
  

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

                                string selectedProdSupp = checkListAddProductSupplier.CheckedItems[i].ToString();
                                string[] splitProdSupp = selectedProdSupp.Split(':');
                                string productName = splitProdSupp[0].Trim(' ');
                                string supplierName = splitProdSupp[1].Trim(' ');
                                int productSupplierId = Products_SuppliersDB.GetProductSupplierID(productName, supplierName);

                                Packages_Products_Suppliers pkgProdSup = new Packages_Products_Suppliers();
                               
                                pkgProdSup.ProductSupplerId = productSupplierId;
                                pkgProdSup.PackageId = Convert.ToInt32(packageIdTextBox.Text);
                                pkgProdSupList.Add(pkgProdSup);
                                productNameList.Add(productName);

                            }

                           
                            distinctProductNameList = productNameList.Distinct().ToList();
                            int numberOfProductRepeats = productNameList.Count() - distinctProductNameList.Count();
                            if (numberOfProductRepeats > 1)

                                MessageBox.Show("You selected more than one of the same product. Please try again");
                            else if (numberOfProductRepeats == 1)
                                MessageBox.Show("You selected " + productNameList[0] + " twice. Please try again");
                            else if (numberOfProductRepeats == 0)
                            {
                                foreach (Packages_Products_Suppliers pkgProdSup in pkgProdSupList)
                                    Packages_Products_SuppliersDB.AddPackageProductSupplier(pkgProdSup);
                            }
                            else
                                MessageBox.Show("Please try again");

                        }

                        int checkedCount = checkListExistingProdSupplier.CheckedItems.Count;
                        int totalCount = checkListExistingProdSupplier.Items.Count;
                    
                        int uncheckedCount = totalCount - checkedCount;
                        if (uncheckedCount > 0)
                        {
                            foreach(var items in checkListExistingProdSupplier.Items)
                            {
                                if (!checkListExistingProdSupplier.CheckedItems.Contains(items))
                                {
                                    string selectedProdSupp = items.ToString();
                                    string[] splitProdSupp = selectedProdSupp.Split(':');
                                    string productName = splitProdSupp[0].Trim(' ');

                                    string supplierName = splitProdSupp[1].Trim(' ');
                                    int productSupplierId = Products_SuppliersDB.GetProductSupplierID(productName, supplierName);

                                    Packages_Products_Suppliers pkgProdSup = new Packages_Products_Suppliers();
                                    pkgProdSup.ProductSupplerId = productSupplierId;
                                    pkgProdSup.PackageId = Convert.ToInt32(packageIdTextBox.Text);

                                    Packages_Products_SuppliersDB.DeletePackProdSuppAssociation(pkgProdSup);
                                }
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
                    
                    int checkedCount = checkListAddNewProductSupplier.CheckedItems.Count;

                    for (var i = 0; i < checkedCount; i++)
                    {
                        string selectedProdSupp = checkListAddNewProductSupplier.CheckedItems[i].ToString();
                        string[] splitProdSupp = selectedProdSupp.Split(':');
                        string productName = splitProdSupp[0].Trim(' ');
                        string supplierName = splitProdSupp[1].Trim(' ');
                        int productSupplierId = Products_SuppliersDB.GetProductSupplierID(productName, supplierName);

                        Packages_Products_Suppliers pkgProdSup = new Packages_Products_Suppliers();
                        pkgProdSup.ProductSupplerId = productSupplierId;
                        pkgProdSup.PackageId = newPackage.PackageId;

                        pkgProdSupList.Add(pkgProdSup);
                        productNameList.Add(productName);

                      
                    }

                    distinctProductNameList = productNameList.Distinct().ToList();
                    int numberOfProductRepeats = productNameList.Count() - distinctProductNameList.Count();
                    if (numberOfProductRepeats > 1)

                        MessageBox.Show("You selected more than one of the same product. Please try again");
                    else if (numberOfProductRepeats == 1)
                        MessageBox.Show("You selected " + productNameList[0] + " twice. Please try again");
                    else if (numberOfProductRepeats == 0)
                    {
                        foreach (Packages_Products_Suppliers pkgProdSup in pkgProdSupList)
                            Packages_Products_SuppliersDB.AddPackageProductSupplier(pkgProdSup);
                    }
                    else
                        MessageBox.Show("Please try again");
                }
                DialogResult = DialogResult.OK;

            }
        }



        
    }
}




