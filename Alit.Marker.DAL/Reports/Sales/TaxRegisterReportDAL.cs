using Alit.Marker.DAL.Inventory.Masters.StockItemTaxCategory;
using Alit.Marker.DBO;
using Alit.Marker.Model.Reports.Sales;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Reports.Sales
{
    public class TaxRegisterReportDAL
    {
        public List<TaxRegisterReportModel> GenerateReportData(DateTime? DateFrom, DateTime? DateTo)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                StockItemTaxCategoryDAL StockItemTaxCategoryDALObj = new StockItemTaxCategoryDAL();
                int TaxCat1ID = 1;
                tblProductTaxCategory TaxCat1 = db.tblProductTaxCategories.Find(TaxCat1ID);
                string TaxCat1Name = null;
                if (TaxCat1 != null) TaxCat1Name = TaxCat1.ProductTaxCategoryName;
                int TaxCat2ID = 2;
                string TaxCat2Name = null;
                tblProductTaxCategory TaxCat2 = db.tblProductTaxCategories.Find(TaxCat2ID);
                if (TaxCat2 != null) TaxCat2Name = TaxCat2.ProductTaxCategoryName;
                int TaxCat3ID = 3;
                string TaxCat3Name = null;
                tblProductTaxCategory TaxCat3 = db.tblProductTaxCategories.Find(TaxCat3ID);
                if (TaxCat3 != null) TaxCat3Name = TaxCat3.ProductTaxCategoryName;


                var SaleRec = from rTab1 in (from rPD in db.tblSaleInvoiceProductDetails
                                             join rSale in db.tblSaleInvoices on rPD.SaleInvoiceID equals rSale.SaleInvoiceID
                                             join rProduct in db.tblProducts on rPD.ProductID equals rProduct.ProductID
                                             where
                                             (DateFrom == null || rSale.SaleInvoiceDate >= DateFrom) &&
                                               (DateTo == null || rSale.SaleInvoiceDate <= DateTo)
                                             group rPD by new { rPD.SaleInvoiceID, rProduct.HSNCode, rPD.Tax1Perc, rPD.Tax2Perc, rPD.Tax3Perc } into gPD
                                             select new
                                             {
                                                 SaleID = gPD.Key.SaleInvoiceID,
                                                 HSNCode = gPD.Key.HSNCode,
                                                 Perc = gPD.Key.Tax1Perc + gPD.Key.Tax2Perc + gPD.Key.Tax3Perc,
                                                 Amt1 = gPD.Sum(r => r.Tax1Amt),
                                                 Amt2 = gPD.Sum(r => r.Tax2Amt),
                                                 Amt3 = gPD.Sum(r => r.Tax3Amt),
                                                 TaxableAmt = gPD.Sum(r => r.NAmt)
                                             })
                              join rSale in db.tblSaleInvoices on rTab1.SaleID equals rSale.SaleInvoiceID
                              join rCust in db.tblAccounts on rSale.CustomerAccountID equals rCust.AccountID
                              join rCity in db.tblCities on rCust.CityID equals rCity.CityID
                              join jPrefix in db.tblSaleInvoiceNoPrefixes on rSale.SaleInvoiceNoPrefixID equals jPrefix.SaleInvoiceNoPrefixID into gPrefix
                              from rPrefix in gPrefix.DefaultIfEmpty()
                              orderby rSale.SaleInvoiceDate, rPrefix.PrefixName, rSale.SaleInvoiceNo, rCust.AccountName, rTab1.Perc
                              select new TaxRegisterReportModel()
                              {
                                  SaleID = rSale.SaleInvoiceID,
                                  MemoType = (eMemoType)rSale.MemoType,

                                  InvoiceDate = rSale.SaleInvoiceDate,
                                  InvoiceNo = rSale.SaleInvoiceNo,
                                  InvoicePrefixID = rSale.SaleInvoiceNoPrefixID,
                                  InvoicePrefixName = rSale.tblSaleInvoiceNoPrefix.PrefixName,
                                  CustomerID = rSale.CustomerAccountID,
                                  //CustomerNameTitle = rCust.NameTitle,
                                  CustomerName = rCust.AccountName,
                                  CustomerAddress = rCust.Address,
                                  CustomerCityName = rCity.CityName,
                                  CustomerCityStateShortName = rCity.tblState.StateShortName ?? rCity.tblState.StateName,
                                  CustomerCityStateGSTCode = rCity.tblState.GSTCode,
                                  CustomerGSTIN = rCust.GSTNo,

                                  GrossAmt = rSale.GrossAmt,
                                  NetAmt = rSale.NetAmt,

                                  TaxPerc = rTab1.Perc,

                                  HSNCode = rTab1.HSNCode,

                                  TaxCat1Name = TaxCat1Name,
                                  TaxCat2Name = TaxCat2Name,
                                  TaxCat3Name = TaxCat3Name,
                                  Tax1Amt = rTab1.Amt1 ?? 0,
                                  Tax2Amt = rTab1.Amt2 ?? 0,
                                  Tax3Amt = rTab1.Amt3 ?? 0,
                                  TaxableAmt = rTab1.TaxableAmt
                              };

                return SaleRec.ToList();
            }
        }
    }
}
