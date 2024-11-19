using Alit.Marker.DAL.Template.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template.Report;
using Alit.Marker.Model.Reports.Accounts.Transactions;
using Alit.Marker.DBO;
using Alit.Marker.Model.Account.VoucherType;
using System.ComponentModel;
using Alit.Marker.Model.Settings.FinancialPeriod;

namespace Alit.Marker.DAL.Reports.Accounts.Transactions
{
    public class LedgerReportDAL : IReportDAL
    {
        public IEnumerable<IReportViewModel> GetReportData()
        {
            return GetReportData(null);
        }

        public IEnumerable<IReportViewModel> GetReportData(params object[] FilterParas)
        {
            DateTime? DateFrom = null;
            DateTime? DateTo = null;
            long? AccountID = null;

            if (FilterParas != null)
            {
                if (FilterParas.Count() >= 1 && FilterParas[0] != null && FilterParas[0] is long)
                {
                    AccountID = (long)FilterParas[0];
                }
                if (FilterParas.Count() >= 2 && FilterParas[1] != null && FilterParas[1] is DateTime)
                {
                    DateFrom = (DateTime)FilterParas[1];
                }
                if (FilterParas.Count() >= 3 && FilterParas[2] != null && FilterParas[2] is DateTime)
                {
                    DateTo = (DateTime)FilterParas[2];
                }
            }
            if (AccountID == null)
            {
                return new List<LedgerReportViewModel>();
            }
            else
            {
                return GetReportData(AccountID.Value, DateFrom, DateTo);
            }
        }        

        public List<LedgerReportViewModel> GetReportData(long AccountID, DateTime? DateFrom, DateTime? DateTo)
        {
            List<LedgerReportViewModel> res = new List<LedgerReportViewModel>();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var financialPeriod = (from fin in db.tblFinPeriods

                                       where fin.CompanyID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.CompanyID
                                                        && (DateTo == null || fin.FinPeriodFrom <= DateTo)
                                                        && (DateFrom == null || fin.FinPeriodTo == null || fin.FinPeriodTo >= DateFrom)
                                       select new FinPeriodDetailModel
                                       {
                                           FinPeriodFrom = fin.FinPeriodFrom,
                                           FinPeriodTo = fin.FinPeriodTo,
                                           FinPeriodID = fin.FinPeriodID,
                                       }).ToList();

                foreach (var fin in financialPeriod)
                {
                    var OpBalance = (from r in db.tblAccountOpeningBalances

                                     join joinrf in db.tblFinPeriods on r.FinPeriodID equals joinrf.FinPeriodID into grrf
                                     from f in grrf.DefaultIfEmpty()

                                     where r.AccountID == AccountID
                                           && f.CompanyID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.CompanyID
                                           && (fin.FinPeriodTo == null || f.FinPeriodFrom <= fin.FinPeriodTo)
                                           && (fin.FinPeriodFrom == null
                                               || (f.FinPeriodTo >= fin.FinPeriodFrom
                                               || (f.FinPeriodTo == null && f.FinPeriodFrom <= fin.FinPeriodTo)
                                               || fin.FinPeriodTo == null)
                                            )
                                        && r.FinPeriodID == fin.FinPeriodID

                                     select new OpeningBalanceLedgerViewModel()
                                     {
                                         OpeningBalance = r.OpeningBalanceAmount,
                                         DateFrom = f.FinPeriodFrom,
                                         DateTo = f.FinPeriodTo,
                                         FinPeriodID = fin.FinPeriodID,
                                     }).ToList();

                    bool IsAccountExist = db.tblAccountVoucherDetaills.Any(avd => avd.AccountID == AccountID && db.tblAccountVouchers.Any(av => av.FinPeriodID == fin.FinPeriodID && av.AccountVoucherID == avd.AccountVoucherID));

                    if ((OpBalance == null || OpBalance.Count == 0) && IsAccountExist)
                    {
                        OpBalance.Add(new OpeningBalanceLedgerViewModel() { DateFrom = fin.FinPeriodFrom, OpeningBalance = 0M });
                    }

                    foreach (var op in OpBalance)
                    {
                        decimal Amt = op.OpeningBalance;
                        if (DateFrom != null && fin.FinPeriodFrom != DateFrom && fin.FinPeriodFrom < DateFrom)
                        {
                            var balance = (from r in db.tblAccountVoucherDetaills

                                           join joinrav in db.tblAccountVouchers on r.AccountVoucherID equals joinrav.AccountVoucherID into grav
                                           from av in grav.DefaultIfEmpty()

                                           where r.AccountID == AccountID
                                              //&& av.FinPeriodID == fin.FinPeriodID
                                              && (av.VoucherDate >= fin.FinPeriodFrom && av.VoucherDate < DateFrom)

                                           select new { r.AccountID, r.Amount }

                                           ).ToList();

                            Amt = Amt + balance.Sum(rr => rr.Amount);
                        }

                        // Add Opening Balance Record
                        res.Add(new LedgerReportViewModel()
                        {
                            AccountVoucherDetailID = 0,
                            Narration = "Opening Balance",
                            CreditAmount = (Amt < 0 ? Amt : 0M),
                            DebitAmount = (Amt > 0 ? Amt : 0M),
                            VoucherType = ePrimaryVoucherType.None,
                            RecordType = eLedgerReportRecordType.OpeningBalance,
                            VoucherDate = fin.FinPeriodFrom,

                            FYDateFrom = fin.FinPeriodFrom,
                            FYDateTo = (fin.FinPeriodTo != null ? fin.FinPeriodTo : null),
                        });

                        //// Add End of Financial Period Record
                        //if (fin.FinPeriodTo != null)
                        //{
       
                        //    res.Add(new LedgerReportViewModel()
                        //    {
                        //        AccountVoucherDetailID = 0,
                        //        Narration = "End of Financial Period",
                        //        VoucherDate = fin.FinPeriodTo,
                        //        RecordType = eLedgerReportRecordType.EndOfFY,

                        //        FYDateFrom = fin.FinPeriodFrom,
                        //        FYDateTo = (fin.FinPeriodTo != null ? fin.FinPeriodTo : null),
                        //    });
                        //}
                    }
                }

                    res.AddRange(from r in db.tblAccountVoucherDetaills

                                 join joinav in db.tblAccountVouchers on r.AccountVoucherID equals joinav.AccountVoucherID into grav
                                 from av in grav.DefaultIfEmpty()

                               join joinvt in db.tblVoucherTypes on av.VoucherTypeID equals joinvt.VoucherTypeID into grvt from vt in grvt.DefaultIfEmpty()

                                 join joinrf in db.tblFinPeriods on av.FinPeriodID equals joinrf.FinPeriodID into grrf
                                 from f in grrf.DefaultIfEmpty()

                                 where r.AccountID == AccountID
                                   && (DateFrom == null || av.VoucherDate >= DateFrom)
                                   && (DateTo == null || av.VoucherDate <= DateTo)

                                 orderby av.VoucherDate, av.AccountVoucherID

                                 select new LedgerReportViewModel()
                                 {
                                     AccountVoucherDetailID = r.AccountVoucherDetailID,
                                     VoucherDate = av.VoucherDate,
                                     VoucherNo = av.VoucherNo,
                                     VoucherTypeName = (vt != null ? vt.VoucherTypeName : null),
                                     RecordType = eLedgerReportRecordType.TransactionType,
                                     Narration = r.Narration,
                                     DebitAmount = (r.Amount > 0 ? r.Amount : 0M),
                                     CreditAmount = (r.Amount < 0 ? r.Amount : 0M),
                                     FYDateFrom = f.FinPeriodFrom,
                                     FYDateTo = f.FinPeriodTo,
                                 });
                                    
                    res = res.OrderBy(r => r.VoucherDate).ThenBy(r => r.RecordType).ThenBy(r => r.AccountVoucherDetailID).ToList();

                    decimal Balance = 0M;
                    foreach (var r in res)
                    {
                        if (r.RecordType == eLedgerReportRecordType.OpeningBalance)
                        {
                            Balance = 0M;
                        }
                        Balance += (r.DebitAmount > 0 ? r.DebitAmount : r.CreditAmount);
                        r.Balance = Balance;
                        r.FinancialYear = $"Financial Period From { r.FYDateFrom.ToShortDateString()} To {(r.FYDateTo != null ? (r.FYDateTo.Value.ToShortDateString()) : "*")}";
                }                
            }
            return res;
        }

    }
}

public class OpeningBalanceLedgerViewModel
{
    [Browsable(false)]
    public long FinPeriodID { get; set; }

    [Browsable(false)]
    public long AccountID { get; set; }

    [DisplayName("Op. Bal")]
    public decimal OpeningBalance { get; set; }

    [DisplayName("Date From")]
    public DateTime DateFrom { get; set; }

    [DisplayName("Date To")]
    public DateTime? DateTo { get; set; }

}




