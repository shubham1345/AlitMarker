namespace Alit.Marker.WinForm.Reports.Sales
{
    partial class frmSaleSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleSummary));
            this.layoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.lookupCustomer = new Alit.WinformControls.LookUpEdit();
            this.dtEditDateTo = new Alit.WinformControls.DateEdit();
            this.dteInvDateFrom = new Alit.WinformControls.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCustomer = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonPrintOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentViewerRibbonController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelParameterContents)).BeginInit();
            this.panelParameterContents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEditDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEditDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteInvDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteInvDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Size = new System.Drawing.Size(111, 319);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 361);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Location = new System.Drawing.Point(809, 28);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 361);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 389);
            this.barDockControlBottom.Size = new System.Drawing.Size(809, 28);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Size = new System.Drawing.Size(809, 28);
            // 
            // btnExit
            // 
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnExit.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // btnSearch
            // 
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnSearch.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnDelete.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerateReport.ImageOptions.Image")));
            this.btnGenerateReport.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnGenerateReport.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // barFormFooter
            // 
            this.barFormFooter.OptionsBar.AllowQuickCustomization = false;
            this.barFormFooter.OptionsBar.DrawDragBorder = false;
            this.barFormFooter.OptionsBar.UseWholeRow = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // barFormHeader
            // 
            this.barFormHeader.OptionsBar.AllowQuickCustomization = false;
            this.barFormHeader.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.barFormHeader.OptionsBar.DisableClose = true;
            this.barFormHeader.OptionsBar.DisableCustomization = true;
            this.barFormHeader.OptionsBar.DrawDragBorder = false;
            this.barFormHeader.OptionsBar.UseWholeRow = true;
            // 
            // dockPanelParameters
            // 
            this.dockPanelParameters.Location = new System.Drawing.Point(0, 28);
            this.dockPanelParameters.Size = new System.Drawing.Size(120, 361);
            // 
            // DocViwer
            // 
            this.DocViwer.HorizontalScrollBarVisibility = DevExpress.XtraEditors.ViewInfo.ScrollBarVisibility.Visible;
            this.DocViwer.Size = new System.Drawing.Size(689, 284);
            this.DocViwer.VerticalScrollBarVisibility = DevExpress.XtraEditors.ViewInfo.ScrollBarVisibility.Visible;
            // 
            // ribbonPrintOptions
            // 
            this.ribbonPrintOptions.ExpandCollapseItem.Id = 0;
            this.ribbonPrintOptions.Size = new System.Drawing.Size(689, 49);
            this.ribbonPrintOptions.Toolbar.ShowCustomizeItem = false;
            // 
            // panelParameterContents
            // 
            this.panelParameterContents.Controls.Add(this.layoutControl1);
            this.panelParameterContents.Size = new System.Drawing.Size(107, 315);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lookupCustomer);
            this.layoutControl1.Controls.Add(this.dtEditDateTo);
            this.layoutControl1.Controls.Add(this.dteInvDateFrom);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(103, 311);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lookupCustomer
            // 
            this.lookupCustomer.EnterMoveNextControl = true;
            this.lookupCustomer.Location = new System.Drawing.Point(12, 108);
            this.lookupCustomer.Name = "lookupCustomer";
            this.lookupCustomer.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookupCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupCustomer.Properties.NullText = "Select";
            this.lookupCustomer.Size = new System.Drawing.Size(79, 20);
            this.lookupCustomer.StyleController = this.layoutControl1;
            this.lookupCustomer.TabIndex = 6;
            // 
            // dtEditDateTo
            // 
            this.dtEditDateTo.EditValue = null;
            this.dtEditDateTo.EnterMoveNextControl = true;
            this.dtEditDateTo.Location = new System.Drawing.Point(12, 68);
            this.dtEditDateTo.Name = "dtEditDateTo";
            this.dtEditDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEditDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEditDateTo.Size = new System.Drawing.Size(79, 20);
            this.dtEditDateTo.StyleController = this.layoutControl1;
            this.dtEditDateTo.TabIndex = 5;
            // 
            // dteInvDateFrom
            // 
            this.dteInvDateFrom.EditValue = null;
            this.dteInvDateFrom.EnterMoveNextControl = true;
            this.dteInvDateFrom.Location = new System.Drawing.Point(12, 28);
            this.dteInvDateFrom.Name = "dteInvDateFrom";
            this.dteInvDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteInvDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteInvDateFrom.Size = new System.Drawing.Size(79, 20);
            this.dteInvDateFrom.StyleController = this.layoutControl1;
            this.dteInvDateFrom.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.lciCustomer,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(103, 311);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dteInvDateFrom;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(83, 40);
            this.layoutControlItem1.Text = "Date From";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtEditDateTo;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(83, 40);
            this.layoutControlItem2.Text = "Date To";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 13);
            // 
            // lciCustomer
            // 
            this.lciCustomer.Control = this.lookupCustomer;
            this.lciCustomer.Location = new System.Drawing.Point(0, 80);
            this.lciCustomer.Name = "lciCustomer";
            this.lciCustomer.Size = new System.Drawing.Size(83, 40);
            this.lciCustomer.Text = "Customer";
            this.lciCustomer.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciCustomer.TextSize = new System.Drawing.Size(50, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 120);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(83, 171);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmSaleSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 417);
            this.FirstControl = this.panelParameterContents;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSaleSummary";
            this.Text = "Sale Summary";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonPrintOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentViewerRibbonController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelParameterContents)).EndInit();
            this.panelParameterContents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookupCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEditDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEditDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteInvDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteInvDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alit.WinformControls.myLayoutControl layoutControl1;
        private Alit.WinformControls.LookUpEdit lookupCustomer;
        private Alit.WinformControls.DateEdit dtEditDateTo;
        private Alit.WinformControls.DateEdit dteInvDateFrom;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem lciCustomer;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}