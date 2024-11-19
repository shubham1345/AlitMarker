using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Manufacturing.Process
{
    public class ProcessDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return ProcessID; } set { ProcessID = value; } }

        [Browsable(false)]
        public long ProcessID { get; set; }

        [Browsable(false)]
        public long ProductID { get; set; }

        [DisplayName("Process Date")]
        public DateTime ProcessDate { get; set; }

        [DisplayName("Process No.")]
        public long ProcessNo { get; set; }

        [DisplayName("P. Code")]
        public long PCode { get; set; }

        [DisplayName("Barcode")]
        public string Barcode { get; set; }

        [DisplayName("Name")]
        public string ProductName { get; set; }

        [DisplayName("Narration")]
        public string Narration { get; set; }

        [DisplayName("Finish Qty")]
        public decimal FinishQuantity { get; set; }

        [DisplayName("Unit")]
        public string UnitName { get; set; }

        [DisplayName("Rate")]
        public decimal Rate { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get { return Math.Round(FinishQuantity * Rate, 2); } }
    }

    public class ProcessViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return ProcessID; } set { ProcessID = value; } }

        [Browsable(false)]
        public long ProcessID { get; set; }

        [Browsable(false)]
        public long ProductID { get; set; }

        [DisplayName("Process Date")]
        public DateTime ProcessDate { get; set; }

        [DisplayName("Process No.")]
        public long ProcessNo { get; set; }

        [DisplayName("Finish Qty")]
        public decimal FinishQuantity { get; set; }

        [DisplayName("Rate")]
        public decimal Rate { get; set; }

        public string Narration { get; set; }

        public List<ProcessDetailViewModel> ProductDetail { get; set; }
    }


    public class ProcessLookUpListModel
    {
        [Browsable(false)]
        public long ProcessID { get; set; }

        [Browsable(false)]
        public long ProductID { get; set; }


        [DisplayName("Process Date")]
        public DateTime ProcessDate { get; set; }

        [DisplayName("Process No.")]
        public long ProcessNo { get; set; }


        [DisplayName("P. Code")]
        public long PCode { get; set; }

        [DisplayName("Barcode")]
        public string Barcode { get; set; }

        [DisplayName("Name")]
        public string ProductName { get; set; }

        [DisplayName("Finish Qty")]
        public decimal FinishQuantity { get; set; }

        [DisplayName("Unit")]
        public string UnitName { get; set; }

        [DisplayName("Rate")]
        public decimal Rate { get; set; }
    }

    public class ProcessDetailViewModel
    {
        [DisplayName("Product")]
        public long ProductID { get; set; }

        [Browsable(false)]
        public decimal FormulaQuantity { get; set; }

        public decimal Quantity { get; set; }

        public decimal Rate { get; set; }

        public decimal Amt { get { return Math.Round(Quantity * Rate, 2); } }
    }
}
