using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.ERP.Reports.Sales
{
    public class SaleRegisterPrintModel
    {
        public long SaleInvoiceID { get; set; }

        public eMemoType MemoType { get; set; }

        public DateTime SaleInvoiceDate { get; set; }

        public long SaleInvoiceNo { get; set; }

        public long? SaleInvoiceNoPrefixID { get; set; }

        public string InvoicePrefixName { get; set; }

        public string InvoiceNoWithPrfSuf
        {
            get
            {
                string InvNo = InvoicePrefixName ?? "";
                InvNo += (InvNo.Length > 0 ? "/" : "") + SaleInvoiceNo.ToString();
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

        public string CustomerNameAddressCity
        {
            get
            {
                string v = CustomerName;
                v += (v != "" && CustomerAddress != "" ? ", " : "") + CustomerAddress;
                v += (v != "" && CustomerCityName != "" ? ", " : "") + CustomerCityName;
                return v;
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
        #endregion

        #region Challan & Order
        public string ChallanNo { get; set; }

        public DateTime? ChallanDate { get; set; }

        public string OrderNo { get; set; }

        public DateTime? OrderDate { get; set; }

        public string SuppRefNo { get; set; }

        public string OtherRefNo { get; set; }
        #endregion

        #region Transport
        public long? TransportID { get; set; }

        public string TransportName { get; set; }

        public string NoPackets { get; set; }

        public string Destination { get; set; }

        public DateTime? DeliveryDate { get; set; }
        #endregion

        public decimal GrossAmt { get; set; }

        public decimal NetAmt { get; set; }

        public string NetAmtInWords { get; set; }

        public string InvoiceMemo { get; set; }


    }
}
