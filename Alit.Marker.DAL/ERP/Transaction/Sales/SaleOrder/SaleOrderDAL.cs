using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Customer;
using Alit.Marker.Model.ERP.Transaction.Sales.SaleOrder;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Transaction.Sales.SaleOrder
{
    public class SaleOrderDAL : IDashboardDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((SaleOrderViewModel)ViewModel);
        }

        public SavingResult SaveRecord(SaleOrderViewModel ViewModel)
        {
            SavingResult res = new SavingResult();
            if (ViewModel.SaleOrderNo == 0)
            {
                res.ValidationError = "Please enter Order#.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.ProductDetails == null || ViewModel.ProductDetails.Count == 0)
            {
                res.ValidationError = "Please enter Product.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.SaleOrderNo, ViewModel.SaleOrderID, db,
                    (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleOrderNoPrefix ? (long?)ViewModel.SaleOrderNoPrefixID : null), ViewModel.SaleOrderDate))
                {
                    long OldVNo = ViewModel.SaleOrderNo;
                    ViewModel.SaleOrderNo = GenerateSaleOrderNo(ViewModel.SaleOrderNoPrefixID, ViewModel.SaleOrderDate);
                    res.MessageAfterSave = string.Format("New number {0} has been generated, because {1} was already exists.", ViewModel.SaleOrderNo.ToString(), OldVNo.ToString());
                }
                else if (ViewModel.SaleOrderID != 0 && ViewModel.SaleInvoiceID != null && ViewModel.SaleInvoiceID != 0)
                {
                    var resSaleInv = (from si in db.tblSaleInvoices
                                      join p in db.tblSaleInvoiceNoPrefixes on si.SaleInvoiceNoPrefixID equals p.SaleInvoiceNoPrefixID
                                      //join c in db.tblCustomers on si.CustomerID equals c.CustomerID
                                      join c in db.tblAccounts on si.CustomerAccountID equals c.AccountID
                                      where si.SaleInvoiceID == ViewModel.SaleInvoiceID
                                      select new
                                      {
                                          Prefix = p.PrefixName,
                                          SaleInvoiceNo = si.SaleInvoiceNo,
                                          SaleInvoiceDate = si.SaleInvoiceDate,
                                          //CustomerName = c.CustomerName
                                          CustomerName = c.AccountName
                                      }).FirstOrDefault();

                    if (resSaleInv != null)
                    {
                        res.ValidationError = String.Format("Can not save. Selected order is already engaged in Invoice# {0}/{1}, dated {2} for {3}",
                            resSaleInv.Prefix, resSaleInv.SaleInvoiceNo.ToString(), resSaleInv.SaleInvoiceDate.ToShortDateString(), resSaleInv.CustomerName);
                    }
                    else
                    {
                        res.ValidationError = "Can not save. Selected order is already engaged in an invoice.";
                    }
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                //--------------------------------------------------
                tblSaleOrder SaveModel = null;
                if (ViewModel.SaleOrderID == 0) // New Entry
                {
                    SaveModel = new tblSaleOrder();
                    db.tblSaleOrders.Add(SaveModel);
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                }
                else
                {
                    SaveModel = db.tblSaleOrders.Find(ViewModel.SaleOrderID);
                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;

                    db.tblSaleOrders.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    db.tblSaleOrderProductDetails.RemoveRange(db.tblSaleOrderProductDetails.Where(r => r.SaleOrderID == ViewModel.SaleOrderID));
                    db.tblSaleOrderAdditionals.RemoveRange(db.tblSaleOrderAdditionals.Where(r => r.SaleOrderID == ViewModel.SaleOrderID));
                }

                SaveModel.SaleOrderDate = ViewModel.SaleOrderDate;
                SaveModel.SaleOrderNoPrefixID = ViewModel.SaleOrderNoPrefixID;
                SaveModel.SaleOrderNo = ViewModel.SaleOrderNo;
                SaveModel.CustomerID = ViewModel.CustomerID;
                SaveModel.PriceListID = ViewModel.PriceListID;
                SaveModel.GrossAmt = ViewModel.ProductDetails.Sum(r => (decimal?)r.GAmt) ?? 0;
                SaveModel.NetAmt = ViewModel.NetAmt;
                SaveModel.OrderMemo = ViewModel.OrderMemo;
                SaveModel.RoundOffAmt = ViewModel.RoundOffAmt;
                SaveModel.RoundOffAddLessID = ViewModel.RoundOffAddLessID;

                //------------------------------------------------------
                int Sno = 0;
                db.tblSaleOrderProductDetails.AddRange(ViewModel.ProductDetails.Select(r => new tblSaleOrderProductDetail()
                {
                    tblSaleOrder = SaveModel,
                    SNo = Sno++,
                    ProductID = r.ProductID,
                    Descr = r.ProductDescr,
                    UnitID = r.UnitID,
                    Quan = r.Quantity,
                    Rate = r.Rate,
                    DiscPerc = r.DiscPerc,
                    DiscAmt = r.DiscAmt,
                    GAmt = r.GAmt,
                    NAmt = r.NetAmt,

                    Tax1ID = r.Tax1ID,
                    Tax1Perc = r.Tax1Perc,
                    Tax1Amt = r.Tax1Amt,

                    Tax2ID = r.Tax2ID,
                    Tax2Perc = r.Tax2Perc,
                    Tax2Amt = r.Tax2Amt,

                    Tax3ID = r.Tax3ID,
                    Tax3Perc = r.Tax3Perc,
                    Tax3Amt = r.Tax3Amt,

                    CompanyID = SaveModel.CompanyID,
                    FinPeriodID = SaveModel.FinPeriodID,
                    rcuid = SaveModel.rcuid,
                    rcdt = SaveModel.rcdt,
                    redt = SaveModel.redt,
                    reuid = SaveModel.reuid,
                }));
                
                db.tblSaleOrderAdditionals.AddRange(ViewModel.AdditionalItems.Select(r => new tblSaleOrderAdditional()
                {
                    tblSaleOrder = SaveModel,

                    AdditionalItemID = r.AdditionalItemID,
                    Descr = r.ItemDescr,
                    Amt = r.Amt,
                    AmtCalculatedOn = r.CalculatedOnAmt,
                    CalculateOnID = (int)r.CalculateOn,
                    IsInclusive = r.IsInclusive,
                    ItemNature = (int)r.ItemNature,
                    Perc = r.Perc,
                    RecordType = (int)r.RecordType,
                    UpdatedAmt = r.UpdatedAmt,

                    rcuid = SaveModel.rcuid,
                    rcdt = SaveModel.rcdt,
                    redt = SaveModel.redt,
                    reuid = SaveModel.reuid,

                    CompanyID = SaveModel.CompanyID,
                    FinPeriodID = SaveModel.FinPeriodID,
                }));
                
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = ViewModel.SaleOrderID;
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
            using (dbMarkerEntities db = new dbMarkerEntities())
            {

                tblSaleOrder SaleOrder = db.tblSaleOrders.Find(DeleteID);

                if (SaleOrder != null && SaleOrder.SaleInvoiceID != null)
                {
                    tblSaleInvoice SaleInvoice = db.tblSaleInvoices.Find(SaleOrder.SaleInvoiceID);
                    if (SaleInvoice != null)
                    {
                        Result.ValidationMessage = "Invoice already generated for selected order. Invoice # " + SaleInvoice.SaleInvoiceNo.ToString() + ", dated " + SaleInvoice.SaleInvoiceDate.ToShortDateString();
                    }
                }
            }
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
                    res.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
                    res.Exception = ex;
                }

            }
            return res;
        }

        public SavingResult DeleteRecord(long DeleteID, dbMarkerEntities db)
        {
            SavingResult res = null;//new SavingResult();

            if (DeleteID != 0)
            {
                tblSaleOrder RecordToDelete = db.tblSaleOrders.FirstOrDefault(r => r.SaleOrderID == DeleteID);

                res = DeleteRecord(RecordToDelete, db);
            }
            else
            {
                res = new SavingResult();
            }
            return res;
        }

        public SavingResult DeleteRecord(tblSaleOrder RecordToDelete, dbMarkerEntities db)
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
                //if (RecordToDelete.StockVoucherID != null)
                //{
                //    tblStock StockRecord = db.tblStocks.FirstOrDefault(r => r.VoucherID == RecordToDelete.StockVoucherID);
                //    db.tblStockPDetails.RemoveRange(db.tblStockPDetails.Where(r => r.StockVoucherID == StockRecord.VoucherID));
                //    db.tblStocks.Remove(StockRecord);
                //}
                //RecordToDelete.tblCustomer.BalanceAmt -= RecordToDelete.NetAmt + RecordToDelete.AdvanceAmt ?? 0;
                db.tblSaleOrderProductDetails.RemoveRange(RecordToDelete.tblSaleOrderProductDetails);
                db.tblSaleOrderAdditionals.RemoveRange(RecordToDelete.tblSaleOrderAdditionals);

                /// Receipt 
                //if (RecordToDelete.AdvanceRecieptID != null)
                //{
                //    db.tblReceipts.Remove(RecordToDelete.tblReceipt);
                //}
                db.tblSaleOrders.Remove(RecordToDelete);

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

                List<SaleOrderDashboardViewModel> List =
                    (from r in db.tblSaleOrders

                     join jc in db.tblCustomers on r.CustomerID equals jc.CustomerID into gc
                     from c in gc.DefaultIfEmpty()

                     join jcity in db.tblCities on c.CityID equals jcity.CityID into gcity
                     from city in gcity.DefaultIfEmpty()

                     join jsonp in db.tblSaleOrderNoPrefixes on r.SaleOrderNoPrefixID equals jsonp.SaleOrderNoPrefixID into gsonp
                     from sonp in gsonp.DefaultIfEmpty()

                     join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                     from rcu in grcu.DefaultIfEmpty()

                     join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                     from reu in greu.DefaultIfEmpty()

                     where r.CompanyID == CurrentCompanyID && r.FinPeriodID == CurrentFinPerID

                     orderby r.SaleOrderDate descending, r.SaleOrderNo descending

                     select new SaleOrderDashboardViewModel()
                     {
                         SaleOrderID = r.SaleOrderID,

                         SaleOrderNoPrefixName = (sonp != null ? sonp.PrefixName : null),
                         SaleOrderNo = r.SaleOrderNo,

                         OrderDate = r.SaleOrderDate,
                         CustomerID = r.CustomerID,

                         CustomerName = (c != null ? c.CustomerName : null),
                         CustomerNameTitle = (c != null ? c.NameTitle : null),
                         CustomerAddress = (c != null ? c.Address : null),
                         CustomerCityName = (city != null ? city.CityName : null),

                         NetAmt = r.NetAmt,
                         OrderMemo = r.OrderMemo,
                         IsCompleted = r.SaleInvoiceID != null,

                         RecordState = (eRecordState)r.rstate,
                         CreatedDateTime = r.rcdt,
                         EditedDateTime = r.redt,
                         CreatedUserID = r.rcuid,
                         EditedUserID = r.reuid,
                         CreatedUserName = (rcu != null ? rcu.UserName : null),
                         EditedUserName = (reu != null ? reu.UserName : null),

                     }).ToList();

                return List;
            }
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public SaleOrderViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblSaleOrders
                        where r.SaleOrderID == ID
                        select new SaleOrderViewModel()
                        {
                            SaleOrderID = r.SaleOrderID,
                            SaleOrderDate = r.SaleOrderDate,
                            SaleOrderNoPrefixID = r.SaleOrderNoPrefixID,
                            SaleOrderNo = r.SaleOrderNo,
                            CustomerID = r.CustomerID,
                            PriceListID = r.PriceListID,
                            NetAmt = r.NetAmt,
                            OrderMemo = r.OrderMemo,
                            RoundOffAmt = r.RoundOffAmt ?? 0,
                            RoundOffAddLessID = r.RoundOffAddLessID,
                            IsCompleted = (r.SaleInvoiceID != null),
                            SaleInvoiceID = r.SaleInvoiceID,
                            ProductDetails = (from pd in db.tblSaleOrderProductDetails

                                              join jp in db.tblProducts on pd.ProductID equals jp.ProductID into gp
                                              from p in gp.DefaultIfEmpty()

                                              where pd.SaleOrderID == r.SaleOrderID
                                              select new SaleOrderProductDetailViewModel()
                                              {
                                                  SaleOrderProductDetailID = pd.SaleOrderProductDetailID,
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

                            AdditionalItems = (from al in db.tblSaleOrderAdditionals

                                               join jalm in db.tblAdditionalItemMasters on al.AdditionalItemID equals jalm.AdditionaItemID into galm
                                               from alm in galm.DefaultIfEmpty()

                                               where al.SaleOrderID == r.SaleOrderID
                                               select new SaleOrderAdditionalsViewModel()
                                               {
                                                   AdditionalsID = al.SaleOrderAdditionalsID,
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
                var SaveModel = db.tblSaleOrders.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblSaleOrders.Attach(SaveModel);
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
            long? CustomerID = null;
            bool PendingSaleOrderOnly = false;
            long? IncluseSaleOrderID = null;
            int Index = 0;

            if (FilterParas != null)
            {
                if (FilterParas.Count() >= (Index + 1) && FilterParas[Index] != null && FilterParas[Index] is long)
                {
                    CustomerID = (long)FilterParas[Index];
                }
                Index++;

                if (FilterParas.Count() >= (Index + 1) && FilterParas[Index] != null && FilterParas[Index] is bool)
                {
                    PendingSaleOrderOnly = (bool)FilterParas[Index];
                }
                Index++;

                if (FilterParas.Count() >= (Index + 1) && FilterParas[Index] != null && FilterParas[Index] is long)
                {
                    IncluseSaleOrderID = (long)FilterParas[Index];
                }
            }
            return GetLookupListFinal(CustomerID, PendingSaleOrderOnly, IncluseSaleOrderID);
        }

        public List<SaleOrderLookupListModel> GetLookupListFinal(long? CustomerID, bool PendingSaleOrderOnly, long? IncluseSaleOrderID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long CurrentCompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                long CurrentFinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;

                var res = (from r in db.tblSaleOrders

                           join jc in db.tblCustomers on r.CustomerID equals jc.CustomerID into gc
                           from c in gc.DefaultIfEmpty()

                           join jcity in db.tblCities on c.CityID equals jcity.CityID into gcity
                           from city in gcity.DefaultIfEmpty()

                           join jsonp in db.tblSaleOrderNoPrefixes on r.SaleOrderNoPrefixID equals jsonp.SaleOrderNoPrefixID into gsonp
                           from sonp in gsonp.DefaultIfEmpty()

                           where r.CompanyID == CurrentCompanyID
                                 && r.FinPeriodID == CurrentFinPerID
                                 && (CustomerID == null || r.CustomerID == CustomerID)
                                 && (!PendingSaleOrderOnly || r.SaleInvoiceID == null || r.SaleOrderID ==               IncluseSaleOrderID)
                                 && r.rstate != (byte)eRecordState.Deactivated

                           orderby r.SaleOrderDate descending, r.SaleOrderNo descending

                           select new SaleOrderLookupListModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               SaleOrderID = r.SaleOrderID,

                               SaleOrderNoPrefixName = (sonp != null ? sonp.PrefixName : null),
                               SaleOrderNo = r.SaleOrderNo,

                               OrderDate = r.SaleOrderDate,
                               CustomerID = r.CustomerID,

                               CustomerName = (c != null ? c.CustomerName : null),
                               CustomerNameTitle = (c != null ? c.NameTitle : null),
                               CustomerAddress = (c != null ? c.Address : null),
                               CustomerCityName = (city != null ? city.CityName : null),

                               NetAmt = r.NetAmt,
                           }).ToList();

                return res;
            }
        }

        public bool IsDuplicateRecord(long SaleOrderNo, long ID, long? PrefixID, DateTime? OrderDate)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(SaleOrderNo, ID, db, PrefixID, OrderDate);
            }
        }

        public bool IsDuplicateRecord(long SaleOrderNo, long ID, dbMarkerEntities db, long? PrefixID, DateTime? OrderDate)
        {
            string Series = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleOrderNoSeries;
            if (String.IsNullOrWhiteSpace(Series))
            {
                //if (db.tblSaleOrders.FirstOrDefault(i => i.SaleOrderNo == SaleOrderNo && i.SaleOrderID != ID && i.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID) != null)
                //{
                //    return true;
                //}
                return db.tblSaleOrders.Any(r => r.SaleOrderNo == SaleOrderNo 
                           && r.SaleOrderID != ID
                           && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID);
            }
            else
            {
                //return (db.tblSaleOrders.Where(r => r.SaleOrderNo == SaleOrderNo && r.SaleOrderID != ID && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID && (
                //    (!Series.Contains("Prefix") || r.SaleOrderNoPrefixID == PrefixID) &&
                //    (!Series.Contains("Date") || (OrderDate.HasValue && r.SaleOrderDate == OrderDate)) &&
                //    (!Series.Contains("Year") || (OrderDate.HasValue && r.SaleOrderDate.Year == OrderDate.Value.Year)) &&
                //    (!Series.Contains("MonthYear") || (OrderDate.HasValue && r.SaleOrderDate.Month == OrderDate.Value.Month && r.SaleOrderDate.Year == OrderDate.Value.Year))
                //    )
                //    ).FirstOrDefault() != null);

            return db.tblSaleOrders.Any(r => r.SaleOrderNo == SaleOrderNo && r.SaleOrderID != ID && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID && (
                    (!Series.Contains("Prefix") || r.SaleOrderNoPrefixID == PrefixID) &&
                    (!Series.Contains("Date") || (OrderDate.HasValue && r.SaleOrderDate == OrderDate)) &&
                    (!Series.Contains("Year") || (OrderDate.HasValue && r.SaleOrderDate.Year == OrderDate.Value.Year)) &&
                    (!Series.Contains("MonthYear") || (OrderDate.HasValue && r.SaleOrderDate.Month == OrderDate.Value.Month && r.SaleOrderDate.Year == OrderDate.Value.Year))
                    ));
            }
            //return false;
        }

        public long GenerateSaleOrderNo(long? PrefixID, DateTime? OrderDate)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                long? MaxInvNo = null;

                string Series = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleOrderNoSeries;

                if (String.IsNullOrWhiteSpace(Series))
                {
                    MaxInvNo = db.tblSaleOrders.Max(r => (long?)r.SaleOrderNo);
                }
                else
                {
                    MaxInvNo = db.tblSaleOrders.Where(r => r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID).Where(r => (!Series.Contains("Prefix") || r.SaleOrderNoPrefixID == PrefixID) &&
                        (!Series.Contains("Date") || (OrderDate.HasValue && r.SaleOrderDate == OrderDate)) &&
                        (!Series.Contains("Year") || (OrderDate.HasValue && r.SaleOrderDate.Year == OrderDate.Value.Year)) &&
                        (!Series.Contains("MonthYear") || (OrderDate.HasValue && r.SaleOrderDate.Month == OrderDate.Value.Month && r.SaleOrderDate.Year == OrderDate.Value.Year))
                        ).Max(r => (long?)r.SaleOrderNo);
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
    }
}