using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Inventory.Masters.Product;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Inventory.Masters.Product
{
    public class PriceListDAL : IGridCRUDDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(IGridCRUDViewModel ViewModel)
        {
            return SaveRecord((PriceListViewModel)ViewModel);
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((PriceListViewModel)ViewModel);
        }

        public SavingResult SaveRecord(PriceListViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (String.IsNullOrWhiteSpace(ViewModel.PriceListName))
            {
                res.ValidationError = "Please enter Price List Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (String.IsNullOrWhiteSpace(ViewModel.PriceListShortName))
            {
                res.ValidationError = "Please enter Price List Short Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.PriceListName, ViewModel.PriceListID, db))
                {
                    res.ValidationError = "Can not accept duplicate Price List Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                if (IsDuplicateShortName(ViewModel.PriceListShortName, ViewModel.PriceListID, db))
                {
                    res.ValidationError = "Can not accept duplicate Price List Short Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                tblPriceList SaveModel = null;
                if (ViewModel.PriceListID == 0) // New Entry
                {
                    SaveModel = new tblPriceList();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblPriceLists.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblPriceLists.Find(ViewModel.PriceListID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    db.tblPriceLists.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                }

                SaveModel.PriceListName = ViewModel.PriceListName;
                SaveModel.PriceListShortName = ViewModel.PriceListShortName;

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.PriceListID;
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

            long CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (!db.tblPriceLists.Any(r => r.PriceListID != DeleteID && r.CompanyID == CompanyID))
                {
                    res.ValidationMessage = "At least one Pricelist should exists.";
                }
                else
                {
                    if (db.tblSaleInvoices.Any(r => r.PriceListID == DeleteID && r.CompanyID == CompanyID))
                    {
                        res.ValidationMessage += "\r\nSale Invoice.";
                    }
                    if (db.tblSaleOrders.Any(r => r.PriceListID == DeleteID && r.CompanyID == CompanyID))
                    {
                        res.ValidationMessage += "\r\nSale Order.";
                    }
                    if (db.tblSaleReturns.Any(r => r.PriceListID == DeleteID && r.CompanyID == CompanyID))
                    {
                        res.ValidationMessage += "\r\nSale Return.";
                    }
                    if (db.tblStocks.Any(r => r.PriceListID == DeleteID && r.CompanyID == CompanyID))
                    {
                        res.ValidationMessage += "\r\nStock.";
                    }
                    if (!String.IsNullOrWhiteSpace(res.ValidationMessage))
                    {
                        res.ValidationMessage = "Price List is already selected in following:" + res.ValidationMessage;
                    }
                }
            }
            res.IsValidForDelete = String.IsNullOrWhiteSpace(res.ValidationMessage);
            return res;            
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = null;

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (DeleteID != 0)
                {
                    tblPriceList RecordToDelete = db.tblPriceLists.FirstOrDefault(r => r.PriceListID == DeleteID);
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

        public SavingResult DeleteRecord(tblPriceList RecordToDelete, dbMarkerEntities db)
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
                db.tblRates.RemoveRange(db.tblRates.Where(r => r.PriceListID == RecordToDelete.PriceListID));
                db.tblPriceLists.Remove(RecordToDelete);
            }

            return res;
        }
        

        public IEnumerable<IGridCRUDViewModel> GetViewModelList() { return GetViewModelList(null); }

        public IEnumerable<IGridCRUDViewModel> GetViewModelList(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                return (from r in db.tblPriceLists

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == CompanyID

                        orderby r.PriceListName

                        select new PriceListViewModel()
                        {
                            RecordState = (eRecordState)r.rstate,

                            PriceListID = r.PriceListID,
                            PriceListName = r.PriceListName,
                            PriceListShortName = r.PriceListShortName,

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

        public PriceListViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblPriceLists

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.PriceListID == ID

                        select new PriceListViewModel()
                        {
                            PriceListID = r.PriceListID,
                            PriceListName = r.PriceListName,
                            PriceListShortName = r.PriceListShortName,

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
                var SaveModel = db.tblPriceLists.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblPriceLists.Attach(SaveModel);
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


        public bool IsDuplicateRecord(string PriceListName, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(PriceListName, ID, db);
            }
        }

        public bool IsDuplicateRecord(string PriceListName, long ID, dbMarkerEntities db)
        {
            PriceListName = PriceListName.ToUpper();
            long CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
            return db.tblPriceLists.Any(r => r.CompanyID == CompanyID && r.PriceListName.ToUpper() == PriceListName && r.PriceListID != ID);
        }

        public bool IsDuplicateShortName(string PriceListShortName, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateShortName(PriceListShortName, ID, db);
            }
        }

        public bool IsDuplicateShortName(string PriceListShortName, long ID, dbMarkerEntities db)
        {
            PriceListShortName = PriceListShortName.ToUpper();
            long CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;

            return db.tblPriceLists.Any(r => r.CompanyID == CompanyID && r.PriceListShortName.ToUpper() == PriceListShortName && r.PriceListID != ID);
        }


        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            return GetLookupList();
        }

        public List<PriceListLookupListModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;

                return (from r in db.tblPriceLists

                        where r.CompanyID == CompanyID && r.rstate != (byte)eRecordState.Deactivated

                        orderby r.PriceListName

                        select new PriceListLookupListModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            PriceListID = r.PriceListID,
                            PriceListName = r.PriceListName,
                            PriceListShortName = r.PriceListShortName,
                        }).ToList();
            }
        }
    }
}
