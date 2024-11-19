using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Reports
{
    public class CompanyDetailReportModel
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

        public string CityName { get; set; }
        public string StateName { get; set; }
        public string StateNameShort { get; set; }
        public string CountryName { get; set; }
        public string CityInDetail
        {
            get
            {
                string City = CityName ?? "";
                if(!String.IsNullOrWhiteSpace(StateNameShort))
                {
                    City += (City != "" ? ", " : "") + StateNameShort;
                }
                if(!String.IsNullOrWhiteSpace(CountryName))
                {
                    City += (City != "" ? ", " : "") + CountryName;
                }

                return City;
            }
        }
        public string AddressWithCity
        {
            get
            {
                string Add = Address ?? "";
                if(!String.IsNullOrWhiteSpace(CityInDetail))
                {
                    Add += (Add != "" ? ", " : "") + CityInDetail;
                }
                return Add;
            }
        }
        public string ContactDetails
        {
            get
            {
                string Cont = "";

                if (!String.IsNullOrWhiteSpace(Phone1))
                {
                    Cont += (Cont != "" ? ", " : "") + "Ph : " + Phone1;
                }

                if (!String.IsNullOrWhiteSpace(MobileNo1))
                {
                    Cont += (Cont != "" ? ", " : "")  + "Mob. " + MobileNo1;
                }

                if (!String.IsNullOrWhiteSpace(EMailID))
                {
                    Cont += (Cont != "" ? ", " : "") + "E-Mail : " + EMailID;
                }

                return Cont;
            }
        }

        public int StateGSTCode { get; set; }
    }
}
