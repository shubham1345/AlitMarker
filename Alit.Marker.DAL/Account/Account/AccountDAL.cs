using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.Model.Account.Group;
using Alit.Marker.Model.Account.VoucherType;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Account.Account
{
    public class AccountDAL : IDashboardDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((AccountViewModel)ViewModel);
        }

        public SavingResult SaveRecord(AccountViewModel ViewModel)
        {
            SavingResult res = new SavingResult();
            if (String.IsNullOrWhiteSpace(ViewModel.AccountName))
            {
                res.ValidationError = "Please enter Account Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            if (ViewModel.AccountGroupID == 0)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please select Account Group.";
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

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblAccount SaveModel;
                if (IsDuplicateRecord(ViewModel.AccountName, ViewModel.AccountID, db))
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Can not accept duplicate Account Name.";
                    return res;
                }

                if (ViewModel.AccountID == 0)
                {
                    SaveModel = new tblAccount();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;

                    long PrevAccountNo = SaveModel.AccountNo;
                    SaveModel.AccountNo = GenerateNewAccountNo(db);
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    if (PrevAccountNo != SaveModel.AccountNo)
                    {
                        res.MessageAfterSave = "New generated Account No. is " + SaveModel.AccountNo.ToString();
                    }

                    SaveModel.rcdt = DateTime.Now;
                    db.tblAccounts.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblAccounts.Find(ViewModel.AccountID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Record not found, Selected record may be deleted by another user over network. Please contact your admin.";
                        return res;
                    }

                    db.tblAccounts.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                }

                SaveModel.AccountName = ViewModel.AccountName;
                SaveModel.AccountNo = ViewModel.AccountNo;
                SaveModel.AccountGroupID = ViewModel.AccountGroupID;
                SaveModel.DefaultAccount = ViewModel.DefaultAccount;
                SaveModel.ContactPerson = ViewModel.ContactPerson;
                //SaveModel.BalanceAmt = ViewModel.BalanceAmt;
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


                #region Opening Balance
                tblAccountOpeningBalance SaveModelOpBal;
                //if (ViewModel.AccountOpeningBalanceID == 0)
                //{
                //SaveModelOpBal = db.tblAccountOpeningBalances.Find(ViewModel.AccountOpeningBalanceID);

                if (ViewModel.AccountOpeningBalanceID == 0 && ViewModel.OpBalAmount != 0)
                {
                    SaveModelOpBal = new tblAccountOpeningBalance();

                    SaveModelOpBal.tblAccount = SaveModel;
                    SaveModelOpBal.OpeningBalanceAmount = (ViewModel.CrDrType == eCrDrType.Dr ? ViewModel.OpBalAmount : -ViewModel.OpBalAmount);
                    SaveModelOpBal.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                    SaveModelOpBal.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModelOpBal.rcdt = DateTime.Now;

                    db.tblAccountOpeningBalances.Add(SaveModelOpBal);
                }
                else
                {
                    SaveModelOpBal = db.tblAccountOpeningBalances.Find(ViewModel.AccountOpeningBalanceID);
                    if (SaveModelOpBal != null)
                    {
                        if (SaveModelOpBal.OpeningBalanceAmount != 0 && ViewModel.OpBalAmount == 0)
                        {
                            db.tblAccountOpeningBalances.Remove(SaveModelOpBal);
                        }
                        else
                        {
                            SaveModelOpBal.OpeningBalanceAmount = (ViewModel.CrDrType == eCrDrType.Dr ? ViewModel.OpBalAmount : -ViewModel.OpBalAmount);
                            //SaveModelOpBal.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                            SaveModelOpBal.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                            SaveModelOpBal.redt = DateTime.Now;

                            db.tblAccountOpeningBalances.Attach(SaveModelOpBal);
                            db.Entry(SaveModelOpBal).State = System.Data.Entity.EntityState.Modified;
                        }
                    }
                }
                #endregion

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.AccountID;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long ID)
        {
            BeforeDeleteValidationResult res = new BeforeDeleteValidationResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                res.ValidationMessage = "";

                if (db.tblAccounts.Any(r => r.AccountID == ID && r.DefaultAccount == true))
                {
                    res.ValidationMessage += "\r\nCan not delete Default Account.";
                    res.IsValidForDelete = false;
                }
                else
                {

                    ////if (db.tblAccountVoucherDetaills.Any(r => r.AccountID == ID))
                    ////{
                    ////    ePrimaryVoucherType VoucherType =
                    ////        (ePrimaryVoucherType)(from r in db.tblVoucherTypes

                    ////                              join jv in db.tblAccountVouchers on r.VoucherTypeID equals jv.VoucherTypeID
                    ////                              join jvde in db.tblAccountVoucherDetaills on jv.AccountVoucherID equals jvde.AccountVoucherID

                    ////                              where jvde.AccountID == ID
                    ////                              select r.PrimaryVoucherTypeID).FirstOrDefault();

                    ////    if (VoucherType == ePrimaryVoucherType.JournalVoucher)
                    ////    {
                    ////        res.ValidationMessage += "\r\nJournal Voucher.";
                    ////    }
                    ////    if (VoucherType == ePrimaryVoucherType.JournalVoucher)
                    ////    {
                    ////        res.ValidationMessage += "\r\nContra Voucher.";
                    ////    }
                    ////    if (VoucherType == ePrimaryVoucherType.Sale)
                    ////    {
                    ////        res.ValidationMessage += "\r\nSale.";
                    ////    }
                    ////    if (VoucherType == ePrimaryVoucherType.SaleReturn)
                    ////    {
                    ////        res.ValidationMessage += "\r\nJSale Return.";
                    ////    }
                    ////    if (VoucherType == ePrimaryVoucherType.Purchase)
                    ////    {
                    ////        res.ValidationMessage += "\r\nPurchase.";
                    ////    }
                    ////    if (VoucherType == ePrimaryVoucherType.PurchaseReturn)
                    ////    {
                    ////        res.ValidationMessage += "\r\nPurchase Return.";
                    ////    }
                    ////    if (VoucherType == ePrimaryVoucherType.Receipt)
                    ////    {
                    ////        res.ValidationMessage += "\r\nReceipt.";
                    ////    }
                    ////    if (VoucherType == ePrimaryVoucherType.Payment)
                    ////    {
                    ////        res.ValidationMessage += "\r\nPayment.";
                    ////    }
                    ////}

                    if (db.tblJournalVoucherDetails.Any(r => r.AccountID == ID))
                    {
                        res.ValidationMessage += "\r\nJournal Voucher.";
                    }
                    if (db.tblContraVoucherDetails.Any(r => r.AccountID == ID))
                    {
                        res.ValidationMessage += "\r\nContra Voucher.";
                    }
                    if (db.tblSaleInvoices.Any(r => r.CustomerAccountID == ID || r.SaleAccountID == ID))
                    {
                        res.ValidationMessage += "\r\nSale.";
                    }
                    if (db.tblSaleReturns.Any(r => r.CustomerAccountID == ID || r.SaleAccountID == ID))
                    {
                        res.ValidationMessage += "\r\nSale Return.";
                    }
                    if (db.tblPurchaseBills.Any(r => r.CustomerAccountID == ID || r.PurchaseAccountID == ID))
                    {
                        res.ValidationMessage += "\r\nPurchase.";
                    }
                    if (db.tblPurchaseReturns.Any(r => r.CustomerAccountID == ID || r.PurchaseAccountID == ID))
                    {
                        res.ValidationMessage += "\r\nPurchase Return.";
                    }
                    if (db.tblReceipts.Any(r => r.CashBankAccountID == ID || r.AccountID == ID))
                    {
                        res.ValidationMessage += "\r\nReceipt.";
                    }
                    if (db.tblPayments.Any(r => r.CashBankAccountID == ID || r.AccountID == ID))
                    {
                        res.ValidationMessage += "\r\nPayment.";
                    }
                    if (db.tblAdditionalItemMasters.Any(r => r.AccountID == ID))
                    {
                        res.ValidationMessage += "\r\nAdditional Item Master.";
                    }
                    //if (db.tblAccountOpeningBalances.Any(r => r.AccountID == ID && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID))
                    //{
                    //    res.ValidationMessage += "\r\nAccount Opening Balance.";
                    //}
                }
                if (!String.IsNullOrWhiteSpace(res.ValidationMessage))
                {
                    res.ValidationMessage = "Account is already selected in following:" + res.ValidationMessage;
                    res.IsValidForDelete = false;
                }
                else
                {
                    res.IsValidForDelete = true;
                }

            }
            return res;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = null;

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (DeleteID != 0)
                {
                    tblAccount RecordToDelete = db.tblAccounts.FirstOrDefault(r => r.AccountID == DeleteID);
                    res = DeleteRecord(RecordToDelete, db);
                }
                else
                {
                    res = new SavingResult();
                    res.ValidationError = "No record selected to delete.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                }

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
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public SavingResult DeleteRecord(tblAccount RecordToDelete, dbMarkerEntities db)
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
                //db.tblAccountOpeningBalances.RemoveRange(db.tblAccountOpeningBalances.Where(r => r.AccountID == RecordToDelete.AccountID && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID));
                db.tblAccountOpeningBalances.RemoveRange(db.tblAccountOpeningBalances.Where(r => r.AccountID == RecordToDelete.AccountID));

                db.tblAccounts.Remove(RecordToDelete);
            }
            return res;
        }

        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            eAccountFormType? IsAccountType = null;

            if (FilterParas != null && FilterParas.Count() >= 1 && FilterParas[0] != null && FilterParas[0] is eAccountFormType)
            {
                IsAccountType = (eAccountFormType)FilterParas[0];
            }
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblAccounts

                        join jopbal in db.tblAccountOpeningBalances on
                         new { r.AccountID, Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID }
                         equals new { jopbal.AccountID, jopbal.FinPeriodID } into gopbal
                        from OpBal in gopbal.DefaultIfEmpty()

                        join jaccg in db.tblAccountGroups on r.AccountGroupID equals jaccg.AccountGroupID
                        into gaccg
                        from acg in gaccg.DefaultIfEmpty()


                        join jCity in db.tblCities on r.CityID equals jCity.CityID into gCity
                        from City in gCity.DefaultIfEmpty()

                        join jstate in db.tblStates on City.StateID equals jstate.StateID into gstate
                        from state in gstate.DefaultIfEmpty()

                        join jcountry in db.tblCountries on state.CountryID equals jcountry.CountryID into gcountry
                        from country in gcountry.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                          && (
                          (IsAccountType == null || IsAccountType == eAccountFormType.Account || ((IsAccountType == eAccountFormType.Customer && acg.GroupTypeID == (byte)eAccountGroupType.SundryDebtors)
                          || (IsAccountType == eAccountFormType.Supplier && acg.GroupTypeID == (byte)eAccountGroupType.SundryCreditors)))
                          )

                        orderby r.AccountName

                        select new AccountDashboardViewModel()
                        {
                            AccountID = r.AccountID,
                            AccountNo = r.AccountNo,
                            AccountName = r.AccountName,
                            Address = r.Address,
                            City = (City != null ? City.CityName : null),
                            State = (state != null ? state.StateName : null),
                            Country = (country != null ? country.CountryName : null),
                            MobileNo = r.MobileNo,
                            ContactPerson = r.ContactPerson,
                            PhoneNo = r.PhoneNo,
                            EMailID = r.EMailID,
                            PAN = r.PAN,
                            GSTNo = r.GSTNo,
                            //BalanceAmt = (balance != null ? balance.Balance : 0),
                            OpBalAmount = (OpBal != null ? OpBal.OpeningBalanceAmount : 0M),

                            RecordState = (eRecordState)r.rstate,
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

        public AccountViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblAccounts

                            //join jopbal in db.tblAccountOpeningBalances on r.AccountID equals jopbal.AccountID into gopbal
                            //from OpBal in gopbal.DefaultIfEmpty()

                        join jopbal in db.tblAccountOpeningBalances on
                        new { r.AccountID, Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID }
                         equals new { jopbal.AccountID, jopbal.FinPeriodID } into gopbal
                        from OpBal in gopbal.DefaultIfEmpty()

                        where r.AccountID == ID

                        select new AccountViewModel()
                        {
                            AccountID = r.AccountID,
                            AccountName = r.AccountName,
                            AccountNo = r.AccountNo,
                            AccountGroupID = r.AccountGroupID,
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
                            DefaultAccount = r.DefaultAccount ?? false,

                            AccountOpeningBalanceID = (OpBal != null ? OpBal.AccountOpeningBalanceID : 0),
                            OpBalAmount = (OpBal != null ? Math.Abs(OpBal.OpeningBalanceAmount) : 0M),
                            //CreditAmount = (jvd.Amount < 0 ? Math.Abs(jvd.Amount) : 0M),
                            CrDrType = (OpBal != null ? (OpBal.OpeningBalanceAmount < 0 ? eCrDrType.Cr : eCrDrType.Dr) : eCrDrType.Dr),
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
                var SaveModel = db.tblAccounts.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblAccounts.Attach(SaveModel);
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
            //eAccountLookupType? AccountLookupType = null;
            eAccountGroupType[] AccountGroupTypes = null;

            int count = 0;
            if (FilterParas != null)
            {
                //if (FilterParas.Count() > count && FilterParas[count] is eAccountLookupType)
                //{
                //    AccountLookupType = (eAccountLookupType)FilterParas[count];
                //}
                //count++;
                if (FilterParas.Count() > count && FilterParas[count] is eAccountGroupType[])
                {
                    AccountGroupTypes = (eAccountGroupType[])FilterParas[count];
                }
            }
            return GetLookupListFinal(AccountGroupTypes);
        }

        //public List<AccountGroupLookupListModel> GetLookupList() { return GetLookupList(null); }

        public List<AccountLookUpListModel> GetLookupListFinal()
        {
            return GetLookupListFinal(null);
        }

        public List<AccountLookUpListModel> GetLookupListFinal(eAccountGroupType[] AccountGroupTypes)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblAccounts

                           join jaccg in db.tblAccountGroups on r.AccountGroupID equals jaccg.AccountGroupID
                           into gaccg from acg in gaccg.DefaultIfEmpty()

                           join joinCity in db.tblCities on r.CityID equals joinCity.CityID into gCity
                           from City in gCity.DefaultIfEmpty()

                           join joinstate in db.tblStates on City.StateID equals joinstate.StateID into gstate
                           from state in gstate.DefaultIfEmpty()

                           join joincountry in db.tblCountries on state.CountryID equals joincountry.CountryID into gcountry
                           from country in gcountry.DefaultIfEmpty()

                           where r.rstate != (byte)eRecordState.Deactivated
                           && r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                           //&& (AccountLookupType == null || 
                           //             (
                           //                  (AccountLookupType == eAccountLookupType.Customer && acg.GroupTypeID ==                    (byte) eAccountGroupType.SundryDebtors)
                           //               || (AccountLookupType == eAccountLookupType.Supplier && acg.GroupTypeID ==                    (byte) eAccountGroupType.SundryCreditors)
                           //             )
                           //     )

                           //&& (AccountGroupTypes == null || (!AccountGroupTypes.Contains(eAccountGroupType.None) && (acg.GroupTypeID != null && AccountGroupTypes.Contains((eAccountGroupType)acg.GroupTypeID))))




                           orderby r.AccountName


                           select new AccountLookUpListModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               AccountID = r.AccountID,
                               AccountNo = r.AccountNo,
                               AccountName = r.AccountName,
                               Address = r.Address,
                               CityID = r.CityID,
                               City = (City != null ? City.CityName : null),
                               StateID = (City != null ? City.StateID ?? 0 : 0),
                               MobileNo = r.MobileNo,
                               ContactPerson = r.ContactPerson,
                               EMailID = r.EMailID,
                               GSTNo = r.GSTNo,
                               //BalanceAmt = (balance != null ? balance.Balance : 0),
                               AllowSendSMS = r.AllowSendSMS ?? false,
                               PriceListID = r.PriceListID,
                               AccountGroupType = (acg != null ? (eAccountGroupType?)acg.GroupTypeID : null)
                           });

                if (AccountGroupTypes != null)
                {
                    res = res.Where(r => r.AccountGroupType != null && AccountGroupTypes.Contains((eAccountGroupType)r.AccountGroupType));
                }
                return res.ToList();
            }
        }

        public bool IsDuplicateRecord(string AccountName, long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(AccountName, ID, db);
            }
        }

        public bool IsDuplicateRecord(string AccountName, long ID, dbMarkerEntities db)
        {
            AccountName = AccountName.ToUpper();
            return db.tblAccounts.Any(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                     && r.AccountName.ToUpper() == AccountName && r.AccountID != ID);
        }

        public long GenerateNewAccountNo()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return GenerateNewAccountNo(db);
            }
        }

        public long GenerateNewAccountNo(dbMarkerEntities db)
        {
            long? LastAccountNo = db.tblAccounts.Where(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID).Max(r => (long?)r.AccountNo);
            return (LastAccountNo ?? 0) + 1;
        }

        public bool IsExpenseORLiablitiesAccountGroup(long AccountGroupID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (db.tblAccountGroups.Any(r => r.AccountGroupID == AccountGroupID && r.GroupNatureID != null && (r.GroupNatureID == (byte)eAccountGroupNature.Asset || r.GroupNatureID == (byte)eAccountGroupNature.Liablities)))
                {
                    return true;
                }
                else
                {
                    long ParentGroupID = db.tblAccountGroups.FirstOrDefault(r => r.AccountGroupID == AccountGroupID && r.ParentGroupID != null)?.ParentGroupID ?? 0;
                    if (ParentGroupID != 0)
                    {
                        return db.tblAccountGroups.Any(r => r.AccountGroupID == ParentGroupID && r.GroupNatureID != null && (r.GroupNatureID == (byte)eAccountGroupNature.Asset || r.GroupNatureID == (byte)eAccountGroupNature.Liablities));
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

    }
}
