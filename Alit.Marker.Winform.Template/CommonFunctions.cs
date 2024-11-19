using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Template
{
    public static class CommonFunctions
    {
        public static void AcquireMaximumScreensize(this Form frm)
        {
            frm.Location = new Point(20, 20);
            Size screenSize = Screen.FromControl(frm).WorkingArea.Size;
            frm.Size = new Size(screenSize.Width - (frm.Left * 2), screenSize.Height - (frm.Top * 2));

        }

        public static Color GetThemeColorHightLightBackColor()
        {
            return GetThemeElementColor(DevExpress.Skins.CommonColors.Highlight);
        }
        public static Color GetThemeColorHightLightForeColor()
        {
            return GetThemeElementColor(DevExpress.Skins.CommonColors.HighlightText);
        }

        public static Color GetThemeColorDisableBackColor()
        {
            return GetThemeElementColor(DevExpress.Skins.CommonColors.DisabledControl);
        }
        public static Color GetThemeColorDisableForeColor()
        {
            return GetThemeElementColor(DevExpress.Skins.CommonColors.DisabledText);
        }

        public static Color GetThemeElementColor(string SkinElementName)
        {
            DevExpress.Skins.Skin currentSkin;

            currentSkin = DevExpress.Skins.CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
            //SkinElementName = DevExpress.Skins.CommonColors.HighlightText;
            Color ElementColor = currentSkin.Colors[SkinElementName];
            return ElementColor;
        }
    }
}
