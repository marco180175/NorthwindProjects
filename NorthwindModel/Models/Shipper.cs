using System;
using System.Collections.ObjectModel;

namespace NorthwindModel.Models
{
    public class Shipper : Object
    {
        public Shipper()
        {

        }

        public Shipper(Int32? shipperID)
        {
            ShipperID = shipperID;
        }

        public Int32? ShipperID { get; set; }

        public String CompanyName { get; set; }

        public String Phone { get; set; }

        public override string ToString()
        {
            return CompanyName;
        }
        //public virtual Collection<Order> Orders { get; set; }
    }
}
