using NorthwindDAO.Src.DAO;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{
    public class CategoriesBusiness : ICustomBusiness
    {
        private NorthwindCategoriesDAO categoriesDAO = new NorthwindCategoriesDAO();

        public List<object> SelectList()
        {            
            try
            {
                List<Category> list = categoriesDAO.CategoriesSelect();
                return list.Cast<object>().ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        public object SelectItem(int id)
        {
            return categoriesDAO.CategoriesSelect(id);
        }

        public void InsertItem(object item)
        {
            categoriesDAO.CategoriesInsert((Category)item);
        }

        public void UpdateItem(object item)
        {
            categoriesDAO.CategoriesUpdate((Category)item);
        }

        public void DeleteItem(int id)
        {
            categoriesDAO.CategoriesDelete(id);
        }
    }
}
