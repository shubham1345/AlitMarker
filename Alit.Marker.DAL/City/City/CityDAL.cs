using Alit.Marker.Model.Template;
using Alit.Marker.Model.City.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;

namespace Alit.Marker.DAL.City.City
{
    public class CityDAL : ICRUDDAL, IGridCRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((CityViewModel)ViewModel);
        }

        public SavingResult SaveRecord(IGridCRUDViewModel ViewModel)
        {
            return SaveRecord((CityViewModel)ViewModel);
        }

        public SavingResult SaveRecord(CityViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (string.IsNullOrWhiteSpace(ViewModel.CityName))
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please enter City Name.";
                return res;
            }

            if (ViewModel.CityName.Length > 100)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Maximum 100 characters accepted in City Name.";
                return res;
            }

            if(ViewModel.StateID == null || ViewModel.StateID == 0)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please select State.";
                return res;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.CityName, ViewModel.StateID, ViewModel.CityID, db))
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Can not accept duplicate City Name.";
                    return res;
                }

                tblCity SaveModel = null;

                if (ViewModel.CityID == 0)
                {
                    SaveModel = new tblCity();
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    db.tblCities.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblCities.Find(ViewModel.CityID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    db.tblCities.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.redt = DateTime.Now;
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                }

                SaveModel.CityName = ViewModel.CityName;
                SaveModel.StateID = ViewModel.StateID;

                tblState StateSaveModel = db.tblStates.Find(ViewModel.StateID);
                if (StateSaveModel != null)
                {
                    SaveModel.CountryID = StateSaveModel.CountryID;
                }
                else
                {
                    SaveModel.CountryID = 0;
                }

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.CityID;
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
                if (db.tblCustomers.Any(r => r.CityID == ID))
                {
                    res.ValidationMessage = "City is already selected in Customers.";
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
                db.tblCities.RemoveRange(db.tblCities.Where(r => r.CityID == ID));

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

        public IEnumerable<IGridCRUDViewModel> GetViewModelList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblCities

                           join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                           from rcu in grcu.DefaultIfEmpty()

                           join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                           from reu in greu.DefaultIfEmpty()

                           orderby r.CityName

                           select new CityViewModel()
                           {
                               CityID = r.CityID,
                               CityName = r.CityName,
                               StateID = r.StateID,

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
        
        IGridCRUDViewModel IGridCRUDDAL.GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public CityViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblCities

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CityID == ID

                        select new CityViewModel()
                        {
                            CityID = r.CityID,
                            CityName = r.CityName,
                            StateID = r.StateID,

                            CreatedDateTime = r.rcdt,
                            CreatedUserID = r.rcuid,
                            EditedDateTime = r.redt,
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
                var SaveModel = db.tblCities.Find(ID);

                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblCities.Attach(SaveModel);
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
        
        public bool IsDuplicateRecord(string CityName, long? StateID, long ExcludeID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (IsDuplicateRecord(CityName, StateID, ExcludeID, db));
            }
        }

        public bool IsDuplicateRecord(string CityName, long? StateID, long ExcludeID, dbMarkerEntities db)
        {
            CityName = CityName.ToUpper();
            return (db.tblCities.Any(r => r.CityName.ToUpper() == CityName && r.StateID == StateID && r.CityID != ExcludeID));
        }

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            return GetLookupList();
        }

        public List<CityLookupListModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblCities

                           join js in db.tblStates on r.StateID equals js.StateID into gs
                           from s in gs.DefaultIfEmpty()

                           join jc in db.tblCountries on s.CountryID equals jc.CountryID into gc
                           from c in gc.DefaultIfEmpty()

                           where r.rstate != (byte)eRecordState.Deactivated

                           orderby r.CityName

                           select new CityLookupListModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               CityID = r.CityID,
                               CityName = r.CityName,
                               StateID = r.StateID ?? 0,
                               StateName = (s != null ? s.StateName : null),
                               CountryName = (c != null ? c.CountryName : null),

                           }).ToList();
                return res;
            }
        }

        public static CityDetailViewModel ConvertToDetailViewModel(tblCity SaveModel)
        {
            return new CityDetailViewModel()
            {
                CityID = SaveModel.CityID,
                CityName = SaveModel.CityName,
                StateID = SaveModel.StateID,
                StateName = SaveModel.tblState.StateShortName,
                CountryID = SaveModel.CountryID,
                CountryName = SaveModel.tblCountry.CountryName,
            };
        }

    }
}
