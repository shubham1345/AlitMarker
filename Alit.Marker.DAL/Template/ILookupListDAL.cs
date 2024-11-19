using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Template
{
    public interface ILookupListDAL
    {
        IEnumerable<ILookupListViewModel> GetLookupList();

        IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas);
    }

    public interface IMultiSelectLookupListDAL
    {
        IEnumerable<IMultiSelectLookupListViewModel> GetMultiSelectLookupList();

        IEnumerable<IMultiSelectLookupListViewModel> GetMultiSelectLookupList(object[] FilterParas);
    }
}
