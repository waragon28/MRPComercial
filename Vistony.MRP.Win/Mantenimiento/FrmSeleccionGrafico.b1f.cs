using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using SAPbouiCOM;
using Forxap.Framework.Extensions;
using System.Threading;
using Forxap.Framework.UI;
using Vistony.MRP.Win.Graficos;

namespace Vistony.MRP.Win.Mantenimiento
{
    [FormAttribute("Vistony.MRP.Win.Mantenimiento.FrmSeleccionGrafico", "Mantenimiento/FrmSeleccionGrafico.b1f")]
    class FrmSeleccionGrafico : UserFormBase
    {

        public static List<double> List_V_y = new List<double>();
        SAPbouiCOM.Form oForm;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.StaticText StaticText0;

        public FrmSeleccionGrafico()
        {
        }
        public FrmSeleccionGrafico(Grid Grid3, SBOItemEventArg pVal)
        {
            List_V_y.Clear();
            List_V_y.Add(Convert.ToDouble(Grid3.DataTable.GetString("Mes 14", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(Grid3.DataTable.GetString("Mes 13", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(Grid3.DataTable.GetString("Mes 12", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(Grid3.DataTable.GetString("Mes 11", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(Grid3.DataTable.GetString("Mes 10", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(Grid3.DataTable.GetString("Mes 9", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(Grid3.DataTable.GetString("Mes 8", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(Grid3.DataTable.GetString("Mes 7", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(Grid3.DataTable.GetString("Mes 6", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(Grid3.DataTable.GetString("Mes 5", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(Grid3.DataTable.GetString("Mes 4", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(Grid3.DataTable.GetString("Mes 3", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(Grid3.DataTable.GetString("Mes 2", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(Grid3.DataTable.GetString("Mes 1", pVal.Row)));
        }
        public FrmSeleccionGrafico(Matrix oMatrix, SBOItemEventArg pVal,string V2)
        {
            
            List_V_y.Clear();
            List_V_y.Add(Convert.ToDouble(oMatrix.GetValueFromEditText("Col_5", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(oMatrix.GetValueFromEditText("Col_6", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(oMatrix.GetValueFromEditText("Col_7", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(oMatrix.GetValueFromEditText("Col_8", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(oMatrix.GetValueFromEditText("Col_9", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(oMatrix.GetValueFromEditText("Col_10", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(oMatrix.GetValueFromEditText("Col_11", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(oMatrix.GetValueFromEditText("Col_12", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(oMatrix.GetValueFromEditText("Col_13", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(oMatrix.GetValueFromEditText("Col_14", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(oMatrix.GetValueFromEditText("Col_15", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(oMatrix.GetValueFromEditText("Col_16", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(oMatrix.GetValueFromEditText("Col_17", pVal.Row)));
            List_V_y.Add(Convert.ToDouble(oMatrix.GetValueFromEditText("Col_18", pVal.Row)));
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
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_3").Specific));
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
            oForm.ScreenCenter();
        }

        private void Button0_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            oForm.Close();
        }

        private void Button1_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {

            if (ComboBox0.GetValue() == "1")
            {
                Thread mythr = new Thread((obj) =>
                {
                    GraficoFuncionLineal graficoFunciones = new GraficoFuncionLineal(List_V_y);
                    graficoFunciones.Show();
                    graficoFunciones.Activate();
                    graficoFunciones.Focus();
                    System.Windows.Forms.Application.Run();
                });
                mythr.Start();
            }
            else if (ComboBox0.GetValue() == "2")
            {
                Thread mythr = new Thread((obj) =>
                {
                    GraficoFuncionExponencial graficoFunciones = new GraficoFuncionExponencial(List_V_y);
                    graficoFunciones.Show();
                    graficoFunciones.Activate();
                    graficoFunciones.Focus();
                    System.Windows.Forms.Application.Run();
                });
                mythr.Start();
            }
            else if (ComboBox0.GetValue() == "3")
            {
                Thread mythr = new Thread((obj) =>
                {
                    GraficoFuncionLogaritmica graficoFunciones = new GraficoFuncionLogaritmica(List_V_y);
                    graficoFunciones.Show();
                    graficoFunciones.Activate();
                    graficoFunciones.Focus();
                    System.Windows.Forms.Application.Run();
                });
                mythr.Start();
            }
            else if (ComboBox0.GetValue() == "4")
            {
                Thread mythr = new Thread((obj) =>
                {
                    GraficoFuncionPolinomica graficoFunciones = new GraficoFuncionPolinomica(List_V_y);
                    graficoFunciones.Show();
                    graficoFunciones.Activate();
                    graficoFunciones.Focus();
                    System.Windows.Forms.Application.Run();
                });
                mythr.Start();
            }
            else if (ComboBox0.GetValue() == "5")
            {
                Thread mythr = new Thread((obj) =>
                {
                    GraficoFuncionPotencial graficoFunciones = new GraficoFuncionPotencial(List_V_y);
                    graficoFunciones.Show();
                    graficoFunciones.Activate();
                    graficoFunciones.Focus();
                    System.Windows.Forms.Application.Run();
                });
                mythr.Start();
            }
            else if (ComboBox0.GetValue() == "6")
            {
                Thread mythr = new Thread((obj) =>
                {
                    GraficoFuncionesConsolidado graficoFunciones = new GraficoFuncionesConsolidado(List_V_y);
                    graficoFunciones.Show();
                    graficoFunciones.Activate();
                    graficoFunciones.Focus();
                    System.Windows.Forms.Application.Run();
                });
                mythr.Start();
            }
            else
            {
                Sb1Messages.ShowError("error de opción");
            }

        }
    }
}
