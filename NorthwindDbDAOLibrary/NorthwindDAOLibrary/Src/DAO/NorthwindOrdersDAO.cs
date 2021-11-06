using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAO.Src.DAO
{
    public class NorthwindOrdersDAO : NorthwindDAO
    {
        public const string ORDERS_TABLE_NAME = "Orders";
        public const string ORDERS_ORDER_ID = "OrderID";//PRIMARY KEY
        public const string ORDERS_COSTUMER_ID = "CustomerID";        
        public const string ORDERS_EMPLOYEE_ID = "EmployeeID";
        public const string ORDERS_ORDER_DATE = "OrderDate";
        public const string ORDERS_REQUIRED_DATE = "RequiredDate";
        public const string ORDERS_SHIPPED_DATE = "ShippedDate";
        public const string ORDERS_SHIP_VIA = "ShipVia";
        public const string ORDERS_FREIGHT = "Freight";
        public const string ORDERS_SHIP_NAME = "ShipName";
        public const string ORDERS_SHIP_ADDRESS = "ShipAddress";
        public const string ORDERS_SHIP_CITY = "ShipCity";
        public const string ORDERS_SHIP_REGION = "ShipRegion";
        public const string ORDERS_SHIP_POSTAL_CODE = "ShipPostalCode";
        public const string ORDERS_SHIP_COUNTRY = "ShipCountry";
        
        /*!
         *
         */
        public NorthwindOrdersDAO()
            :base()
        {   
            Type type = typeof(Order);
            piList.AddRange(type.GetProperties());
        }
        /*!
         *
         */
        public List<Order> OrdersSelect()
        {
            var table = new List<Order>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0}", ORDERS_TABLE_NAME);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var item = new Order();
                                FieldToProperty(item, dataReader);                                
                                table.Add(item);
                            }
                            dataReader.Close();
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
                CloseConnection(connection);
            }
            return table;
        }

        public Order OrdersSelect(int orderID)
        {
            var item = new Order();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0} WHERE {1}={2}",
                    ORDERS_TABLE_NAME, OrderProperties.ORDER_ID, orderID);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                
                                FieldToProperty(item, dataReader);
                                
                            }
                            dataReader.Close();
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
                CloseConnection(connection);
            }
            return item;
        }

        public void OrderInsert(Order order)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {                
                using (var command = BuildInsertCommand(connection, order, ORDERS_ORDER_ID, ORDERS_TABLE_NAME))
                {                                  
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
                CloseConnection(connection);
            }
        }

        public void OrderUpdate(Order order)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                using (var command = BuildUpdateCommand(connection, order, ORDERS_ORDER_ID, ORDERS_TABLE_NAME))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
                CloseConnection(connection);
            }
        }

        public void OrderUpdate(Order order,string propertyName)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                using (var command = BuildUpdatePropertyCommand(connection, order, propertyName, ORDERS_ORDER_ID, ORDERS_TABLE_NAME))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
                CloseConnection(connection);
            }
        }

        public void OrderDelete(int orderID)
        { }

    }
}
