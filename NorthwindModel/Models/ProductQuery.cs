using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindModel.Models
{
    public class ProductQuery
    {
        public ProductQuery()
        {

        }        

        public Int32 ProductID { get; set; }

        public String ProductName { get; set; }

        public String Supplier { get; set; }

        public String Category { get; set; }               

        public Decimal UnitPrice { get; set; }

        public Int16 UnitsInStock { get; set; }

        public Int16 UnitsOnOrder { get; set; }        

        public Boolean Discontinued { get; set; }

        
    }
}
