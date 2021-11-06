using NorthwindDAO.Src.DAO;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{
    public class EmployeesBusiness
    {
        private NorthwindEmployeesDAO employeesDAO = new NorthwindEmployeesDAO();
        public List<Employee> SelectdList()
        {
            return employeesDAO.EmployeesSelect();
        }
    }
}
