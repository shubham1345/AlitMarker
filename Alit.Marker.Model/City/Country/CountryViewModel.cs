using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.City.Country
{
    public class CountryViewModel : Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID
        {
            get
            {
                return CountryID;
            }
            set
            {
                CountryID = value;
            }
        }

        [Browsable(false)]
        public long CountryID { get; set; }

        [DisplayName("Country Name")]
        public string CountryName { get; set; }        
    }

    public class CountryLookupModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return CountryID; } set { CountryID = value; } }

        [Browsable(false)]
        public long CountryID { get; set; }

        [DisplayName("Country Name")]
        public string CountryName { get; set; }

    }
}
