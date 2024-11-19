using Alit.Marker.DAL.Template.Report;
using Alit.Marker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template.Report;
using Alit.Marker.DBO;
using Alit.Marker.Model.Inventory.Reports;

namespace Alit.Marker.DAL.Reports.Inventory
{
    public class StockLedgerDAL : IReportDAL
    {
        public IEnumerable<IReportViewModel> GetReportData()
        {
            return GetReportData(null);
        }

        public IEnumerable<IReportViewModel> GetReportData(params object[] FilterParas)
        {
            long ProductID = 0;
            DateTime DateFrom = DateTime.Now.Date;
            DateTime? DateTo = null;

            // customer and date from is required
            if (FilterParas == null || FilterParas.Length < 2)
            {
                return null;
            }
            ProductID = (long)FilterParas[0];

            if (FilterParas.Length >= 2)
            {
                DateFrom = (DateTime)FilterParas[1];
            }
            if (FilterParas.Length >= 3)
            {
                DateTo = (DateTime?)FilterParas[2];
            }
            if (DateTo != null)
            {
                DateTo = DateTo.Value.Date.Add(new TimeSpan(23, 59, 59));
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                int VTID_SaleInvoice = (int)Model.Inventory.eStockVoucherType.SaleInvoice;
                int VTID_SaleReturn = (int)Model.Inventory.eStockVoucherType.SaleReturn;
                int VTID_Purchase = (int)Model.Inventory.eStockVoucherType.PurchaseBill;
                int VTID_PurchaseReturn = (int)Model.Inventory.eStockVoucherType.PurchaseReturn;

                /// Entered Date From value lies in which financial Period, we are picking that fin per DateFrom. So that we don't have to calculate the whole data, we just need to pick data from the fin per where entered date from lies. Then we have to sum all data which's date < DateFrom, this way we can calculate Opening stock.
                long? DateFromFinPerID = null;
                DateTime? DateFromFinPerStartDate = null;
                if (DateFrom != null)
                {
                    var fp = db.tblFinPeriods.Where(r => r.FinPeriodFrom <= DateFrom && (r.FinPeriodTo == null || r.FinPeriodTo >= DateFrom)).OrderBy(r=> r.FinPeriodFrom).FirstOrDefault();
                    if(fp != null)
                    {
                        DateFromFinPerID = fp.FinPeriodID;
                        DateFromFinPerStartDate = fp.FinPeriodFrom;
                    }
                }

                var res = (from r in db.tblStockPDetails

                           join s in db.tblStocks on r.StockVoucherID equals s.VoucherID
                           join svtype in db.tblStockVoucherTypes on s.StockVoucherTypeID equals svtype.StockVoucherTypeID
                           //join p in db.tblProducts on r.ProductID equals p.ProductID
                           //join u in db.tblUnits on p.UnitID equals u.UnitID

                           join jsale in db.tblSaleInvoices on new { VTypeID = s.StockVoucherTypeID, VoucherID = s.VoucherID } equals new { VTypeID = VTID_SaleInvoice, VoucherID = (long)jsale.StockVoucherID } into gsale
                           from sale in gsale.DefaultIfEmpty()

                           join jsaleret in db.tblSaleReturns on new { VTypeID = s.StockVoucherTypeID, VoucherID = s.VoucherID } equals new { VTypeID = VTID_SaleReturn, VoucherID = (long)jsaleret.StockVoucherID } into gsaleret
                           from saleret in gsaleret.DefaultIfEmpty()

                           join jpur in db.tblPurchaseBills on new { VTypeID = s.StockVoucherTypeID, VoucherID = s.VoucherID } equals new { VTypeID = VTID_Purchase, VoucherID = (long)jpur.StockVoucherID } into gpur
                           from pur in gpur.DefaultIfEmpty()

                           join jpurret in db.tblPurchaseReturns on new { VTypeID = s.StockVoucherTypeID, VoucherID = s.VoucherID } equals new { VTypeID = VTID_PurchaseReturn, VoucherID = (long)jpurret.StockVoucherID } into gpurret
                           from purret in gpurret.DefaultIfEmpty()

                           where
                           //SelectedProductIDs.Contains(r.ProductID) &&
                           r.ProductID == ProductID &&
                           //(DateFrom == null || s.VDate >= DateFrom) &&
                           (DateTo == null || s.VDate <= DateTo) &&
                           s.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                           (DateFromFinPerStartDate == null || s.VDate >= DateFromFinPerStartDate)

                           select new StockLedgerReportModel()
                           {
                               VoucherTypeID = s.StockVoucherTypeID,
                               VoucherTypePRT = svtype.StockVoucherDisplayPrt,
                               VoucherTypeName = svtype.StockVoucherName,
                               ProductID = r.ProductID,
                               Narration = s.Narration,
                               //PCode = p.PCode,
                               //ProductName = p.ProductName,
                               //UnitName = u.UnitName,

                               VDate = s.VDate,
                               VNo = s.VNo,
                               QtyIn = (r.Qty > 0 ? r.Qty : 0),
                               QtyOut = (r.Qty < 0 ? Math.Abs(r.Qty) : 0),
                               Rate = r.Rate,
                               CustomerID = (s.StockVoucherTypeID == VTID_SaleInvoice && sale != null ? (long?)sale.CustomerAccountID :
                                             (s.StockVoucherTypeID == VTID_SaleReturn && saleret != null ? (long?)saleret.CustomerAccountID :
                                             (s.StockVoucherTypeID == VTID_Purchase && pur != null ? (long?)pur.CustomerAccountID :
                                             (s.StockVoucherTypeID == VTID_PurchaseReturn && purret != null ? (long?)purret.CustomerAccountID : null)))),
                               FinPerID = s.FinPeriodID
                           }).ToList();
                
                var ExistingCustomerIDs = (from r in res where DateFrom == null || r.VDate >= DateFrom group r by r.CustomerID into gr select gr.Key).ToArray();

                var customers = (from c in db.tblCustomers
                           join City in db.tblCities on c.CityID equals City.CityID
                           where ExistingCustomerIDs.Contains(c.CustomerID)
                           select new { CustomerID = c.CustomerID, CustomerName = c.CustomerName, CityName = City.CityName }).ToList();

                foreach (var cid in ExistingCustomerIDs)
                {
                    var cust = customers.Find(r => r.CustomerID == cid);
                    if (cust != null)
                    {
                        var records = res.FindAll(r => r.CustomerID == cid);
                        foreach(var r in records)
                        {
                            r.CustomerName = cust.CustomerName;
                            if(!String.IsNullOrWhiteSpace(cust.CityName))
                            {
                                r.CustomerName += (!String.IsNullOrWhiteSpace(r.CustomerName) ? ", " : "") + cust.CityName;
                            }
                        }
                    }
                }

                var Products = (from r in res group r by new { r.ProductID, r.FinPerID } into gr select new { gr.Key.ProductID, gr.Key.FinPerID });

                foreach(var p in Products)
                {
                    if(DateFrom != null && DateFromFinPerID != null && p.FinPerID == DateFromFinPerID)
                    {
                        decimal OpStock = (from r in res
                                           where r.VDate < DateFrom &&
                                           r.ProductID == p.ProductID
                                           select r.QtyIn - r.QtyOut).Sum(srr => (decimal?)srr) ?? 0;

                        if(OpStock != 0)
                        {
                            var ExistingRecord = res.FirstOrDefault(r => r.ProductID == p.ProductID);
                            if (ExistingRecord != null)
                            {
                                res.RemoveAll(r => r.ProductID == p.ProductID && r.VDate < DateFrom);
                                res.Add(new StockLedgerReportModel()
                                {
                                    VoucherTypeID = (int)Model.Inventory.eStockVoucherType.OpeningStock,
                                    VoucherTypePRT = 0,
                                    VoucherTypeName = "Opening Stock",
                                    ProductID = p.ProductID,
                                    //PCode = ExistingRecord.PCode,
                                    //ProductName = ExistingRecord.ProductName,
                                    //UnitName = ExistingRecord.UnitName,
                                    VDate = DateFrom,
                                    VNo = 0,
                                    QtyIn = (OpStock > 0 ? OpStock : 0),
                                    QtyOut = (OpStock < 0 ? Math.Abs(OpStock) : 0),
                                    Rate = 0,
                                    CustomerID = null,
                                    FinPerID = DateFromFinPerID.Value
                                });
                            }
                        }
                    }
                    var records = res.Where(r => r.ProductID == p.ProductID && r.FinPerID == p.FinPerID).OrderBy(r => r.VDate).ThenBy(r => r.VoucherTypePRT).ThenBy(r => r.VNo);

                    decimal RunningStock = 0;
                    foreach(var sr in records)
                    {
                        RunningStock += (sr.QtyIn - sr.QtyOut);
                        sr.RunningStock = RunningStock;
                    }
                }

                return res;
            }
        }

        public static int ParseInt(string strValue)
        {
            int v = 0;
            int.TryParse(strValue, out v);
            return v;
        }

    }
}
