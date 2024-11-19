using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Template
{
    public interface IGridCRUDViewModel : IDashboardViewModel, IEditUserInfo
    {
        string RowError { get; set; }
    }

    public abstract class GridCRUDViewModel : EditUserInfo, IGridCRUDViewModel
    {

        [Browsable(false)]
        public abstract long PrimeKeyID { get; set; }

        [Browsable(false)]
        public eRecordState RecordState { get; set; }

        //[Browsable(false)]
        public string RowError { get; set; }
    }

}
