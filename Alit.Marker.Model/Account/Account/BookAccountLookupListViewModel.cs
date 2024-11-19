using Alit.Marker.Model.Account.Group;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Account.Account
{
    public class BookAccountLookUpListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return AccountID; } set { AccountID = value; } }

        [Browsable(false)]
        public long AccountID { get; set; }

        [DisplayName("Name")]
        public string AccountName { get; set; }

        [Browsable(false)]
        public eAccountGroupType? AccountGroupType { get; set; }
    }
}
