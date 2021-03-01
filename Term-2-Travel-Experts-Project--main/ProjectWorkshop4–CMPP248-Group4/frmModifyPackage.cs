using Packages_Products_SuppliersData;
using PackagesData;
using Products_SuppliersData;
using ProductsData;
using SuppliersData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Package page created by Julie Tran
 */
namespace ProjectWorkshop4_CMPP248_Group4
{
    public partial class frmModifyPackage : Form
    {
        //Declaring variables for modifying packages
        List<ProductSupplierAll> prodSup;
        List<Packages_Products_Suppliers> pkgProdSupList;
        List<Packages_Products_Suppliers> pkgProdSupListRemove;
        List<string> productNameList;
        List<string> distinctProductNameList;
        public Packages newPackage;
        public Packages package;
        int numberOfProductRepeats;
        


        //Declaring variables for adding packages
        List<ProductSupplierAll> addProdSup;

        // true if user wants to add product; false if modify
        public bool addPackage;

        public frmModifyPackage()
        {
            InitializeComponent();

            //instantiating variables 
            productNameList = new List<string>();
            distinctProductNameList = new List<string>();
            pkgProdSupList = new List<Packages_Products_Suppliers>();
            pkgProdSupListRemove = new List<Packages_Products_Suppliers>();
            package = new Packages();
            addPackage = true;
        }
        
        //When modifying a package, package properties will display
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

        //Retrieving data from form when modifying/adding packages.
        private void PackageData(Packages package)
        {
            package.PkgName = pkgNameTextBox.Text;
            package.PkgDesc = pkgDescTextBox.Text;
            if (pkgBasePriceTextBox.Text.StartsWith("$"))
            {
                decimal basePrice = Convert.ToDecimal(pkgBasePriceTextBox.Text.Replace("$", ""));
                package.PkgBasePrice = basePrice;
            }
            else
            {
                package.PkgBasePrice = Convert.ToDecimal(pkgBasePriceTextBox.Text);
            }
            if (pkgAgencyCommissionTextBox.Text.StartsWith("$"))
            {
                decimal comission = Convert.ToDecimal(pkgAgencyCommissionTextBox.Text.Replace("$", ""));
                package.PkgAgencyCommission = comission;
            }
            else
            {
                package.PkgAgencyCommission = Convert.ToDecimal(pkgAgencyCommissionTextBox.Text);
            }
            package.PkgStartDate = (DateTime)pkgStartDateDateTimePicker.Value;
            package.PkgEndDate = (DateTime)pkgEndDateDateTimePicker.Value;
        }
        //Event handler for when package loads 
        private void frmModifyPackage_Load(object sender, EventArgs e)
        {
            //for adding packages
            if (addPackage)
            {
                //Modify display when user wants to add Package
                pnlAdd.Visible = true;
                pnlModify.Visible = false;
                btnModify.Visible = false;
                checkListExistingProdSupplier.Visible = false;
                this.Text = "Add Package";

                // display all available products suppliers for the new package
                addProdSup = Products_SuppliersDB.GetAllProductSupplierName();
                for (int i = 0; i < addProdSup.Count; i++)
                {
                    checkListAddNewProductSupplier.Items.Insert(i, addProdSup[i].ProdName + " : " + addProdSup[i].SupName);
                    checkListAddNewProductSupplier.SetItemChecked(i, false);
                }
            }
            //For modifying packages
            else
            {
                //Modify display when user wants to modify a package
                if (package != null)
                {
                    pnlAdd.Visible = false;
                    pnlModify.Visible = true;
                    DisplaySelectedPackage();
                    btnAdd.Visible = false;
                    this.Text = "Modify Package";

                    //retrieve packageID to retrieve a list of available product suppliers
                    packageIdTextBox.Text = package.PackageId.ToString();
                    int packageID = Convert.ToInt32(packageIdTextBox.Text);
                    prodSup = Products_SuppliersDB.GetProductSupplierName(packageID);

                    //displays products and suppliers that is associated to current package
                    List<string> productNameExistingList = new List<string>();
                    for (int i = 0; i < prodSup.Count; i++)
                    {
                        //display products and suppliers in a CheckListBox
                        checkListExistingProdSupplier.Items.Insert(i, prodSup[i].ProdName + " : " + prodSup[i].SupName);
                        checkListExistingProdSupplier.SetItemChecked(i, true);
                        productNameExistingList.Add(prodSup[i].ProdName);
                    }
                    
                    //displays products and suppliers that is not associated to package
                    List<string> allProductNameList = ProductsDB.GetProductName();
                    List<string> remainingProductNameList = allProductNameList.Except(productNameExistingList).ToList();
                    foreach (string productName in remainingProductNameList)
                    {
                        List<ProductSupplierAll> allProdSup = Products_SuppliersDB.GetFilteredProductSupplier(productName);
                        for (int i = 0; i < allProdSup.Count; i++)
                        {
                            //displays products and suppliers in a CheckListBox
                            checkListAddProductSupplier.Items.Insert(i, allProdSup[i].ProdName + " : " + allProdSup[i].SupName);
                            checkListAddProductSupplier.SetItemChecked(i, false);
                        }
                    }
                }
            }

        }

        //Modify button event handler 
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
                    if (PackagesDB.UpdatePackage(package, newPackage) == true)                      
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
                            numberOfProductRepeats = productNameList.Count() - distinctProductNameList.Count();

                            
                            if (numberOfProductRepeats > 1)
                            {
                                MessageBox.Show("You selected more than one of the same product. Please try again");
                                pkgProdSupList.Clear();
                                productNameList.Clear();
                            }
                            else if (numberOfProductRepeats == 1)
                            {
                                foreach (string name in productNameList)
                                {
                                    int matchingnameCount = productNameList.Where(stringToCheck => stringToCheck.Contains(name)).Count();
                                    if (matchingnameCount > 1)
                                    {
                                        MessageBox.Show("You selected " + name + " twice. Please try again");
                                        break;
                                    }
                                    break;

                                }
                                
                                pkgProdSupList.Clear();
                                productNameList.Clear();
                            }
                            else if (numberOfProductRepeats == 0)
                            {
                                foreach (Packages_Products_Suppliers pkgProdSup in pkgProdSupList)
                                {
                                    Packages_Products_SuppliersDB.AddPackageProductSupplier(pkgProdSup);
                                }
                                //DialogResult = DialogResult.OK;
                                pkgProdSupList.Clear();
                                productNameList.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Please try again");
                                pkgProdSupList.Clear();
                                productNameList.Clear();
                            }
                        }

                        int checkedCount = checkListExistingProdSupplier.CheckedItems.Count;
                        int totalCount = checkListExistingProdSupplier.Items.Count;

                        int uncheckedCount = totalCount - checkedCount;
                        if (uncheckedCount > 0)
                        {
                            foreach (var items in checkListExistingProdSupplier.Items)
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
                                    pkgProdSupListRemove.Add(pkgProdSup);

                                    foreach (Packages_Products_Suppliers pps in pkgProdSupListRemove)
                                    {
                                        Packages_Products_SuppliersDB.DeletePackProdSuppAssociation(pps);
                                    }
                                }
                            }
                        }
                        if (numberOfProductRepeats == 0)
                        {
                            DialogResult = DialogResult.OK;
                        }
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
            //Closes the form
            DialogResult = DialogResult.Cancel;
        }

       
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
                
                try
                {
                    //checks to see if products/suppliers have been added
                    this.PackageData(newPackage);
                    //Add new package 
                    int packageId = PackagesDB.GetNextID() + 1;
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
                            pkgProdSup.PackageId = packageId;

                            pkgProdSupList.Add(pkgProdSup);
                            productNameList.Add(productName);


                        }

                        distinctProductNameList = productNameList.Distinct().ToList();
                        numberOfProductRepeats = productNameList.Count() - distinctProductNameList.Count();


                        if (numberOfProductRepeats > 1)
                        {
                            MessageBox.Show("You selected more than one of the same product. Please try again");
                            pkgProdSupList.Clear();
                            productNameList.Clear();
                        }
                        else if (numberOfProductRepeats == 1)
                        {
                            foreach (string name in productNameList)
                            {
                                int matchingnameCount = productNameList.Where(stringToCheck => stringToCheck.Contains(name)).Count();
                                if (matchingnameCount > 1)
                                {
                                    MessageBox.Show("You selected " + name + " twice. Please try again");
                                    break;
                                }
                                break;

                            }
                            pkgProdSupList.Clear();
                            productNameList.Clear();
                        }
                        else if (numberOfProductRepeats == 0)
                        {
                            PackagesDB.AddPackage(newPackage);
                            foreach (Packages_Products_Suppliers pkgProdSup in pkgProdSupList)
                            {
                                Packages_Products_SuppliersDB.AddPackageProductSupplier(pkgProdSup);
                            }
                            pkgProdSupList.Clear();
                            productNameList.Clear();
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Please try again");
                            pkgProdSupList.Clear();
                            productNameList.Clear();
                        }
                    }
                    else
                    {
                        PackagesDB.AddPackage(newPackage);
                        DialogResult = DialogResult.OK;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating data " + ex.Message, ex.GetType().ToString());
                }

            }
        }

    }
}




