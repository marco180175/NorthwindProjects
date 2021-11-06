using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAO.Src.DAO
{
    public class NorthwindShoppingCartsDAO : NorthwindDAO
    {
        public const string SHOPPING_CART_TABLE_NAME = "ShoppingCarts";
        public const string SHOPPING_CART_SHOPPING_CART_ID = "ShoppingCartID";
        public const string SHOPPING_CART_CUSTOMER_ID = "CustomerID";
        public const string SHOPPING_CART_DATE = "PurchaseDate";
        public const string SHOPPING_CART_DESCRIPTION = "Description";

        public NorthwindShoppingCartsDAO() :
            base()
        {
            Type type = typeof(ShoppingCart);
            piList.AddRange(type.GetProperties());
        }
               
        public List<ShoppingCart> ShoppingCartsSelect()
        {
            var table = new List<ShoppingCart>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0}", SHOPPING_CART_TABLE_NAME);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var item = new ShoppingCart();
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

        public ShoppingCart ShoppingCartSelect(int shoppingCartID)
        {
            ShoppingCart item = null;
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0} WHERE {1}={2}", 
                    SHOPPING_CART_TABLE_NAME, SHOPPING_CART_SHOPPING_CART_ID, shoppingCartID);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                item = new ShoppingCart();
                                FieldToProperty(item, dataReader);                                
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
            return item;
        }

        //public void ShoppingCartUpdate(ShoppingCart item)
        //{
        //    SqlConnection connection = OpenConnection();
        //    if (connection != null)
        //    {
        //        string cmdText = BuildUpdateQuery(item, typeof(ShoppingCart), SHOPPING_CART_SHOPPING_CART_ID, SHOPPING_CART_TABLE_NAME);
        //        using (var command = new SqlCommand(cmdText, connection))
        //        {                    
        //            try
        //            {
        //                command.ExecuteNonQuery();
        //            }
        //            catch (SqlException)
        //            {
        //                throw;
        //            }
        //        }
        //        CloseConnection(connection);
        //    }
        //}
        public void ShoppingCartUpdate(ShoppingCart item)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                var command = BuildUpdateCommand(connection, item, SHOPPING_CART_SHOPPING_CART_ID, SHOPPING_CART_TABLE_NAME);
                
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw;
                }
                finally
                {
                    command.Dispose();
                }
                CloseConnection(connection);
            }
        }





        public void ShoppingCartInsert(ShoppingCart item)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = BuildInsertQuery(item, typeof(ShoppingCart), SHOPPING_CART_SHOPPING_CART_ID, SHOPPING_CART_TABLE_NAME);
                using (var command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw;
                    }
                }
                CloseConnection(connection);
            }
        }

        //public void ShoppingCartInsert(ShoppingCart item)
        //{
        //    SqlConnection connection = OpenConnection();
        //    if (connection != null)
        //    {
        //        var command = BuildInsertCommand(connection, item, typeof(ShoppingCart), SHOPPING_CART_SHOPPING_CART_ID, SHOPPING_CART_TABLE_NAME);

        //        try
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        catch (SqlException ex)
        //        {
        //            throw;
        //        }
        //        finally
        //        {
        //            command.Dispose();
        //        }
        //        CloseConnection(connection);
        //    }
        //}

        public void ShoppingCartDelete(int shoppingCarID)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("DELETE FROM {0} WHERE {1}={2}",
                    SHOPPING_CART_TABLE_NAME, SHOPPING_CART_SHOPPING_CART_ID, shoppingCarID);
                using (var command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();                        
                    }
                    catch (SqlException)
                    {                        
                        throw;
                    }
                }
                CloseConnection(connection);
            }
        }
        
       
    }
}
