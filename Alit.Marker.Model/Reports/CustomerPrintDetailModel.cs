using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Reports
{
    public class CustomerPrintDetailModel
    {
        public long CustomerID { get; set; }

        public long CustomerNo { get; set; }

        public string CustomerNameTitle { get; set; }

        public string CustomerName { get; set; }

        public string CompanyName { get; set; }

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

        public string CustomerAddress { get; set; }

        public string CustomerCityName { get; set; }

        public string CustomerCityStateShortName { get; set; }

        public int? CustomerCityStateGSTCode { get; set; }

        public string CustomerCityStateShortNameWithGSTCode
        {
            get
            {
                return (CustomerCityStateGSTCode ?? 0).ToString() + " - " + CustomerCityStateShortName;
            }
        }

        public string CustomerCityCountryName { get; set; }

        public string CustomerPostCode { get; set; }

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

        public string CustomerMobileNo { get; set; }

        public string CustomerPhoneNo { get; set; }

        public string CustomerEMailID { get; set; }

        public string CustomerContactDetails
        {
            get
            {
                string v = "";
                if(!String.IsNullOrWhiteSpace(CustomerPhoneNo))
                {
                    v += (!String.IsNullOrWhiteSpace(v) ? ", " : "") + "Ph : " + CustomerPhoneNo;
                }
                if (!String.IsNullOrWhiteSpace(CustomerMobileNo))
                {
                    v += (!String.IsNullOrWhiteSpace(v) ? ", " : "") + "Mob : " + CustomerMobileNo;
                }
                return v;
            }
        }

        public string CustomerWebsite { get; set; }

        public string CustomerPAN { get; set; }

        public string CustomerGSTNo { get; set; }

        public string CustomerServiceTaxNo { get; set; }

        public decimal CustomerBalance { get; set; }

    }
}
