using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.TransactionsCommon
{
    public class ProductDetailBaseViewModel
    {
        public ProductDetailBaseViewModel()
        {

        }

        public ProductDetailBaseViewModel(bool suspendCalculationAndEventRaiser)
        {
            if (suspendCalculationAndEventRaiser)
            {
                SuspendCalculationAndEventRaiser();
            }
        }

        private bool CalculationAndEventRaiserSuspended { get; set; }

        public void SuspendCalculationAndEventRaiser() { CalculationAndEventRaiserSuspended = true; }
        public void ResumeCalculationAndEventRaiser() { CalculationAndEventRaiserSuspended = false; }

        [Browsable(false)]
        public long? ProductID { get; set; }

        [DisplayName("P. Code")]
        public long? PCode { get; set; }

        [DisplayName("Barcode")]
        public string Barcode { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [DisplayName("Description")]
        public string ProductDescr { get; set; }

        decimal Quantity_;
        [DisplayName("Qty")]
        public decimal Quantity { get { return Quantity_; } set { Quantity_ = value; CalcGAmt(); } }

        decimal Rate_;
        [DisplayName("Rate")]
        public decimal Rate { get { return Rate_; } set { Rate_ = value; CalcGAmt(); } }

        public long UnitID { get; set; }

        bool CalculatingGAmt;
        public void CalcGAmt()
        {
            if (CalculatingGAmt) return;
            if (CalculationAndEventRaiserSuspended) return;
            CalculatingGAmt = true;
            GAmt = Math.Round(Quantity * Rate, 2);
            //GAmt = Math.Round(Quantity * (Rate - (TaxInclusive ? (Rate * TaxPerc) / (100 + TaxPerc) : 0) ), 2);
            //CalcDiscAmt();
            //CalcTaxAmt();

            CalculatingGAmt = false;
        }


        ///// <summary>
        ///// Auto calculation of Discount Amt is off
        ///// </summary>
        //bool ManualCallDiscAmt;
        ///// <summary>
        ///// Auto calculation of Tax Amt is off
        ///// </summary>
        //bool ManualCallTaxAmt;
        ///// <summary>
        ///// Auto calculation of Net Amt is off
        ///// </summary>
        //bool ManualCallNetAmt;

        decimal GAmt_;
        [DisplayName("G.Amt")]
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
                        CalcDiscAmt();
                        CalculateNetAmt();
                        CalcTax1Amt();
                        CalcTax2Amt();
                        CalcTax3Amt();
                    }
                }
            }
        }

        public event ValueChangedEventHandler GAmtChanged;
        public virtual void OnGAmtChanged(object NewValue, object OldValue)
        {
            GAmtChanged?.Invoke(this, new ValueChangedEventArgs(NewValue, OldValue));
        }

        decimal DiscPerc_;
        [DisplayName("Disc %")]
        public decimal DiscPerc { get { return DiscPerc_; } set { DiscPerc_ = value; CalcDiscAmt(); } }

        bool CalculatingDiscAmt;
        public void CalcDiscAmt()
        {
            if (CalculatingDiscAmt) return;
            if (CalculationAndEventRaiserSuspended) return;
            CalculatingDiscAmt = true;

            DiscAmt = Math.Round((GAmt * DiscPerc), 2);

            CalculatingDiscAmt = false;
        }

        decimal DiscAmt_;
        [DisplayName("Disc Amt")]
        public decimal DiscAmt
        {
            get { return DiscAmt_; }
            set
            {
                if (DiscAmt_ != value)
                {
                    DiscAmt_ = value;
                    if (!CalculationAndEventRaiserSuspended)
                    {
                        CalculateNetAmt();
                        CalcTax1Amt();
                        CalcTax2Amt();
                        CalcTax3Amt();
                    }
                }
            }
        }

        #region Product Tax Category 1
        long? Tax1ID_;
        public long? Tax1ID
        {
            get { return Tax1ID_; }
            set
            {
                if (Tax1ID_ != value)
                {
                    long? OldValue = Tax1ID_;
                    Tax1ID_ = value;

                    if (!CalculationAndEventRaiserSuspended)
                    {
                        Tax1IDChanged?.Invoke(this, new ValueChangedEventArgs(Tax1ID_, OldValue));
                        CalcTax1Amt();
                    }
                }
            }
        }
        public event ValueChangedEventHandler Tax1IDChanged;

        decimal Tax1Perc_;
        [DisplayName("Tax %")]
        public decimal Tax1Perc { get { return Tax1Perc_; } set { Tax1Perc_ = value; CalcTax1Amt(); } }

        bool IsCalculatingTax1Amt;
        public void CalcTax1Amt()
        {
            if (IsCalculatingTax1Amt) return;
            if (CalculationAndEventRaiserSuspended) return;
            IsCalculatingTax1Amt = true;

            //decimal GAmtAfterDisc = GAmt - DiscAmt;
            //TaxAmt = Math.Round((GAmtAfterDisc * TaxPerc) / (100 + (TaxInclusive ? TaxPerc : 0)), 2);
            Tax1Amt = Math.Round(((GAmt - DiscAmt) * Tax1Perc), 2);

            IsCalculatingTax1Amt = false;
        }

        decimal Tax1Amt_;
        [DisplayName("Tax Amt")]
        public decimal Tax1Amt
        {
            get
            {
                return Tax1Amt_;
            }
            set
            {
                if (Tax1Amt_ != value)
                {
                    decimal OldValue = Tax1Amt_;
                    Tax1Amt_ = value;
                    if (!CalculationAndEventRaiserSuspended)
                    {
                        Tax1AmtChanged?.Invoke(this, new ValueChangedEventArgs(Tax1Amt_, OldValue));
                        CalculateNetAmt();
                    }
                }
            }
        }

        public event ValueChangedEventHandler Tax1AmtChanged;
        #endregion

        #region Product Tax Category 2
        long? Tax2ID_;
        public long? Tax2ID
        {
            get { return Tax2ID_; }
            set
            {
                if (Tax2ID_ != value)
                {
                    long? OldValue = Tax2ID_;
                    Tax2ID_ = value;

                    if (!CalculationAndEventRaiserSuspended)
                    {
                        Tax2IDChanged?.Invoke(this, new ValueChangedEventArgs(Tax2ID_, OldValue));
                        CalcTax2Amt();
                    }
                }
            }
        }
        public event ValueChangedEventHandler Tax2IDChanged;

        decimal Tax2Perc_;
        [DisplayName("Tax %")]
        public decimal Tax2Perc { get { return Tax2Perc_; } set { Tax2Perc_ = value; CalcTax2Amt(); } }

        bool IsCalculatingTax2Amt;
        public void CalcTax2Amt()
        {
            if (IsCalculatingTax2Amt) return;
            if (CalculationAndEventRaiserSuspended) return;
            IsCalculatingTax2Amt = true;

            //decimal GAmtAfterDisc = GAmt - DiscAmt;
            //TaxAmt = Math.Round((GAmtAfterDisc * TaxPerc) / (100 + (TaxInclusive ? TaxPerc : 0)), 2);
            Tax2Amt = Math.Round(((GAmt - DiscAmt) * Tax2Perc), 2);

            IsCalculatingTax2Amt = false;
        }

        decimal Tax2Amt_;
        [DisplayName("Tax Amt")]
        public decimal Tax2Amt
        {
            get
            {
                return Tax2Amt_;
            }
            set
            {
                if (Tax2Amt_ != value)
                {
                    decimal OldValue = Tax2Amt_;
                    Tax2Amt_ = value;

                    if (!CalculationAndEventRaiserSuspended)
                    {
                        Tax2AmtChanged?.Invoke(this, new ValueChangedEventArgs(Tax2Amt_, OldValue));
                        CalculateNetAmt();
                    }
                }
            }
        }

        public event ValueChangedEventHandler Tax2AmtChanged;

        #endregion

        #region Product Tax Category 3
        long? Tax3ID_;
        public long? Tax3ID
        {
            get { return Tax3ID_; }
            set
            {
                if (Tax3ID_ != value)
                {
                    long? OldValue = Tax3ID_;
                    Tax3ID_ = value;

                    if (!CalculationAndEventRaiserSuspended)
                    {
                        Tax3IDChanged?.Invoke(this, new ValueChangedEventArgs(Tax3ID_, OldValue));
                        CalcTax3Amt();
                    }
                }
            }
        }
        public event ValueChangedEventHandler Tax3IDChanged;

        //bool Tax3Inclusive_;
        //public bool Tax3Inclusive
        //{
        //    get { return Tax3Inclusive_; }
        //    set
        //    {
        //        if (Tax3Inclusive_ != value)
        //        {
        //            Tax3Inclusive_ = value;
        //            CalcTax3Amt();
        //        }
        //    }
        //}

        decimal Tax3Perc_;
        [DisplayName("Tax %")]
        public decimal Tax3Perc { get { return Tax3Perc_; } set { Tax3Perc_ = value; CalcTax3Amt(); } }

        bool IsCalculatingTax3Amt;
        public void CalcTax3Amt()
        {
            if (IsCalculatingTax3Amt) return;
            IsCalculatingTax3Amt = true;

            if (!CalculationAndEventRaiserSuspended)
            {
                //decimal GAmtAfterDisc = GAmt - DiscAmt;
                //TaxAmt = Math.Round((GAmtAfterDisc * TaxPerc) / (100 + (TaxInclusive ? TaxPerc : 0)), 2);
                Tax3Amt = Math.Round(((GAmt - DiscAmt) * Tax3Perc), 2);
            }

            IsCalculatingTax3Amt = false;
        }

        decimal Tax3Amt_;
        [DisplayName("Tax Amt")]
        public decimal Tax3Amt
        {
            get
            {
                return Tax3Amt_;
            }
            set
            {
                if (Tax3Amt_ != value)
                {
                    decimal OldValue = Tax3Amt_;
                    Tax3Amt_ = value;

                    if (!CalculationAndEventRaiserSuspended)
                    {
                        Tax3AmtChanged?.Invoke(this, new ValueChangedEventArgs(Tax3Amt_, OldValue));
                        CalculateNetAmt();
                    }
                }
            }
        }

        public event ValueChangedEventHandler Tax3AmtChanged;

        #endregion

        decimal NetAmt_;
        [DisplayName("Net Amt")]
        public decimal NetAmt
        {
            get { return NetAmt_; }
            set
            {
                if (NetAmt_ != value)
                {
                    decimal OldValue = NetAmt_;
                    NetAmt_ = value;

                    if (!CalculationAndEventRaiserSuspended)
                    {
                        NetAmtChanged?.Invoke(this, new ValueChangedEventArgs(NetAmt_, OldValue));
                    }
                }
            }
        }

        public event ValueChangedEventHandler NetAmtChanged;

        bool CalculatingNetAmt;
        public void CalculateNetAmt()
        {
            if (CalculatingNetAmt) return;
            if (CalculationAndEventRaiserSuspended) return;
            CalculatingNetAmt = true;
            NetAmt = Math.Round(GAmt - DiscAmt, 2);

            CalculatingNetAmt = false;
        }
    }
}
