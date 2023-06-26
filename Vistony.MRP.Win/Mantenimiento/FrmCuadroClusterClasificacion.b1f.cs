using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.UI;
using Vistony.MRP.Constans;
using Vistony.MRP.BLL;
using SAPbouiCOM;
using Forxap.Framework.Extensions;

namespace Vistony.MRP.Win.Mantenimiento
{
    [FormAttribute("Vistony.MRP.Win.Mantenimiento.FrmCuadroClusterClasificacion", "Mantenimiento/FrmCuadroClusterClasificacion.b1f")]
    class FrmCuadroClusterClasificacion : UserFormBase
    {
        public FrmCuadroClusterClasificacion()
        {


        }
        MRP_BLL MrpBLL = new MRP_BLL();
        private SAPbouiCOM.Grid Grid0;
        SAPbouiCOM.Form oForm;
        private SAPbouiCOM.Button Button0;

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_0").Specific));
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
            this.Grid0.CollapsePressedBefore += new SAPbouiCOM._IGridEvents_CollapsePressedBeforeEventHandler(this.Grid0_CollapsePressedBefore);
            this.Grid0.CollapsePressedAfter += new SAPbouiCOM._IGridEvents_CollapsePressedAfterEventHandler(this.Grid0_CollapsePressedAfter);
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
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
            MrpBLL.ExecuteQueryDataTable(ref oDT, AddonMessageInfo.QueryGetConsultas_Categoria_Cluster);
            Grid0.AutoResizeColumns();
            Grid0.ReadOnlyColumns();
            Grid0.CollapseLevel = 1;
            Grid0.Rows.CollapseAll();
            Grid0.Columns.Item("Valor Inicial").RightJustified = true;
            Grid0.Columns.Item("Valor Final").RightJustified = true;
            oForm.ScreenCenter();
        }

        private void Button0_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            oForm.Close();
        }

        private void Grid0_CollapsePressedAfter(object sboObject, SBOItemEventArg pVal)
        {
        }

        private void Grid0_CollapsePressedBefore(object sboObject, SBOItemEventArg pVal,out bool BubbleEvent)
        {
            BubbleEvent = true;
            
        }

        private Button Button1;

        private void Button1_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            if (Button1.Caption=="Expandir")
            {
                Grid0.CollapseLevel = 1;
                Button1.Caption = "Comprimir";
            }
            else
            {
                Grid0.Rows.CollapseAll();
                Button1.Caption = "Expandir";
            }
        }

        private void Grid0_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }
    }
}
