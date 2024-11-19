namespace Alit.Marker.WinForm.Template
{
    partial class frmGridCRUDTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGridCRUDTemplate));
            this.lblFormCaption = new DevExpress.XtraEditors.LabelControl();
            this.backgroundWorkerLoadInitialValues = new System.ComponentModel.BackgroundWorker();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDashboardControl = new DevExpress.XtraBars.Bar();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnLock = new DevExpress.XtraBars.BarButtonItem();
            this.btnUnLock = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeactivate = new DevExpress.XtraBars.BarButtonItem();
            this.btnActivate = new DevExpress.XtraBars.BarButtonItem();
            this.btnCrudGridPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.btnCrudGridPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnCrudGridExportTo = new DevExpress.XtraBars.BarSubItem();
            this.btnCrudGridExportToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnCrudGridExportToPDF = new DevExpress.XtraBars.BarButtonItem();
            this.btnCrudGridExportToWord = new DevExpress.XtraBars.BarButtonItem();
            this.barCrudGridExportToCSV = new DevExpress.XtraBars.BarButtonItem();
            this.btnCrudGridExportToText = new DevExpress.XtraBars.BarButtonItem();
            this.btnCrudGridExportToImage = new DevExpress.XtraBars.BarButtonItem();
            this.btnResetCrudGridLayout = new DevExpress.XtraBars.BarButtonItem();
            this.barDocumentPrint = new DevExpress.XtraBars.Bar();
            this.btnDocumentPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.btnDocumentPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnDocumentExportTo = new DevExpress.XtraBars.BarSubItem();
            this.btnDocumentExportToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnDocumentExportToPDF = new DevExpress.XtraBars.BarButtonItem();
            this.btnDocumentExportToWord = new DevExpress.XtraBars.BarButtonItem();
            this.btnDocumentExportToCSV = new DevExpress.XtraBars.BarButtonItem();
            this.btnDocumentExportToText = new DevExpress.XtraBars.BarButtonItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.lblRecordNo = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreatedByCaption = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreatedBy = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreatedAtCaption = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreatedAt = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditedByCaption = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditedBy = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditedAtCaption = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditedAt = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnDocumentExportToImage = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.Appearance.FontSizeDelta = 10;
            this.lblFormCaption.Appearance.Options.UseFont = true;
            this.lblFormCaption.Appearance.Options.UseTextOptions = true;
            this.lblFormCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFormCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFormCaption.Location = new System.Drawing.Point(0, 69);
            this.lblFormCaption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblFormCaption.Name = "lblFormCaption";
            this.lblFormCaption.Size = new System.Drawing.Size(1345, 37);
            this.lblFormCaption.TabIndex = 2;
            this.lblFormCaption.Text = "Dashboard";
            this.lblFormCaption.UseMnemonic = false;
            // 
            // backgroundWorkerLoadInitialValues
            // 
            this.backgroundWorkerLoadInitialValues.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoadInitialValues_DoWork);
            this.backgroundWorkerLoadInitialValues.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoadInitialValues_RunWorkerCompleted);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barDashboardControl,
            this.barDocumentPrint,
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnRefresh,
            this.btnDelete,
            this.btnCrudGridPrintPreview,
            this.btnCrudGridPrint,
            this.btnCrudGridExportTo,
            this.btnCrudGridExportToExcel,
            this.btnCrudGridExportToPDF,
            this.btnCrudGridExportToWord,
            this.barCrudGridExportToCSV,
            this.btnCrudGridExportToText,
            this.btnDocumentPrintPreview,
            this.btnDocumentPrint,
            this.btnDocumentExportTo,
            this.btnDocumentExportToExcel,
            this.btnDocumentExportToPDF,
            this.btnDocumentExportToWord,
            this.btnDocumentExportToCSV,
            this.btnDocumentExportToText,
            this.btnDocumentExportToImage,
            this.btnCrudGridExportToImage,
            this.btnLock,
            this.btnUnLock,
            this.btnDeactivate,
            this.btnActivate,
            this.btnResetCrudGridLayout,
            this.lblCreatedByCaption,
            this.lblCreatedBy,
            this.lblCreatedAtCaption,
            this.lblCreatedAt,
            this.lblEditedByCaption,
            this.lblEditedBy,
            this.lblEditedAtCaption,
            this.lblEditedAt,
            this.lblRecordNo});
            this.barManager1.MainMenu = this.barDashboardControl;
            this.barManager1.MaxItemId = 45;
            this.barManager1.StatusBar = this.bar1;
            // 
            // barDashboardControl
            // 
            this.barDashboardControl.BarAppearance.Hovered.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.barDashboardControl.BarAppearance.Hovered.Options.UseFont = true;
            this.barDashboardControl.BarAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.barDashboardControl.BarAppearance.Normal.Options.UseFont = true;
            this.barDashboardControl.BarAppearance.Pressed.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.barDashboardControl.BarAppearance.Pressed.Options.UseFont = true;
            this.barDashboardControl.BarName = "Main menu";
            this.barDashboardControl.DockCol = 0;
            this.barDashboardControl.DockRow = 0;
            this.barDashboardControl.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barDashboardControl.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLock, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUnLock, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDeactivate, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnActivate, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCrudGridPrintPreview, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCrudGridPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCrudGridExportTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnResetCrudGridLayout, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barDashboardControl.OptionsBar.AllowQuickCustomization = false;
            this.barDashboardControl.OptionsBar.DisableClose = true;
            this.barDashboardControl.OptionsBar.DisableCustomization = true;
            this.barDashboardControl.OptionsBar.DrawBorder = false;
            this.barDashboardControl.OptionsBar.DrawDragBorder = false;
            this.barDashboardControl.OptionsBar.UseWholeRow = true;
            this.barDashboardControl.Text = "Main menu";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "&Refresh";
            this.btnRefresh.Id = 0;
            this.btnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefresh.ImageOptions.SvgImage")));
            this.btnRefresh.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "&Delete";
            this.btnDelete.Id = 3;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btnDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnLock
            // 
            this.btnLock.Caption = "&Lock";
            this.btnLock.Id = 30;
            this.btnLock.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLock.ImageOptions.SvgImage")));
            this.btnLock.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btnLock.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L));
            this.btnLock.Name = "btnLock";
            this.btnLock.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnLock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLock_ItemClick);
            // 
            // btnUnLock
            // 
            this.btnUnLock.Caption = "&Unlock";
            this.btnUnLock.Id = 31;
            this.btnUnLock.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUnLock.ImageOptions.SvgImage")));
            this.btnUnLock.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btnUnLock.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U));
            this.btnUnLock.Name = "btnUnLock";
            this.btnUnLock.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnUnLock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUnLock_ItemClick);
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.Caption = "Dea&ctivate";
            this.btnDeactivate.Id = 32;
            this.btnDeactivate.ImageOptions.Image = global::Alit.Marker.WinForm.Template.Properties.Resources.icons8_shutdown_32_Red;
            this.btnDeactivate.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.D));
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnDeactivate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeactivate_ItemClick);
            // 
            // btnActivate
            // 
            this.btnActivate.Caption = "Ac&tivate";
            this.btnActivate.Id = 33;
            this.btnActivate.ImageOptions.Image = global::Alit.Marker.WinForm.Template.Properties.Resources.icons8_shutdown_32_Green;
            this.btnActivate.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.T));
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnActivate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActivate_ItemClick);
            // 
            // btnCrudGridPrintPreview
            // 
            this.btnCrudGridPrintPreview.Caption = "&Print Preview";
            this.btnCrudGridPrintPreview.Id = 4;
            this.btnCrudGridPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCrudGridPrintPreview.ImageOptions.SvgImage")));
            this.btnCrudGridPrintPreview.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btnCrudGridPrintPreview.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnCrudGridPrintPreview.Name = "btnCrudGridPrintPreview";
            this.btnCrudGridPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCrudGridPrintPreview_ItemClick);
            // 
            // btnCrudGridPrint
            // 
            this.btnCrudGridPrint.Caption = "&Quick Print";
            this.btnCrudGridPrint.Id = 5;
            this.btnCrudGridPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCrudGridPrint.ImageOptions.SvgImage")));
            this.btnCrudGridPrint.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btnCrudGridPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q));
            this.btnCrudGridPrint.Name = "btnCrudGridPrint";
            this.btnCrudGridPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCrudGridPrint_ItemClick);
            // 
            // btnCrudGridExportTo
            // 
            this.btnCrudGridExportTo.Caption = "Export to";
            this.btnCrudGridExportTo.Id = 13;
            this.btnCrudGridExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCrudGridExportTo.ImageOptions.SvgImage")));
            this.btnCrudGridExportTo.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btnCrudGridExportTo.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCrudGridExportToExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCrudGridExportToPDF),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCrudGridExportToWord),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCrudGridExportToCSV),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCrudGridExportToText),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCrudGridExportToImage)});
            this.btnCrudGridExportTo.Name = "btnCrudGridExportTo";
            // 
            // btnCrudGridExportToExcel
            // 
            this.btnCrudGridExportToExcel.Caption = "Excel";
            this.btnCrudGridExportToExcel.Id = 14;
            this.btnCrudGridExportToExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCrudGridExportToExcel.ImageOptions.Image")));
            this.btnCrudGridExportToExcel.Name = "btnCrudGridExportToExcel";
            this.btnCrudGridExportToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCrudGridExportToExcel_ItemClick);
            // 
            // btnCrudGridExportToPDF
            // 
            this.btnCrudGridExportToPDF.Caption = "PDF";
            this.btnCrudGridExportToPDF.Id = 15;
            this.btnCrudGridExportToPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCrudGridExportToPDF.ImageOptions.Image")));
            this.btnCrudGridExportToPDF.Name = "btnCrudGridExportToPDF";
            this.btnCrudGridExportToPDF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCrudGridExportToPDF_ItemClick);
            // 
            // btnCrudGridExportToWord
            // 
            this.btnCrudGridExportToWord.Caption = "Word";
            this.btnCrudGridExportToWord.Id = 16;
            this.btnCrudGridExportToWord.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCrudGridExportToWord.ImageOptions.Image")));
            this.btnCrudGridExportToWord.Name = "btnCrudGridExportToWord";
            this.btnCrudGridExportToWord.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCrudGridExportToWord_ItemClick);
            // 
            // barCrudGridExportToCSV
            // 
            this.barCrudGridExportToCSV.Caption = "CSV";
            this.barCrudGridExportToCSV.Id = 17;
            this.barCrudGridExportToCSV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barCrudGridExportToCSV.ImageOptions.Image")));
            this.barCrudGridExportToCSV.Name = "barCrudGridExportToCSV";
            this.barCrudGridExportToCSV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCrudGridExportToCSV_ItemClick);
            // 
            // btnCrudGridExportToText
            // 
            this.btnCrudGridExportToText.Caption = "Text";
            this.btnCrudGridExportToText.Id = 18;
            this.btnCrudGridExportToText.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCrudGridExportToText.ImageOptions.Image")));
            this.btnCrudGridExportToText.Name = "btnCrudGridExportToText";
            this.btnCrudGridExportToText.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCrudGridExportToText_ItemClick);
            // 
            // btnCrudGridExportToImage
            // 
            this.btnCrudGridExportToImage.Caption = "Image";
            this.btnCrudGridExportToImage.Id = 29;
            this.btnCrudGridExportToImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCrudGridExportToImage.ImageOptions.Image")));
            this.btnCrudGridExportToImage.Name = "btnCrudGridExportToImage";
            this.btnCrudGridExportToImage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCrudGridExportToImage_ItemClick);
            // 
            // btnResetCrudGridLayout
            // 
            this.btnResetCrudGridLayout.Caption = "Reset Layout";
            this.btnResetCrudGridLayout.Id = 35;
            this.btnResetCrudGridLayout.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnResetCrudGridLayout.ImageOptions.SvgImage")));
            this.btnResetCrudGridLayout.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btnResetCrudGridLayout.Name = "btnResetCrudGridLayout";
            this.btnResetCrudGridLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResetCrudGridLayout_ItemClick);
            // 
            // barDocumentPrint
            // 
            this.barDocumentPrint.BarAppearance.Disabled.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.barDocumentPrint.BarAppearance.Disabled.Options.UseFont = true;
            this.barDocumentPrint.BarAppearance.Hovered.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.barDocumentPrint.BarAppearance.Hovered.Options.UseFont = true;
            this.barDocumentPrint.BarAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.barDocumentPrint.BarAppearance.Normal.Options.UseFont = true;
            this.barDocumentPrint.BarAppearance.Pressed.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.barDocumentPrint.BarAppearance.Pressed.Options.UseFont = true;
            this.barDocumentPrint.BarName = "Custom 3";
            this.barDocumentPrint.DockCol = 0;
            this.barDocumentPrint.DockRow = 1;
            this.barDocumentPrint.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barDocumentPrint.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDocumentPrintPreview, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDocumentPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDocumentExportTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barDocumentPrint.OptionsBar.AllowQuickCustomization = false;
            this.barDocumentPrint.OptionsBar.DrawDragBorder = false;
            this.barDocumentPrint.OptionsBar.UseWholeRow = true;
            this.barDocumentPrint.Text = "Custom 3";
            this.barDocumentPrint.Visible = false;
            // 
            // btnDocumentPrintPreview
            // 
            this.btnDocumentPrintPreview.Caption = "Document Print Preview";
            this.btnDocumentPrintPreview.Id = 19;
            this.btnDocumentPrintPreview.Name = "btnDocumentPrintPreview";
            this.btnDocumentPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDocumentPrintPreview_ItemClick);
            // 
            // btnDocumentPrint
            // 
            this.btnDocumentPrint.Caption = "Document Print";
            this.btnDocumentPrint.Id = 20;
            this.btnDocumentPrint.Name = "btnDocumentPrint";
            this.btnDocumentPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDocumentPrint_ItemClick);
            // 
            // btnDocumentExportTo
            // 
            this.btnDocumentExportTo.Caption = "Export Document to";
            this.btnDocumentExportTo.Id = 22;
            this.btnDocumentExportTo.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDocumentExportToExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDocumentExportToPDF, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDocumentExportToWord, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDocumentExportToCSV, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDocumentExportToText, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.btnDocumentExportTo.Name = "btnDocumentExportTo";
            // 
            // btnDocumentExportToExcel
            // 
            this.btnDocumentExportToExcel.Caption = "Excel";
            this.btnDocumentExportToExcel.Id = 23;
            this.btnDocumentExportToExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDocumentExportToExcel.ImageOptions.Image")));
            this.btnDocumentExportToExcel.Name = "btnDocumentExportToExcel";
            this.btnDocumentExportToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDocumentExportToExcel_ItemClick);
            // 
            // btnDocumentExportToPDF
            // 
            this.btnDocumentExportToPDF.Caption = "PDF";
            this.btnDocumentExportToPDF.Id = 24;
            this.btnDocumentExportToPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDocumentExportToPDF.ImageOptions.Image")));
            this.btnDocumentExportToPDF.Name = "btnDocumentExportToPDF";
            this.btnDocumentExportToPDF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDocumentExportToPDF_ItemClick);
            // 
            // btnDocumentExportToWord
            // 
            this.btnDocumentExportToWord.Caption = "Word";
            this.btnDocumentExportToWord.Id = 25;
            this.btnDocumentExportToWord.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDocumentExportToWord.ImageOptions.Image")));
            this.btnDocumentExportToWord.Name = "btnDocumentExportToWord";
            this.btnDocumentExportToWord.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDocumentExportToWord_ItemClick);
            // 
            // btnDocumentExportToCSV
            // 
            this.btnDocumentExportToCSV.Caption = "CSV";
            this.btnDocumentExportToCSV.Id = 26;
            this.btnDocumentExportToCSV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDocumentExportToCSV.ImageOptions.Image")));
            this.btnDocumentExportToCSV.Name = "btnDocumentExportToCSV";
            this.btnDocumentExportToCSV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDocumentExportToCSV_ItemClick);
            // 
            // btnDocumentExportToText
            // 
            this.btnDocumentExportToText.Caption = "Text";
            this.btnDocumentExportToText.Id = 27;
            this.btnDocumentExportToText.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDocumentExportToText.ImageOptions.Image")));
            this.btnDocumentExportToText.Name = "btnDocumentExportToText";
            this.btnDocumentExportToText.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDocumentExportToText_ItemClick);
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 4";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblRecordNo),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreatedByCaption, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreatedBy),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreatedAtCaption),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreatedAt),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditedByCaption, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditedBy),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditedAtCaption),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditedAt)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 4";
            // 
            // lblRecordNo
            // 
            this.lblRecordNo.Caption = "0 of 0";
            this.lblRecordNo.Id = 44;
            this.lblRecordNo.Name = "lblRecordNo";
            // 
            // lblCreatedByCaption
            // 
            this.lblCreatedByCaption.Caption = "Created By";
            this.lblCreatedByCaption.Id = 36;
            this.lblCreatedByCaption.Name = "lblCreatedByCaption";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Caption = "xxx";
            this.lblCreatedBy.Id = 37;
            this.lblCreatedBy.Name = "lblCreatedBy";
            // 
            // lblCreatedAtCaption
            // 
            this.lblCreatedAtCaption.Caption = "At";
            this.lblCreatedAtCaption.Id = 38;
            this.lblCreatedAtCaption.Name = "lblCreatedAtCaption";
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Caption = "00:00";
            this.lblCreatedAt.Id = 39;
            this.lblCreatedAt.Name = "lblCreatedAt";
            // 
            // lblEditedByCaption
            // 
            this.lblEditedByCaption.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditedByCaption.Caption = "Edited By";
            this.lblEditedByCaption.Id = 40;
            this.lblEditedByCaption.Name = "lblEditedByCaption";
            // 
            // lblEditedBy
            // 
            this.lblEditedBy.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditedBy.Caption = "xxx";
            this.lblEditedBy.Id = 41;
            this.lblEditedBy.Name = "lblEditedBy";
            // 
            // lblEditedAtCaption
            // 
            this.lblEditedAtCaption.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditedAtCaption.Caption = "At";
            this.lblEditedAtCaption.Id = 42;
            this.lblEditedAtCaption.Name = "lblEditedAtCaption";
            // 
            // lblEditedAt
            // 
            this.lblEditedAt.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditedAt.Caption = "00:00";
            this.lblEditedAt.Id = 43;
            this.lblEditedAt.Name = "lblEditedAt";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1345, 69);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 406);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1345, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 69);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 337);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1345, 69);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 337);
            // 
            // btnDocumentExportToImage
            // 
            this.btnDocumentExportToImage.Caption = "Image";
            this.btnDocumentExportToImage.Id = 28;
            this.btnDocumentExportToImage.Name = "btnDocumentExportToImage";
            // 
            // frmGridCRUDTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 433);
            this.Controls.Add(this.lblFormCaption);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmGridCRUDTemplate.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmGridCRUDTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grid CRUD Template";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected DevExpress.XtraEditors.LabelControl lblFormCaption;
        protected System.ComponentModel.BackgroundWorker backgroundWorkerLoadInitialValues;
        protected DevExpress.XtraBars.BarManager barManager1;
        protected DevExpress.XtraBars.Bar barDashboardControl;
        protected DevExpress.XtraBars.BarButtonItem btnRefresh;
        protected DevExpress.XtraBars.BarButtonItem btnDelete;
        protected DevExpress.XtraBars.BarDockControl barDockControlTop;
        protected DevExpress.XtraBars.BarDockControl barDockControlBottom;
        protected DevExpress.XtraBars.BarDockControl barDockControlLeft;
        protected DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected DevExpress.XtraBars.BarButtonItem btnCrudGridPrintPreview;
        protected DevExpress.XtraBars.BarButtonItem btnCrudGridPrint;
        protected DevExpress.XtraBars.BarSubItem btnCrudGridExportTo;
        protected DevExpress.XtraBars.BarButtonItem btnCrudGridExportToExcel;
        protected DevExpress.XtraBars.BarButtonItem btnCrudGridExportToPDF;
        protected DevExpress.XtraBars.BarButtonItem btnCrudGridExportToWord;
        protected DevExpress.XtraBars.BarButtonItem barCrudGridExportToCSV;
        protected DevExpress.XtraBars.BarButtonItem btnCrudGridExportToText;
        protected DevExpress.XtraBars.Bar barDocumentPrint;
        protected DevExpress.XtraBars.BarButtonItem btnDocumentPrintPreview;
        protected DevExpress.XtraBars.BarButtonItem btnDocumentPrint;
        protected DevExpress.XtraBars.BarSubItem btnDocumentExportTo;
        protected DevExpress.XtraBars.BarButtonItem btnDocumentExportToExcel;
        protected DevExpress.XtraBars.BarButtonItem btnDocumentExportToPDF;
        protected DevExpress.XtraBars.BarButtonItem btnDocumentExportToWord;
        protected DevExpress.XtraBars.BarButtonItem btnDocumentExportToCSV;
        protected DevExpress.XtraBars.BarButtonItem btnDocumentExportToText;
        protected DevExpress.XtraBars.BarButtonItem btnDocumentExportToImage;
        protected DevExpress.XtraBars.BarButtonItem btnCrudGridExportToImage;
        protected DevExpress.XtraBars.BarButtonItem btnLock;
        protected DevExpress.XtraBars.BarButtonItem btnUnLock;
        protected DevExpress.XtraBars.BarButtonItem btnDeactivate;
        protected DevExpress.XtraBars.BarButtonItem btnActivate;
        protected DevExpress.XtraBars.BarButtonItem btnResetCrudGridLayout;
        protected DevExpress.XtraBars.Bar bar1;
        protected DevExpress.XtraBars.BarStaticItem lblCreatedByCaption;
        protected DevExpress.XtraBars.BarStaticItem lblCreatedBy;
        protected DevExpress.XtraBars.BarStaticItem lblCreatedAtCaption;
        protected DevExpress.XtraBars.BarStaticItem lblCreatedAt;
        protected DevExpress.XtraBars.BarStaticItem lblEditedByCaption;
        protected DevExpress.XtraBars.BarStaticItem lblEditedBy;
        protected DevExpress.XtraBars.BarStaticItem lblEditedAtCaption;
        protected DevExpress.XtraBars.BarStaticItem lblEditedAt;
        protected DevExpress.XtraBars.BarStaticItem lblRecordNo;
    }
}