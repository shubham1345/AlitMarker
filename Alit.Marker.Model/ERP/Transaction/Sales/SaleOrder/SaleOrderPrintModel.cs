using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.ERP.Transaction.Sales.SaleOrder
{
    public class SaleOrderPrintModel
    {
        public Model.Reports.CompanyDetailReportModel CompanyDetail { get; set; }

        public long SaleOrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public long OrderNo { get; set; }

        public long? SaleOrderNoPrefixID { get; set; }

        public string SaleOrderNoPrefixName { get; set; }

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
                if(!String.IsNullOrWhiteSpace(CustomerCityName))
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
        #endregion

        public decimal GrossAmt { get; set; }

        public decimal NetAmt { get; set; }

        public string NetAmtInWords { get; set; }

        public string InvoiceMemo { get; set; }

        public List<SaleOrderProductReportModel> Products { get; set; }

        public List<SaleOrderAdditionReportModel> Additionals { get; set; }
    }

    public class SaleOrderProductReportModel : Model.Reports.TransactionsCommon.ProductDetailBaseReportModel
    {
        public long SaleOrderProductDetailID { get; set; }

        public long? SaleOrderID { get; set; }
    }

    public class SaleOrderAdditionReportModel : Model.Reports.TransactionsCommon.AdditionalDetailBaseReportModel
    {
        public long SaleOrderAdditionalsID { get; set; }

        public long SaleOrderID { get; set; }
        
    }
}
