using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Account.Group
{
    public class AccountGroupDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return AccountGroupID; } set { AccountGroupID = value; } }

        [Browsable(false)]
        public long AccountGroupID { get; set; }

        [DisplayName("Account Group Name")]
        public string AccountGroupName { get; set; }

        [DisplayName("Parent")]
        public string ParentGroupName { get; set; }

        [DisplayName("Group Nature")]
        public eAccountGroupNature? AccountGroupNature { get; set; }
    }

    public class AccountGroupViewModel :  Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID
        {
            get
            {
                return AccountGroupID;
            }
            set
            {
                AccountGroupID = value;
            }
        }

        [Browsable(false)]
        public long AccountGroupID { get; set; }

        [DisplayName("AccountGroup Name")]
        public string AccountGroupName { get; set; }

        [Browsable(false)]
        public long? ParentGroupID { get; set; }

        [DisplayName("Group Nature")]
        public eAccountGroupNature? AccountGroupNature { get; set; }

        [Browsable(false)]
        public eAccountGroupType GroupTypeID { get; set; }

        [Browsable(false)]
        public bool? EffectsGrossProfit { get; set; }

        [Browsable(false)]
        public bool DefaultGroup { get; set; }
    }

    public class AccountGroupLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return AccountGroupID;}set  { AccountGroupID = value; } }

        [Browsable(false)]
        public long AccountGroupID { get; set; }

        [DisplayName("Account Group Name")]
        public string AccountGroupName { get; set; }

        [Browsable(false)]
        public eAccountGroupType GroupTypeID { get; set; }
    }

    public class AccountGroupDetailViewModel
    {
        [Browsable(false)]
        public long AccountGroupID { get; set; }

        [DisplayName("AccountGroup")]
        public string AccountGroupName { get; set; }

        [DisplayName("Parent")]
        public string ParentGroupName { get; set; }
    }
}
