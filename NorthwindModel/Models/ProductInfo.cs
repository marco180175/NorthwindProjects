using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindModel.Models
{
    public class ProductInfo
    {
        public Int32 ProductID { get; set; }

        public String ProductName { get; set; }

        public Decimal UnitPrice { get; set; }
    }
}
