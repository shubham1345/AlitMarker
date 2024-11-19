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
            this.btnCloseForm = new DevExpress.XtraBars.BarButtonItem();
            this.barFormFooter = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.lblCreateAt = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditedAt = new DevExpress.XtraBars.BarStaticItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.beiProgressbar = new DevExpress.XtraBars.BarEditItem();
            this.ProgressBarSavingProcess = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barbtnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnNew = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnExit = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuFormShortCuts = new DevExpress.XtraBars.PopupMenu(this.components);
            this.panelContent = new DevExpress.XtraEditors.PanelControl();
            this.backgroundWorkerLoadInitialValues = new System.ComponentModel.BackgroundWorker();
            this.ErrorProvider = new Alit.WinformControls.ErrorProvider(this.components);
            this.btnSetSaveFocus = new DevExpress.XtraEditors.SimpleButton();
            this.btnSetExitFocus = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
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
            this.btnRefresh,
            this.btnExit,
            this.btnSearch,
            this.lblCurrentViewCaption,
            this.lblFormCaption,
            this.btnPrint,
            this.btnPrintPreview,
            this.barbtnSave,
            this.barBtnPrintPreview,
            this.barBtnPrint,
            this.barBtnDelete,
            this.barBtnNew,
            this.barBtnSearch,
            this.barBtnExit,
            this.lblCreateAt,
            this.lblEditedAt,
            this.beiProgressbar,
            this.btnCloseForm});
            this.barManager1.MaxItemId = 29;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ProgressBarSavingProcess});
            this.barManager1.StatusBar = this.barFormFooter;
            // 
            // barFormHeader
            // 
            this.barFormHeader.BarName = "Tools";
            this.barFormHeader.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barFormHeader.DockCol = 0;
            this.barFormHeader.DockRow = 0;
            this.barFormHeader.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barFormHeader.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblFormCaption, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCurrentViewCaption),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCloseForm)});
            this.barFormHeader.OptionsBar.AllowQuickCustomization = false;
            this.barFormHeader.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.barFormHeader.OptionsBar.DisableClose = true;
            this.barFormHeader.OptionsBar.DisableCustomization = true;
            this.barFormHeader.OptionsBar.DrawDragBorder = false;
            this.barFormHeader.OptionsBar.UseWholeRow = true;
            this.barFormHeader.Text = "Tools";
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.lblFormCaption.Caption = "Title";
            this.lblFormCaption.Id = 15;
            this.lblFormCaption.ItemAppearance.Normal.FontSizeDelta = 2;
            this.lblFormCaption.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lblFormCaption.ItemAppearance.Normal.Options.UseFont = true;
            this.lblFormCaption.Name = "lblFormCaption";
            // 
            // lblCurrentViewCaption
            // 
            this.lblCurrentViewCaption.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.lblCurrentViewCaption.Caption = "New";
            this.lblCurrentViewCaption.Id = 14;
            this.lblCurrentViewCaption.ItemAppearance.Normal.FontSizeDelta = 2;
            this.lblCurrentViewCaption.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lblCurrentViewCaption.ItemAppearance.Normal.Options.UseFont = true;
            this.lblCurrentViewCaption.Name = "lblCurrentViewCaption";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Caption = "Close";
            this.btnCloseForm.Id = 28;
            this.btnCloseForm.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Close_Window_16;
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCloseForm_ItemClick);
            // 
            // barFormFooter
            // 
            this.barFormFooter.BarName = "Tools";
            this.barFormFooter.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barFormFooter.DockCol = 0;
            this.barFormFooter.DockRow = 0;
            this.barFormFooter.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barFormFooter.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrintPreview, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSearch, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreateAt),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditedAt),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.beiProgressbar, "", false, true, true, 143)});
            this.barFormFooter.OptionsBar.AllowQuickCustomization = false;
            this.barFormFooter.OptionsBar.DrawDragBorder = false;
            this.barFormFooter.OptionsBar.UseWholeRow = true;
            this.barFormFooter.Text = "Status bar";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "&Save";
            this.btnSave.Id = 4;
            this.btnSave.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Save_Filled_16;
            this.btnSave.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnSave.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnSave.Name = "btnSave";
            this.btnSave.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnSave.ShortcutKeyDisplayString = "Ctr+S";
            this.btnSave.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Caption = "Print Preview";
            this.btnPrintPreview.Id = 17;
            this.btnPrintPreview.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Print_Preview_Filled__16;
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
            this.btnPrint.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Print_16;
            this.btnPrint.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnPrint.ItemAppearance.Normal.Options.UseFont = true;
            this.btnPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ShortcutKeyDisplayString = "Ctrl + Shift + P";
            this.btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "&Delete";
            this.btnDelete.Id = 5;
            this.btnDelete.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Delete_File_16;
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
            this.btnRefresh.Caption = "&New";
            this.btnRefresh.Id = 6;
            this.btnRefresh.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Create_New_16;
            this.btnRefresh.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ShortcutKeyDisplayString = "Ctr+N";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Caption = "Searc&h";
            this.btnSearch.Id = 13;
            this.btnSearch.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Search_16;
            this.btnSearch.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnSearch.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSearch.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F));
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ShortcutKeyDisplayString = "Ctr+F";
            this.btnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSearch_ItemClick);
            // 
            // lblCreateAt
            // 
            this.lblCreateAt.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblCreateAt.Caption = "Created By xx At aa";
            this.lblCreateAt.Id = 25;
            this.lblCreateAt.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lblCreateAt.ItemAppearance.Normal.Options.UseFont = true;
            this.lblCreateAt.Name = "lblCreateAt";
            // 
            // lblEditedAt
            // 
            this.lblEditedAt.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditedAt.Caption = "Edit By xx At xx";
            this.lblEditedAt.Id = 26;
            this.lblEditedAt.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lblEditedAt.ItemAppearance.Normal.Options.UseFont = true;
            this.lblEditedAt.Name = "lblEditedAt";
            // 
            // btnExit
            // 
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnExit.Caption = "E&xit";
            this.btnExit.Id = 11;
            this.btnExit.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Exit_16;
            this.btnExit.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnExit.ItemAppearance.Normal.Options.UseFont = true;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(989, 28);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 332);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(989, 28);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 304);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(989, 28);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 304);
            // 
            // barbtnSave
            // 
            this.barbtnSave.Caption = "Save";
            this.barbtnSave.Id = 18;
            this.barbtnSave.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Save_Filled_16;
            this.barbtnSave.Name = "barbtnSave";
            this.barbtnSave.ShortcutKeyDisplayString = "Ctrl + S";
            this.barbtnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // barBtnPrintPreview
            // 
            this.barBtnPrintPreview.Caption = "Print Preview";
            this.barBtnPrintPreview.Id = 19;
            this.barBtnPrintPreview.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Print_Preview_Filled__16;
            this.barBtnPrintPreview.Name = "barBtnPrintPreview";
            this.barBtnPrintPreview.ShortcutKeyDisplayString = "Ctrl+Shift+P";
            this.barBtnPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barBtnPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrintPreview_ItemClick);
            // 
            // barBtnPrint
            // 
            this.barBtnPrint.Caption = "Print";
            this.barBtnPrint.Id = 20;
            this.barBtnPrint.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Print_16;
            this.barBtnPrint.Name = "barBtnPrint";
            this.barBtnPrint.ShortcutKeyDisplayString = "Ctrl+P";
            this.barBtnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barBtnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // barBtnDelete
            // 
            this.barBtnDelete.Caption = "Delete";
            this.barBtnDelete.Id = 21;
            this.barBtnDelete.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Delete_File_16;
            this.barBtnDelete.Name = "barBtnDelete";
            this.barBtnDelete.ShortcutKeyDisplayString = "Ctrl + D";
            this.barBtnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barBtnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // barBtnNew
            // 
            this.barBtnNew.Caption = "New";
            this.barBtnNew.Id = 22;
            this.barBtnNew.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Refresh_16;
            this.barBtnNew.Name = "barBtnNew";
            this.barBtnNew.ShortcutKeyDisplayString = "Ctrl + N";
            this.barBtnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // barBtnSearch
            // 
            this.barBtnSearch.Caption = "Search";
            this.barBtnSearch.Id = 23;
            this.barBtnSearch.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Search_16;
            this.barBtnSearch.Name = "barBtnSearch";
            this.barBtnSearch.ShortcutKeyDisplayString = "Ctrl + F";
            this.barBtnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSearch_ItemClick);
            // 
            // barBtnExit
            // 
            this.barBtnExit.Caption = "Exit";
            this.barBtnExit.Id = 24;
            this.barBtnExit.ImageOptions.Image = global::Alit.Marker.WinForm.Properties.Resources.Exit_16;
            this.barBtnExit.Name = "barBtnExit";
            this.barBtnExit.ShortcutKeyDisplayString = "Ctrl + X";
            this.barBtnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // popupMenuFormShortCuts
            // 
            this.popupMenuFormShortCuts.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barbtnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPrintPreview),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSearch),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnExit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.popupMenuFormShortCuts.Manager = this.barManager1;
            this.popupMenuFormShortCuts.Name = "popupMenuFormShortCuts";
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 28);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(989, 304);
            this.panelContent.TabIndex = 0;
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
            // frmCRUDTemplate
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnSetExitFocus;
            this.ClientSize = new System.Drawing.Size(989, 360);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.btnSetExitFocus);
            this.Controls.Add(this.btnSetSaveFocus);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCRUDTemplate";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Template";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraBars.BarManager barManager1;
        public DevExpress.XtraBars.Bar barFormHeader;
        public DevExpress.XtraBars.Bar barFormFooter;
        public DevExpress.XtraBars.BarDockControl barDockControlTop;
        public DevExpress.XtraBars.BarDockControl barDockControlBottom;
        public DevExpress.XtraBars.BarDockControl barDockControlLeft;
        public DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraBars.BarButtonItem btnSave;
        public DevExpress.XtraBars.BarButtonItem btnDelete;
        public DevExpress.XtraBars.BarButtonItem btnRefresh;
        public DevExpress.XtraBars.BarButtonItem btnExit;
        public DevExpress.XtraBars.BarButtonItem btnSearch;
        public DevExpress.XtraEditors.PanelControl panelContent;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadInitialValues;
        public Alit.WinformControls.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.SimpleButton btnSetExitFocus;
        private DevExpress.XtraEditors.SimpleButton btnSetSaveFocus;
        private DevExpress.XtraBars.BarStaticItem lblCurrentViewCaption;
        private DevExpress.XtraBars.BarStaticItem lblFormCaption;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnPrintPreview;
        private DevExpress.XtraBars.BarButtonItem barbtnSave;
        private DevExpress.XtraBars.BarButtonItem barBtnPrintPreview;
        private DevExpress.XtraBars.PopupMenu popupMenuFormShortCuts;
        private DevExpress.XtraBars.BarButtonItem barBtnPrint;
        private DevExpress.XtraBars.BarButtonItem barBtnDelete;
        private DevExpress.XtraBars.BarButtonItem barBtnNew;
        private DevExpress.XtraBars.BarButtonItem barBtnSearch;
        private DevExpress.XtraBars.BarButtonItem barBtnExit;
        public DevExpress.XtraBars.BarStaticItem lblCreateAt;
        public DevExpress.XtraBars.BarStaticItem lblEditedAt;
        private DevExpress.XtraBars.BarEditItem beiProgressbar;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar ProgressBarSavingProcess;
        private DevExpress.XtraBars.BarButtonItem btnCloseForm;
    }
}