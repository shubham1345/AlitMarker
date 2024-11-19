using Alit.Marker.Model.CashBank;
using Alit.Marker.Model.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Account.Transactions.Receipt
{
    public class ReceiptPrintModel
    {
        public long ReceiptID { get; set; }

        public long ReceiptNo { get; set; }

        public DateTime ReceiptDate { get; set; }

        public long CustomerID { get; set; }

        public CustomerPrintDetailModel Customer { get; set; }

        public eModeOfPayment PaymentMode { get; set; }

        public decimal Amount { get; set; }

        public string AmtInWords { get; set; }

        public string Remarks { get; set; }

        public Reports.CompanyDetailReportModel CompanyDetail { get; set; }

    }
}
