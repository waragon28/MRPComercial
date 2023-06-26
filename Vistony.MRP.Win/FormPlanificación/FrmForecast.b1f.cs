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
using Vistony.MRP.Constans;
using SAPbobsCOM;
using Vistony.MRP.BLL;
using Forxap.Framework.Extensions;
using SAPbouiCOM;
using Vistony.MRP.Win.Mantenimiento;

namespace Vistony.MRP.Win.FormPlanificación
{
    [FormAttribute(AddonMenuItem.AddonMainMenuForecast, "FormPlanificación/FrmForecast.b1f")]
    class FrmForecast : UserFormBase
    {
        public FrmForecast()
        {
        }

        public SAPbouiCOM.Form oForm;
        MRP_BLL objMrp_Bll = new MRP_BLL();
        string FilterGerencia=string.Empty;
        string FiltroUnidadMedida = string.Empty;
        string FilterUnidadMedida=string.Empty;
        public int filaseleccionada = -1;

        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.ComboBox ComboBox2;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.EditText EditText0;
        private StaticText StaticText7;
        private StaticText StaticText8;
        private SAPbouiCOM.Button Button0;
        private Button Button1;
        private Button Button2;

        public SAPbouiCOM.Matrix oMatrix;

        public int CodUser = Sb1Globals.UserSignature;
        public string NameCompletUser = Sb1Globals.NameCompletUser;
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_1").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_3").Specific));
            this.ComboBox0.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox0_ComboSelectAfter);
            this.ComboBox0.ClickAfter += new SAPbouiCOM._IComboBoxEvents_ClickAfterEventHandler(this.ComboBox0_ClickAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_5").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_6").Specific));
            this.Grid0.KeyDownAfter += new SAPbouiCOM._IGridEvents_KeyDownAfterEventHandler(this.Grid0_KeyDownAfter);
            this.Grid0.GotFocusAfter += new SAPbouiCOM._IGridEvents_GotFocusAfterEventHandler(this.Grid0_GotFocusAfter);
            this.Grid0.DoubleClickAfter += new SAPbouiCOM._IGridEvents_DoubleClickAfterEventHandler(this.Grid0_DoubleClickAfter);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_8").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_9").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.EditText0.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.EditText0_LostFocusAfter);
            this.EditText0.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText0_KeyDownAfter);
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_16").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_18").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_19").Specific));
            this.Button3.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button3_ClickBefore);
            this.Button3.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button3_ClickAfter);
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_20").Specific));
            this.Matrix0.KeyDownAfter += new SAPbouiCOM._IMatrixEvents_KeyDownAfterEventHandler(this.Matrix0_KeyDownAfter);
            this.Matrix0.DoubleClickAfter += new SAPbouiCOM._IMatrixEvents_DoubleClickAfterEventHandler(this.Matrix0_DoubleClickAfter);
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("Item_21").Specific));
            this.Button4.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button4_ClickBefore);
            this.Button4.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button4_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.ResizeAfter += new SAPbouiCOM.Framework.FormBase.ResizeAfterHandler(this.Form_ResizeAfter);
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryGetListSucu_Ind);
            ComboBox0.Select(1, SAPbouiCOM.BoSearchKey.psk_Index);
            Utils.LoadQueryDynamic(ref ComboBox1, AddonMessageInfo.QueryGetSucursalesAlmacen);
#if AD_BO
            ComboBox2.Item.Visible = false;
            StaticText2.Item.Visible = false;
            StaticText7.Item.Visible = false;
            Button1.Item.Visible = false;
#else
            Utils.LoadQueryDynamic(ref ComboBox2, AddonMessageInfo.QueryTipoGerencia);
            ComboBox2.Select(3, SAPbouiCOM.BoSearchKey.psk_Index);
#endif
            ComboBox1.Select(1, SAPbouiCOM.BoSearchKey.psk_Index);

            oMatrix = oForm.GetMatrix("Item_20");
            oMatrix.AutoResizeColumns();

            oForm.ScreenCenter();
            Grid0.AutoResizeColumns();
        }

        private void ComboBox0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            ComboBox1.RemoveValidValues();
            if (ComboBox2.ValidValues.Count > 0)
            {
                ComboBox2.RemoveValidValues();
            }
            switch (ComboBox0.GetValue())
            {
                case "1":
                    {
                        StaticText1.Caption = "Consulta";
                        Utils.LoadQueryDynamic(ref ComboBox1, AddonMessageInfo.QueryGetConsultas);
                        ComboBox1.Select(0, SAPbouiCOM.BoSearchKey.psk_Index);
                        StaticText2.Item.Visible = false;
                        ComboBox2.Item.Visible = false;
                    }
                    break;
                case "2":
                    {
                        StaticText1.Caption = "Sucursales";
                        Utils.LoadQueryDynamic(ref ComboBox1, AddonMessageInfo.QueryGetSucursalesAlmacen);
                        Utils.LoadQueryDynamic(ref ComboBox2, AddonMessageInfo.QueryTipoGerencia);
                        StaticText2.Item.Visible = true;
                        ComboBox2.Item.Visible = true;
                    }
                    break;
                case "3":
                    {
                        StaticText1.Caption = "Induvis";
                        //Utils.LoadQueryDynamic(ref ComboBox1, AddonMessageInfo);
                        StaticText2.Item.Visible = false;
                        ComboBox2.Item.Visible = false;
                    }
                    break;
            }

        }

        private void ComboBox0_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            
        }
        
        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //if (FilterGerencia != string.Empty)
            //{
                string Sucursal = ComboBox1.GetSelectedDescription();
                string Almacen = ComboBox1.GetSelectedValue();
                string TipoGerencia = ComboBox2.GetSelectedDescription();

                string Query = string.Format(AddonMessageInfo.QueryGetForecastSucursales, Sucursal, Almacen, TipoGerencia.Replace(".", "").Trim(), FilterGerencia, FilterUnidadMedida);
                Forxap.Framework.UI.Sb1Messages.ShowWarning("Iniciando Consulta");
                objMrp_Bll.addItem("", oForm, Query);
                /*
                oForm.Freeze(true);
                string Sucursal = ComboBox1.GetSelectedDescription();
                string Almacen = ComboBox1.GetSelectedValue();
                string TipoGerencia = ComboBox2.GetSelectedDescription();

                string Query = string.Format(AddonMessageInfo.QueryGetForecastSucursales, Sucursal, Almacen, TipoGerencia.Replace(".", "").Trim(), FilterGerencia, FilterUnidadMedida);

                SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
            
                objMrp_Bll.ExecuteQueryDataTable(ref oDT, Query);
                if (oDT.Rows.Count>0)
                {
                    FormatGrid(Grid0);
                }
               
                oForm.Freeze(false);
                */
                Forxap.Framework.UI.Sb1Messages.ShowSuccess("Consulta Terminada");
            //}
           
        }

        public void FormatGrid(Grid Grilla)
        {
            Grilla.ReadOnlyColumns();
            Grilla.Columns.Item("ARTICULO").LinkedObjectType(Grilla, "ARTICULO", "4");
            Grilla.Columns.Item("GAL_SKU").TitleObject.Caption = "Galones";
            Grilla.Columns.Item("SUCURSAL").TitleObject.Caption = "Sucursal";
            Grilla.Columns.Item("ARTICULO").TitleObject.Caption = "Articulo";
            Grilla.Columns.Item("DESCRIPCION").TitleObject.Caption = "Descripcion";
            Grilla.Columns.Item("UNIDAD_VENTA").TitleObject.Caption = "Unidad de Venta";
            Grilla.Columns.Item("1_MES_FUTURO").Visible = false;
            Grilla.Columns.Item("2_MES_FUTURO").Visible = false;
            Grilla.Columns.Item("3_MES_FUTURO").Visible = false;
            Grilla.Columns.Item("FILA").Visible = false;
            Grilla.Columns.Item("6_MESES").TitleObject.Caption = "6 Meses";
            Grilla.Columns.Item("4_MESES").TitleObject.Caption = "4 Meses";
            Grilla.Columns.Item("2_MESES").TitleObject.Caption = "2 Meses";
            Grilla.Columns.Item("FILA").TitleObject.Caption = "Fila";
            Grilla.Columns.Item("VTA_1").TitleObject.Caption = "Venta";
            Grilla.Columns.Item("PARETO").TitleObject.Caption = "Pareto";
            Grilla.Columns.Item("CATEGORIA").TitleObject.Caption = "Categoria";
            Grilla.Columns.Item("GAL_SKU").RightJustified = true;
            Grilla.Columns.Item("Mes 1").RightJustified = true;
            Grilla.Columns.Item("Mes 2").RightJustified = true;
            Grilla.Columns.Item("Mes 3").RightJustified = true;
            Grilla.Columns.Item("Mes 4").RightJustified = true;
            Grilla.Columns.Item("Mes 5").RightJustified = true;
            Grilla.Columns.Item("Mes 6").RightJustified = true;
            Grilla.Columns.Item("Mes 7").RightJustified = true;
            Grilla.Columns.Item("Mes 8").RightJustified = true;
            Grilla.Columns.Item("Mes 9").RightJustified = true;
            Grilla.Columns.Item("Mes 10").RightJustified = true;
            Grilla.Columns.Item("Mes 11").RightJustified = true;
            Grilla.Columns.Item("Mes 12").RightJustified = true;
            Grilla.Columns.Item("Mes 13").RightJustified = true;
            Grilla.Columns.Item("Mes 14").RightJustified = true;
            Grilla.Columns.Item("6_MESES").RightJustified = true;
            Grilla.Columns.Item("4_MESES").RightJustified = true;
            Grilla.Columns.Item("2_MESES").RightJustified = true;
            Grilla.Columns.Item("FILA").RightJustified = true;
            Grilla.Columns.Item("VTA_1").RightJustified = true;
            Grilla.Columns.Item("PARETO").RightJustified = true;
            Grilla.Columns.Item("Funcion Lineal").RightJustified = true;
            Grilla.Columns.Item("Exponencial").RightJustified = true;
            Grilla.Columns.Item("Logaritmico").RightJustified = true;
            Grilla.Columns.Item("Potencial").RightJustified = true;
            Grilla.Columns.Item("Polinomica").RightJustified = true;
            Grilla.Columns.Item("Pronostico").RightJustified = true;

            DateTime fechaActual = DateTime.Today;
            DateTime primerDiaMesActual_1 = new DateTime(fechaActual.Year, fechaActual.Month, 1);
            DateTime ultimoDiaMesAnterior_1 = primerDiaMesActual_1.AddDays(-1);
            // Convertir el último día del mes anterior a texto
            Grilla.Columns.Item("Mes 1").TitleObject.Caption = ultimoDiaMesAnterior_1.ToString("MMMM") + "-" + ultimoDiaMesAnterior_1.ToString("yy");

            
            DateTime primerDiaMesHaceDosMeses = primerDiaMesActual_1.AddMonths(-2);
            DateTime ultimoDiaMesHaceDosMeses = primerDiaMesHaceDosMeses.AddMonths(1).AddDays(-1);
            Grilla.Columns.Item("Mes 2").TitleObject.Caption = ultimoDiaMesHaceDosMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceDosMeses.ToString("yy");

            DateTime primerDiaMesHaceTresMeses = primerDiaMesActual_1.AddMonths(-3);
            DateTime ultimoDiaMesHaceTresMeses = primerDiaMesHaceTresMeses.AddMonths(1).AddDays(-1);
            Grilla.Columns.Item("Mes 3").TitleObject.Caption = ultimoDiaMesHaceTresMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceTresMeses.ToString("yy");

            DateTime primerDiaMesHaceCuatroMeses = primerDiaMesActual_1.AddMonths(-4);
            DateTime ultimoDiaMesHaceCuatroMeses = primerDiaMesHaceCuatroMeses.AddMonths(1).AddDays(-1);
            Grilla.Columns.Item("Mes 4").TitleObject.Caption = ultimoDiaMesHaceCuatroMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceCuatroMeses.ToString("yy");

            DateTime primerDiaMesHaceQuintoMeses = primerDiaMesActual_1.AddMonths(-5);
            DateTime ultimoDiaMesHaceQuintoMeses = primerDiaMesHaceQuintoMeses.AddMonths(1).AddDays(-1);
            Grilla.Columns.Item("Mes 5").TitleObject.Caption = ultimoDiaMesHaceQuintoMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceQuintoMeses.ToString("yy");

            DateTime primerDiaMesHaceSextoMeses = primerDiaMesActual_1.AddMonths(-6);
            DateTime ultimoDiaMesHaceSextoMeses = primerDiaMesHaceSextoMeses.AddMonths(1).AddDays(-1);
            Grilla.Columns.Item("Mes 6").TitleObject.Caption = ultimoDiaMesHaceSextoMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceSextoMeses.ToString("yy");

            DateTime primerDiaMesHaceSeptimoMeses = primerDiaMesActual_1.AddMonths(-7);
            DateTime ultimoDiaMesHaceSeptimoMeses = primerDiaMesHaceSeptimoMeses.AddMonths(1).AddDays(-1);
            Grilla.Columns.Item("Mes 7").TitleObject.Caption = ultimoDiaMesHaceSeptimoMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceSeptimoMeses.ToString("yy");

            DateTime primerDiaMesHaceOctavoMeses = primerDiaMesActual_1.AddMonths(-8);
            DateTime ultimoDiaMesHaceOctavoMeses = primerDiaMesHaceOctavoMeses.AddMonths(1).AddDays(-1);
            Grilla.Columns.Item("Mes 8").TitleObject.Caption = ultimoDiaMesHaceOctavoMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceOctavoMeses.ToString("yy");

            DateTime primerDiaMesHaceNovenoMeses = primerDiaMesActual_1.AddMonths(-9);
            DateTime ultimoDiaMesHaceNovenoMeses = primerDiaMesHaceNovenoMeses.AddMonths(1).AddDays(-1);
            Grilla.Columns.Item("Mes 9").TitleObject.Caption = ultimoDiaMesHaceNovenoMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceNovenoMeses.ToString("yy");

            DateTime primerDiaMesHaceDecimoMeses = primerDiaMesActual_1.AddMonths(-10);
            DateTime ultimoDiaMesHaceDecimoMeses = primerDiaMesHaceDecimoMeses.AddMonths(1).AddDays(-1);
            Grilla.Columns.Item("Mes 10").TitleObject.Caption = ultimoDiaMesHaceDecimoMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceDecimoMeses.ToString("yy");

            DateTime primerDiaMesHaceDecimo_UnoMeses = primerDiaMesActual_1.AddMonths(-11);
            DateTime ultimoDiaMesHaceDecimo_UnoMeses = primerDiaMesHaceDecimo_UnoMeses.AddMonths(1).AddDays(-1);
            Grilla.Columns.Item("Mes 11").TitleObject.Caption = ultimoDiaMesHaceDecimo_UnoMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceDecimo_UnoMeses.ToString("yy");

            DateTime primerDiaMesHaceDecimo_DosMeses = primerDiaMesActual_1.AddMonths(-12);
            DateTime ultimoDiaMesHaceDecimo_DosMeses = primerDiaMesHaceDecimo_DosMeses.AddMonths(1).AddDays(-1);
            Grilla.Columns.Item("Mes 12").TitleObject.Caption = ultimoDiaMesHaceDecimo_DosMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceDecimo_DosMeses.ToString("yy");
        
            DateTime primerDiaMesHaceDecimo_TresMeses = primerDiaMesActual_1.AddMonths(-13);
            DateTime ultimoDiaMesHaceDecimo_TresMeses = primerDiaMesHaceDecimo_TresMeses.AddMonths(1).AddDays(-1);
            Grilla.Columns.Item("Mes 13").TitleObject.Caption = ultimoDiaMesHaceDecimo_TresMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceDecimo_TresMeses.ToString("yy");

            DateTime primerDiaMesHaceDecimo_CuatroMeses = primerDiaMesActual_1.AddMonths(-14);
            DateTime ultimoDiaMesHaceDecimo_CuatroMeses = primerDiaMesHaceDecimo_CuatroMeses.AddMonths(1).AddDays(-1);
            Grilla.Columns.Item("Mes 14").TitleObject.Caption = ultimoDiaMesHaceDecimo_CuatroMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceDecimo_CuatroMeses.ToString("yy");

            Grilla.AutoResizeColumns();
            Grilla.Columns.Item("Requerimiento").RightJustified = true;
            Grilla.Columns.Item("Requerimiento").Editable = true;
            Grilla.AssignLineNro();
        }
        
        private void Button1_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            FrmFiltroGerenciaForecast frmFiltroGerenciaForecast = new FrmFiltroGerenciaForecast(this,FilterGerencia);
            frmFiltroGerenciaForecast.Show();
        }

        public void ObtenerFiltroGerencia(string filterGerencia,string LabelGerencia)
        {
            FilterGerencia = filterGerencia;
            StaticText7.Caption = LabelGerencia;
        }

        public void ObtenerFiltroUnidadMedida(string filterUnidadMedida, string LabelUnidadMedida)
        {
            FilterUnidadMedida = filterUnidadMedida;
            StaticText8.Caption = LabelUnidadMedida;
        }

        private void Button2_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            FrmFiltroUnidadMedidaForecast frmFiltroUnidadMedidaForecast = new FrmFiltroUnidadMedidaForecast(this, FilterUnidadMedida);
            frmFiltroUnidadMedidaForecast.Show();
        }

        private void Grid0_DoubleClickAfter(object sboObject, SBOItemEventArg pVal)
        {
          
        }

        private void EditText0_KeyDownAfter(object sboObject, SBOItemEventArg pVal)
        {
            objMrp_Bll.FindText(pVal, filaseleccionada, EditText0, Grid0,"ARTICULO");

        }

        private void EditText0_LostFocusAfter(object sboObject, SBOItemEventArg pVal)
        {
            filaseleccionada = -1;
        }

        private void Form_ResizeAfter(SBOItemEventArg pVal)
        {
           
        }

        private Button Button3;

        private void Button3_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {

            FrmPeriodo frmPeriodo = new FrmPeriodo(this);
            frmPeriodo.Show();
        }

        public void Procesar(string Periodo)
        {
            string PuntoEmision = ComboBox1.GetSelectedDescription();
#if AD_PE
            string TipoGerencia = ComboBox2.GetSelectedDescription();

#else
            string TipoGerencia = "";
#endif
            string Date = DateTime.Now.ToString("yyyyMMdd");
            objMrp_Bll.ProcesarV2(oMatrix, CodUser, NameCompletUser, PuntoEmision, Date, TipoGerencia, Periodo,Button4);
        }

        private void Form_LoadAfter(SBOItemEventArg pVal)
        {
           
        }

        private void Button3_ClickBefore(object sboObject, SBOItemEventArg pVal,out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (oMatrix.RowCount>0)
            {
                BubbleEvent = true;
            }
            else
            {
                BubbleEvent = false;
            }
           
        }

        private void Grid0_GotFocusAfter(object sboObject, SBOItemEventArg pVal)
        {
            
        }

        private void Grid0_KeyDownAfter(object sboObject, SBOItemEventArg pVal)
        {
            if (pVal.ColUID== "Requerimiento")
            {
                double LimiteInferior = Convert.ToInt32(Grid0.DataTable.GetString("Pronostico", pVal.Row).ToString())-(Convert.ToInt32(Grid0.DataTable.GetString("Pronostico", pVal.Row).ToString())*0.25);
                SAPbouiCOM.DataTable exp;
                exp = oForm.DataSources.DataTables.Item("DT_0");
                int Digito =Convert.ToInt32(exp.GetString("Requerimiento",pVal.Row).ToString());
                int Digito2 =Convert.ToInt32(Grid0.DataTable.GetString("Requerimiento",pVal.Row).ToString());
                if (LimiteInferior>= Digito && LimiteInferior <= Digito)
                {
                    Grid0.SetCellBackColor(pVal.Row, 36, System.Drawing.Color.Yellow);
                }
                
            }
        }

        private Matrix Matrix0;

        private void Matrix0_DoubleClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            
            FrmSeleccionGrafico FrmSeleccionGrafico = new FrmSeleccionGrafico(Matrix0, pVal,"");
            FrmSeleccionGrafico.Show();

        }

        private Button Button4;

        private void Matrix0_KeyDownAfter(object sboObject, SBOItemEventArg pVal)
        {
            if (pVal.ColUID=="")
            {
                SAPbouiCOM.DataTable exp;
                exp = oForm.DataSources.DataTables.Item("DT_0");
                int Digito = Convert.ToInt32(exp.GetString("Requerimiento", pVal.Row).ToString());
                double ProcentajeLimInferior = Digito *0.25;

                if (ProcentajeLimInferior > Digito)
                {
                    
                }
            }

        }

        private void Button4_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
                #if AD_BO
                            int DocumentsOwner = Convert.ToInt32(Sb1Globals.empID);
                            objMrp_Bll.GenerarPedido(oMatrix, Sb1Globals.UserSignature, DocumentsOwner, NameCompletUser);
                #else
                            FrmAsignarDatoST frmAsignarDatoST = new FrmAsignarDatoST(this);
                            frmAsignarDatoST.Show();
                #endif

        }
        public void Generar_ST_Draft(string FromWarehouse,string ToWarehouse,string U_SYP_MDMT)
        {
            DateTime fechaActual = DateTime.Today;
            string DocDate = fechaActual.ToString("yyyyMMdd");
            string DueDate = fechaActual.ToString("yyyyMMdd");
            string TaxDate = fechaActual.ToString("yyyyMMdd");
            string JournalMemot = "Solicitud generada por Forecast " + NameCompletUser;
            string DocObjectCode = "1250000001";
            string U_SYP_SOLICITANTE = Sb1Globals.UserName;
            int DocumentsOwner =Convert.ToInt32(Sb1Globals.empID);

            objMrp_Bll.GenerarDraftST( oMatrix, DocDate, DueDate, JournalMemot, FromWarehouse, ToWarehouse, DocObjectCode, TaxDate, U_SYP_MDMT, U_SYP_SOLICITANTE );

        }
        private void Button4_ClickBefore(object sboObject, SBOItemEventArg pVal,out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (oMatrix.RowCount > 0)
            {
                BubbleEvent = true;
            }
            else
            {
                BubbleEvent = true;
            }
        }

    }
}
