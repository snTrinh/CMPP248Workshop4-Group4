/*
 * Class constructor for Product_Supplier 
 * Created by Julie  on January 26, 2021
 */
namespace Products_SuppliersData
{
    public class Products_Suppliers
    {
        public int ProductSupplierId { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
    }

    // displays the number of suppliers associated to a product
    // added by Susan Trinh: January 28, 2021
    public class ProductsNumSuppliers
    {
        public int ProductId { get; set; }
        public string ProdName { get; set; }
        public int NumOfSup { get; set; }
    }

    // displays the type of products associated with a supplier
    // added by Susan Trinh: January 28, 2021
    public class SuppliersTypeOfProducts
    {
        public int SupplierId { get; set; }
        public string SupName { get; set; }
        public string ProdName { get; set; }
    }

    public class SuppliersProdId
    {
        public int SupplierId { get; set; }
        public string SupName { get; set; }
        public int ProductId { get; set; }
    }

    // displays the number of products provided by a supplier
    // added by Susan Trinh: February 2, 2021
    public class SuppliersNumOfProducts
    {
        public int SupplierId { get; set; }
        public string SupName { get; set; }
        public int NumOfProd { get; set; }
    }
    //for package modify table only 
    //added by Julie Tran: January 30, 2021 
    public class ExistingProductSupplierName
    {
        public int ProductId { get; set; }
        public string SupName { get; set; }
        public string ProdName { get; set; }
    }

      public class ProductSupplierAll
    {        
        //from product table
        public int ProductId { get; set; }
        public string ProdName { get; set; }
        //from supplier table
        public int SupplierId { get; set; }
        public string SupName { get; set; }
        //from product_supplier table
        public int ProductSupplierId { get; set; }
    }

}

