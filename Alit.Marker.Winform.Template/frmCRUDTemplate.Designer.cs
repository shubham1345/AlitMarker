namespace Alit.Marker.WinForm.Template
{
    partial class frmCRUDTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCRUDTemplate));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barFormHeader = new DevExpress.XtraBars.Bar();
            this.lblFormCaption = new DevExpress.XtraBars.BarStaticItem();
            this.lblCurrentViewCaption = new DevExpress.XtraBars.BarStaticItem();
            this.lblRecordState = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreatedByCaption = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreatedBy = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreatedAtCaption = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreatedAt = new DevExpress.XtraBars.BarStaticItem();
            this.barFormFooter = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.beiProgressbar = new DevExpress.XtraBars.BarEditItem();
            this.ProgressBarSavingProcess = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.lblEditedByCaption = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditedBy = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditedAtCaption = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditedAt = new DevExpress.XtraBars.BarStaticItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.popupMenuFormShortCuts = new DevExpress.XtraBars.PopupMenu(this.components);
            this.panelContent = new DevExpress.XtraEditors.PanelControl();
            this.backgroundWorkerLoadInitialValues = new System.ComponentModel.BackgroundWorker();
            this.ErrorProvider = new Alit.WinformControls.ErrorProvider(this.components);
            this.btnSetSaveFocus = new DevExpress.XtraEditors.SimpleButton();
            this.btnSetExitFocus = new DevExpress.XtraEditors.SimpleButton();
            this.panelBase1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBase1)).BeginInit();
            this.panelBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barFormHeader,
            this.barFormFooter});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSave,
            this.btnDelete,
            this.btnExit,
            this.btnRefresh,
            this.lblCurrentViewCaption,
            this.lblFormCaption,
            this.btnPrint,
            this.btnPrintPreview,
            this.beiProgressbar,
            this.lblCreatedByCaption,
            this.lblCreatedBy,
            this.lblCreatedAtCaption,
            this.lblCreatedAt,
            this.lblEditedByCaption,
            this.lblEditedBy,
            this.lblEditedAtCaption,
            this.lblEditedAt,
            this.lblRecordState});
            this.barManager1.MaxItemId = 64;
            this.barManager1.OptionsLayout.AllowAddNewItems = false;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ProgressBarSavingProcess});
            this.barManager1.StatusBar = this.barFormFooter;
            // 
            // barFormHeader
            // 
            this.barFormHeader.BarName = "Tools";
            this.barFormHeader.DockCol = 0;
            this.barFormHeader.DockRow = 0;
            this.barFormHeader.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barFormHeader.FloatLocation = new System.Drawing.Point(100, 100);
            this.barFormHeader.FloatSize = new System.Drawing.Size(122, 88);
            this.barFormHeader.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblFormCaption, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCurrentViewCaption),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblRecordState, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreatedByCaption, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreatedBy),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreatedAtCaption),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreatedAt)});
            this.barFormHeader.OptionsBar.AllowQuickCustomization = false;
            this.barFormHeader.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.barFormHeader.OptionsBar.DisableClose = true;
            this.barFormHeader.OptionsBar.DisableCustomization = true;
            this.barFormHeader.OptionsBar.DrawDragBorder = false;
            this.barFormHeader.OptionsBar.UseWholeRow = true;
            this.barFormHeader.Text = "Header";
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.lblFormCaption.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblFormCaption.Caption = "Title";
            this.lblFormCaption.Id = 15;
            this.lblFormCaption.ItemAppearance.Normal.FontSizeDelta = 2;
            this.lblFormCaption.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lblFormCaption.ItemAppearance.Normal.Options.UseFont = true;
            this.lblFormCaption.Name = "lblFormCaption";
            this.lblFormCaption.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // lblCurrentViewCaption
            // 
            this.lblCurrentViewCaption.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblCurrentViewCaption.Caption = "New";
            this.lblCurrentViewCaption.Id = 14;
            this.lblCurrentViewCaption.ItemAppearance.Normal.FontSizeDelta = 2;
            this.lblCurrentViewCaption.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lblCurrentViewCaption.ItemAppearance.Normal.Options.UseFont = true;
            this.lblCurrentViewCaption.Name = "lblCurrentViewCaption";
            // 
            // lblRecordState
            // 
            this.lblRecordState.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblRecordState.Caption = "Active";
            this.lblRecordState.Id = 63;
            this.lblRecordState.ItemAppearance.Normal.FontSizeDelta = 1;
            this.lblRecordState.ItemAppearance.Normal.Options.UseFont = true;
            this.lblRecordState.Name = "lblRecordState";
            this.lblRecordState.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // lblCreatedByCaption
            // 
            this.lblCreatedByCaption.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblCreatedByCaption.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblCreatedByCaption.Caption = "Created By";
            this.lblCreatedByCaption.Id = 49;
            this.lblCreatedByCaption.ItemAppearance.Normal.FontSizeDelta = -2;
            this.lblCreatedByCaption.ItemAppearance.Normal.Options.UseFont = true;
            this.lblCreatedByCaption.Name = "lblCreatedByCaption";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblCreatedBy.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblCreatedBy.Caption = "xxx";
            this.lblCreatedBy.Id = 50;
            this.lblCreatedBy.ItemAppearance.Normal.FontSizeDelta = -1;
            this.lblCreatedBy.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lblCreatedBy.ItemAppearance.Normal.Options.UseFont = true;
            this.lblCreatedBy.Name = "lblCreatedBy";
            // 
            // lblCreatedAtCaption
            // 
            this.lblCreatedAtCaption.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblCreatedAtCaption.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblCreatedAtCaption.Caption = "At";
            this.lblCreatedAtCaption.Id = 51;
            this.lblCreatedAtCaption.ItemAppearance.Normal.FontSizeDelta = -2;
            this.lblCreatedAtCaption.ItemAppearance.Normal.Options.UseFont = true;
            this.lblCreatedAtCaption.Name = "lblCreatedAtCaption";
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblCreatedAt.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblCreatedAt.Caption = "xxx";
            this.lblCreatedAt.Id = 52;
            this.lblCreatedAt.ItemAppearance.Normal.FontSizeDelta = -1;
            this.lblCreatedAt.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lblCreatedAt.ItemAppearance.Normal.Options.UseFont = true;
            this.lblCreatedAt.Name = "lblCreatedAt";
            // 
            // barFormFooter
            // 
            this.barFormFooter.BarName = "Tools";
            this.barFormFooter.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barFormFooter.DockCol = 0;
            this.barFormFooter.DockRow = 0;
            this.barFormFooter.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barFormFooter.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrintPreview, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.beiProgressbar, "", false, true, true, 143),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditedByCaption, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditedBy),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditedAtCaption),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditedAt),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard)});
            this.barFormFooter.OptionsBar.AllowQuickCustomization = false;
            this.barFormFooter.OptionsBar.DrawDragBorder = false;
            this.barFormFooter.OptionsBar.UseWholeRow = true;
            this.barFormFooter.Text = "Status bar";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "&Save";
            this.btnSave.Id = 4;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnSave.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnSave.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnSave.Name = "btnSave";
            this.btnSave.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnSave.ShortcutKeyDisplayString = "Ctr+S";
            this.btnSave.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Caption = "Print Preview";
            this.btnPrintPreview.Id = 17;
            this.btnPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintPreview.ImageOptions.SvgImage")));
            this.btnPrintPreview.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnPrintPreview.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnPrintPreview.ItemAppearance.Normal.Options.UseFont = true;
            this.btnPrintPreview.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.P));
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.ShortcutKeyDisplayString = "Ctrl+Shift+P";
            this.btnPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrintPreview_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Print";
            this.btnPrint.Id = 16;
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnPrint.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnPrint.ItemAppearance.Normal.Options.UseFont = true;
            this.btnPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ShortcutKeyDisplayString = "Ctrl + P";
            this.btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "&Delete";
            this.btnDelete.Id = 5;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnDelete.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnDelete.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShortcutKeyDisplayString = "Ctr+D";
            this.btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "&Refresh";
            this.btnRefresh.Id = 6;
            this.btnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefresh.ImageOptions.SvgImage")));
            this.btnRefresh.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnRefresh.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnRefresh.ShortcutKeyDisplayString = "Ctr+R";
            this.btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // beiProgressbar
            // 
            this.beiProgressbar.Edit = this.ProgressBarSavingProcess;
            this.beiProgressbar.Id = 27;
            this.beiProgressbar.Name = "beiProgressbar";
            this.beiProgressbar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ProgressBarSavingProcess
            // 
            this.ProgressBarSavingProcess.Name = "ProgressBarSavingProcess";
            this.ProgressBarSavingProcess.Stopped = true;
            // 
            // lblEditedByCaption
            // 
            this.lblEditedByCaption.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditedByCaption.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblEditedByCaption.Caption = "Edited By";
            this.lblEditedByCaption.Id = 57;
            this.lblEditedByCaption.ItemAppearance.Normal.FontSizeDelta = -2;
            this.lblEditedByCaption.ItemAppearance.Normal.Options.UseFont = true;
            this.lblEditedByCaption.Name = "lblEditedByCaption";
            // 
            // lblEditedBy
            // 
            this.lblEditedBy.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditedBy.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblEditedBy.Caption = "xxx";
            this.lblEditedBy.Id = 59;
            this.lblEditedBy.ItemAppearance.Normal.FontSizeDelta = -1;
            this.lblEditedBy.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lblEditedBy.ItemAppearance.Normal.Options.UseFont = true;
            this.lblEditedBy.Name = "lblEditedBy";
            // 
            // lblEditedAtCaption
            // 
            this.lblEditedAtCaption.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditedAtCaption.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblEditedAtCaption.Caption = "At";
            this.lblEditedAtCaption.Id = 60;
            this.lblEditedAtCaption.ItemAppearance.Normal.FontSizeDelta = -2;
            this.lblEditedAtCaption.ItemAppearance.Normal.Options.UseFont = true;
            this.lblEditedAtCaption.Name = "lblEditedAtCaption";
            // 
            // lblEditedAt
            // 
            this.lblEditedAt.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditedAt.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblEditedAt.Caption = "xxx";
            this.lblEditedAt.Id = 61;
            this.lblEditedAt.ItemAppearance.Normal.FontSizeDelta = -1;
            this.lblEditedAt.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lblEditedAt.ItemAppearance.Normal.Options.UseFont = true;
            this.lblEditedAt.Name = "lblEditedAt";
            // 
            // btnExit
            // 
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnExit.Caption = "Cancel";
            this.btnExit.Id = 11;
            this.btnExit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExit.ImageOptions.SvgImage")));
            this.btnExit.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnExit.ItemAppearance.Normal.Options.UseFont = true;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(851, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 234);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(851, 34);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 208);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(851, 26);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 208);
            // 
            // popupMenuFormShortCuts
            // 
            this.popupMenuFormShortCuts.Manager = this.barManager1;
            this.popupMenuFormShortCuts.Name = "popupMenuFormShortCuts";
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 26);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(851, 208);
            this.panelContent.TabIndex = 4;
            // 
            // backgroundWorkerLoadInitialValues
            // 
            this.backgroundWorkerLoadInitialValues.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoadInitialValues_DoWork);
            this.backgroundWorkerLoadInitialValues.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoadInitialValues_RunWorkerCompleted);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // btnSetSaveFocus
            // 
            this.btnSetSaveFocus.Location = new System.Drawing.Point(30, 284);
            this.btnSetSaveFocus.Name = "btnSetSaveFocus";
            this.btnSetSaveFocus.Size = new System.Drawing.Size(75, 23);
            this.btnSetSaveFocus.TabIndex = 9;
            this.btnSetSaveFocus.Text = "Set Save Focus";
            this.btnSetSaveFocus.Enter += new System.EventHandler(this.btnSetSaveFocus_Enter);
            // 
            // btnSetExitFocus
            // 
            this.btnSetExitFocus.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSetExitFocus.Location = new System.Drawing.Point(111, 284);
            this.btnSetExitFocus.Name = "btnSetExitFocus";
            this.btnSetExitFocus.Size = new System.Drawing.Size(75, 23);
            this.btnSetExitFocus.TabIndex = 10;
            this.btnSetExitFocus.Text = "Set Exit Focus";
            this.btnSetExitFocus.Click += new System.EventHandler(this.btnSetExitFocus_Click);
            // 
            // panelBase1
            // 
            this.panelBase1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBase1.Controls.Add(this.panelContent);
            this.panelBase1.Controls.Add(this.barDockControlLeft);
            this.panelBase1.Controls.Add(this.barDockControlRight);
            this.panelBase1.Controls.Add(this.barDockControlBottom);
            this.panelBase1.Controls.Add(this.barDockControlTop);
            this.panelBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBase1.Location = new System.Drawing.Point(0, 0);
            this.panelBase1.Name = "panelBase1";
            this.panelBase1.Size = new System.Drawing.Size(851, 268);
            this.panelBase1.TabIndex = 0;
            // 
            // frmCRUDTemplate
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnSetExitFocus;
            this.ClientSize = new System.Drawing.Size(851, 268);
            this.Controls.Add(this.panelBase1);
            this.Controls.Add(this.btnSetSaveFocus);
            this.Controls.Add(this.btnSetExitFocus);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmCRUDTemplate.IconOptions.Icon")));
            this.MinimumSize = new System.Drawing.Size(80, 59);
            this.Name = "frmCRUDTemplate";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Template";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBase1)).EndInit();
            this.panelBase1.ResumeLayout(false);
            this.panelBase1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraBars.BarManager barManager1;
        protected DevExpress.XtraBars.Bar barFormHeader;
        protected DevExpress.XtraBars.Bar barFormFooter;
        protected DevExpress.XtraBars.BarDockControl barDockControlTop;
        protected DevExpress.XtraBars.BarDockControl barDockControlBottom;
        protected DevExpress.XtraBars.BarDockControl barDockControlLeft;
        protected DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected DevExpress.XtraBars.BarButtonItem btnSave;
        protected DevExpress.XtraBars.BarButtonItem btnDelete;
        protected DevExpress.XtraBars.BarButtonItem btnExit;
        protected System.ComponentModel.BackgroundWorker backgroundWorkerLoadInitialValues;
        protected Alit.WinformControls.ErrorProvider ErrorProvider;
        protected DevExpress.XtraEditors.SimpleButton btnSetExitFocus;
        protected DevExpress.XtraEditors.SimpleButton btnSetSaveFocus;
        protected DevExpress.XtraBars.BarStaticItem lblCurrentViewCaption;
        protected DevExpress.XtraBars.BarStaticItem lblFormCaption;
        protected DevExpress.XtraBars.BarButtonItem btnPrint;
        protected DevExpress.XtraBars.BarButtonItem btnPrintPreview;
        protected DevExpress.XtraBars.BarEditItem beiProgressbar;
        protected DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar ProgressBarSavingProcess;
        protected DevExpress.XtraEditors.PanelControl panelBase1;
        protected DevExpress.XtraEditors.PanelControl panelContent;
        protected DevExpress.XtraBars.BarButtonItem btnRefresh;
        protected DevExpress.XtraBars.BarStaticItem lblCreatedByCaption;
        protected DevExpress.XtraBars.BarStaticItem lblCreatedBy;
        protected DevExpress.XtraBars.BarStaticItem lblCreatedAtCaption;
        protected DevExpress.XtraBars.BarStaticItem lblCreatedAt;
        protected DevExpress.XtraBars.BarStaticItem lblEditedByCaption;
        protected DevExpress.XtraBars.BarStaticItem lblEditedBy;
        protected DevExpress.XtraBars.BarStaticItem lblEditedAtCaption;
        protected DevExpress.XtraBars.BarStaticItem lblEditedAt;
        protected DevExpress.XtraBars.BarStaticItem lblRecordState;

        protected DevExpress.XtraBars.PopupMenu popupMenuFormShortCuts;
    }
}