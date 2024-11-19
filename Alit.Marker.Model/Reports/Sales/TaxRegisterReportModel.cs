using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Reports.Sales
{
    public class TaxRegisterReportModel
    {
        public long SaleID { get; set; }

        public eMemoType MemoType { get; set; }

        public DateTime InvoiceDate { get; set; }

        public long InvoiceNo { get; set; }

        public long? InvoicePrefixID { get; set; }

        public string InvoicePrefixName { get; set; }

        public string InvoiceNoWithPrfSuf
        {
            get
            {
                string InvNo = InvoicePrefixName ?? "";
                InvNo += InvoiceNo.ToString(); //gPD.Sum(r=> r.Tax1Amt),
                return InvNo;
            }
        }

        #region Customer Information
        public long CustomerID { get; set; }

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

        public string CustomerNameCityStateName
        {
            get
            {

                string cname = CustomerNameTitle;
                if (cname != "") cname += " ";
                cname += CustomerName;


                if (!String.IsNullOrWhiteSpace(CustomerCityName))
                {
                    cname += (cname != "" ? ", " : "") + CustomerCityName;
                }

                if (!String.IsNullOrWhiteSpace(CustomerCityStateShortName))
                {
                    cname += (cname != "" ? ", " : "") + CustomerCityStateShortName;
                }
                return cname;
            }
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
                string add = CustomerAddress;
                if (!String.IsNullOrWhiteSpace(CustomerCityName))
                {
                    add += (add != "" ? ", " : "") + CustomerCityName;
                }

                if (!String.IsNullOrWhiteSpace(CustomerCityStateShortName))
                {
                    add += (add != "" ? ", " : "") + CustomerCityStateShortName;
                }
                if (!String.IsNullOrWhiteSpace(CustomerCityCountryName))
                {
                    add += (add != "" ? ", " : "") + CustomerCityCountryName;
                }

                if (!String.IsNullOrWhiteSpace(CustomerPostCode))
                {
                    add += (add != "" ? ", PO" : "") + CustomerPostCode;
                }

                return add;
            }
        }

        public string CustomerGSTIN { get; set; }

        public int? CustomerCityStateGSTCode { get; set; }
        public string CustomerCityStateShortNameWithGSTCode
        {
            get
            {
                return (CustomerCityStateGSTCode ?? 0).ToString() + CustomerCityStateShortName;
            }
        }
    
        #endregion

        public string HSNCode { get; set; }

        public decimal GrossAmt { get; set; }

        public decimal NetAmt { get; set; }

        public decimal TaxPerc { get; set; }

        public string TaxCat1Name { get; set; }
        public string TaxCat2Name { get; set; }
        public string TaxCat3Name { get; set; }

        public decimal Tax1Amt { get; set; }

        public decimal Tax2Amt { get; set; }

        public decimal Tax3Amt { get; set; }

        public decimal TaxableAmt { get; set; }
    }
}
