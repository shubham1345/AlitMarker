using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Reports.TransactionsCommon
{
    public class AdditionalDetailBaseReportModel
    {
        public long? AddiotionalID { get; set; }

        public string AdditionalName { get; set; }

        public string Descr { get; set; }

        public string AdditionalNamePrint { get { return (!String.IsNullOrWhiteSpace(Descr) ? Descr : AdditionalName); } }

        public string ItemNature { get; set; }

        public decimal? Perc { get; set; }

        public decimal Amt { get; set; }

        public decimal UpdatedAmt { get; set; }
    }
}
