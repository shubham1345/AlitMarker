using Alit.Marker.Model.Template.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Template.Report
{
    public interface IReportDAL
    {
        IEnumerable<IReportViewModel> GetReportData();

        IEnumerable<IReportViewModel> GetReportData(params object[] FilterParas);
    }
}
