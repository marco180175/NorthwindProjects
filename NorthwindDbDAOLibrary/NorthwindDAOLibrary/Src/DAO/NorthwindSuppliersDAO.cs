using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAO.Src.DAO
{
    public class NorthwindSuppliersDAO : NorthwindDAO
    {
        public const string SUPPLIERS_TABLE_NAME = "Suppliers";
        public const string SUPPLIERS_SUPPLIER_ID = "SupplierID";
        public const string SUPPLIERS_COMPANY_NAME = "CompanyName";
        public const string SUPPLIERS_CONTACT_NAME = "ContactName";
        public const string SUPPLIERS_CONTACT_TITLE = "ContactTitle";
        public const string SUPPLIERS_ADDRESS = "Address";
        public const string SUPPLIERS_CITY = "City";
        public const string SUPPLIERS_REGION = "Region";
        public const string SUPPLIERS_POSTAL_CODE = "PostalCode";
        public const string SUPPLIERS_COUNTRY = "Country";
        public const string SUPPLIERS_PHONE = "Phone";
        public const string SUPPLIERS_FAX = "Fax";
        public const string SUPPLIERS_HOME_PAGE = "HomePage";
        /*!
         * 
         */
        public NorthwindSuppliersDAO()
            :base()
        {
            Type type = typeof(Supplier);
            piList.AddRange(type.GetProperties());
        }
        /*!
         * 
         */
        public List<Supplier> SuppliersSelect()
        {
            var table = new List<Supplier>();
            SqlConnection connection = OpenConnection();
            if (connection != null)
            {
                string cmdText = string.Format("SELECT * FROM {0}", SUPPLIERS_TABLE_NAME);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    try
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var item = new Supplier();
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
    }
}
