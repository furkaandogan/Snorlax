namespace Snorlax.Repository.Model
{
    [CollectionName("Categories")]
    public class Category
        :Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Category()
            :base()
        {

        }
        public Category(string id)
            :base(id)
        {

        }
    }
}