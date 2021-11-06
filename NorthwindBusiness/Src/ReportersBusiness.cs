using NorthwindDAO.Src.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{
    public class ReportersBusiness
    {
        private NorthwindReporters reporters = new NorthwindReporters();
        private List<int> years;
        private string path;
        private const string IDX_COLUMNS1= "Year";
        private const string IDX_COLUMNS2 = "Count";
        public ReportersBusiness(string path)
        {
            this.path = path;
            years = new List<int>();
            years.Add(1996);
            years.Add(1997);
            years.Add(1998);
        }

        public void Select()
        {            
            var table = new DataTable();
            var index = new DataTable();
            index.Columns.Add(IDX_COLUMNS1);
            index.Columns.Add(IDX_COLUMNS2);
            foreach (int year in years)
            {
                table = reporters.Select(year);
                ConvertToCSV(table,path+"\\"+string.Format("tabela-{0}.csv",year));
                DataRow row = index.NewRow();
                row[IDX_COLUMNS1] = year;
                row[IDX_COLUMNS2] = table.Rows.Count;
                index.Rows.Add(row);
            }
            ConvertToCSV(index, path + "\\" + string.Format("tabela-{0}.csv", "index"));
        }

        private void ConvertToCSV(DataTable table,string fileName)
        {
            var file = new StreamWriter(fileName, true);
            string line = "";
            foreach (DataColumn col in table.Columns)
                line += col.ColumnName + ";";
            file.WriteLine(line);
            foreach(DataRow row in table.Rows)
            {
                line = "";
                for (int i = 0; i < row.ItemArray.Length; i++)                
                    line += row.ItemArray[i] + ";";
                file.WriteLine(line);
            }
            file.Close();
            file.Dispose();           
        }
    }
}
