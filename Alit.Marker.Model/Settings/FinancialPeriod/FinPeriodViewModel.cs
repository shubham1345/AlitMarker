using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Settings.FinancialPeriod
{

    public class FinPeriodDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return FinPeriodID; } set { FinPeriodID = value; } }

        [Browsable(false)]
        public long FinPeriodID { get; set; }

        [DisplayName("Financial Period Name")]
        public string FinPeriodName { get; set; }

        [DisplayName("From")]
        public DateTime FinPeriodFrom { get; set; }

        [Browsable(false)]
        public DateTime? FinPeriodTo { get; set; }

        [DisplayName("To")]
        public string FinPeriodText { get { return FinPeriodTo.HasValue ? FinPeriodTo.Value.ToShortDateString() : ""; } }
    }

    public class FinPeriodViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return FinPeriodID; } set { FinPeriodID = value; } }

        [Browsable(false)]
        public long FinPeriodID { get; set; }

        [DisplayName("Financial Period Name")]
        public string FinPeriodName { get; set; }

        [DisplayName("From")]
        public DateTime FinPeriodFrom { get; set; }

        [Browsable(false)]
        public DateTime? FinPeriodTo { get; set; }

        [DisplayName("To")]
        public string FinPeriodText { get { return FinPeriodTo.HasValue ? FinPeriodTo.Value.ToShortDateString() : ""; } }

        public long CompanyID { get; set; }

        public FinPeriodDetailModel PreviousFinancialPeriod { get; set; }

        public FinPeriodDetailModel NextFinancialPeriod { get; set; }

        public List<CustomerClosingBalanceViewModel> OpeningBalance { get; set; }

        public List<ProductOpeningStockViewModel> OpeningStock { get; set; }
    }

    public class FinPeriodLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return FinPeriodID; } set { FinPeriodID = value; } }

        [Browsable(false)]
        public long FinPeriodID { get; set; }

        [DisplayName("Financial Period Name")]
        public string FinPeriodName { get; set; }

        [DisplayName("From")]
        public DateTime FinPeriodFrom { get; set; }

        [Browsable(false)]
        public DateTime? FinPeriodTo { get; set; }

        [DisplayName("To")]
        public string FinPeriodText { get { return FinPeriodTo.HasValue ? FinPeriodTo.Value.ToShortDateString() : ""; } }
    
    }

    public class FinPeriodDetailModel
    {
        [Browsable(false)]
        public long FinPeriodID { get; set; }

        [DisplayName("Financial Period Name")]
        public string FinPeriodName { get; set; }

        [DisplayName("From")]
        public DateTime FinPeriodFrom { get; set; }

        [DisplayName("To")]
        public DateTime? FinPeriodTo { get; set; }

        [Browsable(false)]
        public long CompanyID { get; set; }
    }

    public class CustomerClosingBalanceViewModel
    {
        [Browsable(false)]
        public long CustomerID { get; set; }

        [DisplayName("Customer#")]
        [ReadOnly(true)]
        public long CustomerNo { get; set; }

        [DisplayName("Customer Name")]
        [ReadOnly(true)]
        public string CustomerName { get; set; }

        [DisplayName("Company Name")]
        [ReadOnly(true)]
        public string CompanyName { get; set; }

        [ReadOnly(true)]
        public string Address { get; set; }

        [ReadOnly(true)]
        public string City { get; set; }

        [ReadOnly(true)]
        [DisplayName("Mobile No")]
        public string MobileNo { get; set; }

        [DisplayName("Op. Balance")]
        public decimal OpeningBalance { get; set; }
    }

    public class ProductOpeningStockViewModel
    {
        [Browsable(false)]
        public long ProductID { get; set; }

        [DisplayName("Code")]

        [ReadOnly(true)]
        public long ProductCode { get; set; }

        [DisplayName("Product")]
        [ReadOnly(true)]
        public string ProductName { get; set; }

        [DisplayName("Stock")]
        public decimal Stock { get; set; }

        [DisplayName("Unit")]
        [ReadOnly(true)]
        public string UnitName { get; set; }

        [Browsable(false)]
        public decimal Rate { get; set; }
    }
}
