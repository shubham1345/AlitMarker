using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Inventory.Reports
{
    public class StockInHandReportModel : Model.Template.Report.IReportViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID
        {
            get
            {
                return ProductID;
            }

            set
            {
                ProductID = value;
            }
        }

        [Browsable(false)]
        public long ProductID { get; set; }

        [DisplayName("P.Code")]
        public long PCode { get; set; }

        [DisplayName("Product")]
        public string ProductName { get; set; }

        [DisplayName("Unit")]
        public string UnitName { get; set; }

        [DisplayName("HSN")]
        public string HSN { get; set; }

        [DisplayName("Bar Code")]
        public string BarCode { get; set; }

        [DisplayName("Opening Stock")]
        public decimal? OpeningStock { get; set; }

        [DisplayName("Sale")]
        public decimal? Sale { get; set; }

        [DisplayName("Purchase")]
        public decimal? Purchase { get; set; }

        [DisplayName("Sale Return")]
        public decimal? SaleReturn { get; set; }

        [DisplayName("Purchase Return")]
        public decimal? PurchaseReturn { get; set; }

        [DisplayName("Stock In")]
        public decimal? StockIn { get; set; }

        [DisplayName("Stock Out")]
        public decimal? StockOut { get; set; }

        [DisplayName("Other")]
        public decimal? Other { get; set; }

        [DisplayName("Closing Stock")]
        public decimal? ClosingStock
        {
            get
            {
                if (OpeningStock != null || Sale != null || Purchase != null || SaleReturn != null || PurchaseReturn != null || StockIn != null || StockOut != null || Other != null)
                {
                    return (OpeningStock ?? 0)
                        
                        + (Purchase ?? 0)
                        + (SaleReturn ?? 0)
                        + (StockIn ?? 0)
                        - (Sale ?? 0)
                        - (StockOut ?? 0)
                        - (PurchaseReturn ?? 0)
                        + (Other ?? 0);
                }
                else
                {
                    return null;
                }
            }
        }

        [DisplayName("Purchase Rate")]
        public decimal PurchaseRate { get; set; }

        [DisplayName("Cost")]
        public decimal? CostValue { get { return (ClosingStock != null ? (decimal?)Math.Round(ClosingStock.Value * PurchaseRate, 2) : null); } }
    }
}
