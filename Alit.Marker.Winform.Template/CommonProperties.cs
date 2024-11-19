using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Template
{
    public static class CommonPropperties
    {
        public readonly static string DashboardGridLayoutFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AlitTechnologies\Marker\DashboardGridLayout";
        public readonly static string CrudGridLayoutFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AlitTechnologies\Marker\CRUDGridLayout";
        public readonly static string ReportGridLayoutFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AlitTechnologies\Marker\ReportGridLayout";
        public readonly static string SearchGridLayoutFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AlitTechnologies\Marker\SearchGridLayout";

        public static readonly Color RecordStateForeColor_Locked_ForeColor = CommonFunctions.GetThemeColorHightLightForeColor();
        public static readonly Color RecordStateForeColor_Locked_BackColor = CommonFunctions.GetThemeColorHightLightBackColor();
        public static readonly Color RecordStateForeColor_Deactivated_ForeColor = CommonFunctions.GetThemeColorDisableForeColor();
        public static readonly Color RecordStateForeColor_Deactivated_BackColor = CommonFunctions.GetThemeColorDisableBackColor();

        public static bool IsRunTime { get; set; }
    }
}
