using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Settings
{
    public enum eMenuOptionType
    {
        Normal = 0,
        CRUD = 1,
        Report = 2
    }

    public class MenuOptionsViewModel
    {
        public long MenuOptionID { get; set; }

        public string MenuOptionName { get; set; }

        public string MenuOptionGroupName { get; set; }

        [Browsable(false)]
        public eMenuOptionType MenuType { get; set; }
    }
}
