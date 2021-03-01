using Products_SuppliersData;
using ProductsData;
using SuppliersData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectWorkshop4_CMPP248_Group4
{
    public partial class frmAddModifySuppliers : Form
    {
        public frmAddModifySuppliers()
        {
            InitializeComponent();
        }
        public bool addSupplier = true; // true if user wants to add supplier; false if modify
        public Suppliers newSupplier;
        public Suppliers modifySupplier;

        public SuppliersProdId supplierProdId;

        private void AddModifySuppliers_Load(object sender, EventArgs e)
        {
            //productsBindingSource.DataSource = ProductsDB.GetProducts();
            List<Products> products = ProductsDB.GetProducts();

            if (addSupplier) // adding a supplier
            {
                // display all available products for the new supplier
                for (int i = 0; i < products.Count; i++)
                {
                    prodNameToAddCheckedListBox.Items.Insert(i, products[i].ProdName);
                }

                int randomID = RandomSupplierId();
                supplierIdTextBox.Text = randomID.ToString();
                pnlModify.Visible = false;
                btnModify.Visible = false;
                this.Text = "Add Suplier";
            }
            else // modifying a supplier
            {
                DisplaySelectedSupplier();
                supplierIdTextBox.Enabled = false;

                int supplierId = Convert.ToInt32(supplierIdTextBox.Text);
                // displays products associated to supplier
                List<SuppliersTypeOfProducts> typeOfProds = Products_SuppliersDB.GetSuppliersTypeOfProductsByID(supplierId);
                // displays product options available to supplier
                List<Products> remainingProds = ProductsDB.GetRemainingProducts(supplierId);
                for (int i = 0; i < remainingProds.Count; i++)
                {
                    availableCheckedListBox.Items.Insert(i, remainingProds[i].ProdName);

                }
                for (int i = 0; i < typeOfProds.Count; i++)
                {
                    currentProdCheckedListBox.Items.Insert(i, typeOfProds[i].ProdName);
                    currentProdCheckedListBox.SetItemChecked(i, true);
                }
                pnlAdd.Visible = false;
                btnAdd.Visible = false;
                this.Text = "Modify Supplier";
            }
        }

        // Random Supplier ID with validator
        // Code by Susan Trinh: February 11, 2021
        private int RandomSupplierId()
        {
            Random r = new Random();
            int rand;
            do
            {
                rand = Convert.ToInt32(r.Next(0, 15000));
            }
            while (!SuppliersDB.SupplierExists(rand)); // while this is false, generate random number until one is created that doesn't exist in the DB
            //if the above returns true return the value
            return rand;
        }

        // if modifying a supplier, display these values
        private void DisplaySelectedSupplier()
        {
            supplierIdTextBox.Text = modifySupplier.SupplierId.ToString();
            supNameTextBox.Text = modifySupplier.SupName;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // once a user adds a supplier
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // validate that the Supplier Name is not blank and is non-numeric
            if (Validator.IsPresent(supNameTextBox, "Supplier Name") &&
                Validator.IsNonNumericWithSpecialCharacters(supNameTextBox, "Supplier Name"))
            {
                try 
                { 
                    // create new supplier object from input data
                    Suppliers newSupplier = new Suppliers();
                    newSupplier.SupplierId = Convert.ToInt32(supplierIdTextBox.Text);
                    newSupplier.SupName = supNameTextBox.Text;

                    // if user inputs a name, and the DB comes up with 0 vales of which are the same, implement the following code
                    if (SuppliersDB.SupplierNameExists(newSupplier.SupName).Count == 0)

                    {
                        if (prodNameToAddCheckedListBox.CheckedItems.Count > 0)
                        {
                            // add the supplier to the DB
                            SuppliersDB.AddSupplier(newSupplier);
                            // for each item that is checked
                            for (int i = 0; i < prodNameToAddCheckedListBox.CheckedItems.Count; i++)
                            {
                                // create a variable to store the item value
                                string x = prodNameToAddCheckedListBox.CheckedItems[i].ToString();
                                // create a new product variable
                                Products y = new Products();
                                // this new product variable will search the DB for the product with the corresponding value
                                y = ProductsDB.GetProdId(x);
                                // create new variable that stores the product ID of the newfound product
                                int t = y.ProductId;
                                // add the the Products_SupplierDB using this new product ID and inputted supplier ID
                                Products_SuppliersDB.AddSupplierProductID(t, newSupplier.SupplierId);
                            }
                            this.DialogResult = DialogResult.OK;
                        }
                        // else add the supplier to the DB
                        else
                        {
                            SuppliersDB.AddSupplier(newSupplier);
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    // else the name is duplicated, notify user
                    else
                    {
                        MessageBox.Show(newSupplier.SupName + " already exists in the database.", "Duplication Error");
                    }
            }
            // this error catches upon the deletion of a cell of which is referenced in another table
            catch (DBConcurrencyException)
            {
                MessageBox.Show("Concurrency Error: another user updated or deleted data. Try again", "Concurrency Error");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error because of referenced value: " + ex.Message, "Null Error");
            }
            //this error catches null errors 
            catch (NoNullAllowedException ex)
            {
                MessageBox.Show("Error because of null value: " + ex.Message, "Null Error");
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("There is an error " + ex.Message, "Error Message");
            }
            
            }
        }

        // This section was revised on February 28 through pair programming*
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(supNameTextBox, "Supplier Name") &&
                Validator.IsNonNumericWithSpecialCharacters(supNameTextBox, "Supplier Name"))
            {
                try
                {
                    Suppliers newSup = new Suppliers();
                    newSup.SupplierId = modifySupplier.SupplierId;
                    newSup.SupName = supNameTextBox.Text;

                    //if this supplier does not exist
                    if (SuppliersDB.ModifyingSupplierNameExists(newSup.SupplierId, newSup.SupName).Count == 0)
                    {
                        // upon successful supplier update
                        if (SuppliersDB.UpdateSelectedSupplier(modifySupplier, newSup))
                        {
                            // check to view all items checked to add
                            for (int j = 0; j < availableCheckedListBox.CheckedItems.Count; j++)
                            {
                                // create a variable to store the item value
                                string x = availableCheckedListBox.CheckedItems[j].ToString();
                                // create a new product variable
                                Products y = new Products();
                                // this new product variable will search the DB for the product with the corresponding value
                                y = ProductsDB.GetProdId(x);
                                // create new variable that stores the product ID of the newfound product
                                int t = y.ProductId;
                                if (Products_SuppliersDB.ProductSupplierExist(t, newSup.SupplierId).Count == 0) // if relationship doesnt exist
                                    Products_SuppliersDB.AddSupplierProductID(t, newSup.SupplierId); // add to the DB
                                                                                                        
                            }

                            int checkedProd = currentProdCheckedListBox.CheckedItems.Count;
                            int totalProd = currentProdCheckedListBox.Items.Count;
                            int uncheckedProd = totalProd - checkedProd;
                            // for deselection of items
                            if(uncheckedProd >= 0)
                            {
                                foreach(var prod in currentProdCheckedListBox.Items)
                                {
                                    if(!currentProdCheckedListBox.CheckedItems.Contains(prod))
                                    {
                                        Products b = ProductsDB.GetProdId(prod.ToString());
                                        int c = b.ProductId;
                                        Products_SuppliersDB.DeleteProductSupplier(c, newSup.SupplierId);
                                    }
                                }
                            }
                            
                            
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(newSup.SupName + " already exists in the database.", "Duplication Error");
                    }
                }
                catch (DBConcurrencyException)
                {
                    MessageBox.Show("Concurrency Error: another user updated or deleted data. Try again", "Concurrency Error");
                    //close dialog
                    DialogResult = DialogResult.Cancel;
                }
                catch (Exception)
                {
                    MessageBox.Show("One or more products is referenced with a current package or booking.", "Error");
                    //close dialog
                    DialogResult = DialogResult.None;
                }

            }
        }

    }
}
