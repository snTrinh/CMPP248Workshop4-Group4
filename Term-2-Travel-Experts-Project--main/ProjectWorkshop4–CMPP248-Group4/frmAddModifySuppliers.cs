﻿using Products_SuppliersData;
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

                // if user inputs a name, and the DB comes up with 0 vales of which are the same, implement the following code
                if (SuppliersDB.SupplierNameExists(newSupplier.SupName).Count == 0) 
                                                                                    
                {
                    if (prodNameCheckedListBox.CheckedItems.Count > 0)
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
                // else the name is duplicated, notify user
                else
                {
                    MessageBox.Show(newSupplier.SupName + " already exists in the database.", "Duplication Error");
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

                // if no duplicate name entry
                //if (SuppliersDB.SupplierNameExists(newSup.SupName).Count == 0)
                //{
                    // gives us a count of all the items in the DB
                    if (prodNameCheckedListBox.CheckedItems.Count > 0)
                    {
                        //*************Testiing
                        string allItems = "";
                        for (int i = 0; i < prodNameCheckedListBox.Items.Count; i++)
                        {
                            string a = prodNameCheckedListBox.Items[i].ToString();
                            Products b = new Products();
                            b = ProductsDB.GetProdId(a);
                            int c = b.ProductId;


                            // for testing purposes and console write
                            allItems = allItems + (i + 1) + " ";


                            
                            // gives us a value of selected items
                            for (int j = 0; j < prodNameCheckedListBox.CheckedItems.Count; j++)
                            {
                                // create a variable to store the item value
                                string x = prodNameCheckedListBox.CheckedItems[j].ToString();
                                // create a new product variable
                                Products y = new Products();
                                // this new product variable will search the DB for the product with the corresponding value
                                y = ProductsDB.GetProdId(x);
                                // create new variable that stores the product ID of the newfound product
                                int t = y.ProductId;

                                // if these values are equal, these are the values that are selected
                                // in this case we need to check the DB for existising relationship, 
                                // if it doesnt exists, add it
                                // if it exists, do nothing
                                if (t == c)
                                {
                                    System.Diagnostics.Debug.WriteLine("t: " + t + " c:" + c + " are equal");
                                    if (Products_SuppliersDB.ProductSupplierExist(t, newSup.SupplierId).Count == 0) // if returns nothing, relationship does not exist
                                        Products_SuppliersDB.AddSupplierProductID(t, newSup.SupplierId); // add to the DB
                                }


                                // check to see if the relationship exists
                                // if it exists, delete it
                                else // in the case they are not equal
                                {
                                    System.Diagnostics.Debug.WriteLine("t: " + t + " c: " + c + " are NOT equal");
                                    //if (Products_SuppliersDB.ProductSupplierExist(c, newSup.SupplierId).Count != 0) // if returns value, relationship does not exist
                                       // Products_SuppliersDB.DeleteProductSupplier(c, newSup.SupplierId);
                                }
                                   
                                
                            }

                        }

                        System.Diagnostics.Debug.WriteLine("allItems = " + allItems);
                        

                        // working code
                        // for each item that is checked
                        //for (int i = 0; i < prodNameCheckedListBox.CheckedItems.Count; i++)
                        //{


                        //    // create a variable to store the item value
                        //    string x = prodNameCheckedListBox.CheckedItems[i].ToString();
                        //    // create a new product variable
                        //    Products y = new Products();
                        //    // this new product variable will search the DB for the product with the corresponding value
                        //    y = ProductsDB.GetProdId(x);
                        //    // create new variable that stores the product ID of the newfound product
                        //    int t = y.ProductId;
                        //    // add the the Products_SupplierDB using this new product ID and inputted supplier ID

                        //    // if product supplies record does not exist, add to DB
                        //    if (Products_SuppliersDB.ProductSupplierExist(t, newSup.SupplierId).Count == 0) // returns true
                        //        Products_SuppliersDB.AddSupplierProductID(t, newSup.SupplierId);

                        //}
                        //modifySupplier = newSup;
                        if(SuppliersDB.UpdateSelectedSupplier(modifySupplier,newSup))
                            this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (SuppliersDB.UpdateSelectedSupplier(modifySupplier, newSup))
                            this.DialogResult = DialogResult.OK;
                    }
                ////}
                ////// else the name is duplicated, notify user
                ////else
                ////{
                ////    MessageBox.Show(newSup.SupName + " already exists in the database.", "Duplication Error");
                ////}
            }
        }
    }
}
