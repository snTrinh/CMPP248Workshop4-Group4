using ProductsData;
using System;
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
                newProduct = new Products();
                this.PutProductData(newProduct);
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
        }

        private void PutProductData(Products product)
        {
            product.ProdName = prodNameTextBox.Text;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(prodNameTextBox, "Product Type") &&
                Validator.IsNonNumeric(prodNameTextBox, "Product Type"))
            {
                Products newProd = new Products();
                newProd.ProductId = modifyProduct.ProductId;
                newProd.ProdName = prodNameTextBox.Text;
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating data " + ex.Message, ex.GetType().ToString());
                }
            }
        }

    }
}
