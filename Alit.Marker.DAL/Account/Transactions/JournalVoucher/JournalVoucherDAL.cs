using Alit.Marker.DAL.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model.Account.Transactions.JournalVoucher;
using Alit.Marker.DAL.Account.Account;
using Alit.Marker.Model.Account.Account;

namespace Alit.Marker.DAL.Account.Transactions.JournalVoucher
{
    public class JournalVoucherDAL : IDashboardDAL, ICRUDDAL
    {
        AccountVoucherDAL AccountVoucherDALObj;

        public JournalVoucherDAL()
        {
            AccountVoucherDALObj = new AccountVoucherDAL();
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((JournalVoucherViewModel)ViewModel);
        }

        public SavingResult SaveRecord(JournalVoucherViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (ViewModel.JournalVoucherNo == 0)
            {
                res.ValidationError = "Please enter Journal Voucher No.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.JVDetails.Count == 0)
            {
                res.ValidationError = "Please enter Journal Voucher Details.";
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
                tblJournalVoucher SaveModel;

                if (ViewModel.JournalVoucherID == 0)
                {
                    SaveModel = new tblJournalVoucher();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;

                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;

                    SaveModel.rcdt = DateTime.Now;
                    db.tblJournalVouchers.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblJournalVouchers.Find(ViewModel.JournalVoucherID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Record not found, Selected record may be deleted by another user over network. Please contact your admin.";
                        return res;
                    }

                    db.tblJournalVouchers.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;

                    db.tblJournalVoucherDetails.RemoveRange(db.tblJournalVoucherDetails.Where(r => r.JournalVoucherID == SaveModel.JournalVoucherID));
                }

                SaveModel.JournalVoucherNo = ViewModel.JournalVoucherNo;
                SaveModel.JournalVoucherDate = ViewModel.JournalVoucherDate;
                SaveModel.VoucherTypeID = ViewModel.VoucherTypeID;
                SaveModel.Amount = ViewModel.JVDetails.Where(r => r.DebitAmount > 0).Sum(r => r.DebitAmount);
                SaveModel.Narration = ViewModel.Narration;

                db.tblJournalVoucherDetails.AddRange(ViewModel.JVDetails.Select(r => new tblJournalVoucherDetail()
                {
                    tblJournalVoucher = SaveModel,
                    AccountID = r.AccountID,
                    Amount = (r.DebitAmount > 0 ? r.DebitAmount : -r.CreditAmount),
                }));

                /// Passing Accounting Effects
                var FirstRecord = ViewModel.JVDetails.FirstOrDefault(r => r.DebitAmount != 0 || r.CreditAmount != 0);
                int FirstRecordType = (FirstRecord.DebitAmount != 0 ? 1 : 2); // 1 - Debit, 2 - Credit
                long? BookAccountRecordAccountID = ViewModel.JVDetails.FirstOrDefault(r => (r.DebitAmount != 0 ? 1 : 2) != FirstRecordType && (r.DebitAmount != 0 || r.CreditAmount != 0))?.AccountID;

                tblAccountVoucher AccountVoucherSaveModel = null;
                AccountVoucherDALObj.SaveRecord(new AccountVoucherViewModel()
                {
                    AccountVoucherID = ViewModel.AccountVoucherID,
                    VoucherDate = ViewModel.JournalVoucherDate,
                    VoucherNo = ViewModel.JournalVoucherNo.ToString(),
                    Amount = ViewModel.JVDetails.Where(r => r.DebitAmount > 0).Sum(r => r.DebitAmount),
                    VoucherTypeID = ViewModel.VoucherTypeID,
                    CustomerAccountID = FirstRecord.AccountID,
                    BookAccountID = BookAccountRecordAccountID,
                    AccountVoucherDetails = (ViewModel.JVDetails.Select(r => new AccountVoucherDetaillViewModel()
                    {
                        AccountID = r.AccountID,
                        Amount = (r.DebitAmount > 0 ? r.DebitAmount : -r.CreditAmount),
                        Narration = "Journal Voucher"

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
                    res.PrimeKeyValue = SaveModel.JournalVoucherNo;
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
                tblJournalVoucher RecordToDelete = db.tblJournalVouchers.FirstOrDefault(r => r.JournalVoucherID == DeleteID);
                res = DeleteRecord(RecordToDelete, db);
            }
            else
            {
                res = new SavingResult();
            }
            return res;
        }

        public SavingResult DeleteRecord(tblJournalVoucher RecordToDelete, dbMarkerEntities db)
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
                db.tblJournalVoucherDetails.RemoveRange(db.tblJournalVoucherDetails.Where(r => r.JournalVoucherID == RecordToDelete.JournalVoucherID));
                db.tblJournalVouchers.Remove(RecordToDelete);
            }
            return res;
        }

        //public SavingResult DeleteRecord(long ID)
        //{
        //    SavingResult res = new SavingResult();
        //    using (dbMarkerEntities db = new dbMarkerEntities())
        //    {
        //        db.tblJournalVoucherDetails.RemoveRange(db.tblJournalVoucherDetails.Where(r => r.JournalVoucherID == ID));
        //        db.tblJournalVouchers.RemoveRange(db.tblJournalVouchers.Where(r => r.JournalVoucherID == ID));

        //        try
        //        {
        //            db.SaveChanges();
        //            res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
        //        }
        //        catch (Exception ex)
        //        {
        //            CommonFunctions.GetFinalError(res, ex);
        //        }
        //    }
        //    return res;
        //}

        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res =
                    (from r in db.tblJournalVouchers

                     join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                     from rcu in grcu.DefaultIfEmpty()

                     join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                     from reu in greu.DefaultIfEmpty()

                     where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                     orderby r.JournalVoucherNo

                     select new JournalVoucherDashboardViewModel()
                     {
                         JournalVoucherID = r.JournalVoucherID,
                         JournalVoucherNo = r.JournalVoucherNo,
                         Amount = r.Amount,
                         JournalVoucherDate = r.JournalVoucherDate,
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

        public JournalVoucherViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblJournalVouchers

                        where r.JournalVoucherID == ID

                        select new JournalVoucherViewModel()
                        {
                            JournalVoucherID = r.JournalVoucherID,
                            JournalVoucherNo = r.JournalVoucherNo,
                            JournalVoucherDate = r.JournalVoucherDate,
                            Amount = r.Amount,
                            Narration = r.Narration,
                            VoucherTypeID = r.VoucherTypeID,
                            AccountVoucherID = r.AccountVoucherID,

                            JVDetails = (from jvd in db.tblJournalVoucherDetails

                                         where jvd.JournalVoucherID == r.JournalVoucherID

                                         select new JournalVoucherDetailViewModel()
                                         {
                                             JournalVoucherDetailID = jvd.JournalVoucherDetailID,
                                             JournalVoucherID = jvd.JournalVoucherID,
                                             AccountID = jvd.AccountID,

                                             DebitAmount = (jvd.Amount > 0 ? jvd.Amount : 0M),
                                             CreditAmount = (jvd.Amount < 0 ? Math.Abs(jvd.Amount) : 0M),
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
                var SaveModel = db.tblJournalVouchers.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblJournalVouchers.Attach(SaveModel);
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

        public int GetMaxJournalVoucherNo()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (db.tblJournalVouchers.Where(r => r.CompanyID == 0 || r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID).Max(r => (int?)r.JournalVoucherNo) ?? 0) + 1;
            }
        }
    }
}
