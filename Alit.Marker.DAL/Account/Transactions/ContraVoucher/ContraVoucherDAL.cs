using Alit.Marker.DAL.Account.Account;
using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.Model.Account.Transactions.ContraVoucher;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Account.Transactions.ContraVoucher
{
    public class ContraVoucherDAL : IDashboardDAL, ICRUDDAL
    {
        AccountVoucherDAL AccountVoucherDALObj;

        public ContraVoucherDAL()
        {
            AccountVoucherDALObj = new AccountVoucherDAL();
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((ContraVoucherViewModel)ViewModel);
        }

        public SavingResult SaveRecord(ContraVoucherViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (ViewModel.ContraVoucherNo == 0)
            {
                res.ValidationError = "Please enter Contra Voucher No.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.CVDetails.Count == 0)
            {
                res.ValidationError = "Please enter Contra Voucher Details.";
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
                tblContraVoucher SaveModel;

                if (ViewModel.ContraVoucherID == 0)
                {
                    SaveModel = new tblContraVoucher();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;

                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;

                    SaveModel.rcdt = DateTime.Now;
                    db.tblContraVouchers.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblContraVouchers.Find(ViewModel.ContraVoucherID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Record not found, Selected record may be deleted by another user over network. Please contact your admin.";
                        return res;
                    }

                    db.tblContraVouchers.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;

                    db.tblContraVoucherDetails.RemoveRange(db.tblContraVoucherDetails.Where(r => r.ContraVoucherID == SaveModel.ContraVoucherID));
                }

                SaveModel.ContraVoucherNo = ViewModel.ContraVoucherNo;
                SaveModel.ContraVoucherDate = ViewModel.ContraVoucherDate;
                SaveModel.VoucherTypeID = ViewModel.VoucherTypeID;
                SaveModel.Amount = ViewModel.CVDetails.Where(r => r.DebitAmount > 0).Sum(r => r.DebitAmount);
                SaveModel.Narration = ViewModel.Narration;

                db.tblContraVoucherDetails.AddRange(ViewModel.CVDetails.Select(r => new tblContraVoucherDetail()
                {
                    tblContraVoucher = SaveModel,
                    AccountID = r.AccountID,
                    Amount = (r.DebitAmount > 0 ? r.DebitAmount : -r.CreditAmount),
                }));

                /// Passing Accounting Effects
                var FirstRecord = ViewModel.CVDetails.FirstOrDefault(r => r.DebitAmount != 0 || r.CreditAmount != 0);
                int FirstRecordType = (FirstRecord.DebitAmount != 0 ? 1 : 2); // 1 - Debit, 2 - Credit
                long? BookAccountRecordAccountID = ViewModel.CVDetails.FirstOrDefault(r => (r.DebitAmount != 0 ? 1 : 2) != FirstRecordType && (r.DebitAmount != 0 || r.CreditAmount != 0))?.AccountID;

                tblAccountVoucher AccountVoucherSaveModel = null;
                AccountVoucherDALObj.SaveRecord(new AccountVoucherViewModel()
                {
                    AccountVoucherID = ViewModel.AccountVoucherID,
                    VoucherDate = ViewModel.ContraVoucherDate,
                    VoucherNo = ViewModel.ContraVoucherNo.ToString(),
                    Amount = ViewModel.CVDetails.Where(r => r.DebitAmount > 0).Sum(r => r.DebitAmount),
                    VoucherTypeID = ViewModel.VoucherTypeID,
                    CustomerAccountID = FirstRecord.AccountID,
                    BookAccountID = BookAccountRecordAccountID,
                    AccountVoucherDetails = (ViewModel.CVDetails.Select(r => new AccountVoucherDetaillViewModel()
                    {
                        AccountID = r.AccountID,
                        Amount = (r.DebitAmount > 0 ? r.DebitAmount : -r.CreditAmount),
                        Narration = "Contra Voucher"
                    }).ToList())
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
                    res.PrimeKeyValue = SaveModel.ContraVoucherNo;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long ID)
        {
            BeforeDeleteValidationResult res = new BeforeDeleteValidationResult();
            res.IsValidForDelete = true;
            return res;
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
                tblContraVoucher RecordToDelete = db.tblContraVouchers.FirstOrDefault(r => r.ContraVoucherID == DeleteID);
                res = DeleteRecord(RecordToDelete, db);
            }
            else
            {
                res = new SavingResult();
            }
            return res;
        }

        public SavingResult DeleteRecord(tblContraVoucher RecordToDelete, dbMarkerEntities db)
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
                if (RecordToDelete.AccountVoucherID != 0)
                {
                    AccountVoucherDALObj.DeleteRecord(RecordToDelete.AccountVoucherID, db);
                }
                db.tblContraVoucherDetails.RemoveRange(db.tblContraVoucherDetails.Where(r => r.ContraVoucherID == RecordToDelete.ContraVoucherID));
                db.tblContraVouchers.Remove(RecordToDelete);
            }
            return res;
        }

        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblContraVouchers

                           join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                           from rcu in grcu.DefaultIfEmpty()

                           join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                           from reu in greu.DefaultIfEmpty()

                           where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                           orderby r.ContraVoucherNo

                           select new ContraVoucherDashboardViewModel()
                           {
                               ContraVoucherID = r.ContraVoucherID,
                               ContraVoucherNo = r.ContraVoucherNo,
                               Amount = r.Amount,
                               ContraVoucherDate = r.ContraVoucherDate,
                               Narration = r.Narration,

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

        public ContraVoucherViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblContraVouchers

                        where r.ContraVoucherID == ID

                        select new ContraVoucherViewModel()
                        {
                            ContraVoucherID = r.ContraVoucherID,
                            ContraVoucherNo = r.ContraVoucherNo,
                            ContraVoucherDate = r.ContraVoucherDate,
                            Amount = r.Amount,
                            Narration = r.Narration,
                            VoucherTypeID = r.VoucherTypeID,
                            AccountVoucherID = r.AccountVoucherID,

                            CVDetails = (from cvd in db.tblContraVoucherDetails

                                         where cvd.ContraVoucherID == r.ContraVoucherID

                                         select new ContraVoucherDetailViewModel()
                                         {
                                             ContraVoucherDetailID = cvd.ContraVoucherDetailID,
                                             ContraVoucherID = cvd.ContraVoucherID,
                                             AccountID = cvd.AccountID,

                                             DebitAmount = (cvd.Amount > 0 ? cvd.Amount : 0M),
                                             CreditAmount = (cvd.Amount < 0 ? Math.Abs(cvd.Amount) : 0M),
                                         }).ToList(),
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
                var SaveModel = db.tblContraVouchers.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblContraVouchers.Attach(SaveModel);
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

        public int GetMaxContraVoucherNo()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (db.tblContraVouchers.Where(r => r.CompanyID == 0 || r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID).Max(r => (int?)r.ContraVoucherNo) ?? 0) + 1;
            }
        }
    }
}
