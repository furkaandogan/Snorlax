using Snorlax.Repository.Model;

namespace Snorlax.Web.Api.Models.Request
{
    public class CategoryPostModel
        :BasePostModel<Repository.Model.Category>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public CategoryPostModel() 
        {

        }

        public override Category ToRepositoyModel(RequestType requestType)
        {
            Category category= new Category()
            {
                Description=this.Description,
                Name=this.Name,
                Image=this.Image
            };
            if(requestType==RequestType.PUT){
                category.Id=this.Id;
            }
            return category;
        }
    }
}