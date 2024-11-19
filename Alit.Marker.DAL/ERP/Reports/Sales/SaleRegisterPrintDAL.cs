using Alit.Marker.DBO;
using Alit.Marker.Model.ERP.Reports.Sales;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Reports.Sales
{
    public class SaleRegisterPrintDAL
    {
        public List<SaleRegisterPrintModel> GenerateReportData(DateTime? DateFrom, DateTime? DateTo, long? CustomerID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                List<SaleRegisterPrintModel> InvoiceDS = db.tblSaleInvoices.Where(wr =>
                    (DateFrom == null || wr.SaleInvoiceDate >= DateFrom) &&
                    (DateTo == null || wr.SaleInvoiceDate <= DateTo) &&
                    (CustomerID == null || wr.CustomerAccountID == CustomerID)
                    ).OrderBy(r=> r.SaleInvoiceDate).ThenBy(r=> r.SaleInvoiceNo).Select<tblSaleInvoice, SaleRegisterPrintModel>(r => new SaleRegisterPrintModel()
                    {
                        SaleInvoiceID = r.SaleInvoiceID,
                        MemoType = (eMemoType)r.MemoType,

                        SaleInvoiceDate = r.SaleInvoiceDate,
                        SaleInvoiceNo = r.SaleInvoiceNo,
                        SaleInvoiceNoPrefixID = r.SaleInvoiceNoPrefixID,
                        InvoicePrefixName = r.tblSaleInvoiceNoPrefix.PrefixName,
                        CustomerID = r.CustomerAccountID,
                        //CustomerNameTitle = r.tblAccount.NameTitle,
                        CustomerName = r.tblAccount.AccountName,
                        CustomerAddress = r.tblAccount.Address,
                        CustomerCityName = r.tblAccount.tblCity.CityName,
                        CustomerCityStateShortName = r.tblAccount.tblCity.tblState.StateShortName ?? r.tblAccount.tblCity.tblState.StateName,
                        CustomerCityCountryName = r.tblAccount.tblCity.tblCountry.CountryName,
                        CustomerPostCode = r.tblAccount.PostCode,
                        CustomerMobileNo = r.tblAccount.MobileNo,
                        CustomerPhoneNo = r.tblAccount.PhoneNo,
                        CustomerEMailID = r.tblAccount.EMailID,
                        CustomerWebsite = r.tblAccount.Website,
                        CustomerPAN = r.tblAccount.PAN,
                        CustomerGSTNo = r.tblAccount.GSTNo,
                        CustomerServiceTaxNo = r.tblAccount.ServiceTaxNo,

                        ChallanNo = r.ChallanNo,
                        ChallanDate = r.ChallanDate,
                        OrderNo = r.OrderNo,
                        OrderDate = r.OrderDate,
                        SuppRefNo = r.SupplRefNo,
                        OtherRefNo = r.OtherRefNo,
                        TransportID = r.TransportID,
                        TransportName = r.tblTransport.TransportName,
                        NoPackets = r.NofPackets,
                        Destination = r.Destination,
                        DeliveryDate = r.DeliveryDate,
                        GrossAmt = r.GrossAmt,
                        NetAmt = r.NetAmt,
                        NetAmtInWords = "",
                        InvoiceMemo = r.InvoiceMemo,

                        //Products = r.tblSaleInvoiceProductDetails.Select<tblSaleInvoiceProductDetail, SaleInvoiceProductReportModel>(pr => new SaleInvoiceProductReportModel()
                        //{
                        //    SaleProductDetailID = pr.SaleProductDetailID,
                        //    SaleInvoiceID = pr.SaleInvoiceID,
                        //    ProductID = pr.ProductID,
                        //    SNo = pr.SNo,
                        //    ProductName = (pr.ProductID != null ? pr.tblProduct.ProductName : null),
                        //    ProductDescr = pr.Descr,
                        //    Quan = pr.Quan,
                        //    Rate = pr.Rate,
                        //    UnitID = pr.UnitID,
                        //    UnitName = pr.tblUnit.UnitName,
                        //    DiscPerc = pr.DiscPerc,
                        //    DiscAmt = pr.DiscAmt,
                        //    TaxPerc = pr.TaxPerc,
                        //    TaxAmt = pr.TaxAmt,
                        //    TaxID = pr.TaxID,
                        //    TaxName = pr.tblProduct.tblAdditionalItemMaster.ItemName,
                        //    GAmt = pr.GAmt,
                        //    NAmt = pr.NAmt
                        //}).ToList(),

                        //Additionals = r.tblSaleInvoiceAdditionals.Select<tblSaleInvoiceAdditional, SaleInvoiceAdditionReportModel>(ar => new SaleInvoiceAdditionReportModel()
                        //{
                        //    SaleAdditionalsID = ar.SaleAdditionalsID,
                        //    SaleInvoiceID = ar.SaleInvoiceID,
                        //    AddiotionalID = ar.AdditionalItemID,
                        //    AdditionalName = ar.tblAdditionalItemMaster.ItemName,
                        //    Descr = ar.Descr,
                        //    ItemNature = ((Model.Sales.eAdditionalItemNature)ar.ItemNature == Model.Sales.eAdditionalItemNature.Less ? "Less" : "Add"),
                        //    Perc = ar.Perc,
                        //    Amt = ar.Amt,
                        //    UpdatedAmt = ar.UpdatedAmt
                        //}).ToList()
                    }).ToList();

                //InvoiceDS.ForEach(r =>
                //{
                //    r.CompanyDetail = Model.CommonProperties.LoginInfo.LoggedInCompanyReportModel;
                //    r.NetAmtInWords = Model.CommonFunctions.NumbersToWords(r.NetAmt);
                //});

                return InvoiceDS;
            }
        }
    }
}
