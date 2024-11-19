using Alit.Marker.DAL.Template.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template.Report;
using Alit.Marker.Model.Inventory;
using Alit.Marker.DBO;
using Alit.Marker.Model.Inventory.Reports;

namespace Alit.Marker.DAL.Inventory.Reports
{
    public class StockInHandDAL : IReportDAL
    {
        public IEnumerable<IReportViewModel> GetReportData()
        {
            return GetReportData(null);
        }

        public IEnumerable<IReportViewModel> GetReportData(params object[] FilterParas)
        {
            DateTime? DateFrom = null;
            DateTime? DateTo = null;
            int count = 0;

            if (FilterParas != null)
            {
                if (FilterParas.Count() > count && FilterParas[count] != null && FilterParas[count] is DateTime)
                {
                    DateFrom = (DateTime)FilterParas[count];
                    count++;
                }
                if (FilterParas.Count() > count && FilterParas[count] != null && FilterParas[count] is DateTime)
                {
                    DateTo = (DateTime)FilterParas[count];
                    count++;
                }
            }
            if (DateFrom == null || DateTo == null)
            {
                return new List<Model.Inventory.Reports.StockInHandReportModel>();
            }
            else
            {
                return GetReportData(DateFrom.Value, DateTo.Value);
            }
        }

        public IEnumerable<IReportViewModel> GetReportData(DateTime DateFrom, DateTime DateTo)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
              
                var financialPeriods = (from fin in db.tblFinPeriods

                                        where fin.CompanyID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.CompanyID
                                                         && (fin.FinPeriodFrom <= DateTo)
                                                         && (fin.FinPeriodTo == null || fin.FinPeriodTo >= DateFrom)
                                        select new
                                        {
                                            FinPeriodFrom = fin.FinPeriodFrom,
                                            FinPeriodTo = fin.FinPeriodTo,
                                            FinPeriodID = fin.FinPeriodID,
                                        }).ToList();

                if (financialPeriods == null || financialPeriods.Count == 0 || financialPeriods.Count > 1)
                {
                    return new List<StockInHandReportModel>();
                }
                var financialPeriod = financialPeriods.First();

                var OpeningStock = from r in db.tblStockPDetails

                                   join s in db.tblStocks on r.StockVoucherID equals s.VoucherID

                                   where s.VDate < DateFrom && s.VDate >= financialPeriod.FinPeriodFrom
                                         || (s.FinPeriodID == financialPeriod.FinPeriodID && s.StockVoucherTypeID == (byte)eStockVoucherType.OpeningStock)

                                   group r by new { r.ProductID } into gr

                                   select new
                                   {
                                       ProductID = gr.Key.ProductID,
                                       Quantity = gr.Sum(r => (decimal?)r.Qty)
                                   };

                var TransactionSummary = from r in db.tblStockPDetails

                                         join s in db.tblStocks on r.StockVoucherID equals s.VoucherID

                                         where (s.VDate >= DateFrom
                                              && (s.VDate <= DateTo)
                                              && s.StockVoucherTypeID != (byte)eStockVoucherType.OpeningStock)

                                         group r by new { r.ProductID, StockVoucherType = (eStockVoucherType)s.StockVoucherTypeID } into gr

                                         select new
                                         {
                                             ProductID = gr.Key.ProductID,
                                             StockVoucherType = gr.Key.StockVoucherType,
                                             Quantity = gr.Sum(r => (decimal?)r.Qty)
                                         };

                var res = (from p in db.tblProducts

                          join jsale in TransactionSummary on new { p.ProductID, StockVoucherType = eStockVoucherType.SaleInvoice } equals new { jsale.ProductID, jsale.StockVoucherType } into gsale
                          from sale in gsale.DefaultIfEmpty()

                          join jpur in TransactionSummary on new { p.ProductID, StockVoucherType = eStockVoucherType.PurchaseBill } equals new { jpur.ProductID, jpur.StockVoucherType } into gpur
                          from pur in gpur.DefaultIfEmpty()

                          join jsr in TransactionSummary on new { p.ProductID, StockVoucherType = eStockVoucherType.SaleReturn } equals new { jsr.ProductID, jsr.StockVoucherType } into gsr
                          from sr in gsr.DefaultIfEmpty()

                          join jpr in TransactionSummary on new { p.ProductID, StockVoucherType = eStockVoucherType.PurchaseReturn } equals new { jpr.ProductID, jpr.StockVoucherType } into gpr
                          from pr in gpr.DefaultIfEmpty()

                          join jstin in TransactionSummary on new { p.ProductID, StockVoucherType = eStockVoucherType.StockIn } equals new { jstin.ProductID, jstin.StockVoucherType } into gstin
                          from stin in gstin.DefaultIfEmpty()

                          join jstout in TransactionSummary on new { p.ProductID, StockVoucherType = eStockVoucherType.StockOut } equals new { jstout.ProductID, jstout.StockVoucherType } into gstout
                          from stout in gstout.DefaultIfEmpty()

                          join jother in (from tr in TransactionSummary
                                          where tr.StockVoucherType != eStockVoucherType.OpeningStock
                                                && tr.StockVoucherType != eStockVoucherType.SaleInvoice
                                                && tr.StockVoucherType != eStockVoucherType.SaleReturn
                                                && tr.StockVoucherType != eStockVoucherType.PurchaseBill
                                                && tr.StockVoucherType != eStockVoucherType.PurchaseReturn
                                                && tr.StockVoucherType != eStockVoucherType.StockIn
                                                && tr.StockVoucherType != eStockVoucherType.StockOut
                                          select new { tr.ProductID, tr.Quantity })
                                          on new { p.ProductID } equals new { jother.ProductID } into gother
                          from other in gother.DefaultIfEmpty()

                          join jop in OpeningStock on p.ProductID equals jop.ProductID into gop
                          from op in gop.DefaultIfEmpty()

                          join ju in db.tblUnits on p.UnitID equals ju.UnitID into gu
                          from u in gu.DefaultIfEmpty()

                          where op.Quantity != 0
                            || sale.Quantity != 0
                            || pur.Quantity != 0
                            || sr.Quantity != 0
                            || pr.Quantity != 0
                            || stin.Quantity != 0
                            || stout.Quantity != 0
                          orderby p.PCode
                          select new StockInHandReportModel()
                          {
                              ProductID = p.ProductID,
                              PCode = p.PCode,
                              ProductName = p.ProductName,
                              PurchaseRate = p.PurchaseRate,
                              UnitName = u.UnitName,
                              HSN = p.HSNCode,
                              BarCode = p.Barcode,
                              OpeningStock = (op != null ? op.Quantity : null),
                              Sale = (sale != null ? -sale.Quantity : null),
                              Purchase = (pur != null ? pur.Quantity : null),
                              SaleReturn = (sr != null ? sr.Quantity : null),
                              PurchaseReturn = (pr != null ? -pr.Quantity : null),
                              StockIn = (stin != null ? stin.Quantity : null),
                              StockOut = (stout != null ? -stout.Quantity : null),
                              Other = (other != null ? other.Quantity : null),
                          });
                return res.ToList();
            }
        }
    }
}
