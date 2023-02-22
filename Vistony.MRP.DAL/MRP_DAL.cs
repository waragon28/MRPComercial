using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.MRP.DAL
{
    public class MRP_DAL
    {
        public SAPbouiCOM.DataTable ExecuteQueryDataTable(ref SAPbouiCOM.DataTable oDT, string Query)
        {
            try
            {
                string sSTRSQL =  Query;
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void ExecuteQueryRecorsed(Recordset recordset, string Query)
        {
            try
            {

            string StrHANA = Query;
            recordset.DoQuery(StrHANA);
            }
            catch (Exception ex)
            {
                
            }
        }

    }
}
