using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistony.MRP.Win.Graficos
{
    public partial class GraficoFuncionPolinomica : Form
    {
        double[] y = new double[] { };
        public GraficoFuncionPolinomica(List<double> List_V_y)
        {
            InitializeComponent();
        }
    }
}
