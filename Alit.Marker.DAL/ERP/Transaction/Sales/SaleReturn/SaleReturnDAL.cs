using Alit.Marker.DAL.Account.Account;
using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.Model.Customer;
using Alit.Marker.Model.ERP.Transaction.Sales.SaleReturn;
using Alit.Marker.Model.Inventory;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Transaction.Sales.SaleReturn
{
    public class SaleReturnDAL : IDashboardDAL, ICRUDDAL
    {
        AccountVoucherDAL AccountVoucherDALObj;

        public SaleReturnDAL()
        {
            AccountVoucherDALObj = new AccountVoucherDAL();
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((SaleReturnViewModel)ViewModel);
        }

        public SavingResult SaveRecord(SaleReturnViewModel ViewModel)
        {
            SavingResult res = new SavingResult();
            if (ViewModel.SaleReturnNo == 0)
            {
                res.ValidationError = "Please enter Sale Return Number.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.VoucherTypeID == 0)
            {
                res.ValidationError = "Please select Voucher Type.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.SaleAccountID == 0)
            {
                res.ValidationError = "Please select Sale Account.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.SaleReturnNo, ViewModel.SaleReturnID, db,
                    ViewModel.SaleReturnNoPrefixID, ViewModel.SaleReturnDate))
                {
                    long OldVNo = ViewModel.SaleReturnNo;
                    ViewModel.SaleReturnNo = GenerateSaleReturnNo(ViewModel.SaleReturnNoPrefixID, ViewModel.SaleReturnDate, db);

                    res.MessageAfterSave = string.Format("New number {0} has been generated, because {1} was already exists.", ViewModel.SaleReturnNo.ToString(), OldVNo.ToString());
                    //res.ValidationError = "Can not accept duplicate value. S/R No. is already exists.";
                    //res.ExecutionResult = eExecutionResult.ValidationError;
                    //return res;
                }


                //--------------------------------------------------
                tblSaleReturn SaveModel = null;
                tblStock StockSaveModel = null;
                if (ViewModel.SaleReturnID == 0) // New Entry
                {
                    SaveModel = new tblSaleReturn();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;

                    StockSaveModel = new tblStock()
                    {
                        rcdt = DateTime.Now,
                        rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID,
                        CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                        FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID,
                    };
                    SaveModel.tblStock = StockSaveModel;
                }
                else
                {
                    SaveModel = db.tblSaleReturns.Find(ViewModel.SaleReturnID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }
                    db.tblSaleReturns.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;

                    db.tblSaleReturnProductDetails.RemoveRange(db.tblSaleReturnProductDetails.Where(r => r.SaleReturnID == ViewModel.SaleReturnID));
                    db.tblSaleReturnAdditionals.RemoveRange(db.tblSaleReturnAdditionals.Where(r => r.SaleReturnID == ViewModel.SaleReturnID));

                    if (SaveModel.StockVoucherID != null)
                    {
                        db.tblStockPDetails.RemoveRange(db.tblStockPDetails.Where(r => r.StockVoucherID == SaveModel.StockVoucherID));
                    }

                    if (SaveModel.StockVoucherID != null)
                    {
                        StockSaveModel = db.tblStocks.Find(SaveModel.StockVoucherID);
                    }
                    if (StockSaveModel != null)
                    {
                        StockSaveModel.redt = DateTime.Now;
                        StockSaveModel.reuid = CommonProperties.LoginInfo.LoggedinUser.UserID;

                        db.tblStocks.Attach(StockSaveModel);
                        db.Entry(StockSaveModel).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        StockSaveModel = new tblStock()
                        {
                            rcdt = DateTime.Now,
                            rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID,
                            CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                            FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID,
                        };
                        db.tblStocks.Add(StockSaveModel);
                        SaveModel.tblStock = StockSaveModel;
                    }
                    if (SaveModel.StockVoucherID != null)
                    {
                        db.tblStockPDetails.RemoveRange(db.tblStockPDetails.Where(r => r.StockVoucherID == SaveModel.StockVoucherID));
                    }
                }

                SaveModel.MemoType = (int)ViewModel.MemoType;
                SaveModel.SaleReturnDate = ViewModel.SaleReturnDate;
                SaveModel.SaleReturnNoPrefixID = ViewModel.SaleReturnNoPrefixID;
                SaveModel.SaleReturnNo = ViewModel.SaleReturnNo;
                SaveModel.CustomerAccountID = ViewModel.CustomerAccountID;
                SaveModel.PriceListID = ViewModel.PriceListID;
                SaveModel.GrossAmt = ViewModel.GrossAmt;
                SaveModel.NetAmt = ViewModel.NetAmt;
                SaveModel.RoundOffAmt = ViewModel.RoundOffAmt;
                SaveModel.RoundOffAddLessID = ViewModel.RoundOffAddLessID;
                SaveModel.SaleReturnMemo = ViewModel.SaleReturnMemo;
                SaveModel.SaleAccountID = ViewModel.SaleAccountID;
                SaveModel.VoucherTypeID = ViewModel.VoucherTypeID;

                int Sno = 1;
                db.tblSaleReturnProductDetails.AddRange(ViewModel.ProductDetails.Select(r => new tblSaleReturnProductDetail()
                {
                    tblSaleReturn = SaveModel,
                    SNo = Sno++,
                    ProductID = r.ProductID,
                    Descr = r.ProductDescr,
                    Quan = r.Quantity,
                    Rate = r.Rate,
                    UnitID = r.UnitID,
                    DiscPerc = r.DiscPerc,
                    DiscAmt = r.DiscAmt,
                    GAmt = r.GAmt,
                    NAmt = r.NetAmt,

                    Tax1Perc = r.Tax1Perc,
                    Tax1Amt = r.Tax1Amt,
                    Tax1ID = r.Tax1ID,

                    Tax2Perc = r.Tax2Perc,
                    Tax2Amt = r.Tax2Amt,
                    Tax2ID = r.Tax2ID,

                    Tax3Perc = r.Tax3Perc,
                    Tax3Amt = r.Tax3Amt,
                    Tax3ID = r.Tax3ID,

                    CompanyID = SaveModel.CompanyID,
                    FinPeriodID = SaveModel.FinPeriodID,
                    rcdt = SaveModel.rcdt,
                    rcuid = SaveModel.rcuid,
                    redt = SaveModel.redt,
                    reuid = SaveModel.reuid,
                }));


                db.tblSaleReturnAdditionals.AddRange(ViewModel.AdditionalItems.Select(r => new tblSaleReturnAdditional()
                {
                    tblSaleReturn = SaveModel,

                    AdditionalItemID = r.AdditionalItemID,
                    Descr = r.ItemDescr,
                    ItemNature = (int)r.ItemNature,
                    IsInclusive = r.IsInclusive,
                    Perc = r.Perc,
                    Amt = r.Amt,
                    AmtCalculatedOn = r.CalculatedOnAmt,
                    CalculateOnID = (int)r.CalculateOn,
                    UpdatedAmt = r.UpdatedAmt,
                    RecordType = (int)r.RecordType,

                    rcuid = SaveModel.rcuid,
                    rcdt = SaveModel.rcdt,
                    redt = SaveModel.redt,
                    reuid = SaveModel.reuid,
                    CompanyID = SaveModel.CompanyID,
                    FinPeriodID = SaveModel.FinPeriodID,
                }));


                // stock header
                StockSaveModel.StockVoucherTypeID = (int)Model.Inventory.eStockVoucherType.SaleReturn;
                StockSaveModel.VDate = ViewModel.SaleReturnDate;
                StockSaveModel.VNo = ViewModel.SaleReturnNo;
                StockSaveModel.Narration = ViewModel.SaleReturnMemo;

                List<tblStockPDetail> InventoryProductDetail = ViewModel.ProductDetails.Where(r => r.ProductID != null).Select(r => new tblStockPDetail()
                {
                    tblStock = StockSaveModel,
                    ProductID = r.ProductID.Value,
                    Qty = r.Quantity,
                    Rate = r.Rate,
                    rcuid = SaveModel.rcuid,
                    reuid = SaveModel.reuid,
                }).ToList();
                
                //------------------------------------------------------
                Inventory.StockVoucherDAL stockVoucherDALObj = new Inventory.StockVoucherDAL();
                res = stockVoucherDALObj.SaveNewRecord(new StockVoucherViewModel()
                {
                    //VoucherID = ViewModel.StockInID,
                    StockVoucherTypeID = eStockVoucherType.SaleReturn,
                    VoucherDate = ViewModel.SaleReturnDate,
                    VoucherNo = ViewModel.SaleReturnNo,
                    ProductID = null,
                    PriceListID = null,
                    Narration = "Sale Return",

                    ProductDetail = ViewModel.ProductDetails.Where(r => r.ProductID != null && r.Quantity != 0).Select(r => new StockVoucherProductDetailViewModel()
                    {
                        //StockVoucherID = r.StockVoucherID,
                        //StockProductDetailID = r.StockPDetailID,
                        ProductID = r.ProductID.Value,
                        Quantity = r.Quantity,
                        Rate = r.Rate,
                    }).ToList(),
                }
                , db, res);

                if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                {
                    return res;
                }

                string CustomerName = db.tblAccounts.Find(ViewModel.CustomerAccountID)?.AccountName;
                //string VoucherTypeName = db.tblVoucherTypes.Find(ViewModel.VoucherTypeID)?.VoucherTypeName;
                string PrefixName = db.tblSaleInvoiceNoPrefixes.Find(ViewModel.SaleReturnNoPrefixID)?.PrefixName;

                List<AccountVoucherDetaillViewModel> dsAccountVoucher = new List<AccountVoucherDetaillViewModel>();

                // Customer Account = Credit
                dsAccountVoucher.Add(new AccountVoucherDetaillViewModel
                {
                    AccountID = ViewModel.CustomerAccountID,
                    Amount = -ViewModel.NetAmt,
                    //Narration = $"{(ViewModel.MemoType == eMemoType.Cash ? "Cash" : "Credit")}" + ", " + "Sale Return , S/R No. " + " " + PrefixName + ViewModel.SaleReturnNo
                });

                // Add/Less Accounts Effect
                var AdditionalItemsAccountIDs = (from r in db.tblAdditionalItemMasters
                                                 where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                                 select new
                                                 {
                                                     r.AdditionaItemID,
                                                     r.AccountID,
                                                 });
                var AccountIDWiseSumm = (from r2 in (from r in ViewModel.AdditionalItems
                                                     join jacid in AdditionalItemsAccountIDs on r.AdditionalItemID equals jacid.AdditionaItemID into gacid
                                                     from acid in gacid.DefaultIfEmpty()
                                                     where r.Amt != 0
                                                     select new
                                                     {
                                                         AdditionalItemID = r.AdditionalItemID,
                                                         AccountID = (acid != null ? acid.AccountID : null),
                                                         r.ItemNature,
                                                         Amt = r.Amt,
                                                     })

                                         group r2 by new { r2.AccountID, r2.ItemNature } into gr2
                                         select new
                                         {
                                             AccountID = gr2.Key.AccountID,
                                             ItemNature = gr2.Key.ItemNature,
                                             Amount = gr2.Sum(sr => sr.Amt),
                                         }).ToList();

                dsAccountVoucher.AddRange(from r in AccountIDWiseSumm
                                          where r.AccountID != null
                                          select new AccountVoucherDetaillViewModel()
                                          {
                                              AccountID = r.AccountID.Value,
                                              Amount = (r.ItemNature == eAdditionalItemNature.Less ? -r.Amount : r.Amount), // Add=Debit, Less=Credit
                                              //Narration = CommonNarration,
                                          });

                /// Add=Debit, Less=Credit
                decimal AddLessValueForSaleAccount = AccountIDWiseSumm.Where(r => r.AccountID == null).Sum(r => (decimal?)(r.ItemNature == eAdditionalItemNature.Less ? -r.Amount : r.Amount)) ?? 0M;


                // Sale Account = Debit
                dsAccountVoucher.Add(new AccountVoucherDetaillViewModel
                {
                    AccountID = ViewModel.SaleAccountID,
                    Amount = ViewModel.GrossAmt + AddLessValueForSaleAccount,
                    //Narration = (($"{(ViewModel.MemoType == eMemoType.Cash ? "Cash" : "Credit")}" + ", " + "Sale Return , S/R No. " + " " + PrefixName + ViewModel.SaleReturnNo + (ViewModel.MemoType == eMemoType.Credit ? (", " + CustomerName) : null)))
                });

                tblAccountVoucher AccountVoucherSaveModel = null;
                AccountVoucherDALObj.SaveRecord(new AccountVoucherViewModel()
                {
                    AccountVoucherID = ViewModel.AccountVoucherID,
                    VoucherDate = ViewModel.SaleReturnDate,
                    VoucherNo = ViewModel.SaleReturnNo.ToString(),
                    Amount = ViewModel.NetAmt,
                    VoucherTypeID = ViewModel.VoucherTypeID,
                    CustomerAccountID = ViewModel.CustomerAccountID,
                    BookAccountID = ViewModel.SaleAccountID,
                    Narration = ViewModel.SaleReturnMemo,
                    AccountVoucherDetails = dsAccountVoucher,
                }, out AccountVoucherSaveModel, db, res);

                if (res != null && (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError))
                {
                    return res;
                }
                SaveModel.tblAccountVoucher = AccountVoucherSaveModel;
                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.SaleReturnID;
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
            //using (dbMarkerEntities db = new dbMarkerEntities())
            //{

            //    bool InState = db.tblStates.FirstOrDefault(r => r.TransportID == DeleteID) != null;

            //    if(InState)
            //    {
            //        Result.ValidationMessage = "Transport exists in some states";
            //    }
            //}
            Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
            return Result;
        }


        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = null;//new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                res = DeleteRecord(DeleteID, db);

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
            SavingResult res = new SavingResult();
            tblSaleReturn RecordToDelete = db.tblSaleReturns.FirstOrDefault(r => r.SaleReturnID == DeleteID);

            if (RecordToDelete == null)
            {
                res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            else
            {
                if (RecordToDelete.StockVoucherID != null)
                {
                    //tblStock StockRecord = db.tblStocks.FirstOrDefault(r => r.VoucherID == RecordToDelete.StockVoucherID);
                    //db.tblStockPDetails.RemoveRange(db.tblStockPDetails.Where(r => r.StockVoucherID == StockRecord.VoucherID));
                    //db.tblStocks.Remove(StockRecord);

                    DAL.Inventory.StockVoucherDAL stockVoucherDALObj = new Inventory.StockVoucherDAL();
                    stockVoucherDALObj.DeleteRecord(RecordToDelete.StockVoucherID.Value, db);

                    //if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                    //{
                    //    return res;
                    //}
                }

                if ((eMemoType)RecordToDelete.MemoType == eMemoType.Credit)
                {
                    //RecordToDelete.tblCustomer.BalanceAmt += RecordToDelete.NetAmt;
                    //db.tblCustomers.Attach(RecordToDelete.tblCustomer);
                    //db.Entry(RecordToDelete.tblCustomer).State = System.Data.Entity.EntityState.Modified;
                    Customer.CustomerBalanceDAL.UpdateBalance(RecordToDelete.CustomerAccountID, RecordToDelete.NetAmt, RecordToDelete.CompanyID, RecordToDelete.FinPeriodID, db, res);
                }

                if (RecordToDelete.AccountVoucherID != 0)
                {
                    AccountVoucherDALObj.DeleteRecord(RecordToDelete.AccountVoucherID, db);
                }

                db.tblSaleReturnProductDetails.RemoveRange(RecordToDelete.tblSaleReturnProductDetails);
                db.tblSaleReturnAdditionals.RemoveRange(RecordToDelete.tblSaleReturnAdditionals);
                db.tblSaleReturns.Remove(RecordToDelete);
            }
            return res;
        }


        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long CurrentCompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                long CurrentFinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;

                var res =
                    (from r in db.tblSaleReturns

                     join jc in db.tblCustomers on r.CustomerAccountID equals jc.CustomerID into gc
                     from c in gc.DefaultIfEmpty()

                     join jcity in db.tblCities on c.CityID equals jcity.CityID into gcity
                     from city in gcity.DefaultIfEmpty()

                     join jsip in db.tblSaleReturnNoPrefixes on r.SaleReturnNoPrefixID equals jsip.SaleReturnNoPrefixID into gsip
                     from sip in gsip.DefaultIfEmpty()

                     join jpl in db.tblPriceLists on r.PriceListID equals jpl.PriceListID into gpl
                     from pl in gpl.DefaultIfEmpty()

                     join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                     from rcu in grcu.DefaultIfEmpty()

                     join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                     from reu in greu.DefaultIfEmpty()

                     where r.CompanyID == CurrentCompanyID && r.FinPeriodID == CurrentFinPerID

                     orderby r.SaleReturnDate descending, r.SaleReturnNo descending

                     select new SaleReturnDashboardViewModel()
                     {
                         SaleReturnID = r.SaleReturnID,
                         MemoType = (eMemoType)r.MemoType,

                         SaleReturnNoPrefixName = (sip != null ? sip.PrefixName : null),
                         SaleReturnNo = r.SaleReturnNo,

                         SaleReturnDate = r.SaleReturnDate,

                         CustomerID = r.CustomerAccountID,
                         CustomerName = (c != null ? c.CustomerName : null),
                         CustomerNameTitle = (c != null ? c.NameTitle : null),
                         CustomerAddress = (c != null ? c.Address : null),
                         CustomerCityName = (city != null ? city.CityName : null),

                         PriceListName = (pl != null ? pl.PriceListName : null),

                         NetAmt = r.NetAmt,

                         SaleReturnMemo = r.SaleReturnMemo,

                         RecordState = (eRecordState)r.rstate,
                         CreatedDateTime = r.rcdt,
                         EditedDateTime = r.redt,
                         CreatedUserID = r.rcuid,
                         EditedUserID = r.reuid,
                         CreatedUserName = (rcu != null ? rcu.UserName : null),
                         EditedUserName = (reu != null ? reu.UserName : null),

                     }).ToList();
                return res;
            }
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public SaleReturnViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblSaleReturns

                        join jinvnop in db.tblSaleReturnNoPrefixes on r.SaleReturnNoPrefixID equals jinvnop.SaleReturnNoPrefixID into ginvnop
                        from invnop in ginvnop.DefaultIfEmpty()

                        where r.SaleReturnID == ID

                        select new SaleReturnViewModel()
                        {
                            SaleReturnID = r.SaleReturnID,
                            StockVoucherID = r.StockVoucherID,
                            MemoType = (eMemoType)r.MemoType,
                            SaleReturnDate = r.SaleReturnDate,
                            SaleReturnNoPrefixID = r.SaleReturnNoPrefixID,
                            //SaleReturnNoPrefixName = (invnop != null ? invnop.PrefixName : null),
                            SaleReturnNo = r.SaleReturnNo,
                            CustomerAccountID = r.CustomerAccountID,
                            PriceListID = r.PriceListID,
                            GrossAmt = r.GrossAmt,
                            RoundOffAmt = r.RoundOffAmt ?? 0M,
                            RoundOffAddLessID = r.RoundOffAddLessID,
                            NetAmt = r.NetAmt,
                            SaleReturnMemo = r.SaleReturnMemo,
                            VoucherTypeID = r.VoucherTypeID,
                            SaleAccountID = r.SaleAccountID,
                            AccountVoucherID = r.AccountVoucherID,

                            ProductDetails = (from pd in db.tblSaleReturnProductDetails

                                              join jp in db.tblProducts on pd.ProductID equals jp.ProductID into gp
                                              from p in gp.DefaultIfEmpty()

                                              where pd.SaleReturnID == r.SaleReturnID
                                              select new SaleReturnProductDetailViewModel()
                                              {
                                                  SaleReturnProductDetailID = pd.SaleReturnProductDetailID,
                                                  ProductID = pd.ProductID,
                                                  PCode = (p != null ? (long?)p.PCode : null),
                                                  Barcode = (p != null ? p.Barcode : null),
                                                  ProductName = (p != null ? p.ProductName : null),
                                                  ProductDescr = pd.Descr,
                                                  UnitID = pd.UnitID,
                                                  Quantity = pd.Quan,
                                                  Rate = pd.Rate,
                                                  GAmt = pd.GAmt,
                                                  DiscPerc = pd.DiscPerc,
                                                  DiscAmt = pd.DiscAmt,
                                                  NetAmt = pd.NAmt,

                                                  Tax1ID = pd.Tax1ID,
                                                  Tax1Perc = pd.Tax1Perc,
                                                  Tax1Amt = pd.Tax1Amt ?? 0,

                                                  Tax2ID = pd.Tax2ID,
                                                  Tax2Perc = pd.Tax2Perc,
                                                  Tax2Amt = pd.Tax2Amt ?? 0,

                                                  Tax3ID = pd.Tax3ID,
                                                  Tax3Perc = pd.Tax3Perc,
                                                  Tax3Amt = pd.Tax3Amt ?? 0,

                                              }).ToList(),

                            AdditionalItems = (from al in db.tblSaleReturnAdditionals

                                               join jalm in db.tblAdditionalItemMasters on al.AdditionalItemID equals jalm.AdditionaItemID into galm
                                               from alm in galm.DefaultIfEmpty()

                                               where al.SaleReturnID == r.SaleReturnID
                                               select new SaleReturnAdditionalsViewModel()
                                               {
                                                   AdditionalsID = al.SaleReturnAdditionalsID,
                                                   AdditionalItemID = al.AdditionalItemID,
                                                   AdditionalItemName = (alm != null ? alm.ItemName : null),
                                                   ItemDescr = al.Descr,
                                                   ItemNature = (eAdditionalItemNature)al.ItemNature,
                                                   Perc = al.Perc ?? 0M,
                                                   Amt = al.Amt,
                                                   UpdatedAmt = al.UpdatedAmt,
                                                   CalculateOn = (eCalculateOn)al.CalculateOnID,
                                                   CalculatedOnAmt = al.AmtCalculatedOn,
                                                   RecordType = (eAdditionalRecordType)al.RecordType,
                                                   CalculatePercRev = (alm != null ? alm.CalculatePerc ?? false : false),
                                                   IsInclusive = al.IsInclusive ?? false,
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
                var SaveModel = db.tblSaleReturns.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblSaleReturns.Attach(SaveModel);
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

        public bool IsDuplicateRecord(long DocumentNo, long ID, long? PrefixID, DateTime? Date)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(DocumentNo, ID, db, PrefixID, Date);
            }
        }

        public bool IsDuplicateRecord(long DocumentNo, long ID, dbMarkerEntities db, long? PrefixID, DateTime? Date)
        {
            string Series = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoSeries;
            if (String.IsNullOrWhiteSpace(Series))
            {
                //if (db.tblSaleReturns.FirstOrDefault(i => i.SaleReturnNo == DocumentNo
                //            && i.SaleReturnID != ID
                //            && i.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID) != null)
                //{
                //    return true;
                //}

                return db.tblSaleReturns.Any(i => i.SaleReturnNo == DocumentNo
                                && i.SaleReturnID != ID
                                && i.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID);
            }
            else
            {
                //return (db.tblSaleReturns.Where(r =>
                //            r.SaleReturnNo == DocumentNo
                //            && r.SaleReturnID != ID
                //            && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                //            && (
                //    (!Series.Contains("Prefix") || r.SaleReturnNoPrefixID == PrefixID) &&
                //    (!Series.Contains("Date") || (Date.HasValue && r.SaleReturnDate == Date)) &&
                //    (!Series.Contains("Year") || (Date.HasValue && r.SaleReturnDate.Year == Date.Value.Year)) &&
                //    (!Series.Contains("MonthYear") || (Date.HasValue && r.SaleReturnDate.Month == Date.Value.Month && r.SaleReturnDate.Year == Date.Value.Year))
                //    )).FirstOrDefault() != null);
                return db.tblSaleReturns.Any(r =>
                            r.SaleReturnNo == DocumentNo
                            && r.SaleReturnID != ID
                            && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                            && (
                    (!Series.Contains("Prefix") || r.SaleReturnNoPrefixID == PrefixID) &&
                    (!Series.Contains("Date") || (Date.HasValue && r.SaleReturnDate == Date)) &&
                    (!Series.Contains("Year") || (Date.HasValue && r.SaleReturnDate.Year == Date.Value.Year)) &&
                    (!Series.Contains("MonthYear") || (Date.HasValue && r.SaleReturnDate.Month == Date.Value.Month && r.SaleReturnDate.Year == Date.Value.Year))
                    ));
            }

            //return false;
        }

        public long GenerateSaleReturnNo(long? PrefixID, DateTime? Date)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return GenerateSaleReturnNo(PrefixID, Date, db);
            }
        }

        public long GenerateSaleReturnNo(long? PrefixID, DateTime? Date, dbMarkerEntities db)
        {
            string Series = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoSeries;
            //using (dbMarkerEntities db = new dbMarkerEntities())
            //{
                long? MaxInvNo = null;

                if (String.IsNullOrWhiteSpace(Series))
                {
                    MaxInvNo = db.tblSaleReturns.Max(r => (long?)r.SaleReturnNo);
                }
                else
                {
                    MaxInvNo = db.tblSaleReturns.Where(r => r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID).
                                                        Where(r => (!Series.Contains("Prefix") || r.SaleReturnNoPrefixID == PrefixID) &&
                        (!Series.Contains("Date") || (Date.HasValue && r.SaleReturnDate == Date)) &&
                        (!Series.Contains("Year") || (Date.HasValue && r.SaleReturnDate.Year == Date.Value.Year)) &&
                        (!Series.Contains("MonthYear") || (Date.HasValue && r.SaleReturnDate.Month == Date.Value.Month && r.SaleReturnDate.Year == Date.Value.Year))
                        ).Max(r => (long?)r.SaleReturnNo);
                }

                if (MaxInvNo.HasValue)
                {
                    return MaxInvNo.Value + 1;
                }
                else
                {
                    return 1;
                }
            //}
        }
    }
}