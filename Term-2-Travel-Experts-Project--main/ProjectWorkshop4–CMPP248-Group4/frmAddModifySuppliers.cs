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
            //bool x = SuppliersDB.SupplierExists(69); // returns false because ID exists
            //bool y = SuppliersDB.SupplierExists(70); // returns true cause it doesn't exist
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(supplierIdTextBox, "Supplier Id") &&
                Validator.IsPresent(supNameTextBox, "Supplier Name"))
            {
                Suppliers newSupplier = new Suppliers();
                newSupplier.SupplierId = Convert.ToInt32(supplierIdTextBox.Text);
                newSupplier.SupName = supNameTextBox.Text;

                if(prodNameCheckedListBox.CheckedItems.Count > 0)
                {
                    SuppliersDB.AddSupplier(newSupplier);
                    for (int i = 0; i < prodNameCheckedListBox.CheckedItems.Count; i++)
                    {
                        string x = prodNameCheckedListBox.CheckedItems[i].ToString();
                        Products y = new Products();
                        y = ProductsDB.GetProdId(x);
                        int t = y.ProductId;
                        Products_SuppliersDB.AddSupplierProductID(t, newSupplier.SupplierId);
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else 
                {
                    SuppliersDB.AddSupplier(newSupplier);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void PutSupplierData(Suppliers supplier)
        {
            supplier.SupplierId = Convert.ToInt32(supplierIdTextBox.Text);
            supplier.SupName = supNameTextBox.Text;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(supNameTextBox, "Supplier Name"))
            {

                Suppliers newSup = new Suppliers();
                newSup.SupplierId = modifySupplier.SupplierId;
                newSup.SupName = supNameTextBox.Text;
                try
                {
                    if (!SuppliersDB.UpdateSelectedSupplier(modifySupplier, newSup))
                    {
                        MessageBox.Show("Another user has updated or deleted this package", "DataBase Error");
                        this.DialogResult = DialogResult.Retry;
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
