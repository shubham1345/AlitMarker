using Alit.Marker.DBO;
using Alit.Marker.Model.ERP.Transaction.Sales.SaleReturn;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Transaction.Sales.SaleReturn
{
    public class SaleReturnPrintDAL
    {
        public List<SaleReturnPrintModel> GenerateReportData(long SaleReturnID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return ConvertToModel(db.tblSaleReturns.Where(wr => wr.SaleReturnID == SaleReturnID));
            }
        }

        public List<SaleReturnPrintModel> GenerateReportData(DateTime? DateFrom, DateTime? DateTo, long? CustomerID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return ConvertToModel(db.tblSaleReturns.Where(wr =>
                    (DateFrom == null || wr.SaleReturnDate >= DateFrom) &&
                    (DateTo == null || wr.SaleReturnDate <= DateTo) &&
                    (CustomerID == null || wr.CustomerAccountID == CustomerID)));
            }
        }

        public List<SaleReturnPrintModel> ConvertToModel(IQueryable<tblSaleReturn> SaleReturnRecords)
        {
            List<SaleReturnPrintModel> InvoiceDS = SaleReturnRecords.Select<tblSaleReturn, SaleReturnPrintModel>(r => new SaleReturnPrintModel()
            {
                SaleReturnID = r.SaleReturnID,
                MemoType = (eMemoType)r.MemoType,

                SaleReturnDate = r.SaleReturnDate,
                SaleReturnNo = r.SaleReturnNo,
                ////CustomerID = r.CustomerID,
                ////CustomerNameTitle = r.tblCustomer.NameTitle,
                ////CustomerName = r.tblCustomer.CustomerName,
                ////CompanyName = r.tblCustomer.CustomerCompanyName,
                ////CustomerAddress = r.tblCustomer.Address,
                ////CustomerCityName = r.tblCustomer.tblCity.CityName,
                ////CustomerCityStateShortName = r.tblCustomer.tblCity.tblState.StateShortName ?? r.tblCustomer.tblCity.tblState.StateName,
                ////CustomerCityCountryName = r.tblCustomer.tblCity.tblCountry.CountryName,
                ////CustomerPostCode = r.tblCustomer.PostCode,
                ////CustomerMobileNo = r.tblCustomer.MobileNo,
                ////CustomerPhoneNo = r.tblCustomer.PhoneNo,
                ////CustomerEMailID = r.tblCustomer.EMailID,
                ////CustomerWebsite = r.tblCustomer.Website,
                ////CustomerPAN = r.tblCustomer.PAN,
                ////CustomerGSTNo = r.tblCustomer.GSTNo,
                ////CustomerServiceTaxNo = r.tblCustomer.ServiceTaxNo,

                CustomerID = r.CustomerAccountID,
                //CustomerNameTitle = r.tblAccount.NameTitle,
                CustomerName = r.tblAccount.AccountName,
                //CompanyName = r.tblAccount.CustomerCompanyName,
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

                GrossAmt = r.GrossAmt,
                NetAmt = r.NetAmt,
                NetAmtInWords = "",
                InvoiceMemo = r.SaleReturnMemo,

                Products = r.tblSaleReturnProductDetails.Select<tblSaleReturnProductDetail, SaleReturnProductReportModel>(pr => new SaleReturnProductReportModel()
                {
                    SaleReturnProductDetailID = pr.SaleReturnProductDetailID,
                    SaleReturnID = pr.SaleReturnID,
                    ProductID = pr.ProductID,
                    SNo = pr.SNo,
                    ProductName = (pr.ProductID != null ? pr.tblProduct.ProductName : null),
                    ProductDescr = pr.Descr,
                    Quan = pr.Quan,
                    Rate = pr.Rate,
                    UnitID = pr.UnitID,
                    UnitName = pr.tblUnit.UnitName,
                    DiscPerc = pr.DiscPerc,
                    DiscAmt = pr.DiscAmt,

                    Tax1Perc = pr.Tax1Perc,
                    Tax1Amt = pr.Tax1Amt,
                    Tax1ID = pr.Tax1ID,
                    Tax1Name = pr.tblProduct.tblAdditionalItemMaster.ItemName,

                    Tax2Perc = pr.Tax2Perc,
                    Tax2Amt = pr.Tax2Amt,
                    Tax2ID = pr.Tax2ID,
                    Tax2Name = pr.tblProduct.tblAdditionalItemMaster1.ItemName,

                    Tax3Perc = pr.Tax3Perc,
                    Tax3Amt = pr.Tax3Amt,
                    Tax3ID = pr.Tax3ID,
                    Tax3Name = pr.tblProduct.tblAdditionalItemMaster2.ItemName,

                    GAmt = pr.GAmt,
                    NAmt = pr.NAmt,
                }).ToList(),

                Additionals = r.tblSaleReturnAdditionals.Select<tblSaleReturnAdditional, SaleReturnAdditionReportModel>(ar => new SaleReturnAdditionReportModel()
                {
                    SaleReturnAdditionalsID = ar.SaleReturnAdditionalsID,
                    SaleReturnID = ar.SaleReturnID,
                    AddiotionalID = ar.AdditionalItemID,
                    AdditionalName = ar.tblAdditionalItemMaster.ItemName,
                    Descr = ar.Descr,
                    ItemNature = ((eAdditionalItemNature)ar.ItemNature == eAdditionalItemNature.Less ? "Less" : "Add"),
                    Perc = ar.Perc,
                    Amt = ar.Amt,
                    UpdatedAmt = ar.UpdatedAmt
                }).ToList()
            }).ToList();

            InvoiceDS.ForEach(r =>
            {
                r.CompanyDetail = Model.CommonProperties.LoginInfo.LoggedInCompanyReportModel;
                r.NetAmtInWords = Model.CommonFunctions.NumbersToWords(r.NetAmt);
            });

            return InvoiceDS;
        }

        public List<SaleReturnPrintModel> GetSaleReturnPrintModel(long SaleReturnID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return ConvertToModel(db.tblSaleReturns.Where(wr => wr.SaleReturnID == SaleReturnID));
            }

        }
    }
}