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
        public string FieldValue { get; set; }
        public override string ToString()
        {
            switch(FieldName)
            {
                case "0":
                    return null;
                case "1":
                    return String.Format("SupplierID={0}", FieldValue);
                case "2":
                    return String.Format("CategoryID={0}", FieldValue);
                case "3":
                    return String.Format("Discontinued={0}", FieldValue);
                default:
                    return null;
            }             
        }
    }
}
