using Alit.Marker.DAL.City.City;
using Alit.Marker.DAL.Settings.ApplicationSettings;
using Alit.Marker.DAL.Settings.FinancialPeriod;
using Alit.Marker.DAL.Template;
using Alit.Marker.DAL.ERP.Masters.AdditionalItems;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Reports;
using Alit.Marker.Model.Settings.Compnay;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix;
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix;
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix;

namespace Alit.Marker.DAL.Settings.Compnay
{
    public class CompanyDAL : IDashboardDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((CompanyViewModel)ViewModel);
        }

        public SavingResult SaveRecord(CompanyViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (String.IsNullOrWhiteSpace(ViewModel.CompanyName))
            {
                res.ValidationError = "Please enter Company Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (ViewModel.CityID == 0)
            {
                res.ValidationError = "Please select City.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (!String.IsNullOrWhiteSpace(ViewModel.EMailID) && Model.CommonFunctions.ValidateEmail(ViewModel.EMailID))
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please enter valid Email ID.";
                return res;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.CompanyName, ViewModel.CompanyID, db))
                {
                    res.ValidationError = "Can not accept duplicate Company Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                bool IsNewCompany = (ViewModel.CompanyID == 0);
                tblAdditionalItemMaster RoundOffItem = null;
                tblPriceList DefaultPriceList = null;
                tblCustomer CashCustomer = null;

                tblCompany SaveModel = null;
                if (ViewModel.CompanyID == 0) // New Entry
                {
                    SaveModel = new tblCompany();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblCompanies.Add(SaveModel);

                    db.tblFinPeriods.Add(new tblFinPeriod()
                    {
                        //FinPeriodName = SaveModel.BusinessStartedFrom.Date.Year.ToString() + "-*",
                        //FinPeriodFrom = SaveModel.BusinessStartedFrom.Date,
                        //tblCompany = SaveModel,
                        //rcdt = DateTime.Now

                        tblCompany = SaveModel,
                        FinPeriodName = ViewModel.BusinessStartedFrom.Date.Year.ToString() + "-*",
                        FinPeriodFrom = ViewModel.BusinessStartedFrom.Date,
                        rcdt = DateTime.Now
                    });

                    //-- Inserting new round off record for newly created company
                    RoundOffItem = new tblAdditionalItemMaster()
                    {
                        ItemName = "Round Off",
                        Nature = 1,
                        SystemRecord = 1,
                        ItemType = 0,
                        Perc = 0,
                        CalculatePerc = false,
                        CalculateOnID = 1,
                        IsInclusive = false,
                        DefaultRecord = false,
                        rcdt = DateTime.Now,
                        rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID,
                        tblCompany = SaveModel
                    };
                    db.tblAdditionalItemMasters.Add(RoundOffItem);

                    DefaultPriceList = new tblPriceList()
                    {
                        PriceListName = "Default",
                        PriceListShortName = "D",
                        rcdt = DateTime.Now,
                        rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID,
                        tblCompany = SaveModel
                    };
                    db.tblPriceLists.Add(DefaultPriceList);

                    int CustomerNo = (db.tblCustomers.Max(r => (int?)r.CustomerNo) ?? 0) + 1;
                    CashCustomer = new tblCustomer()
                    {
                        CustomerName = "Cash",
                        NameTitle = "",
                        //CityID = SaveModel.CityID,
                        CityID = ViewModel.CityID,
                        CustomerNo = CustomerNo,
                        rcdt = DateTime.Now,
                        rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID,
                        tblCompany = SaveModel,
                    };
                    db.tblCustomers.Add(CashCustomer);

                    // Copieng settings from existing company;
                    if (ViewModel.CopySettingsFromCompanyID != null)
                    {
                        var NewSettings = db.tblSettingsL1.Where(r => r.CompanyID == ViewModel.CopySettingsFromCompanyID);

                        if (NewSettings != null)
                        {
                            foreach (var rSetting in NewSettings)
                            {
                                var NewSetting = (tblSettingsL1)Model.CommonFunctions.CloneObject(rSetting);
                                NewSetting.tblCompany = SaveModel;
                                db.tblSettingsL1.Add(NewSetting);
                            }
                        }
                    }

                    //Stock Item Tax Categories
                    db.tblProductTaxCategories.Add(new tblProductTaxCategory()
                    {
                        tblCompany = SaveModel,
                        TaxIndex = 1,
                        ProductTaxCategoryName = "Tax 1",
                        Applicable = false,
                        IsInterstateSale = false,
                    });
                    db.tblProductTaxCategories.Add(new tblProductTaxCategory()
                    {
                        tblCompany = SaveModel,
                        TaxIndex = 2,
                        ProductTaxCategoryName = "Tax 2",
                        Applicable = false,
                        IsInterstateSale = false,
                    });
                    db.tblProductTaxCategories.Add(new tblProductTaxCategory()
                    {
                        tblCompany = SaveModel,
                        TaxIndex = 3,
                        ProductTaxCategoryName = "Tax 3",
                        Applicable = false,
                        IsInterstateSale = false,
                    });
                }
                else
                {
                    SaveModel = db.tblCompanies.Find(ViewModel.CompanyID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    db.tblCompanies.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                }

                SaveModel.CompanyName = ViewModel.CompanyName;
                SaveModel.Address = ViewModel.Address;
                SaveModel.CityID = ViewModel.CityID;
                SaveModel.PIN = ViewModel.PIN;
                SaveModel.Phone1 = ViewModel.Phone1;
                SaveModel.MobileNo1 = ViewModel.MobileNo1;
                SaveModel.EMailID = ViewModel.EMailID;
                SaveModel.Website = ViewModel.Website;
                SaveModel.DirectorName = ViewModel.DirectorName;
                SaveModel.PAN = ViewModel.PAN;
                SaveModel.GSTIN = ViewModel.GSTIN;
                SaveModel.ServiceTaxNo = ViewModel.ServiceTaxNo;
                SaveModel.LicenseName = ViewModel.LicenseName;
                SaveModel.LicenseNo = ViewModel.LicenseNo;
                SaveModel.Jurisdiction = ViewModel.Jurisdiction;
                SaveModel.BankName = ViewModel.BankName;
                SaveModel.BankCity = ViewModel.BankCity;
                SaveModel.BankBranch = ViewModel.BankBranch;
                SaveModel.BankIFSC = ViewModel.BankIFSC;
                SaveModel.BankAccountNo = ViewModel.BankAccountNo;
                SaveModel.BankAccountName = ViewModel.BankAccountName;
                SaveModel.BusinessStartedFrom = ViewModel.BusinessStartedFrom;

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.CompanyID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                    return res;
                }

                DAL.Settings.ApplicationSettings.SettingsDAL SettingDALObj = new SettingsDAL();
                if (RoundOffItem != null)
                {
                    // If completed successfully and new company created then move newly added round off item's id in setting
                    SettingDALObj.SaveSettingL1("RoundOffAddLessID", RoundOffItem.AdditionaItemID, SaveModel.CompanyID);
                    SettingDALObj.SaveSettingL1("ApplyRoundOff", true, SaveModel.CompanyID);
                }
                if (CashCustomer != null)
                {
                    // Default cash customer id
                    SettingDALObj.SaveSettingL1("SaleInvoiceDefaultCustomerID", CashCustomer.CustomerID, SaveModel.CompanyID);
                }
            }
            return res;
        }


        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            if (DeleteID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID)
            {
                Result.ValidationMessage = "Can not delete current logged in company. Please log in different company and try to delete.";
            }
            //using (dbMarkerEntities db = new dbMarkerEntities())
            //{

            //bool InState = db.tblCompanies.FirstOrDefault(r => r.CompanyID == DeleteID) != null;

            //if (InState)
            //{
            //    Result.ValidationMessage = "Country is selected in company";
            //}
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
                    tblCompany RecordToDelete = db.tblCompanies.FirstOrDefault(r => r.CompanyID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }

                    SavingResult DataDelRes = new SavingResult();

                    /// financial Period and all financial data
                    DAL.Settings.FinancialPeriod.FinPeriodDAL FinPeriodDALObj = new FinPeriodDAL();

                    List<tblFinPeriod> FinPeriodRecrods = db.tblFinPeriods.Where(r => r.CompanyID == DeleteID).ToList();
                    foreach (tblFinPeriod FinPer in FinPeriodRecrods)
                    {
                        DataDelRes = FinPeriodDALObj.DeleteRecord(FinPer, db);

                        if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                        {
                            return res;
                        }
                    }

                    /// Additional Item Master
                    AdditionalItemDAL AdditionalItemDALObj = new AdditionalItemDAL();
                    List<tblAdditionalItemMaster> AdditionalItems = db.tblAdditionalItemMasters.Where(r => r.CompanyID == DeleteID).ToList();
                    foreach (tblAdditionalItemMaster AddItem in AdditionalItems)
                    {
                        DataDelRes = AdditionalItemDALObj.DeleteRecord(AddItem, db);
                        if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                        {
                            return res;
                        }
                    }

                    // All grid report format user settings
                    db.tblGridLayouts.RemoveRange(db.tblGridLayouts.Where(r => r.CompanyID == DeleteID));

                    /// Customer 
                    DAL.Customer.CustomerDAL CustomerDALObj = new Customer.CustomerDAL();
                    List<tblCustomer> Customers = db.tblCustomers.Where(r => r.CompanyID == DeleteID).ToList();
                    foreach (tblCustomer Customer in Customers)
                    {
                        DataDelRes = CustomerDALObj.DeleteRecord(Customer, db);
                        if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                        {
                            return res;
                        }
                    }

                    /// Product 
                    DAL.Inventory.Masters.StockItem.StockItemDAL StockItemDALObj = new Inventory.Masters.StockItem.StockItemDAL();
                    List<tblProduct> Products = db.tblProducts.Where(r => r.CompanyID == DeleteID).ToList();
                    foreach (tblProduct DeletingRecord in Products)
                    {
                        DataDelRes = StockItemDALObj.DeleteRecord(DeletingRecord, db);
                        if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                        {
                            return res;
                        }
                    }

                    /// Price List Name Master
                    DAL.Inventory.Masters.Product.PriceListDAL PriceListDALObj = new Inventory.Masters.Product.PriceListDAL();
                    List<tblPriceList> PriceLists = db.tblPriceLists.Where(r => r.CompanyID == DeleteID).ToList();
                    foreach (tblPriceList DeletingRecord in PriceLists)
                    {
                        DataDelRes = PriceListDALObj.DeleteRecord(DeletingRecord, db);
                        if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                        {
                            return res;
                        }
                    }


                    /// Transport
                    DAL.ERP.Masters.Transport.TransportDAL TransportDALObj = new ERP.Masters.Transport.TransportDAL();
                    List<tblTransport> Transportes = db.tblTransports.Where(r => r.CompanyID == DeleteID).ToList();
                    foreach (tblTransport DeletingRecord in Transportes)
                    {
                        DataDelRes = TransportDALObj.DeleteRecord(DeletingRecord, db);
                        if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                        {
                            return res;
                        }
                    }

                    /// Purchase Return Prefix
                    DAL.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix.PurchaseReturnNoPrefixDAL PurchaseReturnNoPrefixDALObj = new ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix.PurchaseReturnNoPrefixDAL();
                    List<tblPurchaseReturnNoPrefix> PurchaseReturnNoPrefixes = db.tblPurchaseReturnNoPrefixes.Where(r => r.CompanyID == DeleteID).ToList();
                    foreach (tblPurchaseReturnNoPrefix DeletingRecord in PurchaseReturnNoPrefixes)
                    {
                        DataDelRes = PurchaseReturnNoPrefixDALObj.DeleteRecord(DeletingRecord, db);
                        if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                        {
                            return res;
                        }
                    }

                    /// Purchase Bill Prefix
                    DAL.ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo.PurchaseReceiptNoPrefixDAL PurchaseReceiptNoPrefixDALObj = new ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo.PurchaseReceiptNoPrefixDAL();
                    List<tblPurchaseReceiptNoPrefix> PurchaseReceiptNoPrefixes = db.tblPurchaseReceiptNoPrefixes.Where(r => r.CompanyID == DeleteID).ToList();
                    foreach (tblPurchaseReceiptNoPrefix DeletingRecord in PurchaseReceiptNoPrefixes)
                    {
                        DataDelRes = PurchaseReceiptNoPrefixDALObj.DeleteRecord(DeletingRecord, db);
                        if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                        {
                            return res;
                        }
                    }

                    /// Sale Order Prefix
                    SaleOrderNoPrefixDAL SaleOrderNoPrefixDALObj = new SaleOrderNoPrefixDAL();
                    List<tblSaleOrderNoPrefix> SaleOrderNoPrefixes = db.tblSaleOrderNoPrefixes.Where(r => r.CompanyID == DeleteID).ToList();
                    foreach (tblSaleOrderNoPrefix DeletingRecord in SaleOrderNoPrefixes)
                    {
                        DataDelRes = SaleOrderNoPrefixDALObj.DeleteRecord(DeletingRecord, db);
                        if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                        {
                            return res;
                        }
                    }


                    /// Sale Return Prefix
                    SaleReturnNoPrefixDAL SaleReturnNoPrefixDALObj = new SaleReturnNoPrefixDAL();
                    List<tblSaleReturnNoPrefix> SaleReturnNoPrefixes = db.tblSaleReturnNoPrefixes.Where(r => r.CompanyID == DeleteID).ToList();
                    foreach (tblSaleReturnNoPrefix DeletingRecord in SaleReturnNoPrefixes)
                    {
                        DataDelRes = SaleReturnNoPrefixDALObj.DeleteRecord(DeletingRecord, db);
                        if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                        {
                            return res;
                        }
                    }


                    /// Sale Invoice Prefix
                    SaleInvoiceNoPrefixDAL SaleInvoiceNoPrefixDALObj = new SaleInvoiceNoPrefixDAL();
                    List<tblSaleInvoiceNoPrefix> SaleInvoiceNoPrefixes = db.tblSaleInvoiceNoPrefixes.Where(r => r.CompanyID == DeleteID).ToList();
                    foreach (tblSaleInvoiceNoPrefix DeletingRecord in SaleInvoiceNoPrefixes)
                    {
                        DataDelRes = SaleInvoiceNoPrefixDALObj.DeleteRecord(DeletingRecord, db);
                        if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                        {
                            return res;
                        }
                    }

                    /// Deleting settings for the company
                    db.tblSettingsL1.RemoveRange(db.tblSettingsL1.Where(r => r.CompanyID == DeleteID));



                    try
                    {
                        db.SaveChanges();
                        res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    }
                    catch (Exception ex)
                    {
                        CommonFunctions.GetFinalError(res, ex);
                        return res;
                    }



                    /// Company Record
                    db.tblCompanies.Remove(RecordToDelete);

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
                return (from r in db.tblCompanies

                        join joinrci in db.tblCities on r.CityID equals joinrci.CityID into grci
                        from rci in grci.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        orderby r.CompanyName

                        select new CompanyDashboardViewModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            CompanyID = r.CompanyID,
                            CompanyName = r.CompanyName,
                            City = (rci != null ? rci.CityName : null),
                            Address = r.Address,

                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : null),
                            EditedUserName = (reu != null ? reu.UserName : null),

                        }).ToList(); ;
            }
        }


        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public CompanyViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblCompanies

                        where r.CompanyID == ID

                        select new CompanyViewModel()
                        {
                            CompanyID = r.CompanyID,
                            CompanyName = r.CompanyName,
                            Address = r.Address,
                            CityID = r.CityID,
                            PIN = r.PIN,
                            Phone1 = r.Phone1,
                            MobileNo1 = r.MobileNo1,
                            EMailID = r.EMailID,
                            Website = r.Website,
                            DirectorName = r.DirectorName,
                            PAN = r.PAN,
                            GSTIN = r.GSTIN,
                            ServiceTaxNo = r.ServiceTaxNo,
                            LicenseName = r.LicenseName,
                            LicenseNo = r.LicenseNo,
                            Jurisdiction = r.Jurisdiction,
                            BankName = r.BankName,
                            BankCity = r.BankCity,
                            BankBranch = r.BankBranch,
                            BankIFSC = r.BankIFSC,
                            BankAccountNo = r.BankAccountNo,
                            BankAccountName = r.BankAccountName,
                            BusinessStartedFrom = r.BusinessStartedFrom,
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
                var SaveModel = db.tblCompanies.Find(ID);

                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblCompanies.Attach(SaveModel);
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

        public CompanyDetailViewModel GetCompanyDetail(long CompanyID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblCompany r = db.tblCompanies.FirstOrDefault(r1 => r1.CompanyID == CompanyID);
                if (r == null)
                {
                    return null;
                }
                else
                {
                    return ConvertToDetailViewModel(r);
                }
            }
        }


        public static CompanyDetailViewModel GetFirstCompany()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblCompany r = db.tblCompanies.FirstOrDefault();
                if (r == null)
                {
                    return null;
                }
                else
                {
                    return ConvertToDetailViewModel(r);
                }
            }
        }


        public static CompanyDetailViewModel ConvertToDetailViewModel(tblCompany r)
        {
            return new CompanyDetailViewModel()
            {
                CompanyID = r.CompanyID,
                CompanyName = r.CompanyName,
                Address = r.Address,
                CityID = r.CityID,
                PIN = r.PIN,
                Phone1 = r.Phone1,
                MobileNo1 = r.MobileNo1,
                EMailID = r.EMailID,
                Website = r.Website,
                PAN = r.PAN,
                GSTIN = r.GSTIN,
                LicenseName = r.LicenseName,
                LicenseNo = r.LicenseNo,
                Jurisdiction = r.Jurisdiction,
                BusinessStartedFrom = r.BusinessStartedFrom,
                DirectorName = r.DirectorName,
                ServiceTaxNo = r.ServiceTaxNo,
                BankName = r.BankName,
                BankCity = r.BankCity,
                BankBranch = r.BankBranch,
                BankIFSC = r.BankIFSC,
                BankAccountNo = r.BankAccountNo,
                BankAccountName = r.BankAccountName,
                City = CityDAL.ConvertToDetailViewModel(r.tblCity)
            };
        }


        public static Model.Reports.CompanyDetailReportModel GetCompanyDetailReportModel(long CompanyID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblCompany r = db.tblCompanies.FirstOrDefault(r1 => r1.CompanyID == CompanyID);
                if (r == null)
                {
                    return null;
                }
                else
                {
                    return new CompanyDetailReportModel()
                    {
                        CompanyID = r.CompanyID,
                        CompanyName = r.CompanyName,
                        Address = r.Address,
                        CityID = r.CityID,
                        PIN = r.PIN,
                        Phone1 = r.Phone1,
                        MobileNo1 = r.MobileNo1,
                        EMailID = r.EMailID,
                        Website = r.Website,
                        PAN = r.PAN,
                        GSTIN = r.GSTIN,
                        LicenseName = r.LicenseName,
                        LicenseNo = r.LicenseNo,
                        Jurisdiction = r.Jurisdiction,
                        BusinessStartedFrom = r.BusinessStartedFrom,
                        DirectorName = r.DirectorName,
                        ServiceTaxNo = r.ServiceTaxNo,
                        BankName = r.BankName,
                        BankCity = r.BankCity,
                        BankBranch = r.BankBranch,
                        BankIFSC = r.BankIFSC,
                        BankAccountNo = r.BankAccountNo,
                        BankAccountName = r.BankAccountName,
                        CityName = r.tblCity.CityName,
                        StateName = r.tblCity.tblState.StateName,
                        StateNameShort = r.tblCity.tblState.StateShortName ?? r.tblCity.tblState.StateName,
                        CountryName = r.tblCity.tblState.tblCountry.CountryName,
                        StateGSTCode = r.tblCity.tblState.GSTCode ?? 0
                    };
                }
            }
        }

        public bool IsDuplicateRecord(string CompanyName, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(CompanyName, ID, db);
            }
        }

        public bool IsDuplicateRecord(string CompanyName, long ID, dbMarkerEntities db)
        {
            CompanyName = CompanyName.ToUpper();
            return db.tblCompanies.Any(r => r.CompanyName.ToUpper() == CompanyName && r.CompanyID != ID);
        }

        public static int CompanyCount()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return db.tblCompanies.Count();
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

        public List<CompanyLookupListModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblCompanies

                        where r.rstate != (byte)eRecordState.Deactivated

                        orderby r.CompanyName

                        select new CompanyLookupListModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            CompanyID = r.CompanyID,
                            CompanyName = r.CompanyName,
                        }).ToList();
            }
        }
    }
}
