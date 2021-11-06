using NorthwindDAO.Src.DAO;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{
    public class ShippersBusiness
    {
        private NorthwindShippersDAO shippersDAO = new NorthwindShippersDAO();

        public List<Shipper> SelectList()
        {
            try
            {
                return shippersDAO.ShippersSelect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
