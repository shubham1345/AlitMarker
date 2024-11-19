using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Template
{
    public interface ILookupListViewModel : IDashboardViewModel
    {
        //int PrimeKeyID { get; set; }
    }

    public abstract class LookupListViewModel : ILookupListViewModel
    {
        public abstract long PrimeKeyID { get; set; }

        [Browsable(false)]
        public eRecordState RecordState { get; set; }
    }

    public interface IMultiSelectLookupListViewModel : ILookupListViewModel
    {
        //int PrimeKeyID { get; set; }

        bool Selected { get; set; }
    }

    public abstract class MultiSelectLookupListViewModel : IMultiSelectLookupListViewModel
    {
        [Browsable(false)]
        public abstract long PrimeKeyID { get; set; }

        [Browsable(false)]
        public bool Selected { get; set; }

        [Browsable(false)]
        public eRecordState RecordState { get; set; }
    }
}
