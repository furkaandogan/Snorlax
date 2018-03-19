namespace Snorlax.Repository.Model
{
    [CollectionName("Products")]
    public class Product
        :Base
    {
        public string Name{get;set;}
        public string SupplierId{get;set;}
        public string CategoryId{get;set;}
        public string QuantityPerUnit{get;set;}
        public decimal UnitPrice{get;set;}
        public int UnitsInStock{get;set;}
        public int UnitsOnOrder{get;set;}
        public int ReorderLevel{get;set;}
        public bool Discontinued{get;set;}
        public Product()
            :base()
        {

        }
    }
}