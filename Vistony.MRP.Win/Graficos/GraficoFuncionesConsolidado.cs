using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Vistony.MRP.Win.Graficos
{
    public partial class GraficoFuncionesConsolidado : Form
    {
        double[] y = new double[] { };
        double Suma_xy_Lineal;
        double Sum_Y_Lineal;
        double Sum_X_Lineal;
        double SumX2_Lineal;
        double Xmedios_Lineal;
        double Ymedios_Lineal;
        double m_Lineal;
        double b_Lineal;
        
        double Sum_Yprima_Exponencial;
        double Sum_X_Exponencial;
        double SumX2_Exponencial;
        double Sum_XYprima_Exponencial;
        double Yprima_Exponencial = 0;
        double APrima_Exponencial;
        double a_Exponencial;
        double b_Exponencial;

        double Sum_Y_Logaritmica;
        double Sum_Xprima_Logaritmica;
        double Sum_XprimaY_Logaritmica;
        double Sum_Xprima2_Logaritmica;
        double b_Logaritmica;
        double a_Logaritmica;

        double Sum_Y_Potencial;
        double Sum_Xprima_Potencial;
        double Sum_Yprima_Potencial;
        double Sum_Xprima2_Potencial;
        double SUM_XprimaYprima_Potencial;
        double b_Potencial;
        double a_Potencial;
        double Aprima_Potencial;


        public void FuncionLineal(double[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                Suma_xy_Lineal += x[i] * y[i];
                Sum_Y_Lineal += y[i];
                Sum_X_Lineal += x[i];
                SumX2_Lineal += Math.Pow(x[i], 2);
            }

            Xmedios_Lineal = Sum_X_Lineal / x.Length;
            Ymedios_Lineal = Sum_Y_Lineal / y.Length;

            m_Lineal = (Suma_xy_Lineal - (x.Length * (Ymedios_Lineal * Xmedios_Lineal))) / (SumX2_Lineal - x.Length * Math.Pow(Xmedios_Lineal, 2));
            b_Lineal = Ymedios_Lineal - (m_Lineal * Xmedios_Lineal);

        }
        public void FuncionExponencial(double[] x)
        {
            // OBTENER EL XY
            for (int i = 0; i < y.Length; i++)
            {
                if (y[i] == 0)
                {
                    Yprima_Exponencial += 0;
                }
                else
                {
                    Yprima_Exponencial = (Math.Log10(y[i]) / Math.Log10(2.71828)); //LOGARITMICA EXPONENCIAL
                }

                Sum_X_Exponencial += x[i];
                Sum_Yprima_Exponencial += Yprima_Exponencial;
                Sum_XYprima_Exponencial += x[i] * Yprima_Exponencial;
                SumX2_Exponencial += Math.Pow(x[i], 2);
            }
            b_Exponencial = ((y.Length * Sum_XYprima_Exponencial) - (Sum_X_Exponencial * Sum_Yprima_Exponencial)) / ((y.Length * SumX2_Exponencial) - Math.Pow(Sum_X_Exponencial, 2));
            APrima_Exponencial = (Sum_Yprima_Exponencial / y.Length) - b_Exponencial * (Sum_X_Exponencial / y.Length);
            a_Exponencial = Math.Pow(2.71828, APrima_Exponencial);

        }
        public void FuncionLogaritmica(double[] x, List<double> List_X_Prima_Logaritmica, double[] X_Prima_Logaritmica)
        {
            for (int i = 0; i < y.Length; i++)
            {
                Sum_Y_Logaritmica += y[i];
                List_X_Prima_Logaritmica.Add(Math.Log10(x[i]) / Math.Log10(2.71828));
                X_Prima_Logaritmica = List_X_Prima_Logaritmica.ToArray();
                Sum_Xprima_Logaritmica += X_Prima_Logaritmica[i];
                Sum_XprimaY_Logaritmica += X_Prima_Logaritmica[i] * y[i];
                Sum_Xprima2_Logaritmica += Math.Pow(X_Prima_Logaritmica[i], 2);
            }

            b_Logaritmica = ((y.Length * Sum_XprimaY_Logaritmica) - (Sum_Xprima_Logaritmica * Sum_Y_Logaritmica)) /
               ((y.Length * Sum_Xprima2_Logaritmica) - Math.Pow(Sum_Xprima_Logaritmica, 2));

            a_Logaritmica = (Sum_Y_Logaritmica / y.Length) - b_Logaritmica * (Sum_Xprima_Logaritmica / y.Length);

        }
        public void FuncionPotencial(double[] x, List<double> List_Y_Prima_Potencial, double[] Y_Prima_Potencial, List<double> List_X_Prima_Potencial, double[] X_Prima_Potencial)
        {
            for (int i = 0; i < y.Length; i++)
            {
                Sum_Y_Potencial += y[i];
                if (y[i] == 0)
                {
                    List_Y_Prima_Potencial.Add(0);
                }
                else
                {
                    List_Y_Prima_Potencial.Add(Math.Log10(y[i]));
                }

                Y_Prima_Potencial = List_Y_Prima_Potencial.ToArray();

                if (x[i] == 0)
                {
                    List_X_Prima_Potencial.Add(0);
                }
                else
                {
                    List_X_Prima_Potencial.Add(Math.Log10(x[i]));
                }

                X_Prima_Potencial = List_X_Prima_Potencial.ToArray();

                Sum_Xprima_Potencial += X_Prima_Potencial[i];
                Sum_Yprima_Potencial += Y_Prima_Potencial[i];
                SUM_XprimaYprima_Potencial += X_Prima_Potencial[i] * Y_Prima_Potencial[i];
                Sum_Xprima2_Potencial += Math.Pow(X_Prima_Potencial[i], 2);

            }


            b_Potencial = ((y.Length * SUM_XprimaYprima_Potencial) - (Sum_Xprima_Potencial * Sum_Yprima_Potencial)) /
                ((y.Length * Sum_Xprima2_Potencial) - Math.Pow(Sum_Xprima_Potencial, 2));

            Aprima_Potencial = (Sum_Yprima_Potencial / y.Length) - b_Potencial * (Sum_Xprima_Potencial / y.Length);

            a_Potencial = Math.Pow(10, Aprima_Potencial);
        }

        public GraficoFuncionesConsolidado()
        {
            InitializeComponent();
        }
        public GraficoFuncionesConsolidado(List<double> List_V_y)
        {
            this.y = List_V_y.ToArray();
            // Crear un nuevo gráfico
            var chart = new Chart();
            chart.Dock = DockStyle.Fill;

            // Configuración del control Chart
            chart.BackColor = Color.WhiteSmoke;
            chart.BorderlineColor = Color.Gray;
            chart.BorderlineWidth = 1;
            chart.Titles.Add("Gráfico de función Consolidados");
            // Personalizar la leyenda
            chart.Legends.Add(new Legend("Leyenda"));
            chart.Legends[0].Docking = Docking.Bottom;  // Establecer posición de la leyenda

            chart.ChartAreas.Add(new ChartArea("FuncionConsolidado"));

            // Crear la serie de datos
            var serie = new Series("Valores");
            serie.Color = Color.Blue;
            serie.MarkerSize = 10;
            serie.MarkerStyle = MarkerStyle.Circle;
            serie.ChartType = SeriesChartType.Line;
            serie.BorderWidth = 3;  // Establecer ancho de la línea

            // Crear la serie de datos
            var serie2 = new Series("Función Lineal");
            serie2.Color = Color.Red;
            serie2.MarkerSize = 10;
            serie2.ChartType = SeriesChartType.Line;
            serie2.MarkerStyle = MarkerStyle.Circle;

            // Crear la serie de datos
            var serie3 = new Series("Función Exponencial");
            serie3.Color = Color.Black;
            serie3.MarkerSize = 10;
            serie3.ChartType = SeriesChartType.Line;
            serie3.MarkerStyle = MarkerStyle.Circle;

            // Crear la serie de datos
            var serie4 = new Series("Función Logarítmica");
            serie4.Color = Color.Gray;
            serie4.MarkerSize = 10;
            serie4.ChartType = SeriesChartType.Line;
            serie4.MarkerStyle = MarkerStyle.Circle;

            // Crear la serie de datos
            var serie5 = new Series("Función Potencial");
            serie5.Color = Color.Indigo;
            serie5.MarkerSize = 10;
            serie5.ChartType = SeriesChartType.Line;
            serie5.MarkerStyle = MarkerStyle.Circle;


            // Definir los valores de la función lineal
            double[] x = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }; // Valores de x
                                                                                         //double[] y = new double[] { 242,48,261,140,101,295,109,101,295,101,295,109}; ; // Valores de y
            List<double> List_Y_Result_Lineal = new List<double>();
            double[] Y_Result_Lineal = new double[] { };

            List<double> List_Y_Result_Exponencial = new List<double>();
            double[] Y_Result_Exponencial = new double[] { };

            List<double> List_X_Prima_Logaritmica = new List<double>();
            double[] X_Prima_Logaritmica = new double[] { };//EXPONENCIAL

            List<double> List_Y_Result_Logaritmica = new List<double>();
            double[] Y_Result_Logaritmica = new double[] { };

            List<double> List_Y_Prima_Potencial = new List<double>();
            double[] Y_Prima_Potencial = new double[] { };//EXPONENCIAL


            List<double> List_X_Prima_Potencial = new List<double>();
            double[] X_Prima_Potencial = new double[] { };//EXPONENCIAL

            List<double> List_Y_Result_Potencial = new List<double>();
            double[] Y_Result_Potencial = new double[] { };


            FuncionLineal(x);
            FuncionExponencial(x);
            FuncionLogaritmica(x, List_X_Prima_Logaritmica, X_Prima_Logaritmica);
            FuncionPotencial(x, List_Y_Prima_Potencial, Y_Prima_Potencial, List_X_Prima_Potencial, X_Prima_Potencial);
            // Crear una fuente personalizada para las etiquetas en negrita
            Font font = new Font("Arial", 10, FontStyle.Bold);

            for (int i = 0; i < x.Length; i++)
            {
                List_Y_Result_Lineal.Add(m_Lineal * x[i] + b_Lineal);

                List_Y_Result_Exponencial.Add(a_Exponencial * Math.Pow(2.71828, b_Exponencial * x[i]));

                List_Y_Result_Logaritmica.Add(a_Logaritmica + b_Logaritmica * (Math.Log10(x[i]) / Math.Log10(2.71828)));

                List_Y_Result_Potencial.Add(a_Potencial * Math.Pow(x[i], b_Potencial));
            }



            Y_Result_Lineal = List_Y_Result_Lineal.ToArray();
            Y_Result_Exponencial = List_Y_Result_Exponencial.ToArray();
            Y_Result_Logaritmica = List_Y_Result_Logaritmica.ToArray();
            Y_Result_Potencial = List_Y_Result_Potencial.ToArray();
            // Agregar los puntos a la serie de datos
            for (int i = 0; i < x.Length; i++)
            {
                DataPoint dataPoint = new DataPoint(x[i], y[i]);
                serie.Points.AddXY(x[i], y[i]);

                dataPoint.Label = Convert.ToString(y[i]);
                dataPoint.Font = font;
                dataPoint.LabelForeColor = Color.Blue;
                serie.Points.Add(dataPoint);

                DataPoint dataPoint2 = new DataPoint(x[i], Y_Result_Lineal[i]);
                dataPoint2.Label = Convert.ToString(Convert.ToInt32(Y_Result_Lineal[i]));
                dataPoint2.LabelForeColor = Color.Red;
                serie2.Points.Add(dataPoint2);

                DataPoint dataPoint3 = new DataPoint(x[i], Y_Result_Exponencial[i]);
                dataPoint3.Label = Convert.ToString(Convert.ToInt32(Y_Result_Exponencial[i]));
                dataPoint3.LabelForeColor = Color.Black;
                serie3.Points.Add(dataPoint3);

                  DataPoint dataPoint4 = new DataPoint(x[i], Y_Result_Logaritmica[i]);
                dataPoint4.Label = Convert.ToString(Convert.ToInt32(Y_Result_Logaritmica[i]));
                dataPoint4.LabelForeColor = Color.Gray;
                serie4.Points.Add(dataPoint4);

                DataPoint dataPoint5 = new DataPoint(x[i], Y_Result_Potencial[i]);
                dataPoint5.Label = Convert.ToString(Convert.ToInt32(Y_Result_Potencial[i]));
                dataPoint4.LabelForeColor = Color.Indigo;
                serie5.Points.Add(dataPoint5);
                serie5.Points.AddXY(x[i], Y_Result_Potencial[i]);
            }

            // Agregar la serie de datos al gráfico
            chart.Series.Add(serie);
            chart.Series.Add(serie2);
            chart.Series.Add(serie3);
            chart.Series.Add(serie4);
            chart.Series.Add(serie5);
            this.CenterToScreen();
            // Agregar el gráfico al formulario
            this.Controls.Add(chart);

        }
    }
}
