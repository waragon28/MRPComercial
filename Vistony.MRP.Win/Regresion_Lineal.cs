using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearRegression;
using MathNet.Numerics.Statistics;

namespace Vistony.MRP.Win
{
    public class Regresion_Lineal
    {

        public void Arreglo()
        {
            // Datos de ejemplo
            double[] tiempo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            double[] valores = { 2, 1, 1, 0, 1, 2, 3, 1, 0, 4, 0, 2, 2 };

            // Realizar regresión lineal
            Tuple<double, double> modelo = Fit.Line(tiempo, valores);

            // Imprimir resultados
            Console.WriteLine($"Coeficiente de pendiente: {modelo.Item1}");
            Console.WriteLine($"Coeficiente de intersección: {modelo.Item2}");

        }


    }
}
