using Alit.Marker.DAL.Template.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template.Report;
using Alit.Marker.Model.Reports.Accounts.Transactions;
using Alit.Marker.DBO;

namespace Alit.Marker.DAL.Reports.Accounts.Transactions
{
    public class DayBookReportDAL : IReportDAL
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
                return new List<DayBookReportViewModel>();
            }
            else
            {
                return GetReportData(DateFrom.Value, DateTo.Value);
            }
        }

        public List<DayBookReportViewModel> GetReportData(DateTime DateFrom, DateTime DateTo)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from av in db.tblAccountVouchers

                           join javd in db.tblAccountVoucherDetaills 
                           on new { A = av.AccountVoucherID, B = (long)av.CustomerAccountID } equals new { A = javd.AccountVoucherID, B = javd.AccountID } into gavd
                           from avd in gavd.DefaultIfEmpty()

                           join jacc in db.tblAccounts on av.CustomerAccountID equals jacc.AccountID into gavacc
                           from acc in gavacc.DefaultIfEmpty()

                           join jaccg in db.tblAccountGroups on acc.AccountGroupID equals jaccg.AccountGroupID
                           into gaccg from acg in gaccg.DefaultIfEmpty()

                           join joinvt in db.tblVoucherTypes on av.VoucherTypeID equals joinvt.VoucherTypeID into grvt
                           from vt in grvt.DefaultIfEmpty()

                           join joinfin in db.tblFinPeriods on av.FinPeriodID equals joinfin.FinPeriodID into grfin
                           from fin in grfin.DefaultIfEmpty()

                           where fin.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID                          
                                && av.VoucherDate >= DateFrom
                                && av.VoucherDate <= DateTo

                           select new DayBookReportViewModel
                           {
                               VoucherDate = av.VoucherDate,
                               VoucherType = (vt != null ? vt.VoucherTypeName : null),
                               VoucherNo = av.VoucherNo,
                               AccountName = (acc != null ? acc.AccountName : null),
                               AccountGroup = (acg != null ? acg.AccountGroupName : null),
                               Description = (avd != null ? avd.Narration : null),
                               Amount = av.Amount,
                           }).ToList();
                return res;
            }
        }

    }
}
