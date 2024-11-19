using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.ERP.Masters.AdditionalItems;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Masters.AdditionalItems
{
    public class AdditionalItemDAL : IDashboardDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((AdditionalItemViewModel)ViewModel);
        }

        public SavingResult SaveRecord(AdditionalItemViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (String.IsNullOrWhiteSpace(ViewModel.ItemName))
            {
                res.ValidationError = "Please enter Item Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (ViewModel.ItemType == eAdditionalItemType.Tax && ViewModel.ProductTaxCategoryID == null)
            {
                res.ValidationError = "Please select Tax Category.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (ViewModel.MaintainAccount == true && ViewModel.AccountID == null)
            {
                res.ValidationError = "Please select Account.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.ItemName, ViewModel.AdditionalItemID, db))
                {
                    res.ValidationError = "Can not accept duplicate Item Name";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                tblAdditionalItemMaster SaveModel = null;
                if (ViewModel.AdditionalItemID == 0)
                {
                    SaveModel = new tblAdditionalItemMaster();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;

                    db.tblAdditionalItemMasters.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblAdditionalItemMasters.Find(ViewModel.AdditionalItemID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    db.tblAdditionalItemMasters.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                }

                SaveModel.ItemName = ViewModel.ItemName;
                SaveModel.Nature = (int)ViewModel.Nature;
                SaveModel.Perc = ViewModel.Perc;
                SaveModel.ItemType = (int)ViewModel.ItemType;
                SaveModel.CalculateOnID = (int)ViewModel.CalculateOn;
                SaveModel.CalculatePerc = ViewModel.ReverseCalculatePercentage;
                SaveModel.IsInclusive = ViewModel.InclusiveTax;
                SaveModel.DefaultRecord = ViewModel.IsDefaultRecord;
                SaveModel.DefaultRecordPrt = ViewModel.DefaultRecordPriority;
                SaveModel.ProductTaxCategoryID = ViewModel.ProductTaxCategoryID;
                SaveModel.AccountID = ViewModel.AccountID;

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.AdditionaItemID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
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
                tblAdditionalItemMaster AddItem = db.tblAdditionalItemMasters.Find(DeleteID);
                if (AddItem != null && AddItem.SystemRecord == 1)
                {
                    Result.ValidationMessage += (!String.IsNullOrWhiteSpace(Result.ValidationMessage) ? "\r\n" : "") + "Can not delete system record.";
                }

                if (db.tblSaleInvoiceAdditionals.Any(r => r.AdditionalItemID == DeleteID))
                {
                    Result.ValidationMessage += (!String.IsNullOrWhiteSpace(Result.ValidationMessage) ? "\r\n" : "") + "Sale Invoice";
                }
                if (db.tblSaleReturnAdditionals.Any(r => r.AdditionalItemID == DeleteID))
                {
                    Result.ValidationMessage += (!String.IsNullOrWhiteSpace(Result.ValidationMessage) ? "\r\n" : "") + "Sale Return";
                }
                if (db.tblSaleOrderAdditionals.Any(r => r.AdditionalItemID == DeleteID))
                {
                    Result.ValidationMessage += (!String.IsNullOrWhiteSpace(Result.ValidationMessage) ? "\r\n" : "") + "Sale Order";
                }
                if (db.tblPurchaseBillAdditionals.Any(r => r.AdditionalItemID == DeleteID))
                {
                    Result.ValidationMessage += (!String.IsNullOrWhiteSpace(Result.ValidationMessage) ? "\r\n" : "") + "Purchase Bill";
                }
                if (db.tblPurchaseReturnAdditionals.Any(r => r.AdditionalItemID == DeleteID))
                {
                    Result.ValidationMessage += (!String.IsNullOrWhiteSpace(Result.ValidationMessage) ? "\r\n" : "") + "Purchase Return";
                }
                if (!String.IsNullOrWhiteSpace(Result.ValidationMessage))
                {
                    Result.ValidationMessage = "Item is already selected in following:\r\n" + Result.ValidationMessage;
                }
            }
            Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
            return Result;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = null; new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                res = DeleteRecord(DeleteID, db);
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

        public SavingResult DeleteRecord(long DeleteID, dbMarkerEntities db)
        {
            SavingResult res = null;//new SavingResult();

            if (DeleteID != 0)
            {
                tblAdditionalItemMaster RecordToDelete = db.tblAdditionalItemMasters.FirstOrDefault(r => r.AdditionaItemID == DeleteID);
                res = DeleteRecord(RecordToDelete, db);
            }
            else
            {
                res = new SavingResult();
                res.ValidationError = "No record selected to delete.";
                res.ExecutionResult = eExecutionResult.ValidationError;
            }
            return res;
        }

        public SavingResult DeleteRecord(tblAdditionalItemMaster RecordToDelete, dbMarkerEntities db)
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
                db.tblAdditionalItemMasters.Remove(RecordToDelete);
            }
            return res;
        }


        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                int ItemTypeID = (int)eAdditionalItemType.AdditionalItem;
                return (from r in db.tblAdditionalItemMasters

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID && r.ItemType == ItemTypeID

                        orderby r.ItemName

                        select new AdditionalItemDashboardViewModel()
                        {
                            AdditionalItemID = r.AdditionaItemID,
                            ItemName = r.ItemName,
                            Nature = (eAdditionalItemNature)r.Nature,
                            CalculateOn = (eCalculateOn)r.CalculateOnID,
                            Percentage = r.Perc,
                            ReverseCalculate = r.CalculatePerc,
                            InclusiveRate = r.IsInclusive,
                            AddByDefault = r.DefaultRecord,
                            DefaultOrder = r.DefaultRecordPrt,

                            RecordState = (eRecordState)r.rstate,
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

        public AdditionalItemViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblAdditionalItemMasters

                        where r.AdditionaItemID == ID

                        select new AdditionalItemViewModel()
                        {
                            AdditionalItemID = r.AdditionaItemID,
                            ItemName = r.ItemName,
                            Nature = (eAdditionalItemNature)r.Nature,
                            Perc = r.Perc,
                            ItemType = (eAdditionalItemType)r.ItemType,
                            CalculateOn = (eCalculateOn)r.CalculateOnID,
                            ReverseCalculatePercentage = r.CalculatePerc ?? false,
                            InclusiveTax = r.IsInclusive ?? false,
                            IsDefaultRecord = r.DefaultRecord ?? false,
                            DefaultRecordPriority = r.DefaultRecordPrt,
                            ProductTaxCategoryID = r.ProductTaxCategoryID,
                            AccountID = r.AccountID,
                            MaintainAccount = (r.AccountID != null ? true : false)

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
                var SaveModel = db.tblAdditionalItemMasters.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblAdditionalItemMasters.Attach(SaveModel);
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


        public bool IsDuplicateRecord(string ItemName, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(ItemName, ID, db);
            }
        }

        public bool IsDuplicateRecord(string ItemName, long ID, dbMarkerEntities db)
        {
            ItemName = ItemName.ToUpper();
            return db.tblAdditionalItemMasters.Any(i => i.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                         && i.ItemName.ToUpper() == ItemName
                                         && i.AdditionaItemID != ID);
        }


        public List<tblAdditionalItemMaster> GetDefaultRecords()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return db.tblAdditionalItemMasters.Where(r => r.DefaultRecord ?? false).OrderBy(r => r.DefaultRecordPrt ?? 0).ToList();
            }
        }

        public IEnumerable<tblAdditionalItemMaster> GetSaveModelList(eAdditionalItemType ItemType)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                int ItemTypeID = (int)ItemType;
                return db.tblAdditionalItemMasters.Where(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                    r.ItemType == ItemTypeID).Select(r => r).ToList();
            }
        }

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            eAdditionalItemType? AdditionalItemTypeFilter = null;
            int Index = 0;

            if (FilterParas != null && FilterParas.Count() > Index)
            {
                AdditionalItemTypeFilter = (eAdditionalItemType)FilterParas[Index];
            }

            return GetLookupListFinal(AdditionalItemTypeFilter);
        }

        public List<AdditionalItemLookupModel> GetLookupListFinal(eAdditionalItemType? AdditionalItemTypeFilter)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblAdditionalItemMasters

                           where r.rstate != (byte)eRecordState.Deactivated
                                && r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                && (AdditionalItemTypeFilter == null || (eAdditionalItemType)r.ItemType == AdditionalItemTypeFilter)

                           orderby r.ItemName

                           select new AdditionalItemLookupModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               AdditionalItemID = r.AdditionaItemID,
                               AddnitionalItemName = r.ItemName,
                               Perc = r.Perc,
                               IsInclusive = r.IsInclusive ?? false,
                               ProductTaxCategoryID = r.ProductTaxCategoryID
                           }).ToList();
                return res;
            }
        }
    }
}
