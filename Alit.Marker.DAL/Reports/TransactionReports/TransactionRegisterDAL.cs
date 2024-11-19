using Alit.Marker.DAL.Template.Report;
using Alit.Marker.Model.Reports.TransationReports;
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
    public class TransactionRegisterDAL : IReportDAL
    {
        public IEnumerable<IReportViewModel> GetReportData()
        {
            return GetReportData(null);
        }

        /// <summary>
        /// Get transaction register report. in date to 23:59 will be added in this procedure. No need to take extra precaution.
        /// </summary>
        /// <param name="FilterParas"></param>
        /// <returns></returns>
        public IEnumerable<IReportViewModel> GetReportData(object[] FilterParas)
        {
            long CustomerID = 0;
            DateTime DateFrom = DateTime.Now.Date;
            DateTime? DateTo = null;

            // customer and date from is required
            if (FilterParas == null || FilterParas.Length < 2 )
            {
                return null;
            }
            CustomerID = (long)FilterParas[0];

            if(FilterParas.Length >= 2)
            {
                DateFrom = (DateTime)FilterParas[1];
            }
            if (FilterParas.Length >= 3)
            {
                DateTo = (DateTime?)FilterParas[2];
            }
            if(DateTo != null)
            {
                // setting date to time should be last second of the day, if in any transaction, if time is also saved, 
                // then that will not be filtered because of wrong filter condition.
                // example if you are looking for a report from 01-Jan to 31-jan. and a sale invoice is save with time like 31-Jan 2pm,
                // then it will not be included in result because date to contains 31 jan 00:00, so that we are adding 23 hours in date,
                // by this it will become 31-jan 23:59:59, so all the transactions of the 31st jan will be covered automatically.
                DateTo = DateTo.Value.Date.Add(new TimeSpan(23, 59, 59));
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblCustomer CustomerMaster = db.tblCustomers.FirstOrDefault(r => r.CustomerID == CustomerID);
                if (CustomerMaster == null)
                {
                    return null;
                }

                //List<RepTransactionRegisterReportModelCustomerHeader> RepDS = new List<RepTransactionRegisterReportModelCustomerHeader>();
                //RepDS.Add(new RepTransactionRegisterReportModelCustomerHeader()
                //{
                //    Customer = new Model.Reports.CustomerPrintDetailModel()
                //    {
                //        CustomerID = CustomerMaster.CustomerID,
                //        CustomerNameTitle = CustomerMaster.NameTitle,
                //        CustomerName = CustomerMaster.CustomerName,
                //        CustomerAddress = CustomerMaster.Address,
                //        CustomerCityName = CustomerMaster.tblCity.CityName,
                //        CustomerCityStateShortName = CustomerMaster.tblCity.tblState.StateShortName ?? CustomerMaster.tblCity.tblState.StateName,
                //        CustomerCityStateGSTCode = CustomerMaster.tblCity.tblState.GSTCode,
                //        CustomerCityCountryName = CustomerMaster.tblCity.tblCountry.CountryName,
                //        CustomerPostCode = CustomerMaster.PostCode,
                //        CustomerMobileNo = CustomerMaster.MobileNo,
                //        CustomerPhoneNo = CustomerMaster.PhoneNo,
                //        CustomerEMailID = CustomerMaster.EMailID,
                //        CustomerWebsite = CustomerMaster.Website,
                //        CustomerPAN = CustomerMaster.PAN,
                //        CustomerGSTNo = CustomerMaster.GSTNo,
                //        CustomerServiceTaxNo = CustomerMaster.ServiceTaxNo
                //    }
                //});


                #region Calculate Opening Balance
                decimal OpeningBalanceAmt = 0;
                //if (DateFrom.HasValue)
                {
                    var OPBAL_OpBalRec = db.tblCustomerOpBals.Where(r => r.CustomerID == CustomerID && r.OpBalDate < DateFrom &&
                                               r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                               r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID).OrderByDescending(r => r.OpBalDate).FirstOrDefault();

                    decimal OpBalAmt = 0;
                    if (OPBAL_OpBalRec != null)
                    {
                        OpBalAmt = OPBAL_OpBalRec.OpBalAmt;
                    }

                    /// Sales 
                    decimal SaleAmt = (from r in db.tblSaleInvoices
                                       where r.CustomerAccountID == CustomerID &&
                                           r.SaleInvoiceDate < DateFrom &&
                                           r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                           r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                       select r.NetAmt
                                           ).Sum(gr => (decimal?)gr) ?? 0;
                    /// Sale Return 
                    decimal SRAmt = (from r in db.tblSaleReturns
                                     where r.CustomerAccountID == CustomerID &&
                                     r.SaleReturnDate < DateFrom &&
                                     r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                     r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                     select r.NetAmt).Sum(r => (decimal?)r) ?? 0;

                    /// Purchase
                    decimal PurchaseAmt = (from r in db.tblPurchaseBills
                                           where r.CustomerAccountID == CustomerID &&
                                           r.PurchaseBillDate < DateFrom &&
                                           r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                           r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                           select r.NetAmt).Sum(r => (decimal?)r) ?? 0;

                    /// Purchase Return
                    decimal PRAmt = (from r in db.tblPurchaseReturns
                                     where r.CustomerAccountID == CustomerID &&
                                     r.PurchaseReturnDate < DateFrom &&
                                     r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                     r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                     select r.NetAmt).Sum(r => (decimal?)r) ?? 0;

                    /// Receipts
                    decimal RecAmt = (from r in db.tblReceipts
                                          //where r.CustomerID == CustomerID &&
                                      where r.AccountID == CustomerID &&
                                      r.ReceiptDate < DateFrom &&
                                      r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                      r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                      select r.Amount).Sum(r => (decimal?)r) ?? 0;

                    /// Paid Amt
                    decimal PaidAmt = (from r in db.tblPayments
                                           //where r.CustomerID == CustomerID &&
                                       where r.AccountID == CustomerID &&
                                      r.PaymentDate < DateFrom &&
                                       r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                       r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                       select r.Amount).Sum(r => (decimal?)r) ?? 0;

                    OpeningBalanceAmt = OpBalAmt + SaleAmt - SRAmt - PurchaseAmt + PRAmt - RecAmt + PaidAmt;
                }
                #endregion

                List<TransactionRegisterReportModel> TransactionDS = new List<TransactionRegisterReportModel>();

                if (OpeningBalanceAmt != 0)
                {
                    TransactionDS.Add(
                        new TransactionRegisterReportModel()
                        {
                            TransactionID = 0,
                            TransactionDate = DateFrom,
                            TransactionNoPrefix = "",
                            TransactionNo = 0,
                            CustomerID = CustomerID,
                            AmountSale = (OpeningBalanceAmt > 0 ? OpeningBalanceAmt : 0),
                            AmountRecd = (OpeningBalanceAmt < 0 ? Math.Abs(OpeningBalanceAmt) : 0),
                            TransactionType = "OP.Bal",
                            TransactionTypePrt = 0
                        });
                }

                /// Opening Balance
                TransactionDS.AddRange(from r in db.tblCustomerOpBals
                                       where r.CustomerID == CustomerID &&
                       (r.OpBalDate >= DateFrom &&
                       (DateTo == null || r.OpBalDate <= DateTo)) &&
                       r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                       r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                       select new TransactionRegisterReportModel()
                                       {
                                           TransactionID = r.OpBalID,
                                           TransactionDate = r.OpBalDate,
                                           TransactionNoPrefix = "",
                                           TransactionNo = 0,
                                           CustomerID = r.CustomerID,
                                           AmountSale = (r.OpBalAmt > 0 ? r.OpBalAmt : 0),
                                           AmountRecd = (r.OpBalAmt < 0 ? Math.Abs(r.OpBalAmt) : 0),
                                           TransactionType = "OP.Bal",
                                           TransactionTypePrt = 1,
                                           rcdt = r.rcdt,
                                       });


                /// Sales 
                TransactionDS.AddRange(from r in db.tblSaleInvoices
                                       join joinp in db.tblSaleInvoiceNoPrefixes on r.SaleInvoiceNoPrefixID equals joinp.SaleInvoiceNoPrefixID into grp
                                       from rp in grp.DefaultIfEmpty()
                                       where r.CustomerAccountID == CustomerID &&
                       (r.SaleInvoiceDate >= DateFrom &&
                       (DateTo == null || r.SaleInvoiceDate <= DateTo)) &&
                       r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                       r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                       select new TransactionRegisterReportModel()
                                       {

                                           TransactionID = r.SaleInvoiceID,
                                           TransactionDate = r.SaleInvoiceDate,
                                           TransactionNoPrefix = (r.tblSaleInvoiceNoPrefix != null ? (r.tblSaleInvoiceNoPrefix.PrefixName ?? "") : ""),
                                           TransactionNo = r.SaleInvoiceNo,
                                           CustomerID = r.CustomerAccountID,
                                           //CustomerName = r.tblCustomer.CustomerName + (r.tblCustomer.Address != null && r.tblCustomer.Address != "" ? ", " + r.tblCustomer.Address : ""),
                                           Descr = "Sale Invoice No. " + (r.tblSaleInvoiceNoPrefix != null ? r.tblSaleInvoiceNoPrefix.PrefixName : "") + r.SaleInvoiceNo,
                                           AmountSale = r.NetAmt,
                                           TransactionType = "Sale",
                                           TransactionTypePrt = 2,
                                           rcdt = r.rcdt,
                                       });

                /// Sale Return 
                TransactionDS.AddRange(

                    db.tblSaleReturns.Where(r => r.CustomerAccountID == CustomerID &&
                    (r.SaleReturnDate >= DateFrom &&
                    (DateTo == null || r.SaleReturnDate <= DateTo)) &&
                    r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                    r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID).

                    Select<tblSaleReturn, TransactionRegisterReportModel>(r => new TransactionRegisterReportModel()
                    {
                        TransactionID = r.SaleReturnID,
                        TransactionDate = r.SaleReturnDate,
                        TransactionNoPrefix = "",
                        TransactionNo = r.SaleReturnNo,
                        CustomerID = r.CustomerAccountID,
                        //CustomerName = r.tblCustomer.CustomerName + (r.tblCustomer.Address != null && r.tblCustomer.Address != "" ? ", " + r.tblCustomer.Address : ""),
                        Descr = "Sale Return No. " + r.SaleReturnNo,
                        AmountRecd = r.NetAmt,
                        TransactionType = "S/R",
                        TransactionTypePrt = 3,
                        rcdt = r.rcdt,
                    })
                );

                bool AllowPurchaseReceiptNo = Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReceiptNo;
                /// Purchase
                TransactionDS.AddRange(

                    db.tblPurchaseBills.Where(r => r.CustomerAccountID == CustomerID &&
                    (r.PurchaseBillDate >= DateFrom &&
                    (DateTo == null || r.PurchaseBillDate <= DateTo)) &&
                    r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                    r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID).

                    Select<tblPurchaseBill, TransactionRegisterReportModel>(r => new TransactionRegisterReportModel()
                    {
                        TransactionID = r.PurchaseBillID,
                        TransactionDate = r.PurchaseBillDate,
                        TransactionNoPrefix = "",
                        TransactionNo = r.PurchaseReceiptNo ?? 0,
                        CustomerID = r.CustomerAccountID,
                        //CustomerName = r.tblCustomer.CustomerName + (r.tblCustomer.Address != null && r.tblCustomer.Address != "" ? ", " + r.tblCustomer.Address : ""),
                        Descr = "Purchase Bill No. " + r.PurchaseBillNo + (AllowPurchaseReceiptNo ? ", Purchase Receipt No. " + r.PurchaseReceiptNo : ""),
                        AmountRecd = r.NetAmt,
                        TransactionType = "Purchase",
                        TransactionTypePrt = 4,
                        rcdt = r.rcdt,
                    })
                );

                /// Purchase Return 
                TransactionDS.AddRange(

                    db.tblPurchaseReturns.Where(r => r.CustomerAccountID == CustomerID &&
                    (r.PurchaseReturnDate >= DateFrom &&
                    (DateTo == null || r.PurchaseReturnDate <= DateTo)) &&
                    r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                    r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID).

                    Select<tblPurchaseReturn, TransactionRegisterReportModel>(r => new TransactionRegisterReportModel()
                    {
                        TransactionID = r.PurchaseReturnID,
                        TransactionDate = r.PurchaseReturnDate,
                        TransactionNoPrefix = "",
                        TransactionNo = r.PurchaseReturnNo,
                        //CustomerID = r.CustomerID,
                        //CustomerName = r.tblCustomer.CustomerName + (r.tblCustomer.Address != null && r.tblCustomer.Address != "" ? ", " + r.tblCustomer.Address : ""),
                        Descr = "Purchase Return No. " + r.PurchaseReturnNo,
                        AmountSale = r.NetAmt,
                        TransactionType = "P/R",
                        TransactionTypePrt = 5,
                        rcdt = r.rcdt,
                    })
                );


                /// Receipts
                TransactionDS.AddRange(

                     //db.tblReceipts.Where(r => r.CustomerID == CustomerID &&
                     db.tblReceipts.Where(r => r.AccountID == CustomerID &&
                    (r.ReceiptDate >= DateFrom &&
                    (DateTo == null || r.ReceiptDate <= DateTo)) &&
                    r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                    r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID).

                    Select<tblReceipt, TransactionRegisterReportModel>(r => new TransactionRegisterReportModel()
                    {
                        TransactionID = r.ReceiptID,
                        TransactionDate = r.ReceiptDate,
                        TransactionNoPrefix = "",
                        TransactionNo = r.ReceiptNo,
                        //CustomerID = r.CustomerID,
                        CustomerID = r.AccountID,
                        //CustomerName = r.tblCustomer.CustomerName + (r.tblCustomer.Address != null && r.tblCustomer.Address != "" ? ", " + r.tblCustomer.Address : ""),
                        Descr = "Receipt No. " + r.ReceiptNo,
                        AmountRecd = r.Amount,
                        TransactionType = "Receipt",
                        TransactionTypePrt = 6,
                        rcdt = r.rcdt,
                    })
                );

                /// Payment
                TransactionDS.AddRange(

                      //db.tblPayments.Where(r => r.CustomerID == CustomerID &&
                      db.tblPayments.Where(r => r.AccountID == CustomerID &&
                    (r.PaymentDate >= DateFrom &&
                    (DateTo == null || r.PaymentDate <= DateTo)) &&
                    r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                    r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID).

                    Select<tblPayment, TransactionRegisterReportModel>(r => new TransactionRegisterReportModel()
                    {
                        TransactionID = r.PaymentID,
                        TransactionDate = r.PaymentDate,
                        TransactionNoPrefix = "",
                        TransactionNo = r.PaymentNo,
                        //CustomerID = r.CustomerID,
                        CustomerID = r.AccountID,
                        //CustomerName = r.tblCustomer.CustomerName + (r.tblCustomer.Address != null && r.tblCustomer.Address != "" ? ", " + r.tblCustomer.Address : ""),
                        Descr = "Payment V. No. " + r.PaymentNo,
                        AmountSale = r.Amount,
                        TransactionType = "Payment",
                        TransactionTypePrt = 7,
                        rcdt = r.rcdt,
                    })
                );


                /// Finalization of data
                //TransactionDS = TransactionDS.OrderBy(r => r.TransactionDate).ThenBy(r => r.TransactionTypePrt).ThenBy(r => r.TransactionID).ToList();//.ThenBy(r=> (int)r.TransactionType).ToList();
                /// 14-Oct-2017 - rcdt was added in order by 
                TransactionDS = TransactionDS.OrderBy(r => r.TransactionDate).ThenBy(r => r.rcdt).ThenBy(r => r.TransactionID).ToList();//.ThenBy(r=> (int)r.TransactionType).ToList();

                if (DateFrom != null)
                {
                    //decimal BeginningBalane = db.tblSaleInvoices.Where(r => r.CustomerID == CustomerID && r.SaleInvoiceDate < DateFrom.Value).Sum(r => (decimal?)r.NetAmt) ?? 0;
                    //BeginningBalane -= db.tblReceipts.Where(r => r.CustomerID == CustomerID && r.ReceiptDate < DateFrom.Value).Sum(r => (decimal?) r.Amount) ?? 0;

                    decimal BeginningBalane = TransactionDS.Where(r => r.TransactionDate < DateFrom).Sum(r => (decimal?)(r.AmountSale - r.AmountRecd)) ?? 0;

                    if (BeginningBalane != 0)
                    {
                        TransactionDS.Insert(0, new TransactionRegisterReportModel()
                        {
                            TransactionDate = DateFrom,
                            Descr = "OP.Bal",
                            AmountSale = (BeginningBalane > 0 ? (decimal?)BeginningBalane : null),
                            AmountRecd = (BeginningBalane < 0 ? (decimal?)Math.Abs(BeginningBalane) : null)
                        });
                    }
                }

                decimal RunningBalance = 0;
                foreach (var r in TransactionDS)
                {
                    if (r.TransactionType == "OP.Bal" || r.TransactionType == "Opening Balance")
                    {
                        RunningBalance = 0;
                    }
                    RunningBalance += (r.AmountSale ?? 0) - (r.AmountRecd ?? 0); //(r.TransactionType == eTransactionType.Sale ? r.Amount : -r.Amount);
                    r.Balance = RunningBalance;
                };
                
                return TransactionDS;
            }
        }
    }
}
