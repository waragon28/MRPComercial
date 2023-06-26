using SAPbobsCOM;
using SAPbouiCOM;
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

        public void addItem(string CardCode,Form oForm, string Query)
        {
            MRP_DAL1.addItem(CardCode, oForm,Query);
        }
        public void FindText(SAPbouiCOM.SBOItemEventArg pVal, int filaseleccionada, EditText EditText7, Grid Grid1, string NombCol)
        {
            try
            {
              MRP_DAL1.FindText(pVal, filaseleccionada, EditText7, Grid1,NombCol);
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        public void GetClusterSucursales(Form oForm, Recordset recordSet, Grid Grid0, ComboBox ComboBox0, string Sucursal,
                                        string QueryGetPlanning, string QueryGetPlanningSelect, string QueryGetPlanningClear)
        {
            try
            {
                MRP_DAL1.GetClusterSucursales(oForm,recordSet,Grid0,ComboBox0,Sucursal,QueryGetPlanning,QueryGetPlanningSelect,QueryGetPlanningClear);
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        public void GetClusterSucursalesBO(Form oForm,DataTable oDT, Grid Grid0, ComboBox ComboBox0, string QueryGetPlanning)
        {
            try
            {
                MRP_DAL1.GetClusterSucursalesBO(oForm, oDT, Grid0, ComboBox0, QueryGetPlanning);
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        public void GetClusterLima(Form oForm, string Query, Grid Grid1)
        {
            try
            {
                MRP_DAL1.GetClusterLima(oForm, Query, Grid1);
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        public void ExecuteQueryRecorsed(Recordset recordset, string Query)
        {
            try
            {
                MRP_DAL1.ExecuteQueryRecorsed(recordset, Query);
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        public void Procesar(SAPbouiCOM.Grid Grid, int CodUser, string NombreUsuario, string PuntoEmision, string FechaDocumento, string TipoGerencia,string Periodo)
        {
            try
            {
                MRP_DAL1.Procesar(Grid, CodUser, NombreUsuario, PuntoEmision, FechaDocumento, TipoGerencia, Periodo);
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        public void ProcesarV2(SAPbouiCOM.Matrix oMatrix, int CodUser, string NombreUsuario, string PuntoEmision, string FechaDocumento, string TipoGerencia, string Periodo,Button Button4)
        {
            try
            {
                MRP_DAL1.ProcesarV2(oMatrix, CodUser, NombreUsuario, PuntoEmision, FechaDocumento, TipoGerencia, Periodo, Button4);
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        public void GenerarDraftST(Matrix oMatrix, string DocDate, string DueDate, string JournalMemot, string FromWarehouse, string ToWarehouse,
        string DocObjectCode, string TaxDate, string U_SYP_MDMT, string U_SYP_SOLICITANTE)
        {
            try
            {
                MRP_DAL1.GenerarDraftST(oMatrix,DocDate,DueDate,JournalMemot,FromWarehouse,ToWarehouse,
                DocObjectCode,TaxDate,U_SYP_MDMT,U_SYP_SOLICITANTE);
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        public void GenerarPedido(Matrix oMatrix, int SalesPersonCode, int DocumentsOwner, string NombreSolicitante)
        {
            try
            {
                MRP_DAL1.GenerarPedido(oMatrix, SalesPersonCode, DocumentsOwner, NombreSolicitante);
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
    }
}
