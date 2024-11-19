using Alit.Marker.DAL;
using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.ERP.Masters.Transport;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Masters.Transport
{
    public class TransportDAL : ICRUDDAL, IGridCRUDDAL, ILookupListDAL
    {
        public SavingResult SaveRecord(IGridCRUDViewModel ViewModel)
        {
            return SaveRecord((TransportViewModel)ViewModel);
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((TransportViewModel)ViewModel);
        }

        public SavingResult SaveRecord(TransportViewModel ViewModel)
        {
            SavingResult res = new SavingResult();

            if (String.IsNullOrWhiteSpace(ViewModel.TransportName))
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please enter Transport Name.";
                return res;
            }
            if (ViewModel.TransportName.Length > 50)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Maximum 50 characters are accepted in Transport Name.";
                return res;
            }

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (IsDuplicateRecord(ViewModel.TransportName, ViewModel.TransportID, db))
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Can not accept duplicate Transport Name.";
                    return res;
                }

                tblTransport SaveModel = null;
                if (ViewModel.TransportID == 0) // New Entry
                {
                    SaveModel = new tblTransport();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;

                    SaveModel.rcdt = DateTime.Now;
                    db.tblTransports.Add(SaveModel);
                }
                else
                {
                    SaveModel = db.tblTransports.Find(ViewModel.TransportID);

                    if (SaveModel == null)
                    {
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        res.ValidationError = "Selected record not found. May be it has been changed/deleted by another user over network.";
                        return res;
                    }

                    db.tblTransports.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                }

                SaveModel.TransportName = ViewModel.TransportName;

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.TransportID;
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
            BeforeDeleteValidationResult res = new BeforeDeleteValidationResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (db.tblSaleInvoices.Any(r => r.TransportID == DeleteID))
                {
                    res.ValidationMessage = "Transport exists in some Sale Invoices";
                }
            }
            res.IsValidForDelete = String.IsNullOrWhiteSpace(res.ValidationMessage);
            return res;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = new SavingResult();

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (DeleteID != 0)
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
            }
            return res;
        }

        public SavingResult DeleteRecord(long DeleteID, dbMarkerEntities db)
        {
            SavingResult res = new SavingResult();
            if (DeleteID != 0)
            {
                tblTransport RecordToDelete = db.tblTransports.FirstOrDefault(r => r.TransportID == DeleteID);
                res = DeleteRecord(RecordToDelete, db);
            }
            return res;
        }

        public SavingResult DeleteRecord(tblTransport RecordToDelete, dbMarkerEntities db)
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
                db.tblTransports.Remove(RecordToDelete);
            }
            return res;
        }

        public IEnumerable<IGridCRUDViewModel> GetViewModelList() { return GetViewModelList(null); }

        public IEnumerable<IGridCRUDViewModel> GetViewModelList(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblTransports

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.TransportName

                        select new TransportViewModel()
                        {
                            TransportID = r.TransportID,
                            TransportName = r.TransportName,

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

        IGridCRUDViewModel IGridCRUDDAL.GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public TransportViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblTransports

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.TransportID == ID

                        select new TransportViewModel()
                        {
                            TransportID = r.TransportID,
                            TransportName = r.TransportName,

                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : null),
                            EditedUserName = (reu != null ? reu.UserName : null),

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
                var SaveModel = db.tblTransports.Find(ID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record not found.";
                    return res;
                }

                db.tblTransports.Attach(SaveModel);
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

        public List<TransportLookUpListModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblTransports

                           where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                && r.rstate != (byte)eRecordState.Deactivated

                           orderby r.TransportName

                           select new TransportLookUpListModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               TransportID = r.TransportID,
                               TransportName = r.TransportName
                           }).ToList();
                return res;
            }
        }
        
        public bool IsDuplicateRecord(string TransportName, long TransportID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return IsDuplicateRecord(TransportName, TransportID, db);
            }
        }

        public bool IsDuplicateRecord(string TransportName, long TransportID, dbMarkerEntities db)
        {
            TransportName = TransportName.ToUpper();

            return (db.tblTransports.Any(r => r.TransportName.ToUpper() == TransportName && r.TransportID != TransportID && r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID));
        }
    }
}
