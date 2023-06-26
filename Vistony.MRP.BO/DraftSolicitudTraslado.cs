using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.MRP.BO
{
    public class DraftSolicitudTraslado
    {
        public string DocDate { get; set; }
        public string DueDate { get; set; }
        public string JournalMemo { get; set; }
        public string FromWarehouse { get; set; }
        public string ToWarehouse { get; set; }
        public string DocObjectCode { get; set; }
        public string TaxDate { get; set; }
        public string U_SYP_MDMT { get; set; }
        public string U_SYP_SOLICITANTE { get; set; }
        public List<StockTransferLine> StockTransferLines { get; set; }
    }

    public class StockTransferLine
    {
        public int LineNum { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public double Quantity { get; set; }
        public string WarehouseCode { get; set; }
        public string FromWarehouseCode { get; set; }
        public double U_QtySugerida { get; set; }
    }
}
