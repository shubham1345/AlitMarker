using Alit.Marker.Model.City.City;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Settings.Compnay
{
    public class CompanyDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return CompanyID; } set { CompanyID = value; } }

        [Browsable(false)]
        public long CompanyID { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }
    }

    public class CompanyViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return CompanyID; } set { CompanyID = value; } }

        [Browsable(false)]
        public long CompanyID { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public long CityID { get; set; }

        public string PIN { get; set; }

        public string Phone1 { get; set; }

        public string MobileNo1 { get; set; }

        public string EMailID { get; set; }

        public string Website { get; set; }

        public string DirectorName { get; set; }

        public string PAN { get; set; }

        public string GSTIN { get; set; }

        public string ServiceTaxNo { get; set; }

        public string LicenseName { get; set; }

        public string LicenseNo { get; set; }

        public string Jurisdiction { get; set; }

        public string BankName { get; set; }

        public string BankCity { get; set; }

        public string BankBranch { get; set; }

        public string BankIFSC { get; set; }

        public string BankAccountNo { get; set; }

        public string BankAccountName { get; set; }

        public DateTime BusinessStartedFrom { get; set; }

        public long? CopySettingsFromCompanyID { get; set; }
    }

    public class CompanyLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return CompanyID; } set { CompanyID = value; } }

        [Browsable(false)]
        public long CompanyID { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
    }

    public class CompanyDetailViewModel
    {
        public long CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public long CityID { get; set; }
        public string PIN { get; set; }
        public string Phone1 { get; set; }
        public string MobileNo1 { get; set; }
        public string EMailID { get; set; }
        public string Website { get; set; }
        public string PAN { get; set; }
        public string GSTIN { get; set; }
        public string LicenseName { get; set; }
        public string LicenseNo { get; set; }
        public string Jurisdiction { get; set; }
        public DateTime BusinessStartedFrom { get; set; }
        public string DirectorName { get; set; }
        public string ServiceTaxNo { get; set; }
        public string BankName { get; set; }
        public string BankCity { get; set; }
        public string BankBranch { get; set; }
        public string BankIFSC { get; set; }
        public string BankAccountNo { get; set; }
        public string BankAccountName { get; set; }

        public CityDetailViewModel City { get; set; }

        [DisplayName("Full Address")]
        public string FullCityName
        {
            get
            {
                string city = City.CityName;
                city += (!String.IsNullOrWhiteSpace(City.StateName) ? (!String.IsNullOrWhiteSpace(city) ? ", " : "") + City.StateName : "");
                city += (!String.IsNullOrWhiteSpace(City.CountryName) ? (!String.IsNullOrWhiteSpace(city) ? ", " : "") + City.CountryName : "");
                return city;
            }
        }


        [DisplayName("Full Address")]
        public string FullAddress
        {
            get
            {
                string add = Address;
                add += (!String.IsNullOrWhiteSpace(FullCityName) ? (!String.IsNullOrWhiteSpace(add) ? ", " : "") + FullCityName : "");
                add += (!String.IsNullOrWhiteSpace(PIN) ? (!String.IsNullOrWhiteSpace(add) ? ", " : "") + PIN : "");
                return add;
            }
        }

        //[DisplayName("Address")]
        //public string Address
        //{
        //    get
        //    {
        //        string add = null;
        //        add += (!String.IsNullOrWhiteSpace(Address1) ? (!String.IsNullOrWhiteSpace(add) ? ", " : "") + Address1 : "");
        //        add += (!String.IsNullOrWhiteSpace(Address2) ? (!String.IsNullOrWhiteSpace(add) ? ", " : "") + Address2 : "");
        //        add += (!String.IsNullOrWhiteSpace(Address3) ? (!String.IsNullOrWhiteSpace(add) ? ", " : "") + Address3 : "");
        //        return add;
        //    }
        //}

    }

}
