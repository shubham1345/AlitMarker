using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.CashBank;
using Alit.Marker.DBO;
using Alit.Marker.Model.Account.Transactions.Payment;
using Alit.Marker.DAL.Account.Account;
using Alit.Marker.Model.Account.Account;

namespace Alit.Marker.DAL.Account.Transactions.Payment
{
    public class PaymentDAL : IDashboardDAL, ICRUDDAL
    {
        AccountVoucherDAL AccountVoucherDALObj;

        public PaymentDAL()
        {
            AccountVoucherDALObj = new AccountVoucherDAL();
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((PaymentViewModel)ViewModel);
        }

        public SavingResult SaveRecord(PaymentViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (ViewModel.VoucherTypeID == 0)
            {
                res.ValidationError = "Please select Voucher Type.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.PaymentNo == 0)
            {
                res.ValidationError = "Please enter Payment No.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.CustomerAccountID == 0)
            {
                res.ValidationError = "Please select Customer.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.CashBankAccountID == 0)
            {
                res.ValidationError = "Please select Account.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }


            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.PaymentNo, ViewModel.PaymentID, db))
                {
                    long OldVNo = ViewModel.PaymentNo;
                    ViewModel.PaymentNo = GetNextPaymentNo(db);

                    res.MessageAfterSave = string.Format("New number {0} has been generated, because {1} was already exists.", ViewModel.PaymentNo.ToString(), OldVNo.ToString());
                }

                tblPayment SaveModel = null;
                if (ViewModel.PaymentID == 0) // New Entry
                {
                    SaveModel = new tblPayment();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;

                    db.tblPayments.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblPayments.Find(ViewModel.PrimeKeyID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    db.tblPayments.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;                    
                }

                SaveModel.PaymentDate = ViewModel.PaymentDate;
                SaveModel.PaymentNo = ViewModel.PaymentNo;
                SaveModel.PaymentType = (int)ViewModel.PaymentMode;
                //SaveModel.CustomerID = ViewModel.CustomerID;
                SaveModel.AccountID = ViewModel.CustomerAccountID;
                SaveModel.Amount = ViewModel.Amount;
                SaveModel.BankName = ViewModel.BankName;
                SaveModel.BankBranchName = ViewModel.BankBranchName;
                SaveModel.ChequeNo = ViewModel.ChequeNo;
                SaveModel.Remarks = ViewModel.Remarks;
                SaveModel.CashBankAccountID = ViewModel.CashBankAccountID;
                SaveModel.VoucherTypeID = ViewModel.VoucherTypeID;

                /// Customer Balance
                #region
                //if (SaveModel.PaymentID == 0)
                //{
                //    //DAL.Customer.CustomerBalanceDAL.UpdateBalance(SaveModel.CustomerID, SaveModel.Amount, SaveModel.CompanyID, SaveModel.FinPeriodID, db, res);
                //    DAL.Customer.CustomerBalanceDAL.UpdateBalance(SaveModel.AccountID, SaveModel.Amount, SaveModel.CompanyID, SaveModel.FinPeriodID, db, res);
                //}
                //else
                //{
                //    using (dbMarkerEntities db1 = new dbMarkerEntities())
                //    {
                //        tblPayment OldPayment = db1.tblPayments.FirstOrDefault(r => r.PaymentID == SaveModel.PaymentID);
                //        if (OldPayment != null)
                //        {

                //            /// if previous customer and current customer is same
                //            //if (SaveModel.CustomerID == OldPayment.CustomerID)
                //            if (SaveModel.AccountID == OldPayment.AccountID)
                //            {
                //                decimal UpdateAmt = 0;
                //                UpdateAmt -= OldPayment.Amount;
                //                UpdateAmt += SaveModel.Amount;
                //                //DAL.Customer.CustomerBalanceDAL.UpdateBalance(SaveModel.CustomerID, UpdateAmt, SaveModel.CompanyID, SaveModel.FinPeriodID, db, res);
                //                DAL.Customer.CustomerBalanceDAL.UpdateBalance(SaveModel.AccountID, UpdateAmt, SaveModel.CompanyID, SaveModel.FinPeriodID, db, res);
                //            }
                //            else
                //            {
                //                //DAL.Customer.CustomerBalanceDAL.UpdateBalance(OldPayment.CustomerID, -OldPayment.Amount, OldPayment.CompanyID, OldPayment.FinPeriodID, db, res);
                //                DAL.Customer.CustomerBalanceDAL.UpdateBalance(OldPayment.AccountID, -OldPayment.Amount, OldPayment.CompanyID, OldPayment.FinPeriodID, db, res);
                //                //DAL.Customer.CustomerBalanceDAL.UpdateBalance(SaveModel.CustomerID, SaveModel.Amount, SaveModel.CompanyID, SaveModel.FinPeriodID, db, res);
                //                DAL.Customer.CustomerBalanceDAL.UpdateBalance(SaveModel.AccountID, SaveModel.Amount, SaveModel.CompanyID, SaveModel.FinPeriodID, db, res);
                //            }
                //        }
                //    }
                //}
                #endregion
                // End - Customer Balance

                string CustomerName = db.tblAccounts.Find(ViewModel.CashBankAccountID).AccountName;

                List<AccountVoucherDetaillViewModel> dsAccountVoucher = new List<AccountVoucherDetaillViewModel>();
                //Debit
                dsAccountVoucher.Add(new AccountVoucherDetaillViewModel
                {
                    AccountID = ViewModel.CustomerAccountID,
                    Amount = ViewModel.Amount,
                    Narration = (ViewModel.PaymentMode == 0 ? "Cash Paid" : (
                        ($"Bank Transfer" +
                                (!string.IsNullOrWhiteSpace(ViewModel.ChequeNo) ? (", " + "Ref. No. " + ViewModel.ChequeNo) : null)
                                +
                                 (", " + "Payment No." + " " + ViewModel.PaymentNo)
                                )
                        )
                     )
                });

                //Credit
                dsAccountVoucher.Add(new AccountVoucherDetaillViewModel
                {
                    AccountID = ViewModel.CashBankAccountID,
                    Amount = -ViewModel.Amount,
                    Narration = (($"Payment Voucher No. " + ViewModel.PaymentNo +  
                                (!string.IsNullOrWhiteSpace(CustomerName) ? ("," + CustomerName) : null)))
                });

                tblAccountVoucher AccountVoucherSaveModel = null;
                AccountVoucherDALObj.SaveRecord(new AccountVoucherViewModel()
                {
                    AccountVoucherID = ViewModel.AccountVoucherID,
                    VoucherDate = ViewModel.PaymentDate,
                    VoucherNo = ViewModel.PaymentNo.ToString(),
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

                //--
                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.PaymentID;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public PaymentViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblPayments

                        where r.PaymentID == ID

                        select new PaymentViewModel()
                        {
                            PaymentID = r.PaymentID,
                            PaymentDate = r.PaymentDate,
                            PaymentNo = r.PaymentNo,
                            PaymentMode = (eModeOfPayment)r.PaymentType,
                            //CustomerID = r.CustomerID,
                            CustomerAccountID = r.AccountID,
                            Amount = r.Amount,
                            BankName = r.BankName,
                            BankBranchName = r.BankBranchName,
                            ChequeNo = r.ChequeNo,
                            Remarks = r.Remarks,
                            CashBankAccountID = r.CashBankAccountID,
                            VoucherTypeID = r.VoucherTypeID,
                            AccountVoucherID = r.AccountVoucherID
                        }).FirstOrDefault();
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long ID)
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
                tblPayment RecordToDelete = db.tblPayments.FirstOrDefault(r => r.PaymentID == DeleteID);
                res = DeleteRecord(RecordToDelete, db);
            }
            else
            {
                res = new SavingResult();
            }
            return res;
        }

        public SavingResult DeleteRecord(tblPayment RecordToDelete, dbMarkerEntities db)
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
                ////Customer.CustomerBalanceDAL.UpdateBalance(RecordToDelete.CustomerID, -RecordToDelete.Amount, RecordToDelete.CompanyID, RecordToDelete.FinPeriodID, db, res);
                //Customer.CustomerBalanceDAL.UpdateBalance(RecordToDelete.AccountID, -RecordToDelete.Amount, RecordToDelete.CompanyID, RecordToDelete.FinPeriodID, db, res);
                if (RecordToDelete.AccountVoucherID != 0)
                {
                    AccountVoucherDALObj.DeleteRecord(RecordToDelete.AccountVoucherID, db);
                }
                db.tblPayments.Remove(RecordToDelete);
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

                return (from r in db.tblPayments

                        join jaccount in db.tblAccounts on r.AccountID equals jaccount.AccountID into gacc
                        from acc in gacc.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == CurrentCompanyID && r.FinPeriodID == CurrentFinPerID

                        orderby r.PaymentNo descending

                        select new PaymentDashboardViewModel()
                        {
                            PaymentID = r.PaymentID,
                            PaymentNo = r.PaymentNo,
                            PaymentDate = r.PaymentDate,
                            //CustomerName = r.tblCustomer.CustomerName,
                            AccountName = (acc != null ? acc.AccountName : null),
                            PaymentMode = (eModeOfPayment)r.PaymentType,
                            Amount = r.Amount,
                            Remarks = r.Remarks,

                            RecordState = (eRecordState)r.rstate,
                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : null),
                            EditedUserName = (reu != null ? reu.UserName : null),

                        }).ToList();
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
                var SaveModel = db.tblPayments.Find(ID);

                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                SaveModel.rstate = (byte)newRecordState;
                db.tblPayments.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

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

        public bool IsDuplicateRecord(long PaymentNo, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(PaymentNo, ID, db);
            }
        }

        public bool IsDuplicateRecord(long PaymentNo, long ID, dbMarkerEntities db)
        {
            long CurrentCompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
            long CurrentFinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;

            return db.tblPayments.Any(r => r.CompanyID == CurrentCompanyID && r.FinPeriodID == CurrentFinPerID && r.PaymentNo == PaymentNo &&                                r.PaymentID != ID);
        }
        
        public long GetNextPaymentNo()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return GetNextPaymentNo(db);
            }
        }

        public long GetNextPaymentNo(dbMarkerEntities db)
        {
            long CurrentFinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;

            return (db.tblPayments.Where(r => r.FinPeriodID == CurrentFinPerID).Max(r => (long?)r.PaymentNo) ?? 0) + 1;
        }

    }
}
