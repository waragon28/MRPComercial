using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Vistony.MRP.Win;
using Vistony.MRP.Constans;
using Vistony.MRP.BLL;
using Forxap.Framework.Extensions;
using SAPbobsCOM;

namespace Vistony.MRP.Win.Asistentes
{
    [FormAttribute("Vistony.MRP.Win.Asistentes.wzdAsistenteMRP", "Asistentes/wzdAsistenteMRP.b1f")]
    class wzdAsistenteMRP : UserFormBase
    {
        public SAPbouiCOM.Form oForm;
        public wzdAsistenteMRP()
        {
        }
        MRP_BLL MRP_BLL1 = new MRP_BLL();
        public int PaneMax { get; set; }
        public int PaneLevel { get; set; }
        public int filaseleccionada = -1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.OptionBtn OptionBtn2;
        private SAPbouiCOM.OptionBtn OptionBtn3;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.OptionBtn OptionBtn0;
        private SAPbouiCOM.OptionBtn OptionBtn1;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText7;
        SAPbobsCOM.Recordset recordSet = null;

        private void PriorPane()
        {
            oForm.Freeze(true);
            if (PaneLevel + 1 >= 1)
            {
                oForm.PaneLevel -= 1;
            }
            if (oForm.PaneLevel == 1)
            {
            }
            if (oForm.PaneLevel == 2)
            {
                oForm.PaneLevel = 2;
            }
            if (oForm.PaneLevel == 3)
            {
                oForm.PaneLevel = 2;
            }
            if (oForm.PaneLevel == 4)
            {
                oForm.PaneLevel = 2;
            }
            oForm.Freeze(false);

        }
        private void NextPane()
          {
            oForm.Freeze(true);

            PaneMax = 4;

            if (PaneLevel < PaneMax)
              {
                  oForm.PaneLevel += 1;
              }
              if (oForm.PaneLevel == 1)
              {
                oForm.PaneLevel = 2;
              }
            if (oForm.PaneLevel == 2)
            {

            }
              if (oForm.PaneLevel == 3)
              {
                if (OptionBtn2.Selected && OptionBtn0.Selected)//Cluster Sucursales
                {
                    oForm.PaneLevel = 3;
                }
                else if (OptionBtn2.Selected && OptionBtn3.Selected)//Forecast Sucursales
                {
                   
                }
                else if (OptionBtn1.Selected && OptionBtn2.Selected )//Cluster Lima 
                {
                    oForm.PaneLevel = 4;
                }
                else if (OptionBtn4.Selected && OptionBtn2.Selected)//Cluster Induvis 
                {
                    oForm.PaneLevel = 5;
                }
                else
                {
                    oForm.PaneLevel = 2; //Ancon

                }
             }   
            oForm.Freeze(false);

        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_4").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_5").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.OptionBtn0 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_8").Specific));
            this.OptionBtn0.ClickAfter += new SAPbouiCOM._IOptionBtnEvents_ClickAfterEventHandler(this.OptionBtn0_ClickAfter);
            this.OptionBtn1 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_9").Specific));
            this.OptionBtn1.ClickAfter += new SAPbouiCOM._IOptionBtnEvents_ClickAfterEventHandler(this.OptionBtn1_ClickAfter);
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_11").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_12").Specific));
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_13").Specific));
            this.EditText0.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.EditText0_LostFocusAfter);
            this.EditText0.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText0_KeyDownAfter);
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_15").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.OptionBtn2 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_17").Specific));
            this.OptionBtn3 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_18").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_19").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.Grid1 = ((SAPbouiCOM.Grid)(this.GetItem("Item_21").Specific));
            this.Grid1.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid1_ClickAfter);
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_22").Specific));
            this.EditText1.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText1_KeyDownAfter);
            this.EditText1.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.EditText1_LostFocusAfter);
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_23").Specific));
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_24").Specific));
            this.Button3.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button3_ClickAfter);
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_25").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_26").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_27").Specific));
            this.OptionBtn4 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_28").Specific));
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_29").Specific));
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_30").Specific));
            this.Grid2 = ((SAPbouiCOM.Grid)(this.GetItem("Item_31").Specific));
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_32").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_33").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            OptionBtn0.GroupWith("Item_9");
            OptionBtn4.GroupWith("Item_9");
            OptionBtn2.GroupWith("Item_18");
            StaticText0.SetBold();
            StaticText0.SetSize(15);
            Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryGetSucursales);
            Utils.LoadQueryDynamic2(ref ComboBox1, AddonMessageInfo.QueryGetConsultas);
            oForm.ScreenCenter();
            OptionBtn0.Selected = true;
            OptionBtn2.Selected = true;
            Grid0.AutoResizeColumns();
            Grid1.AutoResizeColumns();
        }
        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            NextPane();
        }
        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            PriorPane();
        }
        public string Sucursal;
        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Forxap.Framework.UI.Sb1Messages.ShowWarning("Iniciando Consulta");
           // Grid1.DataTable.Clear();
            oForm.Freeze(true);

            try
            {
                recordSet = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                Grid0.DataTable.Clear();
                    SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
                if (ComboBox0.Value=="1")
                {
                    for (int ListSucursal = 0; ListSucursal < ComboBox0.ValidValues.Count; ListSucursal++)
                    {
                        ComboBox0.Select(ListSucursal, SAPbouiCOM.BoSearchKey.psk_Index);
                        Sucursal = ComboBox0.Value;
                        if (Sucursal != "1")
                        {
                            try
                            {
                                MRP_BLL1.ExecuteQueryRecorsed(recordSet, string.Format(AddonMessageInfo.QueryGetPlanning, ComboBox0.Value, ""));
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                           
                        }
                    }

                    MRP_BLL1.ExecuteQueryDataTable(ref oDT, AddonMessageInfo.QueryGetPlanningSelect);
                    ComboBox0.Select(0, SAPbouiCOM.BoSearchKey.psk_Index);
                    Grid0.Sortable();
                    Grid0.ReadOnlyColumns();
                    Grid0.AutoResizeColumns();
                    Grid0.Columns.Item("Articulo").LinkedObjectType(Grid0, "Articulo", "4");
                }
                else
                {
                    
                    MRP_BLL1.ExecuteQueryRecorsed(recordSet,string.Format(AddonMessageInfo.QueryGetPlanning, ComboBox0.Value, ""));
                    MRP_BLL1.ExecuteQueryDataTable(ref oDT, AddonMessageInfo.QueryGetPlanningSelect);
                    Grid0.Sortable();
                     Grid0.ReadOnlyColumns();
                     Grid0.AutoResizeColumns();
                     Grid0.Columns.Item("Articulo").LinkedObjectType(Grid0, "Articulo", "4");
                }

                Forxap.Framework.UI.Sb1Messages.ShowSuccess("Consulta Terminada");

                MRP_BLL1.ExecuteQueryRecorsed(recordSet, AddonMessageInfo.QueryGetPlanningClear);
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {
                oForm.Freeze(false);
            }

        }
        private void EditText0_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                string texto = EditText0.Value;
                if (texto.Length <7)
                {
                    filaseleccionada = -1;
                    return;
                }
                if (pVal.CharPressed != 13)
                {
                    if (texto.Length ==7)
                    {
                        for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                        {
                            string docnum = Grid0.DataTable.GetString("Articulo", row);
                            if (docnum == texto)
                            {
                                Grid0.Rows.SelectedRows.Clear();
                                Grid0.Rows.SelectedRows.Add(row);
                                filaseleccionada = row;
                                return;
                            }
                        }
                    }
                   
                }
                else
                {
                }
            }
            catch
            { }
        }
        private void EditText0_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            filaseleccionada = -1;
        }
        private void Grid0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.Row>=0)
            {
                Grid0.Rows.SelectedRows.Add(pVal.Row);
            }
        }
        private void OptionBtn1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
              //  ComboBox1.Item.Visible = true;
            }
            catch (Exception)
            {
                
            }
        }
        private void OptionBtn0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
               // ComboBox1.Item.Visible = false;
            }
            catch (Exception)
            {

               
            }
        }

        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.Grid Grid1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.Button Button3;

        private void Button3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            string Query = "";
            if (ComboBox1.GetSelectedDescription()== "ANCON B2B")
            {
                Query = AddonMessageInfo.QueryGetConsultaAncon_B2B;
            }
            else if (ComboBox1.GetSelectedDescription() == "DETALLISTAS - LPC B2C")
            {
                Query = AddonMessageInfo.QueryGetConsultasDetalleLPC_B2C;
            }
            else if (ComboBox1.GetSelectedDescription() == "DETALLE LIMA B2C")
            {
                Query = AddonMessageInfo.QueryGetConsultasDetalleLima_B2C;
            }
            else if (ComboBox1.GetSelectedDescription() == "TELEVENTAS B2C")
            {
                Query = AddonMessageInfo.QueryGetConsultas_Televentas_B2C;
            }
            else if (ComboBox1.GetSelectedDescription() == "ROFALAB")
            {
                Query = AddonMessageInfo.QueryGetConsultas_Rofalab;
            }
            else if (ComboBox1.GetSelectedDescription() == "SUPERMERCADOS")
            {
                Query = AddonMessageInfo.QueryGetConsultas_Supermercados;
            }
            Forxap.Framework.UI.Sb1Messages.ShowWarning("Iniciando Consulta");

            oForm.Freeze(true);
            Grid1.DataTable.Clear();
            try
            {
                SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_1");
                MRP_BLL1.ExecuteQueryDataTable(ref oDT, Query);
                if (oDT.Rows.Count>0)
                {
                    Grid1.Sortable();
                    Grid1.ReadOnlyColumns();
                    Grid1.AutoResizeColumns();
                    Grid1.Columns.Item("Articulo").LinkedObjectType(Grid1, "Articulo", "4");
                    Forxap.Framework.UI.Sb1Messages.ShowSuccess("Consulta Terminada");
                }
                else
                {
                    Forxap.Framework.UI.Sb1Messages.ShowWarning("Sin Informacion");
                }
               
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void Grid1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.Row >= 0)
            {
                Grid1.Rows.SelectedRows.Add(pVal.Row);
            }
        }

        private void EditText1_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            filaseleccionada = -1;
        }

        private void EditText1_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                string texto = EditText1.Value;
                if (texto.Length < 7)
                {
                    filaseleccionada = -1;
                    return;
                }
                if (pVal.CharPressed != 13)
                {
                    if (texto.Length == 7)
                    {
                        for (int row = 0; row <= Grid1.Rows.Count - 1; row++)
                        {
                            string docnum = Grid1.DataTable.GetString("Articulo", row);
                            if (docnum == texto)
                            {
                                Grid1.Rows.SelectedRows.Clear();
                                Grid1.Rows.SelectedRows.Add(row);
                                filaseleccionada = row;
                                return;
                            }
                        }
                    }

                }
                else
                {
                }
            }
            catch
            { }
        }

        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.OptionBtn OptionBtn4;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.ComboBox ComboBox2;
        private SAPbouiCOM.Grid Grid2;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.EditText EditText2;
    }
}
