using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Inventory.Masters.Unit;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Inventory.Masters.Unit
{
    public class UnitDAL : IGridCRUDDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(IGridCRUDViewModel ViewModel)
        {
            return SaveRecord((UnitViewModel)ViewModel);
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((UnitViewModel)ViewModel);
        }

        public SavingResult SaveRecord(UnitViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (String.IsNullOrWhiteSpace(ViewModel.UnitName))
            {
                res.ValidationError = "Please enter Unit Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (ViewModel.UnitName.Length > 50)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Maximum 50 chars accepted in Unit Name.";
                return res;
            }
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.UnitName, ViewModel.UnitID, db))
                {
                    res.ValidationError = "Can not accept duplicate Unit Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                tblUnit SaveModel = null;
                if (ViewModel.UnitID == 0) // New Entry
                {
                    SaveModel = new tblUnit();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblUnits.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblUnits.Find(ViewModel.UnitID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    db.tblUnits.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;

                }

                SaveModel.UnitName = ViewModel.UnitName;

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.UnitID;
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
            BeforeDeleteValidationResult res = new BeforeDeleteValidationResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                //if (db.tblProducts.Any(r => r.UnitID == DeleteID))
                //{
                //    Result.ValidationMessage = "Unit exists in some Products";
                //}
                if (db.tblProducts.Any(r => r.UnitID == DeleteID))
                {
                    res.ValidationMessage += "\r\nProducts.";
                }
                if (db.tblPurchaseBillProductDetails.Any(r => r.UnitID == DeleteID ))
                {
                    res.ValidationMessage += "\r\nPurchase Bill Product Detail.";
                }
                if (db.tblPurchaseReturnProductDetails.Any(r => r.UnitID == DeleteID))
                {
                    res.ValidationMessage += "\r\nPurchase Return Product Detail.";
                }
                if (db.tblSaleInvoiceProductDetails.Any(r => r.UnitID == DeleteID))
                {
                    res.ValidationMessage += "\r\nSale Invoice Product Detail.";
                }
                if (db.tblSaleOrderProductDetails.Any(r => r.UnitID == DeleteID))
                {
                    res.ValidationMessage += "\r\nSale Order Product Detail.";
                }
                if (db.tblSaleReturnProductDetails.Any(r => r.UnitID == DeleteID))
                {
                    res.ValidationMessage += "\r\nSale Return Product Detail.";
                }
                if (!String.IsNullOrWhiteSpace(res.ValidationMessage))
                {
                    res.ValidationMessage = "Unit is already selected in following:" + res.ValidationMessage;
                }
            }
            res.IsValidForDelete = String.IsNullOrWhiteSpace(res.ValidationMessage);
            return res;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = new SavingResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                db.tblUnits.RemoveRange(db.tblUnits.Where(r => r.UnitID == DeleteID));
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
                return (from r in db.tblUnits

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        orderby r.UnitName
                        select new UnitViewModel()
                        {
                            UnitID = r.UnitID,
                            UnitName = r.UnitName,

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

        IGridCRUDViewModel IGridCRUDDAL.GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public UnitViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblUnits

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.UnitID == ID
                        select new UnitViewModel()
                        {
                            UnitID = r.UnitID,
                            UnitName = r.UnitName,

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
                var SaveModel = db.tblUnits.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblUnits.Attach(SaveModel);
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

        public bool IsDuplicateRecord(string UnitName, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(UnitName, ID, db);
            }
        }

        public bool IsDuplicateRecord(string UnitName, long ID, dbMarkerEntities db)
        {
            UnitName = UnitName.ToUpper();
            return (db.tblUnits.Any(i => i.UnitName.ToUpper() == UnitName && i.UnitID != ID));
        }

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            return GetLookupList();
        }

        public List<UnitLookupListModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblUnits

                        where r.rstate != (byte)eRecordState.Deactivated

                        orderby r.UnitName

                        select new UnitLookupListModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            UnitID = r.UnitID,
                            UnitName = r.UnitName,
                        }).ToList();
            }
        }
    }
}
