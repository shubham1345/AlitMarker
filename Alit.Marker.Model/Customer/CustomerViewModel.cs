using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Customer
{
    public class CustomerDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return CustomerID; } set { CustomerID = value; } }

        [Browsable(false)]
        public long CustomerID { get; set; }

        [Browsable(false)]
        public long? OpeningBalanceID { get; set; }

        [DisplayName("No.")]
        public long CustomerNo { get; set; }

        [DisplayName("Title")]
        public string CustomerNameTitle { get; set; }

        [DisplayName("Party Name")]
        public string CustomerName { get; set; }

        [DisplayName("Print Name")]
        public string CompanyName { get; set; }

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
    }

    public class CustomerViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return CustomerID; } set { CustomerID = value; } }

        [Browsable(false)]
        public long CustomerID { get; set; }

        [DisplayName("No.")]
        public long CustomerNo { get; set; }

        [DisplayName("Title")]
        public string NameTitle { get; set; }

        [DisplayName("Party Name")]
        public string CustomerName { get; set; }

        [DisplayName("Print Name")]
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string PostCode { get; set; }

        public long CityID { get; set; }

        [DisplayName("Contact Person")]
        public string ContactPerson { get; set; }

        [DisplayName("Mobile #")]
        public string MobileNo { get; set; }

        [DisplayName("Phone #")]
        public string PhoneNo { get; set; }

        [DisplayName("E-Mail ID")]
        public string EMailID { get; set; }


        public string Website { get; set; }

        [DisplayName("PAN")]
        public string PAN { get; set; }

        [DisplayName("GSTIN")]
        public string GSTNo { get; set; }

        public string ServiceTaxNo { get; set; }

        public decimal CreditLimit { get; set; }

        public int CreditDays { get; set; }

        public long? PriceListID { get; set; }

        public bool AllowSendSMS { get; set; }
    }

    public class CustomerLookUpListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return CustomerID; } set { CustomerID = value; } }

        [Browsable(false)]
        public long CustomerID { get; set; }

        //[Browsable(false)]
        [DisplayName("No.")]
        public long CustomerNo { get; set; }

        [DisplayName("Title")]
        public string CustomerNameTitle { get; set; }

        [DisplayName("Name")]
        public string CustomerName { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        [Browsable(false)]
        public long CityID { get; set; }

        [Browsable(false)]
        public long StateID { get; set; }

        [DisplayName("Balance"), DisplayFormat(DataFormatString = "#,#")]
        public decimal BalanceAmt { get; set; }

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
    }
}
