using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Template
{
    public class EditUserInfo : IEditUserInfo
    {
        [Browsable(false)]
        public DateTime? CreatedDateTime { get; set; }

        [Browsable(false)]
        public long? CreatedUserID { get; set; }

        [Browsable(false)]
        public string CreatedUserName { get; set; }

        [Browsable(false)]
        public DateTime? EditedDateTime { get; set; }

        [Browsable(false)]
        public long? EditedUserID { get; set; }

        [Browsable(false)]
        public string EditedUserName { get; set; }
    }
}
