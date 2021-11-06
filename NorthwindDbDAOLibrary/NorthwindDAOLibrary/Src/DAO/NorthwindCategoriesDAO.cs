using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAO.Src.DAO
{
    public class NorthwindCategoriesDAO : NorthwindDAO
    {
        public const string CATEGORIES_TABLE_NAME = "Categories";
        
        /*!
         * Construtor 
         */
        public NorthwindCategoriesDAO()
            :base()
        {
            Type type = typeof(Category);
            piList.AddRange(type.GetProperties());
        }
        /*!
         * 
         */
        public List<Category> CategoriesSelect()
        {
            var table = new List<Category>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0}", CATEGORIES_TABLE_NAME);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var item = new Category();
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
        /*!
         * 
         */
        public Category CategoriesSelect(int categoryID)
        {
            Category category = null;
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0} WHERE {1}={2}",
                    CATEGORIES_TABLE_NAME,
                    CategoryProperties.CATEGORY_ID,
                    categoryID);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                category = new Category();
                                FieldToProperty(category, dataReader);                                
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
            return category;
        }
        /*!
         * 
         */
        public void CategoriesInsert(Category category)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = BuildInsertQuery(category, typeof(Category), CategoryProperties.CATEGORY_ID, CATEGORIES_TABLE_NAME);
                                
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

        public void CategoriesUpdate(Category category)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = BuildUpdateQuery(category, typeof(Category), CategoryProperties.CATEGORY_ID, CATEGORIES_TABLE_NAME);

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

        public void CategoriesDelete(int categoryID)
        {
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("DELETE FROM {0} WHERE {1}={2}",
                    CATEGORIES_TABLE_NAME, CategoryProperties.CATEGORY_ID, categoryID);
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
