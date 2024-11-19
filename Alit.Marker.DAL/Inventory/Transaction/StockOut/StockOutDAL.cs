using Alit.Marker.Model;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.Inventory;
using Alit.Marker.Model.Inventory.Transaction.StockOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;

namespace Alit.Marker.DAL.Inventory.Transaction.StockOut
{
    public class StockOutDAL : IDashboardDAL, ICRUDDAL, ILookupListDAL
    {
        DAL.Inventory.StockVoucherDAL StockVoucherDALObj;

        public StockOutDAL()
        {
            StockVoucherDALObj = new StockVoucherDAL();
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((StockOutViewModel)ViewModel);
        }

        public SavingResult SaveRecord(StockOutViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblStock SaveModel;

                res = SaveRecord(ViewModel, out SaveModel, db, res);

                if (!String.IsNullOrWhiteSpace(res.ValidationError))
                {
                    return res;
                }

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

        public SavingResult SaveRecord(StockOutViewModel ViewModel, out tblStock SaveModel, dbMarkerEntities db, SavingResult res)
        {
            SaveModel = null;
            if (ViewModel.VoucherNo == 0)
            {
                res.ValidationError = "Please enter Voucher No.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            else if (IsDuplicateRecord(ViewModel.VoucherNo, ViewModel.StockOutID, db))
            {
                res.ValidationError = "Can not accept duplicate Voucher No.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            res = StockVoucherDALObj.SaveNewRecord(new StockVoucherViewModel()
            {
                VoucherID = ViewModel.StockOutID,
                StockVoucherTypeID = eStockVoucherType.StockOut,
                VoucherDate = ViewModel.VoucherDate,
                VoucherNo = ViewModel.VoucherNo,
                ProductID = null,
                PriceListID = ViewModel.PriceListID,
                //Narration = "Stock Out",
                Narration = ViewModel.Narration,

                ProductDetail = ViewModel.ProductDetail.Where(r => r.Quantity != 0).Select(r => new StockVoucherProductDetailViewModel()
                {
                    StockVoucherID = ViewModel.StockOutID,
                    ProductID = r.ProductID,
                    Quantity = -r.Quantity,
                    Rate = r.Rate,
                    Amount = r.GAmt,
                }).ToList(),
            }
            , out SaveModel, db, res);
            return res;
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
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
                    res = StockVoucherDALObj.DeleteRecord(DeleteID, db);

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

        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long FinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                int VTypeID = (int)eStockVoucherType.StockOut;

                return (from r in db.tblStocks

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.FinPeriodID == FinPerID && r.StockVoucherTypeID == VTypeID

                        orderby r.VDate descending, r.VNo descending

                        select new StockOutDashboardViewModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            StockOutID = r.VoucherID,
                            VoucherDate = r.VDate,
                            VoucherNo = r.VNo,
                            Narration = r.Narration,

                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),

                            ProductDetail = (from rd in db.tblStockPDetails

                                             join jp in db.tblProducts on rd.ProductID equals jp.ProductID into gp
                                             from p in gp.DefaultIfEmpty()

                                             join ju in db.tblUnits on p.UnitID equals ju.UnitID into gu
                                             from u in gu.DefaultIfEmpty()

                                             where rd.StockVoucherID == r.VoucherID

                                             select new StockOutDashboardProductDetailViewModel()
                                             {
                                                 StockOutID = r.VoucherID,
                                                 StockOutProductDetailID = rd.StockPDetailID,
                                                 PCode = (p != null ? (long?)p.PCode : null),
                                                 Barcode = (p != null ? p.Barcode : null),
                                                 ProductName = (p != null ? p.ProductName : null),
                                                 Qty = -rd.Qty,
                                                 UnitName = u.UnitName,
                                                 Rate = rd.Rate,
                                             }).ToList(),
                        }).ToList();
            }
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public StockOutViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblStocks
                        where r.VoucherID == ID
                        select new StockOutViewModel()
                        {
                            StockOutID = r.VoucherID,
                            VoucherDate = r.VDate,
                            VoucherNo = r.VNo,
                            PriceListID = r.PriceListID,
                            Narration = r.Narration,
                            ProductDetail = (from pd in db.tblStockPDetails

                                             join jp in db.tblProducts on pd.ProductID equals jp.ProductID into gp
                                             from p in gp.DefaultIfEmpty()

                                             where pd.StockVoucherID == ID
                                             select new StockOutProductDetailViewModel()
                                             {
                                                 ProductID = pd.ProductID,
                                                 Quantity = -pd.Qty,
                                                 Rate = pd.Rate,
                                                 Barcode = (p != null ? p.Barcode : null),
                                                 PCode = (p != null ? p.PCode : 0),
                                                 ProductName = (p != null ? p.ProductName : null),
                                                 UnitID = (p != null ? (long)p.UnitID : 0),
                                             }).ToList(),
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

        public bool IsDuplicateRecord(long VoucherNo, long ID)
        {
            return StockVoucherDALObj.IsDuplicateStockVoucherNo(eStockVoucherType.StockOut, VoucherNo, ID);

        }

        public bool IsDuplicateRecord(long VoucherNo, long ID, dbMarkerEntities db)
        {
            return StockVoucherDALObj.IsDuplicateStockVoucherNo(eStockVoucherType.StockOut, VoucherNo, ID, db);
        }

        public long GenerateStockVNo()
        {
            return StockVoucherDALObj.GenerateStockVNo(eStockVoucherType.StockOut);
        }

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<StockOutLookUpListModel> GetLookupList()
        {
            return (List<StockOutLookUpListModel>)GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long FinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                int VTypeID = (int)eStockVoucherType.StockOut;

                var res = (from r in db.tblStocks

                           where r.FinPeriodID == FinPerID && r.StockVoucherTypeID == VTypeID
                                 && r.rstate != (byte)eRecordState.Deactivated

                           orderby r.VDate, r.VNo

                           select new StockOutLookUpListModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               StockOutID = r.VoucherID,
                               VoucherDate = r.VDate,
                               VoucherNo = r.VNo
                           }).ToList();
                return res;
            }
        }
    }
}
