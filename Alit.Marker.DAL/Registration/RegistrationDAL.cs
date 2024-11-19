using Alit.Marker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Alit.Marker.Service.Update.Model;
using Alit.Marker.DBO;

namespace Alit.Marker.DAL.Registration
{
    public class RegistrationDAL
    {
        public PostResultViewModel<SoftwareRegistrationViewModel> GetRegistrationFromAdmin(string EmailID, string Password)
        {
            return WebFunctions.GetMarkerAdminAPI<SoftwareRegistrationViewModel>("/SoftwareRegistration/GetRegistration?EmailID=" + EmailID + "&password=" + Password);
        }

        public SoftwareRegistrationViewModel GetSavedRegistration()
        {
            return ConvertToViewModel(GetSavingObject());
        }

        public tblSoftwareRegistration GetSavingObject()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return db.tblSoftwareRegistrations.FirstOrDefault();
            }
        }

        public SoftwareRegistrationViewModel ConvertToViewModel(tblSoftwareRegistration RegInfo)
        {
            if (RegInfo == null) return null;

            return new SoftwareRegistrationViewModel()
            {
                SoftwareRegistrationID = (int)RegInfo.SoftwareRegistrationID,
                EMailID = RegInfo.EMailID,
                //Password = RegInfo.Password,
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


        public SavingResult SaveRegistration(SoftwareRegistrationViewModel ViewModel)
        {
            bool NewEntry = ViewModel.SoftwareRegistrationID == 0;
            
            var APIresult = WebFunctions.PostMarkerAdminAPIAsync<SoftwareRegistrationViewModel, SavingResult>("/SoftwareRegistration/AddRegistration", ViewModel).Result;
            //var APIresult = WebFunctions.GetMarkerAdminAPI<SavingResult>("/SoftwareRegistration/AddRegistration?" + 
            //    "SoftwareRegistrationID=" + SaveModel.SoftwareRegistrationID.ToString() + "&"+
            //    "EMailID=" + SaveModel.EMailID + "&" + 
            //    "Password=" + SaveModel.Password + "&" +
            //    "FullName=" + SaveModel.FullName + "&" +
            //    "CompanyName=" + SaveModel.CompanyName + "&" +
            //    "BusinessType=" + SaveModel.BusinessType + "&" +
            //    "MobileNo=" + SaveModel.MobileNo + "&" + 
            //    "PhoneNo=" + SaveModel.PhoneNo + "&" + 
            //    "CityName=" + SaveModel.CityName + "&" + 
            //    "StateName=" + SaveModel.StateName + "&" +
            //    "CountryName=" + SaveModel.CountryName + "&" + 
            //    "Address=" + SaveModel.Address);

            if (!APIresult.Success || APIresult.ResultObject.ExecutionResult != Service.Update.Model.eExecutionResult.CommitedSucessfuly)
            {
                if (APIresult.ResultObject != null)
                {
                    return new SavingResult()
                    {
                        Exception = APIresult.ResultObject.Exception,
                        ExecutionResult = (eExecutionResult)(int)APIresult.ResultObject.ExecutionResult,
                        MessageAfterSave = APIresult.ResultObject.MessageAfterSave,
                        PrimeKeyValue = APIresult.ResultObject.PrimeKeyValue,
                        ValidationError = APIresult.ResultObject.ValidationError
                    };
                }
                else
                {
                    return new SavingResult()
                    {
                        Exception = new Exception("Resultobject is null"),
                        ExecutionResult = eExecutionResult.ErrorWhileExecuting,
                    };
                }
            }
            ViewModel.SoftwareRegistrationID = (int)APIresult.ResultObject.PrimeKeyValue;
            //--
            SavingResult res = new SavingResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblSoftwareRegistration SaveModel = new tblSoftwareRegistration()
                {
                    SoftwareRegistrationID = ViewModel.SoftwareRegistrationID,
                    EMailID = ViewModel.EMailID,
                    Password = ViewModel.Password,
                    FullName = ViewModel.FullName,
                    CompanyName = ViewModel.CompanyName,
                    BusinessType = ViewModel.BusinessType,
                    Address = ViewModel.Address,
                    CityName = ViewModel.CityName,
                    StateName = ViewModel.StateName,
                    CountryName = ViewModel.CountryName,
                    MobileNo = ViewModel.MobileNo,
                    PhoneNo = ViewModel.PhoneNo,
                };
                if (NewEntry) // New Entry
                {
                    SaveModel.rcuid = (Model.CommonProperties.LoginInfo.LoggedinUser != null ? (long?)Model.CommonProperties.LoginInfo.LoggedinUser.UserID : null);
                    SaveModel.rcdt = DateTime.Now;
                    db.tblSoftwareRegistrations.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = (Model.CommonProperties.LoginInfo.LoggedinUser != null ? (long?)Model.CommonProperties.LoginInfo.LoggedinUser.UserID : null);
                    SaveModel.redt = DateTime.Now;
                    db.tblSoftwareRegistrations.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = ViewModel.SoftwareRegistrationID;
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

        public SavingResult SaveRegistrationLocal(tblSoftwareRegistration SaveModel, bool NewEntry)
        {
            SavingResult res = new SavingResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                if (NewEntry) // New Entry
                {
                    SaveModel.rcuid = (Model.CommonProperties.LoginInfo.LoggedinUser != null ? (long?)Model.CommonProperties.LoginInfo.LoggedinUser.UserID : null);
                    SaveModel.rcdt = DateTime.Now;
                    db.tblSoftwareRegistrations.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = (Model.CommonProperties.LoginInfo.LoggedinUser != null ? (long?)Model.CommonProperties.LoginInfo.LoggedinUser.UserID : null);
                    SaveModel.redt = DateTime.Now;
                    db.tblSoftwareRegistrations.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.SoftwareRegistrationID;
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

        public async Task<bool> IsDuplicateRecord(string EMailID, int SoftwareRegistrationID)
        {
            var res = await WebFunctions.GetMarkerAdminAPIAsync<bool>("/SoftwareRegistration/IsDuplicateRecord?" + 
                "EMailID=" + System.Web.HttpUtility.UrlEncode(EMailID) + "&" +
                "SoftwareRegistrationID=" + System.Web.HttpUtility.UrlEncode(SoftwareRegistrationID.ToString()));

            // if successfully received result and found duplicate than only send true value to update UI for validation message.
            if (res.Success && res.ResultObject)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
