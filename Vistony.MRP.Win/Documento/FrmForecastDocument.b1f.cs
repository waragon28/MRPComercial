using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Constants;

namespace Vistony.MRP.Win.Documento
{
    [FormAttribute("FrmForecastDocument", "Documento/FrmForecastDocument.b1f")]
    class FrmForecastDocument : UserFormBase
    {
        public FrmForecastDocument()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_0").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_6").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_8").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_9").Specific));
            this.Matrix0.ClickAfter += new SAPbouiCOM._IMatrixEvents_ClickAfterEventHandler(this.Matrix0_ClickAfter);
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_12").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_13").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_14").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_17").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.EditText EditText0;

        private void OnCustomInitialize()
        {
            Folder0.Select();
            Matrix0.AutoResizeColumns();
        }
        public static void MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.MenuUID =="1288" && pVal.BeforeAction == false)
            {
                


            }
        }

        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        int ultimaSeldSelec = 0;

        private void Matrix0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           
        }
    }
}
