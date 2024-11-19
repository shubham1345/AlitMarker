namespace Alit.Marker.WinForm.Inventory.Reports
{
    partial class frmRepStockLedger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepStockLedger));
            this.deDateFrom = new Alit.WinformControls.DateEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.deDateTo = new Alit.WinformControls.DateEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.stockLedgerReportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVoucherTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNarration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRunningStock = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            this.lcTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockLedgerReportModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            // 
            // 
            // 
            this.ribbonControl1.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl1.SearchEditItem.EditWidth = 150;
            this.ribbonControl1.SearchEditItem.Id = -5000;
            this.ribbonControl1.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            // 
            // RootTitle
            // 
            this.RootTitle.Size = new System.Drawing.Size(1141, 61);
            // 
            // lcTitle
            // 
            this.lcTitle.Controls.Add(this.deDateTo);
            this.lcTitle.Controls.Add(this.deDateFrom);
            this.lcTitle.OptionsView.HighlightFocusedItem = true;
            this.lcTitle.Size = new System.Drawing.Size(1141, 61);
            // 
            // lcgDefaultFilterGroupBox
            // 
            this.lcgDefaultFilterGroupBox.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2});
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(235, 61);
            this.lcgDefaultFilterGroupBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(235, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(906, 61);
            this.lblFormCaption.Text = "Stock Ledger";
            this.lblFormCaption.TextSize = new System.Drawing.Size(190, 38);
            // 
            // deDateFrom
            // 
            this.deDateFrom.EditValue = null;
            this.deDateFrom.EnterMoveNextControl = true;
            this.deDateFrom.Location = new System.Drawing.Point(105, 4);
            this.deDateFrom.MaximumSize = new System.Drawing.Size(125, 0);
            this.deDateFrom.MenuManager = this.ribbonControl1;
            this.deDateFrom.MinimumSize = new System.Drawing.Size(90, 0);
            this.deDateFrom.Name = "deDateFrom";
            this.deDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Size = new System.Drawing.Size(125, 22);
            this.deDateFrom.StyleController = this.lcTitle;
            this.deDateFrom.TabIndex = 4;
            this.deDateFrom.Validating += new System.ComponentModel.CancelEventHandler(this.deDateFrom_Validating);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deDateFrom;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(209, 26);
            this.layoutControlItem1.Text = "Date From";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(75, 0);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 52);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(56, 1);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(209, 4);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // deDateTo
            // 
            this.deDateTo.EditValue = null;
            this.deDateTo.EnterMoveNextControl = true;
            this.deDateTo.Location = new System.Drawing.Point(105, 30);
            this.deDateTo.MaximumSize = new System.Drawing.Size(125, 0);
            this.deDateTo.MenuManager = this.ribbonControl1;
            this.deDateTo.MinimumSize = new System.Drawing.Size(90, 0);
            this.deDateTo.Name = "deDateTo";
            this.deDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Size = new System.Drawing.Size(125, 22);
            this.deDateTo.StyleController = this.lcTitle;
            this.deDateTo.TabIndex = 5;
            this.deDateTo.Validating += new System.ComponentModel.CancelEventHandler(this.deDateTo_Validating);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.deDateTo;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(209, 26);
            this.layoutControlItem2.Text = "Date To";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(75, 0);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.stockLedgerReportModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 220);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1141, 387);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // stockLedgerReportModelBindingSource
            // 
            this.stockLedgerReportModelBindingSource.DataSource = typeof(Alit.Marker.Model.Inventory.Reports.StockLedgerReportModel);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.ColumnPanelRowHeight = 50;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVoucherTypeName,
            this.colVDate,
            this.colVNo,
            this.colNarration,
            this.colCustomerName,
            this.colQtyIn,
            this.colQtyOut,
            this.colRate,
            this.colAmt,
            this.colRunningStock});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(206, -159, 266, 544);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colVoucherTypeName
            // 
            this.colVoucherTypeName.FieldName = "VoucherTypeName";
            this.colVoucherTypeName.MaxWidth = 150;
            this.colVoucherTypeName.MinWidth = 50;
            this.colVoucherTypeName.Name = "colVoucherTypeName";
            this.colVoucherTypeName.Visible = true;
            this.colVoucherTypeName.VisibleIndex = 0;
            this.colVoucherTypeName.Width = 50;
            // 
            // colVDate
            // 
            this.colVDate.FieldName = "VDate";
            this.colVDate.MaxWidth = 100;
            this.colVDate.MinWidth = 90;
            this.colVDate.Name = "colVDate";
            this.colVDate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "VDate", "{0} Records")});
            this.colVDate.Visible = true;
            this.colVDate.VisibleIndex = 1;
            this.colVDate.Width = 90;
            // 
            // colVNo
            // 
            this.colVNo.FieldName = "VNo";
            this.colVNo.MaxWidth = 100;
            this.colVNo.MinWidth = 60;
            this.colVNo.Name = "colVNo";
            this.colVNo.Visible = true;
            this.colVNo.VisibleIndex = 2;
            this.colVNo.Width = 60;
            // 
            // colNarration
            // 
            this.colNarration.FieldName = "Narration";
            this.colNarration.MinWidth = 100;
            this.colNarration.Name = "colNarration";
            this.colNarration.Visible = true;
            this.colNarration.VisibleIndex = 3;
            this.colNarration.Width = 300;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.MinWidth = 100;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 4;
            this.colCustomerName.Width = 235;
            // 
            // colQtyIn
            // 
            this.colQtyIn.DisplayFormat.FormatString = "n2";
            this.colQtyIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyIn.FieldName = "QtyIn";
            this.colQtyIn.MaxWidth = 125;
            this.colQtyIn.MinWidth = 75;
            this.colQtyIn.Name = "colQtyIn";
            this.colQtyIn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QtyIn", "{0:0.##}")});
            this.colQtyIn.Visible = true;
            this.colQtyIn.VisibleIndex = 5;
            // 
            // colQtyOut
            // 
            this.colQtyOut.DisplayFormat.FormatString = "n2";
            this.colQtyOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyOut.FieldName = "QtyOut";
            this.colQtyOut.MaxWidth = 125;
            this.colQtyOut.MinWidth = 75;
            this.colQtyOut.Name = "colQtyOut";
            this.colQtyOut.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QtyOut", "{0:0.##}")});
            this.colQtyOut.Visible = true;
            this.colQtyOut.VisibleIndex = 6;
            // 
            // colRate
            // 
            this.colRate.DisplayFormat.FormatString = "n2";
            this.colRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRate.FieldName = "Rate";
            this.colRate.MaxWidth = 125;
            this.colRate.MinWidth = 75;
            this.colRate.Name = "colRate";
            this.colRate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Rate", "{0:0.##}")});
            this.colRate.Visible = true;
            this.colRate.VisibleIndex = 8;
            // 
            // colAmt
            // 
            this.colAmt.DisplayFormat.FormatString = "n2";
            this.colAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmt.FieldName = "Amt";
            this.colAmt.MaxWidth = 125;
            this.colAmt.MinWidth = 75;
            this.colAmt.Name = "colAmt";
            this.colAmt.OptionsColumn.ReadOnly = true;
            this.colAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amt", "{0:0.##}")});
            this.colAmt.Visible = true;
            this.colAmt.VisibleIndex = 9;
            // 
            // colRunningStock
            // 
            this.colRunningStock.DisplayFormat.FormatString = "n2";
            this.colRunningStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRunningStock.FieldName = "RunningStock";
            this.colRunningStock.MaxWidth = 125;
            this.colRunningStock.MinWidth = 75;
            this.colRunningStock.Name = "colRunningStock";
            this.colRunningStock.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RunningStock", "{0:0.##}")});
            this.colRunningStock.Visible = true;
            this.colRunningStock.VisibleIndex = 7;
            // 
            // frmRepStockLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 630);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmRepStockLedger.IconOptions.Icon")));
            this.Name = "frmRepStockLedger";
            this.ShowDefaultFilter = true;
            this.Text = "Stock Ledger";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.lcTitle, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).EndInit();
            this.lcTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockLedgerReportModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinformControls.DateEdit deDateTo;
        private WinformControls.DateEdit deDateFrom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource stockLedgerReportModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colVoucherTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colVDate;
        private DevExpress.XtraGrid.Columns.GridColumn colVNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyIn;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyOut;
        private DevExpress.XtraGrid.Columns.GridColumn colRate;
        private DevExpress.XtraGrid.Columns.GridColumn colAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colRunningStock;
        private DevExpress.XtraGrid.Columns.GridColumn colNarration;
    }
}