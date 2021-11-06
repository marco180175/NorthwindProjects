using NorthwindDAO.Src.DAO;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{
    public class OrderDetailsBusiness
    {
        private NorthwindOrderDetailsDAO northwindOrderDetails = new NorthwindOrderDetailsDAO();
        public List<OrderDetail> Get()
        {
            return northwindOrderDetails.OrderDetailsSelect();
        }
    }
}
