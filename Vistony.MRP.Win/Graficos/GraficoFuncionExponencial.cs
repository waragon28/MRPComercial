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
    public partial class GraficoFuncionExponencial : Form
    {
        public GraficoFuncionExponencial()
        {
            InitializeComponent();
        }
        double[] y = new double[] { };

        public GraficoFuncionExponencial(List<double> List_V_y)
        {
            //  if (comboBox1.Text=="Lineal")
            // {
            this.y = List_V_y.ToArray();
            // Crear un nuevo gráfico
            var chart = new Chart();
            chart.Dock = DockStyle.Fill;

            // Configuración del control Chart
            chart.BackColor = Color.WhiteSmoke;
            chart.BorderlineColor = Color.Gray;
            chart.BorderlineWidth = 1;
            chart.Titles.Add("Gráfico de función Exponencial");
            // Personalizar la leyenda
            chart.Legends.Add(new Legend("Mi Leyenda"));
            chart.Legends[0].Docking = Docking.Bottom;  // Establecer posición de la leyenda

            chart.ChartAreas.Add(new ChartArea("FuncionExponencial"));

            // Crear la serie de datos
            var serie = new Series("Valores");
            serie.Color = Color.Blue;
            serie.MarkerSize = 10;
            serie.MarkerStyle = MarkerStyle.Circle;
            serie.ChartType = SeriesChartType.Line;
            serie.BorderWidth = 3;  // Establecer ancho de la línea
            //  serie.ChartArea = "Función lineal";
            //  serie.LegendText = "Datos";


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
            double Sum_X = 0;
            double SumX2 = 0;
            List<double> List_Y_Result = new List<double>();
            double[] Y_Result = new double[] { };

            double Sum_Yprima = 0;//EXPONENCIAL
            double Sum_XYprima = 0;//EXPONENCIAL
            double APrima = 0;//EXPONENCIAL
            double Yprima = 0;
            // OBTENER EL XY
            for (int i = 0; i < y.Length; i++)
            {
                if (y[i] == 0)
                {
                    Yprima += 0;
                }
                else
                {
                    Yprima = (Math.Log10(y[i]) / Math.Log10(2.71828)); //LOGARITMICA EXPONENCIAL
                }

                Sum_X += x[i];
                Sum_Yprima += Yprima;
                Sum_XYprima += x[i]* Yprima;
                SumX2 += Math.Pow(x[i], 2);

            }
            b = ((y.Length * Sum_XYprima) - (Sum_X * Sum_Yprima)) / ((y.Length * SumX2) - Math.Pow(Sum_X, 2));
            APrima = (Sum_Yprima / y.Length) - b * (Sum_X / y.Length);
            a = Math.Pow(2.71828, APrima);

            // Crear una fuente personalizada para las etiquetas en negrita
            Font font = new Font("Arial", 10, FontStyle.Bold);

            for (int i = 0; i < x.Length; i++)
            {
                List_Y_Result.Add(a * Math.Pow(2.71828, b * x[i]));
            }



            Y_Result = List_Y_Result.ToArray();
            // Agregar los puntos a la serie de datos
            for (int i = 0; i < x.Length; i++)
            {
                DataPoint dataPoint = new DataPoint(x[i], y[i]);
                serie.Points.AddXY(x[i], y[i]);
                dataPoint.Label = Convert.ToString(y[i]);
                dataPoint.Color = Color.Gray;
                dataPoint.Font = font;
                serie.Points.Add(dataPoint);

                DataPoint dataPoint2 = new DataPoint(x[i], Y_Result[i]);
                dataPoint2.Label = Convert.ToString(Convert.ToInt32(Y_Result[i]));
                dataPoint2.Color = Color.Blue;
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

    }
}
