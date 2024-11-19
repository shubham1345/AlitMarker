using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Manufacturing.Formula
{
    public class ProductFormulaDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return ProductFormulaID; } set { ProductFormulaID = value; } }

        [Browsable(false)]
        public long ProductFormulaID { get; set; }

        [Browsable(false)]
        public long ProductID { get; set; }

        [DisplayName("P. Code")]
        public long PCode { get; set; }

        [DisplayName("Barcode")]
        public string Barcode { get; set; }

        [DisplayName("Name")]
        public string ProductName { get; set; }

        [DisplayName("Finish Qty")]
        public decimal FinishQuantity { get; set; }

        [DisplayName("Effective from")]
        public DateTime? WEDate { get; set; }
    }

    public class ProductFormulaViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return ProductFormulaID; } set { ProductFormulaID = value; } }

        [Browsable(false)]
        public long ProductFormulaID { get; set; }

        [Browsable(false)]
        public long ProductID { get; set; }

        [DisplayName("Finish Qty")]
        public decimal FinishQuantity { get; set; }

        [DisplayName("Effective from")]
        public DateTime? WEDate { get; set; }

        public string Remark { get; set; }

        public List<ProductFormulaDetailViewModel> ProductDetail { get; set; }
    }

    public class ProductFormulaLookupListModel
    {

        [Browsable(false)]
        public long ProductFormulaID { get; set; }

        [Browsable(false)]
        public long ProductID { get; set; }

        [DisplayName("P. Code")]
        public long PCode { get; set; }

        [DisplayName("Barcode")]
        public string Barcode { get; set; }

        [DisplayName("Name")]
        public string ProductName { get; set; }

        [DisplayName("Finish Qty")]
        public decimal FinishQuantity { get; set; }

        [DisplayName("Effective from")]
        public DateTime? WEDate { get; set; }
    }

    public class ProductFormulaDetailViewModel
    {
        [DisplayName("Product")]
        public long ProductID { get; set; }

        [DisplayName("Quantity")]
        public decimal Quantity { get; set; }

        //public decimal Rate { get; set; }

        //public decimal Amt { get { return Math.Round(Quantity * Rate, 2); } }
    }
}
