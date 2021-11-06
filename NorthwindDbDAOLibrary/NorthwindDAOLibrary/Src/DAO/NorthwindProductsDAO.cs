using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAO.Src.DAO
{
    public class NorthwindProductsDAO : NorthwindDAO
    {
        private const string PRODUCTS_TABLE_NAME = "Products";

        

        public NorthwindProductsDAO()
            :base()
        {
            Type type = typeof(Product);
            piList.AddRange(type.GetProperties());
        }

        
        /*!
         * 
         */
        private List<Product> CustomProductsSelect(string cmdText, SqlConnection connection)
        {
            var table = new List<Product>();            
                
            using (SqlCommand command = new SqlCommand(cmdText, connection))
            {
                try
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var item = new Product();
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
            return table;
        }
        /*!
         * 
         */
        public List<Product> ProductsSelect()
        {
            var table = new List<Product>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0}", PRODUCTS_TABLE_NAME);
                table = CustomProductsSelect(cmdText, connection);
                                
                CloseConnection(connection);
            }
            return table;
        }
        /*!
         * 
         */
        public List<Product> ProductsSelect(string filter)
        {
            var table = new List<Product>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0} WHERE {1}", PRODUCTS_TABLE_NAME, filter);
                table = CustomProductsSelect(cmdText, connection);
                CloseConnection(connection);
            }
            return table;
        }
        /*!
         * 
         */
        public List<Product> ProductsSelect(int categoryID)
        {
            var table = new List<Product>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0} WHERE {1}={2}",
                    PRODUCTS_TABLE_NAME, //0
                    ProductProperties.CATEGORY_ID, //1
                    categoryID); //2
                table = CustomProductsSelect(cmdText, connection);
                CloseConnection(connection);
            }
            return table;
        }
        /*!
         * 
         */
        public Product ProductSelect(int productID)
        {
            Product item = null;
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0} WHERE {1}={2}", PRODUCTS_TABLE_NAME, ProductProperties.PRODUCT_ID, productID);
                var table = CustomProductsSelect(cmdText, connection);
                if(table.Count > 0)
                    item = table[0];
                CloseConnection(connection);
            }
            return item;
        }

        /*!
         * 
         */
        //public void ProductInsert(Product product)
        //{
        //    SqlConnection connection = OpenConnection();
        //    if (connection != null)
        //    {
        //        string cmdText = BuildInsertQuery(product, typeof(Product), PRODUCTS_PRODUCT_ID, PRODUCTS_TABLE_NAME);

        //        using (var command = new SqlCommand(cmdText, connection))
        //        {
        //            try
        //            {
        //                command.ExecuteNonQuery();
        //            }
        //            catch (SqlException ex)
        //            {
        //                throw ex;
        //            }
        //        }
        //        CloseConnection(connection);
        //    }
        //}

        public void ProductInsert(Product product)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                using (var command = BuildInsertCommand(connection, product, ProductProperties.PRODUCT_ID, PRODUCTS_TABLE_NAME))
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

        public void ProductUpdate(Product product)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {

                using (var command = BuildUpdateCommand(connection, product, ProductProperties.PRODUCT_ID, PRODUCTS_TABLE_NAME))
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

        public void ProductDelete(int productID)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("DELETE FROM {0} WHERE {1}={2}",
                    PRODUCTS_TABLE_NAME, ProductProperties.PRODUCT_ID, productID);
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
