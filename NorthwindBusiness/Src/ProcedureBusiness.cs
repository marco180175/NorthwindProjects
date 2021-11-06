using NorthwindDAO.Src.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{

    public class ProcedureParams
    {
        public ProcedureParams(string procedureName)
        {
            ProcedureName = procedureName;
            Parans = new List<KeyValuePair<string, object>>();
        }
        public string ProcedureName { get; }        
        public List<KeyValuePair<string, object>> Parans { get; set; }
        public override string ToString()
        {
            return ProcedureName;
        }
    }

    public class ProcedureBusiness
    {
        private StoredProcedure storedProcedure = new StoredProcedure();

        public DataTable Execute(ProcedureParams procedureParams)
        {
            return storedProcedure.Select(procedureParams.ProcedureName,
                                            procedureParams.Parans);
        }
    }
}
