using System;
using System.Collections.ObjectModel;

namespace NorthwindModel.Models
{
    public interface ICategory
    {
        Int32 CategoryID { get; set; }
        String CategoryName { get; set; }
        string ToString();
    }

    public class Category : ICategory
    {
        public Category()
        {

        }

        public Category(Int32 categoryID)
        {
            CategoryID = categoryID;
        }

        public Int32 CategoryID { get; set; }

        public String CategoryName { get; set; }

        public String Description { get; set; }

        //public Byte[] Picture { get; set; }

        //public virtual Collection<Product> Products { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}]-{1}", CategoryID, CategoryName);
        }
    }
}
