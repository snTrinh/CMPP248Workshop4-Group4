using ProductsData;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectWorkshop4_CMPP248_Group4
{
    public partial class frmAddModifyProducts : Form
    {
        public frmAddModifyProducts()
        {
            InitializeComponent();
        }
        public bool addProduct = true; // true if user wants to add product; false if modify
        public Products newProduct;
        public Products modifyProduct;

        private void frmAddModifyProducts_Load(object sender, EventArgs e)
        {
            if (addProduct)
            {
                btnModify.Visible = false;
                this.Text = "Add Product";
            }
            else
            {
                DisplaySelectedProduct();
                btnAdd.Visible = false;
                this.Text = "Modify Product";
            }
        }

        private void DisplaySelectedProduct()
        {
            productIdTextBox.Text = modifyProduct.ProductId.ToString();
            prodNameTextBox.Text = modifyProduct.ProdName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(prodNameTextBox, "Product Type") &&
                Validator.IsNonNumeric(prodNameTextBox, "Product Type"))
            {
                try
                {
                    newProduct = new Products();
                    newProduct.ProdName = prodNameTextBox.Text;
                    if (ProductsDB.ProductNameExists(newProduct.ProdName).Count == 0)
                    {
                        try
                        {
                            newProduct.ProductId = ProductsDB.AddProduct(newProduct);
                            this.DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show(newProduct.ProdName + " already exists in the database.", "Duplication Error");
                    }
                }
                catch (DBConcurrencyException)
                {
                    MessageBox.Show("Concurrency Error: another user updated or deleted data. Try again", "Concurrency Error");
                }
                // this error catches upon the deletion of a cell of which is referenced in another table
                catch (SqlException ex)
                {
                    MessageBox.Show("Error because of referenced value: " + ex.Message, "Null Error");
                }
                //this error catches null errors 
                catch (NoNullAllowedException ex)
                {
                    MessageBox.Show("Error because of null value: " + ex.Message, "Null Error");
                }
            }
        }



        private void btnModify_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(prodNameTextBox, "Product Type") &&
                Validator.IsNonNumeric(prodNameTextBox, "Product Type"))
            {
                try
                {
                    Products newProd = new Products();
                    newProd.ProductId = modifyProduct.ProductId;
                    newProd.ProdName = prodNameTextBox.Text;
                    if (ProductsDB.ProductNameExists(newProd.ProdName).Count == 0)
                    {
                        if (!ProductsDB.UpdateSelectedProduct(modifyProduct, newProd))
                        {
                            MessageBox.Show("Another user has updated or deleted this package", "DataBase Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            modifyProduct = newProd;
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        MessageBox.Show(newProd.ProdName + " already exists in the database.", "Duplication Error");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Concurrency Error: another user updated or deleted data. Try again", "Concurrency Error");
                    // close dialog
                    DialogResult = DialogResult.Cancel;
                }
            }
        }

    }
}
