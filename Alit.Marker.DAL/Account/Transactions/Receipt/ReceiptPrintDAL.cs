using Alit.Marker.DBO;
using Alit.Marker.Model.Account.Transactions.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Account.Transactions.Receipt
{
    public class ReceiptPrintDAL
    {
        public List<ReceiptPrintModel> GenerateReportData(DateTime? DateFrom, DateTime? DateTo, long? AccountID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return ConvertToModel(db.tblReceipts.Where(wr =>
                    (DateFrom == null || wr.ReceiptDate >= DateFrom) &&
                    (DateTo == null || wr.ReceiptDate <= DateTo) &&
                    //(CustomerID == null || wr.CustomerID == CustomerID)
                    (AccountID == null || wr.AccountID == AccountID)
                    )
                    );
            }
        }

        public List<ReceiptPrintModel> ConvertToModel(IQueryable<tblReceipt> ReceiptRecords)
        {
            List<ReceiptPrintModel> DS = ReceiptRecords.Select<tblReceipt, ReceiptPrintModel>(r => new ReceiptPrintModel()
            {
                ReceiptID = r.ReceiptID,
                PaymentMode = ((Model.CashBank.eModeOfPayment)r.PaymentType),

                ReceiptDate = r.ReceiptDate,
                ReceiptNo = r.ReceiptNo,

                Customer = new Model.Reports.CustomerPrintDetailModel()
                {
                    //CustomerID = r.CustomerID,
                    //CustomerNameTitle = r.tblCustomer.NameTitle,
                    //CustomerName = r.tblCustomer.CustomerName,
                    //CustomerAddress = r.tblCustomer.Address,
                    //CustomerCityName = r.tblCustomer.tblCity.CityName,
                    //CustomerCityStateShortName = r.tblCustomer.tblCity.tblState.StateShortName ?? r.tblCustomer.tblCity.tblState.StateName,
                    //CustomerCityCountryName = r.tblCustomer.tblCity.tblCountry.CountryName,
                    //CustomerPostCode = r.tblCustomer.PostCode,
                    //CustomerMobileNo = r.tblCustomer.MobileNo,
                    //CustomerPhoneNo = r.tblCustomer.PhoneNo,
                    //CustomerEMailID = r.tblCustomer.EMailID,
                    //CustomerWebsite = r.tblCustomer.Website,
                    //CustomerPAN = r.tblCustomer.PAN,
                    //CustomerGSTNo = r.tblCustomer.GSTNo,
                    //CustomerServiceTaxNo = r.tblCustomer.ServiceTaxNo,
                },
                Amount = r.Amount,
                Remarks = r.Remarks
            }).ToList();

            DS.ForEach(r =>
            {
                r.CompanyDetail = Model.CommonProperties.LoginInfo.LoggedInCompanyReportModel;
                r.AmtInWords = Model.CommonFunctions.NumbersToWords(r.Amount);
            });

            return DS;
        }

        public List<ReceiptPrintModel> GetReceiptByID(long ReceiptID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return ConvertToModel(db.tblReceipts.Where(wr => wr.ReceiptID == ReceiptID));
            }
        }
    }
}
