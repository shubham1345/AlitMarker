using Alit.Marker.DBO;
using Alit.Marker.Model.ERP.Transaction.Sales.SaleInvoice;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Transaction.Sales.SaleInvoice
{
    public class SaleInvoicePrintDAL
    {
        public List<SaleInvoicePrintModel> GenerateReportData(long SaleInvoiceID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return ConvertToModel(db.tblSaleInvoices.Where(wr => wr.SaleInvoiceID == SaleInvoiceID), db);
            }
        }

        public List<SaleInvoicePrintModel> GenerateReportData(DateTime? DateFrom, DateTime? DateTo, long? CustomerID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return ConvertToModel(db.tblSaleInvoices.Where(wr =>
                    (DateFrom == null || wr.SaleInvoiceDate >= DateFrom) &&
                    (DateTo == null || wr.SaleInvoiceDate <= DateTo) &&
                    (CustomerID == null || wr.CustomerAccountID == CustomerID)).OrderByDescending(r=> r.SaleInvoiceDate).ThenByDescending(r=> r.SaleInvoiceNo), db);
            }
        }

        public List<SaleInvoicePrintModel> ConvertToModel(IQueryable<tblSaleInvoice> SaleInvoiceRecords, dbMarkerEntities db)
        {
            List<SaleInvoicePrintModel> InvoiceDS = SaleInvoiceRecords.Select<tblSaleInvoice, SaleInvoicePrintModel>(r => new SaleInvoicePrintModel()
            {
                FinPerID = r.FinPeriodID,
                SaleInvoiceID = r.SaleInvoiceID,
                MemoType = (eMemoType)r.MemoType,

                SaleInvoiceDate = r.SaleInvoiceDate,
                SaleInvoiceNo = r.SaleInvoiceNo,
                SaleInvoiceNoPrefixID = r.SaleInvoiceNoPrefixID,
                InvoicePrefixName = r.tblSaleInvoiceNoPrefix.PrefixName,

                //CustomerID = r.CustomerID,
                //CustomerNameTitle = r.tblCustomer.NameTitle,
                //CustomerName = r.tblCustomer.CustomerName,
                //CompanyName = r.tblCustomer.CustomerCompanyName,
                //CustomerAddress = r.tblCustomer.Address,
                //CustomerCityName = r.tblCustomer.tblCity.CityName,
                //CustomerCityStateShortName = r.tblCustomer.tblCity.tblState.StateShortName ?? r.tblCustomer.tblCity.tblState.StateName,
                //CustomerCityCountryName = r.tblCustomer.tblCity.tblCountry.CountryName,
                //CustomerPostCode = r.tblCustomer.PostCode,
                //CustomerMobileNo = r.tblCustomer.MobileNo,
                //CustomerPhoneNo = r.tblCustomer.PhoneNo,
                //CustomerEMailID = r.tblCustomer.EMailID,
                //CustomerWebsite = r.tblCustomer.Website,
                //CustomerPAN = r.tblCustomer.PAN,
                //CustomerGSTNo = r.tblCustomer.GSTNo,
                //CustomerServiceTaxNo = r.tblCustomer.ServiceTaxNo,
                //CustomerStateGSTCode = r.tblCustomer.tblCity.tblState.GSTCode ?? 0,

                CustomerID = r.CustomerAccountID,
                //CustomerNameTitle = r.tblAccount.NameTitle,
                CustomerName = r.tblAccount.AccountName,
                CompanyName = r.tblAccount.tblCompany.CompanyName,
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
                CustomerStateGSTCode = r.tblAccount.tblCity.tblState.GSTCode ?? 0,

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
                DispatchDocumentNo = r.DispDocNo,

                GrossAmt = r.GrossAmt,
                NetAmt = r.NetAmt,
                NetAmtInWords = "",
                InvoiceMemo = r.InvoiceMemo,
                AdvanceAmt = r.AdvanceAmt ?? 0,

                Products = r.tblSaleInvoiceProductDetails.Select<tblSaleInvoiceProductDetail, SaleInvoiceProductReportModel>(pr => new SaleInvoiceProductReportModel()
                {
                    SaleProductDetailID = pr.SaleInvoiceProductDetailID,
                    SaleInvoiceID = pr.SaleInvoiceID,
                    ProductID = pr.ProductID,
                    SNo = pr.SNo+1,
                    HSNCode = (pr.tblProduct != null ? pr.tblProduct.HSNCode : ""),
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

                Additionals = r.tblSaleInvoiceAdditionals.Select<tblSaleInvoiceAdditional, SaleInvoiceAdditionReportModel>(ar => new SaleInvoiceAdditionReportModel()
                {
                    SaleAdditionalsID = ar.SaleInvoiceAdditionalsID,
                    SaleInvoiceID = ar.SaleInvoiceID,
                    AddiotionalID = ar.AdditionalItemID,
                    AdditionalName = ar.tblAdditionalItemMaster.ItemName,
                    Descr = ar.Descr,
                    ItemNature = ((eAdditionalItemNature)ar.ItemNature == eAdditionalItemNature.Less ? "Less" : "Add"),
                    Perc = ar.Perc,
                    Amt = ar.Amt,
                    UpdatedAmt = ar.UpdatedAmt
                }).ToList()
            }).ToList();

            string TaxCat1Name = "", TaxCat2Name = "", TaxCat3Name = "";

            var TaxCat1 = db.tblProductTaxCategories.Find(1);
            if(TaxCat1 != null)
            {
                TaxCat1Name = TaxCat1.ProductTaxCategoryName;
            }

            var TaxCat2 = db.tblProductTaxCategories.Find(2);
            if (TaxCat2 != null)
            {
                TaxCat2Name = TaxCat2.ProductTaxCategoryName;
            }

            var TaxCat3 = db.tblProductTaxCategories.Find(3);
            if (TaxCat3 != null)
            {
                TaxCat3Name = TaxCat3.ProductTaxCategoryName;
            }
            InvoiceDS.ForEach(r => r.Products.ForEach(p => { p.Tax1Name = TaxCat1Name; p.Tax2Name = TaxCat2Name; p.Tax3Name = TaxCat3Name; }));

            DAL.Settings.FinancialPeriod.FinPeriodDAL FinPerDALObj = new Settings.FinancialPeriod.FinPeriodDAL();

            InvoiceDS.ForEach(r =>
            {
                r.CompanyDetail = Model.CommonProperties.LoginInfo.LoggedInCompanyReportModel;
                r.NetAmtInWords = Model.CommonFunctions.NumbersToWords(r.NetAmt);
                r.CurrentBalance = FinPerDALObj.GetCustomerClosingBalance(r.CustomerID, r.SaleInvoiceDate, r.CompanyDetail.CompanyID, r.FinPerID);
            });

            return InvoiceDS;
        }

        public List<SaleInvoicePrintModel> GetSaleInvoicePrintModel(long SaleInvoiceID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return ConvertToModel(db.tblSaleInvoices.Where(wr => wr.SaleInvoiceID == SaleInvoiceID), db);
            }

        }
    }
}