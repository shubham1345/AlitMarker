using Alit.Marker.Model.Template.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Inventory.Reports
{
    public class StockLedgerReportModel : IReportViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID
        {
            get
            {
                return StockVoucherID;
            }

            set
            {
                StockVoucherID = value;
            }
        }

        [Browsable(false)]
        public long StockVoucherID { get; set; }

        [Browsable(false)]
        public long ProductID { get; set; }

        //public long PCode { get; set; }

        [Browsable(false)]

        public long FinPerID { get; set; }

        //[DisplayName("Product Name")]
        //public string ProductName { get; set; }

        [Browsable(false)]
        public int VoucherTypeID { get; set; }

        [Browsable(false)]
        public int VoucherTypePRT { get; set; }

        [DisplayName("Type")]
        public string VoucherTypeName { get; set; }

        [DisplayName("Date")]
        public DateTime VDate { get; set; }

        [DisplayName("Voucher No.")]
        public long VNo { get; set; }

        [Browsable(false)]
        public long? CustomerID { get; set; }

        [DisplayName("Narration")]
        public string Narration { get; set; }

        [DisplayName("Customer")]
        public string CustomerName { get; set; }

        //[DisplayName("Unit")]
        //public string UnitName { get; set; }

        [DisplayName("In")]
        public decimal QtyIn { get; set; }

        [DisplayName("Out")]
        public decimal QtyOut { get; set; }

        [DisplayName("Closing Stock")]
        public decimal RunningStock { get; set; }

        [DisplayName("Rate")]
        public decimal Rate { get; set; }

        [DisplayName("Amount")]
        public decimal Amt { get { return Math.Abs((QtyIn - QtyOut) * Rate); } }

    }
}
