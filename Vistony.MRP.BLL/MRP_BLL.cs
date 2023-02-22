using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistony.MRP.DAL;

namespace Vistony.MRP.BLL
{
    public class MRP_BLL
    {
        MRP_DAL MRP_DAL1 = new MRP_DAL();
        public SAPbouiCOM.DataTable ExecuteQueryDataTable(ref SAPbouiCOM.DataTable oDT, string Query)
        {
            try
            {
                return MRP_DAL1.ExecuteQueryDataTable(ref oDT, Query);
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
                MRP_DAL1.ExecuteQueryRecorsed(recordset, Query);
            }
            catch (Exception)
            {

               // throw;
            }
        }

    }
}
