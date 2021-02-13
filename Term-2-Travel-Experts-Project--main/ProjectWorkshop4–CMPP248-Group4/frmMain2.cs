using Packages_Products_SuppliersData;
using PackagesData;
using Products_SuppliersData;
using ProductsData;
using SuppliersData;
using AgentsAgencyData;
using System;
using System.Windows.Forms;

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
        
        public Agencies selectedAgency;

        public frmMain()
        {
            InitializeComponent();
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

            // testing only
            productsDataGridView.DataSource = ProductsDB.GetProducts();
            //productsBindingSource.DataSource = ProductsDB.GetProducts();
            productsDataGridView.Rows[0].Selected = true;
            DisplayCurrentProduct(0);
            lblProd.Text = productsDataGridView.Rows.Count.ToString();

            // display Suppliers on suppliers tab
            suppliersDataGridView.DataSource = SuppliersDB.GetSuppliers();
            // by default the first index is selected
            suppliersDataGridView.Rows[0].Selected = true;
            DisplayCurrentSupplier(0);
            lblSup.Text = suppliersDataGridView.Rows.Count.ToString();

            //suppliersNumOfProductsDataGridView.DataSource = Products_SuppliersDB.GetSuppliersNumOfProducts();

            agenciesBindingSource1.DataSource = AgentsAgencyDB.GetAgencies();
            
            lblAgencies.Text = AgentsAgencyDB.GetAgencies().Count.ToString();

            // int id = Convert.ToInt32(agencyIdComboBox.Text);
            agentsDataGridView.DataSource = AgentsAgencyDB.GetAgents();
            lblAgents.Text = AgentsAgencyDB.GetAgents().Count.ToString();
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
            modifyPackageForm.package = modifyPackage;
            modifyPackageForm.addPackage = false;
            DialogResult result = modifyPackageForm.ShowDialog();
            // on successful modify we must update the DB
            if (result == DialogResult.OK)
            {
                modifyPackage = modifyPackageForm.package;
                packagesDataGridView.DataSource = PackagesDB.GetPackages();
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
                productsDataGridView.DataSource = ProductsDB.GetProducts();
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
                //productsNumSuppliersDataGridView.DataSource = Products_SuppliersDB.GetProductsNumSuppliers();
                productsDataGridView.DataSource = ProductsDB.GetProducts();
            }
        }

        // PRODUCT TAB: DELETE - delete product
        // Preliminary code by Susan Trinh: January 27, 2021
        private void deleteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete " + modifyProduct.ProdName +"?",
               "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (!ProductsDB.DeleteProduct(modifyProduct))
                    {
                        MessageBox.Show("Another user has updated or deleted " +
                              "that product.", "Concurrency error");
                    }
                    else
                    {

                        ProductsDB.DeleteProduct(modifyProduct);
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
                //suppliersNumOfProductsDataGridView.DataSource = Products_SuppliersDB.GetSuppliersNumOfProducts();
                lblSup.Text = suppliersDataGridView.Rows.Count.ToString();
            }

        }

        // SUPPLIER TAB: MODIFY - modify supplier
        // Preliminary code by Susan Trinh: January 27, 2021
        // Data values extracted by ***: ***
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
                suppliersDataGridView.DataSource = SuppliersDB.GetSuppliers();
                //suppliersNumOfProductsDataGridView.DataSource = Products_SuppliersDB.GetSuppliersNumOfProducts();
            }
            Console.WriteLine(modifySupplier);
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
                    //if (!SuppliersDB.DeleteSupplier(modifySupplier))
                    //{
                    //    MessageBox.Show("Another user has updated or deleted " +
                    //          "that product.", "Concurrency error");
                    //}
                    //else
                    //{
                        if(Products_SuppliersDB.IfProductSuppliersExists(modifySupplier.SupplierId))
                        {
                                Products_SuppliersDB.DeleteProductSupplier(modifySupplier.SupplierId);
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
                        

                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }

        }

        // PRODUCTS Grid View cell click
        // Preliminary code by Susan Trinh: January 27, 2021
        // Revised code by Susan Trinh: January 28, 2021
        // On click of the display only table, redirect to the Products data
        private void productsNumSuppliersDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //int prodNumSupRow = productsNumSuppliersDataGridView.CurrentCell.RowIndex;
            //DisplayCurrentProduct(prodNumSupRow);
        }
        private void suppliersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int supTypeProdRow = suppliersDataGridView.CurrentCell.RowIndex;
            DisplayCurrentSupplier(supTypeProdRow);
        }

        // PACKAGES TAB: DELETE - delete product
        // Code by Julie Tran January 31 2021
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Delete " + modifyPackage.PkgName + "?",
              "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (!PackagesDB.DelPackage(modifyPackage))
                    {
                        MessageBox.Show("Another user has updated or deleted " +
                              "that customer.", "Concurrency error");
                    }
                    else
                    {
                        PackagesDB.DelPackage(modifyPackage);
                        packagesDataGridView.DataSource = PackagesDB.GetPackages();
                        lblPkg.Text = packagesDataGridView.Rows.Count.ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }

            
            }
        }

        private void productsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int prodNumSupRow = productsDataGridView.CurrentCell.RowIndex;
            DisplayCurrentProduct(prodNumSupRow);
        }

        private void agencyIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //agenciesBindingSource1.DataSource = AgentsAgencyDB.GetAgencies();
            ////Console.WriteLine(agencyIdComboBox.Text); 
            ////if(agencyIdComboBox.Text !=null)
            ////{
            ////    //int id = Convert.ToInt32(agencyIdComboBox.Text);
            ////    agentsBindingSource.DataSource = AgentsAgencyDB.GetAgentsByID(0);
            ////}
            ////int id = Convert.ToInt32(agencyIdComboBox.Text);
            //agentsBindingSource.DataSource = AgentsAgencyDB.GetAgentsByID(1);
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
        //
    }
}
