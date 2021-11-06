using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace NorthwindDAO.Src.DAO
{
    public class DAOExceptionEventArgs:EventArgs
    { }

    public delegate void DAOExceptionEventHandler(object sender, DAOExceptionEventArgs e);

    public abstract class NorthwindDAO
    {
        protected NumberFormatInfo nfi;//Inforamção do formato numerio
        public const string SQL_DATE_FORMAT = "yyyyMMdd";//Formato DateTime SQL
        protected string connectionString;//string de conexão        
        protected List<PropertyInfo> piList;
        /*!
         * Construtor
         */
        public NorthwindDAO()
        {            
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NorthwindDbConnectionString"].ConnectionString;
            nfi = new CultureInfo(CultureInfo.CurrentCulture.Name).NumberFormat;
            nfi.NumberDecimalSeparator = ".";            
            piList = new List<PropertyInfo>();
        }
        /*!
         * Inicializa e abre conexão com banco de dados
         */
        protected SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (SqlException ex)
            {
                throw ex;                
            }
            catch (InvalidOperationException ex)
            {
                throw ex;                
            }
        }
        /*!
         * Fecha conexão
         */
        protected void CloseConnection(SqlConnection connection)
        {
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }
        }
        /*!
         * Copia campos do banco para propriedades.
         */
        protected void FieldToProperty(object item, SqlDataReader reader)           
        {
            foreach (var piItem in piList)
            {
                try
                {
                    if (!Convert.IsDBNull(reader[piItem.Name]))
                        piItem.SetValue(item, reader[piItem.Name], null);
                }
                catch
                {
                    piItem.SetValue(item, null, null);
                }
            }
        }
        /*!
         * Converte tipo dado para string
         *
        protected string GetSQLString(object item, PropertyInfo pi)
        {
            object value = pi.GetValue(item);
            if (value == null)
            {
                return "null";
            }
            else
            {
                //
                if (pi.PropertyType == typeof(DateTime)||pi.PropertyType == typeof(DateTime?))
                    return "'" + ((DateTime)value).ToString(SQL_DATE_FORMAT) + "'";                
                //
                if (pi.PropertyType == typeof(decimal)|| pi.PropertyType == typeof(decimal?))
                    return ((decimal)pi.GetValue(item)).ToString(nfi);
                //
                if (pi.PropertyType == typeof(double)||pi.PropertyType == typeof(double?))
                    return ((double)pi.GetValue(item)).ToString(nfi);                 
                //
                if (pi.PropertyType == typeof(Byte) || pi.PropertyType == typeof(Byte?))
                    return ((Byte)pi.GetValue(item)).ToString();
                //
                if (pi.PropertyType == typeof(Int16) || pi.PropertyType == typeof(Int16?))
                    return ((Int16)pi.GetValue(item)).ToString();
                //
                if (pi.PropertyType == typeof(Int32) || pi.PropertyType == typeof(Int32?))
                    return ((Int32)pi.GetValue(item)).ToString();
                //
                if (pi.PropertyType == typeof(Int64) || pi.PropertyType == typeof(Int64?))
                    return ((Int64)pi.GetValue(item)).ToString();
                //
                if (pi.PropertyType == typeof(bool))
                {
                    if ((bool)pi.GetValue(item))
                        return "1";
                    else
                        return "0";
                }
                //
                if (pi.PropertyType == typeof(bool?))
                {
                    //if ((bool)pi.GetValue(item))
                    if ((bool)value == true)
                        return "1";
                    else
                        return "0";
                }
                //
                else if (pi.PropertyType == typeof(string))
                {
                    if (string.IsNullOrEmpty((string)value))
                        return "null";
                    else
                        return "'" + ((string)value).Replace("'", " ") + "'";
                }

                return "null";
            }
        }
        /*!
         * Monta string com texto de comando sql
         */
        protected string BuildInsertQuery(object item, Type itemType, string filterColunm, string tableName)
        {
            string columns = string.Format("INSERT INTO {0} (", tableName);
            string values = "VALUES(";
            foreach (var piItem in piList)
            {
                if (piItem.Name != filterColunm)
                {
                    columns += piItem.Name + ",";                    
                    values += GetSQLString(item, piItem) + ",";
                }
            }
            columns = columns.Remove(columns.Length - 1);
            columns += ")";
            values = values.Remove(values.Length - 1);
            values += ")";
            return columns + values;
        }
        /*!
         * Monta string com texto de comando sql
         */
        protected string BuildUpdateQuery(object item, Type itemType, string filterColunm, string tableName)
        {            
            string update = string.Format("UPDATE {0} ", tableName);
            string values = "SET ";
            foreach (var piItem in piList)
            {
                if (piItem.Name != filterColunm)
                {                    
                    values += piItem.Name + "=" + GetSQLString(item, piItem) + ",";
                }
            }
            values = values.Remove(values.Length - 1);

            //procura nome do identificador            
            var result = piList.Find(
                delegate (PropertyInfo pi)
                {
                    return pi.Name == filterColunm;
                }
            );            
            string condition = string.Format(" WHERE {0}={1}", result.Name, result.GetValue(item));

            return update + values + condition;
        }
        /*!
         * Monta command para insert com parametros
         */
        protected SqlCommand BuildInsertCommand(SqlConnection connection, object item, string filterColunm, string tableName)
        {
            var command = new SqlCommand("", connection);
            string columns = string.Format("INSERT INTO {0} (", tableName);
            string values = "VALUES(";
            foreach (var piItem in piList)
            {
                if (piItem.Name != filterColunm)
                {
                    //sqtText
                    columns += piItem.Name + ",";
                    values += "@" + piItem.Name + ",";
                    //parameters                    
                    object value = piItem.GetValue(item);
                    if (value == null)
                        command.Parameters.AddWithValue("@" + piItem.Name, DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@" + piItem.Name, value);
                }
            }
            columns = columns.Remove(columns.Length - 1);
            columns += ")";
            values = values.Remove(values.Length - 1);
            values += ")";
            
            command.CommandText = columns + values;
            return command;
        }
        /*!
         * Monta command para update com parametros
         */
        protected SqlCommand BuildUpdateCommand(SqlConnection connection, object item, string filterColunm, string tableName)
        {
            StringBuilder query = new StringBuilder();

            var command = new SqlCommand("", connection);
            
            query.AppendFormat("UPDATE {0} SET\n", tableName);
            
            foreach (var piItem in piList)
            {                
                if (piItem.Name != filterColunm)
                {
                    //texto
                    if (piItem == piList[piList.Count - 1])                    
                        query.AppendFormat("{0}=@{0}\n", piItem.Name);                    
                    else                       
                        query.AppendFormat("{0}=@{0},", piItem.Name);                    
                    //parametros
                    object value = piItem.GetValue(item);
                    if (value == null)
                        command.Parameters.AddWithValue("@" + piItem.Name, DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@" + piItem.Name, value);
                }
            }
                 
            
            //procura nome do identificador            
            var result = piList.Find(
                delegate (PropertyInfo pi)
                {
                    return pi.Name == filterColunm;
                }
            );            
            query.AppendFormat(" WHERE {0}=@{0}", result.Name);
            command.Parameters.AddWithValue("@" + result.Name, result.GetValue(item));
            command.CommandText = query.ToString();
            return command;
        }

        protected SqlCommand BuildUpdatePropertyCommand(SqlConnection connection, object item, string propertyName, string filterColunm, string tableName)
        {
            StringBuilder query = new StringBuilder();

            var command = new SqlCommand("", connection);

            query.AppendFormat("UPDATE {0} SET\n", tableName);            
            //procura nome do identificador            
            var piItem = piList.Find(
                delegate (PropertyInfo pi)
                {
                    return pi.Name == propertyName;
                }
            );
            //texto
            query.AppendFormat("{0} = @{1}\n",piItem.Name, piItem.Name);
            //parametros
            object value = piItem.GetValue(item);
            if (value == null)
                command.Parameters.AddWithValue("@" + piItem.Name, DBNull.Value);
            else
                command.Parameters.AddWithValue("@" + piItem.Name, value);
            //procura nome do identificador            
            var result = piList.Find(
                delegate (PropertyInfo pi)
                {
                    return pi.Name == filterColunm;
                }
            );
            query.AppendFormat(" WHERE {0}=@{1}", result.Name, result.Name);
            command.Parameters.AddWithValue("@" + result.Name, result.GetValue(item));
            command.CommandText = query.ToString();
            return command;
        }

    }
}
