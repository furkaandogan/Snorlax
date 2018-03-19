using Snorlax.Repository.Model;

namespace Snorlax.Web.Api.Models.Request
{
    public class ProductPostModel
        :BasePostModel<Repository.Model.Product>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SupplierId { get; set; }
        public string CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public override Product ToRepositoyModel(RequestType requestType)
        { 
            Repository.Model.Product product= new Repository.Model.Product()
            {
                Name=this.Name,
                CategoryId=this.CategoryId,
                SupplierId=this.SupplierId,
                QuantityPerUnit=this.QuantityPerUnit,
                UnitPrice=this.UnitPrice,
                UnitsInStock=this.UnitsInStock,
                UnitsOnOrder=this.UnitsOnOrder,
                ReorderLevel=this.ReorderLevel,
                Discontinued=this.Discontinued
            };
            
            if(requestType==RequestType.PUT){
                product.Id=this.Id;
            }
            return product;
        }
    }
}
