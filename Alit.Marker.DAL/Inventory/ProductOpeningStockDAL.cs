using Alit.Marker.Model;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;

namespace Alit.Marker.DAL.Inventory
{
    public class ProductOpeningStockDAL : ICRUDDAL, IGridCRUDDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((ProductOpeningStockViewModel)ViewModel);
        }
        public SavingResult SaveRecord(IGridCRUDViewModel ViewModel)
        {
            return SaveRecord((ProductOpeningStockViewModel)ViewModel);
        }

        public SavingResult SaveRecord(ProductOpeningStockViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblStock SaveModel = null;
                res = SaveRecord(ViewModel
                    , out SaveModel
                    , CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                    , CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                    , db
                    , res);
                if (!String.IsNullOrWhiteSpace(res.ValidationError))
                {
                    return res;
                }
                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.VoucherID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    res.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
                    res.Exception = ex;
                    while (res.Exception.Message == "An error occurred while updating the entries. See the inner exception for details.")
                    {
                        res.Exception = res.Exception.InnerException;
                    }
                }
            }
            return res;
        }

        public SavingResult SaveRecord(ProductOpeningStockViewModel ViewModel
            , out tblStock SaveModel
            , long CompanyID
            , long FinPeriodID
            , dbMarkerEntities db
            , SavingResult res)
        {
            SaveModel = null;
            if (IsDuplicateRecord(ViewModel.ProductID, ViewModel.OpeningStockID, FinPeriodID, CompanyID, db))
            {
                res.ValidationError = "Duplicate stock not accepted. Opening stock already exists.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.OpeningStockID == 0 && ViewModel.OpeningStockQty == 0)
            {
                res.ValidationError = "Can not accept zero in quantity.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.OpeningStockID != 0 && ViewModel.OpeningStockQty == 0)
            {
                DeleteRecord(ViewModel.OpeningStockID);
                return res;
            }
            DAL.Inventory.StockVoucherDAL StockVoucherDALObj = new StockVoucherDAL();
            StockVoucherViewModel StockVoucherViewModel = null;

            if (ViewModel.OpeningStockID != 0)
            {
                StockVoucherViewModel = StockVoucherDALObj.GetViewModelByPrimeKey(ViewModel.OpeningStockID);
            }

            if (StockVoucherViewModel == null)
            {
                StockVoucherViewModel = new StockVoucherViewModel()
                {
                    VoucherID = ViewModel.OpeningStockID,
                    StockVoucherTypeID = eStockVoucherType.OpeningStock,
                    VoucherDate = ViewModel.OpeningStockDate,
                    //VoucherNo = 0,
                    //ProductID = ViewModel.ProductID,
                    PriceListID = null,
                    Narration = "Opening Stock",

                    ProductDetail = new List<StockVoucherProductDetailViewModel>()
                    {
                        new StockVoucherProductDetailViewModel()
                        {
                            StockVoucherID = ViewModel.OpeningStockID,
                            //StockProductDetailID = ViewModel.id,
                            ProductID = ViewModel.ProductID,
                            Quantity = ViewModel.OpeningStockQty,
                            Rate = ViewModel.Rate,
                        }
                    }
                };
            }
            else
            {
                var StockVoucherProductDetail = StockVoucherViewModel.ProductDetail.FirstOrDefault(r => r.ProductID == ViewModel.ProductID);
                if (StockVoucherProductDetail == null)
                {
                    StockVoucherViewModel.ProductDetail.Add(new StockVoucherProductDetailViewModel()
                    {
                        StockVoucherID = ViewModel.OpeningStockID,
                        //StockProductDetailID = ViewModel.id,
                        ProductID = ViewModel.ProductID,
                        Quantity = ViewModel.OpeningStockQty,
                        Rate = ViewModel.Rate,
                    });
                }
                else
                {
                    StockVoucherProductDetail.Quantity = ViewModel.OpeningStockQty;
                    StockVoucherProductDetail.Rate = ViewModel.Rate;
                }
            }

            res = StockVoucherDALObj.SaveNewRecord(StockVoucherViewModel, out SaveModel, db, res);

            return res;
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {

            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            //
            //
            Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
            return Result;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                res = DeleteRecord(DeleteID, db);
                if (res.ExecutionResult != eExecutionResult.CommitedSucessfuly && res.ExecutionResult != eExecutionResult.NotExecutedYet)
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
                    res.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
                    res.Exception = ex;
                }
            }
            return res;
        }

        public SavingResult DeleteRecord(long DeleteID, dbMarkerEntities db)
        {
            SavingResult res = null;// new SavingResult();

            if (DeleteID != 0)
            {
                DAL.Inventory.StockVoucherDAL StockVoucherDALObj = new StockVoucherDAL();
                res = StockVoucherDALObj.DeleteRecord(DeleteID, db);
            }
            else
            {
                res = new SavingResult();
                res.ValidationError = "No record selected to delete.";
                res.ExecutionResult = eExecutionResult.ValidationError;
            }
            return res;
        }


        public SavingResult DeleteRecord(long DeleteID, long ProductID)
        {
            SavingResult res = new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                res = DeleteRecord(DeleteID, ProductID, db);
                if (res.ExecutionResult != eExecutionResult.CommitedSucessfuly && res.ExecutionResult != eExecutionResult.NotExecutedYet)
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
                    res.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
                    res.Exception = ex;
                }
            }
            return res;
        }

        public SavingResult DeleteRecord(long DeleteID, long ProductID, dbMarkerEntities db)
        {
            SavingResult res = new SavingResult();

            if (DeleteID != 0)
            {
                DAL.Inventory.StockVoucherDAL StockVoucherDALObj = new StockVoucherDAL();
                var StockVoucherViewModel = StockVoucherDALObj.GetViewModelByPrimeKey(DeleteID);
                if (StockVoucherViewModel == null)
                {
                    res.ValidationError = "stock voucher not found.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                StockVoucherViewModel.ProductDetail.RemoveAll(r => r.ProductID == ProductID);

                if (StockVoucherViewModel.ProductDetail.Count == 0)
                {
                    // if no record left after deleting this product then delete whole voucher.
                    res = StockVoucherDALObj.DeleteRecord(DeleteID, db);
                }
                else
                {
                    // if there is another product is there, then update that voucher
                    res = StockVoucherDALObj.SaveNewRecord(StockVoucherViewModel);
                }
            }
            else
            {
                res.ValidationError = "No record selected to delete.";
                res.ExecutionResult = eExecutionResult.ValidationError;
            }
            return res;
        }


        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }
        IGridCRUDViewModel IGridCRUDDAL.GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public ProductOpeningStockViewModel GetViewModelByPrimeKey(long ID)
        {
            return GetViewModelByProductID(ID);
            //using (dbMarkerEntities db = new dbMarkerEntities())
            //{
            //    return (from OS in db.tblStocks
            //            join pd in db.tblStockPDetails on OS.VoucherID equals pd.StockVoucherID

            //            join jp in db.tblProducts on pd.ProductID equals jp.ProductID into gp
            //            from p in gp.DefaultIfEmpty()

            //            join ju in db.tblUnits on p.UnitID equals ju.UnitID into gu
            //            from u in gu.DefaultIfEmpty()

            //            join joinrcu in db.tblUsers on OS.rcuid equals joinrcu.UserID into grcu
            //            from rcu in grcu.DefaultIfEmpty()

            //            join joinreu in db.tblUsers on OS.reuid equals joinreu.UserID into greu
            //            from reu in greu.DefaultIfEmpty()

            //            where OS.VoucherID == ID
            //            orderby p.PCode, OS.VDate
            //            select new ProductOpeningStockViewModel()
            //            {
            //                OpeningStockID = OS.VoucherID,
            //                OpeningStockDate = OS.VDate,
            //                OpeningStockQty = pd.Qty,
            //                Rate = pd.Rate,

            //                ProductID = p.ProductID,
            //                Narration = OS.Narration,

            //                CreatedDateTime = p.rcdt,
            //                EditedDateTime = p.redt,
            //                CreatedUserID = p.rcuid,
            //                EditedUserID = p.reuid,
            //                CreatedUserName = (rcu != null ? rcu.UserName : ""),
            //                EditedUserName = (reu != null ? reu.UserName : ""),

            //            }).FirstOrDefault();
            //}
        }

        public ProductOpeningStockViewModel GetViewModelByProductID(long ProductID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from OS in db.tblStocks
                        join pd in db.tblStockPDetails on OS.VoucherID equals pd.StockVoucherID

                        //join jp in db.tblProducts on pd.ProductID equals jp.ProductID into gp
                        //from p in gp.DefaultIfEmpty()

                        //join ju in db.tblUnits on p.UnitID equals ju.UnitID into gu
                        //from u in gu.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on OS.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on OS.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where pd.ProductID == ProductID
                            && (eStockVoucherType)OS.StockVoucherTypeID == eStockVoucherType.OpeningStock
                            && OS.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                            && OS.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID

                        //orderby p.PCode, OS.VDate
                        select new ProductOpeningStockViewModel()
                        {
                            OpeningStockID = OS.VoucherID,
                            ProductID = pd.ProductID,
                            OpeningStockDate = OS.VDate,
                            OpeningStockQty = pd.Qty,
                            Rate = pd.Rate,
                            Narration = OS.Narration,

                            CreatedDateTime = OS.rcdt,
                            EditedDateTime = OS.redt,
                            CreatedUserID = OS.rcuid,
                            EditedUserID = OS.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),

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
                var SaveModel = db.tblStocks.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblStocks.Attach(SaveModel);
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


        public bool IsDuplicateRecord(long ProductID, long ExcludeVID)
        {
            return IsDuplicateRecord(ProductID, ExcludeVID,
                    Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID,
                    Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID);
        }

        public bool IsDuplicateRecord(long ProductID, long ExcludeVID, dbMarkerEntities db)
        {
            return IsDuplicateRecord(ProductID, ExcludeVID,
                    Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID,
                    Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID, db);
        }

        public bool IsDuplicateRecord(long ProductID, long ExcludeVID, long FinPeriodID, long CompanyID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(ProductID, ExcludeVID,
                        FinPeriodID, CompanyID, db);
            }
        }

        public bool IsDuplicateRecord(long ProductID, long ExcludeVID, long FinaPeriodID, long CompanyID, dbMarkerEntities db)
        {
            int OpeningStockVoucherTypeID = (int)eStockVoucherType.OpeningStock;
            return db.tblStockPDetails.Any(r =>
                r.tblStock.StockVoucherTypeID == OpeningStockVoucherTypeID &&
                r.StockVoucherID != ExcludeVID &&
                r.ProductID == ProductID &&
                r.tblStock.FinPeriodID == FinaPeriodID && r.tblStock.CompanyID == CompanyID);
        }


        public IEnumerable<IGridCRUDViewModel> GetViewModelList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {

                return (from r in db.tblProducts
                        join joinps in db.tblProductStocks.Where(joinpsr => joinpsr.Stock != 0) on
                        new
                        {
                            r.ProductID,
                            Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                            Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                        }
                        equals
                        new
                        {
                            joinps.ProductID,
                            joinps.CompanyID,
                            joinps.FinPeriodID
                        }
                        into gps
                        from ps in gps.DefaultIfEmpty()

                        join jops in (from s in db.tblStocks
                                      join spd in db.tblStockPDetails on s.VoucherID equals spd.StockVoucherID

                                      where s.StockVoucherTypeID == (byte)eStockVoucherType.OpeningStock
                                       && s.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID

                                      select new { s.VoucherID, spd.ProductID, spd.Qty, s.rcuid, s.reuid, s.rcdt, s.redt })
                                      on r.ProductID equals jops.ProductID into gops
                        from ops in gops.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        orderby r.PCode
                        select new ProductOpeningStockViewModel()
                        {
                            ProductID = r.ProductID,
                            PCode = r.PCode,
                            HSN = r.HSNCode,
                            BarCode = r.Barcode,
                            OpeningStockID = (ops != null ? ops.VoucherID : 0),
                            ProductName = r.ProductName,
                            UnitName = r.tblUnit.UnitName,
                            OpeningStockQty = (ops != null ? ops.Qty : 0M),
                            Rate = r.PurchaseRate,
                            RecordState = (eRecordState)r.rstate,
                            CreatedDateTime = ops != null ? ops.rcdt : null,
                            EditedDateTime = ops != null ? ops.redt : null,
                            CreatedUserID = ops != null ? ops.rcuid : null,
                            EditedUserID = ops != null ? ops.reuid : null,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),

                        }).ToList();
            }
        }



    }


}

     
    

