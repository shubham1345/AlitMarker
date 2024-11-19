namespace Alit.Marker.WinForm.Template
{
    partial class frmSearchWindowTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchWindowTemplate));
            this.btnSetExitFocus = new DevExpress.XtraEditors.SimpleButton();
            this.ErrorProvider = new Alit.WinformControls.ErrorProvider(this.components);
            this.backgroundWorkerLoadInitialValues = new System.ComponentModel.BackgroundWorker();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barFormFooter = new DevExpress.XtraBars.Bar();
            this.btnSelect = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.lblRecordNo = new DevExpress.XtraBars.BarHeaderItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilter = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowDetails = new DevExpress.XtraBars.BarButtonItem();
            this.btnExpandAllDetail = new DevExpress.XtraBars.BarButtonItem();
            this.btnCollapsAllDetail = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanelFilter = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.accordionControlAutoFilter = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.panelContent = new DevExpress.XtraEditors.PanelControl();
            this.btnSetSaveFocus = new DevExpress.XtraEditors.SimpleButton();
            this.filteringUIContext1 = new DevExpress.Utils.Filtering.FilteringUIContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanelFilter.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControlAutoFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteringUIContext1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetExitFocus
            // 
            this.btnSetExitFocus.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSetExitFocus.Location = new System.Drawing.Point(581, 306);
            this.btnSetExitFocus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetExitFocus.Name = "btnSetExitFocus";
            this.btnSetExitFocus.Size = new System.Drawing.Size(138, 52);
            this.btnSetExitFocus.TabIndex = 2;
            this.btnSetExitFocus.TabStop = false;
            this.btnSetExitFocus.Text = "Set Exit Focus";
            this.btnSetExitFocus.Enter += new System.EventHandler(this.btnSetExitFocus_Click);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // backgroundWorkerLoadInitialValues
            // 
            this.backgroundWorkerLoadInitialValues.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoadInitialValues_DoWork);
            this.backgroundWorkerLoadInitialValues.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoadInitialValues_RunWorkerCompleted);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 32);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 572);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barFormFooter,
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSelect,
            this.btnExit,
            this.lblRecordNo,
            this.btnAddNew,
            this.btnEdit,
            this.btnFilter,
            this.btnShowDetails,
            this.btnExpandAllDetail,
            this.btnCollapsAllDetail,
            this.btnRefresh});
            this.barManager1.MaxItemId = 33;
            this.barManager1.StatusBar = this.barFormFooter;
            // 
            // barFormFooter
            // 
            this.barFormFooter.BarAppearance.Normal.FontSizeDelta = 1;
            this.barFormFooter.BarAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.barFormFooter.BarAppearance.Normal.Options.UseFont = true;
            this.barFormFooter.BarName = "Tools";
            this.barFormFooter.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barFormFooter.DockCol = 0;
            this.barFormFooter.DockRow = 0;
            this.barFormFooter.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barFormFooter.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSelect, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExit, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblRecordNo)});
            this.barFormFooter.OptionsBar.AllowQuickCustomization = false;
            this.barFormFooter.OptionsBar.DrawDragBorder = false;
            this.barFormFooter.OptionsBar.UseWholeRow = true;
            this.barFormFooter.Text = "Status bar";
            // 
            // btnSelect
            // 
            this.btnSelect.Caption = "&Save";
            this.btnSelect.Id = 4;
            this.btnSelect.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSelect.ImageOptions.SvgImage")));
            this.btnSelect.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnSelect.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnSelect.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSelect.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.ShortcutKeyDisplayString = "C+N";
            this.btnSelect.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.btnSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelect_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnExit.Caption = "&Cancel";
            this.btnExit.Id = 11;
            this.btnExit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExit.ImageOptions.SvgImage")));
            this.btnExit.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnExit.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnExit.ItemAppearance.Normal.Options.UseFont = true;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // lblRecordNo
            // 
            this.lblRecordNo.Caption = "0 of 0 Record(s)";
            this.lblRecordNo.Id = 23;
            this.lblRecordNo.Name = "lblRecordNo";
            // 
            // bar1
            // 
            this.bar1.BarAppearance.Disabled.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.bar1.BarAppearance.Disabled.Options.UseFont = true;
            this.bar1.BarAppearance.Hovered.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.bar1.BarAppearance.Hovered.Options.UseFont = true;
            this.bar1.BarAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.bar1.BarAppearance.Normal.Options.UseFont = true;
            this.bar1.BarAppearance.Pressed.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.bar1.BarAppearance.Pressed.Options.UseFont = true;
            this.bar1.BarName = "Custom 3";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddNew, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFilter, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShowDetails, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExpandAllDetail),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCollapsAllDetail)});
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 3";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 31;
            this.btnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefresh.ImageOptions.SvgImage")));
            this.btnRefresh.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Caption = "Add New";
            this.btnAddNew.Id = 24;
            this.btnAddNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddNew.ImageOptions.SvgImage")));
            this.btnAddNew.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnAddNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnAddNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddNew_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Id = 25;
            this.btnEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEdit.ImageOptions.SvgImage")));
            this.btnEdit.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnFilter
            // 
            this.btnFilter.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnFilter.Caption = "&Filter";
            this.btnFilter.Down = true;
            this.btnFilter.Id = 27;
            this.btnFilter.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFilter.ImageOptions.SvgImage")));
            this.btnFilter.ItemAppearance.Normal.FontSizeDelta = 1;
            this.btnFilter.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnFilter.ItemAppearance.Normal.Options.UseFont = true;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnFilter.DownChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilter_DownChanged);
            this.btnFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilter_ItemClick);
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnShowDetails.Caption = "Show Details";
            this.btnShowDetails.Id = 28;
            this.btnShowDetails.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnShowDetails.ImageOptions.SvgImage")));
            this.btnShowDetails.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnShowDetails.ItemAppearance.Normal.FontSizeDelta = 1;
            this.btnShowDetails.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnShowDetails.ItemAppearance.Normal.Options.UseFont = true;
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnShowDetails.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnShowDetails.DownChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowDetails_DownChanged);
            // 
            // btnExpandAllDetail
            // 
            this.btnExpandAllDetail.Caption = "Expand All";
            this.btnExpandAllDetail.Id = 29;
            this.btnExpandAllDetail.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExpandAllDetail.ImageOptions.SvgImage")));
            this.btnExpandAllDetail.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnExpandAllDetail.Name = "btnExpandAllDetail";
            this.btnExpandAllDetail.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnExpandAllDetail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnExpandAllDetail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExpandAllDetail_ItemClick);
            // 
            // btnCollapsAllDetail
            // 
            this.btnCollapsAllDetail.Caption = "Collaps All";
            this.btnCollapsAllDetail.Id = 30;
            this.btnCollapsAllDetail.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCollapsAllDetail.ImageOptions.SvgImage")));
            this.btnCollapsAllDetail.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnCollapsAllDetail.Name = "btnCollapsAllDetail";
            this.btnCollapsAllDetail.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnCollapsAllDetail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCollapsAllDetail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCollapsAllDetail_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1048, 32);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 604);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1048, 34);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1048, 32);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 572);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelFilter});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanelFilter
            // 
            this.dockPanelFilter.Controls.Add(this.dockPanel1_Container);
            this.dockPanelFilter.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelFilter.ID = new System.Guid("1ce6c0f2-107e-4d6b-adc4-9dcfb41359d8");
            this.dockPanelFilter.Location = new System.Drawing.Point(848, 32);
            this.dockPanelFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dockPanelFilter.Name = "dockPanelFilter";
            this.dockPanelFilter.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelFilter.Size = new System.Drawing.Size(200, 572);
            this.dockPanelFilter.Text = "Filter";
            this.dockPanelFilter.VisibilityChanged += new DevExpress.XtraBars.Docking.VisibilityChangedEventHandler(this.dockPanelFilter_VisibilityChanged);
            this.dockPanelFilter.ClosedPanel += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.dockPanelFilter_ClosedPanel);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.accordionControlAutoFilter);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 26);
            this.dockPanel1_Container.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(193, 543);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // accordionControlAutoFilter
            // 
            this.accordionControlAutoFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accordionControlAutoFilter.Location = new System.Drawing.Point(0, 0);
            this.accordionControlAutoFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.accordionControlAutoFilter.Name = "accordionControlAutoFilter";
            this.accordionControlAutoFilter.Size = new System.Drawing.Size(193, 543);
            this.accordionControlAutoFilter.TabIndex = 0;
            this.accordionControlAutoFilter.Text = "accordionControl1";
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 32);
            this.panelContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(848, 572);
            this.panelContent.TabIndex = 11;
            // 
            // btnSetSaveFocus
            // 
            this.btnSetSaveFocus.Location = new System.Drawing.Point(327, 247);
            this.btnSetSaveFocus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetSaveFocus.Name = "btnSetSaveFocus";
            this.btnSetSaveFocus.Size = new System.Drawing.Size(138, 46);
            this.btnSetSaveFocus.TabIndex = 1;
            this.btnSetSaveFocus.TabStop = false;
            this.btnSetSaveFocus.Text = "Set Save Focus";
            this.btnSetSaveFocus.Enter += new System.EventHandler(this.btnSetSaveFocus_Enter);
            // 
            // filteringUIContext1
            // 
            this.filteringUIContext1.Control = this.accordionControlAutoFilter;
            // 
            // frmSearchWindowTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSetExitFocus;
            this.ClientSize = new System.Drawing.Size(1048, 638);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.btnSetSaveFocus);
            this.Controls.Add(this.btnSetExitFocus);
            this.Controls.Add(this.dockPanelFilter);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmSearchWindowTemplate.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSearchWindowTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanelFilter.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControlAutoFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteringUIContext1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraEditors.SimpleButton btnSetExitFocus;
        protected Alit.WinformControls.ErrorProvider ErrorProvider;
        protected DevExpress.XtraEditors.PanelControl panelContent;
        protected DevExpress.XtraEditors.SimpleButton btnSetSaveFocus;
        protected DevExpress.XtraBars.BarDockControl barDockControlLeft;
        protected DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected DevExpress.XtraBars.BarDockControl barDockControlBottom;
        protected DevExpress.XtraBars.BarDockControl barDockControlTop;
        protected System.ComponentModel.BackgroundWorker backgroundWorkerLoadInitialValues;
        protected DevExpress.XtraBars.BarButtonItem btnExit;
        protected DevExpress.XtraBars.BarButtonItem btnSelect;
        protected DevExpress.XtraBars.Bar barFormFooter;
        protected DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarHeaderItem lblRecordNo;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnAddNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnFilter;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelFilter;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControlAutoFilter;
        private DevExpress.Utils.Filtering.FilteringUIContext filteringUIContext1;
        private DevExpress.XtraBars.BarButtonItem btnShowDetails;
        private DevExpress.XtraBars.BarButtonItem btnExpandAllDetail;
        private DevExpress.XtraBars.BarButtonItem btnCollapsAllDetail;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
    }
}