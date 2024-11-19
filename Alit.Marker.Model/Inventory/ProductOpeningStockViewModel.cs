using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Inventory
{
    public class ProductOpeningStockDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return OpeningStockID; } set { OpeningStockID = value; } }

        [Browsable(false)]
        public long OpeningStockID { get; set; }

        [Browsable(false)]
        public long ProductID { get; set; }

        [DisplayName("P. Code")]
        public long PCode { get; set; }

        [DisplayName("Barcode")]
        public string Barcode { get; set; }

        [DisplayName("Name")]
        public string ProductName { get; set; }

        [DisplayName("Op. Stock Date")]
        public DateTime OpeningStockDate { get; set; }

        [DisplayName("Op.Stock Qty")]
        public decimal OpeningStockQty { get; set; }

        [DisplayName("Unit")]
        public string UnitName { get; set; }

        [DisplayName("Rate")]
        public decimal Rate { get; set; }
    }

    public class ProductOpeningStockViewModel :  Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return ProductID; } set { ProductID = value; } }

        [Browsable(false)]
        public long OpeningStockID { get; set; }

        [Browsable(false)]
        public long ProductID { get; set; }

        [DisplayName("Name")]
        public string ProductName { get; set; }

        [DisplayName("Op.Stock Date")]
        public DateTime OpeningStockDate { get; set; }

        [DisplayName("Op.Stock Qty")]
        public decimal OpeningStockQty { get; set; }

        [DisplayName("Rate")]
        public decimal Rate { get; set; }

        [DisplayName("Unit")]
        public string UnitName { get; set; }

        [DisplayName("Bar Code")]
        public string BarCode { get; set; }


        [DisplayName("P.Code")]
        public long PCode { get; set; }

        [DisplayName("HSN")]
        public string HSN { get; set; }

        public string Narration { get; set; }
    }
}
