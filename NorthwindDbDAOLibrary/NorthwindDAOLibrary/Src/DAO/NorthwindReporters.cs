using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAO.Src.DAO
{
    /*!
     * Gera relatorios entre varias tabelas
     */
    public class NorthwindReporters : NorthwindDAO
    {
        public DataTable Select(int year)
        {
            var table = new DataTable();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = BuildQuery(year);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {                  
                            table.Load(dataReader);                            
                            dataReader.Close();
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw;
                    }
                }
                CloseConnection(connection);
            }
            return table;
        }

        private string BuildQuery(int year)
        {
            var query = new StringBuilder();

            query.Append("select Customers.CompanyName, Orders.OrderDate ");
            query.Append("from Customers inner join Orders ");
            query.Append("on Customers.CustomerID = Orders.CustomerID ");
            query.Append(string.Format("where year(Orders.OrderDate) = '{0}'",year));

            return query.ToString();
        }        
    }
}
