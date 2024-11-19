using Alit.Marker.Model.Reports.TransationReports;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template.Report;
using Alit.Marker.DBO;

namespace Alit.Marker.DAL.Reports.TransationReports
{
    public class CustomerBalanceReportDAL : Template.Report.IReportDAL
    {
        public IEnumerable<IReportViewModel> GetReportData()
        {
            return GetReportData(null);
        }

        public IEnumerable<IReportViewModel> GetReportData(params object[] FilterParas)
        {
            DateTime DateFrom = DateTime.Now.Date;
            DateTime? DateTo = null;

            // date from is required
            if (FilterParas == null || FilterParas.Length < 1)
            {
                return null;
            }

            if (FilterParas.Length >= 1)
            {
                DateFrom = (DateTime)FilterParas[0];
            }
            if (FilterParas.Length >= 2)
            {
                DateTo = (DateTime?)FilterParas[1];
            }
            if (DateTo != null)
            {
                DateTo = DateTo.Value.Date.Add(new TimeSpan(23, 59, 59));
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                int CreditMemoTypeID = (int)eMemoType.Credit;

                List<CustomerBalanceTempModel1> resOpBal = null;
                //if (DateFrom != null)
                {
                    /// Opening Balance
                    var OpBal_ = from r in db.tblCustomerOpBals
                                 where r.OpBalDate < DateFrom &&
                                  r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                  r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                 group r by r.CustomerID into gr
                                 let Amt = gr.Sum(r => (decimal?)r.OpBalAmt) ?? 0

                                 select new CustomerBalanceTempModel1()
                                 {
                                     CustomerID = gr.Key,
                                     Amt = Amt
                                 };

                    /// Sales 
                    var Sale_ = from r in db.tblSaleInvoices
                                where
                                r.SaleInvoiceDate < DateFrom &&
                                r.MemoType == CreditMemoTypeID &&
                                r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                group r by r.CustomerAccountID into gr
                                let Amt = gr.Sum(r => (decimal?)r.NetAmt) ?? 0
                                select new CustomerBalanceTempModel1()
                                {
                                    CustomerID = gr.Key,
                                    Amt = Amt
                                };

                    /// Sale Return 
                    var SaleReturn_ = from r in db.tblSaleReturns
                                      where
                                      r.SaleReturnDate < DateFrom &&
                                      r.MemoType == CreditMemoTypeID &&
                                      r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                      r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                      group r by r.CustomerAccountID into gr
                                      let Amt = gr.Sum(r => (decimal?)r.NetAmt) ?? 0
                                      select new CustomerBalanceTempModel1()
                                      {
                                          CustomerID = gr.Key,
                                          Amt = Amt
                                      };

                    /// Purchase
                    var Purchase_ = from r in db.tblPurchaseBills
                                    where
                                     r.PurchaseBillDate < DateFrom &&
                                     r.MemoType == CreditMemoTypeID &&
                                     r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                     r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                    group r by r.CustomerAccountID into gr
                                    let Amt = gr.Sum(r => (decimal?)r.NetAmt) ?? 0
                                    select new CustomerBalanceTempModel1()
                                    {
                                        CustomerID = gr.Key,
                                        Amt = Amt
                                    };

                    /// Purchase Return 
                    var PurchaseReturn_ = from r in db.tblPurchaseReturns
                                          where
                                          r.PurchaseReturnDate < DateFrom &&
                                          r.MemoType == CreditMemoTypeID &&
                                          r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                          r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                          group r by r.CustomerAccountID into gr
                                          let Amt = gr.Sum(r => (decimal?)r.NetAmt) ?? 0
                                          select new CustomerBalanceTempModel1()
                                          {
                                              CustomerID = gr.Key,
                                              Amt = Amt
                                          };
                    /// Receipts
                    var Reciept_ = from r in db.tblReceipts
                                   where r.ReceiptDate < DateFrom &&
                                         r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                         r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                   //group r by r.CustomerID into gr
                                   group r by r.AccountID into gr
                                   let Amt = gr.Sum(r => (decimal?)r.Amount) ?? 0
                                   select new CustomerBalanceTempModel1()
                                   {
                                       CustomerID = gr.Key,
                                       Amt = Amt
                                   };

                    /// Payments
                    var Payment_ = from r in db.tblPayments
                                   where r.PaymentDate < DateFrom &&
                                         r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                         r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                   //group r by r.CustomerID into gr
                                   group r by r.AccountID into gr
                                   let Amt = gr.Sum(r => (decimal?)r.Amount) ?? 0
                                   select new CustomerBalanceTempModel1()
                                   {
                                       CustomerID = gr.Key,
                                       Amt = Amt
                                   };

                    resOpBal = (from r in db.tblCustomers
                                join jopbal in OpBal_ on r.CustomerID equals jopbal.CustomerID into gopbal
                                from ropbal in gopbal.DefaultIfEmpty()
                                join jsale in Sale_ on r.CustomerID equals jsale.CustomerID into gsale
                                from rsale in gsale.DefaultIfEmpty()
                                join jsalereturn in SaleReturn_ on r.CustomerID equals jsalereturn.CustomerID into gsalereturn
                                from rsalereturn in gsalereturn.DefaultIfEmpty()
                                join jpurchase in Purchase_ on r.CustomerID equals jpurchase.CustomerID into gpurchase
                                from rpurchase in gpurchase.DefaultIfEmpty()
                                join jpurchasereturn in PurchaseReturn_ on r.CustomerID equals jpurchasereturn.CustomerID into gpurchasereturn
                                from rpurchasereturn in gpurchasereturn.DefaultIfEmpty()
                                join jreciept in Reciept_ on r.CustomerID equals jreciept.CustomerID into greciept
                                from rreciept in greciept.DefaultIfEmpty()
                                join jpayment in Payment_ on r.CustomerID equals jpayment.CustomerID into gpayment
                                from rpayment in gpayment.DefaultIfEmpty()

                                where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                select new CustomerBalanceTempModel1()
                                {
                                    CustomerID = r.CustomerID,
                                    Amt = (ropbal != null ? ropbal.Amt : 0) +
                                            (rsale != null ? rsale.Amt : 0) -
                                            (rsalereturn != null ? rsalereturn.Amt : 0) -
                                            (rpurchase != null ? rpurchase.Amt : 0) +
                                            (rpurchasereturn != null ? rpurchasereturn.Amt : 0) -
                                            (rreciept != null ? rreciept.Amt : 0) +
                                            (rpayment != null ? rpayment.Amt : 0)
                                }).ToList();

                }

                /// Opening Balance
                var OpBal = from r in db.tblCustomerOpBals
                            where ((DateFrom == null || r.OpBalDate >= DateFrom) &&
                                 (DateTo == null || r.OpBalDate <= DateTo)) &&
                             r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                             r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                            group r by r.CustomerID into gr
                            let Amt = gr.Sum(r => (decimal?)r.OpBalAmt) ?? 0
                            select new CustomerBalanceTempModel1()
                            {
                                CustomerID = gr.Key,
                                Amt = Amt
                            };

                /// Sales 
                var Sale = from r in db.tblSaleInvoices
                           where
                           ((DateFrom == null || r.SaleInvoiceDate >= DateFrom) &&
                           (DateTo == null || r.SaleInvoiceDate <= DateTo)) &&
                           r.MemoType == CreditMemoTypeID &&
                           r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                           r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                           group r by r.CustomerAccountID into gr
                           let Amt = gr.Sum(r => (decimal?)r.NetAmt) ?? 0
                           select new CustomerBalanceTempModel1()
                           {
                               CustomerID = gr.Key,
                               Amt = Amt
                           };

                /// Sale Return 
                var SaleReturn = from r in db.tblSaleReturns
                                 where
                                 ((DateFrom == null || r.SaleReturnDate >= DateFrom) &&
                                 (DateTo == null || r.SaleReturnDate <= DateTo)) &&
                                 r.MemoType == CreditMemoTypeID &&
                                 r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                 r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                 group r by r.CustomerAccountID into gr
                                 let Amt = gr.Sum(r => (decimal?)r.NetAmt) ?? 0
                                 select new CustomerBalanceTempModel1()
                                 {
                                     CustomerID = gr.Key,
                                     Amt = Amt
                                 };

                /// Purchase
                var Purchase = from r in db.tblPurchaseBills
                               where
                                ((DateFrom == null || r.PurchaseBillDate >= DateFrom) &&
                                (DateTo == null || r.PurchaseBillDate <= DateTo)) &&
                                r.MemoType == CreditMemoTypeID &&
                                r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                               group r by r.CustomerAccountID into gr
                               let Amt = gr.Sum(r => (decimal?)r.NetAmt) ?? 0
                               select new CustomerBalanceTempModel1()
                               {
                                   CustomerID = gr.Key,
                                   Amt = Amt
                               };

                /// Purchase Return 
                var PurchaseReturn = from r in db.tblPurchaseReturns
                                     where
                                     ((DateFrom == null || r.PurchaseReturnDate >= DateFrom) &&
                                     (DateTo == null || r.PurchaseReturnDate <= DateTo)) &&
                                     r.MemoType == CreditMemoTypeID &&
                                     r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                     r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                     group r by r.CustomerAccountID into gr
                                     let Amt = gr.Sum(r => (decimal?)r.NetAmt) ?? 0
                                     select new CustomerBalanceTempModel1()
                                     {
                                         CustomerID = gr.Key,
                                         Amt = Amt
                                     };


                /// Receipts
                var Reciept = from r in db.tblReceipts
                              where ((DateFrom == null || r.ReceiptDate >= DateFrom) &&
                                    (DateTo == null || r.ReceiptDate <= DateTo)) &&
                                    r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                    r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                              //group r by r.CustomerID into gr
                              group r by r.AccountID into gr
                              let Amt = gr.Sum(r => (decimal?)r.Amount) ?? 0
                              select new CustomerBalanceTempModel1()
                              {
                                  CustomerID = gr.Key,
                                  Amt = Amt
                              };

                /// Payment
                var Payment = from r in db.tblPayments
                              where ((DateFrom == null || r.PaymentDate >= DateFrom) &&
                                    (DateTo == null || r.PaymentDate <= DateTo)) &&
                                    r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                    r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                              //group r by r.CustomerID into gr
                              group r by r.AccountID into gr
                              let Amt = gr.Sum(r => (decimal?)r.Amount) ?? 0
                              select new CustomerBalanceTempModel1()
                              {
                                  CustomerID = gr.Key,
                                  Amt = Amt
                              };


                var res = (from r in db.tblCustomers
                           join jCity in db.tblCities on r.CityID equals jCity.CityID into gCity
                           from City in gCity.DefaultIfEmpty()
                           join jstate in db.tblStates on City.CityID equals jstate.StateID into gstate
                           from state in gstate.DefaultIfEmpty()
                           join jcountry in db.tblCountries on state.CountryID equals jcountry.CountryID into gcountry
                           from country in gcountry.DefaultIfEmpty()

                           join jopbal in OpBal on r.CustomerID equals jopbal.CustomerID into gopbal
                           from ropbal in gopbal.DefaultIfEmpty()
                           join jsale in Sale on r.CustomerID equals jsale.CustomerID into gsale
                           from rsale in gsale.DefaultIfEmpty()
                           join jsalereturn in SaleReturn on r.CustomerID equals jsalereturn.CustomerID into gsalereturn
                           from rsalereturn in gsalereturn.DefaultIfEmpty()
                           join jpurchase in Purchase on r.CustomerID equals jpurchase.CustomerID into gpurchase
                           from rpurchase in gpurchase.DefaultIfEmpty()
                           join jpurchasereturn in PurchaseReturn on r.CustomerID equals jpurchasereturn.CustomerID into gpurchasereturn
                           from rpurchasereturn in gpurchasereturn.DefaultIfEmpty()
                           join jreciept in Reciept on r.CustomerID equals jreciept.CustomerID into greciept
                           from rreciept in greciept.DefaultIfEmpty()
                           join jpayment in Payment on r.CustomerID equals jpayment.CustomerID into gpayment
                           from rpayment in gpayment.DefaultIfEmpty()

                           where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                           orderby r.CustomerNo
                           select new CustomerBalanceReportModel()
                           {
                               CustomerID = r.CustomerID,
                               CustomerNo = r.CustomerNo,
                               CustomerNameTitle = r.NameTitle,
                               CustomerName = r.CustomerName,
                               CompanyName = r.CustomerCompanyName,
                               CustomerAddress = r.Address,
                               CustomerCityName = (City != null ? City.CityName : ""),
                               CustomerCityStateShortName = (state != null ? state.StateShortName : ""),
                               CustomerCityCountryName = (country != null ? country.CountryName : ""),
                               CustomerPostCode = r.PostCode,
                               CustomerMobileNo = r.MobileNo,
                               CustomerPhoneNo = r.PhoneNo,
                               CustomerEMailID = r.EMailID,
                               CustomerWebsite = r.Website,
                               CustomerPAN = r.PAN,
                               CustomerGSTNo = r.GSTNo,
                               CustomerServiceTaxNo = r.ServiceTaxNo,

                               OpeningBalance = (ropbal != null ? ropbal.Amt : 0),
                               SaleAmt = (rsale != null ? rsale.Amt : 0),
                               SaleReturnAmt = (rsalereturn != null ? rsalereturn.Amt : 0),
                               PurchaseAmt = (rpurchase != null ? rpurchase.Amt : 0),
                               PurchaseReturnAmt = (rpurchasereturn != null ? rpurchasereturn.Amt : 0),
                               RecieptAmt = (rreciept != null ? rreciept.Amt : 0),
                               PaymentAmt = (rpayment != null ? rpayment.Amt : 0),
                               //Select = r.AllowSendSMS ?? false,
                           }).ToList();

                if (resOpBal != null)
                {
                    foreach (var r in res)
                    {
                        var ropbal = resOpBal.FirstOrDefault(rr => rr.CustomerID == r.CustomerID);

                        if (ropbal != null)
                        {
                            r.OpeningBalance += ropbal.Amt;
                        }
                    }
                }
                return res;
            }
        }


        public class CustomerBalanceTempModel1
        {
            public long CustomerID { get; set; }

            public decimal Amt { get; set; }
        }
    }
}
