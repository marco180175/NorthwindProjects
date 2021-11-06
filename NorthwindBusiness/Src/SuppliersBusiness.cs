using NorthwindDAO.Src.DAO;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{
    public class SuppliersBusiness
    {
        private NorthwindSuppliersDAO suppliersDAO = new NorthwindSuppliersDAO();
        public List<Supplier> SelectList()
        {
            return suppliersDAO.SuppliersSelect();
        }
    }
}
