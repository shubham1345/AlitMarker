using Alit.Marker.DAL.Account.Account;
using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.Model.ERP.Transaction.Purchase.PurchaseReturn;
using Alit.Marker.Model.Inventory;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Transaction.Purchase.PurchaseReturn
{
    public class PurchaseReturnDAL : IDashboardDAL, ICRUDDAL
    {
        AccountVoucherDAL AccountVoucherDALObj;

        public PurchaseReturnDAL()
        {
            AccountVoucherDALObj = new AccountVoucherDAL();
        }
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((PurchaseReturnViewModel)ViewModel);
        }

        public SavingResult SaveRecord(PurchaseReturnViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (ViewModel.PurchaseReturnNo == 0)
            {
                res.ValidationError = "Please enter Purchase Return Number.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.CustomerAccountID == 0)
            {
                res.ValidationError = "Please select Customer.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.VoucherTypeID == 0)
            {
                res.ValidationError = "Please select Voucher Type.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.PurchaseAccountID == 0)
            {
                res.ValidationError = "Please select Purchase Account.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (ViewModel.ProductDetail == null || ViewModel.ProductDetail.Count == 0)
            {
                res.ValidationError = "Please enter Product.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.PurchaseReturnNo, ViewModel.PurchaseReturnID, db,
                    ViewModel.PurchaseReturnNoPrefixID, ViewModel.PurchaseReturnDate))
                {
                    long OldVNo = ViewModel.PurchaseReturnNo;
                    ViewModel.PurchaseReturnNo = GeneratePurchaseReturnNo(ViewModel.PurchaseReturnNoPrefixID, ViewModel.PurchaseReturnDate, db);

                    res.MessageAfterSave = string.Format("New number {0} has been generated, because {1} was already exists.", ViewModel.PurchaseReturnNo.ToString(), OldVNo.ToString());
                }

                tblPurchaseReturn SaveModel = null;
                tblStock StockSaveModel = null;
                if (ViewModel.PurchaseReturnID == 0) // New Entry
                {
                    SaveModel = new tblPurchaseReturn();
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
                    db.tblStocks.Add(StockSaveModel);
                }
                else
                {
                    SaveModel = db.tblPurchaseReturns.Find(ViewModel.PurchaseReturnID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    db.tblPurchaseReturns.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;


                    db.tblPurchaseReturnProductDetails.RemoveRange(db.tblPurchaseReturnProductDetails.Where(r => r.PurchaseReturnID == SaveModel.PurchaseReturnID));
                    db.tblPurchaseReturnAdditionals.RemoveRange(db.tblPurchaseReturnAdditionals.Where(r => r.PurchaseReturnID == SaveModel.PurchaseReturnID));


                    if (SaveModel.StockVoucherID != null)
                    {
                        StockSaveModel = db.tblStocks.Find(SaveModel.StockVoucherID);
                    }
                    if (StockSaveModel == null)
                    {
                        StockSaveModel = new tblStock()
                        {
                            rcdt = DateTime.Now,
                            rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID,
                            CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                            FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID,
                        };
                        db.tblStocks.Add(StockSaveModel);
                    }
                    else
                    {
                        StockSaveModel.redt = DateTime.Now;
                        StockSaveModel.reuid = CommonProperties.LoginInfo.LoggedinUser.UserID;
                        db.tblStocks.Attach(StockSaveModel);
                        db.Entry(StockSaveModel).State = System.Data.Entity.EntityState.Modified;

                    }
                    if (SaveModel.StockVoucherID != null)
                    {
                        db.tblStockPDetails.RemoveRange(db.tblStockPDetails.Where(r => r.StockVoucherID == SaveModel.StockVoucherID));
                    }
                    if (SaveModel.StockVoucherID != null)
                    {
                        db.tblStockPDetails.RemoveRange(db.tblStockPDetails.Where(r => r.StockVoucherID == SaveModel.StockVoucherID));
                    }
                }
                //--
                SaveModel.MemoType = (int)ViewModel.MemoType;
                SaveModel.PurchaseReturnDate = ViewModel.PurchaseReturnDate;
                SaveModel.PurchaseReturnNoPrefixID = ViewModel.PurchaseReturnNoPrefixID;
                SaveModel.PurchaseReturnNo = ViewModel.PurchaseReturnNo;
                SaveModel.CustomerAccountID = ViewModel.CustomerAccountID;
                SaveModel.GrossAmt = ViewModel.GrossAmt;
                SaveModel.NetAmt = ViewModel.NetAmt;
                SaveModel.RoundOffAmt = ViewModel.RoundOffAmt;
                SaveModel.RoundOffAddLessID = ViewModel.RoundOffAddLessID;
                SaveModel.PurchaseReturnMemo = ViewModel.PurchaseReturnMemo;
                SaveModel.tblStock = StockSaveModel;
                SaveModel.PurchaseAccountID = ViewModel.PurchaseAccountID;
                SaveModel.VoucherTypeID = ViewModel.VoucherTypeID;

                //--
                int Sno = 1;
                db.tblPurchaseReturnProductDetails.AddRange(ViewModel.ProductDetail.Select(r => new tblPurchaseReturnProductDetail()
                {
                    tblPurchaseReturn = SaveModel,
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

                db.tblPurchaseReturnAdditionals.AddRange(ViewModel.AdditionalItems.Select(r => new tblPurchaseReturnAdditional()
                {
                    tblPurchaseReturn = SaveModel,

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

                
                // Stock Voucher Header
                StockSaveModel.StockVoucherTypeID = (int)Model.Inventory.eStockVoucherType.PurchaseReturn;
                StockSaveModel.VDate = ViewModel.PurchaseReturnDate;
                StockSaveModel.VNo = ViewModel.PurchaseReturnNo;
                StockSaveModel.Narration = "P/R No. " + ViewModel.PurchaseReturnNo + ". " + ViewModel.PurchaseReturnMemo;

                Inventory.StockVoucherDAL stockVoucherDALObj = new Inventory.StockVoucherDAL();
                res = stockVoucherDALObj.SaveNewRecord(new StockVoucherViewModel()
                {
                    VoucherID = ViewModel.StockVoucherID ?? 0,
                    StockVoucherTypeID = eStockVoucherType.PurchaseReturn,
                    VoucherDate = ViewModel.PurchaseReturnDate,
                    VoucherNo = ViewModel.PurchaseReturnNo,
                    ProductID = null,
                    PriceListID = null,
                    Narration = "Purchase Return",

                    ProductDetail = ViewModel.ProductDetail.Where(r => r.ProductID != null && r.Quantity != 0).Select(r => new StockVoucherProductDetailViewModel()
                    {
                        //StockVoucherID = r.StockVoucherID,
                        //StockProductDetailID = r.StockPDetailID,
                        ProductID = r.ProductID.Value,
                        Quantity = -r.Quantity,
                        Rate = r.Rate,
                    }).ToList(),
                }
                , db, res);

                if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                {
                    return res;
                }

                #region Accounting Effects
                string CustomerName = db.tblAccounts.Find(ViewModel.CustomerAccountID)?.AccountName;
                string VoucherTypeName = db.tblVoucherTypes.Find(ViewModel.VoucherTypeID)?.VoucherTypeName;
                string PrefixName = db.tblPurchaseReceiptNoPrefixes.Find(ViewModel.PurchaseReturnNoPrefixID)?.PrefixName;

                List<AccountVoucherDetaillViewModel> dsAccountVoucher = new List<AccountVoucherDetaillViewModel>();

                //Customer Account = Credit
                dsAccountVoucher.Add(new AccountVoucherDetaillViewModel
                {
                    AccountID = ViewModel.CustomerAccountID,
                    Amount = ViewModel.NetAmt,
                    //Narration = ($"{(ViewModel.MemoType == eMemoType.Cash ? "Cash" : "Credit")}" + ", " + "Purchase Return , P/R No. " + " " + PrefixName + ViewModel.PurchaseReturnNo + (ViewModel.MemoType == eMemoType.Credit ? (", " + CustomerName) : null))
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
                                              Amount = (r.ItemNature == eAdditionalItemNature.Add ? -r.Amount : r.Amount), // Add=Credit, Less=Debit
                                              //Narration = CommonNarration,
                                          });

                /// Add=Credit, Less=Debit
                decimal AddLessValueForPurchaseAccount = AccountIDWiseSumm.Where(r => r.AccountID == null).Sum(r => (decimal?)(r.ItemNature == eAdditionalItemNature.Add ? -r.Amount : r.Amount)) ?? 0M;


                //Purchase Account = Debit
                dsAccountVoucher.Add(new AccountVoucherDetaillViewModel
                {
                    AccountID = ViewModel.PurchaseAccountID,
                    Amount = (-ViewModel.GrossAmt) + AddLessValueForPurchaseAccount,
                    //Narration = ($"{(ViewModel.MemoType == eMemoType.Cash ? "Cash" : "Credit")}" + ", " + "Purchase Return, P/R No." + " " + PrefixName + ViewModel.PurchaseReturnNo +  (!string.IsNullOrWhiteSpace(ViewModel.PurchaseReturnMemo) ? ", " + ViewModel.PurchaseReturnMemo : null))
                });


                tblAccountVoucher AccountVoucherSaveModel = null;
                AccountVoucherDALObj.SaveRecord(new AccountVoucherViewModel()
                {
                    AccountVoucherID = ViewModel.AccountVoucherID,
                    VoucherDate = ViewModel.PurchaseReturnDate,
                    VoucherNo = ViewModel.PurchaseReturnNo.ToString(),
                    Amount = ViewModel.NetAmt,
                    VoucherTypeID = ViewModel.VoucherTypeID,
                    CustomerAccountID = ViewModel.CustomerAccountID,
                    BookAccountID = ViewModel.PurchaseAccountID,
                    Narration = ViewModel.PurchaseReturnMemo,
                    AccountVoucherDetails = dsAccountVoucher,
                }, out AccountVoucherSaveModel, db, res);

                if (res != null && (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError))
                {
                    return res;
                }
                SaveModel.tblAccountVoucher = AccountVoucherSaveModel;
                #endregion

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.PurchaseReturnID;
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
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
            return Result;
        }


        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = null;// new SavingResult();

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
            SavingResult res = null;//new SavingResult();

            if (DeleteID != 0)
            {
                tblPurchaseReturn RecordToDelete = db.tblPurchaseReturns.FirstOrDefault(r => r.PurchaseReturnID == DeleteID);

                res = DeleteRecord(RecordToDelete, db);
            }
            else
            {
                res = new SavingResult();
            }
            return res;
        }

        public SavingResult DeleteRecord(tblPurchaseReturn RecordToDelete, dbMarkerEntities db)
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
                    ////RecordToDelete.tblCustomer.BalanceAmt += RecordToDelete.NetAmt;
                    ////db.tblCustomers.Attach(RecordToDelete.tblCustomer);
                    ////db.Entry(RecordToDelete.tblCustomer).State = System.Data.Entity.EntityState.Modified;
                    //Customer.CustomerBalanceDAL.UpdateBalance(RecordToDelete.CustomerID, -RecordToDelete.NetAmt, RecordToDelete.CompanyID, RecordToDelete.FinPeriodID, db, res);
                }

                if (RecordToDelete.AccountVoucherID != 0)
                {
                    AccountVoucherDALObj.DeleteRecord(RecordToDelete.AccountVoucherID, db);
                }

                db.tblPurchaseReturnProductDetails.RemoveRange(RecordToDelete.tblPurchaseReturnProductDetails);
                db.tblPurchaseReturnAdditionals.RemoveRange(RecordToDelete.tblPurchaseReturnAdditionals);
                db.tblPurchaseReturns.Remove(RecordToDelete);
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

                var res = (from r in db.tblPurchaseReturns

                           join jc in db.tblAccounts on r.CustomerAccountID equals jc.AccountID into gc
                           from cacc in gc.DefaultIfEmpty()

                           join jcity in db.tblCities on cacc.CityID equals jcity.CityID into gcity
                           from city in gcity.DefaultIfEmpty()

                           join jsip in db.tblPurchaseReturnNoPrefixes on r.PurchaseReturnNoPrefixID equals jsip.PurchaseReturnNoPrefixID into gsip
                           from sip in gsip.DefaultIfEmpty()

                           join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                           from rcu in grcu.DefaultIfEmpty()

                           join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                           from reu in greu.DefaultIfEmpty()

                           where r.CompanyID == CurrentCompanyID && r.FinPeriodID == CurrentFinPerID

                           orderby r.PurchaseReturnDate descending, r.PurchaseReturnNo descending

                           select new PurchaseReturnDashboardViewModel()
                           {
                               PurchaseReturnID = r.PurchaseReturnID,
                               MemoType = (eMemoType)r.MemoType,
                               PurchaseReturnNoPrefixName = (sip != null ? sip.PrefixName : null),
                               PurchaseReturnNo = r.PurchaseReturnNo,
                               PurchaseReturnDate = r.PurchaseReturnDate,

                               CustomerName = (cacc != null ? cacc.AccountName : null),
                               CustomerAddress = (cacc != null ? cacc.Address : null),
                               CustomerCityName = (city != null ? city.CityName : null),

                               NetAmt = r.NetAmt,
                               Memo = r.PurchaseReturnMemo,

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

        public PurchaseReturnViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblPurchaseReturns

                        where r.PurchaseReturnID == ID
                        select new PurchaseReturnViewModel()
                        {
                            PurchaseReturnID = r.PurchaseReturnID,
                            StockVoucherID = r.StockVoucherID,

                            MemoType = (eMemoType)r.MemoType,
                            PurchaseReturnDate = r.PurchaseReturnDate,
                            PurchaseReturnNoPrefixID = r.PurchaseReturnNoPrefixID,
                            PurchaseReturnNo = r.PurchaseReturnNo,

                            CustomerAccountID = r.CustomerAccountID,

                            GrossAmt = r.GrossAmt,
                            RoundOffAmt = r.RoundOffAmt ?? 0M,
                            RoundOffAddLessID = r.RoundOffAddLessID,
                            NetAmt = r.NetAmt,
                            PurchaseReturnMemo = r.PurchaseReturnMemo,
                            VoucherTypeID = r.VoucherTypeID,
                            PurchaseAccountID = r.PurchaseAccountID,
                            AccountVoucherID = r.AccountVoucherID,

                            ProductDetail = (from pd in db.tblPurchaseReturnProductDetails

                                             join jp in db.tblProducts on pd.ProductID equals jp.ProductID into gp
                                             from p in gp.DefaultIfEmpty()

                                             where pd.PurchaseReturnID == r.PurchaseReturnID
                                             select new PurchaseReturnProductDetailViewModel()
                                             {
                                                 PurchaseReturnProductDetailID = pd.PurchaseReturnProductDetailID,
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

                            AdditionalItems = (from al in db.tblPurchaseReturnAdditionals

                                               join jalm in db.tblAdditionalItemMasters on al.AdditionalItemID equals jalm.AdditionaItemID into galm
                                               from alm in galm.DefaultIfEmpty()

                                               where al.PurchaseReturnID == r.PurchaseReturnID
                                               select new PurchaseReturnAdditionalsViewModel()
                                               {
                                                   AdditionalsID = al.PurchaseReturnAdditionalsID,
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
                var SaveModel = db.tblPurchaseReturns.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblPurchaseReturns.Attach(SaveModel);
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
            string Series = CommonProperties.LoginInfo.SoftwareSettings.PurchaseReturnNoSeries;
            if (String.IsNullOrWhiteSpace(Series))
            {
                //if (db.tblPurchaseReturns.FirstOrDefault(i => i.PurchaseReturnNo == DocumentNo && i.PurchaseReturnID != ID && i.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID) != null)
                //{
                //    return true;
                //}

                return db.tblPurchaseReturns.Any(i => i.PurchaseReturnNo == DocumentNo && i.PurchaseReturnID != ID && i.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID);
            }
            else
            {
                //return (db.tblPurchaseReturns.Where(r => r.PurchaseReturnNo == DocumentNo && r.PurchaseReturnID != ID && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID && (
                //    (!Series.Contains("Prefix") || r.PurchaseReturnNoPrefixID == PrefixID) &&
                //    (!Series.Contains("Date") || (Date.HasValue && r.PurchaseReturnDate == Date)) &&
                //    (!Series.Contains("Year") || (Date.HasValue && r.PurchaseReturnDate.Year == Date.Value.Year)) &&
                //    (!Series.Contains("MonthYear") || (Date.HasValue && r.PurchaseReturnDate.Month == Date.Value.Month && r.PurchaseReturnDate.Year == Date.Value.Year))
                //    )
                //    ).FirstOrDefault() != null);

                return db.tblPurchaseReturns.Any(r => r.PurchaseReturnNo == DocumentNo && r.PurchaseReturnID != ID
                          && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                          && ((!Series.Contains("Prefix") || r.PurchaseReturnNoPrefixID == PrefixID) &&
                               (!Series.Contains("Date") || (Date.HasValue && r.PurchaseReturnDate == Date))
                           && (!Series.Contains("Year") || (Date.HasValue && r.PurchaseReturnDate.Year == Date.Value.Year)) &&
                              (!Series.Contains("MonthYear") || (Date.HasValue && r.PurchaseReturnDate.Month == Date.Value.Month && r.PurchaseReturnDate.Year == Date.Value.Year)
                              )));
            }
            //return false;
        }

        public long GeneratePurchaseReturnNo(long? PrefixID, DateTime? Date)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return GeneratePurchaseReturnNo(PrefixID, Date, db);
            }
        }

        public long GeneratePurchaseReturnNo(long? PrefixID, DateTime? Date, dbMarkerEntities db)
        {
            string Series = CommonProperties.LoginInfo.SoftwareSettings.PurchaseReturnNoSeries;

            if (String.IsNullOrWhiteSpace(Series))
            {
                return (db.tblPurchaseReturns.Max(r => (long?)r.PurchaseReturnNo) ?? 0) + 1;
            }
            else
            {
                return (db.tblPurchaseReturns.Where(r => r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID).
                                                        Where(r => (!Series.Contains("Prefix") || r.PurchaseReturnNoPrefixID == PrefixID) &&
                        (!Series.Contains("Date") || (Date.HasValue && r.PurchaseReturnDate == Date)) &&
                        (!Series.Contains("Year") || (Date.HasValue && r.PurchaseReturnDate.Year == Date.Value.Year)) &&
                        (!Series.Contains("MonthYear") || (Date.HasValue && r.PurchaseReturnDate.Month == Date.Value.Month && r.PurchaseReturnDate.Year == Date.Value.Year))
                        ).Max(r => (long?)r.PurchaseReturnNo) ?? 0) + 1;
            }
        }
    }
}