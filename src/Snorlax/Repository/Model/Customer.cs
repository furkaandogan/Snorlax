namespace Snorlax.Repository.Model
{
    [CollectionName("Customers")]
    public class Customer
        :Base
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public Customer()
            :base()
        {

        }
       
    }
}