using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.MRP.BO
{
    public class Forecast_Hist_C
    {
        public int U_USER_CODE { get; set; }
        public string U_NAME { get; set; }
        public string U_NDED { get; set; }
        public string U_TipoGerencia { get; set; }
        public string U_TaxDate { get; set; }
        public string Period { get; set; }
        public List<Forecast_Hist_D> VIS_SCM_FRC1Collection { get; set; }
    }
}
