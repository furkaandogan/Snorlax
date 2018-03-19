namespace Snorlax.Core.Model
{
    public class Category
        :Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Category()
        {

        }
        public Category(Repository.Model.Category category)
        {
            this.Id=category.Id;
            this.Name=category.Name;
            this.Description=category.Description;
            this.Image=category.Image;
        }
    }
}