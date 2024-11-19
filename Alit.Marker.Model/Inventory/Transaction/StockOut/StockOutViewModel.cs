using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Inventory.Transaction.StockOut
{
    public class StockOutDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return StockOutID; } set { StockOutID = value; } }

        [Browsable(false)]
        public long StockOutID { get; set; }

        [DisplayName("Date")]
        public DateTime VoucherDate { get; set; }

        [DisplayName("No.")]
        public long VoucherNo { get; set; }

        public string Narration { get; set; }

        public List<StockOutDashboardProductDetailViewModel> ProductDetail { get; set; }
    }

    public class StockOutDashboardProductDetailViewModel
    {
        [Browsable(false)]
        public long StockOutID { get; set; }

        public long StockOutProductDetailID { get; set; }

        [DisplayName("P. Code")]
        public long? PCode { get; set; }

        [DisplayName("Barcode")]
        public string Barcode { get; set; }

        [DisplayName("Product")]
        public string ProductName { get; set; }

        [DisplayName("Qty")]
        [DisplayFormat(DataFormatString = "{0:n2")]
        public decimal Qty { get; set; }

        [DisplayName("Unit")]
        public string UnitName { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2")]
        public decimal Rate { get; set; }

        [DisplayName("Amount")]
        [DisplayFormat(DataFormatString = "{0:n2")]
        public decimal Amount
        {
            get { return Math.Round(Qty * Rate, 2); }
        }
    }

    public class StockOutViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return StockOutID; } set { StockOutID = value; } }

        [Browsable(false)]
        public long StockOutID { get; set; }

        [DisplayName("Date")]
        public DateTime VoucherDate { get; set; }

        [DisplayName("No.")]
        public long VoucherNo { get; set; }

        public long? PriceListID { get; set; }

        public List<StockOutProductDetailViewModel> ProductDetail { get; set; }

        public string Narration { get; set; }
    }

    public class StockOutProductDetailViewModel
    {
        private bool CalculationAndEventRaiserSuspended { get; set; }

        public void SuspendCalculationAndEventRaiser() { CalculationAndEventRaiserSuspended = true; }
        public void ResumeCalculationAndEventRaiser() { CalculationAndEventRaiserSuspended = false; }

        [DisplayName("Product")]
        public long ProductID { get; set; }

        [DisplayName("P. Code")]
        public long PCode { get; set; }

        [DisplayName("Barcode")]
        public string Barcode { get; set; }

        [DisplayName("Product")]
        public string ProductName { get; set; }

        //[DisplayName("Description")]
        //public string Description { get; set; }


        decimal Quantity_;
        [DisplayName("Qty")]
        public decimal Quantity { get { return Quantity_; } set { Quantity_ = value; CalcGAmt(); } }

        decimal Rate_;
        [DisplayName("Rate")]
        public decimal Rate { get { return Rate_; } set { Rate_ = value; CalcGAmt(); } }

        [DisplayName("Unit")]
        public long UnitID { get; set; }

        bool CalculatingGAmt;
        public void CalcGAmt()
        {
            if (CalculatingGAmt) return;
            if (CalculationAndEventRaiserSuspended) return;

            CalculatingGAmt = true;
            GAmt = Math.Round(Quantity * Rate, 2);
            CalculatingGAmt = false;
        }

        decimal GAmt_;
        [DisplayName("Amount")]
        public decimal GAmt
        {
            get { return GAmt_; }
            set
            {
                if (GAmt_ != value)
                {
                    decimal OldValue = GAmt_;
                    GAmt_ = value;
                    if (!CalculationAndEventRaiserSuspended)
                    {
                        OnGAmtChanged(GAmt_, OldValue);
                    }
                }
            }
        }

        public event ValueChangedEventHandler GAmtChanged;
        public virtual void OnGAmtChanged(object NewValue, object OldValue)
        {
            GAmtChanged?.Invoke(this, new ValueChangedEventArgs(NewValue, OldValue));
        }
    }


    public class StockOutLookUpListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return StockOutID; } set { StockOutID = value; } }

        [Browsable(false)]
        public long StockOutID { get; set; }

        [DisplayName("No.")]
        public long VoucherNo { get; set; }

        [DisplayName("Date")]
        public DateTime VoucherDate { get; set; }
    }
}
