using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Template
{
    public abstract class DashboardViewModel : EditUserInfo, IDashboardViewModel
    {
        public abstract long PrimeKeyID { get; set; }

        [DisplayName("Status")]
        public virtual eRecordState RecordState { get; set; }
    }
}
