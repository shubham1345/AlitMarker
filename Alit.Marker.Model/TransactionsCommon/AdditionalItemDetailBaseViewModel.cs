using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.TransactionsCommon
{
    public enum eAdditionalRecordType
    {
        UserAdded = 0,
        Tax = 1,
        RoundedOff = 2
    }

    public enum eAdditionalItemNature
    {
        Add = 0,
        Less = 1,
    }

    public enum eAdditionalItemType
    {
        AdditionalItem = 0,
        Tax = 1
    }

    public enum eCalculateOn
    {
        /// <summary>
        /// None denotes don't calculate automatically.
        /// </summary>
        None = 0,
        GrossAmt = 1,
        UpdatedAmt = 2
    }


    public class AdditionalItemDetailBaseViewModel
    {
        public AdditionalItemDetailBaseViewModel(bool suspendCalculationAndEventRaiser) : this(0, null, suspendCalculationAndEventRaiser)
        {
        }

        public AdditionalItemDetailBaseViewModel() : this(0, null)
        { }

        public AdditionalItemDetailBaseViewModel(
            [Optional] long AdditionalsID,
            [Optional] long? AdditionalItemID,
            bool suspendCalculationAndEventRaiser = false,
            string AdditionalItemName = "",
            eCalculateOn CalculateOn = eCalculateOn.None,
            string ItemDescr = "",
            eAdditionalItemNature ItemNature = eAdditionalItemNature.Add,
            decimal Perc = 0,
            decimal Amt = 0,
            decimal CalculatedOnAmt = 0,
            decimal UpdatedAmt = 0,
            bool IsInclusive = false,
            eAdditionalRecordType RecordType = eAdditionalRecordType.UserAdded,
            bool CalculatePercRev = false)
        {
            this.CalculationAndEventRaiserSuspended = suspendCalculationAndEventRaiser;
            this.AdditionalsID = AdditionalsID;
            this.AdditionalItemID = AdditionalItemID;
            this.AdditionalItemName = AdditionalItemName;
            this.CalculateOn = CalculateOn;
            this.ItemDescr = ItemDescr;
            this.ItemNature_ = ItemNature;
            this.Perc_ = Perc;
            this.Amt_ = Amt;
            this.CalculatedOnAmt_ = CalculatedOnAmt;
            this.UpdatedAmt = UpdatedAmt;
            this.IsInclusive = IsInclusive;
            this.RecordType = RecordType;
            this.CalculatePercRev = CalculatePercRev;
        }

        private bool CalculationAndEventRaiserSuspended { get; set; }

        public void SuspendCalculationAndEventRaiser() { CalculationAndEventRaiserSuspended = true; }
        public void ResumeCalculationAndEventRaiser() { CalculationAndEventRaiserSuspended = false; }


        [Browsable(false)]
        public long AdditionalsID { get; set; }

        [Browsable(false)]
        public long? AdditionalItemID { get; set; }

        [DisplayName("Name")]
        public string AdditionalItemName { get; set; }

        [DisplayName("Calculate On Percentage")]
        public eCalculateOn CalculateOn { get; set; }

        [DisplayName("Descriptions")]
        public string ItemDescr { get; set; }

        eAdditionalItemNature ItemNature_ = eAdditionalItemNature.Add;
        [DisplayName("+/-")]
        public eAdditionalItemNature ItemNature
        {
            get { return ItemNature_; }
            set
            {
                if (ItemNature_ != value)
                {
                    eAdditionalItemNature oldvalue = ItemNature_;
                    ItemNature_ = value;

                    if (!CalculationAndEventRaiserSuspended)
                    {
                        CalculateAmt();
                        OnItemNatureChanged(ItemNature_, oldvalue);
                    }
                }
            }
        }

        bool SuppressPercCalculation;
        bool SuppressAmtCalculation;
        decimal Perc_;
        [DisplayName("%")]
        public decimal Perc
        {
            get { return Perc_; }
            set
            {
                if (Perc_ != value)
                {
                    Perc_ = value;

                    if (!CalculationAndEventRaiserSuspended)
                    {
                        SuppressPercCalculation = true;
                        if (!SuppressAmtCalculation) CalculateAmt(true);
                        SuppressPercCalculation = false;
                    }
                }
            }
        }

        public void CalculateAmt(bool Forced = false)
        {
            try
            {
                if (Perc != 0 || Forced)
                {
                    if (!IsInclusive)
                    {
                        Amt = Math.Round(CalculatedOnAmt * Perc_, CommonProperties.UIDataFormats.AmountDecimalLen);
                    }
                    else
                    {
                        Amt = Math.Round(CalculatedOnAmt * (Perc_ * 100) / (100 + (IsInclusive ? 1 : 0)), CommonProperties.UIDataFormats.AmountDecimalLen);
                    }
                }
            }
            catch (DivideByZeroException)
            {
                Amt = 0;
            }
        }

        decimal Amt_;
        [DisplayName("Amt")]
        public decimal Amt
        {
            get
            {
                return Amt_;
            }
            set
            {
                decimal OldValue = Amt_;
                Amt_ = value;

                if (!CalculationAndEventRaiserSuspended)
                {
                    SuppressAmtCalculation = true;
                    if (!SuppressPercCalculation && CalculatePercRev) CalculatePerc();
                    SuppressAmtCalculation = false;
                }

                OnAmtChanged(Amt_, OldValue);
            }
        }

        public event ValueChangedEventHandler AmtChanged;
        public virtual void OnAmtChanged(object NewValue, object OldValue)
        {
            AmtChanged?.Invoke(this, new ValueChangedEventArgs(NewValue, OldValue));
        }

        public event ValueChangedEventHandler ItemNatureChanged;
        public virtual void OnItemNatureChanged(object NewValue, object OldValue)
        {
            ItemNatureChanged?.Invoke(this, new ValueChangedEventArgs(NewValue, OldValue));
        }

        public void CalculatePerc()
        {
            if (CalculatedOnAmt == 0)
            {
                Perc = 0;
            }
            else
            {
                Perc = Math.Round((Amt / (CalculatedOnAmt - (IsInclusive ? Amt : 0))), CommonProperties.UIDataFormats.RateDecimalLen);
            }
        }

        decimal CalculatedOnAmt_;
        public decimal CalculatedOnAmt
        {
            get { return CalculatedOnAmt_; }
            set
            {

                if (CalculatedOnAmt_ != value)
                {
                    CalculatedOnAmt_ = value;

                    if (!CalculationAndEventRaiserSuspended)
                    {
                        SuppressPercCalculation = true;
                        CalculateAmt();
                        SuppressPercCalculation = false;
                    }
                }
            }
        }

        [Browsable(false)]
        public decimal UpdatedAmt { get; set; }

        [Browsable(false)]
        public bool IsInclusive { get; set; }

        [Browsable(false)]
        public eAdditionalRecordType RecordType { get; set; }

        [Description("Calculate percentage reverse back while user enters amount manually.")]
        public bool CalculatePercRev { get; set; }
    }

}
