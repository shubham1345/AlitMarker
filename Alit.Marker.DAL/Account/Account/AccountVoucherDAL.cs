using Alit.Marker.DAL.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.DBO;

namespace Alit.Marker.DAL.Account.Account
{
    public class AccountVoucherDAL : ICRUDDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((AccountVoucherViewModel)ViewModel);
        }

        public SavingResult SaveRecord(AccountVoucherViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblAccountVoucher SaveModel;
                res = SaveRecord(ViewModel, out SaveModel, db, res);

                if (!String.IsNullOrWhiteSpace(res.ValidationError))
                {
                    return res;
                }

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.AccountVoucherID;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public SavingResult SaveRecord(AccountVoucherViewModel ViewModel, out tblAccountVoucher SaveModel, dbMarkerEntities db, SavingResult res)
        {
            SaveModel = null;
            if (ViewModel.VoucherDate == null)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please enter Voucher Date.";
                return res;
            }
            if (ViewModel.VoucherTypeID == 0)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please enter Voucher Type.";
                return res;
            }
            if (ViewModel.Amount == 0)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Amount should be greater than 0.";
                return res;
            }
            if (ViewModel.AccountVoucherDetails.Sum(r => r.Amount) != 0)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Does not match Amount-.";
                return res;
            }

            if (ViewModel.AccountVoucherID == 0) 
            {
                SaveModel = new tblAccountVoucher();
                SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.rcdt = DateTime.Now;
                SaveModel.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;

                db.tblAccountVouchers.Add(SaveModel);
            }
            else
            {
                SaveModel = db.tblAccountVouchers.Find(ViewModel.PrimeKeyID);

                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                    return res;
                }

                db.tblAccountVouchers.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.redt = DateTime.Now;

                db.tblAccountVoucherDetaills.RemoveRange(db.tblAccountVoucherDetaills.Where(r => r.AccountVoucherID == ViewModel.AccountVoucherID));
            }

            SaveModel.VoucherDate = ViewModel.VoucherDate;
            SaveModel.VoucherNo = ViewModel.VoucherNo;
            SaveModel.VoucherTypeID = ViewModel.VoucherTypeID;
            SaveModel.Amount = ViewModel.Amount;
            SaveModel.CustomerAccountID = ViewModel.CustomerAccountID;
            SaveModel.BookAccountID = ViewModel.BookAccountID;
            SaveModel.Narration = ViewModel.Narration;

            tblAccountVoucher AccountVoucherSaveModel = SaveModel;
            db.tblAccountVoucherDetaills.AddRange(ViewModel.AccountVoucherDetails.Select(r => new tblAccountVoucherDetaill()
            {
                tblAccountVoucher = AccountVoucherSaveModel,
                AccountID = r.AccountID,
                Amount = r.Amount,
                Narration = r.Narration,
            }));

            return res;
        }

        ////public SavingResult SaveRecord(AccountVoucherViewModel ViewModel)
        ////{
        ////    SavingResult res = new SavingResult();

        ////    using (dbMarkerEntities db = new dbMarkerEntities())
        ////    {
        ////        tblAccountVoucher SaveModel = null;
        ////        if (ViewModel.VoucherID == 0) // New Entry
        ////        {
        ////            SaveModel = new tblAccountVoucher();
        ////            SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
        ////            SaveModel.rcdt = DateTime.Now;
        ////            SaveModel.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;

        ////            db.tblAccountVouchers.Add(SaveModel);
        ////        }
        ////        else
        ////        {
        ////            SaveModel = db.tblAccountVouchers.Find(ViewModel.PrimeKeyID);

        ////            if (SaveModel == null)
        ////            {
        ////                res.ExecutionResult = eExecutionResult.ValidationError;
        ////                res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
        ////                return res;
        ////            }

        ////            db.tblAccountVouchers.Attach(SaveModel);
        ////            db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

        ////            SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
        ////            SaveModel.redt = DateTime.Now;

        ////            db.tblAccountVoucherDetaills.RemoveRange(db.tblAccountVoucherDetaills.Where(r => r.VoucherID == ViewModel.VoucherID));
        ////        }

        ////        SaveModel.VoucherDate = ViewModel.VoucherDate;
        ////        SaveModel.VoucherNo = ViewModel.VoucherNo;
        ////        SaveModel.VoucherTypeID = ViewModel.VoucherTypeID;
        ////        SaveModel.Amount = ViewModel.Amount;

        ////        db.tblAccountVoucherDetaills.AddRange(ViewModel.dsAccountVoucherDetail.Select(r => new tblAccountVoucherDetaill()
        ////        {
        ////            tblAccountVoucher = SaveModel,
        ////            AccountID = r.AccountID,
        ////            Amount = r.Amount,
        ////            Narration = r.Narration,
        ////        }));

        ////        try
        ////        {
        ////            db.SaveChanges();
        ////            res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
        ////            res.PrimeKeyValue = SaveModel.VoucherID;
        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            CommonFunctions.GetFinalError(res, ex);
        ////        }
        ////    }
        ////        return res;
        ////}

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
                tblAccountVoucher RecordToDelete = db.tblAccountVouchers.FirstOrDefault(r => r.AccountVoucherID == DeleteID);
                res = DeleteRecord(RecordToDelete, db);
            }
            else
            {
                res = new SavingResult();
            }
            return res;
        }

        public SavingResult DeleteRecord(tblAccountVoucher RecordToDelete, dbMarkerEntities db)
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
                db.tblAccountVoucherDetaills.RemoveRange(RecordToDelete.tblAccountVoucherDetaills);
                db.tblAccountVouchers.Remove(RecordToDelete);
            }
            return res;
        }

        //public SavingResult DeleteRecord(long ID)
        //{
        //    SavingResult res = new SavingResult();

        //    using (dbMarkerEntities db = new dbMarkerEntities())
        //    {
        //        db.tblAccountVoucherDetaills.RemoveRange(db.tblAccountVoucherDetaills.Where(r => r.VoucherID == ID));
        //        db.tblAccountVouchers.RemoveRange(db.tblAccountVouchers.Where(r => r.VoucherID == ID));

        //        try
        //        {
        //            db.SaveChanges();
        //            res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
        //        }
        //        catch (Exception ex)
        //        {
        //            CommonFunctions.GetFinalError(ex);
        //        }
        //    }
        //    return res;
        //}

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            throw new NotImplementedException();
        }

        public SavingResult UpdateRecordState(long ID, eRecordState newState)
        {
            throw new NotImplementedException();
        }

        public BeforeUpdateRecordStateValidationResult ValidateBeforeUpdateRecordState(long ID, eRecordState oldState, eRecordState newState)
        {
            throw new NotImplementedException();
        }
    }
}
