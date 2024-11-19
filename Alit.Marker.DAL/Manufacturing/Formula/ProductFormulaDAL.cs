using Alit.Marker.Model;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.Manufacturing.Formula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;

namespace Alit.Marker.DAL.Manufacturing.Formula
{
    public class ProductFormulaDAL : IDashboardDAL, ICRUDDAL
    {
        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((ProductFormulaViewModel)ViewModel);
        }

        public SavingResult SaveRecord(ProductFormulaViewModel ViewModel)
        {
            SavingResult res = new SavingResult();
            if (ViewModel.ProductID == 0)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please select finish product";
                return res;
            }
            if (ViewModel.FinishQuantity == 0)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please enter finish quantity";
                return res;
            }
            if (ViewModel.ProductDetail == null || ViewModel.ProductDetail.Count(r => r.Quantity != 0) == 0)
            {
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please enter material detail";
                return res;
            }
            //--
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var FormulasToDelete = db.tblProductFormulas.Where(r => r.ProductID == ViewModel.ProductID && (ViewModel.WEDate == null || r.WEDate >= ViewModel.WEDate));
                db.tblProductFormulaDetails.RemoveRange(from fd in db.tblProductFormulaDetails
                                                        join f in FormulasToDelete on fd.ProductFormulaID equals f.ProductFormulaID
                                                        select fd);
                db.tblProductFormulas.RemoveRange(FormulasToDelete);

                tblProductFormula SaveModel = null;
                //if (ViewModel.ProductFormulaID == 0) // New Entry
                //{
                    SaveModel = new tblProductFormula();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblProductFormulas.Add(SaveModel);
                //}
                //else
                //{
                //    SaveModel = db.tblProductFormulas.Find(ViewModel.ProductFormulaID);
                //    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                //    SaveModel.redt = DateTime.Now;
                //    db.tblProductFormulas.Attach(SaveModel);
                //    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                //    db.tblProductFormulaDetails.RemoveRange(db.tblProductFormulaDetails.Where(r => r.ProductFormulaID == ViewModel.ProductFormulaID));
                //}

                SaveModel.ProductID = ViewModel.ProductID;
                SaveModel.FinishQuantity = ViewModel.FinishQuantity;
                SaveModel.Remark = ViewModel.Remark;
                SaveModel.WEDate = ViewModel.WEDate;

                db.tblProductFormulaDetails.AddRange(ViewModel.ProductDetail.Select(r => new tblProductFormulaDetail()
                {
                    tblProductFormula = SaveModel,
                    RawMaterialProductID = r.ProductID,
                    Quantity = r.Quantity,
                }));

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.ProductFormulaID;
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
            Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
            return Result;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = new SavingResult();

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
            SavingResult res = null;// new SavingResult();

            if (DeleteID != 0)
            {
                tblProductFormula RecordToDelete = db.tblProductFormulas.FirstOrDefault(r => r.ProductFormulaID == DeleteID);
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

        public SavingResult DeleteRecord(tblProductFormula RecordToDelete, dbMarkerEntities db)
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
                db.tblProductFormulaDetails.RemoveRange(db.tblProductFormulaDetails.Where(r => r.ProductFormulaID == RecordToDelete.ProductFormulaID));
                db.tblProductFormulas.Remove(RecordToDelete);
            }

            return res;
        }


        public IEnumerable<IDashboardViewModel> GetDashboardData() { return GetDashboardData(null); }

        public IEnumerable<IDashboardViewModel> GetDashboardData(object[] FilterParas = null)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from p in db.tblProducts
                        join r in (from f in db.tblProductFormulas
                                   group f by f.ProductID into gf
                                   select gf.OrderByDescending(gr => gr.WEDate).FirstOrDefault())
                        on p.ProductID equals r.ProductID

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        orderby p.PCode
                        select new ProductFormulaDashboardViewModel()
                        {
                            ProductFormulaID = r.ProductFormulaID,
                            ProductID = r.ProductID,
                            PCode = p.PCode,
                            Barcode = p.Barcode,
                            ProductName = p.ProductName,
                            FinishQuantity = r.FinishQuantity,
                            WEDate = r.WEDate,

                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),

                        }).ToList();
            }
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            return GetViewModelByPrimeKey(ID);
        }

        public ProductFormulaViewModel GetViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return GetViewModelByPrimeKey(ID, db);
            }
        }
        public ProductFormulaViewModel GetViewModelByPrimeKey(long ID, dbMarkerEntities db)
        {
            //using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblProductFormulas
                        where r.ProductFormulaID == ID
                        select new ProductFormulaViewModel()
                        {
                            ProductFormulaID = r.ProductFormulaID,
                            ProductID = r.ProductID,
                            FinishQuantity = r.FinishQuantity,
                            Remark = r.Remark,
                            WEDate = r.WEDate,
                            ProductDetail = (from pd in db.tblProductFormulaDetails
                                             where pd.ProductFormulaID == r.ProductFormulaID
                                             select new ProductFormulaDetailViewModel()
                                             {
                                                 ProductID = pd.RawMaterialProductID,
                                                 Quantity = pd.Quantity,
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

            //    SaveModel.rstate = (byte)newRecordState;

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

        public IEnumerable<ProductFormulaLookupListModel> GetLookupList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from p in db.tblProducts
                        join r in (from f in db.tblProductFormulas
                                   group f by f.ProductID into gf
                                   select gf.OrderByDescending(gr => gr.WEDate).FirstOrDefault())
                                   on p.ProductID equals r.ProductID

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        orderby p.PCode
                        select new ProductFormulaLookupListModel()
                        {
                            ProductFormulaID = r.ProductFormulaID,
                            PCode = p.PCode,
                            Barcode = p.Barcode,
                            ProductName = p.ProductName,
                            FinishQuantity = r.FinishQuantity,
                            WEDate = r.WEDate,
                        }).ToList();
            }
        }

        public ProductFormulaViewModel GetLatestFormulaByProductID(long ProductID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var SaveModel = db.tblProductFormulas.Where(r => r.ProductID == ProductID).OrderByDescending(r => r.WEDate).FirstOrDefault();
                if (SaveModel != null)
                {
                    return GetViewModelByPrimeKey(SaveModel.ProductFormulaID);
                }
                return null;
            }
        }
    }
}
