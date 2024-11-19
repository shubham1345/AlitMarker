using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.Users;
using Alit.Marker.Model.Users.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Users.User
{
    public class UserDAL : IDashboardDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((UserViewModel)ViewModel);
        }

        public SavingResult SaveRecord(UserViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (string.IsNullOrWhiteSpace(ViewModel.UserName))
            {
                res.ValidationError = "Please enter User Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (ViewModel.UserGroupID == 0)
            {
                res.ValidationError = "Please enter User Group.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (ViewModel.SuperAdmin)
            {
                res.ValidationError = "Can not accept add/edit a Super User.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
                        
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.UserName, ViewModel.UserID, db))
                {
                    res.ValidationError = "Can not accept duplicate User Name.";               
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                tblUser SaveModel = null;
                if (ViewModel.UserID == 0) 
                {
                    SaveModel = new tblUser();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblUsers.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblUsers.Find(ViewModel.UserID);
                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                        res.ValidationError = "Record not found. May be another user has changed/deleted that record. Please contact your admin.";
                        return res;
                    }

                    db.tblUsers.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                }

                SaveModel.UserName = ViewModel.UserName;
                SaveModel.UserGroupID = ViewModel.UserGroupID;
                SaveModel.Password = ViewModel.Password;

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.UserID;
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
                if (db.tblUsers.Any(r => r.UserID == DeleteID && (r.SuperAdmin ?? false)))
                {
                    Result.IsValidForDelete = false;
                    Result.ValidationMessage = "Super Admin record.";
                    return Result;
                }
            }

            Result.IsValidForDelete = true;
            return Result;
        }
        public SavingResult UpdatePassword(long UserID, string CurrentPassword, string NewPassword, string ConfirmPassword)
        {
            SavingResult res = new SavingResult();

            if (UserID == 0)
            {
                res.ValidationError = "Logged in User not found. Please check.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            
            if (NewPassword != ConfirmPassword)
            {
                res.ValidationError = "Confirm Password does not matched with New Password.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                bool IsPasswordMatched = IsPasswordMatch(UserID, CurrentPassword, db);
                if (CurrentPassword == NewPassword && IsPasswordMatched)
                {
                    res.ValidationError = "Current Password and New Password can not be same.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                if (!IsPasswordMatched)
                {
                    res.ValidationError = "Current Password does not matched.Please enter valid Password.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                tblUser SaveModel = null;

                SaveModel = db.tblUsers.Find(UserID);
                if (SaveModel == null)
                {
                    res.ValidationError = "Selected record not found."; ;
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                db.tblUsers.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.redt = DateTime.Now;
                SaveModel.Password = CurrentPassword;

                try
                {
                    db.SaveChanges();
                    res.MessageAfterSave = "Password changed successfully.";
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.UserID;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public bool IsPasswordMatch(long UserID, string NewPassword)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsPasswordMatch(UserID, NewPassword, db);
            }
        }

        public bool IsPasswordMatch(long UserID, string NewPassword,dbMarkerEntities db)
        {
           return db.tblUsers.Any(r => r.UserID == UserID && r.Password == NewPassword);
        }

        public SavingResult DeleteRecord(long ID)
        {
            SavingResult res = new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                db.tblUsers.RemoveRange(db.tblUsers.Where(r => r.UserID == ID));
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

        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblUsers

                        join jug in db.tblUserGroups on r.UserGroupID equals jug.UserGroupID into gug
                        from ug in gug.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where !(r.SuperAdmin ?? false)

                        orderby r.UserName

                        select new UserDashboardViewModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            UserID = r.UserID,
                            UserName = r.UserName,
                            UserGroupName = (ug != null ? ug.UserGroupName : null),

                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : null),
                            EditedUserName = (reu != null ? reu.UserName : null),

                        }).ToList();
            }
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public UserViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblUsers

                        where r.UserID == ID

                        select new UserViewModel()
                        {
                            UserID = r.UserID,
                            UserGroupID = r.UserGroupID,
                            UserName = r.UserName,
                            Password = r.Password,
                            SuperAdmin = r.SuperAdmin ?? false,
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
                var SaveModel = db.tblUsers.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblUsers.Attach(SaveModel);
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


        public bool IsDuplicateRecord(string UserName, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(UserName, ID, db);
            }
        }

        public bool IsDuplicateRecord(string UserName, long ID, dbMarkerEntities db)
        {
            UserName = UserName.ToUpper();
            return db.tblUsers.Any(i => i.UserName.ToUpper() == UserName && i.UserID != ID);
        }

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            return GetLookupList();
        }

        public List<UserLookupModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblUsers

                           where !(r.SuperAdmin ?? false) && r.rstate != (byte)eRecordState.Deactivated

                           orderby r.UserName

                           select new UserLookupModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               UserID = r.UserID,
                               UserName = r.UserName
                           }).ToList();
                return res;
            }
        }
        
        public UserDetailModel GetUserDetailModel(string UserName, string Password)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                UserName = UserName.ToLower();
                return (from r in db.tblUsers

                        join jug in db.tblUserGroups on r.UserGroupID equals jug.UserGroupID into gug
                        from ug in gug.DefaultIfEmpty()

                        where r.UserName.ToLower() == UserName && r.Password == Password

                        select new UserDetailModel()
                        {
                            UserID = r.UserID,
                            UserName = r.UserName,
                            UserGroupID = r.UserGroupID,
                            UserGroupName = (ug != null ? ug.UserGroupName : null),
                            SuperUser = r.SuperAdmin ?? false
                        }).FirstOrDefault();
            }
        }

        #region This mehod is not used yet
        public UserDetailModel GetUserDetailModelById(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblUser SaveModel = db.tblUsers.FirstOrDefault(r => r.UserID == ID);
                if (SaveModel == null) return null;

                return new UserDetailModel()
                {
                    UserID = SaveModel.UserID,
                    UserName = SaveModel.UserName
                };
            }
        }
        
        public tblUser GetFirstUser()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return db.tblUsers.Where(r => r.SuperAdmin ?? false).FirstOrDefault();
            }
        }

        public long MatchUser(string UserName, string Password)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                UserName = UserName.ToLower();

                tblUser User = db.tblUsers.FirstOrDefault(r => r.UserName.ToLower() == UserName && r.Password == Password);

                if (User == null) { return 0; }
                else { return User.UserID; }
            }
        }
        #endregion
    }
}
