namespace Alit.Marker.WinForm.Template.Report
{
    partial class frmGridReportTemplate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGridReportTemplate));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnDashboardPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.btnDashboardPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnDashboardExportToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnDashboardExportToPDF = new DevExpress.XtraBars.BarButtonItem();
            this.btnDashboardExportToWord = new DevExpress.XtraBars.BarButtonItem();
            this.btnDashboardExportToCSV = new DevExpress.XtraBars.BarButtonItem();
            this.btnDashboardExportToText = new DevExpress.XtraBars.BarButtonItem();
            this.btnDashboardExportToImage = new DevExpress.XtraBars.BarButtonItem();
            this.btnResetLayout = new DevExpress.XtraBars.BarButtonItem();
            this.lblRecordNo = new DevExpress.XtraBars.BarStaticItem();
            this.rpcReport = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgLayout = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.backgroundWorkerLoadInitialValues = new System.ComponentModel.BackgroundWorker();
            this.lcTitle = new Alit.WinformControls.myLayoutControl();
            this.RootTitle = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgDefaultFilterGroupBox = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblFormCaption = new DevExpress.XtraLayout.SimpleLabelItem();
            this.ErrorProvider = new Alit.WinformControls.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnRefresh,
            this.btnDashboardPrintPreview,
            this.btnDashboardPrint,
            this.btnDashboardExportToExcel,
            this.btnDashboardExportToPDF,
            this.btnDashboardExportToWord,
            this.btnDashboardExportToCSV,
            this.btnDashboardExportToText,
            this.btnDashboardExportToImage,
            this.btnResetLayout,
            this.lblRecordNo});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.rpcReport});
            this.ribbonControl1.Size = new System.Drawing.Size(1141, 166);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 19;
            this.btnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefresh.ImageOptions.SvgImage")));
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnRefresh.ShortcutKeyDisplayString = "C+N";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnDashboardPrintPreview
            // 
            this.btnDashboardPrintPreview.Caption = "Print Preview";
            this.btnDashboardPrintPreview.Id = 20;
            this.btnDashboardPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDashboardPrintPreview.ImageOptions.SvgImage")));
            this.btnDashboardPrintPreview.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnDashboardPrintPreview.Name = "btnDashboardPrintPreview";
            this.btnDashboardPrintPreview.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDashboardPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReportPrintPreview_ItemClick);
            // 
            // btnDashboardPrint
            // 
            this.btnDashboardPrint.Caption = "Quick Print";
            this.btnDashboardPrint.Id = 21;
            this.btnDashboardPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDashboardPrint.ImageOptions.SvgImage")));
            this.btnDashboardPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q));
            this.btnDashboardPrint.Name = "btnDashboardPrint";
            this.btnDashboardPrint.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnDashboardPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReportPrint_ItemClick);
            // 
            // btnDashboardExportToExcel
            // 
            this.btnDashboardExportToExcel.Caption = "Excel";
            this.btnDashboardExportToExcel.Id = 22;
            this.btnDashboardExportToExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboardExportToExcel.ImageOptions.Image")));
            this.btnDashboardExportToExcel.Name = "btnDashboardExportToExcel";
            this.btnDashboardExportToExcel.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnDashboardExportToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReportExportToExcel_ItemClick);
            // 
            // btnDashboardExportToPDF
            // 
            this.btnDashboardExportToPDF.Caption = "PDF";
            this.btnDashboardExportToPDF.Id = 23;
            this.btnDashboardExportToPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboardExportToPDF.ImageOptions.Image")));
            this.btnDashboardExportToPDF.Name = "btnDashboardExportToPDF";
            this.btnDashboardExportToPDF.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnDashboardExportToPDF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReportExportToPDF_ItemClick);
            // 
            // btnDashboardExportToWord
            // 
            this.btnDashboardExportToWord.Caption = "Word";
            this.btnDashboardExportToWord.Id = 24;
            this.btnDashboardExportToWord.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboardExportToWord.ImageOptions.Image")));
            this.btnDashboardExportToWord.Name = "btnDashboardExportToWord";
            this.btnDashboardExportToWord.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnDashboardExportToWord.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReportExportToWord_ItemClick);
            // 
            // btnDashboardExportToCSV
            // 
            this.btnDashboardExportToCSV.Caption = "CSV";
            this.btnDashboardExportToCSV.Id = 25;
            this.btnDashboardExportToCSV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboardExportToCSV.ImageOptions.Image")));
            this.btnDashboardExportToCSV.Name = "btnDashboardExportToCSV";
            this.btnDashboardExportToCSV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReportExportToCSV_ItemClick);
            // 
            // btnDashboardExportToText
            // 
            this.btnDashboardExportToText.Caption = "Text";
            this.btnDashboardExportToText.Id = 26;
            this.btnDashboardExportToText.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboardExportToText.ImageOptions.Image")));
            this.btnDashboardExportToText.Name = "btnDashboardExportToText";
            this.btnDashboardExportToText.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReportExportToText_ItemClick);
            // 
            // btnDashboardExportToImage
            // 
            this.btnDashboardExportToImage.Caption = "Image";
            this.btnDashboardExportToImage.Id = 27;
            this.btnDashboardExportToImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboardExportToImage.ImageOptions.Image")));
            this.btnDashboardExportToImage.Name = "btnDashboardExportToImage";
            this.btnDashboardExportToImage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReportExportToImage_ItemClick);
            // 
            // btnResetLayout
            // 
            this.btnResetLayout.Caption = "Reset Layout";
            this.btnResetLayout.Id = 28;
            this.btnResetLayout.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnResetLayout.ImageOptions.SvgImage")));
            this.btnResetLayout.Name = "btnResetLayout";
            this.btnResetLayout.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnResetLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResetReportGridLayout_ItemClick);
            // 
            // lblRecordNo
            // 
            this.lblRecordNo.Caption = "0 of 0 records";
            this.lblRecordNo.Id = 1;
            this.lblRecordNo.Name = "lblRecordNo";
            // 
            // rpcReport
            // 
            this.rpcReport.Name = "rpcReport";
            this.rpcReport.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.rpcReport.Text = "Report";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.rpgLayout});
            this.ribbonPage1.MergeOrder = 3;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Data";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDashboardPrintPreview);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDashboardPrint);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Print";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDashboardExportToExcel);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDashboardExportToPDF);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDashboardExportToWord);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDashboardExportToCSV);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDashboardExportToText);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDashboardExportToImage);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Export To";
            // 
            // rpgLayout
            // 
            this.rpgLayout.ItemLinks.Add(this.btnResetLayout);
            this.rpgLayout.Name = "rpgLayout";
            this.rpgLayout.Text = "Layout";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.lblRecordNo);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 606);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1141, 24);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // backgroundWorkerLoadInitialValues
            // 
            this.backgroundWorkerLoadInitialValues.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoadInitialValues_DoWork);
            this.backgroundWorkerLoadInitialValues.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoadInitialValues_RunWorkerCompleted);
            // 
            // lcTitle
            // 
            this.lcTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lcTitle.Location = new System.Drawing.Point(0, 166);
            this.lcTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lcTitle.Name = "lcTitle";
            this.lcTitle.OptionsView.HighlightFocusedItem = true;
            this.lcTitle.Root = this.RootTitle;
            this.lcTitle.Size = new System.Drawing.Size(1141, 55);
            this.lcTitle.TabIndex = 8;
            this.lcTitle.Text = "myLayoutControl1";
            // 
            // RootTitle
            // 
            this.RootTitle.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootTitle.GroupBordersVisible = false;
            this.RootTitle.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgDefaultFilterGroupBox,
            this.lblFormCaption});
            this.RootTitle.Name = "RootTitle";
            this.RootTitle.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.RootTitle.Size = new System.Drawing.Size(1141, 55);
            this.RootTitle.TextVisible = false;
            // 
            // lcgDefaultFilterGroupBox
            // 
            this.lcgDefaultFilterGroupBox.Location = new System.Drawing.Point(0, 0);
            this.lcgDefaultFilterGroupBox.Name = "lcgDefaultFilterGroupBox";
            this.lcgDefaultFilterGroupBox.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(246, 55);
            this.lcgDefaultFilterGroupBox.Text = "Filter";
            this.lcgDefaultFilterGroupBox.TextLocation = DevExpress.Utils.Locations.Left;
            this.lcgDefaultFilterGroupBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AllowHotTrack = false;
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(246, 0);
            this.lblFormCaption.Name = "lblFormCaption";
            this.lblFormCaption.Size = new System.Drawing.Size(895, 55);
            this.lblFormCaption.Text = "Dashboard";
            this.lblFormCaption.TextSize = new System.Drawing.Size(157, 38);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // frmGridReportTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 630);
            this.Controls.Add(this.lcTitle);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmGridReportTemplate.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmGridReportTemplate";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Dahboard";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        protected DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        protected DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        protected DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        protected System.ComponentModel.BackgroundWorker backgroundWorkerLoadInitialValues;
        protected DevExpress.XtraLayout.LayoutControlGroup RootTitle;
        protected Alit.WinformControls.myLayoutControl lcTitle;
        protected DevExpress.XtraLayout.LayoutControlGroup lcgDefaultFilterGroupBox;
        protected DevExpress.XtraLayout.SimpleLabelItem lblFormCaption;
        protected DevExpress.XtraBars.BarButtonItem btnRefresh;
        protected DevExpress.XtraBars.BarButtonItem btnDashboardPrintPreview;
        protected DevExpress.XtraBars.BarButtonItem btnDashboardPrint;
        protected DevExpress.XtraBars.BarButtonItem btnDashboardExportToExcel;
        protected DevExpress.XtraBars.BarButtonItem btnDashboardExportToPDF;
        protected DevExpress.XtraBars.BarButtonItem btnDashboardExportToWord;
        protected DevExpress.XtraBars.BarButtonItem btnDashboardExportToCSV;
        protected DevExpress.XtraBars.BarButtonItem btnDashboardExportToText;
        protected DevExpress.XtraBars.BarButtonItem btnDashboardExportToImage;
        protected DevExpress.XtraBars.BarButtonItem btnResetLayout;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        protected DevExpress.XtraBars.BarStaticItem lblRecordNo;
        protected Alit.WinformControls.ErrorProvider ErrorProvider;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgLayout;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory rpcReport;
    }
}