using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAO.Src.DAO
{
    public class NorthwindCustomersDAO : NorthwindDAO
    {
        public const string CUSTUMERS_TABLE_NAME = "Customers";
        public const string CUSTUMERS_CUSTUMER_ID = "CustomerID";
        public const string CUSTUMERS_COMPANY_NAME = "CompanyName";
        public const string CUSTUMERS_CONTACT_NAME = "ContactName";
        public const string CUSTUMERS_CONTACT_TITLE = "ContactTitle";
        public const string CUSTUMERS_ADDRESS = "Address";
        public const string CUSTUMERS_CITY = "City";
        public const string CUSTUMERS_REGION = "Region";
        public const string CUSTUMERS_POSTAL_CODE = "PostalCode";
        public const string CUSTUMERS_COUNTRY = "Country";
        public const string CUSTUMERS_PHONE = "Phone";
        public const string CUSTUMERS_FAX = "Fax";
        /*!
         *
         */
        public NorthwindCustomersDAO() 
            :base()
        {   
            Type type = typeof(Customer);
            piList.AddRange(type.GetProperties());
        }
        /*!
         * Retorna toda tabela
         */
        public List<Customer> Select()
        {
            var table = new List<Customer>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0}", CUSTUMERS_TABLE_NAME);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var item = new Customer();
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
        /*!
         * Retorna toda tabela por pais
         */
        public List<Customer> SelectByCountry(string country)
        {
            var table = new List<Customer>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0} WHERE {1}='{2}'",
                    CUSTUMERS_TABLE_NAME, CUSTUMERS_COUNTRY, country);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var item = new Customer();
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
        /*!
         * Retorna toda tabela por pais
         */
        public List<Customer> SelectByCity(string city)
        {
            var table = new List<Customer>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0} WHERE {1}='{2}'",
                    CUSTUMERS_TABLE_NAME, CUSTUMERS_CITY, city);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var item = new Customer();
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
        /*!
         * Retorna lista de paises
         */
        public List<string> SelectCountry()
        {
            var table = new List<string>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT DISTINCT {0} FROM {1}", CUSTUMERS_COUNTRY, CUSTUMERS_TABLE_NAME);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                table.Add(dataReader[CUSTUMERS_COUNTRY].ToString());
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
        /*!
         * Retorna lista de cidades
         */
        public List<string> SelectCity()
        {
            var table = new List<string>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT DISTINCT {0} FROM {1}", CUSTUMERS_CITY, CUSTUMERS_TABLE_NAME);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                table.Add(dataReader[CUSTUMERS_CITY].ToString());
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
