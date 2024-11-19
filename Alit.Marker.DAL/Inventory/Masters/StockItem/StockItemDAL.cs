using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Inventory;
using Alit.Marker.Model.Inventory.Masters.StockItem;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Inventory.Masters.StockItem
{
    public class StockItemDAL : IDashboardDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((StockItemViewModel)ViewModel);
        }

        public SavingResult SaveRecord(StockItemViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblProduct SaveModel;
                res = SaveRecord(ViewModel, out SaveModel, db, res);
                if (!String.IsNullOrWhiteSpace(res.ValidationError))
                {
                    return res;
                }

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.ProductID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public SavingResult SaveRecord(StockItemViewModel ViewModel, out tblProduct SaveModel, dbMarkerEntities db, SavingResult res)
        {
            SaveModel = null;
            if (String.IsNullOrWhiteSpace(ViewModel.ProductName))
            {
                res.ValidationError = "Please enter Stock Item Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            else if (IsDuplicateRecord(ViewModel.ProductName, ViewModel.ProductID, db))
            {
                res.ValidationError = "Can not accept duplicate Stock Item Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (ViewModel.PCode == 0)
            {
                ViewModel.PCode = GeneratePCode(db);
            }
            else
            {
                if (db.tblProducts.Count(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                    r.PCode == ViewModel.PCode && r.ProductID != ViewModel.ProductID) > 0)
                {
                    res.ValidationError = "Can not accept duplicate Stock Item Code.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
            }

            if (CommonProperties.LoginInfo.SoftwareSettings.ProductBarcode)
            {
                if (String.IsNullOrWhiteSpace(ViewModel.Barcode))
                {
                    ViewModel.Barcode = ViewModel.PCode.ToString("000000000#");
                }
                else
                {
                    if (db.tblProducts.Count(r => r.Barcode == ViewModel.Barcode && r.ProductID != ViewModel.ProductID) > 0)
                    {
                        res.ValidationError = "Can not accept duplicate Barcode.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                }
            }
            else
            {
                ViewModel.Barcode = ViewModel.PCode.ToString("000000000#");
            }

            if (ViewModel.UnitID == 0)
            {
                res.ValidationError = "Unit is required.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (ViewModel.ProductID == 0) // New Entry
            {
                SaveModel = new tblProduct();
                SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.rcdt = DateTime.Now;
                SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                db.tblProducts.Add(SaveModel);
            }
            else
            {
                SaveModel = db.tblProducts.Find(ViewModel.ProductID);

                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                    return res;
                }

                db.tblProducts.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.redt = DateTime.Now;

                db.tblRates.RemoveRange(db.tblRates.Where(r => r.ProductID == ViewModel.ProductID));
            }

            SaveModel.PCode = ViewModel.PCode;
            SaveModel.Barcode = ViewModel.Barcode;
            SaveModel.ProductName = ViewModel.ProductName;
            SaveModel.ProdDescr = ViewModel.ProdDescr;
            SaveModel.HSNCode = ViewModel.HSNCode;
            SaveModel.UnitID = ViewModel.UnitID;
            SaveModel.Tax1ID = ViewModel.Tax1ID;
            SaveModel.Tax2ID = ViewModel.Tax2ID;
            SaveModel.Tax3ID = ViewModel.Tax3ID;
            SaveModel.PurchaseRate = ViewModel.PurchaseRate;

            if (ViewModel.SaleRate != null)
            {
                foreach (var rate in ViewModel.SaleRate.Where(r => r.Rate != 0 || r.DiscountPerc != 0))
                {
                    db.tblRates.Add(new tblRate()
                    {
                        tblProduct = SaveModel,
                        PriceListID = rate.PriceListID,
                        Rate = rate.Rate,
                        DiscPerc = rate.DiscountPerc,
                        rcdt = SaveModel.rcdt,
                        redt = SaveModel.redt,
                        CompanyID = SaveModel.CompanyID
                    });
                }
            }

            DAL.Inventory.ProductOpeningStockDAL POStockDALObj = new Inventory.ProductOpeningStockDAL();

            if (ViewModel.OpeningStock != null && ViewModel.OpeningStock.OpeningStockQty != 0 )
            {
                tblStock OpeningStockSaveModel;
                POStockDALObj.SaveRecord(new Model.Inventory.ProductOpeningStockViewModel()
                {
                    ProductID = SaveModel.ProductID,
                    OpeningStockQty = 
                    ViewModel.OpeningStock.OpeningStockQty,
                    Rate = ViewModel.OpeningStock.Rate,
                }, out OpeningStockSaveModel, SaveModel.CompanyID,Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID, db, res);
            }
            
            return res;
        }


        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {

            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (db.tblSaleInvoiceProductDetails.Any(r => r.ProductID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Product exists in some invoices";
                }

                if (db.tblSaleOrderProductDetails.Any(r => r.ProductID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Product exists in some orders";
                }
                if (db.tblSaleReturnProductDetails.Any(r => r.ProductID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Product exists in some sale returns";
                }
                if (db.tblPurchaseBillProductDetails.Any(r => r.ProductID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Product exists in some purchase bills.";
                }

                int VTypeID = (int)Model.Inventory.eStockVoucherType.OpeningStock;
                if (db.tblStockPDetails.Any(r => r.tblStock.StockVoucherTypeID == VTypeID && r.ProductID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Product exists in some opening stock.";
                }

                VTypeID = (int)Model.Inventory.eStockVoucherType.StockIn;
                if (db.tblStockPDetails.Any(r => r.tblStock.StockVoucherTypeID == VTypeID && r.ProductID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Product exists in some stock in.";
                }

                VTypeID = (int)Model.Inventory.eStockVoucherType.StockOut;
                if (db.tblStockPDetails.Any(r => r.tblStock.StockVoucherTypeID == VTypeID && r.ProductID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Product exists in some stock out.";
                }

                VTypeID = (int)Model.Inventory.eStockVoucherType.StockTransferProductToPruduct;
                if (db.tblStockPDetails.Any(r => r.tblStock.StockVoucherTypeID == VTypeID && r.ProductID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Product exists in some stock transfer.";
                }

                if (db.tblProductFormulas.Any(r => r.ProductID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Product exists in some product formula.";
                }
                if (db.tblProductFormulaDetails.Any(r => r.RawMaterialProductID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Product exists in some product detail formula";
                }
                if (db.tblPurchaseReturnProductDetails.Any(r => r.ProductID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Product exists in some purchase return product detail.";
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
                tblProduct RecordToDelete = db.tblProducts.FirstOrDefault(r => r.ProductID == DeleteID);
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

        public SavingResult DeleteRecord(tblProduct RecordToDelete, dbMarkerEntities db)
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
                db.tblRates.RemoveRange(db.tblRates.Where(r => r.ProductID == RecordToDelete.ProductID));
                db.tblProductStocks.RemoveRange(db.tblProductStocks.Where(r => r.ProductID == RecordToDelete.ProductID));
                db.tblProducts.Remove(RecordToDelete);
            }

            return res;
        }
        
        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                byte StockVoucherType_OpeningStock = (byte)eStockVoucherType.OpeningStock;
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

                                      where s.StockVoucherTypeID == StockVoucherType_OpeningStock
                                       && s.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                      
                                       select new { s.VoucherID, spd.ProductID, spd.Qty })
                                      on r.ProductID equals jops.ProductID into gops
                        from ops in gops.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        orderby r.PCode
                        select new StockItemDashboardViewModel()
                        {
                            ProductID = r.ProductID,
                            OpeningStockID = (ops != null ? (long?)ops.VoucherID : null),
                            PCode = r.PCode,
                            Barcode = r.Barcode,
                            ProductName = r.ProductName,
                            UnitName = r.tblUnit.UnitName,
                            CurrentStock = (ps != null ? (decimal?)ps.Stock : null),

                            RecordState = (eRecordState)r.rstate,
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

        public StockItemViewModel GetViewModelByPrimeKey(long ID)
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

                        where r.ProductID == ID

                        select new StockItemViewModel()
                        {
                            ProductID = r.ProductID,
                            PCode = r.PCode,
                            Barcode = r.Barcode,
                            HSNCode = r.HSNCode,
                            ProductName = r.ProductName,
                            ProdDescr = r.ProdDescr,
                            UnitID = r.UnitID,
                            Tax1ID = r.Tax1ID,
                            Tax2ID = r.Tax2ID,
                            Tax3ID = r.Tax3ID,
                            PurchaseRate = r.PurchaseRate,
                            CurrentStock = (ps != null ? (decimal?)ps.Stock : null),

                            SaleRate = (from sr in db.tblRates

                                        join jpl in db.tblPriceLists on sr.PriceListID equals jpl.PriceListID into gpl
                                        from pl in gpl.DefaultIfEmpty()

                                        where sr.ProductID == r.ProductID

                                        select new StockItemRateViewModel()
                                        {
                                            PriceListID = sr.PriceListID,
                                            PriceListName = (pl != null ? pl.PriceListName : null),
                                            Rate = sr.Rate,
                                            DiscountPerc = sr.DiscPerc,
                                        }).ToList(),
                        }).FirstOrDefault();
            }
        }

        public StockItemDetailViewModel GetDetailViewModelByPrimeKey(long ID)
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

                        join ju in db.tblUnits on r.UnitID equals ju.UnitID into gu 
                        from u in gu.DefaultIfEmpty()

                        join jtax1 in db.tblAdditionalItemMasters on r.Tax1ID equals jtax1.AdditionaItemID into gtax1
                        from tax1 in gtax1.DefaultIfEmpty()

                        join jtax2 in db.tblAdditionalItemMasters on r.Tax2ID equals jtax2.AdditionaItemID into gtax2
                        from tax2 in gtax2.DefaultIfEmpty()

                        join jtax3 in db.tblAdditionalItemMasters on r.Tax3ID equals jtax3.AdditionaItemID into gtax3
                        from tax3 in gtax3.DefaultIfEmpty()

                        where r.ProductID == ID

                        select new StockItemDetailViewModel()
                        {
                            ProductID = r.ProductID,
                            PCode = r.PCode,
                            Barcode = r.Barcode,
                            HSNCode = r.HSNCode,
                            ProductName = r.ProductName,
                            ProdDescr = r.ProdDescr,

                            UnitID = r.UnitID,
                            UnitName = (u != null ? u.UnitName: null),

                            Tax1ID = r.Tax1ID,
                            Tax1Name = (tax1 != null ? tax1.ItemName : null),

                            Tax2ID = r.Tax2ID,
                            Tax2Name = (tax2 != null ? tax2.ItemName : null),

                            Tax3ID = r.Tax3ID,
                            Tax3Name = (tax3 != null ? tax3.ItemName : null),

                            PurchaseRate = r.PurchaseRate,
                            CurrentStock = (ps != null ? (decimal?)ps.Stock : null),
                            SaleRate = (from sr in db.tblRates
                                        join jpl in db.tblPriceLists on sr.PriceListID equals jpl.PriceListID into gpl
                                        from pl in gpl.DefaultIfEmpty()
                                        where sr.ProductID == r.ProductID
                                        select new StockItemRateViewModel()
                                        {
                                            PriceListID = sr.PriceListID,
                                            PriceListName = (pl != null ? pl.PriceListName : null),
                                            Rate = sr.Rate,
                                            DiscountPerc = sr.DiscPerc,
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
                var SaveModel = db.tblProducts.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblProducts.Attach(SaveModel);
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
            return GetLookupList();
        }

        public List<StockItemLookupListModel> GetLookupList()
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

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.PCode
                        select new StockItemLookupListModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            ProductID = r.ProductID,
                            PCode = r.PCode,
                            Barcode = r.Barcode,
                            ProductName = r.ProductName,
                            UnitName = r.tblUnit.UnitName,
                            CurrentStock = (ps != null ? (decimal?)ps.Stock : null),
                        }).ToList();
            }
        }

        public List<StockItemLookupListModel_WithoutStock> GetLookupList_WithoutStock()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblProducts

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.PCode

                        select new StockItemLookupListModel_WithoutStock()
                        {
                            ProductID = r.ProductID,
                            PCode = r.PCode,
                            Barcode = r.Barcode,
                            ProductName = r.ProductName,
                            UnitName = r.tblUnit.UnitName,
                        }).ToList();
            }
        }
        
        public bool IsDuplicateRecord(string ProductName, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(ProductName, ID, db);
            }
        }

        public bool IsDuplicateRecord(string ProductName, long ID, dbMarkerEntities db)
        {
            ProductName = ProductName.ToUpper();

            return db.tblProducts.Any(i => i.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID 
                                         && i.ProductName.ToUpper() == ProductName && i.ProductID != ID);
        }

        public long GeneratePCode()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return GeneratePCode(db);
            }
        }

        public long GeneratePCode(dbMarkerEntities db)
        {
                return (db.tblProducts.Where(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID).Max(r => (long?)r.PCode) ?? 0) + 1;
        }
        
        public bool IsDuplicatePCode(long PCode, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicatePCode(PCode, ID, db);
            }
        }

        public bool IsDuplicatePCode(long PCode, long ID, dbMarkerEntities db)
        {
            return db.tblProducts.Any(i => i.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                        && i.PCode == PCode && i.ProductID != ID);
        }


        public decimal GetSaleRate(long ProductID, long PriceListID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var vRate = db.tblRates.FirstOrDefault(r => r.ProductID == ProductID && r.PriceListID == PriceListID);

                if (vRate != null)
                {
                    return vRate.Rate;
                }
                return 0;

                //return (db.tblRates.FirstOrDefault(r => r.ProductID == ProductID && r.PriceListID == PriceListID)?.Rate) ?? 0M;                
            }
        }

        public decimal GetPurchaseRate(long ProductID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from p in db.tblProducts where p.ProductID == ProductID select (decimal?)p.PurchaseRate).FirstOrDefault() ?? 0;
                //return (db.tblProducts.FirstOrDefault(r => r.ProductID == ProductID)?.PurchaseRate) ?? 0M;
            }
        }

        //public long GenerateBarcode()
        //{
        //    using (dbMarkerEntities db = new dbMarkerEntities())
        //    {
        //        return (long)(db.tblProducts.Max(r => (long?)r.PCode) ?? 0) + 1;
        //    }
        //}

        public StockItemViewModel GetViewModelByPCode(long PCode)
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

                        where r.PCode == PCode

                        select new StockItemViewModel()
                        {
                            ProductID = r.ProductID,
                            PCode = r.PCode,
                            Barcode = r.Barcode,
                            HSNCode = r.HSNCode,
                            ProductName = r.ProductName,
                            ProdDescr = r.ProdDescr,
                            UnitID = r.UnitID,
                            Tax1ID = r.Tax1ID,
                            Tax2ID = r.Tax2ID,
                            Tax3ID = r.Tax3ID,
                            PurchaseRate = r.PurchaseRate,
                            CurrentStock = (ps != null ? (decimal?)ps.Stock : null),
                            SaleRate = (from sr in db.tblRates

                                        join jpl in db.tblPriceLists on sr.PriceListID equals jpl.PriceListID into gpl
                                        from pl in gpl.DefaultIfEmpty()

                                        where sr.ProductID == r.ProductID

                                        select new StockItemRateViewModel()
                                        {
                                            PriceListID = sr.PriceListID,
                                            PriceListName = (pl != null ? pl.PriceListName : null),
                                            Rate = sr.Rate,
                                            DiscountPerc = sr.DiscPerc,
                                        }).ToList(),
                        }).FirstOrDefault();
            }
        }

        public StockItemViewModel GetViewModelByBarcode(string Barcode)
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

                        where r.Barcode == Barcode

                        select new StockItemViewModel()
                        {
                            ProductID = r.ProductID,
                            PCode = r.PCode,
                            Barcode = r.Barcode,
                            HSNCode = r.HSNCode,
                            ProductName = r.ProductName,
                            ProdDescr = r.ProdDescr,
                            UnitID = r.UnitID,
                            Tax1ID = r.Tax1ID,
                            Tax2ID = r.Tax2ID,
                            Tax3ID = r.Tax3ID,
                            PurchaseRate = r.PurchaseRate,
                            CurrentStock = (ps != null ? (decimal?)ps.Stock : null),
                            SaleRate = (from sr in db.tblRates
                                        join jpl in db.tblPriceLists on sr.PriceListID equals jpl.PriceListID into gpl
                                        from pl in gpl.DefaultIfEmpty()
                                        where sr.ProductID == r.ProductID
                                        select new StockItemRateViewModel()
                                        {
                                            PriceListID = sr.PriceListID,
                                            PriceListName = (pl != null ? pl.PriceListName : null),
                                            Rate = sr.Rate,
                                            DiscountPerc = sr.DiscPerc,
                                        }).ToList(),
                        }).FirstOrDefault();
            }
        }

    }
}
