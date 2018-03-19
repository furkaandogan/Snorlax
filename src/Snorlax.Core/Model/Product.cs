namespace Snorlax.Core.Model
{
    public class Product
        :Base
    {
        public string Name{get;set;}
        public Supplier Supplier{get;set;}
        public Category Category{get;set;}
        public string QuantityPerUnit{get;set;}
        public decimal UnitPrice{get;set;}
        public int UnitsInStock{get;set;}
        public int UnitsOnOrder{get;set;}
        public int ReorderLevel{get;set;}
        public bool Discontinued{get;set;}
         public Product()
        {

        }
        public Product(Repository.Model.Product product)
        {
            this.Name=product.Name;
            this.QuantityPerUnit=product.QuantityPerUnit;
            this.UnitPrice=product.UnitPrice;
            this.UnitsInStock=product.UnitsInStock;
            this.UnitsOnOrder=product.UnitsOnOrder;
            this.ReorderLevel=product.ReorderLevel;
            this.Discontinued=product.Discontinued;
            this.Category=new Category(){
                Id=product.CategoryId
            };
            this.Supplier=new Supplier(){
                Id=product.SupplierId
            };

        }
    }
}