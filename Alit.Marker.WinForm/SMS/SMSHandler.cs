using Alit.WinformControls;
using Alit.Marker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Alit.Marker.DBO;

namespace Alit.Marker.WinForm.SMS
{
    public static class SMSHandler
    {
        private static string BaseSMSUrl = "http://sms.badshahsoft.com/api/";

        public static bool SendSMS(string MobileNo, string SenderID, string Message, string OptionName, long UserID)
        {
            bool Result = false;

            //Your authentication key
            string authKey = CommonProperties.LoginInfo.SoftwareSettings.SMSAuthKey;
            //Multiple mobiles numbers separated by comma
            string mobileNumber = MobileNo;
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderId = SenderID;
            //Your message to send, Add URL encoding here.
            string message = HttpUtility.UrlEncode(Message);

            //Prepare you post parameters
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
            sbPostData.AppendFormat("&message={0}", message);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", "4");

            tblSMSLog SMSLog = new tblSMSLog()
            {
                MobileNo = mobileNumber,
                SMSText = Message,
                OptionName = OptionName,
                SendDateTime = DateTime.Now,
                DeliveryStatus = "Sent",
                SenderID = senderId,
                UserID = UserID
            };

            string responseString = "";
            try
            {
                //Call Send SMS API
                string sendSMSUri = BaseSMSUrl + "sendhttp.php";
                //Create HTTPWebrequest
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                responseString = reader.ReadToEnd();

                if (responseString.Length == 24)
                {
                    SMSLog.SMSID = responseString;
                }
                SMSLog.SMSAPIResponse = responseString;

                //Close the response
                reader.Close();
                response.Close();

                Result = true;
            }
            catch (SystemException ex)
            {
                SMSLog.DeliveryStatus = "Error";
                SMSLog.Error = ex.Message;
                Alit.WinformControls.MessageBox.Show("Unable to send SMS, please check following error:\r\n\r\n" + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Task.Run(async () =>
            {
                await UpdateDisplaySMSBalanceAsync();
            });

            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                db.tblSMSLogs.Add(SMSLog);


                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    while (ex != null && ex.Message == "An error occurred while updating the entries. See the inner exception for details.")
                    {
                        ex = ex.InnerException;
                    }

                    string ValidationError = null;
                    if (ex.GetType() == typeof(System.Data.Entity.Validation.DbEntityValidationException))
                    {
                        ValidationError = "SMS Sent but Validation Errors occurred while saving log : \r\n\r\n";

                        System.Data.Entity.Validation.DbEntityValidationException ValidationException = (System.Data.Entity.Validation.DbEntityValidationException)ex;

                        foreach (System.Data.Entity.Validation.DbEntityValidationResult ValidRes in ValidationException.EntityValidationErrors)
                        {
                            foreach (System.Data.Entity.Validation.DbValidationError ValidError in ValidRes.ValidationErrors)
                            {
                                ValidationError += ValidError.PropertyName + " = " + ValidError.ErrorMessage + "\r\n";
                            }
                            ValidationError += "\r\n";
                        }
                    }
                    if(!String.IsNullOrWhiteSpace(ValidationError))
                    {
                        Alit.WinformControls.MessageBox.Show(ValidationError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Alit.WinformControls.MessageBox.Show("SMS Sent but error occurred while saving log : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return Result;
        }

        public static long GetBalance()
        {
            //Your authentication key
            string authKey = CommonProperties.LoginInfo.SoftwareSettings.SMSAuthKey;

            //Prepare you post parameters
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&type={0}", 4);

            try
            {
                //Call Send SMS API
                string sendSMSUri = BaseSMSUrl + "balance.php";
                //Create HTTPWebrequest
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                //Close the response
                reader.Close();
                response.Close();

                long Balance = 0;
                long.TryParse(responseString, out Balance);
                return Balance;
            }
            catch (SystemException ex)
            {
                Alit.WinformControls.MessageBox.Show("Unable to get balance, please check following error:\r\n\r\n" + ex.Message.ToString());
            }
            return 0;
        }

        public static async Task<long> GetBalanceAsync()
        {
            //Your authentication key
            string authKey = CommonProperties.LoginInfo.SoftwareSettings.SMSAuthKey;

            //Prepare you post parameters
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&type={0}", 4);

            try
            {
                //Call Send SMS API
                string sendSMSUri = BaseSMSUrl + "balance.php";
                //Create HTTPWebrequest
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                var response = await httpWReq.GetResponseAsync();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = await reader.ReadToEndAsync();

                //Close the response
                reader.Close();
                response.Close();

                long Balance = 0;
                long.TryParse(responseString, out Balance);
                return Balance;
            }
            catch (SystemException ex)
            {
                Alit.WinformControls.MessageBox.Show("Unable to get balance, please check following error:\r\n\r\n" + ex.Message.ToString());
            }
            return 0;
        }

        public static void UpdateDisplaySMSBalance()
        {
            Navigation.frmNavigationDashboard.DashBoard.lblSmsBalance.Caption = "SMS Balance : "  + GetBalance().ToString();
        }

        public static async Task UpdateDisplaySMSBalanceAsync(int WaitSeconds = 10)
        {
            //Task.Run(async () =>
            //{
                DateTime WaitTill = DateTime.Now.AddSeconds(WaitSeconds);
                await Task.Run(() =>
                {
                    while (DateTime.Now < WaitTill) { }
                });

                Navigation.frmNavigationDashboard.DashBoard.lblSmsBalance.Caption = "SMS Balance : " + (await GetBalanceAsync()).ToString();
            //});
        }
    }
}
