
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Template
{
    public class GeneralizeReportGeneratorParameters
    {
        #region Public Properties

        public PaperKind PaperSize { get; set; }
        public bool Landscape { get; set; }

        public Margins PageMargin { get; set; }

        public IPrintable GridContorl { get; set; }


        public string ReportHeaderLine1 { get; set; }

        public string ReportHeaderLine2 { get; set; }


        public string PageHeaderLine1 { get; set; }

        public string PageHeaderLine2 { get; set; }
        #endregion

        public GeneralizeReportGeneratorParameters(IPrintable gridContorl) : this(gridContorl, PaperKind.A4)
        {

        }
        public GeneralizeReportGeneratorParameters(IPrintable gridContorl, PaperKind paperSize) : this(gridContorl, paperSize, new Margins(25, 25, 25, 35))
        {

        }
        public GeneralizeReportGeneratorParameters(IPrintable gridContorl, PaperKind paperSize, Margins pageMargin) : this(gridContorl, paperSize, pageMargin, false)
        {

        }
        public GeneralizeReportGeneratorParameters(IPrintable gridContorl, PaperKind paperSize, Margins pageMargin, bool landscape)
        {
            this.GridContorl = gridContorl;
            this.PaperSize = paperSize;
            this.PageMargin = pageMargin;
            this.Landscape = landscape;

            ReportHeaderLine1 = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyName;

            ReportHeaderLine2 = Model.CommonProperties.LoginInfo.LoggedInCompany.FullAddress;
            //ReportHeaderLine2 += (!String.IsNullOrWhiteSpace(Model.CommonProperties.LoginInfo.LoggedInCompany.PhoneNo) ? (!String.IsNullOrWhiteSpace(ReportHeaderLine2) ? ", " : "")
            //    + "Phone No. " + Model.CommonProperties.LoginInfo.LoggedInCompany.PhoneNo : "");
            //ReportHeaderLine2 += (!String.IsNullOrWhiteSpace(Model.CommonProperties.LoginInfo.LoggedInCompany.EMailID) ? (!String.IsNullOrWhiteSpace(ReportHeaderLine2) ? ", " : "")
            //    + "E-Mail ID: " + Model.CommonProperties.LoginInfo.LoggedInCompany.EMailID : "");
            //ReportHeaderLine2 += (!String.IsNullOrWhiteSpace(Model.CommonProperties.LoginInfo.LoggedInCompany.Website) ? (!String.IsNullOrWhiteSpace(ReportHeaderLine2) ? ", " : "")
            //    + "Website: " + Model.CommonProperties.LoginInfo.LoggedInCompany.Website : "");
        }
    }

    public class GeneralizeReportGenerator : IDisposable
    {
        #region Public enums
        public enum eGeneralizeReportHeaderFontSize
        {
            Line1 = 16,
            Line2 = 11,
            Line3 = 14,
            Line4 = 10,
        }
        #endregion

        public GeneralizeReportGeneratorParameters Parameters { get; private set; }

        public PrintingSystem ReportPrintingSystem { get; set; }

        public PrintableComponentLink ReportPrintableComponentLink { get; set; }


        #region Private Fields
        string DefaultFontName;
        Size DefaultTextSize;
        Size PageHeaderLine2Size;
        #endregion

        public GeneralizeReportGenerator(GeneralizeReportGeneratorParameters parameters)
        {
            Parameters = parameters;
            DefaultFontName = "Arial";
            //--

            ReportPrintingSystem = new DevExpress.XtraPrinting.PrintingSystem();
            ReportPrintingSystem.ContinuousPageNumbering = true;


            ReportPrintableComponentLink = new DevExpress.XtraPrinting.PrintableComponentLink();
            ReportPrintingSystem.Links.AddRange(new object[] { ReportPrintableComponentLink });
            ReportPrintableComponentLink.Component = Parameters.GridContorl;
            ReportPrintableComponentLink.PrintingSystem = ReportPrintingSystem;
            ReportPrintableComponentLink.PrintingSystemBase = ReportPrintingSystem;
            ReportPrintableComponentLink.PaperKind = Parameters.PaperSize;
            ReportPrintableComponentLink.Landscape = Parameters.Landscape;


            PageHeaderFooter phf = ReportPrintableComponentLink.PageHeaderFooter as PageHeaderFooter;
            phf.Footer.LineAlignment = BrickAlignment.Far;
            phf.Footer.Content.AddRange(new string[] { "Page " + "[Page # of Pages #]", "", $"Print Date : {DateTime.Now.ToString($"{CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern} {CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern  }") }" });

            ReportPrintableComponentLink.CreateMarginalHeaderArea += PrintableComponentLink1_CreateMarginalHeaderArea;

            DefaultTextSize = new Size((int)ReportPrintableComponentLink.PrintingSystem.PageBounds.Width - 50,
                new Font(DefaultFontName, 10, FontStyle.Bold).Height);

            //--
            int TopMargin = Parameters.PageMargin.Top;

            if (!string.IsNullOrWhiteSpace(Parameters.ReportHeaderLine1))
            {
                TopMargin = TopMargin + (new Font(DefaultFontName, (int)eGeneralizeReportHeaderFontSize.Line1, FontStyle.Bold)).Height;
            }
            if (!string.IsNullOrWhiteSpace(Parameters.ReportHeaderLine2))
            {
                TopMargin = 5 + TopMargin + (new Font(DefaultFontName, (int)eGeneralizeReportHeaderFontSize.Line2, FontStyle.Regular)).Height;
            }
            if (!string.IsNullOrWhiteSpace(Parameters.PageHeaderLine1))
            {
                TopMargin = 10 + TopMargin + (new Font(DefaultFontName, (int)eGeneralizeReportHeaderFontSize.Line3, FontStyle.Bold)).Height + 10;
            }

            if (!string.IsNullOrWhiteSpace(Parameters.PageHeaderLine2))
            {
                Font LineFont = (new Font(DefaultFontName, (int)eGeneralizeReportHeaderFontSize.Line4, FontStyle.Bold));
                //Size TextSize = TextRenderer.MeasureText(PageHeaderLine2, LineFont);

                PageHeaderLine2Size = TextRenderer.MeasureText(Parameters.PageHeaderLine2,
                                            (new Font(DefaultFontName, (int)eGeneralizeReportHeaderFontSize.Line4,
                                                FontStyle.Bold)), DefaultTextSize, TextFormatFlags.WordBreak);

                TopMargin = 5 + TopMargin + PageHeaderLine2Size.Height;
            }
            ReportPrintableComponentLink.Margins = parameters.PageMargin;
            ReportPrintableComponentLink.Margins.Top = TopMargin;
        }

        public void PrintPreview()
        {
            //ReportPrintableComponentLink.ShowRibbonPreviewDialog(Navigation.frmNavigationDashboard.Dashboard.defaultLookAndFeel1.LookAndFeel);
            ReportPrintableComponentLink.ShowRibbonPreviewDialog(null);
        }

        public void Print()
        {
            ReportPrintableComponentLink.PrintDlg();
        }

        public void ExportToPDF(string FileName)
        {
            ReportPrintableComponentLink.ExportToPdf(FileName);
        }

        public void ExportToExcel(string FileName)
        {
            ReportPrintableComponentLink.ExportToXlsx(FileName);
        }

        public void ExportToWord(string FileName)
        {
            ReportPrintableComponentLink.ExportToDocx(FileName);
        }

        public void ExportToCSV(string FileName)
        {
            ReportPrintableComponentLink.ExportToCsv(FileName);
        }

        public void ExportToText(string FileName)
        {
            ReportPrintableComponentLink.ExportToText(FileName);
        }

        public void ExportToImage(string FileName)
        {
            ReportPrintableComponentLink.ExportToImage(FileName, new ImageExportOptions()
            {
                ExportMode = ImageExportMode.SingleFile,
                Format = System.Drawing.Imaging.ImageFormat.Png,
                RetainBackgroundTransparency = false,
            });
        }

        private void PrintableComponentLink1_CreateMarginalHeaderArea(object sender,
            DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            float x = 0;
            e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
            if (!string.IsNullOrWhiteSpace(Parameters.ReportHeaderLine1))
            {
                e.Graph.Font = new Font(DefaultFontName, (int)eGeneralizeReportHeaderFontSize.Line1, FontStyle.Bold);
                RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, e.Graph.Font.Height);
                e.Graph.DrawString(Parameters.ReportHeaderLine1, Color.Black, rec, BorderSide.None);
                x = x + rec.Height + 1;
            }

            if (!string.IsNullOrWhiteSpace(Parameters.ReportHeaderLine2))
            {
                e.Graph.Font = new Font(DefaultFontName, (int)eGeneralizeReportHeaderFontSize.Line2, FontStyle.Regular);
                RectangleF rec = new RectangleF(0, x, e.Graph.ClientPageSize.Width, e.Graph.Font.Height);
                e.Graph.DrawString(Parameters.ReportHeaderLine2, Color.Black, rec, BorderSide.None);
                x = x + rec.Height + 5;
            }
            e.Graph.DrawLine(new PointF(0, x), new PointF(e.Graph.ClientPageSize.Width, x), Color.Black, 1f);

            x += 10;

            if (!string.IsNullOrWhiteSpace(Parameters.PageHeaderLine1))
            {

                e.Graph.Font = new Font(DefaultFontName, (int)eGeneralizeReportHeaderFontSize.Line3, FontStyle.Bold);
                RectangleF rec = new RectangleF(0, x, e.Graph.ClientPageSize.Width, e.Graph.Font.Height);
                e.Graph.DrawString(Parameters.PageHeaderLine1, Color.Black, rec, BorderSide.None);
                x = x + rec.Height + 5;
            }

            if (!string.IsNullOrWhiteSpace(Parameters.PageHeaderLine2))
            {
                e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Near);

                e.Graph.Font = new Font(DefaultFontName, (int)eGeneralizeReportHeaderFontSize.Line4, FontStyle.Bold);
                RectangleF rec = new RectangleF(0, x, e.Graph.ClientPageSize.Width, PageHeaderLine2Size.Height);

                e.Graph.DrawString(Parameters.PageHeaderLine2, Color.Black, rec, BorderSide.Top);
                x = x + rec.Height + 5;
            }
        }

        public void Dispose()
        {
            ReportPrintableComponentLink.Dispose();
            this.ReportPrintingSystem.Dispose();
        }
    }

}
