using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template;

namespace Alit.Marker.Model.Users.User
{
    public class UserDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return UserID; } set { UserID = value; } }

        [Browsable(false)]
        public long UserID { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Group")]
        public string UserGroupName { get; set; }
    }

    public class UserViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return UserID; } set { UserID = value; } }

        [Browsable(false)]
        public long UserID { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        public string Password { get; set; }

        public long UserGroupID { get; set; }

        public bool SuperAdmin { get; set; }
    }

    public class UserLookupModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return UserID; } set { UserID = value; } }

        [Browsable(false)]
        public long UserID { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }
    }

    public class UserDetailModel
    {
        [Browsable(false)]
        public long UserID { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        public long UserGroupID { get; set; }

        public string UserGroupName { get; set; }

        public bool SuperUser { get; set; }
    }
}
