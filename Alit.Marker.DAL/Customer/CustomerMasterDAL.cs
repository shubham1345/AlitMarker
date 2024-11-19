using Alit.Marker.Model.Template;
using Alit.Marker.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;

namespace Alit.Marker.DAL.Customer
{
    public class CustomerDAL : IDashboardDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((CustomerViewModel)ViewModel);
        }

        public SavingResult SaveRecord(CustomerViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblCustomer SaveModel;
                res = SaveRecord(ViewModel, out SaveModel, db, res);

                if (!String.IsNullOrWhiteSpace(res.ValidationError))
                {
                    return res;
                }
                
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.CustomerID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public SavingResult SaveRecord(CustomerViewModel ViewModel, out tblCustomer SaveModel, dbMarkerEntities db, SavingResult res)
        {
            SaveModel = null;
            if (String.IsNullOrWhiteSpace(ViewModel.CustomerName))
            {
                res.ValidationError = "Please enter Customer Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (!String.IsNullOrWhiteSpace(ViewModel.EMailID) && Model.CommonFunctions.ValidateEmail(ViewModel.EMailID))
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please enter valid Email-ID.";
                return res;
            }
            if (!String.IsNullOrWhiteSpace(ViewModel.Website) && Model.CommonFunctions.ValidateWebSiteURL(ViewModel.Website))
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please enter valid Website URL.";
                return res;
            }
            if (ViewModel.CityID == 0)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please select City.";
                return res;
            }

            if (ViewModel.CustomerID == 0) // New Entry
            {
                SaveModel = new tblCustomer();
                SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;

                long PrevCustomerNo = SaveModel.CustomerNo;
                SaveModel.CustomerNo = GenerateNewCustomerNo(db);
                SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                if (PrevCustomerNo != SaveModel.CustomerNo)
                {
                    res.MessageAfterSave = "New generated Customer No. is " + SaveModel.CustomerNo.ToString();
                }

                SaveModel.rcdt = DateTime.Now;
                db.tblCustomers.Add(SaveModel);
            }
            else
            {
                SaveModel = db.tblCustomers.Find(ViewModel.CustomerID);

                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Record not found, Selected record may be deleted by another user over network. Please contact your admin.";
                    return res;
                }

                db.tblCustomers.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                
                SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.redt = DateTime.Now;

            }

            SaveModel.CustomerName = ViewModel.CustomerName;
            SaveModel.CustomerNo = ViewModel.CustomerNo;
            SaveModel.NameTitle = ViewModel.NameTitle;
            SaveModel.CustomerCompanyName = ViewModel.CompanyName;
            SaveModel.ContactPerson = ViewModel.ContactPerson;
            SaveModel.Address = ViewModel.Address;
            SaveModel.CityID = ViewModel.CityID;
            SaveModel.PostCode = ViewModel.PostCode;
            SaveModel.MobileNo = ViewModel.MobileNo;
            SaveModel.PhoneNo = ViewModel.PhoneNo;
            SaveModel.EMailID = ViewModel.EMailID;
            SaveModel.Website = ViewModel.Website;
            SaveModel.PAN = ViewModel.PAN;
            SaveModel.GSTNo = ViewModel.GSTNo;
            SaveModel.ServiceTaxNo = ViewModel.ServiceTaxNo;
            SaveModel.CreditLimit = ViewModel.CreditLimit;
            SaveModel.CreditDays = ViewModel.CreditDays;
            SaveModel.PriceListID = ViewModel.PriceListID;
            SaveModel.AllowSendSMS = ViewModel.AllowSendSMS;

            return res;
        }


        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                Result.ValidationMessage = "";

                if (db.tblCustomerOpBals.Any(r => r.CustomerID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Customer is selected in opening balance";
                }

                //if (db.tblSaleInvoices.Any(r => r.CustomerID == DeleteID))
                if (db.tblSaleInvoices.Any(r => r.CustomerAccountID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Customer is selected in some Invoices";
                }

                if (db.tblSaleOrders.Any(r => r.CustomerID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Customer is selected in some Orders";
                }

                if (db.tblSaleReturns.Any(r => r.CustomerAccountID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Customer is selected in some Sale Returns";
                }

                if (db.tblPurchaseBills.Any(r => r.CustomerAccountID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Customer is selected in some Purchase Invoices";
                }

                if (db.tblPurchaseReturns.Any(r => r.CustomerAccountID == DeleteID))
                {
                    Result.ValidationMessage += (Result.ValidationMessage != "" ? "\r\n" : "") + "Customer is selected in some Purchase Returns";
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
            SavingResult res = null;//new SavingResult();

            if (DeleteID != 0)
            {
                tblCustomer RecordToDelete = db.tblCustomers.FirstOrDefault(r => r.CustomerID == DeleteID);
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

        public SavingResult DeleteRecord(tblCustomer RecordToDelete, dbMarkerEntities db)
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
                db.tblCustomerBalances.RemoveRange(db.tblCustomerBalances.Where(r => r.CustomerID == RecordToDelete.CustomerID));
                db.tblCustomers.Remove(RecordToDelete);
            }
            return res;
        }


        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from customer in db.tblCustomers

                        join jCity in db.tblCities on customer.CityID equals jCity.CityID into gCity
                        from City in gCity.DefaultIfEmpty()

                        join jstate in db.tblStates on City.StateID equals jstate.StateID into gstate
                        from state in gstate.DefaultIfEmpty()

                        join jcountry in db.tblCountries on state.CountryID equals jcountry.CountryID into gcountry
                        from country in gcountry.DefaultIfEmpty()

                        join jopb in db.tblCustomerOpBals on
                        new
                        {
                            customer.CustomerID,
                            Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                            Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                        }
                        equals new { jopb.CustomerID, jopb.CompanyID, jopb.FinPeriodID } into gopb
                        from opb in gopb.DefaultIfEmpty()

                        join joinbalance in db.tblCustomerBalances on
                        new
                        {
                            customer.CustomerID,
                            Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                            Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                        }
                        equals
                        new
                        {
                            joinbalance.CustomerID,
                            joinbalance.CompanyID,
                            joinbalance.FinPeriodID
                        } into grbalance
                        from balance in grbalance.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on customer.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on customer.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where customer.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        orderby customer.CustomerName
                        select
                     new CustomerDashboardViewModel()
                     {
                         CustomerID = customer.CustomerID,
                         CustomerNo = customer.CustomerNo,
                         CustomerNameTitle = customer.NameTitle,
                         CustomerName = customer.CustomerName,
                         CompanyName = customer.CustomerCompanyName,
                         Address = customer.Address,
                         City = (City != null ? City.CityName : ""),
                         State = (state != null ? state.StateName : ""),
                         Country = (country != null ? country.CountryName : ""),
                         MobileNo = customer.MobileNo,
                         ContactPerson = customer.ContactPerson,
                         PhoneNo = customer.PhoneNo,
                         EMailID = customer.EMailID,
                         PAN = customer.PAN,
                         GSTNo = customer.GSTNo,
                         BalanceAmt = (balance != null ? balance.Balance : 0),

                         OpeningBalanceID = (opb != null ? (long?)opb.OpBalID : null),
                         RecordState = (eRecordState)customer.rstate,
                         CreatedDateTime = customer.rcdt,
                         EditedDateTime = customer.redt,
                         CreatedUserID = customer.rcuid,
                         EditedUserID = customer.reuid,
                         CreatedUserName = (rcu != null ? rcu.UserName : ""),
                         EditedUserName = (reu != null ? reu.UserName : ""),

                     }).ToList();
            }
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public CustomerViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblCustomers
                        where r.CustomerID == ID
                        select new CustomerViewModel()
                        {
                            CustomerID = r.CustomerID,
                            CustomerName = r.CustomerName,
                            CustomerNo = r.CustomerNo,
                            NameTitle = r.NameTitle,
                            CompanyName = r.CustomerCompanyName,
                            ContactPerson = r.ContactPerson,
                            Address = r.Address,
                            CityID = r.CityID,
                            PostCode = r.PostCode,
                            MobileNo = r.MobileNo,
                            PhoneNo = r.PhoneNo,
                            EMailID = r.EMailID,
                            Website = r.Website,
                            PAN = r.PAN,
                            GSTNo = r.GSTNo,
                            ServiceTaxNo = r.ServiceTaxNo,
                            CreditLimit = r.CreditLimit,
                            CreditDays = (int)r.CreditDays,
                            PriceListID = r.PriceListID,
                            AllowSendSMS = r.AllowSendSMS ?? false,
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
                var SaveModel = db.tblCustomers.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblCustomers.Attach(SaveModel);
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

        public bool IsDuplicateRecord(string CustomerName, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(CustomerName, ID, db);
            }
        }

        public bool IsDuplicateRecord(string CustomerName, long ID, dbMarkerEntities db)
        {
            //if (db.tblCustomers.FirstOrDefault(i =>
            //    i.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
            //    i.CustomerName == CustomerName && i.CustomerID != ID) != null)
            //{
            //    return true;
            //}
            //return false;
            CustomerName = CustomerName.ToUpper();
            return db.tblCustomers.Any(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                     && r.CustomerName.ToUpper() == CustomerName && r.CustomerID != ID);
        }

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            return GetLookupList();
        }

        public List<CustomerLookUpListModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from customer in db.tblCustomers

                        join joinCity in db.tblCities on customer.CityID equals joinCity.CityID into gCity
                        from City in gCity.DefaultIfEmpty()

                        join joinstate in db.tblStates on City.StateID equals joinstate.StateID into gstate
                        from state in gstate.DefaultIfEmpty()

                        join joincountry in db.tblCountries on state.CountryID equals joincountry.CountryID into gcountry
                        from country in gcountry.DefaultIfEmpty()

                        join joinbalance in db.tblCustomerBalances on
                        new
                        {
                            customer.CustomerID,
                            Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                            Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                        }
                        equals
                        new
                        {
                            joinbalance.CustomerID,
                            joinbalance.CompanyID,
                            joinbalance.FinPeriodID
                        } into grbalance
                        from balance in grbalance.DefaultIfEmpty()

                        where customer.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                              && customer.rstate != (byte)eRecordState.Deactivated

                        orderby customer.CustomerName

                        select new CustomerLookUpListModel()
                        {
                            RecordState = (eRecordState)customer.rstate,
                            CustomerID = customer.CustomerID,
                            CustomerNo = customer.CustomerNo,
                            CustomerNameTitle = customer.NameTitle,
                            CustomerName = customer.CustomerName,
                            CompanyName = customer.CustomerCompanyName,
                            Address = customer.Address,
                            CityID = customer.CityID,
                            City = (City != null ? City.CityName : ""),
                            StateID = (City != null ? City.StateID ?? 0 : 0),
                            MobileNo = customer.MobileNo,
                            ContactPerson = customer.ContactPerson,
                            EMailID = customer.EMailID,
                            GSTNo = customer.GSTNo,
                            BalanceAmt = (balance != null ? balance.Balance : 0),
                            AllowSendSMS = customer.AllowSendSMS ?? false,
                            PriceListID = customer.PriceListID
                        }).ToList();
            }
        }

        public long GenerateNewCustomerNo()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return GenerateNewCustomerNo(db);
            }
        }

        public long GenerateNewCustomerNo(dbMarkerEntities db)
        {
            long? LastCustomerNo = db.tblCustomers.Where(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID).Max(r => (long?)r.CustomerNo);
            return (LastCustomerNo ?? 0) + 1;
        }

        public Model.Reports.CustomerPrintDetailModel GetCustomerPrintModel(long CustomerID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return GetCustomerPrintModel(CustomerID, db);
            }
        }

        public Model.Reports.CustomerPrintDetailModel GetCustomerPrintModel(long CustomerID, dbMarkerEntities db)
        {
            tblCustomer CustomerMaster = db.tblCustomers.FirstOrDefault(r => r.CustomerID == CustomerID);
            if (CustomerMaster == null)
            {
                return null;
            }

            return new Model.Reports.CustomerPrintDetailModel()
            {
                CustomerID = CustomerMaster.CustomerID,
                CustomerNameTitle = CustomerMaster.NameTitle,
                CustomerName = CustomerMaster.CustomerName,
                CustomerAddress = CustomerMaster.Address,
                CustomerCityName = CustomerMaster.tblCity.CityName,
                CustomerCityStateShortName = CustomerMaster.tblCity.tblState.StateShortName ?? CustomerMaster.tblCity.tblState.StateName,
                CustomerCityCountryName = CustomerMaster.tblCity.tblCountry.CountryName,
                CustomerPostCode = CustomerMaster.PostCode,
                CustomerMobileNo = CustomerMaster.MobileNo,
                CustomerPhoneNo = CustomerMaster.PhoneNo,
                CustomerEMailID = CustomerMaster.EMailID,
                CustomerWebsite = CustomerMaster.Website,
                CustomerPAN = CustomerMaster.PAN,
                CustomerGSTNo = CustomerMaster.GSTNo,
                CustomerServiceTaxNo = CustomerMaster.ServiceTaxNo,
                CustomerBalance = DAL.Customer.CustomerBalanceDAL.GetBalance(CustomerID)
            };
        }

    }
}
