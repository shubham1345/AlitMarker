using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.TransactionsCommon
{
    public class DynamicProductBase
    {
        public int SNo { get; set; }
        public long ProductCode { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public long UnitID { get; set; }
        public long? Tax1ID { get; set; }
        public long? Tax2ID { get; set; }
        public long? Tax3ID { get; set; }
        public decimal DiscountPerc { get; set; }
    }
}
