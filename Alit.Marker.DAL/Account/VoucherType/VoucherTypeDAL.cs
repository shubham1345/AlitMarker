using Alit.Marker.DAL.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.Account.VoucherType;
using Alit.Marker.DBO;

namespace Alit.Marker.DAL.Account.VoucherType
{
    public class VoucherTypeDAL : IDashboardDAL, ICRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((VoucherTypeViewModel)ViewModel);
        }

        public SavingResult SaveRecord(VoucherTypeViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (String.IsNullOrWhiteSpace(ViewModel.VoucherTypeName))
            {
                res.ValidationError = "Please enter Voucher Type Name.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.VoucherTypeName, ViewModel.VoucherTypeID, db))
                {
                    res.ValidationError = "Can not accept duplicate Voucher Type Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                tblVoucherType SaveModel = null;
                if (ViewModel.VoucherTypeID == 0) // New Entry
                {
                    SaveModel = new tblVoucherType();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblVoucherTypes.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblVoucherTypes.Find(ViewModel.VoucherTypeID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    db.tblVoucherTypes.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                }

                SaveModel.VoucherTypeName = ViewModel.VoucherTypeName;
                SaveModel.PrimaryVoucherTypeID = (byte)ViewModel.PrimaryVoucherType;
                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.VoucherTypeID;
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
            //BeforeDeleteValidationResult res = new BeforeDeleteValidationResult();
            //res.IsValidForDelete = true;
            //return res;

            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (db.tblReceipts.Any(r => r.VoucherTypeID == ID))
                {
                    Result.ValidationMessage += (!String.IsNullOrWhiteSpace(Result.ValidationMessage) ? "\r\n" : "") + "Receipt.";
                }
                if (db.tblPayments.Any(r => r.VoucherTypeID == ID))
                {
                    Result.ValidationMessage += (!String.IsNullOrWhiteSpace(Result.ValidationMessage) ? "\r\n" : "") + "Payment.";
                }
                if (db.tblJournalVouchers.Any(r => r.VoucherTypeID == ID))
                {
                    Result.ValidationMessage += (!String.IsNullOrWhiteSpace(Result.ValidationMessage) ? "\r\n" : "") + "Journal Voucher.";
                }
                if (db.tblContraVouchers.Any(r => r.ContraVoucherID == ID))
                {
                    Result.ValidationMessage += (!String.IsNullOrWhiteSpace(Result.ValidationMessage) ? "\r\n" : "") + "Contra Voucher.";
                }
               
                if (!String.IsNullOrWhiteSpace(Result.ValidationMessage))
                {
                    Result.ValidationMessage = "Voucher Type is already selected in following:\r\n" + Result.ValidationMessage;
                }
            }
            Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
            return Result;
        }

        public SavingResult DeleteRecord(long ID)
        {
            SavingResult res = new SavingResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                db.tblVoucherTypes.RemoveRange(db.tblVoucherTypes.Where(r => r.VoucherTypeID == ID));

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

        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblVoucherTypes

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.VoucherTypeName

                        select new VoucherTypeDashboardViewModel()
                        {
                            VoucherTypeID = r.VoucherTypeID,
                            VoucherTypeName = r.VoucherTypeName,
                            PrimaryVoucherType = (ePrimaryVoucherType)r.PrimaryVoucherTypeID,

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

        public VoucherTypeViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblVoucherTypes

                        //join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        //from rcu in grcu.DefaultIfEmpty()

                        //join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        //from reu in greu.DefaultIfEmpty()

                        where r.VoucherTypeID == ID

                        select new VoucherTypeViewModel()
                        {
                            VoucherTypeID = r.VoucherTypeID,
                            VoucherTypeName = r.VoucherTypeName,
                            PrimaryVoucherType = (ePrimaryVoucherType)r.PrimaryVoucherTypeID,

                            //CreatedDateTime = r.rcdt,
                            //EditedDateTime = r.redt,
                            //CreatedUserID = r.rcuid,
                            //EditedUserID = r.reuid,
                            //CreatedUserName = (rcu != null ? rcu.UserName : null),
                            //EditedUserName = (reu != null ? reu.UserName : null),
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
                var SaveModel = db.tblVoucherTypes.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblVoucherTypes.Attach(SaveModel);
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
            ePrimaryVoucherType? PrimaryVoucherType = null;
            int count = 0;
            if (FilterParas != null)
            {
                if (FilterParas.Count() > count && FilterParas[count] is ePrimaryVoucherType)
                {
                    PrimaryVoucherType = (ePrimaryVoucherType)FilterParas[count];
                }
            }
            return GetLookupListFinal(PrimaryVoucherType);
        }

        public List<VoucherTypeLookUpListModel> GetLookupList() { return GetLookupListFinal(null); }

        public List<VoucherTypeLookUpListModel> GetLookupListFinal(ePrimaryVoucherType? PrimaryVoucherType)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblVoucherTypes

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                && r.rstate != (byte)eRecordState.Deactivated
                         
                        orderby r.VoucherTypeName

                        select new VoucherTypeLookUpListModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            VoucherTypeID = r.VoucherTypeID,
                            VoucherTypeName = r.VoucherTypeName,
                            PrimaryVoucherType = (ePrimaryVoucherType)r.PrimaryVoucherTypeID,
                        });

                if (PrimaryVoucherType != null)
                {
                    res = res.Where(r => r.PrimaryVoucherType == (ePrimaryVoucherType)PrimaryVoucherType);
                }
                return res.ToList();
            }
        }

        //public List<VoucherTypeLookUpListModel> GetLookupListFinal(ePrimaryVoucherType? PrimaryVoucherType)
        //{
        //    using (dbMarkerEntities db = new dbMarkerEntities())
        //    {
        //        return (from r in db.tblVoucherTypes

            //                where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
            //                        && r.rstate != (byte)eRecordState.Deactivated
            //                        && (PrimaryVoucherType == null || r.PrimaryVoucherTypeID == (byte)PrimaryVoucherType)

            //                orderby r.VoucherTypeName

            //                select new VoucherTypeLookUpListModel()
            //                {
            //                    RecordState = (eRecordState)r.rstate,
            //                    VoucherTypeID = r.VoucherTypeID,
            //                    VoucherTypeName = r.VoucherTypeName,
            //                    PrimaryVoucherType = (ePrimaryVoucherType)r.PrimaryVoucherTypeID,
            //                }).ToList();
            //    }
            //}

        public bool IsDuplicateRecord(string VoucherTypeName, long VoucherTypeID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(VoucherTypeName, VoucherTypeID, db);
            }
        }

        public bool IsDuplicateRecord(string VoucherTypeName, long VoucherTypeID, dbMarkerEntities db)
        {
            VoucherTypeName = VoucherTypeName.ToUpper();

            return db.tblVoucherTypes.Any(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                                        && r.VoucherTypeName.ToUpper() == VoucherTypeName
                                                        && r.VoucherTypeID != VoucherTypeID);
        }

    }
}
