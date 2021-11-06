using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAO.Src.DAO
{            
    public class StoredProcedure : NorthwindDAO
    {
        public DataTable Select(string procedureName, List<KeyValuePair<string, object>> parans)
        {
            DataTable table = new DataTable();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    foreach(var param in parans)                    
                        command.Parameters.AddWithValue(param.Key,param.Value);                    
                    SqlDataReader datareader = command.ExecuteReader();
                    table.Load(datareader);
                    datareader.Close();                                    
                }
                CloseConnection(connection);
            }
            return table;
        }        
    }       

    
}
