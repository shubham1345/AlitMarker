using Alit.Marker.Model.Template;
using Alit.Marker.Model;
using Alit.Marker.Model.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DBO;

namespace Alit.Marker.DAL.Inventory
{
    public class StockVoucherDAL
    {
        public SavingResult SaveNewRecord(StockVoucherViewModel ViewModel)
        {
            tblStock SaveModel;
            return SaveNewRecord(ViewModel, out SaveModel);
        }

        public SavingResult SaveNewRecord(StockVoucherViewModel ViewModel, out tblStock SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                res = SaveNewRecord(ViewModel, out SaveModel, db, res);

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
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public SavingResult SaveNewRecord(StockVoucherViewModel ViewModel, dbMarkerEntities db, SavingResult res)
        {
            tblStock SaveModel;
            return SaveNewRecord(ViewModel, out SaveModel, db, res);
        }

        public SavingResult SaveNewRecord(StockVoucherViewModel ViewModel, out tblStock SaveModel, dbMarkerEntities db, SavingResult res)
        {
            return SaveNewRecord(ViewModel, out SaveModel,
                Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID, db, res);
        }

        public SavingResult SaveNewRecord(StockVoucherViewModel ViewModel, out tblStock SaveModel, long CompanyID, long FinPeriodID, dbMarkerEntities db, SavingResult res)
        {
            SaveModel = null;
            tblStock SaveModel2 = null;
            if (ViewModel.VoucherID == 0) // New Entry
            {
                SaveModel = new tblStock();
                SaveModel2 = SaveModel;
                SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.rcdt = DateTime.Now;
                SaveModel.CompanyID = CompanyID;
                SaveModel.FinPeriodID = FinPeriodID;

                db.tblStocks.Add(SaveModel);
            }
            else
            {
                SaveModel = db.tblStocks.Find(ViewModel.VoucherID);
                SaveModel2 = SaveModel;

                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                    return res;
                }

                db.tblStocks.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.redt = DateTime.Now;

                List<tblStockPDetail> pdetail = db.tblStockPDetails.Where(r => r.StockVoucherID == SaveModel2.VoucherID).ToList();
                pdetail.ForEach(r => DAL.Inventory.ProductStockDAL.UpdateStock(r.ProductID, -r.Qty, CompanyID, FinPeriodID, db, res));
                db.tblStockPDetails.RemoveRange(pdetail);
            }

            SaveModel.Narration = ViewModel.Narration;
            SaveModel.PriceListID = ViewModel.PriceListID;
            SaveModel.ProductID = ViewModel.ProductID;
            SaveModel.StockVoucherTypeID = (int)ViewModel.StockVoucherTypeID;
            SaveModel.VDate = ViewModel.VoucherDate;
            SaveModel.VNo = ViewModel.VoucherNo;

            db.tblStockPDetails.AddRange(ViewModel.ProductDetail.Select(r => new tblStockPDetail()
            {
                tblStock = SaveModel2,
                ProductID = r.ProductID,
                Qty = r.Quantity,
                Rate = r.Rate,
                Amount = r.Amount,
                rcuid = SaveModel2.rcuid,
                reuid = SaveModel2.reuid,
            }));

            ViewModel.ProductDetail.ForEach(r =>
            {
                DAL.Inventory.ProductStockDAL.UpdateStock(r.ProductID, r.Quantity, CompanyID, FinPeriodID, db, res);
            });

            return res;
        }

        public StockVoucherViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblStocks
                        where r.VoucherID == ID
                        select new StockVoucherViewModel()
                        {
                            VoucherID = r.VoucherID,
                            VoucherDate = r.VDate,
                            VoucherNo = r.VNo,
                            ProductID = r.ProductID,
                            StockVoucherTypeID = (eStockVoucherType)r.StockVoucherTypeID,
                            PriceListID = r.PriceListID,
                            Narration = r.Narration,
                            ProductDetail = (from pd in db.tblStockPDetails
                                             where pd.StockVoucherID == ID
                                             select new StockVoucherProductDetailViewModel()
                                             {
                                                 StockProductDetailID = pd.StockPDetailID,
                                                 StockVoucherID = pd.StockVoucherID,
                                                 ProductID = pd.ProductID,
                                                 Quantity = pd.Qty,
                                                 Rate = pd.Rate,
                                             }).ToList(),
                        }).FirstOrDefault();
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            //using (dbMarkerEntities db = new dbMarkerEntities())
            //{

            //    bool InState = db.tblStates.FirstOrDefault(r => r.StockInID == DeleteID) != null;

            //    if(InState)
            //    {
            //        Result.ValidationMessage = "StockIn exists in some states";
            //    }
            //}
            Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
            return Result;
        }

        public SavingResult DeleteRecord(long DeleteID, dbMarkerEntities db)
        {
            SavingResult res = new SavingResult();
            if (DeleteID != 0)
            {
                tblStock RecordToDelete = db.tblStocks.FirstOrDefault(r => r.VoucherID == DeleteID);

                if (RecordToDelete == null)
                {
                    res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                else
                {
                    List<tblStockPDetail> pdetail = db.tblStockPDetails.Where(r => r.StockVoucherID == RecordToDelete.VoucherID).ToList();
                    pdetail.ForEach(r => DAL.Inventory.ProductStockDAL.UpdateStock(r.ProductID, -r.Qty, RecordToDelete.CompanyID.Value, RecordToDelete.FinPeriodID, db, res));
                    db.tblStockPDetails.RemoveRange(pdetail);

                    db.tblStocks.Remove(RecordToDelete);
                }
            }
            return res;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (DeleteID != 0)
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
                        CommonFunctions.GetFinalError(res, ex);
                    }
                }
            }
            return res;
        }

        public long GenerateStockVNo(eStockVoucherType StockVoucherType)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long FinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                int VTypeID = (int)StockVoucherType;
                return (db.tblStocks.Where(r => r.FinPeriodID == FinPerID && r.StockVoucherTypeID == VTypeID).Max(r => (long?)r.VNo) ?? 0) + 1;
            }
        }

        public bool IsDuplicateStockVoucherNo(eStockVoucherType StockVoucherType, long VoucherNo, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateStockVoucherNo(StockVoucherType, VoucherNo, ID, db);
            }
        }
        public bool IsDuplicateStockVoucherNo(eStockVoucherType StockVoucherType, long VoucherNo, long ID, dbMarkerEntities db)
        {
            long FinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
            int VTypeID = (int)StockVoucherType;

            if (db.tblStocks.FirstOrDefault(i => i.FinPeriodID == FinPerID 
                        && i.VNo == VoucherNo 
                        && i.StockVoucherTypeID == VTypeID 
                        && i.VoucherID != ID) != null)
            {
                return true;
            }
            return false;
        }
    }
}
