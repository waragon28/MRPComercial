using Forxap.Framework.Extensions;
using Newtonsoft.Json;
using SAPbobsCOM;
using SAPbouiCOM;
using System;
using System.Collections.Generic;
using Vistony.MRP.BO;

namespace Vistony.MRP.DAL
{
    public class MRP_DAL
    {
        public SAPbouiCOM.DataTable ExecuteQueryDataTable(ref SAPbouiCOM.DataTable oDT, string Query)
        {
            try
            {
                string sSTRSQL =  Query;
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
                return null;
            }
        }
        public void addItem(string CardCode,Form oForm,string Query)
        {
        SAPbouiCOM.Matrix oMatrix;
        /*EJECUTAR EL PROCEDIMIENTO ALMACENADO*/
         SAPbouiCOM.DataTable exp;
            exp = oForm.DataSources.DataTables.Item("DT_QUERY");
            exp.ExecuteQuery(Query);
            /*FIN DE EJECUCION DE PROCEDIMIENTO ALMACENADO*/


            SAPbouiCOM.DataTable udt = oForm.GetDataTable("DT_2");
            oMatrix = oForm.GetMatrix("Item_20");
            oMatrix.Clear();
            SAPbouiCOM.Columns oColumns;
            oColumns = oMatrix.Columns;
            SAPbouiCOM.Column oColumn;
            var colItems = udt.Columns;
            oForm.Freeze(true);
            if (udt.Columns.Count == 0)
            {

                colItems.Add("#", BoFieldsType.ft_AlphaNumeric);
                colItems.Add("Sucursal", BoFieldsType.ft_AlphaNumeric);
                colItems.Add("Articulo", BoFieldsType.ft_AlphaNumeric);
                colItems.Add("Descripción", BoFieldsType.ft_AlphaNumeric);
                colItems.Add("Galones", BoFieldsType.ft_AlphaNumeric);
                colItems.Add("Unidad de Venta", BoFieldsType.ft_AlphaNumeric);
                colItems.Add("Mes 14", BoFieldsType.ft_Integer);
                colItems.Add("Mes 13", BoFieldsType.ft_Integer);
                colItems.Add("Mes 12", BoFieldsType.ft_Integer);
                colItems.Add("Mes 11", BoFieldsType.ft_Integer);
                colItems.Add("Mes 10", BoFieldsType.ft_Integer);
                colItems.Add("Mes 9", BoFieldsType.ft_Integer);
                colItems.Add("Mes 8", BoFieldsType.ft_Integer);
                colItems.Add("Mes 7", BoFieldsType.ft_Integer);
                colItems.Add("Mes 6", BoFieldsType.ft_Integer);
                colItems.Add("Mes 5", BoFieldsType.ft_Integer);
                colItems.Add("Mes 4", BoFieldsType.ft_Integer);
                colItems.Add("Mes 3", BoFieldsType.ft_Integer);
                colItems.Add("Mes 2", BoFieldsType.ft_Integer);
                colItems.Add("Mes 1", BoFieldsType.ft_Integer);
                colItems.Add("6 Meses", BoFieldsType.ft_Integer);
                colItems.Add("4 Meses", BoFieldsType.ft_Integer);
                colItems.Add("2 Meses", BoFieldsType.ft_Integer);
                colItems.Add("Venta", BoFieldsType.ft_AlphaNumeric);
                colItems.Add("Pareto", BoFieldsType.ft_AlphaNumeric);
                colItems.Add("Categoria", BoFieldsType.ft_AlphaNumeric);
                colItems.Add("Función Lineal", BoFieldsType.ft_Integer);
                colItems.Add("Función Exponencial", BoFieldsType.ft_Integer);
                colItems.Add("Función Logaritmica", BoFieldsType.ft_Integer);
                colItems.Add("Función Potencial", BoFieldsType.ft_Integer);
                colItems.Add("Función Polinomica", BoFieldsType.ft_Integer);
                colItems.Add("Función", BoFieldsType.ft_AlphaNumeric);
                colItems.Add("Pronostico", BoFieldsType.ft_AlphaNumeric);
                colItems.Add("Limite Inferior", BoFieldsType.ft_Integer);
                colItems.Add("Requerimiento", BoFieldsType.ft_AlphaNumeric);
                colItems.Add("Limite Superior", BoFieldsType.ft_AlphaNumeric);
                colItems.Add("Stock", BoFieldsType.ft_AlphaNumeric);
            }
                int a = udt.Rows.Count;
                if (oMatrix.RowCount > 0)
                    a = udt.Rows.Count;
                for (int oRow = 0; oRow < exp.Rows.Count; oRow++)
                {
                 udt.Rows.Add();
                 udt.SetValue("#", oRow,oRow+1);
                 udt.SetValue("Sucursal", oRow, exp.GetString("SUCURSAL", oRow));
                 udt.SetValue("Articulo", oRow, exp.GetString("ARTICULO", oRow));
                 udt.SetValue("Descripción", oRow, exp.GetString("DESCRIPCION", oRow));
                 udt.SetValue("Galones", oRow, exp.GetString("GAL_SKU", oRow));
                 udt.SetValue("Unidad de Venta", oRow, exp.GetString("UNIDAD_VENTA", oRow));
                 udt.SetValue("Mes 14", oRow, exp.GetString("Mes 14", oRow));
                 udt.SetValue("Mes 13", oRow, exp.GetString("Mes 13", oRow));
                 udt.SetValue("Mes 12", oRow, exp.GetString("Mes 12", oRow));
                 udt.SetValue("Mes 11", oRow, exp.GetString("Mes 11", oRow));
                 udt.SetValue("Mes 10", oRow, exp.GetString("Mes 10", oRow));
                 udt.SetValue("Mes 9", oRow, exp.GetString("Mes 9", oRow));
                 udt.SetValue("Mes 8", oRow, exp.GetString("Mes 8", oRow));
                 udt.SetValue("Mes 7", oRow, exp.GetString("Mes 7", oRow));
                 udt.SetValue("Mes 6", oRow, exp.GetString("Mes 6", oRow));
                 udt.SetValue("Mes 5", oRow, exp.GetString("Mes 5", oRow));
                 udt.SetValue("Mes 4", oRow, exp.GetString("Mes 4", oRow));
                 udt.SetValue("Mes 3", oRow, exp.GetString("Mes 3", oRow));
                 udt.SetValue("Mes 2", oRow, exp.GetString("Mes 2", oRow));
                 udt.SetValue("Mes 1", oRow, exp.GetString("Mes 1", oRow));
                 udt.SetValue("6 Meses", oRow, exp.GetString("6_MESES", oRow));
                 udt.SetValue("4 Meses", oRow, exp.GetString("4_MESES", oRow));
                 udt.SetValue("2 Meses", oRow, exp.GetString("2_MESES", oRow));
                 udt.SetValue("Venta", oRow, exp.GetString("VTA_1", oRow));
                 udt.SetValue("Pareto", oRow, exp.GetString("PARETO", oRow)); 
                 udt.SetValue("Categoria", oRow, exp.GetString("CATEGORIA", oRow));
                 udt.SetValue("Función Lineal", oRow, exp.GetString("Funcion Lineal", oRow));
                 udt.SetValue("Función Exponencial", oRow, exp.GetString("Exponencial", oRow));
                 udt.SetValue("Función Logaritmica", oRow, exp.GetString("Logaritmico", oRow));
                 udt.SetValue("Función Potencial", oRow, exp.GetString("Potencial", oRow));
                 udt.SetValue("Función Polinomica", oRow, exp.GetString("Polinomica", oRow));
                 udt.SetValue("Función", oRow, exp.GetString("Funcion", oRow));
                 udt.SetValue("Pronostico", oRow, exp.GetString("Pronostico", oRow));
                 udt.SetValue("Limite Inferior", oRow, Convert.ToInt32(exp.GetString("Limite Inferior", oRow)));
                 udt.SetValue("Requerimiento",oRow, Convert.ToInt32(exp.GetString("Pronostico", oRow)));
                 udt.SetValue("Limite Superior", oRow,exp.GetString("Limite Superior", oRow));
                 udt.SetValue("Stock", oRow, exp.GetString("Stock", oRow));


            }

                oMatrix.Columns.Item("Col_0").DataBind.Bind("DT_2", "Sucursal");
                oMatrix.Columns.Item("Col_1").DataBind.Bind("DT_2", "Articulo");
                oMatrix.Columns.Item("Col_2").DataBind.Bind("DT_2", "Descripción");
                oMatrix.Columns.Item("Col_3").DataBind.Bind("DT_2", "Galones");
                oMatrix.Columns.Item("Col_4").DataBind.Bind("DT_2", "Unidad de Venta");
                oMatrix.Columns.Item("Col_5").DataBind.Bind("DT_2", "Mes 14");
                oMatrix.Columns.Item("Col_6").DataBind.Bind("DT_2", "Mes 13");
                oMatrix.Columns.Item("Col_7").DataBind.Bind("DT_2", "Mes 12");
                oMatrix.Columns.Item("Col_8").DataBind.Bind("DT_2", "Mes 11");
                oMatrix.Columns.Item("Col_9").DataBind.Bind("DT_2", "Mes 10");
                oMatrix.Columns.Item("Col_10").DataBind.Bind("DT_2", "Mes 9");
                oMatrix.Columns.Item("Col_11").DataBind.Bind("DT_2", "Mes 8");
                oMatrix.Columns.Item("Col_12").DataBind.Bind("DT_2", "Mes 7");
                oMatrix.Columns.Item("Col_13").DataBind.Bind("DT_2", "Mes 6");
                oMatrix.Columns.Item("Col_14").DataBind.Bind("DT_2", "Mes 5");
                oMatrix.Columns.Item("Col_15").DataBind.Bind("DT_2", "Mes 4");
                oMatrix.Columns.Item("Col_16").DataBind.Bind("DT_2", "Mes 3");
                oMatrix.Columns.Item("Col_17").DataBind.Bind("DT_2", "Mes 2");
                oMatrix.Columns.Item("Col_18").DataBind.Bind("DT_2", "Mes 1");
                oMatrix.Columns.Item("Col_19").DataBind.Bind("DT_2", "6 Meses");
                oMatrix.Columns.Item("Col_20").DataBind.Bind("DT_2", "4 Meses");
                oMatrix.Columns.Item("Col_21").DataBind.Bind("DT_2", "2 Meses");
                oMatrix.Columns.Item("Col_22").DataBind.Bind("DT_2", "Venta");
                oMatrix.Columns.Item("Col_23").DataBind.Bind("DT_2", "Pareto");
                oMatrix.Columns.Item("Col_24").DataBind.Bind("DT_2", "Categoria");
                oMatrix.Columns.Item("Col_25").DataBind.Bind("DT_2", "Función Lineal");
                oMatrix.Columns.Item("Col_26").DataBind.Bind("DT_2", "Función Exponencial");
                oMatrix.Columns.Item("Col_27").DataBind.Bind("DT_2", "Función Logaritmica");
                oMatrix.Columns.Item("Col_28").DataBind.Bind("DT_2", "Función Potencial");
                oMatrix.Columns.Item("Col_29").DataBind.Bind("DT_2", "Función Polinomica");
                oMatrix.Columns.Item("Col_30").DataBind.Bind("DT_2", "Función");
                oMatrix.Columns.Item("Col_31").DataBind.Bind("DT_2", "Pronostico");
                oMatrix.Columns.Item("Col_35").DataBind.Bind("DT_2", "Stock");

            oMatrix.Columns.Item("Col_33").DataBind.Bind("DT_2", "Limite Superior");
                oMatrix.Columns.Item("Col_32").DataBind.Bind("DT_2", "Requerimiento");
                oMatrix.Columns.Item("Col_34").DataBind.Bind("DT_2", "Limite Inferior");


            oMatrix.Columns.Item("Col_1").LinkedObjectType(oMatrix,"Articulo","4");
                oMatrix.Columns.Item("Col_1").RightJustified = true;
                oMatrix.Columns.Item("Col_3").RightJustified = true;
                oMatrix.Columns.Item("Col_5").RightJustified = true;
                oMatrix.Columns.Item("Col_6").RightJustified = true;
                oMatrix.Columns.Item("Col_7").RightJustified = true;
                oMatrix.Columns.Item("Col_8").RightJustified = true;
                oMatrix.Columns.Item("Col_9").RightJustified = true;
                oMatrix.Columns.Item("Col_10").RightJustified = true;
                oMatrix.Columns.Item("Col_11").RightJustified = true;
                oMatrix.Columns.Item("Col_12").RightJustified = true;
                oMatrix.Columns.Item("Col_13").RightJustified = true;
                oMatrix.Columns.Item("Col_14").RightJustified = true;
                oMatrix.Columns.Item("Col_15").RightJustified = true;
                oMatrix.Columns.Item("Col_16").RightJustified = true;
                oMatrix.Columns.Item("Col_17").RightJustified = true;
                oMatrix.Columns.Item("Col_18").RightJustified = true;
                oMatrix.Columns.Item("Col_19").RightJustified = true;
                oMatrix.Columns.Item("Col_20").RightJustified = true;
                oMatrix.Columns.Item("Col_21").RightJustified = true;
                oMatrix.Columns.Item("Col_22").RightJustified = true;
                oMatrix.Columns.Item("Col_25").RightJustified = true;
                oMatrix.Columns.Item("Col_26").RightJustified = true;
                oMatrix.Columns.Item("Col_27").RightJustified = true;
                oMatrix.Columns.Item("Col_28").RightJustified = true;
                oMatrix.Columns.Item("Col_29").RightJustified = true;
                oMatrix.Columns.Item("Col_31").RightJustified = true;
                oMatrix.Columns.Item("Col_32").RightJustified = true;
            oMatrix.Columns.Item("Col_34").RightJustified = true;
            oMatrix.Columns.Item("Col_33").RightJustified = true;
            oMatrix.Columns.Item("Col_35").RightJustified = true;



            oMatrix.Columns.Item("Col_19").Visible = false;
                oMatrix.Columns.Item("Col_20").Visible = false;
                oMatrix.Columns.Item("Col_21").Visible = false;
                oMatrix.Columns.Item("Col_22").Visible = false;
                oMatrix.Columns.Item("Col_23").Visible = false;

            // oMatrix.Columns.Item("Col_33").Visible = false;
            // oMatrix.Columns.Item("Col_34").Visible = false;

            DateTime fechaActual = DateTime.Today;
            DateTime primerDiaMesActual_1 = new DateTime(fechaActual.Year, fechaActual.Month, 1);
            DateTime ultimoDiaMesAnterior_1 = primerDiaMesActual_1.AddDays(-1);
            oMatrix.Columns.Item("Col_18").TitleObject.Caption = ultimoDiaMesAnterior_1.ToString("MMMM") + "-" + ultimoDiaMesAnterior_1.ToString("yy");


            DateTime primerDiaMesHaceDosMeses = primerDiaMesActual_1.AddMonths(-2);
            DateTime ultimoDiaMesHaceDosMeses = primerDiaMesHaceDosMeses.AddMonths(1).AddDays(-1);
            oMatrix.Columns.Item("Col_17").TitleObject.Caption = ultimoDiaMesHaceDosMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceDosMeses.ToString("yy");

            DateTime primerDiaMesHaceTresMeses = primerDiaMesActual_1.AddMonths(-3);
            DateTime ultimoDiaMesHaceTresMeses = primerDiaMesHaceTresMeses.AddMonths(1).AddDays(-1);
            oMatrix.Columns.Item("Col_16").TitleObject.Caption = ultimoDiaMesHaceTresMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceTresMeses.ToString("yy");

            DateTime primerDiaMesHaceCuatroMeses = primerDiaMesActual_1.AddMonths(-4);
            DateTime ultimoDiaMesHaceCuatroMeses = primerDiaMesHaceCuatroMeses.AddMonths(1).AddDays(-1);
            oMatrix.Columns.Item("Col_15").TitleObject.Caption = ultimoDiaMesHaceCuatroMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceCuatroMeses.ToString("yy");

            DateTime primerDiaMesHaceQuintoMeses = primerDiaMesActual_1.AddMonths(-5);
            DateTime ultimoDiaMesHaceQuintoMeses = primerDiaMesHaceQuintoMeses.AddMonths(1).AddDays(-1);
            oMatrix.Columns.Item("Col_14").TitleObject.Caption = ultimoDiaMesHaceQuintoMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceQuintoMeses.ToString("yy");

            DateTime primerDiaMesHaceSextoMeses = primerDiaMesActual_1.AddMonths(-6);
            DateTime ultimoDiaMesHaceSextoMeses = primerDiaMesHaceSextoMeses.AddMonths(1).AddDays(-1);
            oMatrix.Columns.Item("Col_13").TitleObject.Caption = ultimoDiaMesHaceSextoMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceSextoMeses.ToString("yy");

            DateTime primerDiaMesHaceSeptimoMeses = primerDiaMesActual_1.AddMonths(-7);
            DateTime ultimoDiaMesHaceSeptimoMeses = primerDiaMesHaceSeptimoMeses.AddMonths(1).AddDays(-1);
            oMatrix.Columns.Item("Col_12").TitleObject.Caption = ultimoDiaMesHaceSeptimoMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceSeptimoMeses.ToString("yy");

            DateTime primerDiaMesHaceOctavoMeses = primerDiaMesActual_1.AddMonths(-8);
            DateTime ultimoDiaMesHaceOctavoMeses = primerDiaMesHaceOctavoMeses.AddMonths(1).AddDays(-1);
            oMatrix.Columns.Item("Col_11").TitleObject.Caption = ultimoDiaMesHaceOctavoMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceOctavoMeses.ToString("yy");

            DateTime primerDiaMesHaceNovenoMeses = primerDiaMesActual_1.AddMonths(-9);
            DateTime ultimoDiaMesHaceNovenoMeses = primerDiaMesHaceNovenoMeses.AddMonths(1).AddDays(-1);
            oMatrix.Columns.Item("Col_10").TitleObject.Caption = ultimoDiaMesHaceNovenoMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceNovenoMeses.ToString("yy");

            DateTime primerDiaMesHaceDecimoMeses = primerDiaMesActual_1.AddMonths(-10);
            DateTime ultimoDiaMesHaceDecimoMeses = primerDiaMesHaceDecimoMeses.AddMonths(1).AddDays(-1);
            oMatrix.Columns.Item("Col_9").TitleObject.Caption = ultimoDiaMesHaceDecimoMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceDecimoMeses.ToString("yy");

            DateTime primerDiaMesHaceDecimo_UnoMeses = primerDiaMesActual_1.AddMonths(-11);
            DateTime ultimoDiaMesHaceDecimo_UnoMeses = primerDiaMesHaceDecimo_UnoMeses.AddMonths(1).AddDays(-1);
            oMatrix.Columns.Item("Col_8").TitleObject.Caption = ultimoDiaMesHaceDecimo_UnoMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceDecimo_UnoMeses.ToString("yy");

            DateTime primerDiaMesHaceDecimo_DosMeses = primerDiaMesActual_1.AddMonths(-12);
            DateTime ultimoDiaMesHaceDecimo_DosMeses = primerDiaMesHaceDecimo_DosMeses.AddMonths(1).AddDays(-1);
            oMatrix.Columns.Item("Col_7").TitleObject.Caption = ultimoDiaMesHaceDecimo_DosMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceDecimo_DosMeses.ToString("yy");

            DateTime primerDiaMesHaceDecimo_TresMeses = primerDiaMesActual_1.AddMonths(-13);
            DateTime ultimoDiaMesHaceDecimo_TresMeses = primerDiaMesHaceDecimo_TresMeses.AddMonths(1).AddDays(-1);
            oMatrix.Columns.Item("Col_6").TitleObject.Caption = ultimoDiaMesHaceDecimo_TresMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceDecimo_TresMeses.ToString("yy");

            DateTime primerDiaMesHaceDecimo_CuatroMeses = primerDiaMesActual_1.AddMonths(-14);
            DateTime ultimoDiaMesHaceDecimo_CuatroMeses = primerDiaMesHaceDecimo_CuatroMeses.AddMonths(1).AddDays(-1);
            oMatrix.Columns.Item("Col_5").TitleObject.Caption = ultimoDiaMesHaceDecimo_CuatroMeses.ToString("MMMM") + "-" + ultimoDiaMesHaceDecimo_CuatroMeses.ToString("yy");

            oColumn = oColumns.Item("Col_0");
            oMatrix.LoadFromDataSource();
            oMatrix.AutoResizeColumns();
            oForm.Freeze(false);
        }
        

        public void ExecuteQueryRecorsed(Recordset recordset, string Query)
        {
            try
            {

            string StrHANA = Query;
            recordset.DoQuery(StrHANA);
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }

        public Forecast_Hist_C ConstruirForecast(Grid Grid,int CodUser,string NombreUsuario,string PuntoEmision,string FechaDocumento,string TipoGerencia,string Periodo)
        {
            Forecast_Hist_C Obj_Forecast_Hist_C = new Forecast_Hist_C();
                Obj_Forecast_Hist_C.U_USER_CODE = CodUser;
                Obj_Forecast_Hist_C.U_NAME = NombreUsuario;
                Obj_Forecast_Hist_C.U_SYP_NDED = PuntoEmision;
                Obj_Forecast_Hist_C.U_TaxDate = FechaDocumento;
                Obj_Forecast_Hist_C.U_TipoGerencia = TipoGerencia;
                Obj_Forecast_Hist_C.Period = Periodo;
                Obj_Forecast_Hist_C.VIS_FRC1Collection = GetDetalleForecast(Grid);
                return Obj_Forecast_Hist_C;
           
        }

        public List<Forecast_Hist_D> GetDetalleForecast(Grid Grid)
        {
            List<Forecast_Hist_D> Obj_ListForecast = new List<Forecast_Hist_D>();
            try
            {
                for (int oRows = 0; oRows < Grid.Rows.Count; oRows++)
                {
                    if (Convert.ToInt32(Grid.DataTable.GetString("Requerimiento", oRows).ToString())>0)
                    {
                    Forecast_Hist_D Obj_Forecast_Hist_D = new Forecast_Hist_D();
                    Obj_Forecast_Hist_D.U_ItemCode = Grid.DataTable.GetString("ARTICULO", oRows).ToString();
                    Obj_Forecast_Hist_D.U_Dscription = Grid.DataTable.GetString("DESCRIPCION", oRows).ToString();
                    Obj_Forecast_Hist_D.U_VIS_Gal = Convert.ToInt32(Grid.DataTable.GetString("GAL_SKU", oRows).ToString());
                    Obj_Forecast_Hist_D.U_Func_Lineal = Convert.ToInt32(Grid.DataTable.GetString("Funcion Lineal", oRows).ToString());
                    Obj_Forecast_Hist_D.U_Func_Exponencial = Convert.ToInt32(Grid.DataTable.GetString("Exponencial", oRows).ToString());
                    Obj_Forecast_Hist_D.U_Func_Logaritmico = Convert.ToInt32(Grid.DataTable.GetString("Logaritmico", oRows).ToString());
                    Obj_Forecast_Hist_D.U_Func_Potencial = Convert.ToInt32(Grid.DataTable.GetString("Potencial", oRows).ToString());
                    Obj_Forecast_Hist_D.U_Func_Polinomica = Convert.ToInt32(Grid.DataTable.GetString("Polinomica", oRows).ToString());
                    Obj_Forecast_Hist_D.U_Func_Aplicada = Grid.DataTable.GetString("Funcion", oRows).ToString();
                    Obj_Forecast_Hist_D.U_Pronostico = Convert.ToInt32(Grid.DataTable.GetString("Pronostico", oRows).ToString());
                    Obj_Forecast_Hist_D.U_Ult_Mes_Hist = Convert.ToInt32(Grid.DataTable.GetString("Mes 1", oRows).ToString());
                    Obj_Forecast_Hist_D.U_VIS_Req = Convert.ToInt32(Grid.DataTable.GetString("Requerimiento", oRows).ToString());
                        Obj_ListForecast.Add(Obj_Forecast_Hist_D);
                }
            }
                return Obj_ListForecast;
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
                return null;
            }
        }

        public Forecast_Hist_C ConstruirForecastV2(Matrix oMatrix, int CodUser, string NombreUsuario, string PuntoEmision, string FechaDocumento, string TipoGerencia, string Periodo)
        {
            Forecast_Hist_C Obj_Forecast_Hist_C = new Forecast_Hist_C();
            Obj_Forecast_Hist_C.U_USER_CODE = CodUser;
            Obj_Forecast_Hist_C.U_NAME = NombreUsuario;
            Obj_Forecast_Hist_C.U_SYP_NDED = PuntoEmision;
            Obj_Forecast_Hist_C.U_TaxDate = FechaDocumento;
            Obj_Forecast_Hist_C.U_TipoGerencia = TipoGerencia;
            Obj_Forecast_Hist_C.Period = Periodo;
            Obj_Forecast_Hist_C.VIS_FRC1Collection = GetDetalleForecastV2(oMatrix);
            return Obj_Forecast_Hist_C;
        }
        public List<Forecast_Hist_D> GetDetalleForecastV2(Matrix oMatrix)
        {
            List<Forecast_Hist_D> Obj_ListForecast = new List<Forecast_Hist_D>();
            try
            {
                for (int oRows = 0; oRows < oMatrix.RowCount; oRows++)
                {
                    if (Convert.ToInt32(oMatrix.GetValueFromEditText("Col_32", oRows+1).ToString()) > 0)
                    {
                        Forecast_Hist_D Obj_Forecast_Hist_D = new Forecast_Hist_D();
                        Obj_Forecast_Hist_D.U_ItemCode = oMatrix.GetValueFromEditText("Col_1", oRows+1).ToString();
                        Obj_Forecast_Hist_D.U_Dscription = oMatrix.GetValueFromEditText("Col_2", oRows+1).ToString();
                        Obj_Forecast_Hist_D.U_VIS_Gal = Convert.ToDouble(oMatrix.GetValueFromEditText("Col_3", oRows+1).ToString());
                        Obj_Forecast_Hist_D.U_Func_Lineal = Convert.ToInt32(oMatrix.GetValueFromEditText("Col_25", oRows + 1).ToString());
                        Obj_Forecast_Hist_D.U_Func_Exponencial = Convert.ToInt32(oMatrix.GetValueFromEditText("Col_26", oRows + 1).ToString());
                        Obj_Forecast_Hist_D.U_Func_Logaritmico = Convert.ToInt32(oMatrix.GetValueFromEditText("Col_27", oRows + 1).ToString());
                        Obj_Forecast_Hist_D.U_Func_Potencial = Convert.ToInt32(oMatrix.GetValueFromEditText("Col_28", oRows + 1).ToString());
                        Obj_Forecast_Hist_D.U_Func_Polinomica = Convert.ToInt32(oMatrix.GetValueFromEditText("Col_29", oRows + 1).ToString());
                        Obj_Forecast_Hist_D.U_Func_Aplicada = oMatrix.GetValueFromEditText("Col_30", oRows + 1).ToString();
                        Obj_Forecast_Hist_D.U_Pronostico = Convert.ToInt32(oMatrix.GetValueFromEditText("Col_31", oRows + 1).ToString());
                        Obj_Forecast_Hist_D.U_Ult_Mes_Hist = Convert.ToInt32(oMatrix.GetValueFromEditText("Col_18", oRows + 1).ToString());
                        Obj_Forecast_Hist_D.U_VIS_Req = Convert.ToInt32(oMatrix.GetValueFromEditText("Col_32", oRows + 1).ToString());
                        Obj_Forecast_Hist_D.U_Stock = Convert.ToInt32(oMatrix.GetValueFromEditText("Col_35", oRows + 1).ToString());
                        Obj_ListForecast.Add(Obj_Forecast_Hist_D);
                    }
                }
                return Obj_ListForecast;
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
                return Obj_ListForecast;
            }
        }
        /*INICIO GUARDAR EN EL UDO TIPO DOCUMENTO */
        public void Procesar(SAPbouiCOM.Grid Grid, int CodUser, string NombreUsuario, string PuntoEmision, string FechaDocumento, string TipoGerencia,string Periodo)
        {
            try
            {
                Forxap.Framework.UI.Sb1Messages.ShowWarning("Procesando...");
                Forecast_Hist_C ObjForecast = ConstruirForecast(Grid, CodUser, NombreUsuario, PuntoEmision, FechaDocumento, TipoGerencia, Periodo);
                string ObjForecastJson = JsonConvert.SerializeObject(ObjForecast);

                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic response;
                response = methods.POST("OFRC", ObjForecastJson);
                dynamic json2 = JsonConvert.DeserializeObject(response.Content.ToString());
                if (response.StatusCode.ToString() == "Created")
                {
                    Forxap.Framework.UI.Sb1Messages.ShowSuccess("Se guardo Historial Forecast");
                }
                else
                {
                    Forxap.Framework.UI.Sb1Messages.ShowError(response.Content.ToString());
                }
                
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
                Forxap.Framework.UI.Sb1Messages.ShowWarning("Procesando...");
                Forecast_Hist_C ObjForecast = ConstruirForecastV2(oMatrix, CodUser, NombreUsuario, PuntoEmision, FechaDocumento, TipoGerencia, Periodo);
                string ObjForecastJson = JsonConvert.SerializeObject(ObjForecast);

                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic response;
                Forxap.Framework.UI.Sb1Messages.ShowWarning("Procesando...");
                response = methods.POST("OFRC", ObjForecastJson);
                dynamic json2 = JsonConvert.DeserializeObject(response.Content.ToString());
                if (response.StatusCode.ToString() == "Created")
                {
                    Forxap.Framework.UI.Sb1Messages.ShowSuccess("Se guardo el Forecast");
                    Button4.Item.Enabled = true;
                }
                else
                {
                    Forxap.Framework.UI.Sb1Messages.ShowError(response.Content.ToString());
                }

            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }

        }
        /*FIN GUARDAR EN EL UDO TIPO DOCUMENTO */
        public void GetClusterSucursales(Form oForm,Recordset recordSet,Grid Grid0, ComboBox ComboBox0,string Sucursal,
            string QueryGetPlanning,string QueryGetPlanningSelect,string QueryGetPlanningClear)
        {
            try
            {
                Forxap.Framework.UI.Sb1Messages.ShowWarning("Iniciando Consulta");
               // oForm.Freeze(true);

                try
                {
                   // Grid0.DataTable.Clear();
                    SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
                    if (ComboBox0.Value == "1")
                    {
                        for (int ListSucursal = 0; ListSucursal < ComboBox0.ValidValues.Count; ListSucursal++)
                        {
                            ComboBox0.Select(ListSucursal, SAPbouiCOM.BoSearchKey.psk_Index);
                            Sucursal = ComboBox0.GetSelectedDescription();
                            if (Sucursal != "1")
                            {
                              ExecuteQueryRecorsed(recordSet, string.Format(QueryGetPlanning, ComboBox0.GetSelectedDescription(),ComboBox0.Value));
                                Forxap.Framework.UI.Sb1Messages.ShowSuccess("Generando consulta.....");
                            }
                        }

                        ExecuteQueryDataTable(ref oDT,QueryGetPlanningSelect);
                        ComboBox0.Select(1, SAPbouiCOM.BoSearchKey.psk_Index);
                        Grid0.Sortable();
                        Grid0.ReadOnlyColumns();
                        Grid0.AutoResizeColumns();
                        Grid0.Columns.Item("Articulo").LinkedObjectType(Grid0, "Articulo", "4");

                        Grid0.Columns.Item("Articulo").RightJustified = true;
                        Grid0.Columns.Item("Pareto").RightJustified = true;
                        Grid0.Columns.Item("Total sin Impuesto").RightJustified = true;
                        Grid0.Columns.Item("Costo Total").RightJustified = true;
                        Grid0.Columns.Item("Margen").RightJustified = true;
                        Grid0.Columns.Item("Fila").RightJustified = true;

                    }
                    else
                    {

                      //  ExecuteQueryRecorsed(recordSet, string.Format(QueryGetPlanning, ComboBox0.Value, ""));
                        ExecuteQueryDataTable(ref oDT,string.Format("CALL P_VIST_PLANNING_PLANEAMIENTO_X_SUCURSAL('{0}', '{1}')", ComboBox0.GetSelectedDescription(), ComboBox0.Value));
                        if (oDT.Rows.Count>0)
                        {
                            Grid0.Sortable();
                            Grid0.ReadOnlyColumns();
                            Grid0.AutoResizeColumns();
                            Grid0.Columns.Item("Articulo").LinkedObjectType(Grid0, "Articulo", "4");
                            Grid0.Columns.Item("Total sin Impuesto").RightJustified = true;
                            Grid0.Columns.Item("Costo Total").RightJustified = true;
                            Grid0.Columns.Item("Articulo").RightJustified = true;
                            Grid0.Columns.Item("Margen").RightJustified = true;
                            Grid0.Columns.Item("Pareto").RightJustified = true;
                            Grid0.Columns.Item("Fila").RightJustified = true;
                            Grid0.Columns.Item("Stock").RightJustified = true;

                        }

                            Grid0.Columns.Item("Pareto").Visible = false;
                            Grid0.Columns.Item("Total sin Impuesto").Visible = false;
                            Grid0.Columns.Item("Total sin Impuesto").Visible = false;
                            Grid0.Columns.Item("Costo Total").Visible = false;
                            Grid0.Columns.Item("Margen").Visible = false;
                            Grid0.Columns.Item("Categoria").TitleObject.Caption = "Galones Pareto";
                        Grid0.AutoResizeColumns();


                    }

                    Forxap.Framework.UI.Sb1Messages.ShowSuccess("Consulta Terminada");

                    ExecuteQueryRecorsed(recordSet, QueryGetPlanningClear);
                }
                catch (Exception ex)
                {
                    Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
                }
                finally
                {
                 //   oForm.Freeze(false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void GetClusterSucursalesBO(Form oForm, DataTable oDT, Grid Grid0, ComboBox ComboBox0, string QueryGetPlanning)
        {
            try
            {
                Forxap.Framework.UI.Sb1Messages.ShowWarning("Iniciando Consulta");
                 oForm.Freeze(true);

                try
                {
                    
                        ExecuteQueryDataTable(ref oDT, string.Format(QueryGetPlanning, ComboBox0.Value, ""));
                        if (oDT.Rows.Count > 0)
                        {
                            Grid0.Sortable();
                            Grid0.ReadOnlyColumns();
                            Grid0.AutoResizeColumns();
                            Grid0.Columns.Item("Articulo").LinkedObjectType(Grid0, "Articulo", "4");
                            Grid0.Columns.Item("Total sin Impuesto").RightJustified = true;
                            Grid0.Columns.Item("Costo Total").RightJustified = true;
                            Grid0.Columns.Item("Articulo").RightJustified = true;
                            Grid0.Columns.Item("Margen").RightJustified = true;
                            Grid0.Columns.Item("Pareto").RightJustified = true;
                            Grid0.Columns.Item("Fila").RightJustified = true;
                        }
                    Forxap.Framework.UI.Sb1Messages.ShowSuccess("Consulta Terminada");
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
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        public void GetClusterLima(Form oForm,string Query,Grid Grid1)
        {
            Forxap.Framework.UI.Sb1Messages.ShowWarning("Iniciando Consulta");

            oForm.Freeze(true);
            Grid1.DataTable.Clear();
            try
            {
                SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
                ExecuteQueryDataTable(ref oDT, Query);
                if (oDT.Rows.Count > 0)
                {
                    Grid1.Sortable();
                    Grid1.ReadOnlyColumns();
                    Grid1.AutoResizeColumns();
                    Grid1.Columns.Item("Articulo").LinkedObjectType(Grid1, "Articulo", "4");
                    Grid1.Columns.Item("Articulo").RightJustified = true;
                    Grid1.Columns.Item("Fila").RightJustified = true;
                    Grid1.Columns.Item("Pareto").RightJustified = true;

                    Grid1.Columns.Item("Total sin Impuesto").RightJustified = true;


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
                Forxap.Framework.UI.Sb1Messages.ShowSuccess("Consulta Terminada");
            }
        }

        /*INICIO - CUANDO ESCRIBA EN LA CAJA DE TEXTO Y ENCUENTRA EL VALOR SE SELECCIONARA AUTORIMATICAMNETE EL VALOR */
        public void FindText(SAPbouiCOM.SBOItemEventArg pVal, int filaseleccionada, EditText EditText7, Grid Grid1,string NombCol)
        {
            string textoFind = string.Empty;
            string docNum = string.Empty;

            try
            {
                textoFind = EditText7.Value.Trim();
                if (textoFind.Length>=6)
                {
                if (pVal.CharPressed != 13)
                {
                    for (int row = 0; row <= Grid1.Rows.Count - 1; row++)
                    {
                        docNum = Grid1.DataTable.GetString(NombCol, row);
                        if (docNum == textoFind)
                        {
                            Grid1.Rows.SelectedRows.Clear();
                            Grid1.Rows.SelectedRows.Add(row);
                            filaseleccionada = row;
                            return;
                        }
                    }
                }
                else
                {
                    if (filaseleccionada != -1)
                    {
                        if (Grid1.DataTable.GetValue(0, filaseleccionada).ToString() != "Y")
                        {
                            Grid1.DataTable.SetValue(0, filaseleccionada, "Y");
                        }
                        else
                        {
                            Grid1.DataTable.SetValue(0, filaseleccionada, "N");
                        }
                    }
                }
            }
            }
            catch
            {

            }
        }
        /*FIN - CUANDO ESCRIBA EN LA CAJA DE TEXTO Y ENCUENTRA EL VALOR SE SELECCIONARA AUTORIMATICAMNETE EL VALOR */

       public DraftSolicitudTraslado ConstruirDraftST(Matrix oMatrix, string DocDate, string DueDate, string JournalMemo, string FromWarehouse, string ToWarehouse,
         string DocObjectCode, string TaxDate, string U_SYP_MDMT, string U_SYP_SOLICITANTE)
        {
            DraftSolicitudTraslado Obj_DraftSolicitudTraslado = new DraftSolicitudTraslado();
            Obj_DraftSolicitudTraslado.DocDate = DocDate;
            Obj_DraftSolicitudTraslado.DueDate = DueDate;
            Obj_DraftSolicitudTraslado.JournalMemo = JournalMemo;
            Obj_DraftSolicitudTraslado.FromWarehouse = FromWarehouse;
            Obj_DraftSolicitudTraslado.ToWarehouse = ToWarehouse;
            Obj_DraftSolicitudTraslado.DocObjectCode = DocObjectCode;
            Obj_DraftSolicitudTraslado.TaxDate = TaxDate;
            Obj_DraftSolicitudTraslado.U_SYP_MDMT = U_SYP_MDMT;
            Obj_DraftSolicitudTraslado.U_SYP_SOLICITANTE = U_SYP_SOLICITANTE;
            Obj_DraftSolicitudTraslado.StockTransferLines = GetDetalleST(oMatrix, FromWarehouse, ToWarehouse);
            return Obj_DraftSolicitudTraslado;
        }
        public List<StockTransferLine> GetDetalleST(Matrix oMatrix, string FromWarehouse, string ToWarehouse)
        {
            List<StockTransferLine> Obj_ListStockTransferLine = new List<StockTransferLine>();
            int Linea = 0;
            try
            {
                for (int oRows = 0; oRows < oMatrix.RowCount; oRows++)
                {
                    if (Convert.ToInt32(oMatrix.GetValueFromEditText("Col_32", oRows + 1).ToString()) > 0)
                    {
                        StockTransferLine Obj_StockTransfer = new StockTransferLine();
                        Obj_StockTransfer.LineNum = Linea;
                        Obj_StockTransfer.ItemCode = oMatrix.GetValueFromEditText("Col_1", oRows + 1).ToString();
                        Obj_StockTransfer.ItemDescription = oMatrix.GetValueFromEditText("Col_2", oRows + 1).ToString();
                        Obj_StockTransfer.Quantity = Convert.ToDouble(oMatrix.GetValueFromEditText("Col_32", oRows + 1).ToString());
                        Obj_StockTransfer.WarehouseCode = ToWarehouse;//FALTA
                        Obj_StockTransfer.FromWarehouseCode = FromWarehouse;//FALTA
                        Obj_StockTransfer.U_QtySugerida = Convert.ToDouble(oMatrix.GetValueFromEditText("Col_31", oRows + 1).ToString());
                        Obj_ListStockTransferLine.Add(Obj_StockTransfer);
                        Linea++;
                    }
                }
                return Obj_ListStockTransferLine;
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
                return null;
            }
        }
        public void GenerarDraftST(Matrix oMatrix,string DocDate,string DueDate,string JournalMemot,string FromWarehouse,string ToWarehouse,
         string DocObjectCode,string TaxDate, string U_SYP_MDMT, string U_SYP_SOLICITANTE)
        {

            try
            {
                Forxap.Framework.UI.Sb1Messages.ShowWarning("Generando Solicitud de Traslado...");
                DraftSolicitudTraslado ObjDraftSolicitudTraslado = ConstruirDraftST(oMatrix,DocDate,DueDate,JournalMemot,
                    FromWarehouse,ToWarehouse,DocObjectCode,TaxDate,U_SYP_MDMT,U_SYP_SOLICITANTE);
                string ObjForecastJson = JsonConvert.SerializeObject(ObjDraftSolicitudTraslado);

                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic response;
                response = methods.POST("StockTransferDrafts", ObjForecastJson);
                dynamic json2 = JsonConvert.DeserializeObject(response.Content.ToString());
                if (response.StatusCode.ToString() == "Created")
                {
                    Forxap.Framework.UI.Sb1Messages.ShowSuccess("Se genero la Solicitud de Traslado como documento borrador");
                }
                else
                {
                    Forxap.Framework.UI.Sb1Messages.ShowError(response.Content.ToString());
                }

            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }

        public PurchaseOrders ConstruirPedido(Matrix oMatrix, int SalesPersonCode, int DocumentsOwner,string NombreSolicitante)
        {
            PurchaseOrders Obj_PurchaseOrders = new PurchaseOrders();
            Obj_PurchaseOrders.DocDate = DateTime.Now.ToString("yyyyMMdd");
            Obj_PurchaseOrders.DocDueDate= DateTime.Now.ToString("yyyyMMdd");
            Obj_PurchaseOrders.CardCode = "P20102306598";
            Obj_PurchaseOrders.Comments = "Pedido Generado por SCM - " + NombreSolicitante;
            Obj_PurchaseOrders.SalesPersonCode = SalesPersonCode;
            Obj_PurchaseOrders.DocumentsOwner = DocumentsOwner;
            Obj_PurchaseOrders.DocumentLines = GetDetalleDocumentLine(oMatrix);
            return Obj_PurchaseOrders;
        }
        public List<DocumentLine> GetDetalleDocumentLine(Matrix oMatrix)
        {
            List<DocumentLine> Obj_ListDocumentLine = new List<DocumentLine>();
            int Linea = 0;
            try
            {
                for (int oRows = 0; oRows < oMatrix.RowCount; oRows++)
                {
                    if (Convert.ToInt32(oMatrix.GetValueFromEditText("Col_32", oRows + 1).ToString()) > 0)
                    {
                        DocumentLine Obj_DocumentLine = new DocumentLine();
                        Obj_DocumentLine.LineNum = Linea;
                        Obj_DocumentLine.ItemCode = oMatrix.GetValueFromEditText("Col_1", oRows + 1).ToString();
                        Obj_DocumentLine.ItemDescription = oMatrix.GetValueFromEditText("Col_2", oRows + 1).ToString();
                        Obj_DocumentLine.Quantity = Convert.ToDouble(oMatrix.GetValueFromEditText("Col_32", oRows + 1).ToString());
                        Obj_DocumentLine.Price = Convert.ToDouble(oMatrix.GetValueFromEditText("Col_33", oRows + 1).ToString());
                        Obj_DocumentLine.WarehouseCode = oMatrix.GetValueFromEditText("Col_34", oRows + 1).ToString();
                        Obj_ListDocumentLine.Add(Obj_DocumentLine);
                        Linea++;
                    }
                }
                return Obj_ListDocumentLine;
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
                return null;
            }
        }


        public void GenerarPedido(Matrix oMatrix,int SalesPersonCode,int DocumentsOwner, string NombreSolicitante)
        {

            try
            {
                Forxap.Framework.UI.Sb1Messages.ShowWarning("Generando Pedido...");
                PurchaseOrders ObjPurchaseOrders = ConstruirPedido(oMatrix, SalesPersonCode, DocumentsOwner, NombreSolicitante);
                string ObjForecastJson = JsonConvert.SerializeObject(ObjPurchaseOrders);

                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic response;
                response = methods.POST("PurchaseOrders", ObjForecastJson);
                dynamic json2 = JsonConvert.DeserializeObject(response.Content.ToString());
                if (response.StatusCode.ToString() == "Created")
                {
                    Forxap.Framework.UI.Sb1Messages.ShowSuccess("Se genero el pedido como documento borrador");
                }
                else
                {
                    Forxap.Framework.UI.Sb1Messages.ShowError(response.Content.ToString());
                }

            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
    }
}
