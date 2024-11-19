using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.City.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DBO;

namespace Alit.Marker.DAL.City.Country
{
    public class CountryDAL : ICRUDDAL, IGridCRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((CountryViewModel)ViewModel);
        }

        public SavingResult SaveRecord(IGridCRUDViewModel ViewModel)
        {
            return SaveRecord((CountryViewModel)ViewModel);
        }

        public SavingResult SaveRecord(CountryViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (string.IsNullOrWhiteSpace(ViewModel.CountryName))
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please enter Country Name.";
                return res;
            }
            if (ViewModel.CountryName.Length > 50)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Maximum 50 characters are accepted in Country Name.";
                return res;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.CountryName, ViewModel.CountryID, db))
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Can not accept duplicate Country Name.";
                    return res;
                }

                tblCountry SaveModel = null;

                if (ViewModel.CountryID == 0)
                {
                    SaveModel = new tblCountry();
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    db.tblCountries.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblCountries.Find(ViewModel.CountryID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    db.tblCountries.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.redt = DateTime.Now;
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                }

                SaveModel.CountryName = ViewModel.CountryName;

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.CountryID;
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
                if (db.tblStates.Any(r => r.CountryID == ID))
                {
                    res.ValidationMessage += "\r\nStates.";
                }
                if (db.tblCities.Any(r => r.CityID == ID))
                {
                    res.ValidationMessage += "\r\nCity.";
                }

                if (!String.IsNullOrWhiteSpace(res.ValidationMessage))
                {
                    res.ValidationMessage = "Country is already selected in following:" + res.ValidationMessage;
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
                db.tblCountries.RemoveRange(db.tblCountries.Where(r => r.CountryID == ID));

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
                var res = (from r in db.tblCountries

                           join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                           from rcu in grcu.DefaultIfEmpty()

                           join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                           from reu in greu.DefaultIfEmpty()

                           orderby r.CountryName

                           select new CountryViewModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               CountryID = r.CountryID,
                               CountryName = r.CountryName,

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

        public CountryViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblCountries

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CountryID == ID

                        select new CountryViewModel()
                        {
                            CountryID = r.CountryID,
                            CountryName = r.CountryName,

                            CreatedDateTime = r.rcdt,
                            CreatedUserID = r.rcuid,
                            EditedDateTime = r.redt,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : null),
                            EditedUserName = (reu != null ? reu.UserName : null),
                        }
                ).FirstOrDefault();

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

        public List<CountryLookupModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblCountries

                           where r.rstate != (byte)eRecordState.Deactivated

                           orderby r.CountryName

                           select new CountryLookupModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               CountryID = r.CountryID,
                               CountryName = r.CountryName,
                           }).ToList();
                return res;
            }
        }

        public bool IsDuplicateRecord(string CountryName, long ExcludeID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (IsDuplicateRecord(CountryName, ExcludeID, db));
            }
        }

        public bool IsDuplicateRecord(string CountryName, long ExcludeID, dbMarkerEntities db)
        {
            CountryName = CountryName.ToUpper();
            return db.tblCountries.Any(r => r.CountryName.ToUpper() == CountryName && r.CountryID != ExcludeID);
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
                var SaveModel = db.tblCountries.Find(ID);

                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblCountries.Attach(SaveModel);
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
