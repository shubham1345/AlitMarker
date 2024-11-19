using Alit.Marker.DBO;
using Alit.Marker.Model.Reports.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Reports.Customer
{
    public class CustomerListDAL
    {
        public List<CustomerListReportModel> GetReportData()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblCustomers
                        orderby r.CustomerNo
                       select new CustomerListReportModel()
                       {
                           CustomerID = r.CustomerID,
                           CustomerNo = r.CustomerNo,
                           CustomerNameTitle = r.NameTitle,
                           CustomerName = r.CustomerName,
                           CompanyName = r.CustomerCompanyName,
                           CustomerAddress = r.Address,
                           CustomerCityName = r.tblCity.CityName,
                           CustomerCityStateShortName = r.tblCity.tblState.StateShortName ?? r.tblCity.tblState.StateName,
                           CustomerCityCountryName = r.tblCity.tblCountry.CountryName,
                           CustomerPostCode = r.PostCode,
                           CustomerMobileNo = r.MobileNo,
                           CustomerPhoneNo = r.PhoneNo,
                           CustomerEMailID = r.EMailID,
                           CustomerWebsite = r.Website,
                           CustomerPAN = r.PAN,
                           CustomerGSTNo = r.GSTNo,
                           CustomerServiceTaxNo = r.ServiceTaxNo,
                       }).ToList();
            }
        }
    }
}
