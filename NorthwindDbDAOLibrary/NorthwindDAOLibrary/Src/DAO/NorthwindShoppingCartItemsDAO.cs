using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace NorthwindDAO.Src.DAO
{
    public class NorthwindShoppingCartItemsDAO : NorthwindDAO
    {
        public const string SHOPPING_CART_ITEM_TABLE_NAME = "ShoppingCartItems";
        public const string SHOPPING_CART_ITEM_SHOPPING_CART_ITEM_ID = "ShoppingCartItemID";
        public const string SHOPPING_CART_ITEM_SHOPPING_CART_ID = "ShoppingCartID";
        public const string SHOPPING_CART_ITEM_PRODUCT_ID = "ProductID";
        public const string SHOPPING_CART_ITEM_QUANTITY = "Quantity";
        public const string SHOPPING_CART_ITEM_UNIT_PRICE = "UnitPrice";

        public NorthwindShoppingCartItemsDAO()
            :base()
        {   
            Type type = typeof(ShoppingCartItem);
            piList.AddRange(type.GetProperties());            
        }

        public List<ShoppingCartItem> ShoppingCartItemsSelect(int shoppingCartID)
        {
            var table = new List<ShoppingCartItem>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText;
                if (shoppingCartID == -1)
                {
                    cmdText = string.Format("SELECT * FROM {0}",
                        SHOPPING_CART_ITEM_TABLE_NAME);
                }
                else
                {
                    cmdText = string.Format("SELECT * FROM {0} WHERE {1}={2}",
                        SHOPPING_CART_ITEM_TABLE_NAME, SHOPPING_CART_ITEM_SHOPPING_CART_ID, shoppingCartID);
                }
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var item = new ShoppingCartItem();
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

        public ShoppingCartItem ShoppingCartItemSelect(int shoppingCartItemID)
        {
            ShoppingCartItem item = null;
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0} WHERE {1}={2}",
                        SHOPPING_CART_ITEM_TABLE_NAME, SHOPPING_CART_ITEM_SHOPPING_CART_ITEM_ID, shoppingCartItemID);
                
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                item = new ShoppingCartItem();
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
        
        public void ShoppingCartItemUpdate(ShoppingCartItem item)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = BuildUpdateQuery(item, typeof(ShoppingCartItem), SHOPPING_CART_ITEM_SHOPPING_CART_ITEM_ID, SHOPPING_CART_ITEM_TABLE_NAME);

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
        
        public void ShoppingCartItemInsert(ShoppingCartItem item)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = BuildInsertQuery(item, typeof(ShoppingCartItem), SHOPPING_CART_ITEM_SHOPPING_CART_ITEM_ID, SHOPPING_CART_ITEM_TABLE_NAME);
                //                
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

        public void ShoppingCartItemDelete(int shoppingCartItemID)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("DELETE FROM {0} WHERE {1}={2}",
                    SHOPPING_CART_ITEM_TABLE_NAME, SHOPPING_CART_ITEM_SHOPPING_CART_ITEM_ID, shoppingCartItemID);
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

        public void ShoppingCartItemsDelete(int shoppingCartID)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("DELETE FROM {0} WHERE {1}={2}",
                    SHOPPING_CART_ITEM_TABLE_NAME, SHOPPING_CART_ITEM_SHOPPING_CART_ID, shoppingCartID);
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
        /*!
         * Retorna numero de shoppingCartID 
         */
        public int ShoppingCartItemCount(int shoppingCartID)
        {
            int count = 0;
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT COUNT(*) FROM {0} WHERE {1}={2}",
                        SHOPPING_CART_ITEM_TABLE_NAME, SHOPPING_CART_ITEM_SHOPPING_CART_ID, shoppingCartID);

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        count = (int)command.ExecuteScalar();                        
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                }
                CloseConnection(connection);
            }
            return count;
        }

    }
}
