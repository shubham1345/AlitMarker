using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.Users;
using Alit.Marker.Model.Users.UserGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Users.UserGroup
{
    public class UserGroupDAL : ICRUDDAL, IGridCRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveNewRecord((UserGroupViewModel)ViewModel);
        }

        public SavingResult SaveRecord(IGridCRUDViewModel ViewModel)
        {
            return SaveNewRecord((UserGroupViewModel)ViewModel);
        }

        public SavingResult SaveNewRecord(UserGroupViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (string.IsNullOrWhiteSpace(ViewModel.UserGroupName))
            {
                res.ValidationError = "Please enter User Group Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (ViewModel.SuperAdminGroup)
            {
                res.ValidationError = "Can not add/edit Super Admin Group.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.UserGroupName, ViewModel.UserGroupID, db))
                {
                    res.ValidationError = "Can not accept duplicate User Group Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                tblUserGroup SaveModel;
                if (ViewModel.UserGroupID == 0) // New Entry
                {
                    SaveModel = new tblUserGroup();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblUserGroups.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblUserGroups.Find(ViewModel.UserGroupID);
                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                        res.ValidationError = "Record not found. May be another user has changed/deleted that record. Please contact your admin.";
                        return res;
                    }

                    db.tblUserGroups.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                }

                SaveModel.UserGroupName = ViewModel.UserGroupName;

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.UserGroupID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
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
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (db.tblUserGroups.Any(r => r.UserGroupID == ID && (r.SuperAdminGroup ?? false)))
                {
                    Result.ValidationMessage = "Super Admin Group";
                    Result.IsValidForDelete = false;
                    return Result;
                }
                else if (db.tblUsers.Any(r => r.UserGroupID == ID))
                {
                    Result.ValidationMessage = "Selected group already selected in some users.";
                    Result.IsValidForDelete = false;
                    return Result;
                }
            }
            Result.IsValidForDelete = true;
            return Result;
        }

        public SavingResult DeleteRecord(long ID)
        {
            SavingResult res = new SavingResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                db.tblUserGroups.RemoveRange(db.tblUserGroups.Where(r => r.UserGroupID == ID));
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
              
        IGridCRUDViewModel IGridCRUDDAL.GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public UserGroupViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblUserGroups

                        where r.UserGroupID == ID

                        select new UserGroupViewModel()
                        {
                            UserGroupID = r.UserGroupID,
                            UserGroupName = r.UserGroupName,
                            SuperAdminGroup = r.SuperAdminGroup ?? false,
                        }).FirstOrDefault();
            }
        }

        public IEnumerable<IGridCRUDViewModel> GetViewModelList()
        {
            return GetViewModelList(null);
        }

        public List<UserGroupViewModel> GetViewModelList(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {               
                var res = (from r in db.tblUserGroups

                           join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                           from rcu in grcu.DefaultIfEmpty()

                           join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                           from reu in greu.DefaultIfEmpty()

                           where !(r.SuperAdminGroup ?? false) 

                           select new UserGroupViewModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               UserGroupID = r.UserGroupID,
                               UserGroupName = r.UserGroupName,
                               SuperAdminGroup = r.SuperAdminGroup ?? false,

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

        public BeforeUpdateRecordStateValidationResult ValidateBeforeUpdateRecordState(long ID, eRecordState oldState, eRecordState newState)
        {
            return new BeforeUpdateRecordStateValidationResult() { IsValidForUpdate = true };
        }

        public SavingResult UpdateRecordState(long ID, eRecordState newRecordState)
        {
            SavingResult res = new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var SaveModel = db.tblUserGroups.Find(ID);

                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblUserGroups.Attach(SaveModel);
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

        public bool IsDuplicateRecord(string UserGroupName, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(UserGroupName, ID, db);
            }
        }

        public bool IsDuplicateRecord(string UserGroupName, long ID, dbMarkerEntities db)
        {
            UserGroupName = UserGroupName.ToUpper();
            return db.tblUserGroups.Any(i => i.UserGroupName.ToUpper() == UserGroupName && i.UserGroupID != ID);
        }

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            return GetLookupList();
        }

        public List<UserGroupLookupModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblUserGroups

                           where !(r.SuperAdminGroup ?? false) && r.rstate != (byte)eRecordState.Deactivated
                           orderby r.UserGroupName

                           select new UserGroupLookupModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               UserGroupID = r.UserGroupID,
                               UserGroupName = r.UserGroupName
                           }).ToList();
                return res;
            }
        }
        
        public List<Model.Users.UserGroup.MenuOptionPermissionViewModel> GetPermission(long UserGroupID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var perms = (from r in db.tblUserGroupPerimissions

                             where r.UserGroupID == UserGroupID

                             select r).ToList();

                DAL.Settings.MenuOptionsDAL MenuOptionDALObj = new Settings.MenuOptionsDAL();

                var res = (from m in MenuOptionDALObj.GetMenus()

                           join joinp in perms on m.MenuOptionID equals joinp.MenuOptionID into gp
                           from p in gp.DefaultIfEmpty()

                           select new Model.Users.UserGroup.MenuOptionPermissionViewModel()
                           {
                               MenuOptionID = m.MenuOptionID,
                               MenuOptionName = m.MenuOptionName,
                               MenuOptionGroupName = m.MenuOptionGroupName,
                               MenuOptionType = m.MenuType,
                               CanView = (p != null ? p.CanRead : false),
                               CanAdd = (p != null ? p.CanAdd : false),
                               CanEdit = (p != null ? p.CanEdit : false),
                               CanDelete = (p != null ? p.CanDelete : false)
                           }).ToList();

                return res;
            }
        }        
    }
}
