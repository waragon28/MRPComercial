using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Vistony.MRP.BLL;
using Forxap.Framework.Extensions;
using Vistony.MRP.Constans;
using Vistony.MRP.Win.FormPlanificación;
using System.Threading;

namespace Vistony.MRP.Win.Mantenimiento
{
    [FormAttribute("FrmFiltroGerForecast", "Mantenimiento/FrmFiltroGerenciaForecast.b1f")]
    class FrmFiltroGerenciaForecast : UserFormBase
    {
        int BuscarGerenciaList(string palabra, string[] arreglo)
        {
            int indice = Array.IndexOf(arreglo, palabra);
            return indice;
        }

        public FrmFiltroGerenciaForecast(FrmForecast ownerForm,string FiltroGerencia)
        {
            OwnerForm = ownerForm;
            FiltroGerenciaSelect = FiltroGerencia;


            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
            MrpBLL.ExecuteQueryDataTable(ref oDT, AddonMessageInfo.QueryGetConsultas_List_Gerencia_Forecast);
            if (FiltroGerenciaSelect != "")
            {
                char delimitador = ',';
                string[] valores = FiltroGerenciaSelect.Split(delimitador);

                for (int RowSelec = 0; RowSelec < oDT.Rows.Count; RowSelec++)
                {

                    int indicePalabraC = BuscarGerenciaList(oDT.GetString("Gerencia", RowSelec), valores);

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
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Grid Grid0;

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_0").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_1").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }


        private void OnCustomInitialize()
        {
            
        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.Close();
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            string FiltroGerencia = string.Empty;
            int CantidadSeleccionado=0;
            for (int i = 0; i < Grid0.Rows.Count; i++)
            {
                if (Grid0.DataTable.GetValue(0, i).ToString() == "Y")
                {
                    FiltroGerencia += "" + Grid0.DataTable.GetValue("Gerencia", i).ToString() + ",";
                    CantidadSeleccionado++;
                }
            }

            FrmForecast owner = this.OwnerForm;
            Thread myNewThread = new Thread(() => owner.ObtenerFiltroGerencia(FiltroGerencia,"Gerencia ( "+ CantidadSeleccionado + " )"));
            myNewThread.Start();
            oForm.Close();
        }
    }
}
