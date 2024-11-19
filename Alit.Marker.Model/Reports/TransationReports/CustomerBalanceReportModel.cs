using Alit.Marker.Model.Template.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Reports.TransationReports
{
    public class CustomerBalanceReportModel : IReportViewModel
    {
        public long PrimeKeyID
        {
            get
            {
                return CustomerID;
            }

            set
            {
                CustomerID = value;
            }
        }

        public bool Select { get; set; }

        [Browsable(false)]
        public long CustomerID { get; set; }

        [DisplayName("No.")]
        public long CustomerNo { get; set; }

        [DisplayName("Title")]
        public string CustomerNameTitle { get; set; }

        [DisplayName("Name")]
        public string CustomerName { get; set; }

        [DisplayName("Company")]
        public string CompanyName { get; set; }

        [DisplayName("Name")]
        public string CustomerNameWithTitle
        {
            get
            {
                string cname = CustomerNameTitle;
                if (cname != "") cname += " ";
                cname += CustomerName;
                return cname;
            }
        }

        [DisplayName("Address")]
        public string CustomerAddress { get; set; }

        [DisplayName("City")]
        public string CustomerCityName { get; set; }

        [DisplayName("State")]
        public string CustomerCityStateShortName { get; set; }

        [DisplayName("Country")]
        public string CustomerCityCountryName { get; set; }

        [DisplayName("PIN")]
        public string CustomerPostCode { get; set; }

        [DisplayName("Address")]
        public string CustomerAddressDetail
        {
            get
            {
                string add = CustomerAddress;
                if (!String.IsNullOrWhiteSpace(CustomerCityName))
                {
                    add += (add != "" ? ", " : "") + CustomerCityName;
                }

                //if (!String.IsNullOrWhiteSpace(CustomerCityStateShortName))
                //{
                //    add += (add != "" ? ", " : "") + CustomerCityStateShortName;
                //}
                //if (!String.IsNullOrWhiteSpace(CustomerCityCountryName))
                //{
                //    add += (add != "" ? ", " : "") + CustomerCityCountryName;
                //}

                //if (!String.IsNullOrWhiteSpace(CustomerPostCode))
                //{
                //    add += (add != "" ? ", PO" : "") + CustomerPostCode;
                //}

                return add;
            }
        }

        [DisplayName("Mobile")]
        public string CustomerMobileNo { get; set; }

        [DisplayName("Phone")]
        public string CustomerPhoneNo { get; set; }

        [DisplayName("Email ID")]
        public string CustomerEMailID { get; set; }

        [DisplayName("Website")]
        public string CustomerWebsite { get; set; }

        [DisplayName("PAN")]
        public string CustomerPAN { get; set; }

        [DisplayName("GSTIN")]
        public string CustomerGSTNo { get; set; }

        [DisplayName("Service Tax No.")]
        public string CustomerServiceTaxNo { get; set; }

        [DisplayName("Opening Balance")]
        public decimal OpeningBalance { get; set; }

        [DisplayName("Sale")]
        public decimal SaleAmt { get; set; }

        [DisplayName("S/R")]
        public decimal SaleReturnAmt { get; set; }

        [DisplayName("Purchase")]
        public decimal PurchaseAmt { get; set; }

        [DisplayName("P/R")]
        public decimal PurchaseReturnAmt { get; set; }

        [DisplayName("Received")]
        public decimal RecieptAmt { get; set; }

        [DisplayName("Paid")]
        public decimal PaymentAmt { get; set; }

        [DisplayName("Closing Balance")]
        public decimal ClosingBalance
        {
            get
            {
                return OpeningBalance + SaleAmt - SaleReturnAmt - PurchaseAmt + PurchaseReturnAmt - RecieptAmt + PaymentAmt;
            }
        }

       
    }
}
