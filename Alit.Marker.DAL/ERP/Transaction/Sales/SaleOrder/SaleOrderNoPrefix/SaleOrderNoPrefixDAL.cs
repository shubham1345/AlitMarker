using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.City;
using Alit.Marker.Model.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix
{
    public class SaleOrderNoPrefixDAL : IGridCRUDDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(IGridCRUDViewModel ViewModel)
        {
            return SaveRecord((SaleOrderNoPrefixViewModel)ViewModel);
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((SaleOrderNoPrefixViewModel)ViewModel);
        }

        public SavingResult SaveRecord(SaleOrderNoPrefixViewModel ViewModel)
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
                if (IsDuplicateRecord(ViewModel.PrefixName, ViewModel.SaleOrderNoPrefixID, db))
                {
                    res.ValidationError = "Can not accept duplicate Prefix Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                tblSaleOrderNoPrefix SaveModel = null;
                if (ViewModel.SaleOrderNoPrefixID == 0) 
                {
                    SaveModel = new tblSaleOrderNoPrefix();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblSaleOrderNoPrefixes.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblSaleOrderNoPrefixes.Find(ViewModel.SaleOrderNoPrefixID);
                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    db.tblSaleOrderNoPrefixes.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                }

                SaveModel.PrefixName = ViewModel.PrefixName;

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.SaleOrderNoPrefixID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }
        
        public tblSaleOrderNoPrefix FindSaveModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return db.tblSaleOrderNoPrefixes.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (db.tblSaleOrders.Any(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID && r.SaleOrderNoPrefixID == DeleteID))
                {
                    Result.ValidationMessage = "Prefix exists in some Sale Orders";
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
            SavingResult res = null;// new SavingResult();

            if (DeleteID != 0)
            {
                tblSaleOrderNoPrefix RecordToDelete = db.tblSaleOrderNoPrefixes.FirstOrDefault(r => r.SaleOrderNoPrefixID == DeleteID);
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

        public SavingResult DeleteRecord(tblSaleOrderNoPrefix RecordToDelete, dbMarkerEntities db)
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
                db.tblSaleOrderNoPrefixes.Remove(RecordToDelete);
            }
            return res;
        }

        public IEnumerable<IGridCRUDViewModel> GetViewModelList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblSaleOrderNoPrefixes

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.PrefixName

                        select new SaleOrderNoPrefixViewModel()
                        {
                            SaleOrderNoPrefixID = r.SaleOrderNoPrefixID,
                            PrefixName = r.PrefixName,

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
            return (IGridCRUDViewModel)GetViewModelByPrimeKey(ID);
        }
        
        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public SaleOrderNoPrefixViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblSaleOrderNoPrefixes

                        where r.SaleOrderNoPrefixID == ID

                        select new SaleOrderNoPrefixViewModel()
                        {
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
                var SaveModel = db.tblSaleOrderNoPrefixes.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblSaleOrderNoPrefixes.Attach(SaveModel);
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
            return (db.tblSaleOrderNoPrefixes.Any(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                                       && r.PrefixName.ToUpper() == PrefixName
                                                       && r.SaleOrderNoPrefixID != ID));
        }

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }              

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            return GetLookupList();
        }

        public List<SaleOrderNoPrefixLookupListModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblSaleOrderNoPrefixes

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                && r.rstate != (byte)eRecordState.Deactivated

                        orderby r.PrefixName

                        select new SaleOrderNoPrefixLookupListModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            SaleOrderNoPrefixID = r.SaleOrderNoPrefixID,
                            PrefixName = r.PrefixName,
                        }).ToList();
            }
        }
        
    }
}
