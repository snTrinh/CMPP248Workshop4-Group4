using System.Windows.Forms;
using PackagesData;
using ProductsData;
using Products_SuppliersData;
using Packages_Products_SuppliersData;
using SuppliersData;


namespace ProjectWorkshop4_CMPP248_Group4
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            packagesDataGridView.DataSource = PackagesDB.GetPackages();
            productsDataGridView.DataSource = ProductsDB.GetProducts();
            packages_Products_SuppliersDataGridView.DataSource = Packages_Products_SuppliersDB.GetPackagesProductsSuppliers();
            products_SuppliersDataGridView.DataSource = Products_SuppliersDB.GetProducts_Suppliers();
            suppliersDataGridView.DataSource = SuppliersDB.GetSuppliers();
        }
    }
}
