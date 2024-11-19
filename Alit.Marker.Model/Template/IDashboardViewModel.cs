using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Template
{
    public interface IDashboardViewModel
    {
        long PrimeKeyID { get; set; }

        eRecordState RecordState { get; set; }
        
    }
}
