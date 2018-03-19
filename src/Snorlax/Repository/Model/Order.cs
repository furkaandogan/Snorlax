using System;

namespace Snorlax.Repository.Model
{
    [CollectionName("Orders")]
    public class Order
        :Base
    {
        public string CustomerId{get;set;}
        public string EmployeeId{get;set;}
        public DateTime OrderDate { get; set; }
        public DateTime RequierdDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public Order()
            :base()
        {

        }
        
    }
}