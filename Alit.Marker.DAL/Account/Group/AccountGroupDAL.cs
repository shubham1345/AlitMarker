using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model.Account.Group;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Account.Group
{
    public class AccountGroupDAL : IDashboardDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((AccountGroupViewModel)ViewModel);
        }

        public SavingResult SaveRecord(AccountGroupViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (string.IsNullOrWhiteSpace(ViewModel.AccountGroupName))
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please enter Account group name.";
                return res;
            }

            if (ViewModel.ParentGroupID == null && ViewModel.AccountGroupNature == null)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please select Group Nature.";
                return res;
            }
            if (ViewModel.ParentGroupID == null && ViewModel.EffectsGrossProfit == null)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please select Effects Gross Profit.";
                return res;
            }
            if (ViewModel.ParentGroupID == ViewModel.AccountGroupID)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Parent and Account Group can not be same.";
                return res;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (CheckDuplicate(ViewModel.AccountGroupName, ViewModel.AccountGroupID, db))
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Can not accept duplicate Account Group Name.";
                    return res;
                }
                if (ViewModel.ParentGroupID != null && CheckParentIsnull(ViewModel.AccountGroupID, db))
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Can not select Parent because this Account Group is selected in other Account Group as a Parent Account Group.";
                    return res;
                }

                tblAccountGroup SaveModel = null;

                if (ViewModel.AccountGroupID == 0)
                {
                    SaveModel = new tblAccountGroup();
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblAccountGroups.Add(SaveModel);

                    if (ViewModel.ParentGroupID != null)
                    {
                        eAccountGroupType? GroupTypeID = (eAccountGroupType?)db.tblAccountGroups.FirstOrDefault(r => r.AccountGroupID == ViewModel.ParentGroupID)?.GroupTypeID;
                        if (GroupTypeID != null)
                        {
                            SaveModel.GroupTypeID = (byte)GroupTypeID;
                        }
                        else
                        {
                            SaveModel.GroupTypeID = (byte)ViewModel.GroupTypeID;
                        }
                    }
                    else
                    {
                        SaveModel.GroupTypeID = (byte)ViewModel.GroupTypeID;
                    }

                }
                else
                {
                    SaveModel = db.tblAccountGroups.Find(ViewModel.AccountGroupID);

                    db.tblAccountGroups.Attach(SaveModel);
                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. Please contact your administrator.";
                        return res;
                    }

                    SaveModel.redt = DateTime.Now;
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;

                    //if (ViewModel.GroupTypeID != null && SaveModel.GroupTypeID != null && ViewModel.GroupTypeID != (eAccountGroupType)SaveModel.GroupTypeID)
                    if (ViewModel.GroupTypeID != (eAccountGroupType)SaveModel.GroupTypeID)
                    {
                        UpdateGroupTypeID(ViewModel.AccountGroupID, ViewModel.GroupTypeID,db);
                    }
                    else
                    {
                        SaveModel.GroupTypeID = (byte)ViewModel.GroupTypeID;
                    }
                }

                SaveModel.AccountGroupName = ViewModel.AccountGroupName;
                SaveModel.ParentGroupID = ViewModel.ParentGroupID;
                SaveModel.GroupNatureID = (byte?)ViewModel.AccountGroupNature;
                SaveModel.EffectsGrossProfit = ViewModel.EffectsGrossProfit;
                SaveModel.DefaultGroup = ViewModel.DefaultGroup;
                //SaveModel.GroupTypeID = (byte?)ViewModel.GroupTypeID;                

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.AccountGroupID;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public SavingResult UpdateGroupTypeID(long AccountGroupTypeID, eAccountGroupType GroupTypeID, dbMarkerEntities db )
        {
            SavingResult res = new SavingResult(); 

             tblAccountGroup SaveModel = null;

            SaveModel = db.tblAccountGroups.Find(AccountGroupTypeID);

            if (SaveModel != null)
            {
                db.tblAccountGroups.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                SaveModel.GroupTypeID = (byte)GroupTypeID;

                List<long> AccountGroupIDs = db.tblAccountGroups.Where(r => r.ParentGroupID == AccountGroupTypeID).Select(r => r.AccountGroupID).ToList();

                foreach(long Id in AccountGroupIDs)
                {
                    UpdateGroupTypeID(Id, GroupTypeID, db);
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
                res.ValidationMessage = "";
                if (db.tblAccountGroups.Any(r => r.ParentGroupID == ID))
                {
                    res.ValidationMessage += "Group is already selected in other group as parent.";
                }

                if (db.tblAccounts.Any(r => r.AccountGroupID == ID))
                {
                    res.ValidationMessage += "Group is already selected in accounts.";
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
                db.tblAccountGroups.RemoveRange(db.tblAccountGroups.Where(r => r.AccountGroupID == ID));

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

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblAccountGroups

                           join joinrag in db.tblAccountGroups on r.ParentGroupID equals joinrag.AccountGroupID into grag
                           from rag in grag.DefaultIfEmpty()

                           join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                           from rcu in grcu.DefaultIfEmpty()

                           join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                           from reu in greu.DefaultIfEmpty()

                           where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                           orderby r.AccountGroupName

                           select new AccountGroupDashboardViewModel()
                           {
                               AccountGroupID = r.AccountGroupID,
                               AccountGroupName = r.AccountGroupName,
                               ParentGroupName = (rag != null ? rag.AccountGroupName : null),
                               AccountGroupNature = (eAccountGroupNature?)r.GroupNatureID,

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

        public AccountGroupViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblAccountGroups

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.AccountGroupID == ID

                        select new AccountGroupViewModel()
                        {
                            AccountGroupID = r.AccountGroupID,
                            AccountGroupName = r.AccountGroupName,
                            ParentGroupID = r.ParentGroupID,
                            AccountGroupNature = (eAccountGroupNature)r.GroupNatureID,
                            GroupTypeID = (eAccountGroupType)r.GroupTypeID,
                            EffectsGrossProfit = r.EffectsGrossProfit,
                            DefaultGroup = r.DefaultGroup,
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
                var SaveModel = db.tblAccountGroups.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblAccountGroups.Attach(SaveModel);
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

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            long? ParentAccountGroupID = null;
            bool? ShowOnlyPrimaryGroups = null;

            int count = 0;
            if (FilterParas != null)
            {
                if (FilterParas.Count() > count && FilterParas[count] is long)
                {
                    ParentAccountGroupID = (long)FilterParas[count];
                }
                count++;

                if (FilterParas.Count() > count && FilterParas[count] is bool)
                {
                    ShowOnlyPrimaryGroups = (bool)FilterParas[count];
                }
                count++;
            }
            return GetLookupList(ParentAccountGroupID, ShowOnlyPrimaryGroups);
        }

        public List<AccountGroupLookupListModel> GetLookupList() { return GetLookupList(null, null); }

        public List<AccountGroupLookupListModel> GetLookupList(long? ParentAccountGroupID, bool? ShowOnlyPrimaryGroups)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblAccountGroups

                           where r.rstate != (byte)eRecordState.Deactivated
                           && r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                && (ParentAccountGroupID == null || r.ParentGroupID == ParentAccountGroupID)
                                && (ShowOnlyPrimaryGroups == null
                                        || (ShowOnlyPrimaryGroups.Value && r.ParentGroupID == null)
                                        || (!ShowOnlyPrimaryGroups.Value && r.ParentGroupID != null))

                           orderby r.AccountGroupName

                           select new AccountGroupLookupListModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               AccountGroupID = r.AccountGroupID,
                               AccountGroupName = r.AccountGroupName,
                               GroupTypeID = (eAccountGroupType)r.GroupTypeID,
                           }).ToList();
                return res;
            }
        }

        public bool CheckDuplicate(string AccountGroupName, long ExcludeID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (CheckDuplicate(AccountGroupName, ExcludeID, db));
            }
        }

        public bool CheckDuplicate(string AccountGroupName, long ExcludeID, dbMarkerEntities db)
        {
            AccountGroupName = AccountGroupName.ToUpper();
            return db.tblAccountGroups.Any(r => r.AccountGroupName.ToUpper() == AccountGroupName && r.AccountGroupID != ExcludeID);
        }

        public bool CheckParentIsnull(long ParentAccountGroupID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return CheckParentIsnull(ParentAccountGroupID, db);
            }
        }

        public bool CheckParentIsnull(long ParentAccountGroupID, dbMarkerEntities db)
        {
            return db.tblAccountGroups.Any(r => r.ParentGroupID != null && r.ParentGroupID == ParentAccountGroupID);
        }
    }
}
