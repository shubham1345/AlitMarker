using Alit.Marker.Model.ERP.Transaction.Sales.SaleInvoice;
using Alit.Marker.Model.Reports.Sales;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleInvoice.InvoiceFormats
{
    public static class InvoiceFormatController
    {
        public static XtraReport GetSelectedInvoiceFormat()
        {
            switch ((eInvoiceFormats)Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoicePrintDefaultFormatNo)
            {
                case eInvoiceFormats.None:
                case eInvoiceFormats.Standard_A4:
                    return new rptInvoicePrintStandardA4();
                case eInvoiceFormats.Standard_A5:
                    return new rptInvoicePrintStandardA5();
                case eInvoiceFormats.Standard_A6:
                    return new rptInvoicePrintStandardA6();
                case eInvoiceFormats.Customized:
                    if (!String.IsNullOrWhiteSpace(Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoicePrintCustomFormatFileName)
                        && System.IO.File.Exists(Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoicePrintCustomFormatFileName))
                    {
                        try
                        {
                            return DevExpress.XtraReports.UI.XtraReport.FromFile(Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoicePrintCustomFormatFileName, true);
                        }
                        catch (Exception ex)
                        {
                            ex = DAL.CommonFunctions.GetFinalError(ex);
                            Alit.WinformControls.MessageBox.Show("Following error occured while trying to load customized invoice format. We are loading default invoice format. Please contact to your vendor and provide following error details.\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
            }
            return new rptInvoicePrintStandardA4();
        }
    }
}
