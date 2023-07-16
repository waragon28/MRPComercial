using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.MRP.BO
{
    public class Forecast_Hist_D
    {
        public string U_ItemCode { get; set; }
        public string U_Dscription { get; set; }
        public double U_VIS_Gal { get; set; }
        public int U_Func_Lineal { get; set; }
        public int U_Func_Exponencial { get; set; }
        public int U_Func_Logaritmico { get; set; }
        public int U_Func_Potencial { get; set; }
        public int U_Func_Polinomica { get; set; }
        public string U_Func_Aplicada { get; set; }
        public int U_Pronostico { get; set; }
        public int U_Ult_Mes_Hist { get; set; }
        public int U_VIS_Req { get; set; }
        public int U_Stock { get; set; }
    }
}
