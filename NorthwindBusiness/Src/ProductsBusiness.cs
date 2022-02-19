using NorthwindDAO.Src.DAO;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{
    public class ProductsBusiness //: ICustomBusiness
    {
        private NorthwindProductsDAO productsDAO = new NorthwindProductsDAO();

        public Product SelectItem(int id)
        {
            return productsDAO.ProductSelect(id);
        }
        public List<Product> SelectListByCategory(int categoryID)
        {
            return productsDAO.ProductsSelect(categoryID);
        }

        public List<Product> SelectList()
        {
            return productsDAO.ProductsSelect();             
        }

        public List<Product> SelectList(string filter)
        {
            return productsDAO.ProductsSelect(filter);
        }

        public List<ProductQuery> SelectListQuery()
        {
            return productsDAO.ProductsSelectQuery();
        }

        public List<ProductQuery> SelectListQuery(string filter)
        {
            return productsDAO.ProductsSelectQuery(filter);
        }

        public void InsertItem(object item)
        {            
            productsDAO.ProductInsert((Product)item);
        }

        public void UpdateItem(object item)
        {            
            productsDAO.ProductUpdate((Product)item);
        }

        public void DeleteItem(int id)
        {
            productsDAO.ProductDelete(id);
        }
    }
}
