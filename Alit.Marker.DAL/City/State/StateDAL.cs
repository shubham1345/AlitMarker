using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model.City.State;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.City.State
{
    public class StateDAL : ICRUDDAL, IGridCRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((StateViewModel)ViewModel);
        }

        public SavingResult SaveRecord(IGridCRUDViewModel ViewModel)
        {
            return SaveRecord((StateViewModel)ViewModel);
        }

        public SavingResult SaveRecord(StateViewModel ViewModel)
        {
            SavingResult res = new SavingResult();
            if (string.IsNullOrWhiteSpace(ViewModel.StateName))
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please enter State Name.";
                return res;
            }
            if (ViewModel.StateName.Length > 100)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Maximum 100 chars accepted in State Name.";
                return res;
            }
            if (ViewModel.CountryID == 0)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please select Country.";
                return res;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.StateName, ViewModel.StateID, db))
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Can not accept duplicate State Name.";
                    return res;
                }

                tblState SaveModel = null;

                if (ViewModel.StateID == 0)
                {
                    SaveModel = new tblState();
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    db.tblStates.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblStates.Find(ViewModel.StateID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    db.tblStates.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.redt = DateTime.Now;
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                }

                SaveModel.StateName = ViewModel.StateName;
                SaveModel.CountryID = ViewModel.CountryID;

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.StateID;
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
            res.ValidationMessage = null;
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (db.tblCities.Any(r => r.StateID == ID))
                {
                    res.ValidationMessage = "State is already selected in Cities.";
                }
            }
            res.IsValidForDelete = string.IsNullOrWhiteSpace(res.ValidationMessage);
            return res;
        }

        public SavingResult DeleteRecord(long ID)
        {
            SavingResult res = new SavingResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                db.tblStates.RemoveRange(db.tblStates.Where(r => r.StateID == ID));

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

        public IEnumerable<IGridCRUDViewModel> GetViewModelList() { return GetViewModelList(null); }
        public IEnumerable<IGridCRUDViewModel> GetViewModelList(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblStates

                           join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                           from rcu in grcu.DefaultIfEmpty()

                           join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                           from reu in greu.DefaultIfEmpty()

                           orderby r.StateName
                           select new StateViewModel()
                           {
                               RecordState = (eRecordState)r.rstate,

                               StateID = r.StateID,
                               StateName = r.StateName,
                               CountryID = r.CountryID,

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

        ICRUDViewModel ICRUDDAL.GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public IGridCRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public StateViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblStates

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.StateID == ID

                        select new StateViewModel()
                        {
                            StateID = r.StateID,
                            StateName = r.StateName,
                            CountryID = r.CountryID,

                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : null),
                            EditedUserName = (reu != null ? reu.UserName : null),
                        }).FirstOrDefault();
            }
        }

        public bool IsDuplicateRecord(string StateName, long ExcludeID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (IsDuplicateRecord(StateName, ExcludeID, db));
            }
        }

        public bool IsDuplicateRecord(string StateName, long ExcludeID, dbMarkerEntities db)
        {
            StateName = StateName.ToUpper();
            return (db.tblStates.Any(r => r.StateName.ToUpper() == StateName && r.StateID != ExcludeID));
        }

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            return GetLookupList();
        }

        public List<StateLookupListModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblStates

                           join jc in db.tblCountries on r.CountryID equals jc.CountryID into gc
                           from c in gc.DefaultIfEmpty()

                           where r.rstate != (byte)eRecordState.Deactivated

                           orderby r.StateName

                           select new StateLookupListModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               StateID = r.StateID,
                               StateName = r.StateName,
                               CountryName = (c != null ? c.CountryName : null),
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
                var SaveModel = db.tblStates.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblStates.Attach(SaveModel);
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
    }
}
