using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.City.State
{
    public class StateViewModel : Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return StateID; } set { StateID = value; } }

        [Browsable(false)]
        public long StateID { get; set; }

        [DisplayName("State Name")]
        public string StateName { get; set; }

        [DisplayName("Country")]
        public long CountryID { get; set; }
    }

    public class StateLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return StateID; } set { StateID = value; } }
       
        [Browsable(false)]
        public long StateID { get; set; }

        [DisplayName("State Name")]
        public string StateName { get; set; }

        [DisplayName("Country Name")]
        public string CountryName { get; set; }                
    }
}
