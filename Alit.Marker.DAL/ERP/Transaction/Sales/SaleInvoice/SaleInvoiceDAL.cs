using Alit.Marker.DAL.Account.Account;
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix;
using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.Model.ERP.Transaction.Sales.SaleInvoice;
using Alit.Marker.Model.Inventory;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Transaction.Sales.SaleInvoice
{
    public class SaleInvoiceDAL : IDashboardDAL, ICRUDDAL, ILookupListDAL
    {
        AccountVoucherDAL AccountVoucherDALObj;

        public SaleInvoiceDAL()
        {
            AccountVoucherDALObj = new AccountVoucherDAL();
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((SaleInvoiceViewModel)ViewModel);
        }

        public SavingResult SaveRecord(SaleInvoiceViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (ViewModel.SaleInvoiceNo == 0)
            {
                res.ValidationError = "Please enter Invoice No.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.CustomerAccountID == 0)
            {
                res.ValidationError = "Please select Customer.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.ProductDetail == null || ViewModel.ProductDetail.Count == 0)
            {
                res.ValidationError = "Please enter Product.";
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

            //--
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.SaleInvoiceNo
                                      , ViewModel.SaleInvoiceID
                                      , db
                                      , (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoPrefix ? (long?)ViewModel.SaleInvoiceNoPrefixID : null)
                                      , (DateTime?)ViewModel.SaleInvoiceDate))
                {
                    long OldVNo = ViewModel.SaleInvoiceNo;
                    ViewModel.SaleInvoiceNo = GenerateSaleInvoiceNo(ViewModel.SaleInvoiceNoPrefixID, ViewModel.SaleInvoiceDate);
                    res.MessageAfterSave = string.Format("New number {0} has been generated, because {1} was already exists.", ViewModel.SaleInvoiceNo.ToString(), OldVNo.ToString());
                    //res.ValidationError = "Can not accept duplicate value. Invoice No. is already exists.";
                    //res.ExecutionResult = eExecutionResult.ValidationError;
                    //return res;
                }

                //--------------------------------------------------
                tblSaleInvoice SaveModel;
                tblStock StockSaveModel = null;
                if (ViewModel.SaleInvoiceID == 0) // New Entry
                {
                    SaveModel = new tblSaleInvoice();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                    db.tblSaleInvoices.Add(SaveModel);

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
                    SaveModel = db.tblSaleInvoices.Find(ViewModel.SaleInvoiceID);
                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblSaleInvoices.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    db.tblSaleInvoiceProductDetails.RemoveRange(db.tblSaleInvoiceProductDetails.Where(r => r.SaleInvoiceID == ViewModel.SaleInvoiceID));
                    db.tblSaleInvoiceAdditionals.RemoveRange(db.tblSaleInvoiceAdditionals.Where(r => r.SaleInvoiceID == ViewModel.SaleInvoiceID));


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

                //Sale Table Header
                SaveModel.MemoType = (int)ViewModel.MemoType;
                SaveModel.SaleInvoiceNoPrefixID = ViewModel.SaleInvoiceNoPrefixID;
                SaveModel.SaleInvoiceNo = ViewModel.SaleInvoiceNo;
                SaveModel.SaleInvoiceDate = ViewModel.SaleInvoiceDate;
                //SaveModel.CustomerID = ViewModel.CustomerID;
                SaveModel.CustomerAccountID = ViewModel.CustomerAccountID;
                SaveModel.ChallanNo = ViewModel.ChallanNo;
                SaveModel.ChallanDate = ViewModel.ChallanDate;
                SaveModel.OrderNo = ViewModel.OrderNo;
                SaveModel.OrderDate = ViewModel.OrderDate;
                SaveModel.SupplRefNo = ViewModel.SupplierReferenceNo;
                SaveModel.OtherRefNo = ViewModel.OtherReferenceNo;
                SaveModel.TransportID = ViewModel.TransportID;
                SaveModel.NofPackets = ViewModel.NofPackets;
                SaveModel.Destination = ViewModel.Destination;
                SaveModel.DispDocNo = ViewModel.DispatchDocumentNo;
                SaveModel.DeliveryDate = ViewModel.DeliveryDate;
                SaveModel.PriceListID = ViewModel.PriceListID;
                SaveModel.GrossAmt = ViewModel.GrossAmt;
                SaveModel.NetAmt = ViewModel.NetAmt;
                SaveModel.InvoiceMemo = ViewModel.InvoiceMemo;
                SaveModel.AdvanceAmt = ViewModel.AdvanceAmt;
                SaveModel.SaleOrderID = ViewModel.SaleOrderID;
                SaveModel.RoundOffAmt = ViewModel.RoundOffAmt;
                SaveModel.RoundOffAddLessID = ViewModel.RoundOffAddLessID;
                SaveModel.tblStock = StockSaveModel;
                SaveModel.SaleAccountID = ViewModel.SaleAccountID;
                SaveModel.VoucherTypeID = ViewModel.VoucherTypeID;

                int Sno = 1;
                db.tblSaleInvoiceProductDetails.AddRange(ViewModel.ProductDetail.Select(r => new tblSaleInvoiceProductDetail()
                {
                    tblSaleInvoice = SaveModel,
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


                db.tblSaleInvoiceAdditionals.AddRange(ViewModel.AdditionalItems.Select(r => new tblSaleInvoiceAdditional()
                {
                    tblSaleInvoice = SaveModel,

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
                StockSaveModel.StockVoucherTypeID = (int)Model.Inventory.eStockVoucherType.SaleInvoice;
                StockSaveModel.VDate = ViewModel.SaleInvoiceDate;
                StockSaveModel.VNo = ViewModel.SaleInvoiceNo;
                StockSaveModel.Narration = ViewModel.InvoiceMemo;

                List<tblStockPDetail> InventoryProductDetail = ViewModel.ProductDetail.Where(r => r.ProductID != null).Select(r => new tblStockPDetail()
                {
                    tblStock = StockSaveModel,
                    ProductID = r.ProductID.Value,
                    Qty = -r.Quantity,
                    Rate = r.Rate,
                    rcuid = SaveModel.rcuid,
                    reuid = SaveModel.reuid,
                }).ToList();
                //it will be added in stockDAL.SaveRecord method //db.tblStockPDetails.AddRange(InventoryProductDetail);


                //------------------------------------------------------
                tblSaleInvoice OldSaleRecord = null;
                decimal AdvanceOldAmt = 0;
                if (ViewModel.SaleInvoiceID != 0)
                {
                    using (dbMarkerEntities db1 = new dbMarkerEntities())
                    {
                        OldSaleRecord = db1.tblSaleInvoices.FirstOrDefault(r => r.SaleInvoiceID == ViewModel.SaleInvoiceID);

                        var OldReceipt = db1.tblReceipts.FirstOrDefault(r => r.ReceiptID == ViewModel.AdvanceOldRecieptID);
                        if (OldReceipt != null)
                        {
                            AdvanceOldAmt = OldReceipt.Amount;
                        }
                    }
                }

                /// Sale Order
                if (ViewModel.SaleInvoiceID != 0 && OldSaleRecord != null && OldSaleRecord.SaleOrderID != ViewModel.SaleOrderID)
                {
                    tblSaleOrder SaleOrder = db.tblSaleOrders.Find(OldSaleRecord.SaleOrderID);
                    if (SaleOrder != null)
                    {
                        SaleOrder.SaleInvoiceID = null;
                        db.tblSaleOrders.Attach(SaleOrder);
                        db.Entry(SaleOrder).State = System.Data.Entity.EntityState.Modified;
                    }
                }
                if (ViewModel.SaleOrderID != null && ViewModel.SaleOrderID != 0 && (ViewModel.SaleInvoiceID == 0 || (OldSaleRecord != null && OldSaleRecord.SaleOrderID != ViewModel.SaleOrderID)))
                {
                    tblSaleOrder SaleOrder = db.tblSaleOrders.Find(ViewModel.SaleOrderID);
                    SaleOrder.tblSaleInvoice = SaveModel;
                    if (SaleOrder != null)
                    {
                        db.tblSaleOrders.Attach(SaleOrder);
                        db.Entry(SaleOrder).State = System.Data.Entity.EntityState.Modified;
                    }
                }
                /// End Sale Order

                //----------------------------------------

                Inventory.StockVoucherDAL stockVoucherDALObj = new Inventory.StockVoucherDAL();
                res = stockVoucherDALObj.SaveNewRecord(new StockVoucherViewModel()
                {
                    //VoucherID = ViewModel.StockInID,
                    StockVoucherTypeID = eStockVoucherType.SaleInvoice,
                    VoucherDate = ViewModel.SaleInvoiceDate,
                    VoucherNo = ViewModel.SaleInvoiceNo,
                    ProductID = null,
                    PriceListID = null,
                    Narration = "Sale Invoice",

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

                // -- Saving Reciept
                if (ViewModel.SaleInvoiceID == 0 || (ViewModel.AdvanceAmt != 0 && ViewModel.AdvanceOldRecieptID == null)) // new
                {
                    if (ViewModel.AdvanceAmt != 0)
                    {
                        DAL.Account.Transactions.Receipt.ReceiptDAL RecDAL = new Account.Transactions.Receipt.ReceiptDAL();
                        string SaleInvoiceNoPrefixName = "";
                        if (CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoPrefix && ViewModel.SaleInvoiceNoPrefixID.HasValue)
                        {
                            var PrefixViewModle = new SaleInvoiceNoPrefixDAL().GetViewModelByPrimeKey(ViewModel.SaleInvoiceNoPrefixID.Value);
                            if (PrefixViewModle != null)
                            {
                                SaleInvoiceNoPrefixName = PrefixViewModle.PrefixName;
                            }
                        }
                        tblReceipt ReceiptSaveModel = new tblReceipt()
                        {
                            Amount = ViewModel.AdvanceAmt,
                            //CustomerID = ViewModel.CustomerID,
                            AccountID = ViewModel.CustomerAccountID,
                            PaymentType = (int)Model.CashBank.eModeOfPayment.Cash,
                            ReceiptDate = ViewModel.SaleInvoiceDate,
                            ReceiptNo = RecDAL.GenerateReceiptNo(null, ViewModel.SaleInvoiceDate, db),
                            Remarks = "Advance Payment on Invoice No. " + SaleInvoiceNoPrefixName + ViewModel.SaleInvoiceNo.ToString(),
                            rcdt = DateTime.Now,
                            rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID,
                            CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                            FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID,
                        };
                        db.tblReceipts.Add(ReceiptSaveModel);
                        SaveModel.tblReceipt = ReceiptSaveModel;
                    }
                }
                else
                {
                    // on Editing - do anything when finds changes in advance amt
                    if (ViewModel.AdvanceAmt != ViewModel.AdvanceOldAmt)
                    {
                        tblReceipt RecieptSaveModel = db.tblReceipts.FirstOrDefault(r => r.ReceiptID == ViewModel.AdvanceOldRecieptID);

                        // Delete Advance Reciept
                        if (SaveModel.AdvanceAmt == 0)
                        {
                            if (RecieptSaveModel != null)
                            {
                                db.tblReceipts.Remove(RecieptSaveModel);
                            }
                            SaveModel.AdvanceRecieptID = null;
                        }
                        else // update amount
                        {
                            RecieptSaveModel.Amount = ViewModel.AdvanceAmt;
                            RecieptSaveModel.redt = DateTime.Now;
                            RecieptSaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                            db.tblReceipts.Attach(RecieptSaveModel);
                            db.Entry(RecieptSaveModel).State = System.Data.Entity.EntityState.Modified;
                        }
                    }
                }

                string CustomerName = db.tblAccounts.Find(ViewModel.CustomerAccountID)?.AccountName;
                string VoucherTypeName = db.tblVoucherTypes.Find(ViewModel.VoucherTypeID)?.VoucherTypeName;
                string PrefixName = db.tblSaleInvoiceNoPrefixes.Find(ViewModel.SaleInvoiceNoPrefixID)?.PrefixName;

                List<AccountVoucherDetaillViewModel> dsAccountVoucher = new List<AccountVoucherDetaillViewModel>();
                // Customer Account = Debit
                dsAccountVoucher.Add(new AccountVoucherDetaillViewModel
                {
                    AccountID = ViewModel.CustomerAccountID,
                    Amount = ViewModel.NetAmt,
                    //Narration = VoucherTypeName
                });

                //string CommonNarration = $"{(ViewModel.MemoType == eMemoType.Cash ? "Cash" : "Credit")}" + ", " + "Invoice No." + " " + PrefixName + ViewModel.SaleInvoiceNo + (ViewModel.MemoType == eMemoType.Credit ? (", " + CustomerName) : null);

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
                decimal AddLessValueForSaleAccount = AccountIDWiseSumm.Where(r => r.AccountID == null).Sum(r => (decimal?)(r.ItemNature == eAdditionalItemNature.Add ? -r.Amount : r.Amount)) ?? 0M;

                // Sale Account = Credit
                dsAccountVoucher.Add(new AccountVoucherDetaillViewModel
                {
                    AccountID = ViewModel.SaleAccountID,
                    Amount = (-ViewModel.GrossAmt) + AddLessValueForSaleAccount,
                    //Narration = CommonNarration
                });

                tblAccountVoucher AccountVoucherSaveModel = null;
                AccountVoucherDALObj.SaveRecord(new AccountVoucherViewModel()
                {
                    AccountVoucherID = ViewModel.AccountVoucherID,
                    VoucherDate = ViewModel.SaleInvoiceDate,
                    VoucherNo = ViewModel.SaleInvoiceNo.ToString(),
                    Amount = ViewModel.NetAmt,
                    VoucherTypeID = ViewModel.VoucherTypeID,
                    CustomerAccountID = ViewModel.CustomerAccountID,
                    BookAccountID = ViewModel.SaleAccountID,
                    AccountVoucherDetails = dsAccountVoucher,
                    Narration = ViewModel.InvoiceMemo,
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
                    res.PrimeKeyValue = SaveModel.SaleInvoiceID;
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
                tblSaleInvoice RecordToDelete = db.tblSaleInvoices.FirstOrDefault(r => r.SaleInvoiceID == DeleteID);

                res = DeleteRecord(RecordToDelete, db);
            }
            else
            {
                res = new SavingResult();
            }
            return res;
        }

        public SavingResult DeleteRecord(tblSaleInvoice RecordToDelete, dbMarkerEntities db)
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
                    DAL.Inventory.StockVoucherDAL stockVoucherDALObj = new Inventory.StockVoucherDAL();
                    stockVoucherDALObj.DeleteRecord(RecordToDelete.StockVoucherID.Value, db);
                }

                if ((eMemoType)RecordToDelete.MemoType == eMemoType.Credit)
                {
                    ////Customer.CustomerBalanceDAL.UpdateBalance(RecordToDelete.CustomerID, -RecordToDelete.NetAmt + RecordToDelete.AdvanceAmt ?? 0, RecordToDelete.CompanyID, RecordToDelete.FinPeriodID, db, res);
                    //Customer.CustomerBalanceDAL.UpdateBalance(RecordToDelete.CustomerAccountID, -RecordToDelete.NetAmt + RecordToDelete.AdvanceAmt ?? 0, RecordToDelete.CompanyID, RecordToDelete.FinPeriodID, db, res);
                    ////RecordToDelete.tblCustomer.BalanceAmt -= RecordToDelete.NetAmt + RecordToDelete.AdvanceAmt ?? 0;
                    ////db.tblCustomers.Attach(RecordToDelete.tblCustomer);
                    ////db.Entry(RecordToDelete.tblCustomer).State = System.Data.Entity.EntityState.Modified;
                }
                db.tblSaleInvoiceProductDetails.RemoveRange(RecordToDelete.tblSaleInvoiceProductDetails);
                db.tblSaleInvoiceAdditionals.RemoveRange(RecordToDelete.tblSaleInvoiceAdditionals);

                if (RecordToDelete.AdvanceRecieptID != null)
                {
                    db.tblReceipts.Remove(RecordToDelete.tblReceipt);
                }

                if (RecordToDelete.SaleOrderID.HasValue)
                {
                    tblSaleOrder saleOrder = db.tblSaleOrders.Find(RecordToDelete.SaleOrderID);
                    if (saleOrder != null)
                    {
                        saleOrder.SaleInvoiceID = null;
                        db.tblSaleOrders.Attach(saleOrder);
                        db.Entry(saleOrder).State = System.Data.Entity.EntityState.Modified;
                    }
                }

                if (RecordToDelete.AccountVoucherID != 0)
                {
                    AccountVoucherDALObj.DeleteRecord(RecordToDelete.AccountVoucherID, db);
                }

                db.tblSaleInvoices.Remove(RecordToDelete);

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

                List<SaleInvoiceDashboardViewModel> List =
                    (from r in db.tblSaleInvoices

                         //join jc in db.tblCustomers on r.CustomerID equals jc.CustomerID into gc
                         //from c in gc.DefaultIfEmpty()

                     join jc in db.tblAccounts on r.CustomerAccountID equals jc.AccountID into gc
                     from cacc in gc.DefaultIfEmpty()

                     join jcity in db.tblCities on cacc.CityID equals jcity.CityID into gcity
                     from city in gcity.DefaultIfEmpty()

                     join jsip in db.tblSaleInvoiceNoPrefixes on r.SaleInvoiceNoPrefixID equals jsip.SaleInvoiceNoPrefixID into gsip
                     from sip in gsip.DefaultIfEmpty()

                     join jpl in db.tblPriceLists on r.PriceListID equals jpl.PriceListID into gpl
                     from pl in gpl.DefaultIfEmpty()

                     join jtrnsp in db.tblTransports on r.TransportID equals jtrnsp.TransportID into gtrnsp
                     from trnsp in gtrnsp.DefaultIfEmpty()

                     join jrec in db.tblReceipts on r.AdvanceRecieptID equals jrec.ReceiptID into grec
                     from rec in grec.DefaultIfEmpty()

                     join jso in db.tblSaleOrders on r.SaleOrderID equals jso.SaleOrderID into gso
                     from so in gso.DefaultIfEmpty()

                     join jsonp in db.tblSaleOrderNoPrefixes on so.SaleOrderNoPrefixID equals jsonp.SaleOrderNoPrefixID into gsonp
                     from sonp in gsonp.DefaultIfEmpty()

                     join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                     from rcu in grcu.DefaultIfEmpty()

                     join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                     from reu in greu.DefaultIfEmpty()

                     where r.CompanyID == CurrentCompanyID && r.FinPeriodID == CurrentFinPerID

                     orderby r.SaleInvoiceDate descending, r.SaleInvoiceNo descending

                     select new SaleInvoiceDashboardViewModel()
                     {
                         SaleInvoiceID = r.SaleInvoiceID,
                         MemoType = (eMemoType)r.MemoType,

                         SaleInvoiceNoPrefixName = (sip != null ? sip.PrefixName : null),
                         SaleInvoiceNo = r.SaleInvoiceNo,

                         SaleInvoiceDate = r.SaleInvoiceDate,

                         //CustomerID = r.CustomerID,
                         //CustomerName = (c != null ? c.CustomerName : null),
                         //CustomerNameTitle = (c != null ? c.NameTitle : null),
                         CustomerID = r.CustomerAccountID,
                         CustomerName = (cacc != null ? cacc.AccountName : null),
                         CustomerAddress = (cacc != null ? cacc.Address : null),
                         CustomerCityName = (city != null ? city.CityName : null),

                         PriceListName = (pl != null ? pl.PriceListName : null),

                         ChallanNo = r.ChallanNo,
                         ChallanDate = r.ChallanDate,
                         OrderNo = r.OrderNo,
                         OrderDate = r.OrderDate,

                         TransportName = (trnsp != null ? trnsp.TransportName : null),
                         Destination = r.Destination,
                         DeliveryDate = r.DeliveryDate,
                         DispatchDocumentNo = r.DispDocNo,
                         NofPackets = r.NofPackets,
                         SupplierReferenceNo = r.SupplRefNo,
                         OtherReferenceNo = r.OtherRefNo,
                         SaleOrderNo = (so != null ? (long?)so.SaleOrderNo : null),
                         SaleOrderNoPrefixName = (sonp != null ? sonp.PrefixName : null),

                         NetAmt = r.NetAmt,
                         AdvanceAmt = (rec != null ? (decimal?)rec.Amount : null),
                         InvoiceMemo = r.InvoiceMemo,

                         RecordState = (eRecordState)r.rstate,
                         CreatedDateTime = r.rcdt,
                         EditedDateTime = r.redt,
                         CreatedUserID = r.rcuid,
                         EditedUserID = r.reuid,
                         CreatedUserName = (rcu != null ? rcu.UserName : ""),
                         EditedUserName = (reu != null ? reu.UserName : ""),
                     }).ToList();
                return List;
            }
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public SaleInvoiceViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblSaleInvoices

                        join jinvnop in db.tblSaleInvoiceNoPrefixes on r.SaleInvoiceNoPrefixID equals jinvnop.SaleInvoiceNoPrefixID into ginvnop
                        from invnop in ginvnop.DefaultIfEmpty()

                        where r.SaleInvoiceID == ID
                        select new SaleInvoiceViewModel()
                        {
                            SaleInvoiceID = r.SaleInvoiceID,
                            StockVoucherID = r.StockVoucherID,
                            SaleOrderID = r.SaleOrderID,
                            MemoType = (eMemoType)r.MemoType,
                            SaleInvoiceDate = r.SaleInvoiceDate,
                            SaleInvoiceNoPrefixID = r.SaleInvoiceNoPrefixID,
                            //SaleInvoiceNoPrefixName = (invnop != null ? invnop.PrefixName : null),
                            SaleInvoiceNo = r.SaleInvoiceNo,
                            //CustomerID = r.CustomerID,
                            CustomerAccountID = r.CustomerAccountID,
                            ChallanNo = r.ChallanNo,
                            ChallanDate = r.ChallanDate,
                            OrderNo = r.OrderNo,
                            OrderDate = r.OrderDate,
                            SupplierReferenceNo = r.SupplRefNo,
                            OtherReferenceNo = r.OtherRefNo,
                            TransportID = r.TransportID,
                            NofPackets = r.NofPackets,
                            Destination = r.Destination,
                            DispatchDocumentNo = r.DispDocNo,
                            DeliveryDate = r.DeliveryDate,
                            PriceListID = r.PriceListID,
                            GrossAmt = r.GrossAmt,
                            RoundOffAmt = r.RoundOffAmt ?? 0M,
                            RoundOffAddLessID = r.RoundOffAddLessID,
                            NetAmt = r.NetAmt,
                            InvoiceMemo = r.InvoiceMemo,
                            AdvanceAmt = r.AdvanceAmt ?? 0,
                            AdvanceOldAmt = r.AdvanceAmt ?? 0,
                            AdvanceOldRecieptID = r.AdvanceRecieptID,
                            VoucherTypeID = r.VoucherTypeID,
                            SaleAccountID = r.SaleAccountID,
                            AccountVoucherID = r.AccountVoucherID,

                            ProductDetail = (from pd in db.tblSaleInvoiceProductDetails

                                             join jp in db.tblProducts on pd.ProductID equals jp.ProductID into gp
                                             from p in gp.DefaultIfEmpty()

                                             where pd.SaleInvoiceID == r.SaleInvoiceID
                                             select new SaleInvoiceProductDetailViewModel()
                                             {
                                                 SaleInvoiceProductDetailID = pd.SaleInvoiceProductDetailID,
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

                            AdditionalItems = (from al in db.tblSaleInvoiceAdditionals

                                               join jalm in db.tblAdditionalItemMasters on al.AdditionalItemID equals jalm.AdditionaItemID into galm
                                               from alm in galm.DefaultIfEmpty()

                                               where al.SaleInvoiceID == r.SaleInvoiceID
                                               select new SaleInvoiceAdditionalsViewModel()
                                               {
                                                   AdditionalsID = al.SaleInvoiceAdditionalsID,
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
                var SaveModel = db.tblSaleInvoices.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblSaleInvoices.Attach(SaveModel);
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

        public bool IsDuplicateRecord(long SaleInvoiceNo, long ID, long? PrefixID, DateTime? SaleInvoiceDate)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(SaleInvoiceNo, ID, db, PrefixID, SaleInvoiceDate);
            }
        }

        public bool IsDuplicateRecord(long SaleInvoiceNo, long ID, dbMarkerEntities db, long? PrefixID, DateTime? SaleInvoiceDate)
        {
            string Series = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoSeries;

            if (String.IsNullOrWhiteSpace(Series))
            {
                return db.tblSaleInvoices.Any(i => i.SaleInvoiceNo == SaleInvoiceNo
                                                    && i.SaleInvoiceID != ID
                                                    && i.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID);
            }
            else
            {
                return db.tblSaleInvoices.Any(r => r.SaleInvoiceNo == SaleInvoiceNo && r.SaleInvoiceID != ID && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                    && (
                        (!Series.Contains("Prefix") || r.SaleInvoiceNoPrefixID == PrefixID) &&
                        (!Series.Contains("Date") || (SaleInvoiceDate.HasValue && r.SaleInvoiceDate == SaleInvoiceDate)) &&
                        (!Series.Contains("Year") || (SaleInvoiceDate.HasValue && r.SaleInvoiceDate.Year == SaleInvoiceDate.Value.Year)) &&
                        (!Series.Contains("MonthYear") || (SaleInvoiceDate.HasValue && r.SaleInvoiceDate.Month == SaleInvoiceDate.Value.Month && r.SaleInvoiceDate.Year == SaleInvoiceDate.Value.Year))
                       )
                    );
            }
        }


        public long GenerateSaleInvoiceNo(long? PrefixID, DateTime? SaleInvoiceDate)
        {
            string Series = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoSeries;
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long? MaxInvNo = null;

                if (String.IsNullOrWhiteSpace(Series))
                {
                    MaxInvNo = db.tblSaleInvoices.Where(r => r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID).Max(r => (long?)r.SaleInvoiceNo);
                }
                else
                {
                    MaxInvNo = db.tblSaleInvoices.Where(r => r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID).Where(r => (!Series.Contains("Prefix") || r.SaleInvoiceNoPrefixID == PrefixID) &&
                        (!Series.Contains("Date") || (SaleInvoiceDate.HasValue && r.SaleInvoiceDate == SaleInvoiceDate)) &&
                        (!Series.Contains("Year") || (SaleInvoiceDate.HasValue && r.SaleInvoiceDate.Year == SaleInvoiceDate.Value.Year)) &&
                        (!Series.Contains("MonthYear") || (SaleInvoiceDate.HasValue && r.SaleInvoiceDate.Month == SaleInvoiceDate.Value.Month && r.SaleInvoiceDate.Year == SaleInvoiceDate.Value.Year))
                        ).Max(r => (long?)r.SaleInvoiceNo);
                }

                if (MaxInvNo.HasValue)
                {
                    return MaxInvNo.Value + 1;
                }
                else
                {
                    return 1;
                }
            }
        }

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            return GetLookupList();
        }

        public List<SaleInvoiceLookupListModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblSaleInvoices

                           join jsip in db.tblSaleInvoiceNoPrefixes on r.SaleInvoiceNoPrefixID equals jsip.SaleInvoiceNoPrefixID into gsip
                           from sip in gsip.DefaultIfEmpty()

                               //join jc in db.tblCustomers on r.CustomerID equals jc.CustomerID into gc
                               //from c in gc.DefaultIfEmpty()

                           join jc in db.tblAccounts on r.CustomerAccountID equals jc.AccountID into gc
                           from c in gc.DefaultIfEmpty()

                           where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                && r.rstate != (byte)eRecordState.Deactivated

                           orderby r.SaleInvoiceNo

                           select new SaleInvoiceLookupListModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               SaleInvoiceID = r.SaleInvoiceID,
                               MemoType = (eMemoType)r.MemoType,
                               SaleInvoiceNoPrefixName = (sip != null ? sip.PrefixName : null),
                               SaleInvoiceNo = r.SaleInvoiceNo,

                               SaleInvoiceDate = r.SaleInvoiceDate,
                               //CustomerName = (c != null ? c.CustomerName : null),
                               CustomerName = (c != null ? c.AccountName : null),
                               NetAmt = r.NetAmt,

                           }).ToList();
                return res;
            }
        }

    }
}