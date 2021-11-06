using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAO.Src.DAO
{
    public class NorthwindEmployeesDAO : NorthwindDAO
    {
        public string EMPLOYEES_TABLE_NAME = "Employees";
        public string EMPLOYEES_EMPLOYEE_ID = "EmployeeID";
        public string EMPLOYEES_LAST_NAME = "LastName";
        public string EMPLOYEES_FIRST_NAME = "FirstName";
        public string EMPLOYEES_TITLE = "Title";
        public string EMPLOYEES_TITLE_OF_COURTESY = "TitleOfCourtesy";
        public string EMPLOYEES_BIRTH_DATE = "BirthDate";
        public string EMPLOYEES_HIRE_DATE = "HireDate";
        public string EMPLOYEES_ADDRESS = "Address";
        public string EMPLOYEES_CITY = "City";
        public string EMPLOYEES_REGION = "Region";
        public string EMPLOYEES_POSTAL_CODE = "PostalCode";
        public string EMPLOYEES_COUNTRY = "Country";
        public string EMPLOYEES_HOME_PHONE = "HomePhone";
        public string EMPLOYEES_EXTENSION = "Extension";        
        public string EMPLOYEES_NOTES = "Notes";
        public string EMPLOYEES_REPORTS_TO = "ReportsTo";
        //public String PhotoPath { get; set; }
        //public Byte[] Photo { get; set; }
        //
        public NorthwindEmployeesDAO() 
            : base()
        {   
            Type type = typeof(Employee);
            piList.AddRange(type.GetProperties());
        }

        public List<Employee> EmployeesSelect()
        {
            List<Employee> table = new List<Employee>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0}", EMPLOYEES_TABLE_NAME);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var item = new Employee();
                                FieldToProperty(item, dataReader);
                                table.Add(item);
                            }
                            dataReader.Close();
                        }
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                }
                CloseConnection(connection);
            }
            return table;            
        }
    }
}
