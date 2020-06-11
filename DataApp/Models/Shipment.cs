using System.Collections.Generic;

namespace DataApp.Models
{
    public class Shipment
    {
        public long Id { get; set; }
        public string ShipName { get; set; }
        public string StartCity { get; set; }
        public string EndCity { get; set; }

        public IEnumerable<ProductShipmentJunction>
            ProductShipments { get; set; }
    }
}
