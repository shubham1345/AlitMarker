using Alit.Marker.Model.Account.Group;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Account.Account
{
    public enum eAccountFormType
    {
        Account = 0,
        Customer = 1,
        Supplier = 2 
    }

    public enum eCrDrType
    {
        Cr = 0,
        Dr = 1
    }

    public class AccountDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return AccountID; } set { AccountID = value; } }

        [Browsable(false)]
        public long AccountID { get; set; }

        [DisplayName("No.")]
        public long AccountNo { get; set; }

        [DisplayName("Account Name")]
        public string AccountName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        [DisplayName("Balance"), DisplayFormat(DataFormatString = "#")]
        public decimal BalanceAmt { get; set; }

        [Browsable(false)]
        public string State { get; set; }

        [Browsable(false)]
        public string Country { get; set; }

        [DisplayName("Contact Person")]
        public string ContactPerson { get; set; }

        [DisplayName("Mobile No.")]
        public string MobileNo { get; set; }

        [DisplayName("Phone No.")]
        public string PhoneNo { get; set; }

        [DisplayName("E-Mail ID")]
        public string EMailID { get; set; }

        [DisplayName("PAN")]
        public string PAN { get; set; }

        [DisplayName("GSTIN")]
        public string GSTNo { get; set; }

        [DisplayName("Op. Balance")]
        public decimal OpBalAmount { get; set; }

    }

    public class AccountViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return AccountID; } set { AccountID = value; } }

        [Browsable(false)]
        public long AccountID { get; set; }

        [DisplayName("No.")]
        public long AccountNo { get; set; }

        [DisplayName("Account Name")]
        public string AccountName { get; set; }

        [Browsable(false)]
        public long AccountGroupID { get; set; }

        [DisplayName("Default Account")]
        public bool? DefaultAccount { get; set; }

        [DisplayName("Balance"), DisplayFormat(DataFormatString = "#")]
        public decimal BalanceAmt { get; set; }

        //[DisplayName("Print Name")]
        //public string CompanyName { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Post Code")]
        public string PostCode { get; set; }

        [Browsable(false)]
        public long? CityID { get; set; }

        [DisplayName("Contact Person")]
        public string ContactPerson { get; set; }

        [DisplayName("Mobile #")]
        public string MobileNo { get; set; }

        [DisplayName("Phone #")]
        public string PhoneNo { get; set; }

        [DisplayName("E-Mail ID")]
        public string EMailID { get; set; }

        [DisplayName("Website")]
        public string Website { get; set; }

        [DisplayName("PAN")]
        public string PAN { get; set; }

        [DisplayName("GSTIN")]
        public string GSTNo { get; set; }

        public string ServiceTaxNo { get; set; }

        public decimal? CreditLimit { get; set; }

        public int? CreditDays { get; set; }

        public long? PriceListID { get; set; }

        public bool? AllowSendSMS { get; set; }

        [Browsable(false)]
        public long AccountOpeningBalanceID { get; set; }

        [DisplayName("Amount")]
        public decimal OpBalAmount { get; set; }

        [DisplayName("Type")]
        public eCrDrType CrDrType { get; set; }
    }

    public class AccountLookUpListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return AccountID; } set { AccountID = value; } }

        [Browsable(false)]
        public long AccountID { get; set; }

        //[Browsable(false)]
        [DisplayName("No.")]
        public long AccountNo { get; set; }

        [DisplayName("Name")]
        public string AccountName { get; set; }

        //[DisplayName("Company Name")]
        //public string CompanyName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        [Browsable(false)]
        public long? CityID { get; set; }

        [Browsable(false)]
        public long StateID { get; set; }

        //[DisplayName("Balance"), DisplayFormat(DataFormatString = "#,#")]
        //public decimal BalanceAmt { get; set; }

        [DisplayName("Contact Person")]
        public string ContactPerson { get; set; }

        [DisplayName("Mobile No.")]
        public string MobileNo { get; set; }

        [Browsable(false)]
        public string EMailID { get; set; }

        [Browsable(false)]
        public string GSTNo { get; set; }

        [Browsable(false)]
        public bool AllowSendSMS { get; set; }

        [Browsable(false)]
        public long? PriceListID { get; set; }

        [Browsable(false)]
        public eAccountGroupType? AccountGroupType { get; set; }
    }
}
