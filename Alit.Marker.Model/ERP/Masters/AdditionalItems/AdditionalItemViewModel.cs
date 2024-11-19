using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.ERP.Masters.AdditionalItems
{
    public class AdditionalItemDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return AdditionalItemID; } set { AdditionalItemID = value; } }

        [Browsable(false)]
        public long AdditionalItemID { get; set; }

        [DisplayName("Name")]
        public string ItemName { get; set; }

        [DisplayName("Nature")]
        public eAdditionalItemNature Nature { get; set; }

        [DisplayName("Calculate On")]
        public eCalculateOn CalculateOn { get; set; }

        [DisplayName("%")]
        public decimal Percentage { get; set; }

        [DisplayName("Reverse Calculation")]
        public bool? ReverseCalculate { get; set; }

        [DisplayName("Inclusive Rate")]
        public bool? InclusiveRate { get; set; }

        [DisplayName("Default")]
        public bool? AddByDefault { get; set; }

        [DisplayName("Order")]
        public int? DefaultOrder { get; set; }
    }

    public class AdditionalItemViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return AdditionalItemID; } set { AdditionalItemID = value; } }

        [Browsable(false)]
        public long AdditionalItemID { get; set; }

        [DisplayName("Name")]
        public string ItemName { get; set; }

        [DisplayName("Nature")]
        public eAdditionalItemNature Nature { get; set; }

        [DisplayName("%")]
        public decimal Perc { get; set; }

        public eAdditionalItemType ItemType { get; set; }

        public eCalculateOn CalculateOn { get; set; }

        public bool ReverseCalculatePercentage { get; set; }

        public bool InclusiveTax { get; set; }

        public bool IsDefaultRecord { get; set; }

        public int? DefaultRecordPriority { get; set; }

        public long? ProductTaxCategoryID { get; set; }

        public bool MaintainAccount { get; set; }

        [Browsable(false)]
        public long? AccountID { get; set; }
    }

    public class AdditionalItemLookupModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return (long)AdditionalItemID; } set { AdditionalItemID = value; } }

        [Browsable(false)]
        public long? AdditionalItemID { get; set; }

        [DisplayName("Name")]
        public string AddnitionalItemName { get; set; }

        [DisplayName("%")]
        public decimal Perc { get; set; }

        [Browsable(false)]
        [DisplayName("Inclusive")]
        public bool IsInclusive { get; set; }

        [Browsable(false)]
        public long? ProductTaxCategoryID { get; set; }
    }
}
