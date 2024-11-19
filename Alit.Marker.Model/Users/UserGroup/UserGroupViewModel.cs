using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Users.UserGroup
{
    public class UserGroupViewModel : Template.GridCRUDViewModel,Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return UserGroupID; } set { UserGroupID = value; } }

        [Browsable(false)]
        public long UserGroupID { get; set; }

        [DisplayName("User Group Name")]
        public string UserGroupName { get; set; }

        public bool SuperAdminGroup { get; set; }
    }
    
    public class UserGroupLookupModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return UserGroupID; } set { UserGroupID = value; } }
        
        [Browsable(false)]
        public long UserGroupID { get; set; }

        [DisplayName("User Group Name")]
        public string UserGroupName { get; set; }
    }

    public class MenuOptionPermissionViewModel
    {
        [Browsable(false)]
        public long MenuOptionID { get; set; }

        [DisplayName("Menu")]
        public string MenuOptionName { get; set; }

        [DisplayName("Group")]
        public string MenuOptionGroupName { get; set; }

        [Browsable(false)]
        public Model.Settings.eMenuOptionType MenuOptionType { get; set; }

        [DisplayName("Can View")]
        public bool CanView { get; set; }

        [DisplayName("Can Add")]
        public bool CanAdd { get; set; }

        [DisplayName("Can Edit")]
        public bool CanEdit { get; set; }

        [DisplayName("Can Delete")]
        public bool CanDelete { get; set; }

        [DisplayName("Can Print")]
        public bool CanPrint { get; set; }
    }
}
