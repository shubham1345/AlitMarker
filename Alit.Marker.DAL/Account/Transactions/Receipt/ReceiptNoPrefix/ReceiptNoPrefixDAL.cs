using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DBO;
using Alit.Marker.Model.Account.Transactions.Receipt.ReceiptNoPrefix;

namespace Alit.Marker.DAL.Account.Transactions.Receipt.ReceiptNoPrefix
{
    public class ReceiptNoPrefixDAL : IGridCRUDDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(IGridCRUDViewModel ViewModel)
        {
            return SaveRecord((ReceiptNoPrefixViewModel)ViewModel);
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((ReceiptNoPrefixViewModel)ViewModel);
        }

        public SavingResult SaveRecord(ReceiptNoPrefixViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (String.IsNullOrWhiteSpace(ViewModel.PrefixName))
            {
                res.ValidationError = "Please enter Prefix Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.PrefixName, ViewModel.ReceiptNoPrefixID, db))
                {
                    res.ValidationError = "Can not accept duplicate Prefix Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                tblReceiptNoPrefix SaveModel = null;

                if (ViewModel.ReceiptNoPrefixID == 0)
                {
                    SaveModel = new tblReceiptNoPrefix();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblReceiptNoPrefixes.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblReceiptNoPrefixes.Find(ViewModel.ReceiptNoPrefixID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    db.tblReceiptNoPrefixes.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                }

                SaveModel.PrefixName = ViewModel.PrefixName;

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.ReceiptNoPrefixID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblReceiptNoPrefix FindSaveModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return db.tblReceiptNoPrefixes.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            if (DeleteID == 0)
            {
                Result.IsValidForDelete = false;
                Result.ValidationMessage = "Record not selected";
                return Result;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (db.tblReceipts.Any(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID && r.ReceiptNoPrefixID == DeleteID))
                {
                    Result.ValidationMessage = "Prefix exists in some Purchase Return";
                }
            }
            Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
            return Result;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (DeleteID != 0)
                {
                    tblReceiptNoPrefix RecordToDelete = db.tblReceiptNoPrefixes.FirstOrDefault(r => r.ReceiptNoPrefixID == DeleteID);
                    res = DeleteRecord(RecordToDelete, db);
                }
                else
                {
                    res = new SavingResult();
                    res.ValidationError = "No record selected to delete.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                }

                if (res.ExecutionResult == eExecutionResult.ValidationError)
                {
                    return res;
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

        public SavingResult DeleteRecord(tblReceiptNoPrefix RecordToDelete, dbMarkerEntities db)
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
                db.tblReceiptNoPrefixes.Remove(RecordToDelete);
            }
            return res;
        }

        IEnumerable<IGridCRUDViewModel> IGridCRUDDAL.GetViewModelList()
        {
            return GetViewModelList();
        }

        public List<ReceiptNoPrefixViewModel> GetViewModelList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblReceiptNoPrefixes

                           join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                           from rcu in grcu.DefaultIfEmpty()

                           join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                           from reu in greu.DefaultIfEmpty()

                           where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                           orderby r.PrefixName

                           select new ReceiptNoPrefixViewModel()
                           {
                               ReceiptNoPrefixID = r.ReceiptNoPrefixID,
                               PrefixName = r.PrefixName,

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

        public IGridCRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        ICRUDViewModel ICRUDDAL.GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public ReceiptNoPrefixViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblReceiptNoPrefixes

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.ReceiptNoPrefixID == ID

                        select new ReceiptNoPrefixViewModel()
                        {
                            ReceiptNoPrefixID = r.ReceiptNoPrefixID,
                            PrefixName = r.PrefixName,

                            //RecordState = r.rstate,
                            CreatedDateTime = r.rcdt,
                            CreatedUserID = r.rcuid,
                            EditedDateTime = r.redt,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : null),
                            EditedUserName = (reu != null ? reu.UserName : null),
                        }).FirstOrDefault();
            }
        }

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            return GetLookupList();
        }

        public List<ReceiptNoPrefixLookupModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblReceiptNoPrefixes

                           where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                 && r.rstate != (byte)eRecordState.Deactivated

                           orderby r.PrefixName

                           select new ReceiptNoPrefixLookupModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               ReceiptNoPrefixID = r.ReceiptNoPrefixID,
                               PrefixName = r.PrefixName,
                           }).ToList();
                return res;
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
                var SaveModel = db.tblReceiptNoPrefixes.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                SaveModel.rstate = (byte)newRecordState;
                db.tblReceiptNoPrefixes.Attach(SaveModel);
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

        public bool IsDuplicateRecord(string PrefixName, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(PrefixName, ID, db);
            }
        }

        public bool IsDuplicateRecord(string PrefixName, long ID, dbMarkerEntities db)
        {
            PrefixName = PrefixName.ToUpper();

            return (db.tblReceiptNoPrefixes.Any(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                        && r.PrefixName.ToUpper() == PrefixName && r.ReceiptNoPrefixID != ID));
        }
    }
}
