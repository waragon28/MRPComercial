#define AD_BO
//#define AD_PE
//#define AD_PY
//#define AD_EC
//#define AD_CL

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Vistony.MRP.Constans;
using Vistony.MRP.BLL;
using SAPbobsCOM;
using Forxap.Framework.UI;
using Vistony.MRP.Win.Mantenimiento;
using SAPbouiCOM;
using System.Threading;

namespace Vistony.MRP.Win.FormPlanificación
{
    [FormAttribute(AddonMenuItem.AddonMainMenuCluster, "FormPlanificación/FrmCluster.b1f")]
    class FrmCluster : UserFormBase
    {
        public SAPbouiCOM.Form oForm;
        MRP_BLL objMrp_Bll = new MRP_BLL();
        Recordset recordSet = null;

        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.Folder Folder0;
        public string Sucursal = string.Empty;
        public int filaseleccionada = -1;

        // Declarar una variable para controlar si frm_ventana_2 está abierta
        bool ventana2Abierta = false;

        public FrmCluster()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_1").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button0.ChooseFromListBefore += new SAPbouiCOM._IButtonEvents_ChooseFromListBeforeEventHandler(this.Button0_ChooseFromListBefore);
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.EditText0.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.EditText0_LostFocusAfter);
            this.EditText0.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText0_KeyDownAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_5").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_6").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_10").Specific));
            this.ComboBox1.ClickAfter += new SAPbouiCOM._IComboBoxEvents_ClickAfterEventHandler(this.ComboBox1_ClickAfter);
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_17").Specific));
            this.Folder0.ClickAfter += new SAPbouiCOM._IFolderEvents_ClickAfterEventHandler(this.Folder0_ClickAfter);
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.StaticText5.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText5_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.ResizeAfter += new ResizeAfterHandler(this.Form_ResizeAfter);

        }
        
        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            Utils.LoadQueryDynamic(ref ComboBox1, AddonMessageInfo.QueryGetListSucu_Ind);
            StaticText2.SetBold();
            StaticText5.SetColor(System.Drawing.Color.Blue);
            oForm.ScreenCenter();            
            Grid0.AutoResizeColumns();
            ComboBox1.Select(1, SAPbouiCOM.BoSearchKey.psk_Index);
            Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryGetSucursales);
        }
        
        private void ComboBox1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            ComboBox0.RemoveValidValues();
#if AD_PE
            if (ComboBox1.GetValue() == "1")
            {
                StaticText0.Caption = "Consulta";
                Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryGetConsultas);
            }
            else if (ComboBox1.GetValue() == "2")
            {
                StaticText0.Caption = "Sucursales";
                Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryGetSucursales);
            }
            else if (ComboBox1.GetValue() == "3")
            {
                StaticText0.Caption = "Induvis";
                //Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo);
            }
#elif AD_BO
          
            if (ComboBox1.GetValue() == "1")
            {
                StaticText0.Caption = "Punto Emisión";
                Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryGetSucursales);
                ComboBox0.Select(1, BoSearchKey.psk_Index);
            }
#endif
        }

        private void Button0_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal,out bool BubbleEvent)
        {
            BubbleEvent = true;
        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (ComboBox0.GetValue()!=string.Empty && ComboBox1.GetValue()!= string.Empty)
            {
                BubbleEvent = true;
            }
            else
            {
                BubbleEvent = false;
                Sb1Messages.ShowError("Debe seleccionar los datos");
            }
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            recordSet = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
#if AD_PE
              if (ComboBox1.GetValue()=="1") // LIMA
            {
                string Query = string.Empty;
                if (ComboBox0.GetSelectedDescription() == "ANCON B2B")
                {
                    Query = AddonMessageInfo.QueryGetConsultaAncon_B2B;
                }
                else if (ComboBox0.GetSelectedDescription() == "DETALLISTAS - LPC B2C")
                {
                    Query = AddonMessageInfo.QueryGetConsultasDetalleLPC_B2C;
                }
                else if (ComboBox0.GetSelectedDescription() == "DETALLE LIMA B2C")
                {
                    Query = AddonMessageInfo.QueryGetConsultasDetalleLima_B2C;
                }
                else if (ComboBox0.GetSelectedDescription() == "TELEVENTAS B2C")
                {
                    Query = AddonMessageInfo.QueryGetConsultas_Televentas_B2C;
                }
                else if (ComboBox0.GetSelectedDescription() == "ROFALAB")
                {
                    Query = AddonMessageInfo.QueryGetConsultas_Rofalab;
                }
                else if (ComboBox0.GetSelectedDescription() == "SUPERMERCADOS")
                {
                    Query = AddonMessageInfo.QueryGetConsultas_Supermercados;
                }

                objMrp_Bll.GetClusterLima(oForm, Query,Grid0);
            }
            else if (ComboBox1.GetValue()=="2")// SUCURSAL
            {
                objMrp_Bll.GetClusterSucursales(oForm, recordSet, Grid0, ComboBox0, string.Empty, AddonMessageInfo.QueryGetPlanning,
                               AddonMessageInfo.QueryGetPlanningSelect, AddonMessageInfo.QueryGetPlanningClear);
            }
            else if (ComboBox1.GetValue() == "3")// INDUVIS
            {

            }
#elif AD_BO
        if (ComboBox1.GetValue()=="1")// SUCURSAL
            {
                SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
                objMrp_Bll.GetClusterSucursalesBO(oForm, oDT, Grid0, ComboBox0,AddonMessageInfo.QueryGetPlanning);
            }

#endif


        }

        private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            StaticText5.Item.Left = StaticText6.Item.Width+50;
        }

        private void Folder0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }
        
        private void StaticText5_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

            Thread mythr = new Thread((obj) =>
            {
                FrmCuadroClusterClasificacion frmCuadroClusterClasificacion = new FrmCuadroClusterClasificacion();
                frmCuadroClusterClasificacion.Show();
            });
            mythr.Start();

        }

        private void Application_MenuEvent(ref MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.MenuUID != "1282") // ID del menú "Cambiar de ventana"
            {
                SAPbouiCOM.Framework.Application.SBO_Application.StatusBar.SetText("No se permite cambiar de ventana", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Warning);
                BubbleEvent = false;
            }
        }

        private void EditText0_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
          objMrp_Bll.FindText(pVal, filaseleccionada, EditText0, Grid0,"Articulo");
        }

        private void EditText0_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            filaseleccionada = -1;
        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.Close();
        }
    }
}
