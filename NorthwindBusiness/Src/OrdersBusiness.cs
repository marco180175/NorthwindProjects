using NorthwindDAO.Src.DAO;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{
    public class OrdersBusiness: ICustomBusiness
    {
        private NorthwindOrdersDAO ordersDAO = new NorthwindOrdersDAO();

        public object SelectItem(int id)
        {
            return ordersDAO.OrdersSelect(id);
        }

        public List<object> SelectList()
        {

            List<Order> list = ordersDAO.OrdersSelect();
            return list.Cast<object>().ToList();
        }        

        public void InsertItem(object item)
        {
            ordersDAO.OrderInsert((Order)item);
        }

        public void UpdateItem(object item)
        {
            ordersDAO.OrderUpdate((Order)item);
        }
        public void UpdateItem(object item,string propertyName)
        {
            ordersDAO.OrderUpdate((Order)item, propertyName);
        }
        public void DeleteItem(int id)
        { }


    }
}
