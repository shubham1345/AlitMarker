namespace Alit.Marker.WinForm.Template
{
    partial class frmEditList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditList));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridEditList = new DevExpress.XtraGrid.GridControl();
            this.gridViewEditList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barFormFooter = new DevExpress.XtraBars.Bar();
            this.btnSelect = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.lblFormCaption = new DevExpress.XtraBars.BarStaticItem();
            this.batBtnSelect = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnExit = new DevExpress.XtraBars.BarButtonItem();
            this.btnEscapeSetFocus = new System.Windows.Forms.Button();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEditList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEditList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridEditList);
            this.panelControl2.Controls.Add(this.btnEscapeSetFocus);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(849, 315);
            this.panelControl2.TabIndex = 1;
            // 
            // gridEditList
            // 
            this.gridEditList.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridEditList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEditList.Location = new System.Drawing.Point(2, 2);
            this.gridEditList.MainView = this.gridViewEditList;
            this.gridEditList.MenuManager = this.barManager1;
            this.gridEditList.Name = "gridEditList";
            this.gridEditList.Size = new System.Drawing.Size(845, 311);
            this.gridEditList.TabIndex = 0;
            this.gridEditList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEditList});
            this.gridEditList.DoubleClick += new System.EventHandler(this.gridEditList_DoubleClick);
            // 
            // gridViewEditList
            // 
            this.gridViewEditList.GridControl = this.gridEditList;
            this.gridViewEditList.Name = "gridViewEditList";
            this.gridViewEditList.OptionsView.ShowAutoFilterRow = true;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barFormFooter});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblFormCaption,
            this.btnSelect,
            this.btnRefresh,
            this.btnCancel,
            this.barStaticItem1,
            this.btnPrintPreview,
            this.btnPrint,
            this.batBtnSelect,
            this.barBtnRefresh,
            this.barBtnPrintPreview,
            this.barBtnPrint,
            this.barBtnExit});
            this.barManager1.MaxItemId = 29;
            this.barManager1.StatusBar = this.barFormFooter;
            // 
            // barFormFooter
            // 
            this.barFormFooter.BarName = "Tools";
            this.barFormFooter.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barFormFooter.DockCol = 0;
            this.barFormFooter.DockRow = 0;
            this.barFormFooter.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barFormFooter.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSelect, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrintPreview, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCancel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barFormFooter.OptionsBar.AllowQuickCustomization = false;
            this.barFormFooter.OptionsBar.DrawDragBorder = false;
            this.barFormFooter.OptionsBar.UseWholeRow = true;
            this.barFormFooter.Text = "Status bar";
            // 
            // btnSelect
            // 
            this.btnSelect.Caption = "&Select";
            this.btnSelect.Id = 4;
            this.btnSelect.ImageOptions.Image = global::Alit.Marker.WinForm.Template.Properties.Resources.Checked_Checkbox_16;
            this.btnSelect.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnSelect.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSelect.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Enter));
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.btnSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelect_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "&Refresh";
            this.btnRefresh.Id = 6;
            this.btnRefresh.ImageOptions.Image = global::Alit.Marker.WinForm.Template.Properties.Resources.Refresh_16;
            this.btnRefresh.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Caption = "Print Preview";
            this.btnPrintPreview.Id = 17;
            this.btnPrintPreview.ImageOptions.Image = global::Alit.Marker.WinForm.Template.Properties.Resources.Print_Preview_Filled__16;
            this.btnPrintPreview.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnPrintPreview.ItemAppearance.Normal.Options.UseFont = true;
            this.btnPrintPreview.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.P));
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.ShortcutKeyDisplayString = "Ctrl + P";
            this.btnPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrintPreview_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Print";
            this.btnPrint.Id = 23;
            this.btnPrint.ImageOptions.Image = global::Alit.Marker.WinForm.Template.Properties.Resources.Print_16;
            this.btnPrint.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnPrint.ItemAppearance.Normal.Options.UseFont = true;
            this.btnPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ShortcutKeyDisplayString = "Ctrl + Shift + P";
            this.btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Press Ctrl+Enter or Alt+S to select record.";
            this.barStaticItem1.Id = 16;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnCancel.Caption = "&Cancel";
            this.btnCancel.Id = 11;
            this.btnCancel.ImageOptions.Image = global::Alit.Marker.WinForm.Template.Properties.Resources.Close_Window_16;
            this.btnCancel.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnCancel.ItemAppearance.Normal.Options.UseFont = true;
            this.btnCancel.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShortcutKeyDisplayString = "Ctr+X";
            this.btnCancel.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(849, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 315);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(849, 28);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 315);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(849, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 315);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblFormCaption.Caption = "Form Caption";
            this.lblFormCaption.Id = 3;
            this.lblFormCaption.Name = "lblFormCaption";
            // 
            // batBtnSelect
            // 
            this.batBtnSelect.Caption = "Select";
            this.batBtnSelect.Id = 24;
            this.batBtnSelect.ImageOptions.Image = global::Alit.Marker.WinForm.Template.Properties.Resources.Checked_Checkbox_16;
            this.batBtnSelect.Name = "batBtnSelect";
            this.batBtnSelect.ShortcutKeyDisplayString = "Ctrl + Enter";
            this.batBtnSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelect_ItemClick);
            // 
            // barBtnRefresh
            // 
            this.barBtnRefresh.Caption = "Refresh";
            this.barBtnRefresh.Id = 25;
            this.barBtnRefresh.ImageOptions.Image = global::Alit.Marker.WinForm.Template.Properties.Resources.Refresh_16;
            this.barBtnRefresh.Name = "barBtnRefresh";
            this.barBtnRefresh.ShortcutKeyDisplayString = "Ctrl + R";
            this.barBtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // barBtnPrintPreview
            // 
            this.barBtnPrintPreview.Caption = "Print Preview";
            this.barBtnPrintPreview.Id = 26;
            this.barBtnPrintPreview.ImageOptions.Image = global::Alit.Marker.WinForm.Template.Properties.Resources.Print_Preview_Filled__16;
            this.barBtnPrintPreview.Name = "barBtnPrintPreview";
            this.barBtnPrintPreview.ShortcutKeyDisplayString = "Ctrl + P";
            // 
            // barBtnPrint
            // 
            this.barBtnPrint.Caption = "Print";
            this.barBtnPrint.Id = 27;
            this.barBtnPrint.ImageOptions.Image = global::Alit.Marker.WinForm.Template.Properties.Resources.Print_16;
            this.barBtnPrint.Name = "barBtnPrint";
            this.barBtnPrint.ShortcutKeyDisplayString = "Ctrl + Shift + P";
            // 
            // barBtnExit
            // 
            this.barBtnExit.Caption = "Exit";
            this.barBtnExit.Id = 28;
            this.barBtnExit.ImageOptions.Image = global::Alit.Marker.WinForm.Template.Properties.Resources.Exit_16;
            this.barBtnExit.Name = "barBtnExit";
            this.barBtnExit.ShortcutKeyDisplayString = "Ctrl + X";
            this.barBtnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // btnEscapeSetFocus
            // 
            this.btnEscapeSetFocus.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEscapeSetFocus.Location = new System.Drawing.Point(580, 122);
            this.btnEscapeSetFocus.Name = "btnEscapeSetFocus";
            this.btnEscapeSetFocus.Size = new System.Drawing.Size(75, 23);
            this.btnEscapeSetFocus.TabIndex = 1;
            this.btnEscapeSetFocus.Text = "button1";
            this.btnEscapeSetFocus.UseVisualStyleBackColor = true;
            this.btnEscapeSetFocus.Enter += new System.EventHandler(this.btnEscapeSetFocus_Enter);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.batBtnSelect),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPrintPreview),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnExit)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // frmEditList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnEscapeSetFocus;
            this.ClientSize = new System.Drawing.Size(849, 343);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmEditList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Record for Edit / Delete";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEditList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEditList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraBars.BarManager barManager1;
        public DevExpress.XtraBars.BarStaticItem lblFormCaption;
        public DevExpress.XtraBars.Bar barFormFooter;
        public DevExpress.XtraBars.BarButtonItem btnSelect;
        public DevExpress.XtraBars.BarButtonItem btnRefresh;
        public DevExpress.XtraBars.BarButtonItem btnCancel;
        public DevExpress.XtraBars.BarDockControl barDockControlTop;
        public DevExpress.XtraBars.BarDockControl barDockControlBottom;
        public DevExpress.XtraBars.BarDockControl barDockControlLeft;
        public DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraGrid.GridControl gridEditList;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private System.Windows.Forms.Button btnEscapeSetFocus;
        private DevExpress.XtraBars.BarButtonItem btnPrintPreview;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem batBtnSelect;
        private DevExpress.XtraBars.BarButtonItem barBtnRefresh;
        private DevExpress.XtraBars.BarButtonItem barBtnPrintPreview;
        private DevExpress.XtraBars.BarButtonItem barBtnPrint;
        private DevExpress.XtraBars.BarButtonItem barBtnExit;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridViewEditList;
    }
}