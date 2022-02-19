using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindModel.Models
{
    public class FilterProducts
    {
        public string FieldName { get; set; }
        public string Supplier { get; set; }
        public string Category { get; set; }
        public bool Discontinued { get; set; }
        public override string ToString()
        {
            switch(FieldName)
            {
                case "0":
                    return null;
                case "1":
                    return String.Format("SupplierID={0}", Supplier);
                case "2":
                    return String.Format("CategoryID={0}", Category);
                case "3":
                    {
                        if (Discontinued)
                            return String.Format("Discontinued=1");
                        else
                            return String.Format("Discontinued=0");
                    }                    
                default:
                    return null;
            }             
        }
    }
}
