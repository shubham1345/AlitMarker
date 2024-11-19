using Alit.Marker.DBO;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Customer
{
    public static class CustomerBalanceDAL
    {
        public static SavingResult UpdateBalance(long CustomerID, decimal UpdateAmt, long CompanyID, long FinPeriodID, dbMarkerEntities db, SavingResult res)
        {
            tblCustomerBalance SaveModel = db.tblCustomerBalances.FirstOrDefault(r => r.CustomerID == CustomerID &&
                r.CompanyID == CompanyID &&
                r.FinPeriodID == FinPeriodID);

            if (SaveModel == null) // New Entry
            {
                SaveModel = new tblCustomerBalance();
                SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.CustomerID = CustomerID;
                SaveModel.Balance = UpdateAmt;
                SaveModel.CompanyID = CompanyID;
                SaveModel.FinPeriodID = FinPeriodID;
                SaveModel.rcdt = DateTime.Now;
                db.tblCustomerBalances.Add(SaveModel);
            }
            else
            {
                SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.Balance += UpdateAmt;
                SaveModel.redt = DateTime.Now;
                db.tblCustomerBalances.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
            }

            return res;
        }

        public static SavingResult UpdateBalance(long CustomerID, decimal UpdateAmt, long CompanyID, long FinPeriodID)
        {
            SavingResult res = new SavingResult();

            //--
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return UpdateBalance(CustomerID, UpdateAmt, CompanyID, FinPeriodID, db, res);
            }
        }

        public static decimal GetBalance(long CustomerID, long CompanyID, long FinPeriodID, dbMarkerEntities db, SavingResult res)
        {
            tblCustomerBalance SaveModel = db.tblCustomerBalances.FirstOrDefault(r => 
                r.CustomerID == CustomerID &&
                r.CompanyID == CompanyID &&
                r.FinPeriodID == FinPeriodID);
            if(SaveModel != null)
            {
                return SaveModel.Balance;
            }
            else
            {
                return 0;
            }
        }
        public static decimal GetBalance(long CustomerID, long CompanyID, long FinPeriodID)
        {
            SavingResult res = new SavingResult();

            //--
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return GetBalance(CustomerID, CompanyID, FinPeriodID, db, res);
            }
        }
        public static decimal GetBalance(long CustomerID, dbMarkerEntities db, SavingResult res)
        {
            return GetBalance(CustomerID, 
                    Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                    Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID, 
                    db, res);
        }
        public static decimal GetBalance(long CustomerID)
        {
            SavingResult res = new SavingResult();

            //--
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return GetBalance(CustomerID, db, res);
            }
        }

        public async static Task<SavingResult> ReCalculateBalance()
        {
            SavingResult res = new SavingResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                db.tblCustomerBalances.RemoveRange(db.tblCustomerBalances.Where(r =>
                    r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                    r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID));

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    res.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
                    res.Exception = ex;
                    while (res.Exception.Message == "An error occurred while updating the entries. See the inner exception for details.")
                    {
                        res.Exception = res.Exception.InnerException;
                    }
                    return res;
                }

                DAL.Settings.FinancialPeriod.FinPeriodDAL FinPerDALObj = new Settings.FinancialPeriod.FinPeriodDAL();
                List<Model.Settings.FinancialPeriod.CustomerClosingBalanceViewModel> balances = await FinPerDALObj.GetCustomerClosingBalance(
                    Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                    Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID);


                foreach (Model.Settings.FinancialPeriod.CustomerClosingBalanceViewModel Cust in balances)
                {
                    res = DAL.Customer.CustomerBalanceDAL.UpdateBalance(Cust.CustomerID, Cust.OpeningBalance,
                        Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                    Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID, db, res);
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
                    while (res.Exception.Message == "An error occurred while updating the entries. See the inner exception for details.")
                    {
                        res.Exception = res.Exception.InnerException;
                    }
                }
            }
            return res;
        }

    }
}
