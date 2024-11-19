using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Reports.TransactionsCommon
{
    public class ProductDetailBaseReportModel
    {
        public long? ProductID { get; set; }

        public int SNo { get; set; }

        public string HSNCode { get; set; }

        public string ProductName { get; set; }

        public string ProductDescr { get; set; }

        public decimal Quan { get; set; }

        public decimal Rate { get; set; }

        public long UnitID { get; set; }

        public string UnitName { get; set; }

        public decimal DiscPerc { get; set; }

        public decimal DiscAmt { get; set; }

        #region Tax 1 
        public decimal Tax1Perc { get; set; }

        public decimal? Tax1Amt { get; set; }

        public long? Tax1ID { get; set; }

        public string Tax1Name { get; set; }
        #endregion

        #region Tax 2
        public decimal Tax2Perc { get; set; }

        public decimal? Tax2Amt { get; set; }

        public long? Tax2ID { get; set; }

        public string Tax2Name { get; set; }
        #endregion

        #region Tax 3
        public decimal Tax3Perc { get; set; }

        public decimal? Tax3Amt { get; set; }

        public long? Tax3ID { get; set; }

        public string Tax3Name { get; set; }
        #endregion

        public decimal GAmt { get; set; }

        public decimal NAmt { get; set; }
    }
}
