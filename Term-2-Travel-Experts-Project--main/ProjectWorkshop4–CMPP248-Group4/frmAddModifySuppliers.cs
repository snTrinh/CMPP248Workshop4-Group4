using Products_SuppliersData;
using ProductsData;
using SuppliersData;
using System;
using System.Collections.Generic;
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
                    prodNameCheckedListBox.Items.Insert(i, products[i].ProdName);
                }

                int randomID = RandomSupplierId();
                supplierIdTextBox.Text = randomID.ToString();
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
                    prodNameCheckedListBox.Items.Insert(i, remainingProds[i].ProdName);

                }
                for (int i = 0; i < typeOfProds.Count; i++)
                {
                    prodNameCheckedListBox.Items.Insert(i, typeOfProds[i].ProdName);
                    prodNameCheckedListBox.SetItemChecked(i, true);
                }

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
                Validator.IsNonNumeric(supNameTextBox, "Supplier Name"))
            {
                // create new supplier object from input data
                Suppliers newSupplier = new Suppliers();
                newSupplier.SupplierId = Convert.ToInt32(supplierIdTextBox.Text);
                newSupplier.SupName = supNameTextBox.Text;

                // if the product list count is more than 0
                if(prodNameCheckedListBox.CheckedItems.Count > 0)
                {
                    // add the supplier to the DB
                    SuppliersDB.AddSupplier(newSupplier);
                    // for each item that is checked
                    for (int i = 0; i < prodNameCheckedListBox.CheckedItems.Count; i++)
                    {
                        // create a variable to store the item value
                        string x = prodNameCheckedListBox.CheckedItems[i].ToString();
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
        }


        private void btnModify_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(supNameTextBox, "Supplier Name") &&
                Validator.IsNonNumeric(supNameTextBox, "Supplier Name"))
            {

                Suppliers newSup = new Suppliers();
                newSup.SupplierId = modifySupplier.SupplierId;
                newSup.SupName = supNameTextBox.Text;
                try
                {
                    //if (!SuppliersDB.UpdateSelectedSupplier(modifySupplier, newSup))
                    //{
                    //    MessageBox.Show("Another user has updated or deleted this package", "DataBase Error");
                    //    this.DialogResult = DialogResult.Retry;
                    //}
                    //if (SuppliersDB.SupplierNameExists(newSup.SupName))
                    //{
                    //    MessageBox.Show("This supplier already exists in this database.", "Duplication Error");
                    //    this.DialogResult = DialogResult.Retry;
                    //}


                    // if the product list count is more than 0
                    if (prodNameCheckedListBox.CheckedItems.Count > 0)
                    {
                        // for each item that is checked
                        for (int i = 0; i < prodNameCheckedListBox.CheckedItems.Count; i++)
                        {
                            // create a variable to store the item value
                            string x = prodNameCheckedListBox.CheckedItems[i].ToString();
                            // create a new product variable
                            Products y = new Products();
                            // this new product variable will search the DB for the product with the corresponding value
                            y = ProductsDB.GetProdId(x);
                            // create new variable that stores the product ID of the newfound product
                            int t = y.ProductId;
                            // add the the Products_SupplierDB using this new product ID and inputted supplier ID

                            // must check if association exists first
                            // if exists, no not add - break
                            // if does not exists
                            //Products_SuppliersDB.AddSupplierProductID(t, newSup.SupplierId);

                            // if product supplier exists
                            //if(!Products_SuppliersDB.ProductSupplierExist(t, newSup.SupplierId)) // returns false
                               // Console.Write("false"); // do nothing

                            // if pro supplies does not exist
                            if (Products_SuppliersDB.ProductSupplierExist(t, newSup.SupplierId).Count==0) // returns true
                                Products_SuppliersDB.AddSupplierProductID(t, newSup.SupplierId);
                        }
                        modifySupplier = newSup;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        modifySupplier = newSup;
                        this.DialogResult = DialogResult.OK;
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
