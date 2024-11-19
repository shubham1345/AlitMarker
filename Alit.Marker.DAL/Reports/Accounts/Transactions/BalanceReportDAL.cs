using Alit.Marker.DAL.Template.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template.Report;
using Alit.Marker.Model.Reports.Accounts.Transactions;
using Alit.Marker.DBO;
using Alit.Marker.Model.Account.Group;
using Alit.Marker.Model.Settings.FinancialPeriod;
using Alit.Marker.Model.Account.VoucherType;
using System.ComponentModel;

namespace Alit.Marker.DAL.Reports.Accounts.Transactions
{
    public class BalanceReportDAL : IReportDAL
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
                return new List<BalanceReportViewModel>();
            }
            else
            {
                return GetReportData(DateFrom.Value, DateTo.Value);
            }
        }

        public List<BalanceReportViewModel> GetReportData(DateTime DateFrom, DateTime DateTo)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var financialPeriods = (from fin in db.tblFinPeriods

                                        where fin.CompanyID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.CompanyID
                                                         && (fin.FinPeriodFrom <= DateTo)
                                                         && (fin.FinPeriodTo == null || fin.FinPeriodTo >= DateFrom)
                                        //select new FinPeriodDetailModel
                                        select new
                                        {
                                            FinPeriodFrom = fin.FinPeriodFrom,
                                            FinPeriodTo = fin.FinPeriodTo,
                                            FinPeriodID = fin.FinPeriodID,
                                        }).ToList();

                if (financialPeriods == null || financialPeriods.Count == 0 || financialPeriods.Count > 1)
                {
                    return new List<BalanceReportViewModel>();
                }
                var financialPeriod = financialPeriods.First();

                var OpBalance = (from r in db.tblAccountOpeningBalances

                                 join joinacc in db.tblAccounts on r.AccountID equals joinacc.AccountID into gracc
                                 from acc in gracc.DefaultIfEmpty()

                                 join joinag in db.tblAccountGroups on acc.AccountGroupID equals joinag.AccountGroupID into gracg
                                 from acg in gracg.DefaultIfEmpty()

                                 where acc.CompanyID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.CompanyID
                                        && r.FinPeriodID == financialPeriod.FinPeriodID // Only for the financial which lies in entered date from
                                        && (acg.GroupTypeID == (byte)eAccountGroupType.SundryDebtors
                                        || acg.GroupTypeID == (byte)eAccountGroupType.SundryCreditors)

                                 select new 
                                 {
                                     OpeningBalance = r.OpeningBalanceAmount,
                                     AccountID = r.AccountID,
                                 }).ToList();

                var TransactionOpBalance = (from r in db.tblAccountVoucherDetaills

                                            join joinrav in db.tblAccountVouchers on r.AccountVoucherID equals joinrav.AccountVoucherID into grav
                                            from av in grav.DefaultIfEmpty()

                                            join joinacc in db.tblAccounts on r.AccountID equals joinacc.AccountID into gracc
                                            from acc in gracc.DefaultIfEmpty()

                                            join joinag in db.tblAccountGroups on acc.AccountGroupID equals joinag.AccountGroupID into gracg
                                            from acg in gracg.DefaultIfEmpty()

                                            where (av.VoucherDate >= financialPeriod.FinPeriodFrom && av.VoucherDate < DateFrom)
                                                 && (acg.GroupTypeID == (byte)eAccountGroupType.SundryDebtors || acg.GroupTypeID == (byte)eAccountGroupType.SundryCreditors)

                                            group r by r.AccountID into gr

                                            select new
                                            {
                                                AccountID = gr.Key,
                                                OpeningBalanceAmount = gr.Sum(rr => rr.Amount)
                                            }).ToList();

                var TransactionClosingBalance = (from r2 in (from r in db.tblAccountVoucherDetaills

                                                 join joinrav in db.tblAccountVouchers on r.AccountVoucherID equals joinrav.AccountVoucherID into grav
                                                 from av in grav.DefaultIfEmpty()

                                                 join joinacc in db.tblAccounts on r.AccountID equals joinacc.AccountID into gracc
                                                 from acc in gracc.DefaultIfEmpty()

                                                 join joinag in db.tblAccountGroups on acc.AccountGroupID equals joinag.AccountGroupID into gracg
                                                 from acg in gracg.DefaultIfEmpty()

                                                 join joinvt in db.tblVoucherTypes on av.VoucherTypeID equals joinvt.VoucherTypeID into grvt
                                                 from vt in grvt.DefaultIfEmpty()

                                                 where (av.VoucherDate >= DateFrom)
                                                     && (av.VoucherDate <= DateTo)
                                                     && (acg.GroupTypeID == (byte)eAccountGroupType.SundryDebtors
                                                                || acg.GroupTypeID == (byte)eAccountGroupType.SundryCreditors)

                                                 group r by new { r.AccountID, vt.PrimaryVoucherTypeID } into gr

                                                 select new
                                                 {
                                                     AccountID = gr.Key.AccountID,
                                                     PrimaryVoucherType = (ePrimaryVoucherType)gr.Key.PrimaryVoucherTypeID,
                                                     Amount = gr.Sum(r => (decimal?)r.Amount)
                                                 })

                                                 group r2 by new { r2.AccountID } into gr2
                                                 select new
                                                 {
                                                     AccountID = gr2.Key.AccountID,
                                                     TotalAmount = gr2.Sum(sr=> sr.Amount),
                                                     TotalSale = gr2.Where(wr=> wr.PrimaryVoucherType == ePrimaryVoucherType.Sale).Sum(sr => sr.Amount),
                                                     TotalSaleReturn = gr2.Where(wr => wr.PrimaryVoucherType == ePrimaryVoucherType.SaleReturn).Sum(sr => sr.Amount),
                                                     TotalPurchase = gr2.Where(wr => wr.PrimaryVoucherType == ePrimaryVoucherType.Purchase).Sum(sr => sr.Amount),
                                                     TotalPurchaseReturn = gr2.Where(wr => wr.PrimaryVoucherType == ePrimaryVoucherType.PurchaseReturn).Sum(sr => sr.Amount),
                                                     TotalReceipt = gr2.Where(wr => wr.PrimaryVoucherType == ePrimaryVoucherType.Receipt).Sum(sr => sr.Amount),
                                                     TotalPayment = gr2.Where(wr => wr.PrimaryVoucherType == ePrimaryVoucherType.Payment).Sum(sr => sr.Amount),
                                                     TotalOthers = gr2.Where(wr => wr.PrimaryVoucherType != ePrimaryVoucherType.Sale
                                                                                    && wr.PrimaryVoucherType != ePrimaryVoucherType.SaleReturn
                                                                                    && wr.PrimaryVoucherType != ePrimaryVoucherType.Purchase
                                                                                    && wr.PrimaryVoucherType != ePrimaryVoucherType.PurchaseReturn
                                                                                    && wr.PrimaryVoucherType != ePrimaryVoucherType.Receipt
                                                                                    && wr.PrimaryVoucherType != ePrimaryVoucherType.Payment).Sum(sr => sr.Amount),
                                                 }
                               ).ToList();


                var accounts = (from r in db.tblAccounts

                       join joinag in db.tblAccountGroups on r.AccountGroupID equals joinag.AccountGroupID into gracg
                       from acg in gracg.DefaultIfEmpty()

                       where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.CompanyID
                             && (acg.GroupTypeID == (byte?)eAccountGroupType.SundryDebtors
                                || acg.GroupTypeID == (byte?)eAccountGroupType.SundryCreditors)

                       select new
                       {
                           AccountID = r.AccountID,
                           AccountName = r.AccountName,
                           AccountGroupName = (acg != null ? acg.AccountGroupName : null),
                           AccountGroupID = r.AccountGroupID,
                       }).ToList();

                var res = (from ac in accounts

                           join jopb1 in OpBalance on ac.AccountID equals jopb1.AccountID into gopb1
                           from opb1 in gopb1.DefaultIfEmpty()

                           join jopb2 in TransactionOpBalance on ac.AccountID equals jopb2.AccountID into gopb2
                           from opb2 in gopb2.DefaultIfEmpty()

                           join jcb in TransactionClosingBalance on ac.AccountID equals jcb.AccountID into gcb
                           from cb in gcb.DefaultIfEmpty()

                           select new BalanceReportViewModel
                           {
                               AccountID = ac.AccountID,
                               AccountName = ac.AccountName,
                               AccountGroupID = ac.AccountGroupID,
                               AccountGroupName = ac.AccountGroupName,
                               OpeningBalance = (opb1?.OpeningBalance ?? 0M) + (opb2?.OpeningBalanceAmount ?? 0M),
                               ClosingBalance = (opb1?.OpeningBalance ?? 0M) + (opb2?.OpeningBalanceAmount ?? 0M) + (cb?.TotalAmount ?? 0M),

                               Sales = (cb?.TotalSale ?? 0M),
                               SalesReturns = (cb?.TotalSaleReturn ?? 0M),
                               Purchase = (cb?.TotalPurchase ?? 0M),
                               PurchaseReturn = (cb?.TotalPurchaseReturn ?? 0M),
                               Received = (cb?.TotalReceipt ?? 0M),
                               Paid = (cb?.TotalPayment ?? 0M),
                               Other = (cb?.TotalOthers ?? 0M),
                           }).ToList();
                return res;              
            }
        }
    }
}
