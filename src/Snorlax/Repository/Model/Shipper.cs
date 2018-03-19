namespace Snorlax.Repository.Model
{
    [CollectionName("Shippers")]
    public class Shipper
        :Base
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public Shipper()
            :base()
        {

        }
    }
}