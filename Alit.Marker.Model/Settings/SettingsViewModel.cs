using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Settings
{
    public class SettingsViewModel
    {
        [Browsable(false)]
        public long SettingID { get; set; }

        [DisplayName("Auto User Login")]
        public bool AutoUserLogin { get; set; }
    }
}
