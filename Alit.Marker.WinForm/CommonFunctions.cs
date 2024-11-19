using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.WinForm
{
    public static class CommonFunctions
    {
        public static void SetCurrencyMask(DevExpress.XtraEditors.TextEdit TextBox)
        {
            TextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            TextBox.Properties.Mask.EditMask = Model.CommonProperties.UIDataFormats.CurrencyMask;
            TextBox.Properties.Mask.BeepOnError = true;
            TextBox.Properties.Mask.UseMaskAsDisplayFormat = true;
            TextBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        }

        public static void SetQuantityMask(DevExpress.XtraEditors.TextEdit TextBox)
        {
            TextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            TextBox.Properties.Mask.EditMask = Model.CommonProperties.UIDataFormats.QuantityFormat;
            TextBox.Properties.Mask.BeepOnError = true;
        }

        public static bool CheckParseInt(string strValue)
        {
            int v = 0;
            return int.TryParse(strValue, out v);
        }

        public static bool CheckParseLong(string strValue)
        {
            long v = 0;
            return long.TryParse(strValue, out v);
        }

        public static bool CheckParseDecimal(string strValue)
        {
            decimal v = 0;
            return decimal.TryParse(strValue, out v);
        }

        public static int ParseInt(string strValue)
        {
            int v = 0;
            int.TryParse(strValue, out v);
            return v;
        }

        public static long ParseLong(string strValue)
        {
            long v = 0;
            long.TryParse(strValue, out v);
            return v;
        }

        public static decimal ParseDecimal(string strValue)
        {
            decimal v = 0;
            decimal.TryParse(strValue, out v);
            return v;
        }

        public static bool CheckDateCurrentFinPer(DateTime DateValue)
        {
            return (Model.CommonProperties.LoginInfo.LoggedInFinPeriod != null &&
                DateValue >= Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom &&
                (Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo == null || 
                    DateValue <= Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo));
        }

        public static void gridViewlookupProductSelection_ColumnFormat(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridViewProductDetailLookUpProduct)
        {
            gridViewProductDetailLookUpProduct.PopupWidth = 1000;
            gridViewProductDetailLookUpProduct.NullText = "[Select Product]";

            gridViewProductDetailLookUpProduct.Columns.Clear();
            gridViewProductDetailLookUpProduct.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
            {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PCode", "P. Code", 100, DevExpress.Utils.FormatType.Numeric, "",
                Model.CommonProperties.LoginInfo.SoftwareSettings.ProductCode,
                DevExpress.Utils.HorzAlignment.Far),

            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Barcode", "Barcode", 150, DevExpress.Utils.FormatType.None, "",
                    Model.CommonProperties.LoginInfo.SoftwareSettings.ProductBarcode,
                    DevExpress.Utils.HorzAlignment.Near),

            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", "Name", 700, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            //new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size", 100, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrentStock", "Stock", 100, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitName", "Unit", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)
            });
        }
    }
}
