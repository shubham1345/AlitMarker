using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Alit.Marker.Service.Update
{
    public class LogRequestAndResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string IPAddress = request.GetClientIpAddress();
            string CallingAPI = "";
            string Parameters = "";
            //Web-hosting
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                HttpContextWrapper ctx = (HttpContextWrapper)request.Properties["MS_HttpContext"];
                if (ctx != null)
                {
                    CallingAPI = ctx.Request.Url.AbsolutePath;
                    Parameters = ctx.Request.Url.Query;
                }
            }

            // log request body
            string requestBody = await request.Content.ReadAsStringAsync();

            DAL.tblServiceRequestLog SRLog = new DAL.tblServiceRequestLog()
            {
                CallingAPI = CallingAPI,
                Parameteres = Parameters,
                RequestTime = DateTime.Now,
                RequestBody = requestBody,
                IPAddress = IPAddress,
            };

            Task InsertLog = null;
            DAL.DB_A05B1F_markerupdateEntities dbLog = null; 
            try
            {
                dbLog = new DAL.DB_A05B1F_markerupdateEntities();
                dbLog.tblServiceRequestLogs.Add(SRLog);
                InsertLog = dbLog.SaveChangesAsync();
                //using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
                //{
                //    db.tblServiceRequestLogs.Add(SRLog);
                //    InsertLog = db.SaveChangesAsync();
                //}
            }
            catch (Exception ex)
            {
                Alit.Marker.Service.Update.CommonFunctions.GetFinalError(ex);

                using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
                {
                    SRLog.ServiceRequestLogID = 0;
                    SRLog.ResponseTime = DateTime.Now;
                    SRLog.ResponseBody = "Error : " + ex.Message;
                    db.tblServiceRequestLogs.Add(SRLog);
                    db.SaveChanges();
                }
            }

            // let other handlers process the request
            var result = await base.SendAsync(request, cancellationToken);

            SRLog.ResponseTime = DateTime.Now;
            if (result.Content != null)
            {
                // once response body is ready, log it
                var responseBody = await result.Content.ReadAsStringAsync();
                //Trace.WriteLine(responseBody);
                SRLog.ResponseBody = responseBody;
            }

            if(InsertLog != null)
            {
                await InsertLog;
                dbLog.Dispose();
                dbLog = null;
            }
            try
            {
                using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
                {
                    //SRLog = db.tblServiceRequestLogs.Find(SRLog.ServiceRequestLogID);
                    if (SRLog != null)
                    {
                        db.tblServiceRequestLogs.Attach(SRLog);
                        db.Entry(SRLog).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        db.tblServiceRequestLogs.Add(new DAL.tblServiceRequestLog()
                        {
                            CallingAPI = CallingAPI,
                            Parameteres = Parameters,
                            RequestTime = DateTime.Now,
                            RequestBody = requestBody,
                            IPAddress = IPAddress,
                        });

                    }
                    await db.SaveChangesAsync();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Alit.Marker.Service.Update.CommonFunctions.GetFinalError(ex);

                using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
                {
                    SRLog.ServiceRequestLogID = 0;
                    SRLog.ResponseTime = DateTime.Now;
                    SRLog.ResponseBody = "Error : " + ex.Message;
                    db.tblServiceRequestLogs.Add(SRLog);
                    db.SaveChanges();
                }
            }
            return result;
        }
    }

    public static class HttpRequestMessageExtensions
    {
        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
        private const string OwinContext = "MS_OwinContext";

        [Obsolete("See IsLocal at HttpRequestMessageExtensions Version 5.0.0.0")]
        public static bool IsLocal(this HttpRequestMessage request)
        {
            var localFlag = request.Properties["MS_IsLocal"] as Lazy<bool>;
            return localFlag != null && localFlag.Value;
        }

        public static string GetClientIpAddress(this HttpRequestMessage request)
        {
            //Web-hosting
            if (request.Properties.ContainsKey(HttpContext))
            {
                dynamic ctx = request.Properties[HttpContext];
                if (ctx != null)
                {
                    return ctx.Request.UserHostAddress;
                }
            }
            //Self-hosting
            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }
            //Owin-hosting
            if (request.Properties.ContainsKey(OwinContext))
            {
                dynamic ctx = request.Properties[OwinContext];
                if (ctx != null)
                {
                    return ctx.Request.RemoteIpAddress;
                }
            }
            return null;
        }
    }
}