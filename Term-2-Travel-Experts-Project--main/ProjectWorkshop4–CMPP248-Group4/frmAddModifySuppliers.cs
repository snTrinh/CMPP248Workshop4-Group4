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
                // need to validate this value
                Random r = new Random();
                int rand;
                //bool x = SuppliersDB.SupplierExists(69); // returns false because ID exists
                //bool y = SuppliersDB.SupplierExists(70); // returns true cause it doesnt exist
                do
                {
                    rand = Convert.ToInt32(r.Next(0, 15000));
                }
                while (!SuppliersDB.SupplierExists(rand)); // while this is false, generate random number until one is created that doesn't exist in the DB
                    
                //if the above returns tre, assigne value to supplierID
                supplierIdTextBox.Text = rand.ToString();
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
                Validator.IsNonNegativeInt32(supplierIdTextBox, "Supplier Id") &&
                Validator.IsPresent(supNameTextBox, "Supplier Name"))
            {
                try
                {
                    string s = "";
                    for (int i = 0; i <= prodNameCheckedListBox.Items.Count - 1; i++)
                    {
                        if (prodNameCheckedListBox.GetItemChecked(i))
                        {
                            s = s + (i + 1).ToString() + " ";
                        }
                        else
                            break;
                    }
                    Console.WriteLine(s);
                    //s = "";
                    string[] variables = s.Split(' ');
                    string x = variables[0];
                    string y = variables[1];
                    string z = variables[2];
                    Console.WriteLine(x);
                    Console.WriteLine(y);
                    Console.WriteLine(z);
                    int prod1 = Convert.ToInt32(x);
                    int prod2 = Convert.ToInt32(y);
                    int prod3 = Convert.ToInt32(z);
                    Suppliers newSupplier = new Suppliers();
                    newSupplier.SupplierId = Convert.ToInt32(supplierIdTextBox.Text);

                   

                    newSupplier.SupName = supNameTextBox.Text;


                    if (SuppliersDB.AddSupplier(newSupplier) &&
                        Products_SuppliersDB.AddSupplierProductID(prod1, newSupplier.SupplierId) &&
                        Products_SuppliersDB.AddSupplierProductID(prod2, newSupplier.SupplierId) &&
                        Products_SuppliersDB.AddSupplierProductID(prod3, newSupplier.SupplierId))
                    {
                        this.DialogResult = DialogResult.OK;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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
