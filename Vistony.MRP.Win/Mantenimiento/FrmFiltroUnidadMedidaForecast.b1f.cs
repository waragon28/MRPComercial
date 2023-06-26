using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Vistony.MRP.Win.FormPlanificación;
using Vistony.MRP.BLL;
using Forxap.Framework.Extensions;
using Vistony.MRP.Constans;
using System.Threading;

namespace Vistony.MRP.Win.Mantenimiento
{
    [FormAttribute("Vistony.MRP.Win.Mantenimiento.FrmFiltroUnidadMedidaForecast", "Mantenimiento/FrmFiltroUnidadMedidaForecast.b1f")]
    class FrmFiltroUnidadMedidaForecast : UserFormBase
    {
        int BuscarGerenciaList(string palabra, string[] arreglo)
        {
            int indice = Array.IndexOf(arreglo, palabra);
            return indice;
        }

        public FrmFiltroUnidadMedidaForecast(FrmForecast ownerForm, string FiltroUnidadMedida)
        {
            OwnerForm = ownerForm;
            FiltroGerenciaSelect = FiltroUnidadMedida;


            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
            MrpBLL.ExecuteQueryDataTable(ref oDT, AddonMessageInfo.QueryGetConsultas_List_UnidadMedida_Forecast);
            if (FiltroGerenciaSelect != "")
            {
                char delimitador = ',';
                string[] valores = FiltroGerenciaSelect.Split(delimitador);

                for (int RowSelec = 0; RowSelec < oDT.Rows.Count; RowSelec++)
                {

                    int indicePalabraC = BuscarGerenciaList(oDT.GetString("Código", RowSelec), valores);

                    if (indicePalabraC != -1)
                    {
                        oDT.SetValue(0, RowSelec, "Y");
                    }
                }
            }
            Grid0.AutoResizeColumns();
            Grid0.ReadOnlyColumns();
            Grid0.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            Grid0.Columns.Item(0).TitleObject.Caption = "Marcar";
            Grid0.Columns.Item(0).Editable = true;


        }
        FrmForecast OwnerForm;
        MRP_BLL MrpBLL = new MRP_BLL();
        SAPbouiCOM.Form oForm;
        string FiltroGerenciaSelect = string.Empty;


        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_0").Specific));
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_1").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.Grid Grid0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            string FiltroUnidadMedida = string.Empty;
            int CantidadSeleccionado = 0;
            for (int i = 0; i < Grid0.Rows.Count; i++)
            {
                if (Grid0.DataTable.GetValue(0, i).ToString() == "Y")
                {
                    FiltroUnidadMedida += "" + Grid0.DataTable.GetValue("Código", i).ToString() + ",";
                    CantidadSeleccionado++;
                }
            }

            FrmForecast owner = this.OwnerForm;
            Thread myNewThread = new Thread(() => owner.ObtenerFiltroUnidadMedida(FiltroUnidadMedida, "Unidad de Medida ( " + CantidadSeleccionado + " )"));
            myNewThread.Start();
            oForm.Close();
        }

        private void Grid0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            // si hicieron clic en la columna para marcar o desmarcar
            if (pVal.ColUID == "Marcar" && pVal.Row == -1)
            {

                // debo marcar o desmarcar todo
                Utils.CheckRowsCheck_NotCheck(oForm, Grid0);


            }
        }
    }
}
