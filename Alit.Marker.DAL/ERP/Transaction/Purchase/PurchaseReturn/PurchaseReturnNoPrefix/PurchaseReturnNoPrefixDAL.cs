using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix
{
    public class PurchaseReturnNoPrefixDAL : IGridCRUDDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(IGridCRUDViewModel ViewModel)
        {
            return SaveRecord((PurchaseReturnNoPrefixViewModel)ViewModel);
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((PurchaseReturnNoPrefixViewModel)ViewModel);
        }

        public SavingResult SaveRecord(PurchaseReturnNoPrefixViewModel ViewModel)
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
                if (IsDuplicateRecord(ViewModel.PrefixName, ViewModel.PurchaseReturnNoPrefixID, db))
                {
                    res.ValidationError = "Can not accept duplicate Prefix Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                tblPurchaseReturnNoPrefix SaveModel = null;
                if (ViewModel.PurchaseReturnNoPrefixID == 0) // New Entry
                {
                    SaveModel = new tblPurchaseReturnNoPrefix();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblPurchaseReturnNoPrefixes.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblPurchaseReturnNoPrefixes.Find(ViewModel.PurchaseReturnNoPrefixID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    db.tblPurchaseReturnNoPrefixes.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                }

                SaveModel.PrefixName = ViewModel.PrefixName;
                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.PurchaseReturnNoPrefixID;
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
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (db.tblPurchaseReturns.Any(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID 
                     && r.PurchaseReturnNoPrefixID == DeleteID))
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
                    tblPurchaseReturnNoPrefix RecordToDelete = db.tblPurchaseReturnNoPrefixes.FirstOrDefault(r => r.PurchaseReturnNoPrefixID == DeleteID);
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

        public SavingResult DeleteRecord(tblPurchaseReturnNoPrefix RecordToDelete, dbMarkerEntities db)
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
                db.tblPurchaseReturnNoPrefixes.Remove(RecordToDelete);
            }
            return res;
        }

        public IEnumerable<IGridCRUDViewModel> GetViewModelList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblPurchaseReturnNoPrefixes

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.PrefixName

                        select new PurchaseReturnNoPrefixViewModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            PurchaseReturnNoPrefixID = r.PurchaseReturnNoPrefixID,
                            PrefixName = r.PrefixName,

                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : null),
                            EditedUserName = (reu != null ? reu.UserName : null),

                        }).ToList();
            }
        }
        
        IGridCRUDViewModel IGridCRUDDAL.GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public PurchaseReturnNoPrefixViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblPurchaseReturnNoPrefixes

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.PurchaseReturnNoPrefixID == ID

                        select new PurchaseReturnNoPrefixViewModel()
                        {
                            PurchaseReturnNoPrefixID = r.PurchaseReturnNoPrefixID,
                            PrefixName = r.PrefixName,

                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : null),
                            EditedUserName = (reu != null ? reu.UserName : null),

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
                var SaveModel = db.tblPurchaseReturnNoPrefixes.Find(ID);

                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblPurchaseReturnNoPrefixes.Attach(SaveModel);
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
            //if (db.tblPurchaseReturnNoPrefixes.FirstOrDefault(i => 
            //    i.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID && 
            //    i.PrefixName.ToUpper() == PrefixName && i.PurchaseReturnNoPrefixID != ID) != null)
            //{
            //    return true;
            //}
            //return false;

            return db.tblPurchaseReturnNoPrefixes.Any(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                     && r.PrefixName.ToUpper() == PrefixName && r.PurchaseReturnNoPrefixID != ID);
        }

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            return GetLookupList();
        }

        public List<PurchaseReturnNoPrefixLookupListModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblPurchaseReturnNoPrefixes

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                           && r.rstate != (byte)eRecordState.Deactivated

                        //where r.rstate != (byte)eRecordState.Deactivated

                        select new PurchaseReturnNoPrefixLookupListModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            PurchaseReturnNoPrefixID = r.PurchaseReturnNoPrefixID,
                            PrefixName = r.PrefixName,
                        }).ToList();
            }
        }
    }
}
