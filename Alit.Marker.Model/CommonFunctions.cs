using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Alit.Marker.Model
{
    public static class CommonFunctions
    {
        public static object CloneObject(object Source)
        {
            object Destination = Activator.CreateInstance(Source.GetType());
            var fields = Destination.GetType().GetProperties();

            foreach (var field in fields)
            {
                var value = field.GetValue(Source);
                field.SetValue(Destination, value);
            }
            return Destination;
        }

        public static System.Data.Linq.Binary ConvertImageToBinary(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                return new System.Data.Linq.Binary(ms.GetBuffer());
            }
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static string NumbersToWords(decimal inputNumber)
        {
            long inputNo = (long)inputNumber;

            if (inputNo == 0)
                return "Zero";

            long[] numbers = new long[5];
            long first = 0;
            long u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (inputNo < 0)
            {
                sb.Append("Minus ");
                inputNo = -inputNo;
            }

            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ", "Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Lakh ", "Crore ", "Arab " };

            numbers[0] = inputNo % 1000; // units
            numbers[1] = inputNo / 1000;
            numbers[2] = inputNo / 100000;
            numbers[1] = numbers[1] - 100 * numbers[2]; // thousands
            numbers[3] = inputNo / 10000000; // crores
            numbers[2] = numbers[2] - 100 * numbers[3]; // lakhs
            numbers[4] = inputNo / 1000000000; // Arab
            numbers[3] = numbers[3] - 100 * numbers[4]; // crores


            for (int i = 4; i > 0; i--)
            {
                if (numbers[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (long i = first; i >= 0; i--)
            {
                if (numbers[i] == 0) continue;
                u = numbers[i] % 10; // ones
                t = numbers[i] / 10;
                h = numbers[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if ((h > 0 || i == 0) && sb.Length > 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }

            if(sb.Length > 0)
            {
                //sb.Append("Rs ");
                int DecValue = (int)(Math.Round(inputNumber - (decimal)inputNo, 2) * 100);
                if(DecValue > 0)
                {
                    string DecText = NumbersToWords(DecValue);
                    DecText = DecText.Substring(0, Math.Max(DecText.Length - 3, 0));
                    if (!DecText.Trim().StartsWith("and"))
                    {
                        DecText = "and " + DecText;
                    }
                    sb.Append(DecText);
                    sb.Append("Ps ");
                }
            }

            return "Rs. " + sb.ToString().TrimEnd();
        }

        public static Users.UserGroup.MenuOptionPermissionViewModel GetCurreUserPermission(long MenuOptionID)
        {
            return Model.CommonProperties.LoginInfo.UserPermission.FirstOrDefault(r => r.MenuOptionID == MenuOptionID);
        }

        public static void SendEmailFromNoReply(string SendToIds, string Subject, string MessageBody, params Attachment[] Attachments)
        {
            SendEmail("noreply@alittech.com", "ReplyMe@123.Com", SendToIds, Subject, MessageBody, false, Attachments);
        }

        public static async Task SendEmailFromNoReplyAsync(string SendToIds, string Subject, string MessageBody, params Attachment[] Attachments)
        {
            await SendEmailAsync("noreply@alittech.com", "ReplyMe@123.Com", SendToIds, Subject, MessageBody, false, Attachments);
        }

        //public static void SendEmail(string FromEmailID, string FromEmailPassword, string SendToIds, string Subject, string MessageBody, bool SSL, params Stream[] AttachmentStream)
        //{
        //    SendEmailAsync(FromEmailID, FromEmailPassword, SendToIds, Subject, MessageBody, SSL, AttachmentStream).RunSynchronously();
        //}

        public static void SendEmail(string FromEmailID,
                    string FromEmailPassword,
                    string SendToIds,
                    string Subject,
                    string MessageBody,
                    bool EnableSSL,
                    params Attachment[] Attachments)
        {
            // Command line argument must the the SMTP host.
            SmtpClient SMTPClient = new SmtpClient();
            SMTPClient.Host = CommonProperties.DevelopmentCompanyInfo.CompanyEmailSMTPHost;
            SMTPClient.Port = CommonProperties.DevelopmentCompanyInfo.CompanyEmailSMTPPort;
            SMTPClient.EnableSsl = EnableSSL;
            //SMTPClient.Timeout = 10000;
            SMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SMTPClient.UseDefaultCredentials = false;

            SMTPClient.Credentials = new System.Net.NetworkCredential(FromEmailID, FromEmailPassword);
            //MailMessage mm = new MailMessage("donotreply@domain.com", "sendtomyemail@domain.co.uk", "test", "test");
            //mm.BodyEncoding = UTF8Encoding.UTF8;
            //mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            MailMessage Mail = new MailMessage();// FromEmailID, SendToIds, Subject, MessageBody);
            Mail.From = new MailAddress(FromEmailID);
            Mail.To.Add(new MailAddress(SendToIds));
            Mail.Subject = Subject;
            Mail.Body = MessageBody;
            Mail.Priority = MailPriority.High;
            Mail.IsBodyHtml = true;
            Mail.BodyEncoding = Encoding.Default;

            foreach (var att in Attachments)
            {
                Mail.Attachments.Add(att);
            }

            try
            {
                SMTPClient.Send(Mail);
            }
            catch (Exception) { }
        }

        public static async Task SendEmailAsync(string FromEmailID, 
            string FromEmailPassword, 
            string SendToIds, 
            string Subject, 
            string MessageBody, 
            bool EnableSSL,
            params Attachment[] Attachments)
        {
            // Command line argument must the the SMTP host.
            SmtpClient SMTPClient = new SmtpClient();
            SMTPClient.Host = CommonProperties.DevelopmentCompanyInfo.CompanyEmailSMTPHost;
            SMTPClient.Port = CommonProperties.DevelopmentCompanyInfo.CompanyEmailSMTPPort;
            SMTPClient.EnableSsl = EnableSSL;
            //SMTPClient.Timeout = 10000;
            SMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SMTPClient.UseDefaultCredentials = false;

            SMTPClient.Credentials = new System.Net.NetworkCredential(FromEmailID, FromEmailPassword);

            //MailMessage mm = new MailMessage("donotreply@domain.com", "sendtomyemail@domain.co.uk", "test", "test");
            //mm.BodyEncoding = UTF8Encoding.UTF8;
            //mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            MailMessage Mail = new MailMessage(FromEmailID, SendToIds, Subject, MessageBody);

            foreach (var att in Attachments)
            {
                Mail.Attachments.Add(att);
            }

            try
            {
                await SMTPClient.SendMailAsync(Mail);
            }
            catch (Exception) { }
        }

        public static bool ValidateEmail(string Email)
        {
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            bool isValid = regex.IsMatch(Email);
            if (!isValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateWebSiteURL(string URL)
        {
            Regex regex = new Regex(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)");
            bool isValid = regex.IsMatch(URL);
            if (!isValid)
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
