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
    public class CustomerOpeningBalanceDAL : IDashboardDAL, ICRUDDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((CustomerOpeningBalanceViewModel)ViewModel);
        }

        public SavingResult SaveRecord(CustomerOpeningBalanceViewModel ViewModel)
        {
            SavingResult res = new SavingResult();
            //--
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblCustomerOpBal SaveModel = null;
                res = SaveRecord(ViewModel, out SaveModel, db, res);
                if(!String.IsNullOrWhiteSpace(res.ValidationError))
                {
                    return res;
                }
                //--
                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.OpBalID;
                }
                catch (Exception ex)
                {
                    //res.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
                    //res.Exception = ex;
                    //while (res.Exception.Message == "An error occurred while updating the entries. See the inner exception for details.")
                    //{
                    //    res.Exception = res.Exception.InnerException;
                    //}
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public SavingResult SaveRecord(CustomerOpeningBalanceViewModel ViewModel, out tblCustomerOpBal SaveModel, dbMarkerEntities db, SavingResult res)
        {
            return SaveRecord(ViewModel, out SaveModel,
                Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID,
                db, res);
        }

        public SavingResult SaveRecord(CustomerOpeningBalanceViewModel ViewModel, out tblCustomerOpBal SaveModel, long CompanyID, long FinPeriodID, dbMarkerEntities db, SavingResult res)
        {
            SaveModel = null;
            if (ViewModel.OpBalanceAmt == 0)
            {
                res.ValidationError = "Please enter Opening Balance Amt.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }

            if (ViewModel.OpBalID == 0) // New Entry
            {
                SaveModel = new tblCustomerOpBal();
                SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.FinPeriodID = FinPeriodID;
                SaveModel.CompanyID = CompanyID;
                SaveModel.rcdt = DateTime.Now;
                db.tblCustomerOpBals.Add(SaveModel);
            }
            else
            {
                SaveModel = db.tblCustomerOpBals.Find(ViewModel.OpBalID);
                if(SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Record not found. Record may be deleted by another user over network. Please contact your admin.";
                    return res;
                }
                db.tblCustomerOpBals.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.redt = DateTime.Now;

                tblCustomerOpBal OldOpeningBalance = null;
                using (dbMarkerEntities db1 = new dbMarkerEntities())
                {
                    OldOpeningBalance = db1.tblCustomerOpBals.Find(SaveModel.OpBalID);
                }

                DAL.Customer.CustomerBalanceDAL.UpdateBalance(SaveModel.CustomerID, -OldOpeningBalance.OpBalAmt, CompanyID, FinPeriodID, db, res);
            }
            SaveModel.CustomerID = ViewModel.CustomerID;
            SaveModel.OpBalDate = ViewModel.OpBalanceDate;
            SaveModel.OpBalAmt = ViewModel.OpBalanceAmt;
            SaveModel.Narration = ViewModel.Narration;
            DAL.Customer.CustomerBalanceDAL.UpdateBalance(SaveModel.CustomerID, SaveModel.OpBalAmt, SaveModel.CompanyID, SaveModel.FinPeriodID, db, res);
            return res;
        }



        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            //using (dbMarkerEntities db = new dbMarkerEntities())
            //{

            //bool InState = db.tblCustomerOpBal.FirstOrDefault(r => r.CustomerID == DeleteID) != null;

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
                tblCustomerOpBal RecordToDelete = db.tblCustomerOpBals.FirstOrDefault(r => r.OpBalID == DeleteID);
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

        public SavingResult DeleteRecord(tblCustomerOpBal RecordToDelete, dbMarkerEntities db)
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
                db.tblCustomerOpBals.Remove(RecordToDelete);
                DAL.Customer.CustomerBalanceDAL.UpdateBalance(RecordToDelete.CustomerID, -RecordToDelete.OpBalAmt, RecordToDelete.CompanyID, RecordToDelete.FinPeriodID, db, res);
            }
            return res;
        }

        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return ( from opbal in db.tblCustomerOpBals

                         //join jc in db.tblCustomers on opbal.CustomerID equals jc.CustomerID into gc
                         //from c in gc.DefaultIfEmpty()

                        //join joincurrbal in db.tblCustomerBalances on
                        //     new
                        //     {
                        //         CustomerID = c.CustomerID,
                        //         CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                        //         FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                        //     }
                        // equals
                        //     new
                        //     {
                        //         CustomerID = joincurrbal.CustomerID,
                        //         CompanyID = joincurrbal.CompanyID,
                        //         FinPeriodID = joincurrbal.FinPeriodID
                        //     } into gcurrbal
                        //from currbal in gcurrbal.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on opbal.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on opbal.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where opbal.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        //orderby c.CustomerName

                        select new CustomerOpeningBalanceViewModel()
                        {
                            OpBalID =opbal.OpBalID,
                            OpBalanceDate = opbal.OpBalDate,
                            OpBalanceAmt = opbal.OpBalAmt,

                            CustomerID = opbal.CustomerID,
                            Narration = opbal.Narration,

                            CreatedDateTime = opbal.rcdt,
                            EditedDateTime = opbal.redt,
                            CreatedUserID = opbal.rcuid,
                            EditedUserID = opbal.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),

                        }).ToList();
            }
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public CustomerOpeningBalanceViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from opbal in db.tblCustomerOpBals 
                                            
                        join joinrcu in db.tblUsers on opbal.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on opbal.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where opbal.OpBalID == ID

                        select new CustomerOpeningBalanceViewModel()
                        {
                            OpBalID = opbal.OpBalID,
                            CustomerID = opbal.CustomerID,
                            OpBalanceDate = opbal.OpBalDate,
                            OpBalanceAmt = opbal.OpBalAmt,

                            CreatedDateTime = opbal.rcdt,
                            EditedDateTime = opbal.redt,
                            CreatedUserID = opbal.rcuid,
                            EditedUserID = opbal.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),

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
            //using (dbMarkerEntities db = new DAL.dbMarkerEntities())
            //{
            //    var SaveModel = db.tblCities.Find(ID);
            //    if (SaveModel == null)
            //    {
            //        res.ExecutionResult = eExecutionResult.ValidationError;
            //        res.ValidationError = "Selected record not found.";
            //        return res;
            //    }

            //    db.tblCities.Attach(SaveModel);
            //    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

            //    //SaveModel.rstate = (byte)newRecordState;

            //    try
            //    {
            //        db.SaveChanges();
            //        res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
            //    }
            //    catch (Exception ex)
            //    {
            //        CommonFunctions.GetFinalError(res, ex);
            //    }
            //}
            return res;
        }
    }
}
