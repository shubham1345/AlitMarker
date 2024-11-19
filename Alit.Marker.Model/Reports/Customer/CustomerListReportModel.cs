using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Reports.Customer
{
    public class CustomerListReportModel
    {
        public long CustomerID { get; set; }

        [DisplayName("No.")]
        public long CustomerNo { get; set; }

        public string CustomerNameTitle { get; set; }

        public string CustomerName { get; set; }

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

        public string CompanyName { get; set; }

        public string CustomerPrintName
        {
            get { return (CompanyName != null && !String.IsNullOrWhiteSpace(CompanyName) ? CompanyName : CustomerNameWithTitle); }
        }

        public string CustomerAddress { get; set; }

        public string CustomerCityName { get; set; }

        public string CustomerCityStateShortName { get; set; }

        public string CustomerCityCountryName { get; set; }

        public string CustomerPostCode { get; set; }

        public string CustomerAddressDetail
        {
            get
            {
                string add = CustomerAddress.Trim();
                if (!String.IsNullOrWhiteSpace(CustomerCityName))
                {
                    add += (add != "" ? ", " : "") + CustomerCityName;
                }

                if (!String.IsNullOrWhiteSpace(CustomerCityStateShortName))
                {
                    add += (add != "" ? ", " : "") + CustomerCityStateShortName;
                }
                //if (!String.IsNullOrWhiteSpace(CustomerCityCountryName))
                //{
                //    add += (add != "" ? ", " : "") + CustomerCityCountryName;
                //}

                if (!String.IsNullOrWhiteSpace(CustomerPostCode))
                {
                    add += (add != "" ? ", PO" : "") + CustomerPostCode;
                }

                return add;
            }
        }

        public string CustomerMobileNo { get; set; }

        public string CustomerPhoneNo { get; set; }

        public string CustomerEMailID { get; set; }

        public string CustomerContactDetails
        {
            get
            {
                return "";
            }
        }

        public string CustomerWebsite { get; set; }

        public string CustomerPAN { get; set; }

        public string CustomerGSTNo { get; set; }

        public string CustomerServiceTaxNo { get; set; }
    }
}
