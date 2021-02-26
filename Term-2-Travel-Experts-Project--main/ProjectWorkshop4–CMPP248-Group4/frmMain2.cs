using Packages_Products_SuppliersData;
using PackagesData;
using Products_SuppliersData;
using ProductsData;
using SuppliersData;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjectWorkshop4_CMPP248_Group4
{
    public partial class frmMain : Form
    {
        private Products newProduct;
        private Products modifyProduct;

        private Suppliers newSupplier;
        private Suppliers modifySupplier;

        private Packages newPackage;
        public Packages modifyPackage;
        public Packages_Products_Suppliers pkgProdSup; 
        


        //public object Packages_Product_SuppliersDB { get; private set; }

        public frmMain()
        {
            InitializeComponent();
            Text = "Travel Experts";
        }

        // On load of form, display form from 5 databases
        // GUI designed by Susan Trinh: January 26, 2021
        // Coded by Susan Trinh: January 26, 2021
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            // display Packages grid view
            packagesDataGridView.DataSource = PackagesDB.GetPackages();
            packagesBindingSource.DataSource = packagesDataGridView.DataSource = PackagesDB.GetPackages();
            // by default the first index is selected
            
            packagesDataGridView.Rows[0].Selected = true;
            DisplayCurrentPackage(0);
            lblPkg.Text = packagesDataGridView.Rows.Count.ToString();
            //default is that nothing is selected
            

           
            productsDataGridView.DataSource = ProductsDB.GetProducts();
           
            productsDataGridView.Rows[0].Selected = true;
            DisplayCurrentProduct(0);
            lblProd.Text = productsDataGridView.Rows.Count.ToString();

            // display Suppliers on suppliers tab
            suppliersDataGridView.DataSource = SuppliersDB.GetSuppliers();
            // by default the first index is selected
            suppliersDataGridView.Rows[0].Selected = true;
            DisplayCurrentSupplier(0);
            lblSup.Text = suppliersDataGridView.Rows.Count.ToString();

         

           
            
          
        }

        // Display current package
        // Preliminary code by Susan Trinh: January 28, 2021
        public void DisplayCurrentPackage(int rowIndex)
        {
            Packages selectedPackage = new Packages();
            selectedPackage.PackageId = (int)packagesDataGridView["Column1", rowIndex].Value;
            selectedPackage.PkgName = (string)packagesDataGridView["dataGridViewTextBoxColumn2", rowIndex].Value;
            selectedPackage.PkgStartDate = (DateTime)packagesDataGridView["dataGridViewTextBoxColumn3", rowIndex].Value;
            selectedPackage.PkgEndDate = (DateTime)packagesDataGridView["dataGridViewTextBoxColumn4", rowIndex].Value;
            selectedPackage.PkgDesc = (string)packagesDataGridView["dataGridViewTextBoxColumn5", rowIndex].Value;
            selectedPackage.PkgBasePrice = (decimal)packagesDataGridView["dataGridViewTextBoxColumn6", rowIndex].Value;
            selectedPackage.PkgAgencyCommission = (decimal)packagesDataGridView["dataGridViewTextBoxColumn7", rowIndex].Value;
            modifyPackage = selectedPackage;
        }

        // Display current product
        // Preliminary code by Susan Trinh: January 28, 2021
        public void DisplayCurrentProduct(int rowIndex)
        {
            Products selectedProduct = new Products();
            selectedProduct.ProductId = (int)productsDataGridView["dataGridViewTextBoxColumn11", rowIndex].Value;
            selectedProduct.ProdName = (string)productsDataGridView["dataGridViewTextBoxColumn12", rowIndex].Value;
            modifyProduct = selectedProduct;
        }

        // Display current supplier
        // Preliminary code by Susan Trinh: January 28, 2021
        public void DisplayCurrentSupplier(int rowIndex)
        {
            Suppliers selectedSupplier = new Suppliers();
            selectedSupplier.SupplierId = (int)suppliersDataGridView["dataGridViewTextBoxColumn13", rowIndex].Value;
            selectedSupplier.SupName = (string)suppliersDataGridView["dataGridViewTextBoxColumn14", rowIndex].Value;
            modifySupplier = selectedSupplier;
        }
        // PACKAGES TAB: ADD - adds new package
        // Preliminary code by Susan Trinh: January 27, 2021
        // Data values extracted by ***: ***
        private void addToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            frmModifyPackage addPackageForm = new frmModifyPackage();
            addPackageForm.newPackage = newPackage;
            // on successful add we must update the DB
            DialogResult result = addPackageForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                newPackage = addPackageForm.newPackage;
                packagesDataGridView.DataSource = PackagesDB.GetPackages();
                lblPkg.Text = packagesDataGridView.Rows.Count.ToString();
            }
        }

        // PACKAGES TAB: MODIFY - modify package
        // Preliminary code by Susan Trinh: January 27, 2021
        // Data values extracted by ***: ***
        private void modifyToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
    
            frmModifyPackage modifyPackageForm = new frmModifyPackage();
            if (modifyPackage != null)
            {
                modifyPackageForm.package = modifyPackage;
                modifyPackageForm.addPackage = false;
                DialogResult result = modifyPackageForm.ShowDialog();
                // on successful modify we must update the DB
                if (result == DialogResult.OK)
                {
                    modifyPackage = modifyPackageForm.package;
                    packagesDataGridView.DataSource = PackagesDB.GetPackages();

                }
                frmMain_Load(null, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Please select a package to modify.", "Package Selection");
                frmMain_Load(null, EventArgs.Empty);
            }
           
        }
        // PACKAGES Grid View cell click
        // Preliminary code by Susan Trinh: January 27, 2021
        public void packagesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pkgRow = packagesDataGridView.CurrentCell.RowIndex;
          
            DisplayCurrentPackage(pkgRow);
        }

        // PRODUCT TAB: ADD - adds new product
        // Preliminary code by Susan Trinh: January 27, 2021
        // Data values extracted by ***: ***
        private void addToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmAddModifyProducts addProductForm = new frmAddModifyProducts();
            addProductForm.newProduct = newProduct;
            DialogResult result = addProductForm.ShowDialog();
            // on successful add we must update the DB
            if (result == DialogResult.OK)
            {
                newProduct = addProductForm.newProduct;
                // update datagrid
                productsDataGridView.DataSource = ProductsDB.GetProducts();
                // update label on main
                lblProd.Text = productsDataGridView.Rows.Count.ToString();
            }

        }

        // PRODUCT TAB: MODIFY - modify product
        // Preliminary code by Susan Trinh: January 27, 2021
        // Data values extracted by ***: ***
        private void modifyToolStripMenuItem5_Click(object sender, System.EventArgs e)
        {
            frmAddModifyProducts modifyProductForm = new frmAddModifyProducts();
            modifyProductForm.modifyProduct = modifyProduct;
            modifyProductForm.addProduct = false;
            // on successful modify we must update the DB
            DialogResult result = modifyProductForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                modifyProduct = modifyProductForm.modifyProduct;
                // refresh datagrid view
                productsDataGridView.DataSource = ProductsDB.GetProducts();
                // update label on main
                lblProd.Text = productsDataGridView.Rows.Count.ToString();
            }
            else 
            {
                // refresh datagrid view
                productsDataGridView.DataSource = ProductsDB.GetProducts();
                // update label on main
                lblProd.Text = productsDataGridView.Rows.Count.ToString();
            }
        }

        // PRODUCT TAB: DELETE - delete product
        // Preliminary code by Susan Trinh: January 27, 2021
        private void deleteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            // confirm deletion
            DialogResult result = MessageBox.Show("Delete " + modifyProduct.ProdName +"?",
               "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                { 
                    // if a product exists within the Product_Suppliers table
                    if (Products_SuppliersDB.IfProductSuppliersExistsByProdID(modifyProduct.ProductId))
                    {
                        // delete the data associated with the product ID
                        Products_SuppliersDB.DeleteProductSupplierByProductId(modifyProduct.ProductId);
                        // delete the product
                        ProductsDB.DeleteProduct(modifyProduct);
                        // repopulate the grid with the new DB data
                        productsDataGridView.DataSource = ProductsDB.GetProducts();
                        lblProd.Text = productsDataGridView.Rows.Count.ToString();
                    }
                    // product has no Products_Suppliers association
                    else
                    {
                        // delete the product
                        ProductsDB.DeleteProduct(modifyProduct);
                        // repopulate the grid with the new DB data
                        productsDataGridView.DataSource = ProductsDB.GetProducts();
                        lblProd.Text = productsDataGridView.Rows.Count.ToString();

                    }
                } 
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        // SUPPLIER TAB: ADD - adds new supplier
        // Preliminary code by Susan Trinh: January 27, 2021
        // Data values extracted by ***: ***
        private void addToolStripMenuItem2_Click(object sender, System.EventArgs e)
        {
            frmAddModifySuppliers addSuppliersForm = new frmAddModifySuppliers();
            addSuppliersForm.newSupplier = newSupplier;
            DialogResult result = addSuppliersForm.ShowDialog();
            // on successful add we must update the DB
            if (result == DialogResult.OK)
            {
                newSupplier = addSuppliersForm.newSupplier;
                suppliersDataGridView.DataSource = SuppliersDB.GetSuppliers();
                lblSup.Text = suppliersDataGridView.Rows.Count.ToString();
            }

        }

        // SUPPLIER TAB: MODIFY - modify supplier
        // Preliminary code by Susan Trinh: January 27, 2021
        private void modifyToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            frmAddModifySuppliers modifySupplierForm = new frmAddModifySuppliers();
            modifySupplierForm.modifySupplier = modifySupplier;
            modifySupplierForm.addSupplier = false;
            DialogResult result = modifySupplierForm.ShowDialog();
            // on successful modify we must update the DB
            if (result == DialogResult.OK)
            {
                modifySupplier = modifySupplierForm.modifySupplier;
                // update data grid view
                suppliersDataGridView.DataSource = SuppliersDB.GetSuppliers();
                // update label on main
                lblSup.Text = suppliersDataGridView.Rows.Count.ToString();
            }
            else
            {
                // update data grid view
                suppliersDataGridView.DataSource = SuppliersDB.GetSuppliers();
                // update label on main
                lblSup.Text = suppliersDataGridView.Rows.Count.ToString();
            }

        }
        // SUPPLIER TAB: Delete - delete supplier
        // Preliminary code by Susan Trinh: January 27, 2021
        private void deleteToolStripMenuItem2_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete " + modifySupplier.SupName +"?",
              "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (Products_SuppliersDB.IfProductSuppliersExistsBySupplierId(modifySupplier.SupplierId))
                    {
                        Products_SuppliersDB.DeleteProductSupplierBySupplierId(modifySupplier.SupplierId);
                        SuppliersDB.DeleteSupplier(modifySupplier);
                        suppliersDataGridView.DataSource = SuppliersDB.GetSuppliers();
                        lblSup.Text = suppliersDataGridView.Rows.Count.ToString();
                    }
                    else
                    {
                        SuppliersDB.DeleteSupplier(modifySupplier);
                        suppliersDataGridView.DataSource = SuppliersDB.GetSuppliers();
                        lblSup.Text = suppliersDataGridView.Rows.Count.ToString();
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("This supplier cannot be deleted because it is associated to a package. Please remove from packages before deleting supplier");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void suppliersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int supTypeProdRow = suppliersDataGridView.CurrentCell.RowIndex;
            DisplayCurrentSupplier(supTypeProdRow);
        }

        // PACKAGES TAB: DELETE - delete packages
        // Code by Julie Tran January 31 2021
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<int> productSupplierIDList;
            Packages_Products_Suppliers pkgProdSup = new Packages_Products_Suppliers();
            productSupplierIDList = Packages_Products_SuppliersDB.GetProductSupplierID(modifyPackage.PackageId);
            DialogResult result = MessageBox.Show("Delete " + modifyPackage.PkgName + "? There are " + productSupplierIDList.Count + " associated product suppliers. All will be deleted.",
                               "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (productSupplierIDList.Count == 0)
            {

                PackagesDB.DelPackage(modifyPackage);
                packagesDataGridView.DataSource = PackagesDB.GetPackages();
            }
            else //there's associated products suppliers
            {
                //delete each product supplier that is associated to the package, prior to deleting the package
                pkgProdSup = new Packages_Products_Suppliers();
                for (int i = 0; i < productSupplierIDList.Count; i++)
                {
                    
                    pkgProdSup.PackageId = modifyPackage.PackageId;
                    pkgProdSup.ProductSupplerId = productSupplierIDList[i];
                    Packages_Products_SuppliersDB.DeletePackProdSuppAssociation(pkgProdSup);

                }
                PackagesDB.DelPackage(modifyPackage);
                packagesDataGridView.DataSource = PackagesDB.GetPackages();
            }
            lblPkg.Text = packagesDataGridView.Rows.Count.ToString();
        }



        // exit on overview
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // exit on packages
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // exit oon products
        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // exit on suppliers
        private void exitToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // exit on agencies
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void productsDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int prodNumSupRow = productsDataGridView.CurrentCell.RowIndex;
            DisplayCurrentProduct(prodNumSupRow);
        }
    }
}
