using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.CashBank;
using Alit.Marker.DBO;
using Alit.Marker.Model.Account.Transactions.Receipt;
using Alit.Marker.DAL.Account.Account;
using Alit.Marker.Model.Account.Account;

namespace Alit.Marker.DAL.Account.Transactions.Receipt
{
    public class ReceiptDAL : IDashboardDAL, ICRUDDAL
    {
        AccountVoucherDAL AccountVoucherDALObj;

        public ReceiptDAL()
        {
            AccountVoucherDALObj = new AccountVoucherDAL();
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((ReceiptViewModel)ViewModel);
        }

        public SavingResult SaveRecord(ReceiptViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (ViewModel.CustomerAccountID == 0)
            {
                res.ValidationError = "Please select Customer.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.ReceiptNo == 0)
            {
                res.ValidationError = "Please enter Receipt No.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.CashBankAccountID == 0)
            {
                if (ViewModel.ModeOfPayment == 0)
                {
                    res.ValidationError = "Please select Cash Account.";
                }
                else
                {
                    res.ValidationError = "Please select Bank Account.";
                }
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (ViewModel.VoucherTypeID == 0)
            {
                res.ValidationError = "Please select Voucher Type.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.ReceiptNo, ViewModel.ReceiptID, db, ViewModel.ReceiptNoPrefixID, ViewModel.ReceiptDate))
                {
                    long OldVNo = ViewModel.ReceiptNo;
                    ViewModel.ReceiptNo = GenerateReceiptNo(ViewModel.ReceiptNoPrefixID, ViewModel.ReceiptDate, db);

                    res.MessageAfterSave = string.Format("New number {0} has been generated, because {1} was already exists.", ViewModel.ReceiptNo.ToString(), OldVNo.ToString());
                }

                tblReceipt SaveModel = null;
                if (ViewModel.ReceiptID == 0) // New Entry
                {
                    SaveModel = new tblReceipt();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                    db.tblReceipts.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblReceipts.Find(ViewModel.ReceiptID);
                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }
                    db.tblReceipts.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                }

                SaveModel.ReceiptDate = ViewModel.ReceiptDate;
                SaveModel.ReceiptNoPrefixID = ViewModel.ReceiptNoPrefixID;
                SaveModel.ReceiptNo = ViewModel.ReceiptNo;
                SaveModel.PaymentType = (int)ViewModel.ModeOfPayment;
                SaveModel.Amount = ViewModel.Amount;
                SaveModel.Remarks = ViewModel.Remarks;
                SaveModel.BankName = ViewModel.BankName;
                SaveModel.BankBranchName = ViewModel.BankBranchName;
                SaveModel.ChequeNo = ViewModel.ChequeNo;
                SaveModel.CashBankAccountID = ViewModel.CashBankAccountID;
                SaveModel.AccountID = ViewModel.CustomerAccountID;
                SaveModel.VoucherTypeID = ViewModel.VoucherTypeID;

                /// Customer Balance
                #region 
                //if (SaveModel.ReceiptID == 0)
                //{
                //    DAL.Customer.CustomerBalanceDAL.UpdateBalance(SaveModel.AccountID, -SaveModel.Amount, SaveModel.CompanyID, SaveModel.FinPeriodID, db, res);
                //}
                //else
                //{
                //    using (dbMarkerEntities db1 = new dbMarkerEntities())
                //    {
                //        tblReceipt OldReceipt = db1.tblReceipts.FirstOrDefault(r => r.ReceiptID == SaveModel.ReceiptID);
                //        if (OldReceipt != null)
                //        {
                //            /// if previous customer and current customer is same
                //            if (SaveModel.AccountID == OldReceipt.AccountID)
                //            {
                //                decimal UpdateAmt = 0;
                //                UpdateAmt += OldReceipt.Amount;
                //                UpdateAmt -= SaveModel.Amount;
                //                DAL.Customer.CustomerBalanceDAL.UpdateBalance(SaveModel.AccountID, UpdateAmt, SaveModel.CompanyID, SaveModel.FinPeriodID, db, res);
                //            }
                //            else
                //            {
                //                DAL.Customer.CustomerBalanceDAL.UpdateBalance(OldReceipt.AccountID, OldReceipt.Amount, OldReceipt.CompanyID, OldReceipt.FinPeriodID, db, res);
                //                DAL.Customer.CustomerBalanceDAL.UpdateBalance(SaveModel.AccountID, -SaveModel.Amount, SaveModel.CompanyID, SaveModel.FinPeriodID, db, res);
                //            }
                //        }
                //    }
                //}
                #endregion
                // End - Customer Balance

                string CustomerName = db.tblAccounts.Find(ViewModel.CashBankAccountID).AccountName;
                string ReceiptPrefixName = db.tblReceiptNoPrefixes.Find(ViewModel.ReceiptNoPrefixID)?.PrefixName;

                List<AccountVoucherDetaillViewModel> dsAccountVoucher = new List<AccountVoucherDetaillViewModel>();
                //Debit
                dsAccountVoucher.Add(new AccountVoucherDetaillViewModel { AccountID = ViewModel.CustomerAccountID, Amount = ViewModel.Amount,
                    Narration = (ViewModel.ModeOfPayment == 0 ? "Cash Received" : (
                        ($"Bank Transfer" +

                                (!string.IsNullOrWhiteSpace(ViewModel.ChequeNo) ? (", " + "Ref. No. " + ViewModel.ChequeNo) : null)
                                +
                                 (", " + "Receipt No." +" " + ReceiptPrefixName + ViewModel.ReceiptNo)
                                )                         
                        )
                     )
                });

                //Credit
                dsAccountVoucher.Add(new AccountVoucherDetaillViewModel
                {
                    AccountID = ViewModel.CashBankAccountID,
                    Amount = -ViewModel.Amount,
                    Narration = (ViewModel.ModeOfPayment == 0 ? "Cash Received" : (($"Bank Transfer" +
                 (!string.IsNullOrWhiteSpace(ViewModel.ChequeNo) ? (", " + "Ref. No. " + ViewModel.ChequeNo) : null) +
                         (", " + "Receipt No." + " " + ReceiptPrefixName + ViewModel.ReceiptNo) +                     
                         (!string.IsNullOrWhiteSpace(CustomerName) ? ("," + CustomerName) : null)
                                                                                   ))
                                )
                });

                tblAccountVoucher AccountVoucherSaveModel = null;
                AccountVoucherDALObj.SaveRecord(new AccountVoucherViewModel()
                {
                    AccountVoucherID = ViewModel.AccountVoucherID,
                    VoucherDate = ViewModel.ReceiptDate,
                    VoucherNo = ViewModel.ReceiptNo.ToString(),
                    Amount = ViewModel.Amount,
                    VoucherTypeID = ViewModel.VoucherTypeID,
                    CustomerAccountID = ViewModel.CustomerAccountID,
                    BookAccountID = ViewModel.CashBankAccountID,
                    AccountVoucherDetails = dsAccountVoucher,
                }, out AccountVoucherSaveModel, db, res);

                if (res != null && (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError))
                {
                    return res;
                }
                SaveModel.tblAccountVoucher = AccountVoucherSaveModel;

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.ReceiptID;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            Result.IsValidForDelete = true;
            return Result;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = null;

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                res = DeleteRecord(DeleteID, db);

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

        public SavingResult DeleteRecord(long DeleteID, dbMarkerEntities db)
        {
            SavingResult res = null;

            if (DeleteID != 0)
            {
                tblReceipt RecordToDelete = db.tblReceipts.FirstOrDefault(r => r.ReceiptID == DeleteID);
                res = DeleteRecord(RecordToDelete, db);
            }
            else
            {
                res = new SavingResult();
            }
            return res;
        }

        public SavingResult DeleteRecord(tblReceipt RecordToDelete, dbMarkerEntities db)
        {
            SavingResult res = new SavingResult();

            if (RecordToDelete == null)
            {
                res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            else
            {
                ////RecordToDelete.tblCustomer.BalanceAmt += RecordToDelete.Amount;
                //Customer.CustomerBalanceDAL.UpdateBalance(RecordToDelete.AccountID, RecordToDelete.Amount, RecordToDelete.CompanyID, RecordToDelete.FinPeriodID, db, res);

                //DAL.Account.Account.AccountVoucherDAL AccountVoucherDALObj = new AccountVoucherDAL();
                //res = AccountVoucherDALObj.DeleteRecord(RecordToDelete.VoucherID, db);
                //if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                //{
                //    return res;
                //}

                if (RecordToDelete.AccountVoucherID != 0)
                {
                    AccountVoucherDALObj.DeleteRecord(RecordToDelete.AccountVoucherID, db);
                }
                db.tblReceipts.Remove(RecordToDelete);
            }
            return res;
        }

        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }
        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long CurrentCompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                long CurrentFinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;

                var res = (from r in db.tblReceipts

                           join joinp in db.tblReceiptNoPrefixes on r.ReceiptNoPrefixID equals joinp.ReceiptNoPrefixID into groupp from p in groupp.DefaultIfEmpty()
                                                                                                           
                           join jaccount in db.tblAccounts on r.AccountID equals jaccount.AccountID into gacc from acc in gacc.DefaultIfEmpty()

                           join jcity in db.tblCities on acc.CityID equals jcity.CityID into gcity
                           from city in gcity.DefaultIfEmpty()


                           join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                           from rcu in grcu.DefaultIfEmpty()

                           join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                           from reu in greu.DefaultIfEmpty()

                           where r.CompanyID == CurrentCompanyID && r.FinPeriodID == CurrentFinPerID

                           orderby r.ReceiptNo descending

                           select new ReceiptDashboardViewModel()
                           {
                               ReceiptID = r.ReceiptID,
                               ReceiptNoPrefixName = (p != null ? p.PrefixName : null),
                               ReceiptNo = r.ReceiptNo,
                               ReceiptDate = r.ReceiptDate,

                               AccountID = r.AccountID,
                               AccountName = (acc != null ? acc.AccountName : null),
                               AccountAddress = (acc != null ? acc.Address : null),
                               AccountCityName = (city != null ? city.CityName : null),

                               ModeOfPayment = (eModeOfPayment)r.PaymentType,
                               Amount = r.Amount,
                               Remarks = r.Remarks,

                               BankName = r.BankName,
                               BankBranchName = r.BankBranchName,
                               ChequeNo = r.ChequeNo,

                               RecordState = (eRecordState)r.rstate,
                               CreatedDateTime = r.rcdt,
                               EditedDateTime = r.redt,
                               CreatedUserID = r.rcuid,
                               EditedUserID = r.reuid,
                               CreatedUserName = (rcu != null ? rcu.UserName : null),
                               EditedUserName = (reu != null ? reu.UserName : null),

                           }).ToList();
                return res;
            }
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public ReceiptViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblReceipts

                        where r.ReceiptID == ID

                        select new ReceiptViewModel()
                        {
                            ReceiptDate = r.ReceiptDate,
                            ReceiptNoPrefixID = r.ReceiptNoPrefixID,
                            ReceiptNo = r.ReceiptNo,
                            CustomerAccountID = r.AccountID,
                            ModeOfPayment = (eModeOfPayment)r.PaymentType,
                            Amount = r.Amount,
                            Remarks = r.Remarks,
                            BankName = r.BankName,
                            BankBranchName = r.BankBranchName,
                            ChequeNo = r.ChequeNo,
                            CashBankAccountID = r.CashBankAccountID,
                            VoucherTypeID = r.VoucherTypeID,
                            AccountVoucherID = r.AccountVoucherID
                        }).FirstOrDefault();
            }
        }

        public BeforeUpdateRecordStateValidationResult ValidateBeforeUpdateRecordState(long ID, eRecordState oldState, eRecordState newState)
        {
            return new BeforeUpdateRecordStateValidationResult() { IsValidForUpdate = true };
        }

        public SavingResult UpdateRecordState(long ID, eRecordState newRecordState)
        {
            SavingResult res = new SavingResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var SaveModel = db.tblReceipts.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblReceipts.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                SaveModel.rstate = (byte)newRecordState;

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

        public bool IsDuplicateRecord(long DocumentNo, long ID, long? PrefixID, DateTime? Date)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(DocumentNo, ID, db, PrefixID, Date);
            }
        }

        public bool IsDuplicateRecord(long DocumentNo, long ID, dbMarkerEntities db, long? PrefixID, DateTime? Date)
        {
            string Series = Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoSeries;
            if (String.IsNullOrWhiteSpace(Series))
            {
                //if (db.tblReceipts.FirstOrDefault(i => i.ReceiptNo == DocumentNo && i.ReceiptID != ID && i.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID) != null)
                //{
                //    return true;
                //}

                return db.tblReceipts.Any(r => r.ReceiptNo == DocumentNo && r.ReceiptID != ID && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID);
            }
            else
            {
                //return (db.tblReceipts.Where(r => r.ReceiptNo == DocumentNo && r.ReceiptID != ID && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID && (
                //    (!Series.Contains("Prefix") || r.ReceiptNoPrefixID == PrefixID) &&
                //    (!Series.Contains("Date") || (Date.HasValue && r.ReceiptDate == Date)) &&
                //    (!Series.Contains("Year") || (Date.HasValue && r.ReceiptDate.Year == Date.Value.Year)) &&
                //    (!Series.Contains("MonthYear") || (Date.HasValue && r.ReceiptDate.Month == Date.Value.Month && r.ReceiptDate.Year == Date.Value.Year))
                //    )
                //    ).FirstOrDefault() != null);

                return db.tblReceipts.Any(r => r.ReceiptNo == DocumentNo && r.ReceiptID != ID && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID && (
                        (!Series.Contains("Prefix") || r.ReceiptNoPrefixID == PrefixID) &&
                        (!Series.Contains("Date") || (Date.HasValue && r.ReceiptDate == Date)) &&
                        (!Series.Contains("Year") || (Date.HasValue && r.ReceiptDate.Year == Date.Value.Year)) &&
                        (!Series.Contains("MonthYear") || (Date.HasValue && r.ReceiptDate.Month == Date.Value.Month && r.ReceiptDate.Year == Date.Value.Year))
                        )
                        );
            }

            //return false;
        }

        public long GenerateReceiptNo(long? PrefixID, DateTime? Date)
        {
            string Series = Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoSeries;
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return GenerateReceiptNo(PrefixID, Date, db);
            }
        }

        public long GenerateReceiptNo(long? PrefixID, DateTime? Date, dbMarkerEntities db)
        {
            string Series = Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoSeries;
            ////using (dbMarkerEntities db = new dbMarkerEntities())
            ////{
            long? MaxInvNo = null;

            if (String.IsNullOrWhiteSpace(Series))
            {
                MaxInvNo = db.tblReceipts.Max(r => (long?)r.ReceiptNo);
            }
            else
            {
                MaxInvNo = db.tblReceipts.Where(r => r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID).
                                                    Where(r => (!Series.Contains("Prefix") || r.ReceiptNoPrefixID == PrefixID) &&
                    (!Series.Contains("Date") || (Date.HasValue && r.ReceiptDate == Date)) &&
                    (!Series.Contains("Year") || (Date.HasValue && r.ReceiptDate.Year == Date.Value.Year)) &&
                    (!Series.Contains("MonthYear") || (Date.HasValue && r.ReceiptDate.Month == Date.Value.Month && r.ReceiptDate.Year == Date.Value.Year))
                    ).Max(r => (long?)r.ReceiptNo);
            }

            if (MaxInvNo.HasValue)
            {
                return MaxInvNo.Value + 1;
            }
            else
            {
                return 1;
            }
            //}
        }
    }
}
