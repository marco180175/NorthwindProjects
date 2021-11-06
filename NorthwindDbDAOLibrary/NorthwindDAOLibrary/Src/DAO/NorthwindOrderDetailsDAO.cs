using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAO.Src.DAO
{
    public class NorthwindOrderDetailsDAO : NorthwindDAO
    {
        public const string ORDER_DETAILS_TABLE_NAME = "[Order Details]";
        public const string ORDER_DETAILS_ORDER_ID = "OrderID";
        public const string ORDER_DETAILS_PRODUCT_ID = "ProductID";
        public const string ORDER_DETAILS_UNIT_PRICE = "UnitPrice";
        public const string ORDER_DETAILS_QUANTITY = "Quantity";
        public const string ORDER_DETAILS_DISCOUNT = "Discount";

        public NorthwindOrderDetailsDAO():base()
        {
            Type type = typeof(OrderDetail);
            piList.AddRange(type.GetProperties());
        }
        /*!
         *
         */
        public List<OrderDetail> OrderDetailsSelect()
        {
            var table = new List<OrderDetail>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0}", ORDER_DETAILS_TABLE_NAME);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var item = new OrderDetail();
                                FieldToProperty(item,  dataReader);
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
