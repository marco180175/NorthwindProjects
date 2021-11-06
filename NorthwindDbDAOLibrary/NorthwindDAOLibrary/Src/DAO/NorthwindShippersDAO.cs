using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAO.Src.DAO
{
    public class NorthwindShippersDAO: NorthwindDAO
    {
        public const string SHIPPERS_TABLE_NAME = "Shippers";
        /*!
         * 
         */
        public NorthwindShippersDAO()
            :base()
        {            
            Type type = typeof(Shipper);
            piList.AddRange(type.GetProperties());
        }
        /*!
         * 
         */
        public List<Shipper> ShippersSelect()
        {
            var table = new List<Shipper>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0}", SHIPPERS_TABLE_NAME);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var item = new Shipper();
                                FieldToProperty(item, dataReader);
                                table.Add(item);
                            }
                            dataReader.Close();
                        }
                    }
                    catch (SqlException ex)
                    {
                        CloseConnection(connection);
                        throw ex;
                    }
                }
                CloseConnection(connection);
            }
            return table;
        }
    }
}
