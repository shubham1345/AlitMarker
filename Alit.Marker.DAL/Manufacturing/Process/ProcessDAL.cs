using Alit.Marker.Model;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.Inventory;
using Alit.Marker.Model.Manufacturing.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;
using Alit.Marker.DAL.Inventory;
using Alit.Marker.DBO;

namespace Alit.Marker.DAL.Manufacturing.Process
{
    public class ProcessDAL : IDashboardDAL, ICRUDDAL
    {
        StockVoucherDAL StockVoucherDALObj;
        public ProcessDAL()
        {
            StockVoucherDALObj = new StockVoucherDAL();
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((ProcessViewModel)ViewModel);
        }

        public SavingResult SaveRecord(ProcessViewModel ViewModel)
        {
            SavingResult res = new SavingResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (ViewModel.ProcessNo == 0)
                {
                    res.ValidationError = "Can not accept blank value. Please enter Voucher No.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(ViewModel.ProcessNo, ViewModel.ProcessID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The voucher number is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                tblStock SaveModel = null;

                var ProductDetial = ViewModel.ProductDetail.Select(r => new StockVoucherProductDetailViewModel()
                {
                    ProductID = r.ProductID,
                    Quantity = -r.Quantity,
                    Rate = r.Rate,
                }).ToList();

                ProductDetial.Add(new StockVoucherProductDetailViewModel()
                {
                    ProductID = ViewModel.ProductID,
                    Quantity = ViewModel.FinishQuantity,
                    Rate = ViewModel.Rate,
                });

                res = StockVoucherDALObj.SaveNewRecord(new StockVoucherViewModel()
                {
                    VoucherID = ViewModel.ProcessID,
                    StockVoucherTypeID = eStockVoucherType.ManufacturingProcess,
                    VoucherDate = ViewModel.ProcessDate,
                    VoucherNo = ViewModel.ProcessNo,
                    ProductID = ViewModel.ProductID,
                    PriceListID = null,
                    Narration = ViewModel.Narration,

                    ProductDetail = ProductDetial,
                }, out SaveModel, db, res);
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
                }
            }
            return res;
        }


        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            //using (dbMarkerEntities db = new dbMarkerEntities())
            //{

            //    bool InState = db.tblStates.FirstOrDefault(r => r.ProcessID == DeleteID) != null;

            //    if(InState)
            //    {
            //        Result.ValidationMessage = "Process exists in some states";
            //    }
            //}
            Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
            return Result;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (DeleteID != 0)
                {
                    DAL.Inventory.StockVoucherDAL StockVourcherDALObj = new Inventory.StockVoucherDAL();
                    res = StockVourcherDALObj.DeleteRecord(DeleteID, db);
                    //tblStock RecordToDelete = db.tblStocks.FirstOrDefault(r => r.VoucherID == DeleteID);

                    //if (RecordToDelete == null)
                    //{
                    //    res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                    //    res.ExecutionResult = eExecutionResult.ValidationError;
                    //    return res;
                    //}

                    //else
                    //{
                    //    db.tblStockPDetails.RemoveRange(db.tblStockPDetails.Where(r => r.StockVoucherID == RecordToDelete.VoucherID));
                    //    db.tblStocks.Remove(RecordToDelete);
                    //}

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
            }
            return res;
        }


        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long FinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                int VTypeID = (int)eStockVoucherType.ManufacturingProcess;
                return (from rd in db.tblStockPDetails
                        join r in db.tblStocks on new { StockVoucherID = rd.StockVoucherID, ProductID = rd.ProductID } equals new { StockVoucherID = r.VoucherID, ProductID = r.ProductID ?? 0 }
                        join p in db.tblProducts on rd.ProductID equals p.ProductID

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.FinPeriodID == FinPerID && r.StockVoucherTypeID == VTypeID && rd.Qty > 0
                        orderby r.VDate descending, r.VNo descending
                        select new ProcessDashboardViewModel()
                        {
                            ProcessID = r.VoucherID,
                            ProcessDate = r.VDate,
                            ProcessNo = r.VNo,
                            ProductID = rd.ProductID,
                            PCode = p.PCode,
                            Barcode = p.Barcode,
                            ProductName = p.ProductName,
                            Narration = r.Narration,
                            FinishQuantity = rd.Qty,
                            UnitName = p.tblUnit.UnitName,
                            Rate = rd.Rate,

                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),
                        }).ToList();
            }
        }



        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public ProcessViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                int StockVoucherType_ManufacturingProcess = (int)eStockVoucherType.ManufacturingProcess;
                var ViewModel = (from r in db.tblStocks
                                 where r.VoucherID == ID
                                     && r.StockVoucherTypeID == StockVoucherType_ManufacturingProcess
                                 select new ProcessViewModel()
                                 {
                                     ProcessID = r.VoucherID,
                                     Narration = r.Narration,
                                     ProcessDate = r.VDate,
                                     ProcessNo = r.VNo,
                                     ProductID = r.ProductID.Value,
                                 }).FirstOrDefault();

                var FinishProduct = db.tblStockPDetails.FirstOrDefault(r => r.StockVoucherID == ViewModel.ProcessID && r.ProductID == ViewModel.ProductID);
                if (FinishProduct != null)
                {
                    ViewModel.FinishQuantity = FinishProduct.Qty;
                    ViewModel.Rate = FinishProduct.Rate;
                }

                ViewModel.ProductDetail = (from r in db.tblStockPDetails
                                           where r.StockVoucherID == ViewModel.ProcessID
                                                && r.ProductID != ViewModel.ProductID
                                           select new ProcessDetailViewModel()
                                           {
                                               ProductID = r.ProductID,
                                               Quantity = -r.Qty,
                                               Rate = r.Rate,

                                           }).ToList();

                var FormulaHeader = db.tblProductFormulas.Where(r => r.ProductID == ViewModel.ProductID
                                                && (r.WEDate == null || r.WEDate <= ViewModel.ProcessDate)).OrderByDescending(r => r.WEDate).FirstOrDefault();

                List<tblProductFormulaDetail> FormulaProductDetail = null;
                if (FormulaHeader != null)
                {
                    FormulaProductDetail = db.tblProductFormulaDetails.Where(r => r.ProductFormulaID == FormulaHeader.ProductFormulaID).ToList();
                    ViewModel.ProductDetail.ForEach(r =>
                    {
                        var fpd = FormulaProductDetail.FirstOrDefault(rr => rr.RawMaterialProductID == r.ProductID);
                        if (fpd != null)
                        {
                            r.FormulaQuantity = fpd.Quantity;
                        }
                    });
                }

                return ViewModel;
            }
        }

        public BeforeUpdateRecordStateValidationResult ValidateBeforeUpdateRecordState(long ID, eRecordState oldState, eRecordState newState)
        {
            return new BeforeUpdateRecordStateValidationResult() { IsValidForUpdate = true };
        }

        public SavingResult UpdateRecordState(long ID, eRecordState newRecordState)
        {
            SavingResult res = new SavingResult();
            //using (dbMarkerEntities db = new DAL.dbMarkerEntities())
            //{
            //    var SaveModel = db.tblCities.Find(ID);
            //    if (SaveModel == null)
            //    {
            //        res.ExecutionResult = eExecutionResult.ValidationError;
            //        res.ValidationError = "Selected record not found.";
            //        return res;
            //    }

            //    db.tblCities.Attach(SaveModel);
            //    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

            //    SaveModel.rstate = (byte)newRecordState;

            //    try
            //    {
            //        db.SaveChanges();
            //        res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
            //    }
            //    catch (Exception ex)
            //    {
            //        CommonFunctions.GetFinalError(res, ex);
            //    }
            //}
            return res;
        }

        public IEnumerable<ProcessLookUpListModel> GetLookUpList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long FinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                int VTypeID = (int)eStockVoucherType.ManufacturingProcess;
                return (from rd in db.tblStockPDetails
                        join r in db.tblStocks on new { StockVoucherID = rd.StockVoucherID, ProductID = rd.ProductID } equals new { StockVoucherID = r.VoucherID, ProductID = r.ProductID ?? 0 }
                        join p in db.tblProducts on rd.ProductID equals p.ProductID

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.FinPeriodID == FinPerID && r.StockVoucherTypeID == VTypeID && rd.Qty > 0
                        orderby r.VDate descending, r.VNo descending
                        select new ProcessLookUpListModel()
                        {
                            ProcessID = r.VoucherID,
                            ProcessDate = r.VDate,
                            ProcessNo = r.VNo,
                            ProductID = rd.ProductID,
                            PCode = p.PCode,
                            Barcode = p.Barcode,
                            ProductName = p.ProductName,
                            FinishQuantity = rd.Qty,
                            UnitName = p.tblUnit.UnitName,
                            Rate = rd.Rate,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(long VoucherNo, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(VoucherNo, ID, db);
            }
        }
        public bool IsDuplicateRecord(long VoucherNo, long ID, dbMarkerEntities db)
        {
            long FinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
            int VTypeID = (int)eStockVoucherType.ManufacturingProcess;
            if (db.tblStocks.FirstOrDefault(i => i.FinPeriodID == FinPerID && i.VNo == VoucherNo && i.StockVoucherTypeID == VTypeID && i.VoucherID != ID) != null)
            {
                return true;
            }
            return false;
        }

        public long GenerateStockVNo()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long FinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                int VTypeID = (int)eStockVoucherType.ManufacturingProcess;
                return (db.tblStocks.Where(r => r.FinPeriodID == FinPerID && r.StockVoucherTypeID == VTypeID).Max(r => (long?)r.VNo) ?? 0) + 1;
            }
        }
    }
}
