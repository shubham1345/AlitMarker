using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.ERP.Transaction.Sales.SaleInvoice
{
    public class SaleInvoicePrintModel
    {
        public Model.Reports.CompanyDetailReportModel CompanyDetail { get; set; }

        public long FinPerID { get; set; }

        public long SaleInvoiceID { get; set; }

        public eMemoType MemoType { get; set; }

        public DateTime SaleInvoiceDate { get; set; }

        public long SaleInvoiceNo { get; set; }

        public long? SaleInvoiceNoPrefixID { get; set; }

        public string InvoicePrefixName { get; set; }

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
                    add += (add != "" ? ", PIN. " : "") + CustomerPostCode;
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
                string v = "";

                if(!String.IsNullOrWhiteSpace(CustomerPhoneNo))
                {
                    v += (!String.IsNullOrWhiteSpace(v) ? ", " : "") + "Phone : " + CustomerPhoneNo;
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

        public int CustomerStateGSTCode { get; set; }

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

        public string DispatchDocumentNo { get; set; }
        #endregion

        public decimal GrossAmt { get; set; }

        public decimal NetAmt { get; set; }

        public string NetAmtInWords { get; set; }

        public string InvoiceMemo { get; set; }

        public decimal CurrentBalance { get; set; }

        public decimal AdvanceAmt { get; set; }

        public List<SaleInvoiceProductReportModel> Products { get; set; }

        public List<SaleInvoiceAdditionReportModel> Additionals { get; set; }
    }

    public class SaleInvoiceProductReportModel : Model.Reports.TransactionsCommon.ProductDetailBaseReportModel
    {
        public long SaleProductDetailID { get; set; }

        public long? SaleInvoiceID { get; set; }
    }

    public class SaleInvoiceAdditionReportModel : Model.Reports.TransactionsCommon.AdditionalDetailBaseReportModel
    {
        public long SaleAdditionalsID { get; set; }

        public long SaleInvoiceID { get; set; }
    }

    public enum eInvoiceFormats
    {
        None = 0,
        Standard_A4 = 1,
        Standard_A5 = 2,
        Standard_A6 = 3,
        //Professional = 4,
        //Compact = 5
        Customized = -1
    }

    public class SaleInvoicePrintingFormatViewModel
    {
        [Browsable(false)]
        public long SaleInvoicePrintFormatID { get; set; }

        public string FormatName { get; set; }

        public static List<SaleInvoicePrintingFormatViewModel> GetGeneraliseFormatList()
        {
            string[] Names = Enum.GetNames(typeof(eInvoiceFormats));
            int[] Values = Enum.GetValues(typeof(eInvoiceFormats)).Cast<int>().ToArray();
            List<SaleInvoicePrintingFormatViewModel> List = new List<SaleInvoicePrintingFormatViewModel>();
            int length = Names.Length;
            for(int i = 0; i < length; i++)
            {
                if (Values[i] == 0) continue;
                List.Add(new SaleInvoicePrintingFormatViewModel()
                {
                    SaleInvoicePrintFormatID = Values[i],
                    FormatName = Names[i].Replace("_", " ")
                });
            }

            return List;
        }
    }
}
