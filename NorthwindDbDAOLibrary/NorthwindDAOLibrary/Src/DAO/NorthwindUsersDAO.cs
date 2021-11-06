using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAO.Src.DAO
{
    public class NorthwindUsersDAO:NorthwindDAO
    {
        public const string USERS_TABLE_NAME = "Users";
        public const string USERS_USER_ID = "UserID";
        public const string USERS_EMAIL = "Email";
        public const string USERS_PASSWORD = "Password";

        public NorthwindUsersDAO() : base(){ }

        public User UserSelect(string email)
        {
            User user = null;
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0} WHERE Email='{1}'", USERS_TABLE_NAME, email);
                var command = new SqlCommand(cmdText, connection);
                try
                {
                    var dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        user = new User()
                        {
                            UserID = Convert.ToInt32(dataReader[USERS_USER_ID]),
                            Email = Convert.ToString(dataReader[USERS_EMAIL]),
                            Password = Convert.ToString(dataReader[USERS_PASSWORD])                           
                        };
                    }
                    dataReader.Close();
                    command.Dispose();
                }
                catch (SqlException)
                {
                    throw;
                }
                CloseConnection(connection);
            }
            return user;
        }

        public void UserInsert(User user)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("INSERT INTO {0} ({1},{2}) VALUES('{3}','{4}')",
                    USERS_TABLE_NAME, USERS_EMAIL, USERS_PASSWORD, user.Email, user.Password);
                var command = new SqlCommand(cmdText, connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw;
                }
                command.Dispose();
                //
                CloseConnection(connection);
            }
        }
        
    }
}
