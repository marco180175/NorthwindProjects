using NorthwindDAO.Src.DAO;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{
    public enum FilterType
    {
        Country,
        City
    }

    public class CustomersBusiness
    {
        private NorthwindCustomersDAO customersDAO = new NorthwindCustomersDAO();

        public List<Customer> SelectList()
        {
            return customersDAO.Select();
        }

        public List<Customer> Get(string className,FilterType filter)
        {
            switch (filter)
            {
                case FilterType.Country:
                    return customersDAO.SelectByCountry(className);
                case FilterType.City:
                    return customersDAO.SelectByCity(className);
                default:
                    return null;
            }
        }        
    }
}
