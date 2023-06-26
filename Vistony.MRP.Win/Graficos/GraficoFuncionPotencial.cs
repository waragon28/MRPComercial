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
    public partial class GraficoFuncionPotencial : Form
    {
        double[] y = new double[] { };
        public GraficoFuncionPotencial(List<double> List_V_y)
        {   //  if (comboBox1.Text=="Lineal")
            // {
            this.y = List_V_y.ToArray();
            // Crear un nuevo gráfico
            var chart = new Chart();
            chart.Dock = DockStyle.Fill;

            // Configuración del control Chart
            chart.BackColor = Color.WhiteSmoke;
            chart.BorderlineColor = Color.Gray;
            chart.BorderlineWidth = 1;
            chart.Titles.Add("Gráfico de función Potencial");
            // Personalizar la leyenda
            chart.Legends.Add(new Legend("Mi Leyenda"));
            chart.Legends[0].Docking = Docking.Bottom;  // Establecer posición de la leyenda

            chart.ChartAreas.Add(new ChartArea("FuncionPotencial"));

            // Crear la serie de datos
            var serie = new Series("Valores");
            serie.Color = Color.Blue;
            serie.MarkerSize = 10;
            serie.MarkerStyle = MarkerStyle.Circle;
            serie.ChartType = SeriesChartType.Line;
            serie.BorderWidth = 3;  // Establecer ancho de la línea

            // Crear la serie de datos
            var serie2 = new Series("Pendiente");
            serie2.Color = Color.Red;
            serie2.MarkerSize = 10;
            serie2.ChartType = SeriesChartType.Line;
            serie2.MarkerStyle = MarkerStyle.Circle;


            // Definir los valores de la función lineal
            double a = 0; // Pendiente
            double b = 0; // Intercepto
            double[] x = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }; // Valores de x
                                                                                         //double[] y = new double[] { 242,48,261,140,101,295,109,101,295,101,295,109}; ; // Valores de y
            double Sum_Y = 0;
            //double SumX2 = 0;
            List<double> List_Y_Result = new List<double>();
            double[] Y_Result = new double[] { };

            double Sum_Xprima2 = 0; //
            double Sum_Xprima = 0;  //
            double Sum_Yprima = 0;  //
            double Aprima = 0; //
            double SUM_XprimaYprima = 0;
            List<double> List_Y_Prima = new List<double>();
            double[] Y_Prima = new double[] { };//EXPONENCIAL

            List<double> List_X_Prima = new List<double>();
            double[] X_Prima = new double[] { };//EXPONENCIAL


            // OBTENER EL XY
            for (int i = 0; i < y.Length; i++)
            {
                Sum_Y += y[i];
                if (y[i] == 0)
                {
                    List_Y_Prima.Add(0);
                }
                else
                {
                    List_Y_Prima.Add(Math.Log10(y[i]));
                }

                Y_Prima = List_Y_Prima.ToArray();

                if (x[i] == 0)
                {
                    List_X_Prima.Add(0);
                }
                else
                {
                    List_X_Prima.Add(Math.Log10(x[i]));
                }

                X_Prima = List_X_Prima.ToArray();

                Sum_Xprima += X_Prima[i];
                Sum_Yprima += Y_Prima[i];
                SUM_XprimaYprima += X_Prima[i] * Y_Prima[i];
                Sum_Xprima2 += Math.Pow(X_Prima[i], 2);

            }


            b = ((y.Length * SUM_XprimaYprima) - (Sum_Xprima * Sum_Yprima)) /
                ((y.Length * Sum_Xprima2) - Math.Pow(Sum_Xprima, 2));

            Aprima = (Sum_Yprima / y.Length) - b * (Sum_Xprima / y.Length);

            a = Math.Pow(10, Aprima);

            // Crear una fuente personalizada para las etiquetas en negrita
            Font font = new Font("Arial", 10, FontStyle.Bold);

            for (int i = 0; i < x.Length; i++)
            {
                List_Y_Result.Add(a * Math.Pow(x[i], b));
            }



            Y_Result = List_Y_Result.ToArray();
            // Agregar los puntos a la serie de datos
            for (int i = 0; i < x.Length; i++)
            {
                DataPoint dataPoint = new DataPoint(x[i], y[i]);
                serie.Points.AddXY(x[i], y[i]);

                dataPoint.Label = Convert.ToString(y[i]);
                dataPoint.Font = font;
                serie.Points.Add(dataPoint);

                DataPoint dataPoint2 = new DataPoint(x[i], Y_Result[i]);
                dataPoint2.Label = Convert.ToString(Convert.ToInt32(Y_Result[i]));
                serie2.Points.Add(dataPoint2);
                serie2.Points.AddXY(x[i], Y_Result[i]);
            }

            // Agregar la serie de datos al gráfico
            chart.Series.Add(serie);
            chart.Series.Add(serie2);

            // Agregar el gráfico al formulario
            this.Controls.Add(chart);

            //}
        }
        public GraficoFuncionPotencial()
        {
            InitializeComponent();
        }
    }
}
