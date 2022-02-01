using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{
    public class BoolItem
    {
        public bool Value { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class BooleanBusiness
    {
        private List<BoolItem> list;
        public BooleanBusiness()
        {
            list = new List<BoolItem>();
            list.Add(new BoolItem() { Value = true, Index = 1 ,Name="True"});
            list.Add(new BoolItem() { Value = false, Index = 0, Name = "False" });
        }
        public List<BoolItem> SelectList()
        {
            return list;
        }
    }
}
