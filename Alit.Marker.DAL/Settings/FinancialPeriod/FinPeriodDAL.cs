using Alit.Marker.DAL.ERP.Transaction.Sales.SaleInvoice;
using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Settings.FinancialPeriod;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Settings.FinancialPeriod
{
    public class FinPeriodDAL : IDashboardDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((FinPeriodViewModel)ViewModel);
        }

        public SavingResult SaveRecord(FinPeriodViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (String.IsNullOrWhiteSpace(ViewModel.FinPeriodName))
            {
                res.ValidationError = "Please enter Financial Period Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.FinPeriodName, ViewModel.FinPeriodID, db))
                {
                    res.ValidationError = "Can not accept duplicate Financial Period Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                bool IsNewFinPeriodAdded = (ViewModel.FinPeriodID == 0);

                tblFinPeriod SaveModel = null;
                if (ViewModel.FinPeriodID == 0) // New Entry
                {
                    SaveModel = new tblFinPeriod();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblFinPeriods.Add(SaveModel);

                    if (ViewModel.PreviousFinancialPeriod != null)
                    {
                        tblFinPeriod PrevFinPerSaveModel = db.tblFinPeriods.Find(ViewModel.PreviousFinancialPeriod.FinPeriodID);
                        if (PrevFinPerSaveModel != null)
                        {
                            if (PrevFinPerSaveModel.FinPeriodTo == null)
                            {
                                PrevFinPerSaveModel.FinPeriodTo = ViewModel.FinPeriodFrom.Date.AddDays(-1);
                                //if (PrevFinPerSaveModel.FinPeriodName == PrevFinPerSaveModel.FinPeriodFrom.Year.ToString() + " - *")
                                //{
                                PrevFinPerSaveModel.FinPeriodName = PrevFinPerSaveModel.FinPeriodFrom.Year.ToString() + " - " + PrevFinPerSaveModel.FinPeriodTo.Value.Year.ToString();
                                //}

                                PrevFinPerSaveModel.redt = DateTime.Now;
                                db.tblFinPeriods.Attach(PrevFinPerSaveModel);
                                db.Entry(PrevFinPerSaveModel).State = System.Data.Entity.EntityState.Modified;
                            }
                        }
                    }
                }
                else
                {
                    SaveModel = db.tblFinPeriods.Find(ViewModel.FinPeriodID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }
                    db.tblFinPeriods.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                }
                SaveModel.FinPeriodName = ViewModel.FinPeriodName;
                SaveModel.FinPeriodFrom = ViewModel.FinPeriodFrom;
                SaveModel.FinPeriodTo = ViewModel.FinPeriodTo;
                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.FinPeriodID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }

                if (IsNewFinPeriodAdded && ViewModel.PreviousFinancialPeriod != null)
                {
                    /// Transfer Stock and Balances
                    if (ViewModel.OpeningBalance != null)
                    {
                        DAL.Customer.CustomerOpeningBalanceDAL COPBDALObj = new Customer.CustomerOpeningBalanceDAL();
                        ///--- Save Customer Balances
                        foreach (var copb in ViewModel.OpeningBalance)
                        {
                            if (copb.OpeningBalance != 0)
                            {
                                tblCustomerOpBal CustomerOpeningBalanceSaveModel = new tblCustomerOpBal()
                                {
                                    OpBalDate = SaveModel.FinPeriodFrom.Date,
                                    OpBalAmt = copb.OpeningBalance,
                                    Narration = "Opening Balance T/F",
                                    CustomerID = copb.CustomerID,
                                    CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                                    tblFinPeriod = SaveModel,
                                    rcdt = DateTime.Now,
                                    rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID
                                };
                                COPBDALObj.SaveRecord(null, out CustomerOpeningBalanceSaveModel, SaveModel.CompanyID, SaveModel.FinPeriodID, db, res);
                            }
                        }
                    }
                    ///

                    /// Save Product Stock
                    if (ViewModel.OpeningStock != null)
                    {
                        DAL.Inventory.ProductOpeningStockDAL POStockDALObj = new Inventory.ProductOpeningStockDAL();
                        foreach (var stock in ViewModel.OpeningStock)
                        {
                            if (stock.Stock != 0)
                            {
                                tblStock OpeningStockSaveModel;
                                POStockDALObj.SaveRecord(new Model.Inventory.ProductOpeningStockViewModel()
                                {
                                    OpeningStockDate = SaveModel.FinPeriodFrom.Date,
                                    Narration = "Opening Stock T/F",
                                    OpeningStockQty = stock.Stock,
                                    ProductID = stock.ProductID,
                                    Rate = stock.Rate,
                                }, out OpeningStockSaveModel, SaveModel.CompanyID, SaveModel.FinPeriodID, db, res);
                            }
                        }
                    }
                    /// 
                    //--
                    try
                    {
                        db.SaveChanges();
                        res.PrimeKeyValue = SaveModel.FinPeriodID;
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

        public tblFinPeriod FindSaveModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return db.tblFinPeriods.Find(ID);
            }
        }
       
        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {

                if (DeleteID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID)
                {
                    Result.ValidationMessage = "Can not delete current logged in financial period. Please login other financial period to delete this.";
                }
                else
                {
                    tblFinPeriod FirstFinPer = db.tblFinPeriods.Where(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID).OrderBy(r => r.FinPeriodFrom).FirstOrDefault();
                    tblFinPeriod LastFinPer = db.tblFinPeriods.Where(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID).OrderByDescending(r => r.FinPeriodFrom).FirstOrDefault();

                    if (DeleteID != FirstFinPer.FinPeriodID && DeleteID != LastFinPer.FinPeriodID)
                    {
                        Result.ValidationMessage = "Can not delete. Oldest or newest finacial period can be deleted.";
                    }
                    else
                    {
                        tblFinPeriod RecordToDelete = db.tblFinPeriods.FirstOrDefault(r => r.FinPeriodID == DeleteID);
                        if (RecordToDelete != null)
                        {
                            long CompanyID = RecordToDelete.CompanyID;
                            long FinPeriodID = RecordToDelete.FinPeriodID;
                            /// Receipt
                            List<tblReceipt> ReceiptsToDelete = db.tblReceipts.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();

                            DAL.Account.Transactions.Receipt.ReceiptDAL RecietpDALObject = new Account.Transactions.Receipt.ReceiptDAL();
                            foreach (tblReceipt Rec in ReceiptsToDelete)
                            {
                                BeforeDeleteValidationResult ValRes = RecietpDALObject.ValidateBeforeDelete(Rec.ReceiptID);
                                if (!ValRes.IsValidForDelete)
                                {
                                    Result.IsValidForDelete = false;
                                    Result.ValidationMessage += "\r\nReceipt : " + ValRes.ValidationMessage;
                                }
                            }

                            // Sale 
                            SaleInvoiceDAL SaleDALObject = new SaleInvoiceDAL();
                            List<tblSaleInvoice> SalesToDelete = db.tblSaleInvoices.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                            foreach (tblSaleInvoice Rec in SalesToDelete)
                            {
                                BeforeDeleteValidationResult ValRes = SaleDALObject.ValidateBeforeDelete(Rec.SaleInvoiceID);
                                if (!ValRes.IsValidForDelete)
                                {
                                    Result.IsValidForDelete = false;
                                    Result.ValidationMessage += "\r\nSale : " + ValRes.ValidationMessage;
                                }
                            }
                        }
                    }
                }
            }
            Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
            return Result;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = null;

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
                    while (res.Exception != null && res.Exception.Message == "An error occurred while updating the entries. See the inner exception for details.")
                    {
                        res.Exception = res.Exception.InnerException;
                    }

                    if (ex.GetType() == typeof(System.Data.Entity.Validation.DbEntityValidationException))
                    {
                        res.ValidationError = "dbEntity Validation Errors : \r\n\r\n";

                        System.Data.Entity.Validation.DbEntityValidationException ValidationException = (System.Data.Entity.Validation.DbEntityValidationException)ex;

                        foreach (System.Data.Entity.Validation.DbEntityValidationResult ValidRes in ValidationException.EntityValidationErrors)
                        {
                            foreach (System.Data.Entity.Validation.DbValidationError ValidError in ValidRes.ValidationErrors)
                            {
                                res.ValidationError += ValidError.PropertyName + " = " + ValidError.ErrorMessage + "\r\n";
                            }
                            res.ValidationError += "\r\n";
                        }

                        res.Exception = new Exception(res.ValidationError);
                    }
                }

                //DAL.Customer.CustomerDAL CustomerDALObject = new Customer.CustomerDAL();
                //CustomerDALObject.ReCalculateBalance();
                //DAL.Customer.CustomerBalanceDAL.ReCalculateBalance();

            }
            return res;
        }

        public SavingResult DeleteRecord(long DeleteID, dbMarkerEntities db)
        {
            SavingResult res = null;
            if (DeleteID != 0)
            {
                tblFinPeriod RecordToDelete = db.tblFinPeriods.FirstOrDefault(r => r.FinPeriodID == DeleteID);

                res = DeleteRecord(RecordToDelete, db);
            }
            else
            {
                res = new SavingResult();
            }
            return res;
        }

        public SavingResult DeleteRecord(tblFinPeriod RecordToDelete, dbMarkerEntities db)
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
                //DateTime FinDateFrom = RecordToDelete.FinPeriodFrom;
                //DateTime? FinDateTo = RecordToDelete.FinPeriodTo.Value;
                long CompanyID = RecordToDelete.CompanyID;
                long FinPeriodID = RecordToDelete.FinPeriodID;

                //// Sale 
                var SaleInvoices = db.tblSaleInvoices.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID);
                db.tblSaleInvoiceAdditionals.RemoveRange(db.tblSaleInvoiceAdditionals.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                db.tblSaleInvoiceProductDetails.RemoveRange(db.tblSaleInvoiceProductDetails.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                db.tblSaleInvoices.RemoveRange(db.tblSaleInvoices.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));

                foreach (var sale in SaleInvoices)
                {
                    if (sale.AdvanceRecieptID != null)
                    {
                        db.tblReceipts.Remove(sale.tblReceipt);
                    }
                    if (sale.SaleOrderID.HasValue)
                    {
                        tblSaleOrder saleOrder = db.tblSaleOrders.Find(sale.SaleOrderID);
                        if (saleOrder != null)
                        {
                            saleOrder.SaleInvoiceID = null;
                            db.tblSaleOrders.Attach(saleOrder);
                            db.Entry(saleOrder).State = System.Data.Entity.EntityState.Modified;
                        }
                    }
                }

                /// Deleting Sale Invoices
                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    res.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
                    res.Exception = ex;
                    while (res.Exception != null && res.Exception.Message == "An error occurred while updating the entries. See the inner exception for details.")
                    {
                        res.Exception = res.Exception.InnerException;
                    }

                    if (ex.GetType() == typeof(System.Data.Entity.Validation.DbEntityValidationException))
                    {
                        res.ValidationError = "dbEntity Validation Errors : \r\n\r\n";

                        System.Data.Entity.Validation.DbEntityValidationException ValidationException = (System.Data.Entity.Validation.DbEntityValidationException)ex;

                        foreach (System.Data.Entity.Validation.DbEntityValidationResult ValidRes in ValidationException.EntityValidationErrors)
                        {
                            foreach (System.Data.Entity.Validation.DbValidationError ValidError in ValidRes.ValidationErrors)
                            {
                                res.ValidationError += ValidError.PropertyName + " = " + ValidError.ErrorMessage + "\r\n";
                            }
                            res.ValidationError += "\r\n";
                        }

                        res.Exception = new Exception(res.ValidationError);
                    }
                }
                //DAL.Sales.SaleInvoiceDAL SaleDALObject = new Sales.SaleInvoiceDAL();
                //List<tblSaleInvoice> SalesToDelete = db.tblSaleInvoices.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                //foreach (tblSaleInvoice Rec in SalesToDelete)
                //{
                //    res = SaleDALObject.DeleteRecord(Rec, db);
                //    if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                //    {
                //        return res;
                //    }
                //}

                //// Sale Return
                var SaleReturns = db.tblSaleReturns.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID);
                db.tblSaleReturnAdditionals.RemoveRange(db.tblSaleReturnAdditionals.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                db.tblSaleReturnProductDetails.RemoveRange(db.tblSaleReturnProductDetails.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                db.tblSaleReturns.RemoveRange(db.tblSaleReturns.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //DAL.Sales.SaleReturnDAL SaleReturnDALObject = new Sales.SaleReturnDAL();
                //List<tblSaleReturn> SaleReturnsToDelete = db.tblSaleReturns.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                //foreach (tblSaleReturn Rec in SaleReturnsToDelete)
                //{
                //    res = SaleReturnDALObject.DeleteRecord(Rec, db);
                //    if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                //    {
                //        return res;
                //    }
                //}


                //// Sale Order
                var SaleOrders = db.tblSaleOrders.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID);
                db.tblSaleOrderAdditionals.RemoveRange(db.tblSaleOrderAdditionals.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                db.tblSaleOrderProductDetails.RemoveRange(db.tblSaleOrderProductDetails.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                db.tblSaleOrders.RemoveRange(db.tblSaleOrders.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //DAL.Sales.SaleOrderDAL SaleOrderDALObject = new Sales.SaleOrderDAL();
                //List<tblSaleOrder> SaleOrdersToDelete = db.tblSaleOrders.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                //foreach (tblSaleOrder Rec in SaleOrdersToDelete)
                //{
                //    res = SaleOrderDALObject.DeleteRecord(Rec, db);
                //    if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                //    {
                //        return res;
                //    }
                //}

                //// PurchaseReturn Return
                db.tblPurchaseReturnAdditionals.RemoveRange(db.tblPurchaseReturnAdditionals.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                db.tblPurchaseReturnProductDetails.RemoveRange(db.tblPurchaseReturnProductDetails.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                db.tblPurchaseReturns.RemoveRange(db.tblPurchaseReturns.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //DAL.Purchase.PurchaseReturnDAL PurchaseReturnDALObject = new Purchase.PurchaseReturnDAL();
                //List<tblPurchaseReturn> PurchaseReturnsToDelete = db.tblPurchaseReturns.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                //foreach (tblPurchaseReturn Rec in PurchaseReturnsToDelete)
                //{
                //    res = PurchaseReturnDALObject.DeleteRecord(Rec, db);
                //    if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                //    {
                //        return res;
                //    }
                //}

                //// Purchase
                db.tblPurchaseBillAdditionals.RemoveRange(db.tblPurchaseBillAdditionals.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                db.tblPurchaseBillProductDetails.RemoveRange(db.tblPurchaseBillProductDetails.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                db.tblPurchaseBills.RemoveRange(db.tblPurchaseBills.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //DAL.Purchase.PurchaseInvoiceDAL PurchaseDALObject = new Purchase.PurchaseInvoiceDAL();
                //List<tblPurchase> PurchasesToDelete = db.tblPurchaseBills.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                //foreach (tblPurchase Rec in PurchasesToDelete)
                //{
                //    res = PurchaseDALObject.DeleteRecord(Rec, db);
                //    if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                //    {
                //        return res;
                //    }
                //}


                /// Receipt
                db.tblReceipts.RemoveRange(db.tblReceipts.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //List<tblReceipt> ReceiptsToDelete = db.tblReceipts.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                //DAL.Receipt.ReceiptDAL RecietpDALObject = new Receipt.ReceiptDAL();
                //foreach (tblReceipt Rec in ReceiptsToDelete)
                //{
                //    res = RecietpDALObject.DeleteRecord(Rec, db);
                //    if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                //    {
                //        return res;
                //    }
                //}


                /// Payment
                db.tblPayments.RemoveRange(db.tblPayments.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //List<tblPayment> PaymentsToDelete = db.tblPayments.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                //DAL.Payment.PaymentDAL RecietpDALObject = new Payment.PaymentDAL();
                //foreach (tblPayment Rec in PaymentsToDelete)
                //{
                //    res = RecietpDALObject.DeleteRecord(Rec, db);
                //    if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                //    {
                //        return res;
                //    }
                //}


                //-- Customer Balances
                db.tblCustomerBalances.RemoveRange(db.tblCustomerBalances.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));

                //// Inventory 
                db.tblStockPDetails.RemoveRange(db.tblStockPDetails.Where(r => r.tblStock.CompanyID == CompanyID && r.tblStock.FinPeriodID == FinPeriodID));
                db.tblStocks.RemoveRange(db.tblStocks.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));

                /// Product Stock
                db.tblProductStocks.RemoveRange(db.tblProductStocks.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));

                //// Opening Balance
                db.tblCustomerOpBals.RemoveRange(db.tblCustomerOpBals.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //DAL.Customer.CustomerOpeningBalanceDAL OpBalDALObject = new Customer.CustomerOpeningBalanceDAL();
                //List<tblCustomerOpBal> OpBalsToDelete = db.tblCustomerOpBals.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                //foreach (tblCustomerOpBal Rec in OpBalsToDelete)
                //{
                //    res = OpBalDALObject.DeleteRecord(Rec, db);
                //    if(res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                //    {
                //        return res;
                //    }
                //}



                //// deleting all transactions
                //if (res.ExecutionResult == eExecutionResult.ValidationError)
                //{
                //    return res;
                //}

                // Deleting sms Log
                db.tblSMSLogs.RemoveRange(db.tblSMSLogs.Where(r => r.SendDateTime >= RecordToDelete.FinPeriodFrom && r.SendDateTime <= RecordToDelete.FinPeriodTo));

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    res.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
                    res.Exception = ex;
                    while (res.Exception != null && res.Exception.Message == "An error occurred while updating the entries. See the inner exception for details.")
                    {
                        res.Exception = res.Exception.InnerException;
                    }

                    if (ex.GetType() == typeof(System.Data.Entity.Validation.DbEntityValidationException))
                    {
                        res.ValidationError = "dbEntity Validation Errors : \r\n\r\n";

                        System.Data.Entity.Validation.DbEntityValidationException ValidationException = (System.Data.Entity.Validation.DbEntityValidationException)ex;

                        foreach (System.Data.Entity.Validation.DbEntityValidationResult ValidRes in ValidationException.EntityValidationErrors)
                        {
                            foreach (System.Data.Entity.Validation.DbValidationError ValidError in ValidRes.ValidationErrors)
                            {
                                res.ValidationError += ValidError.PropertyName + " = " + ValidError.ErrorMessage + "\r\n";
                            }
                            res.ValidationError += "\r\n";
                        }

                        res.Exception = new Exception(res.ValidationError);
                    }
                }


                /// Financial Year record removed here but will be committed from where it was called.
                /// Remove Fin Period
                db.tblFinPeriods.Remove(RecordToDelete);
            }
            return res;
        }

        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            long? CompanyID = null;

            if (FilterParas != null)
            {
                if (FilterParas.Length >= 1)
                {
                    CompanyID = (long)FilterParas[0];
                }
            }
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblFinPeriods

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == CompanyID

                        orderby r.FinPeriodFrom descending

                        select new FinPeriodDashboardViewModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            FinPeriodID = r.FinPeriodID,
                            FinPeriodName = r.FinPeriodName,
                            FinPeriodFrom = r.FinPeriodFrom,
                            FinPeriodTo = r.FinPeriodTo,

                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : null),
                            EditedUserName = (reu != null ? reu.UserName : null),
                        }).ToList();
            }
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public FinPeriodViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblFinPeriods

                        where r.FinPeriodID == ID

                        select new FinPeriodViewModel()
                        {
                            FinPeriodID = r.FinPeriodID,
                            FinPeriodName = r.FinPeriodName,
                            FinPeriodFrom = r.FinPeriodFrom,
                            FinPeriodTo = r.FinPeriodTo,
                            CompanyID = r.CompanyID,

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
                var SaveModel = db.tblFinPeriods.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblFinPeriods.Attach(SaveModel);
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

        public List<FinPeriodLookupListModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblFinPeriods

                        where r.rstate != (byte)eRecordState.Deactivated

                        orderby r.FinPeriodFrom descending

                        select new FinPeriodLookupListModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            FinPeriodID = r.FinPeriodID,
                            FinPeriodName = r.FinPeriodName,
                            FinPeriodFrom = r.FinPeriodFrom,
                            FinPeriodTo = r.FinPeriodTo,
                        }).ToList();
            }
        }

        /// <summary>
        /// This method is shorting financial period according to companyID
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public List<FinPeriodLookupListModel> GetLookupList(long CompanyID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblFinPeriods

                        where r.CompanyID == CompanyID

                        orderby r.FinPeriodFrom descending

                        select new FinPeriodLookupListModel()
                        {
                            FinPeriodID = r.FinPeriodID,
                            FinPeriodName = r.FinPeriodName,
                            FinPeriodFrom = r.FinPeriodFrom,
                            FinPeriodTo = r.FinPeriodTo,
                        }).ToList();
            }
        }

        public FinPeriodDetailModel GetDetailModel(long FinPeriodID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblFinPeriod r = db.tblFinPeriods.FirstOrDefault(r1 => r1.FinPeriodID == FinPeriodID);
                if (r == null) return null;
                else
                {
                    return ConvertToDetailModel(r);
                }
            }
        }

        public static FinPeriodDetailModel GetFirstFinPeriod(long CompanyID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblFinPeriod r = db.tblFinPeriods.FirstOrDefault(r1 => r1.CompanyID == CompanyID);
                if (r == null) return null;
                else
                {
                    return ConvertToDetailModel(r);
                }
            }
        }

        public bool IsDuplicateRecord(string FinPeriodName, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(FinPeriodName, ID, db);
            }
        }

        public bool IsDuplicateRecord(string FinPeriodName, long ID, dbMarkerEntities db)
        {
            long CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
            FinPeriodName = FinPeriodName.ToUpper();

            return db.tblFinPeriods.Any(r => r.FinPeriodName.ToUpper() == FinPeriodName && r.FinPeriodID != ID && r.CompanyID == CompanyID);            
            //if (db.tblFinPeriods.FirstOrDefault(i => i.FinPeriodName == FinPeriodName && i.FinPeriodID != ID) != null)
            //{
            //    return true;
            //}
            //return false;
        }

        public FinPeriodDetailModel GetLatestFinPeriod(long CompanyID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblFinPeriod Ses = db.tblFinPeriods.Where(r => r.CompanyID == CompanyID).OrderByDescending(r => r.FinPeriodFrom).FirstOrDefault();
                if (Ses == null) return null;
                else
                {
                    return ConvertToDetailModel(Ses);
                }
            }
        }

        public FinPeriodDetailModel GetPreviousFinPeriod(long CompanyID, DateTime FinPerFrom)
        {
            FinPerFrom = FinPerFrom.Date;
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblFinPeriod Ses = db.tblFinPeriods.Where(r => r.CompanyID == CompanyID && r.FinPeriodTo < FinPerFrom).OrderByDescending(r => r.FinPeriodFrom).FirstOrDefault();
                if (Ses == null) return null;
                else
                {
                    return ConvertToDetailModel(Ses);
                }
            }
        }

        public FinPeriodDetailModel GetNextFinPeriod(long CompanyID, DateTime FinPerTo)
        {
            FinPerTo = FinPerTo.Date;
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblFinPeriod Ses = db.tblFinPeriods.Where(r => r.CompanyID == CompanyID && r.FinPeriodFrom > FinPerTo).OrderBy(r => r.FinPeriodFrom).FirstOrDefault();
                if (Ses == null) return null;
                else
                {
                    return ConvertToDetailModel(Ses);
                }
            }
        }

        public static FinPeriodDetailModel ConvertToDetailModel(tblFinPeriod Ses)
        {
            return new FinPeriodDetailModel()
            {
                FinPeriodID = Ses.FinPeriodID,
                FinPeriodName = Ses.FinPeriodName,
                FinPeriodFrom = Ses.FinPeriodFrom,
                FinPeriodTo = Ses.FinPeriodTo,
                CompanyID = Ses.CompanyID
            };

        }

        public static int FinPeriodsCount(long CompanyID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return db.tblFinPeriods.Count(r => r.CompanyID == CompanyID);
            }
        }

        public async Task<List<CustomerClosingBalanceViewModel>> GetCustomerClosingBalance(long CompanyID, long FinPeriodID)
        {
            return await Task.Run<List<CustomerClosingBalanceViewModel>>(() =>
            {
                using (dbMarkerEntities db = new dbMarkerEntities())
                {
                    var opbal = from ob in db.tblCustomerOpBals
                                where ob.CompanyID == CompanyID &&
                                ob.FinPeriodID == FinPeriodID
                                select new { CustomerID = ob.CustomerID, Amt = ob.OpBalAmt };

                    var sale = from s in db.tblSaleInvoices
                               where s.CompanyID == CompanyID &&
                               s.FinPeriodID == FinPeriodID
                               group s by s.CustomerAccountID into gs
                               let Amt = gs.Sum(gr => (decimal?)gr.NetAmt) ?? 0
                               select new { CustomerID = gs.Key, Amt = Amt };

                    var salereturn = from s in db.tblSaleReturns
                                     where s.CompanyID == CompanyID &&
                                     s.FinPeriodID == FinPeriodID
                                     group s by s.CustomerAccountID into gs
                                     let Amt = gs.Sum(gr => (decimal?)gr.NetAmt) ?? 0
                                     select new { CustomerID = gs.Key, Amt = -Amt };

                    var purchase = from s in db.tblPurchaseBills
                                   where s.CompanyID == CompanyID &&
                                   s.FinPeriodID == FinPeriodID
                                   group s by s.CustomerAccountID into gs
                                   let Amt = gs.Sum(gr => (decimal?)gr.NetAmt) ?? 0
                                   select new { CustomerID = gs.Key, Amt = -Amt };

                    var purchaseReturn = from s in db.tblPurchaseReturns
                                         where s.CompanyID == CompanyID &&
                                         s.FinPeriodID == FinPeriodID
                                         group s by s.CustomerAccountID into gs
                                         let Amt = gs.Sum(gr => (decimal?)gr.NetAmt) ?? 0
                                         select new { CustomerID = gs.Key, Amt = Amt };

                    var Reciepts = from s in db.tblReceipts
                                   where s.CompanyID == CompanyID &&
                                   s.FinPeriodID == FinPeriodID
                                   //group s by s.CustomerID into gs
                                   group s by s.AccountID into gs
                                   let Amt = gs.Sum(gr => (decimal?)gr.Amount) ?? 0
                                   select new { CustomerID = gs.Key, Amt = -Amt };

                    var Payments = from s in db.tblPayments
                                   where s.CompanyID == CompanyID &&
                                   s.FinPeriodID == FinPeriodID
                                   //group s by s.CustomerID into gs
                                   group s by s.AccountID into gs
                                   let Amt = gs.Sum(gr => (decimal?)gr.Amount) ?? 0
                                   select new { CustomerID = gs.Key, Amt = Amt };

                    var allTransactions = opbal.Concat(sale).Concat(salereturn).Concat(purchase).Concat(purchaseReturn).Concat(Reciepts).Concat(Payments);

                    var summed = from s in allTransactions
                                 group s by s.CustomerID into gs
                                 let Amt = gs.Sum(gr => (decimal?)gr.Amt) ?? 0
                                 select new { CustomerID = gs.Key, Amt = Amt };

                    var res = from customer in db.tblCustomers
                              join joinCity in db.tblCities on customer.CityID equals joinCity.CityID into gCity
                              from City in gCity.DefaultIfEmpty()
                              join joinstate in db.tblStates on City.StateID equals joinstate.StateID into gstate
                              from state in gstate.DefaultIfEmpty()
                              join joincountry in db.tblCountries on state.CountryID equals joincountry.CountryID into gcountry
                              from country in gcountry.DefaultIfEmpty()
                              join joinsum in summed on customer.CustomerID equals joinsum.CustomerID into gsum
                              from sum in gsum.DefaultIfEmpty()
                              orderby customer.CustomerNo
                              select
                               new CustomerClosingBalanceViewModel()
                               {
                                   CustomerID = customer.CustomerID,
                                   CustomerNo = customer.CustomerNo,
                                   CustomerName = customer.CustomerName,
                                   CompanyName = customer.CustomerCompanyName,
                                   Address = customer.Address,
                                   City = (City != null ? City.CityName : ""),
                                   MobileNo = customer.MobileNo,
                                   OpeningBalance = (sum != null ? sum.Amt : 0)
                               };

                    return res.ToList();
                }
            });
        }

        public decimal GetCustomerClosingBalance(long CustomerID, DateTime UptoDate, long CompanyID, long FinPeriodID)
        {
            UptoDate = UptoDate.Date.Add(new TimeSpan(23, 59, 59));

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var opbal = from ob in db.tblCustomerOpBals
                            where ob.CompanyID == CompanyID &&
                            ob.FinPeriodID == FinPeriodID &&
                            ob.CustomerID == CustomerID &&
                            ob.OpBalDate <= UptoDate
                            select new { CustomerID = ob.CustomerID, Amt = ob.OpBalAmt };

                var sale = from s in db.tblSaleInvoices
                           where s.CompanyID == CompanyID &&
                           s.FinPeriodID == FinPeriodID &&
                           s.CustomerAccountID == CustomerID &&
                           s.SaleInvoiceDate <= UptoDate
                           group s by s.CustomerAccountID into gs
                           let Amt = gs.Sum(gr => (decimal?)gr.NetAmt) ?? 0
                           select new { CustomerID = gs.Key, Amt = Amt };

                var salereturn = from s in db.tblSaleReturns
                                 where s.CompanyID == CompanyID &&
                                 s.FinPeriodID == FinPeriodID &&
                                 s.CustomerAccountID == CustomerID &&
                                 s.SaleReturnDate <= UptoDate
                                 group s by s.CustomerAccountID into gs
                                 let Amt = gs.Sum(gr => (decimal?)gr.NetAmt) ?? 0
                                 select new { CustomerID = gs.Key, Amt = -Amt };

                var purchase = from s in db.tblPurchaseBills
                               where s.CompanyID == CompanyID &&
                               s.FinPeriodID == FinPeriodID &&
                               s.CustomerAccountID == CustomerID &&
                               s.PurchaseBillDate <= UptoDate
                               group s by s.CustomerAccountID into gs
                               let Amt = gs.Sum(gr => (decimal?)gr.NetAmt) ?? 0
                               select new { CustomerID = gs.Key, Amt = -Amt };

                var purchaseReturn = from s in db.tblPurchaseReturns
                                     where s.CompanyID == CompanyID &&
                                     s.FinPeriodID == FinPeriodID &&
                                     s.CustomerAccountID == CustomerID &&
                                     s.PurchaseReturnDate <= UptoDate
                                     group s by s.CustomerAccountID into gs
                                     let Amt = gs.Sum(gr => (decimal?)gr.NetAmt) ?? 0
                                     select new { CustomerID = gs.Key, Amt = Amt };

                var Reciepts = from s in db.tblReceipts
                               where s.CompanyID == CompanyID &&
                               s.FinPeriodID == FinPeriodID &&
                               //s.CustomerID == CustomerID &&
                               s.AccountID == CustomerID &&
                               s.ReceiptDate <= UptoDate
                               //group s by s.CustomerID into gs
                               group s by s.AccountID into gs
                               let Amt = gs.Sum(gr => (decimal?)gr.Amount) ?? 0
                               select new { CustomerID = gs.Key, Amt = -Amt };

                var Payments = from s in db.tblPayments
                               where s.CompanyID == CompanyID &&
                               s.FinPeriodID == FinPeriodID &&
                               //s.CustomerID == CustomerID &&
                               s.AccountID == CustomerID &&
                               s.PaymentDate <= UptoDate
                               //group s by s.CustomerID into gs
                               group s by s.AccountID into gs
                               let Amt = gs.Sum(gr => (decimal?)gr.Amount) ?? 0
                               select new { CustomerID = gs.Key, Amt = Amt };

                var allTransactions = opbal.Concat(sale).Concat(salereturn).Concat(purchase).Concat(purchaseReturn).Concat(Reciepts).Concat(Payments);

                var summed = from s in allTransactions
                             where s.CustomerID == CustomerID
                             group s by s.CustomerID into gs
                             let Amt = gs.Sum(gr => (decimal?)gr.Amt) ?? 0
                             select new { CustomerID = gs.Key, Amt = Amt };

                return summed.Sum(r => (decimal?)r.Amt) ?? 0;
                //var res = from customer in db.tblCustomers
                //          join joinCity in db.tblCities on customer.CityID equals joinCity.CityID into gCity
                //          from City in gCity.DefaultIfEmpty()
                //          join joinstate in db.tblStates on City.StateID equals joinstate.StateID into gstate
                //          from state in gstate.DefaultIfEmpty()
                //          join joincountry in db.tblCountries on state.CountryID equals joincountry.CountryID into gcountry
                //          from country in gcountry.DefaultIfEmpty()
                //          join joinsum in summed on customer.CustomerID equals joinsum.CustomerID into gsum
                //          from sum in gsum.DefaultIfEmpty()
                //          orderby customer.CustomerNo
                //          select
                //           new CustomerClosingBalanceViewModel()
                //           {
                //               CustomerID = customer.CustomerID,
                //               CustomerNo = customer.CustomerNo,
                //               CustomerName = customer.CustomerName,
                //               CompanyName = customer.CustomerCompanyName,
                //               Address = customer.Address,
                //               City = (City != null ? City.CityName : ""),
                //               MobileNo = customer.MobileNo,
                //               OpeningBalance = (sum != null ? sum.Amt : 0)
                //           };

                //return res.sum()
            }
        }

        public async Task<List<ProductOpeningStockViewModel>> GetProductOpeningBalance(long CompanyID, long FinPeriodID)
        {
            return await Task.Run<List<ProductOpeningStockViewModel>>(() =>
            {
                using (dbMarkerEntities db = new dbMarkerEntities())
                {
                    var res = from pd in db.tblStockPDetails
                              join st in db.tblStocks on pd.StockVoucherID equals st.VoucherID
                              where st.CompanyID == CompanyID && st.FinPeriodID == FinPeriodID
                              group pd by new { pd.ProductID } into gpd
                              let Stock = gpd.Sum(gr => (decimal?)gr.Qty) ?? 0
                              let Rate = gpd.Average(gr => (decimal?)gr.Rate) ?? 0
                              select new
                              {
                                  ProductID = gpd.Key.ProductID,
                                  Stock = Stock,
                                  Rate = Rate
                              };
                    var res1 = from r in res
                               join p in db.tblProducts on r.ProductID equals p.ProductID
                               join u in db.tblUnits on p.UnitID equals u.UnitID
                               orderby p.PCode
                               select new ProductOpeningStockViewModel()
                               {
                                   ProductID = p.ProductID,
                                   ProductCode = p.PCode,
                                   ProductName = p.ProductName,
                                   UnitName = u.UnitName,
                                   Stock = r.Stock,
                                   Rate = r.Rate
                               };
                    return res1.ToList();
                }
            });
        }


        public static bool IsDateRangeInMultipleFinancialPeriod(DateTime DateFrom, DateTime DateTo)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (db.tblFinPeriods.Where(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.CompanyID
                                      && (r.FinPeriodFrom <= DateFrom || (r.FinPeriodFrom <= DateTo))
                                       && (r.FinPeriodTo == null || (r.FinPeriodTo >= DateFrom || r.FinPeriodTo >= DateTo))).Count() > 1);
            }
        }

    }
}
