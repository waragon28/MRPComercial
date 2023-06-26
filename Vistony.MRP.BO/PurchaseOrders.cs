using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.MRP.BO
{
    public class PurchaseOrders
    {
        public string DocDate { get; set; }
        public string DocDueDate { get; set; }
        public string CardCode { get; set; }
        public string Comments { get; set; }
        public int SalesPersonCode { get; set; }
        public int DocumentsOwner { get; set; }
        public List<DocumentLine> DocumentLines { get; set; }
    }

    public class DocumentLine
    {
        public int LineNum { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public double Quantity { get; set; }
        public string WarehouseCode { get; set; }
        public double Price { get; set; }
    }
}
