using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.City.City
{
    public class CityViewModel : Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return CityID; } set { CityID = value; } }

        [Browsable(false)]
        public long CityID { get; set; }

        [DisplayName("City Name")]
        public string CityName { get; set; }

        [DisplayName("State")]
        //[Browsable(false)]
        public long? StateID { get; set; }
    }

    public class CityLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return CityID; } set { CityID = value; } }

        [Browsable(false)]
        public long CityID { get; set; }

        [DisplayName("City Name")]
        public string CityName { get; set; }

        [Browsable(false)]
        public long StateID { get; set; }

        [DisplayName("State Name")]
        public string StateName { get; set; }

        [DisplayName("Country Name")]
        public string CountryName { get; set; }                
    }

    public class CityDetailViewModel
    {
        [Browsable(false)]
        public long CityID { get; set; }

        [DisplayName("City")]
        public string CityName { get; set; }

        [Browsable(false)]
        public long? StateID { get; set; }

        [DisplayName("State")]
        public string StateName { get; set; }

        [Browsable(false)]
        public long CountryID { get; set; }

        [DisplayName("Country")]
        public string CountryName { get; set; }
    }
}