using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.ERP.Masters.Transport
{
    public class TransportViewModel : Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return TransportID; } set { TransportID = value; } }

        [Browsable(false)]
        public long TransportID { get; set; }

        [DisplayName("Transport Name")]
        public string TransportName { get; set; }
    }

    public class TransportLookUpListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return (long)TransportID; } set { TransportID = value; } }

        [Browsable(false)]
        public long? TransportID { get; set; }

        [DisplayName("Transport Name")]
        public string TransportName { get; set; }
    }
}
