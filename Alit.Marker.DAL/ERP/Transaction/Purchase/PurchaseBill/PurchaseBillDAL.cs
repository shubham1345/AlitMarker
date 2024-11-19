using Alit.Marker.DAL.Account.Account;
using Alit.Marker.DAL.Inventory;
using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.Model.ERP.Transaction.Purchase.PurchaseBill;
using Alit.Marker.Model.Inventory;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Transaction.Purchase.PurchaseBill
{
    public class PurchaseBillDAL : IDashboardDAL, ICRUDDAL
    {
        AccountVoucherDAL AccountVoucherDALObj;

        public PurchaseBillDAL()
        {
            AccountVoucherDALObj = new AccountVoucherDAL();
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((PurchaseBillViewModel)ViewModel);
        }

        public SavingResult SaveRecord(PurchaseBillViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (String.IsNullOrWhiteSpace(ViewModel.PurchaseBillNo))
            {
                res.ValidationError = "Please enter Purchase Bill Number.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.PurchaseReceiptNo == 0)
            {
                res.ValidationError = "Please enter Purchase Receipt Number.";
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
                if (IsDuplicatePurchaseBillNo(ViewModel.PurchaseBillNo, ViewModel.CustomerAccountID, ViewModel.PurchaseBillID, db))
                {
                    res.ValidationError = "Can not accept duplicate Purchase Bill Number.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (ViewModel.PurchaseReceiptNo != null)
                {
                    if (IsDuplicatePurchaseReceiptNo(ViewModel.PurchaseReceiptNo ?? 0, ViewModel.PurchaseBillID, db,
                    ViewModel.PurchaseReceiptNoPrefixID, ViewModel.PurchaseReceiptDate))
                    {
                        long OldVNo = ViewModel.PurchaseReceiptNo ?? 0;
                        ViewModel.PurchaseReceiptNo = GenerateReceiptNo(ViewModel.PurchaseReceiptNoPrefixID, ViewModel.PurchaseReceiptDate, db);

                        res.MessageAfterSave = string.Format("New number {0} has been generated, because {1} was already exists.", ViewModel.PurchaseReceiptNo.ToString(), OldVNo.ToString());
                        //res.ValidationError = "Can not accept duplicate value. S/R No. is already exists.";
                        //res.ExecutionResult = eExecutionResult.ValidationError;
                        //return res;
                    }
                }
                else
                {
                    ViewModel.PurchaseReceiptNo = GenerateReceiptNo(ViewModel.PurchaseReceiptNoPrefixID, ViewModel.PurchaseReceiptDate, db);
                }

                //--------------------------------------------------
                tblPurchaseBill SaveModel = null;
                tblStock StockSaveModel = null;
                if (ViewModel.PurchaseBillID == 0) // New Entry
                {
                    SaveModel = new tblPurchaseBill();
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
                    SaveModel = db.tblPurchaseBills.Find(ViewModel.PurchaseBillID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Record not found. Selected record may be deleted over network by another user. Please contact your admin.";
                        return res;
                    }

                    db.tblPurchaseBills.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;

                    db.tblPurchaseBillProductDetails.RemoveRange(db.tblPurchaseBillProductDetails.Where(r => r.PurchaseBillID == SaveModel.PurchaseBillID));
                    db.tblPurchaseBillAdditionals.RemoveRange(db.tblPurchaseBillAdditionals.Where(r => r.PurchaseBillID == SaveModel.PurchaseBillID));

                    if (ViewModel.StockVoucherID != null)
                    {
                        StockSaveModel = db.tblStocks.Find(ViewModel.StockVoucherID);
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
                }

                //Header
                SaveModel.MemoType = (int)ViewModel.MemoType;
                SaveModel.PurchaseBillNo = ViewModel.PurchaseBillNo;
                SaveModel.PurchaseBillDate = ViewModel.PurchaseBillDate;
                SaveModel.PurchaseReceiptNoPrefixID = ViewModel.PurchaseReceiptNoPrefixID;
                SaveModel.PurchaseReceiptNo = ViewModel.PurchaseReceiptNo;
                SaveModel.PurchaseReceiptDate = ViewModel.PurchaseReceiptDate ?? ViewModel.PurchaseBillDate;
                SaveModel.CustomerAccountID = ViewModel.CustomerAccountID;
                SaveModel.GrossAmt = ViewModel.GrossAmt;
                SaveModel.NetAmt = ViewModel.NetAmt;
                SaveModel.RoundOffAmt = ViewModel.RoundOffAmt;
                SaveModel.RoundOffAddLessID = ViewModel.RoundOffAddLessID;
                SaveModel.PurchaseBillMemo = ViewModel.PurchaseBillMemo;
                SaveModel.tblStock = StockSaveModel;
                SaveModel.PurchaseAccountID = ViewModel.PurchaseAccountID;
                SaveModel.VoucherTypeID = ViewModel.VoucherTypeID;

                int Sno = 1;
                db.tblPurchaseBillProductDetails.AddRange(ViewModel.ProductDetail.Select(r => new tblPurchaseBillProductDetail()
                {
                    tblPurchaseBill = SaveModel,
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

                db.tblPurchaseBillAdditionals.AddRange(ViewModel.AdditionalItems.Select(r => new tblPurchaseBillAdditional()
                {
                    tblPurchaseBill = SaveModel,

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

                //------------------------------------------------------
                // Stock Voucher Header
                StockSaveModel.StockVoucherTypeID = (int)Model.Inventory.eStockVoucherType.PurchaseBill;
                StockSaveModel.VDate = ViewModel.PurchaseBillDate;
                StockSaveModel.VNo = ViewModel.PurchaseReceiptNo.Value;
                StockSaveModel.Narration = "P.Bill No. " + ViewModel.PurchaseBillNo + ". " + ViewModel.PurchaseBillMemo;

                List<tblStockPDetail> InventoryProductDetail = ViewModel.ProductDetail.Select(r => new tblStockPDetail()
                {
                    tblStock = StockSaveModel,
                    ProductID = r.ProductID.Value,
                    Qty = r.Quantity,
                    Rate = r.Rate,
                    rcuid = SaveModel.rcuid,
                    reuid = SaveModel.reuid,
                }).ToList();


                StockVoucherDAL StockVoucherDALObj = new StockVoucherDAL();
                res = StockVoucherDALObj.SaveNewRecord(new StockVoucherViewModel()
                {
                    StockVoucherTypeID = eStockVoucherType.PurchaseBill,
                    VoucherDate = ViewModel.PurchaseBillDate,
                    VoucherNo = ViewModel.PurchaseReceiptNo ?? 0,
                    ProductID = null,
                    PriceListID = null,
                    Narration = $"Purchase Bill No. {ViewModel.PurchaseBillNo} {ViewModel.PurchaseBillMemo}".Trim(),

                    ProductDetail = ViewModel.ProductDetail.Where(r => r.ProductID != null && r.Quantity != 0).Select(r => new StockVoucherProductDetailViewModel()
                    {
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

                #region Accounting Effects
                string CustomerName = db.tblAccounts.Find(ViewModel.CustomerAccountID)?.AccountName;
                string VoucherTypeName = db.tblVoucherTypes.Find(ViewModel.VoucherTypeID)?.VoucherTypeName;
                string PrefixName = db.tblPurchaseReceiptNoPrefixes.Find(ViewModel.PurchaseReceiptNoPrefixID)?.PrefixName;

                List<AccountVoucherDetaillViewModel> dsAccountVoucher = new List<AccountVoucherDetaillViewModel>();
                
                //Customer Account = Credit
                dsAccountVoucher.Add(new AccountVoucherDetaillViewModel
                {
                    AccountID = ViewModel.CustomerAccountID,
                    Amount = -ViewModel.NetAmt,
                    //Narration = (($"{(ViewModel.MemoType == eMemoType.Cash ? "Cash" : "Credit")}" + " " + "Purchase" + ", " + "P.B.No." + " " + ViewModel.PurchaseBillNo + (!string.IsNullOrWhiteSpace(ViewModel.PurchaseBillMemo) ? ", " + ViewModel.PurchaseBillMemo : null)))
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
                decimal AddLessValueForPurchaseAccount = AccountIDWiseSumm.Where(r => r.AccountID == null).Sum(r => (decimal?)(r.ItemNature == eAdditionalItemNature.Less ? -r.Amount : r.Amount)) ?? 0M;



                //Purchase Account Debit
                dsAccountVoucher.Add(new AccountVoucherDetaillViewModel
                {
                    AccountID = ViewModel.PurchaseAccountID,
                    Amount = ViewModel.GrossAmt + AddLessValueForPurchaseAccount,
                    //Narration = (($"{(ViewModel.MemoType == eMemoType.Cash ? "Cash" : "Credit")}" + " " + "Purchase" + ", " + "P.B.No." + " " + ViewModel.PurchaseBillNo + (ViewModel.MemoType == eMemoType.Credit ? (", " + CustomerName) : null)))
                });



                tblAccountVoucher AccountVoucherSaveModel = null;
                AccountVoucherDALObj.SaveRecord(new AccountVoucherViewModel()
                {
                    AccountVoucherID = ViewModel.AccountVoucherID,
                    VoucherDate = ViewModel.PurchaseBillDate,
                    VoucherNo = ViewModel.PurchaseBillNo.ToString(),
                    Amount = ViewModel.NetAmt,
                    VoucherTypeID = ViewModel.VoucherTypeID,
                    CustomerAccountID = ViewModel.CustomerAccountID,
                    BookAccountID = ViewModel.PurchaseAccountID,
                    Narration = ViewModel.PurchaseBillMemo,
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
                    res.PrimeKeyValue = SaveModel.PurchaseBillID;
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
                tblPurchaseBill RecordToDelete = db.tblPurchaseBills.FirstOrDefault(r => r.PurchaseBillID == DeleteID);

                res = DeleteRecord(RecordToDelete, db);
            }
            else
            {
                res = new SavingResult();
            }
            return res;
        }

        public SavingResult DeleteRecord(tblPurchaseBill RecordToDelete, dbMarkerEntities db)
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


                //if ((eMemoType)RecordToDelete.MemoType == eMemoType.Credit)
                //{
                //    //RecordToDelete.tblCustomer.BalanceAmt += RecordToDelete.NetAmt;
                //    //db.tblCustomers.Attach(RecordToDelete.tblCustomer);
                //    //db.Entry(RecordToDelete.tblCustomer).State = System.Data.Entity.EntityState.Modified;
                //    Customer.CustomerBalanceDAL.UpdateBalance(RecordToDelete.CustomerID, RecordToDelete.NetAmt, RecordToDelete.CompanyID, RecordToDelete.FinPeriodID, db, res);
                //}

                if (RecordToDelete.AccountVoucherID != 0)
                {
                    AccountVoucherDALObj.DeleteRecord(RecordToDelete.AccountVoucherID, db);
                }

                db.tblPurchaseBillProductDetails.RemoveRange(RecordToDelete.tblPurchaseBillProductDetails);
                db.tblPurchaseBillAdditionals.RemoveRange(RecordToDelete.tblPurchaseBillAdditionals);
                db.tblPurchaseBills.Remove(RecordToDelete);

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
                    (from r in db.tblPurchaseBills

                     join jc in db.tblAccounts on r.CustomerAccountID equals jc.AccountID into gc
                     from cacc in gc.DefaultIfEmpty()

                     join jcity in db.tblCities on cacc.CityID equals jcity.CityID into gcity
                     from city in gcity.DefaultIfEmpty()

                     join jsip in db.tblPurchaseReceiptNoPrefixes on r.PurchaseReceiptNoPrefixID equals jsip.PurchaseReceiptNoPrefixID into gsip
                     from sip in gsip.DefaultIfEmpty()

                     join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                     from rcu in grcu.DefaultIfEmpty()

                     join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                     from reu in greu.DefaultIfEmpty()

                     where r.CompanyID == CurrentCompanyID && r.FinPeriodID == CurrentFinPerID

                     orderby r.PurchaseBillDate descending, r.PurchaseReceiptNo descending

                     select new PurchaseBillDashboardViewModel()
                     {
                         PurchaseBillID = r.PurchaseBillID,
                         MemoType = (eMemoType)r.MemoType,

                         PurchaseBillNo = r.PurchaseBillNo,
                         PurchaseBillDate = r.PurchaseBillDate,

                         PurchaseReceiptNoPrefixName = (sip != null ? sip.PrefixName : null),
                         PurchaseReceiptNo = r.PurchaseReceiptNo,
                         PurchaseReceiptDate = r.PurchaseReceiptDate,

                         //CustomerID = r.CustomerID,
                         CustomerName = (cacc != null ? cacc.AccountName : null),
                         CustomerAddress = (cacc != null ? cacc.Address : null),
                         CustomerCityName = (city != null ? city.CityName : null),

                         NetAmt = r.NetAmt,
                         PurchaseBillMemo = r.PurchaseBillMemo,

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

        public PurchaseBillViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblPurchaseBills

                        join jinvnop in db.tblPurchaseReceiptNoPrefixes on r.PurchaseReceiptNoPrefixID equals jinvnop.PurchaseReceiptNoPrefixID into ginvnop
                        from invnop in ginvnop.DefaultIfEmpty()

                        where r.PurchaseBillID == ID

                        select new PurchaseBillViewModel()
                        {
                            PurchaseBillID = r.PurchaseBillID,
                            StockVoucherID = r.StockVoucherID,

                            MemoType = (eMemoType)r.MemoType,
                            PurchaseBillDate = r.PurchaseBillDate,
                            PurchaseBillNo = r.PurchaseBillNo,

                            PurchaseReceiptDate = r.PurchaseReceiptDate,
                            PurchaseReceiptNoPrefixID = r.PurchaseReceiptNoPrefixID,
                            //PurchaseReceiptNoPrefixName = (invnop != null ? invnop.PrefixName : null),
                            PurchaseReceiptNo = r.PurchaseReceiptNo,

                            //CustomerID = r.CustomerID,
                            CustomerAccountID = r.CustomerAccountID,

                            GrossAmt = r.GrossAmt,
                            RoundOffAmt = r.RoundOffAmt ?? 0M,
                            RoundOffAddLessID = r.RoundOffAddLessID,
                            NetAmt = r.NetAmt,
                            PurchaseBillMemo = r.PurchaseBillMemo,

                            VoucherTypeID = r.VoucherTypeID,
                            PurchaseAccountID = r.PurchaseAccountID,
                            AccountVoucherID = r.AccountVoucherID,

                            ProductDetail = (from pd in db.tblPurchaseBillProductDetails

                                             join jp in db.tblProducts on pd.ProductID equals jp.ProductID into gp
                                             from p in gp.DefaultIfEmpty()

                                             where pd.PurchaseBillID == r.PurchaseBillID

                                             select new PurchaseBillProductDetailViewModel()
                                             {
                                                 PurchaseBillProductDetailID = pd.PurchaseBillProductDetailID,
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

                            AdditionalItems = (from al in db.tblPurchaseBillAdditionals

                                               join jalm in db.tblAdditionalItemMasters on al.AdditionalItemID equals jalm.AdditionaItemID into galm
                                               from alm in galm.DefaultIfEmpty()

                                               where al.PurchaseBillID == r.PurchaseBillID
                                               select new PurchaseBillAdditionalsViewModel()
                                               {
                                                   AdditionalsID = al.PurchaseBillAdditionalsID,
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
                var SaveModel = db.tblPurchaseBills.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblPurchaseBills.Attach(SaveModel);
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

        public bool IsDuplicatePurchaseReceiptNo(long DocumentNo, long ID, long? PrefixID, DateTime? Date)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicatePurchaseReceiptNo(DocumentNo, ID, db, PrefixID, Date);
            }
        }

        public bool IsDuplicatePurchaseReceiptNo(long DocumentNo, long ID, dbMarkerEntities db, long? PrefixID, DateTime? Date)
        {
            string Series = CommonProperties.LoginInfo.SoftwareSettings.PurchaseReceiptNoSeries;
            if (String.IsNullOrWhiteSpace(Series))
            {
                return db.tblPurchaseBills.Any(i => i.PurchaseReceiptNo == DocumentNo && i.PurchaseBillID != ID && i.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID);
            }
            else
            {
                ////return (db.tblPurchaseBills.Where(r => r.PurchaseReceiptNo == DocumentNo && r.PurchaseBillID != ID && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID && (
                ////    (!Series.Contains("Prefix") || r.PurchaseReceiptNoPrefixID == PrefixID) &&
                ////    (!Series.Contains("Date") || (Date.HasValue && r.PurchaseReceiptDate == Date)) &&
                ////    (!Series.Contains("Year") || (Date.HasValue && r.PurchaseReceiptDate.Year == Date.Value.Year)) &&
                ////    (!Series.Contains("MonthYear") || (Date.HasValue && r.PurchaseReceiptDate.Month == Date.Value.Month && r.PurchaseReceiptDate.Year == Date.Value.Year))
                ////    )
                ////    ).FirstOrDefault() != null);

                return db.tblPurchaseBills.Any(r => r.PurchaseReceiptNo == DocumentNo
                                  && r.PurchaseBillID != ID
                                  && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                  && (
                                       (!Series.Contains("Prefix") || r.PurchaseReceiptNoPrefixID == PrefixID) &&
                                       (!Series.Contains("Date") || (Date.HasValue && r.PurchaseReceiptDate == Date))
                                       && (
                                         !Series.Contains("Year") || (Date.HasValue && r.PurchaseReceiptDate.Year == Date.Value.Year))
                                       && (!Series.Contains("MonthYear") || (Date.HasValue && r.PurchaseReceiptDate.Month == Date.Value.Month && r.PurchaseReceiptDate.Year == Date.Value.Year))
                                     ));
            }

            //return false;
        }

        public long GenerateReceiptNo(long? PrefixID, DateTime? Date)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return GenerateReceiptNo(PrefixID, Date, db);
            }
        }

        public long GenerateReceiptNo(long? PrefixID, DateTime? Date, dbMarkerEntities db)
        {
            string Series = CommonProperties.LoginInfo.SoftwareSettings.PurchaseReceiptNoSeries;
            //using (dbMarkerEntities db = new dbMarkerEntities())
            //{
            long? MaxInvNo = null;

            if (String.IsNullOrWhiteSpace(Series))
            {
                MaxInvNo = db.tblPurchaseBills.Max(r => (long?)r.PurchaseReceiptNo);
            }
            else
            {
                MaxInvNo = db.tblPurchaseBills.Where(r => r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID).
                                                    Where(r => (!Series.Contains("Prefix") || r.PurchaseReceiptNoPrefixID == PrefixID) &&
                    (!Series.Contains("Date") || (Date.HasValue && r.PurchaseReceiptDate == Date)) &&
                    (!Series.Contains("Year") || (Date.HasValue && r.PurchaseReceiptDate.Year == Date.Value.Year)) &&
                    (!Series.Contains("MonthYear") || (Date.HasValue && r.PurchaseReceiptDate.Month == Date.Value.Month && r.PurchaseReceiptDate.Year == Date.Value.Year))
                    ).Max(r => (long?)r.PurchaseReceiptNo);
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

        public bool IsDuplicatePurchaseBillNo(string DocumentNo, long? CustomerAccountID, long? ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicatePurchaseBillNo(DocumentNo, CustomerAccountID, ID, db);
            }
        }

        public bool IsDuplicatePurchaseBillNo(string DocumentNo, long? CustomerAccountID, long? ID, dbMarkerEntities db)
        {
            //if (db.tblPurchaseBills.FirstOrDefault(i => i.PurchaseBillNo == DocumentNo &&
            //                    i.CustomerID == CustomerID &&
            //                    i.PurchaseBillID != ID &&
            //                    i.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID) != null)
            //{
            //    return true;
            //}

            //return false;

            return db.tblPurchaseBills.Any(i => i.PurchaseBillNo == DocumentNo
                                             && i.CustomerAccountID == CustomerAccountID
                                             && i.PurchaseBillID != ID
                                             && i.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID);
        }

    }
}
