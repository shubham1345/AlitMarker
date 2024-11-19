using Alit.Marker.Service.Update.DAL;
using Alit.Marker.Service.Update.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Alit.Marker.Service.Update.Controllers
{
    public class SoftwareRegistrationController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetRegistration(string EmailID, string Password)
        {
            PostResultViewModel<SoftwareRegistrationViewModel> result = new PostResultViewModel<SoftwareRegistrationViewModel>();
            result.Success = true;
            try
            {
                using (DB_A05B1F_markerupdateEntities db = new DB_A05B1F_markerupdateEntities())
                {
                    EmailID = EmailID.ToLower();
                    tblSoftwareRegistration RegInfo = db.tblSoftwareRegistrations.FirstOrDefault(r => r.EmailID.ToLower() == EmailID && r.Password == Password);

                    if (RegInfo != null)
                    {
                        result.ResultObject = ConvertToViewModel(RegInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                ex = CommonFunctions.GetFinalError(ex);
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetRegistration(int SoftwareRegistrationID)
        {
            PostResultViewModel<SoftwareRegistrationViewModel> result = new PostResultViewModel<SoftwareRegistrationViewModel>();
            try
            {
                using (DB_A05B1F_markerupdateEntities db = new DB_A05B1F_markerupdateEntities())
                {
                    tblSoftwareRegistration RegInfo = db.tblSoftwareRegistrations.FirstOrDefault(r => r.SoftwareRegistrationID == SoftwareRegistrationID);

                    if (RegInfo != null)
                    {
                        result.ResultObject = ConvertToViewModel(RegInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                ex = CommonFunctions.GetFinalError(ex);
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return Ok(result);
        }

        private SoftwareRegistrationViewModel ConvertToViewModel(tblSoftwareRegistration RegInfo)
        {
            return new SoftwareRegistrationViewModel()
            {
                SoftwareRegistrationID = RegInfo.SoftwareRegistrationID,
                EMailID = RegInfo.EmailID,
                FullName = RegInfo.FullName,
                CompanyName = RegInfo.CompanyName,
                BusinessType = RegInfo.BusinessType,
                MobileNo = RegInfo.MobileNo,
                PhoneNo = RegInfo.PhoneNo,
                CityName = RegInfo.CityName,
                StateName = RegInfo.StateName,
                CountryName = RegInfo.CountryName,
                Address = RegInfo.Address,
            };
        }

        [HttpPost]
        public IHttpActionResult AddRegistration([FromBody]SoftwareRegistrationViewModel value)
        {
            SavingResult res = new SavingResult();
            PostResultViewModel<SavingResult> result = new PostResultViewModel<SavingResult>();
            result.ResultObject = res;
            result.Success = false;
            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            try
            {
                using (DB_A05B1F_markerupdateEntities db = new DB_A05B1F_markerupdateEntities())
                {
                    if (value.EMailID == "")
                    {
                        res.ValidationError = "Can not accept blank value. Please enter valid email address.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return Ok(result);
                    }

                    var IsDuplicateResult = IsDuplicateRecord(value.EMailID, value.SoftwareRegistrationID, db);
                    if (IsDuplicateResult.Success)
                    {
                        if (IsDuplicateResult.ResultObject)
                        {
                            res.ValidationError = "Can not accept duplicate value. The Email id is already in use.";
                            res.ExecutionResult = eExecutionResult.ValidationError;
                            return Ok(result);
                        }
                    }
                    else
                    {
                        result.Success = false;
                        result.ErrorMessage = "Following error occurred while trying to check email validity. " + IsDuplicateResult.ErrorMessage;
                        res.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
                        return Ok(result);
                    }

                    tblSoftwareRegistration SaveModel = null;
                    if (value.SoftwareRegistrationID == 0) // New Entry
                    {
                        SaveModel = new tblSoftwareRegistration();
                        //SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoginInformations.LoggedinUser.UserID;
                        SaveModel.rcdt = DateTime.Now;
                        db.tblSoftwareRegistrations.Add(SaveModel);
                    }
                    else
                    {
                        SaveModel = db.tblSoftwareRegistrations.FirstOrDefault(r => r.SoftwareRegistrationID == value.SoftwareRegistrationID);
                        if (SaveModel == null)
                        {
                            res.ValidationError = "Selected registration is not exists/delted/invalid. Please retry or contact to your vendor.";
                            res.ExecutionResult = eExecutionResult.ValidationError;
                            return Ok(result);
                        }
                        //SaveModel.reuid = Model.CommonProperties.LoginInfo.LoginInformations.LoggedinUser.UserID;
                        SaveModel.redt = DateTime.Now;
                        db.tblSoftwareRegistrations.Attach(SaveModel);
                        db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                    }

                    //--
                    //SaveModel.SoftwareRegistrationID = value.SoftwareRegistrationID;
                    SaveModel.EmailID = value.EMailID;
                    SaveModel.Password = value.Password;
                    SaveModel.FullName = value.FullName ?? "";
                    SaveModel.CompanyName = value.CompanyName ?? "";
                    SaveModel.BusinessType = value.BusinessType ?? "";
                    SaveModel.Address = value.Address ?? "";
                    SaveModel.CityName = value.CityName ?? "";
                    SaveModel.StateName = value.StateName ?? "";
                    SaveModel.CountryName = value.CountryName ?? "";
                    SaveModel.PhoneNo = value.PhoneNo ?? "";
                    SaveModel.MobileNo = value.MobileNo ?? "";

                    //--
                    try
                    {
                        db.SaveChanges();
                        result.Success = true;
                        res.PrimeKeyValue = SaveModel.SoftwareRegistrationID;
                        res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    }
                    catch (Exception ex)
                    {
                        ex = CommonFunctions.GetFinalError(ex);
                        res.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
                        res.Exception = ex;
                    }
                }
            }
            catch (Exception ex)
            {
                ex = CommonFunctions.GetFinalError(ex);
                result.ErrorMessage = ex.Message;
            }
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult IsDuplicateRecord(string EMailID, int SoftwareRegistrationID)
        {
            try
            {
                using (DB_A05B1F_markerupdateEntities db = new DB_A05B1F_markerupdateEntities())
                {
                    return Ok(IsDuplicateRecord(EMailID, SoftwareRegistrationID, db));
                }
            }
            catch (Exception ex)
            {
                ex = CommonFunctions.GetFinalError(ex);
                PostResultViewModel<bool> result = new PostResultViewModel<bool>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return Ok(result);
            }
        }

        private PostResultViewModel<bool> IsDuplicateRecord(string EMailID, int SoftwareRegistrationID, DB_A05B1F_markerupdateEntities db)
        {
            PostResultViewModel<bool> result = new PostResultViewModel<bool>();
            try
            {
                if (db.tblSoftwareRegistrations.FirstOrDefault(i => i.EmailID == EMailID && i.SoftwareRegistrationID != SoftwareRegistrationID) != null)
                {
                    result.ResultObject = true;
                }
                result.Success = true;
            }
            catch (Exception ex)
            {
                ex = CommonFunctions.GetFinalError(ex);
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
