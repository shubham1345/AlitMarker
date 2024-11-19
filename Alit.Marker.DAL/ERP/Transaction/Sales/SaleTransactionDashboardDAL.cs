using Alit.Marker.DBO;
using Alit.Marker.Model.ERP.Transaction.Sales;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Transaction.Sales
{
    public class SaleTransactionDashboardDAL : Template.IDashboardDAL
    {
        public SavingResult DeleteRecord(long ID)
        {
            throw new NotImplementedException();
        }
        public SavingResult UpdateRecordState(long ID, eRecordState newState)
        {
            throw new NotImplementedException();
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long ID)
        {
            throw new NotImplementedException();
        }

        public BeforeUpdateRecordStateValidationResult ValidateBeforeUpdateRecordState(long ID, eRecordState oldState, eRecordState newState)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long CurrentCompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                long CurrentFinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;

                List<SaleTransactionDashboardViewModel> SaleInvoices =
                    (from r in db.tblSaleInvoices

                         //join jc in db.tblCustomers on r.CustomerID equals jc.CustomerID into gc
                         //from c in gc.DefaultIfEmpty()

                     join jc in db.tblAccounts on r.CustomerAccountID equals jc.AccountID into gc
                     from c in gc.DefaultIfEmpty()

                     join jcity in db.tblCities on c.CityID equals jcity.CityID into gcity
                     from city in gcity.DefaultIfEmpty()

                     join jsip in db.tblSaleInvoiceNoPrefixes on r.SaleInvoiceNoPrefixID equals jsip.SaleInvoiceNoPrefixID into gsip
                     from sip in gsip.DefaultIfEmpty()

                     join jpl in db.tblPriceLists on r.PriceListID equals jpl.PriceListID into gpl
                     from pl in gpl.DefaultIfEmpty()

                     join jrec in db.tblReceipts on r.AdvanceRecieptID equals jrec.ReceiptID into grec
                     from rec in grec.DefaultIfEmpty()

                     join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                     from rcu in grcu.DefaultIfEmpty()

                     join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                     from reu in greu.DefaultIfEmpty()

                     where r.CompanyID == CurrentCompanyID && r.FinPeriodID == CurrentFinPerID
                     //orderby r.SaleInvoiceDate descending, r.SaleInvoiceNo descending
                     select new SaleTransactionDashboardViewModel()
                     {
                         RecordType = eSaleTransactionDashboardRecordType.SaleInvoice,
                         TransactionID = r.SaleInvoiceID,
                         MemoType = (eMemoType)r.MemoType,

                         PrefixName = (sip != null ? sip.PrefixName : null),
                         TransactionNo = r.SaleInvoiceNo,

                         TransactionDate = r.SaleInvoiceDate,

                         CustomerID = r.CustomerAccountID,
                         CustomerName = (c != null ? c.AccountName : null),
                         //CustomerNameTitle = (c != null ? c.NameTitle : null),
                         CustomerAddress = (c != null ? c.Address : null),
                         CustomerCityName = (city != null ? city.CityName : null),

                         PriceListName = (pl != null ? pl.PriceListName : null),

                         NetAmt = r.NetAmt,
                         AdvanceAmt = (rec != null ? (decimal?)rec.Amount : null),
                         Memo = r.InvoiceMemo,

                         //RecordState = x
                         CreatedDateTime = r.rcdt,
                         EditedDateTime = r.redt,
                         CreatedUserID = r.rcuid,
                         EditedUserID = r.reuid,
                         CreatedUserName = (rcu != null ? rcu.UserName : ""),
                         EditedUserName = (reu != null ? reu.UserName : ""),

                     }).ToList();


                List<SaleTransactionDashboardViewModel> SaleReturns =
                    (from r in db.tblSaleReturns

                     //join jc in db.tblCustomers on r.CustomerAccountID equals jc.CustomerID into gc
                     //from c in gc.DefaultIfEmpty()

                     join jc in db.tblAccounts on r.CustomerAccountID equals jc.AccountID into gc
                     from acc in gc.DefaultIfEmpty()

                     join jcity in db.tblCities on acc.CityID equals jcity.CityID into gcity
                     from city in gcity.DefaultIfEmpty()

                     join jsip in db.tblSaleReturnNoPrefixes on r.SaleReturnNoPrefixID equals jsip.SaleReturnNoPrefixID into gsip
                     from sip in gsip.DefaultIfEmpty()

                     join jpl in db.tblPriceLists on r.PriceListID equals jpl.PriceListID into gpl
                     from pl in gpl.DefaultIfEmpty()

                     join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                     from rcu in grcu.DefaultIfEmpty()

                     join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                     from reu in greu.DefaultIfEmpty()

                     where r.CompanyID == CurrentCompanyID && r.FinPeriodID == CurrentFinPerID
                     //orderby r.SaleReturnDate descending, r.SaleReturnNo descending
                     select new SaleTransactionDashboardViewModel()
                     {
                         RecordType = eSaleTransactionDashboardRecordType.SaleReturn,
                         TransactionID = r.SaleReturnID,
                         MemoType = (eMemoType)r.MemoType,

                         PrefixName = (sip != null ? sip.PrefixName : null),
                         TransactionNo = r.SaleReturnNo,

                         TransactionDate = r.SaleReturnDate,

                         CustomerID = r.CustomerAccountID,
                         CustomerName = (acc != null ? acc.AccountName : null),
                         //CustomerNameTitle = (acc != null ? acc.NameTitle : null),
                         CustomerAddress = (acc != null ? acc.Address : null),
                         CustomerCityName = (city != null ? city.CityName : null),

                         PriceListName = (pl != null ? pl.PriceListName : null),

                         NetAmt = r.NetAmt,

                         Memo = r.SaleReturnMemo,

                         CreatedDateTime = r.rcdt,
                         EditedDateTime = r.redt,
                         CreatedUserID = r.rcuid,
                         EditedUserID = r.reuid,
                         CreatedUserName = (rcu != null ? rcu.UserName : ""),
                         EditedUserName = (reu != null ? reu.UserName : ""),

                     }).ToList();

                List<SaleTransactionDashboardViewModel> SaleOrders =
                    (from r in db.tblSaleOrders

                     join jc in db.tblCustomers on r.CustomerID equals jc.CustomerID into gc
                     from c in gc.DefaultIfEmpty()

                     join jcity in db.tblCities on c.CityID equals jcity.CityID into gcity
                     from city in gcity.DefaultIfEmpty()

                     join jsonp in db.tblSaleOrderNoPrefixes on r.SaleOrderNoPrefixID equals jsonp.SaleOrderNoPrefixID into gsonp
                     from sonp in gsonp.DefaultIfEmpty()

                     join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                     from rcu in grcu.DefaultIfEmpty()

                     join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                     from reu in greu.DefaultIfEmpty()

                     where r.CompanyID == CurrentCompanyID && r.FinPeriodID == CurrentFinPerID

                     orderby r.SaleOrderDate descending, r.SaleOrderNo descending

                     select new SaleTransactionDashboardViewModel()
                     {
                         RecordType = eSaleTransactionDashboardRecordType.SaleOrder,
                         TransactionID = r.SaleOrderID,

                         PrefixName = (sonp != null ? sonp.PrefixName : null),
                         TransactionNo = r.SaleOrderNo,

                         TransactionDate = r.SaleOrderDate,
                         CustomerID = r.CustomerID,

                         CustomerName = (c != null ? c.CustomerName : null),
                         CustomerNameTitle = (c != null ? c.NameTitle : null),
                         CustomerAddress = (c != null ? c.Address : null),
                         CustomerCityName = (city != null ? city.CityName : null),

                         NetAmt = r.NetAmt,
                         Memo = r.OrderMemo,

                         CreatedDateTime = r.rcdt,
                         EditedDateTime = r.redt,
                         CreatedUserID = r.rcuid,
                         EditedUserID = r.reuid,
                         CreatedUserName = (rcu != null ? rcu.UserName : ""),
                         EditedUserName = (reu != null ? reu.UserName : ""),

                     }).ToList();

                var List = (from r in SaleInvoices.Union(SaleReturns).Union(SaleOrders)
                            orderby r.TransactionDate, r.TransactionNoWithPrefix, r.RecordType
                            select r).ToList();
                return List;
            }
        }
    }
}
