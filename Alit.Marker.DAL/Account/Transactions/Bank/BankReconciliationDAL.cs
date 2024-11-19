using Alit.Marker.DAL.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.Account.Transactions.Bank;
using Alit.Marker.DBO;
using Alit.Marker.Model.Settings.FinancialPeriod;
using Alit.Marker.Model.Account.VoucherType;
using Alit.Marker.Model.Reports.Accounts.Transactions;

namespace Alit.Marker.DAL.Account.Transactions.Bank
{
    public class BankReconciliationDAL : IDashboardDAL
    {
        public SavingResult SaveRecord(List<BankReconciliationDashboardViewModel> ViewModels)
        {
            SavingResult res = new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                foreach (var ViewModel in ViewModels)
                {
                    tblAccountVoucherDetaill SaveModel = null;

                    SaveModel = db.tblAccountVoucherDetaills.Find(ViewModel.AccountVoucherDetailID);

                    if (SaveModel != null)
                    {
                        db.tblAccountVoucherDetaills.Attach(SaveModel);
                        db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                        if (ViewModel.Reconciled)
                        {
                            SaveModel.ValueDate = (DateTime)ViewModel.ValueDate;
                        }
                        else
                        {
                            SaveModel.ValueDate = null;
                        }
                    }
                }

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public IEnumerable<IDashboardViewModel> GetDashboardData()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas)
        {
            long AccountID = 0;
            DateTime? DateFrom = null;
            DateTime? DateTo = null;

            if (FilterParas != null)
            {
                int index = 0;
                if (FilterParas.Count() > index && FilterParas[index] != null && FilterParas[index] is long)
                {
                    AccountID = (long)FilterParas[index];
                }
                index++;

                if (FilterParas.Count() > index && FilterParas[index] != null && FilterParas[index] is DateTime)
                {
                    DateFrom = (DateTime)FilterParas[index];
                }
                index++;

                if (FilterParas.Count() > index && FilterParas[index] != null && FilterParas[index] is DateTime)
                {
                    DateTo = (DateTime)FilterParas[index];
                }
                index++;

            }

            if (AccountID == 0 || DateFrom == null || DateTo == null)
            {
                return new List<BankReconciliationDashboardViewModel>();
            }
            else
            {
                return GetDashboardData(AccountID, DateFrom.Value, DateTo.Value);
            }
        }

        public List<BankReconciliationDashboardViewModel> GetDashboardData(long AccountID, DateTime DateFrom, DateTime DateTo)
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
                    return new List<BankReconciliationDashboardViewModel>();
                }
                var financialPeriod = financialPeriods.First();

                decimal FinancialPeriodOpeningBalance = (from r in db.tblAccountOpeningBalances

                                                         join joinrf in db.tblFinPeriods on r.FinPeriodID equals joinrf.FinPeriodID into grrf
                                                         from f in grrf.DefaultIfEmpty()

                                                         where r.AccountID == AccountID
                                                                 && f.CompanyID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.CompanyID
                                                                 && r.FinPeriodID == financialPeriod.FinPeriodID // Only for the financial which lies in entered date from

                                                         select (decimal?)r.OpeningBalanceAmount).FirstOrDefault() ?? 0M;

                decimal BookOpeningBalance = FinancialPeriodOpeningBalance;
                if (financialPeriod.FinPeriodFrom < DateFrom)
                {
                    // Adding Transaction balance within current fp before date from.
                    BookOpeningBalance += (from r in db.tblAccountVoucherDetaills

                                           join joinrav in db.tblAccountVouchers on r.AccountVoucherID equals joinrav.AccountVoucherID into grav
                                           from av in grav.DefaultIfEmpty()

                                           where r.AccountID == AccountID
                                              && (av.VoucherDate >= financialPeriod.FinPeriodFrom && av.VoucherDate < DateFrom)
                                           select new { r.Amount }

                                  ).Sum(r => (decimal?)r.Amount) ?? 0M;
                }

                decimal BankOpeningBalance = FinancialPeriodOpeningBalance;
                BankOpeningBalance += ((from r in db.tblAccountVoucherDetaills

                                        join joinrav in db.tblAccountVouchers on r.AccountVoucherID equals joinrav.AccountVoucherID into grav
                                        from av in grav.DefaultIfEmpty()

                                        where r.AccountID == AccountID
                                              //&& (av.VoucherDate >= financialPeriod.FinPeriodFrom && av.VoucherDate < DateFrom)
                                              //&& av.FinPeriodID == financialPeriod.FinPeriodID
                                              && (av.VoucherDate >= financialPeriod.FinPeriodFrom && av.VoucherDate < DateFrom)
                                              && r.ValueDate != null
                                        select new { r.Amount }

                                  ).Sum(r => (decimal?)r.Amount) ?? 0M);

                var res = (from r in db.tblAccountVoucherDetaills

                           join joinav in db.tblAccountVouchers on r.AccountVoucherID equals joinav.AccountVoucherID into grav
                           from av in grav.DefaultIfEmpty()

                           join joinvt in db.tblVoucherTypes on av.VoucherTypeID equals joinvt.VoucherTypeID into grvt
                           from vt in grvt.DefaultIfEmpty()

                           join joinrf in db.tblFinPeriods on av.FinPeriodID equals joinrf.FinPeriodID into grrf
                           from f in grrf.DefaultIfEmpty()

                           where r.AccountID == AccountID
                                  && av.VoucherDate >= DateFrom
                                  && av.VoucherDate <= DateTo
                           //&& (IncludeReconciled || r.ValueDate == null)

                           orderby av.VoucherDate, av.AccountVoucherID

                           select new BankReconciliationDashboardViewModel()
                           {
                               AccountVoucherDetailID = r.AccountVoucherDetailID,
                               VoucherDate = av.VoucherDate,
                               ValueDate = r.ValueDate,
                               VoucherNo = av.VoucherNo,
                               VoucherTypeName = (vt != null ? vt.VoucherTypeName : null),
                               RecordType = eLedgerReportRecordType.TransactionType,
                               Narration = r.Narration,
                               DebitAmount = (r.Amount > 0 ? r.Amount : 0M),
                               CreditAmount = (r.Amount < 0 ? r.Amount : 0M),
                           }).ToList();

                decimal BookBalance = BookOpeningBalance;
                foreach (var r in res)
                {
                    BookBalance += (r.DebitAmount > 0 ? r.DebitAmount : r.CreditAmount);
                    r.Balance = BookBalance;
                }

                return res;
            }
        }

        public decimal GetOpeningBankBalance(long AccountID, DateTime DateFrom)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var financialPeriods = (from fin in db.tblFinPeriods

                                        where fin.CompanyID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.CompanyID
                                                         && (fin.FinPeriodFrom <= DateFrom)
                                                         && (fin.FinPeriodTo == null || fin.FinPeriodTo >= DateFrom)
                                        select new
                                        {
                                            FinPeriodFrom = fin.FinPeriodFrom,
                                            FinPeriodTo = fin.FinPeriodTo,
                                            FinPeriodID = fin.FinPeriodID,
                                        }).ToList();

                if (financialPeriods == null || financialPeriods.Count == 0 || financialPeriods.Count > 1)
                {
                    return 0M;
                }
                var financialPeriod = financialPeriods.First();


                decimal OpeningBankBalance = (from r in db.tblAccountOpeningBalances

                                              join joinrf in db.tblFinPeriods on r.FinPeriodID equals joinrf.FinPeriodID into grrf
                                              from f in grrf.DefaultIfEmpty()

                                              where r.AccountID == AccountID
                                                      && f.CompanyID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.CompanyID
                                                      && r.FinPeriodID == financialPeriod.FinPeriodID // Only for the financial which lies in entered date from

                                              select (decimal?)r.OpeningBalanceAmount).FirstOrDefault() ?? 0M;

                OpeningBankBalance += (from avd in db.tblAccountVoucherDetaills

                                       join joinav in db.tblAccountVouchers on avd.AccountVoucherID equals joinav.AccountVoucherID into grav
                                       from av in grav.DefaultIfEmpty()

                                       where avd.AccountID == AccountID
                                             && avd.ValueDate != null
                                             && av.VoucherDate >= financialPeriod.FinPeriodFrom
                                             && av.VoucherDate < DateFrom

                                       group avd by avd.AccountID into gr

                                       select gr.Sum(rr => rr.Amount)).FirstOrDefault();

                return OpeningBankBalance;
            }
        }

        public SavingResult UpdateRecordState(long ID, eRecordState newState)
        {
            throw new NotImplementedException();
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long ID)
        {
            throw new NotImplementedException();
        }

        public SavingResult DeleteRecord(long ID)
        {
            throw new NotImplementedException();
        }

        public BeforeUpdateRecordStateValidationResult ValidateBeforeUpdateRecordState(long ID, eRecordState oldState, eRecordState newState)
        {
            throw new NotImplementedException();
        }
    }
}
