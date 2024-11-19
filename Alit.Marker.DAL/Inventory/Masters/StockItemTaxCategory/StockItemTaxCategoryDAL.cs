using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Inventory.Masters.StockItemTaxCategory;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Inventory.Masters.StockItemTaxCategory
{
    public class StockItemTaxCategoryDAL : IGridCRUDDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(IGridCRUDViewModel ViewModel)
        {
            return SaveRecord((StockItemTaxCategoryViewModel)ViewModel);
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((StockItemTaxCategoryViewModel)ViewModel);
        }

        public SavingResult SaveRecord(StockItemTaxCategoryViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            //--
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblProductTaxCategory SaveModel;

                res = SaveRecord(ViewModel, out SaveModel, db, res);

                if (!String.IsNullOrWhiteSpace(res.ValidationError))
                {
                    return res;
                }
                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.ProductTaxCategoryID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public SavingResult SaveRecord(StockItemTaxCategoryViewModel ViewModel, out tblProductTaxCategory SaveModel, dbMarkerEntities db, SavingResult res)
        {
            SaveModel = null;
            if (String.IsNullOrWhiteSpace(ViewModel.ProductTaxCategoryName))
            {
                res.ValidationError = "Please enter Stock Item Tax Category Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            else if (IsDuplicateRecord(ViewModel.ProductTaxCategoryName, ViewModel.ProductTaxCategoryID, db))
            {
                res.ValidationError = "Can not accept duplicate Stock Item Tax Category Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (ViewModel.ProductTaxCategoryID == 0) // New Entry
            {
                SaveModel = new tblProductTaxCategory();
                SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.rcdt = DateTime.Now;
                SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                db.tblProductTaxCategories.Add(SaveModel);
            }
            else
            {
                SaveModel = db.tblProductTaxCategories.Find(ViewModel.ProductTaxCategoryID);

                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                    return res;
                }

                db.tblProductTaxCategories.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.redt = DateTime.Now;

            }

            SaveModel.ProductTaxCategoryName = ViewModel.ProductTaxCategoryName;
            SaveModel.IsInterstateSale = ViewModel.IsInterstateTax;
            SaveModel.TaxIndex = ViewModel.TaxIndex;
            SaveModel.Applicable = ViewModel.Applicable;

            return res;
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult res = new BeforeDeleteValidationResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (db.tblAdditionalItemMasters.Any(r => r.ProductTaxCategoryID == DeleteID && r.ItemType == (int)eAdditionalItemType.Tax))
                {
                    res.ValidationMessage = "\r\nStock Item Tax.";
                }
                if (db.tblAdditionalItemMasters.Any(r => r.ProductTaxCategoryID == DeleteID && r.ItemType == (int)eAdditionalItemType.AdditionalItem))
                {
                    res.ValidationMessage = "\r\nDiscount and Tax."; //for Additional Item
                }
                if (!String.IsNullOrWhiteSpace(res.ValidationMessage))
                {
                    res.ValidationMessage = "Stock Item Tax Category is already selected in following:" + res.ValidationMessage;
                }
            }
            res.IsValidForDelete = string.IsNullOrWhiteSpace(res.ValidationMessage);
            return res;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                db.tblProductTaxCategories.RemoveRange(db.tblProductTaxCategories.Where(r => r.ProductTaxCategoryID == DeleteID));
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
                return (from r in db.tblProductTaxCategories

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.ProductTaxCategoryName

                        select new StockItemTaxCategoryViewModel()
                        {
                            ProductTaxCategoryID = r.ProductTaxCategoryID,
                            ProductTaxCategoryName = r.ProductTaxCategoryName,
                            IsInterstateTax = r.IsInterstateSale ?? false,
                            TaxIndex = r.TaxIndex,
                            Applicable = r.Applicable,

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

        public StockItemTaxCategoryViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblProductTaxCategories

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.ProductTaxCategoryID == ID

                        select new StockItemTaxCategoryViewModel()
                        {
                            ProductTaxCategoryID = r.ProductTaxCategoryID,
                            ProductTaxCategoryName = r.ProductTaxCategoryName,
                            IsInterstateTax = r.IsInterstateSale ?? false,
                            TaxIndex = r.TaxIndex,
                            Applicable = r.Applicable,

                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : null),
                            EditedUserName = (reu != null ? reu.UserName : null),

                        }).FirstOrDefault();
            }
        }


        public StockItemTaxCategoryViewModel GetViewModelByTaxIndex(int TaxIndex)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblProductTaxCategories

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.TaxIndex == TaxIndex

                        select new StockItemTaxCategoryViewModel()
                        {
                            ProductTaxCategoryID = r.ProductTaxCategoryID,
                            ProductTaxCategoryName = r.ProductTaxCategoryName,
                            IsInterstateTax = r.IsInterstateSale ?? false,
                            TaxIndex = r.TaxIndex,
                            Applicable = r.Applicable,

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
                var SaveModel = db.tblProductTaxCategories.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblProductTaxCategories.Attach(SaveModel);
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


        public bool IsDuplicateRecord(string ProductTaxCategoryName, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(ProductTaxCategoryName, ID, db);
            }
        }

        public bool IsDuplicateRecord(string ProductTaxCategoryName, long ID, dbMarkerEntities db)
        {
            ProductTaxCategoryName = ProductTaxCategoryName.ToUpper();
            long CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;

            return db.tblProductTaxCategories.Any(r => r.CompanyID == CompanyID && r.ProductTaxCategoryName.ToUpper() == ProductTaxCategoryName && r.ProductTaxCategoryID != ID);
        }

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            return GetLookUpList();
        }

        public List<StockItemTaxCategoryLookUpListModel> GetLookUpList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                return (from r in db.tblProductTaxCategories

                        where r.CompanyID == CompanyID
                            && r.rstate != (byte)eRecordState.Deactivated
                            && r.Applicable

                        orderby r.ProductTaxCategoryName

                        select new StockItemTaxCategoryLookUpListModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            ProductTaxCategoryID = r.ProductTaxCategoryID,
                            ProductTaxCategoryName = r.ProductTaxCategoryName,
                            IsInterstateTax = r.IsInterstateSale ?? false,
                            TaxIndex = r.TaxIndex,

                        }).ToList();
            }
        }

    }
}
