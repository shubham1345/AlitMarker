namespace Alit.Marker.WinForm.Inventory.Reports
{
    partial class frmRepStockInHand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepStockInHand));
            this.deDateFrom = new Alit.WinformControls.DateEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.deDateTo = new Alit.WinformControls.DateEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.stockInHandReportModelBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpeningStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleReturn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseReturn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOther = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClosingStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHSN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.stockInHandReportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.stockInHandReportModelBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockInHandReportModelBindingSource)).BeginInit();
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
            this.ribbonControl1.Size = new System.Drawing.Size(1206, 159);
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1206, 23);
            // 
            // RootTitle
            // 
            this.RootTitle.Size = new System.Drawing.Size(1206, 61);
            // 
            // lcTitle
            // 
            this.lcTitle.Controls.Add(this.deDateTo);
            this.lcTitle.Controls.Add(this.deDateFrom);
            this.lcTitle.OptionsView.HighlightFocusedItem = true;
            this.lcTitle.Size = new System.Drawing.Size(1206, 61);
            // 
            // lcgDefaultFilterGroupBox
            // 
            this.lcgDefaultFilterGroupBox.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2});
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(247, 61);
            this.lcgDefaultFilterGroupBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(247, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(959, 61);
            this.lblFormCaption.Text = "Stock In Hand";
            this.lblFormCaption.TextSize = new System.Drawing.Size(203, 38);
            // 
            // deDateFrom
            // 
            this.deDateFrom.EditValue = null;
            this.deDateFrom.EnterMoveNextControl = true;
            this.deDateFrom.Location = new System.Drawing.Point(117, 4);
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
            this.deDateFrom.EditValueChanged += new System.EventHandler(this.deDateFrom_EditValueChanged);
            this.deDateFrom.Validating += new System.ComponentModel.CancelEventHandler(this.deDateFrom_Validating);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deDateFrom;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(221, 26);
            this.layoutControlItem1.Text = "Date From";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(87, 0);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 52);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(35, 1);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(221, 4);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // deDateTo
            // 
            this.deDateTo.EditValue = null;
            this.deDateTo.EnterMoveNextControl = true;
            this.deDateTo.Location = new System.Drawing.Point(117, 30);
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
            this.deDateTo.EditValueChanged += new System.EventHandler(this.deDateTo_EditValueChanged);
            this.deDateTo.Validating += new System.ComponentModel.CancelEventHandler(this.deDateTo_Validating);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.deDateTo;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(221, 26);
            this.layoutControlItem2.Text = "Date To";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(87, 0);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.stockInHandReportModelBindingSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 220);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1206, 387);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
           
            // 
            // stockInHandReportModelBindingSource1
            // 
            this.stockInHandReportModelBindingSource1.DataSource = typeof(Alit.Marker.Model.Inventory.Reports.StockInHandReportModel);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.ColumnPanelRowHeight = 50;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPCode,
            this.colProductName,
            this.colUnitName,
            this.colOpeningStock,
            this.colSale,
            this.colPurchase,
            this.colSaleReturn,
            this.colPurchaseReturn,
            this.colStockIn,
            this.colStockOut,
            this.colOther,
            this.colClosingStock,
            this.colPurchaseRate,
            this.colCostValue,
            this.colHSN,
            this.colBarCode});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(206, -159, 266, 544);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colPCode
            // 
            this.colPCode.FieldName = "PCode";
            this.colPCode.MaxWidth = 100;
            this.colPCode.MinWidth = 60;
            this.colPCode.Name = "colPCode";
            this.colPCode.Visible = true;
            this.colPCode.VisibleIndex = 0;
            this.colPCode.Width = 60;
            // 
            // colProductName
            // 
            this.colProductName.FieldName = "ProductName";
            this.colProductName.MaxWidth = 500;
            this.colProductName.MinWidth = 100;
            this.colProductName.Name = "colProductName";
            this.colProductName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProductName", "{0} Records")});
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 3;
            this.colProductName.Width = 231;
            // 
            // colUnitName
            // 
            this.colUnitName.FieldName = "UnitName";
            this.colUnitName.MaxWidth = 100;
            this.colUnitName.MinWidth = 60;
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.Visible = true;
            this.colUnitName.VisibleIndex = 4;
            this.colUnitName.Width = 60;
            // 
            // colOpeningStock
            // 
            this.colOpeningStock.DisplayFormat.FormatString = "n2";
            this.colOpeningStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOpeningStock.FieldName = "OpeningStock";
            this.colOpeningStock.MaxWidth = 125;
            this.colOpeningStock.MinWidth = 75;
            this.colOpeningStock.Name = "colOpeningStock";
            this.colOpeningStock.Visible = true;
            this.colOpeningStock.VisibleIndex = 5;
            // 
            // colSale
            // 
            this.colSale.DisplayFormat.FormatString = "n2";
            this.colSale.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSale.FieldName = "Sale";
            this.colSale.MaxWidth = 125;
            this.colSale.MinWidth = 75;
            this.colSale.Name = "colSale";
            this.colSale.Visible = true;
            this.colSale.VisibleIndex = 6;
            // 
            // colPurchase
            // 
            this.colPurchase.DisplayFormat.FormatString = "n2";
            this.colPurchase.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPurchase.FieldName = "Purchase";
            this.colPurchase.MaxWidth = 125;
            this.colPurchase.MinWidth = 75;
            this.colPurchase.Name = "colPurchase";
            this.colPurchase.Visible = true;
            this.colPurchase.VisibleIndex = 7;
            // 
            // colSaleReturn
            // 
            this.colSaleReturn.DisplayFormat.FormatString = "n2";
            this.colSaleReturn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaleReturn.FieldName = "SaleReturn";
            this.colSaleReturn.MaxWidth = 125;
            this.colSaleReturn.MinWidth = 75;
            this.colSaleReturn.Name = "colSaleReturn";
            this.colSaleReturn.Visible = true;
            this.colSaleReturn.VisibleIndex = 8;
            this.colSaleReturn.Width = 100;
            // 
            // colPurchaseReturn
            // 
            this.colPurchaseReturn.DisplayFormat.FormatString = "n2";
            this.colPurchaseReturn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPurchaseReturn.FieldName = "PurchaseReturn";
            this.colPurchaseReturn.MaxWidth = 125;
            this.colPurchaseReturn.MinWidth = 75;
            this.colPurchaseReturn.Name = "colPurchaseReturn";
            this.colPurchaseReturn.Visible = true;
            this.colPurchaseReturn.VisibleIndex = 9;
            this.colPurchaseReturn.Width = 97;
            // 
            // colStockIn
            // 
            this.colStockIn.DisplayFormat.FormatString = "n2";
            this.colStockIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStockIn.FieldName = "StockIn";
            this.colStockIn.MaxWidth = 125;
            this.colStockIn.MinWidth = 75;
            this.colStockIn.Name = "colStockIn";
            this.colStockIn.Visible = true;
            this.colStockIn.VisibleIndex = 10;
            this.colStockIn.Width = 82;
            // 
            // colStockOut
            // 
            this.colStockOut.DisplayFormat.FormatString = "n2";
            this.colStockOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStockOut.FieldName = "StockOut";
            this.colStockOut.MaxWidth = 125;
            this.colStockOut.MinWidth = 75;
            this.colStockOut.Name = "colStockOut";
            this.colStockOut.Visible = true;
            this.colStockOut.VisibleIndex = 11;
            // 
            // colOther
            // 
            this.colOther.DisplayFormat.FormatString = "n2";
            this.colOther.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOther.FieldName = "Other";
            this.colOther.MaxWidth = 125;
            this.colOther.MinWidth = 75;
            this.colOther.Name = "colOther";
            this.colOther.Width = 77;
            // 
            // colClosingStock
            // 
            this.colClosingStock.DisplayFormat.FormatString = "n2";
            this.colClosingStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colClosingStock.FieldName = "ClosingStock";
            this.colClosingStock.MaxWidth = 125;
            this.colClosingStock.MinWidth = 75;
            this.colClosingStock.Name = "colClosingStock";
            this.colClosingStock.OptionsColumn.ReadOnly = true;
            this.colClosingStock.Visible = true;
            this.colClosingStock.VisibleIndex = 12;
            // 
            // colPurchaseRate
            // 
            this.colPurchaseRate.DisplayFormat.FormatString = "n2";
            this.colPurchaseRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPurchaseRate.FieldName = "PurchaseRate";
            this.colPurchaseRate.MaxWidth = 125;
            this.colPurchaseRate.MinWidth = 75;
            this.colPurchaseRate.Name = "colPurchaseRate";
            this.colPurchaseRate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PurchaseRate", "{0:n2}")});
            // 
            // colCostValue
            // 
            this.colCostValue.DisplayFormat.FormatString = "n2";
            this.colCostValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCostValue.FieldName = "CostValue";
            this.colCostValue.MaxWidth = 125;
            this.colCostValue.MinWidth = 75;
            this.colCostValue.Name = "colCostValue";
            this.colCostValue.OptionsColumn.ReadOnly = true;
            this.colCostValue.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CostValue", "{0:n2}")});
            // 
            // colHSN
            // 
            this.colHSN.Caption = "HSN";
            this.colHSN.FieldName = "HSN";
            this.colHSN.MaxWidth = 125;
            this.colHSN.MinWidth = 90;
            this.colHSN.Name = "colHSN";
            this.colHSN.Visible = true;
            this.colHSN.VisibleIndex = 2;
            this.colHSN.Width = 90;
            // 
            // colBarCode
            // 
            this.colBarCode.Caption = "Bar Code";
            this.colBarCode.FieldName = "BarCode";
            this.colBarCode.MaxWidth = 125;
            this.colBarCode.MinWidth = 90;
            this.colBarCode.Name = "colBarCode";
            this.colBarCode.Visible = true;
            this.colBarCode.VisibleIndex = 1;
            this.colBarCode.Width = 90;
            // 
            // stockInHandReportModelBindingSource
            // 
            this.stockInHandReportModelBindingSource.DataSource = typeof(Alit.Marker.Model.Inventory.Reports.StockInHandReportModel);
            // 
            // frmRepStockInHand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 630);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmRepStockInHand.IconOptions.Icon")));
            this.Name = "frmRepStockInHand";
            this.ShowDefaultFilter = true;
            this.Text = "Stock In Hand";
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
            ((System.ComponentModel.ISupportInitialize)(this.stockInHandReportModelBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockInHandReportModelBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource stockInHandReportModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn colOpeningStock;
        private DevExpress.XtraGrid.Columns.GridColumn colSale;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchase;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleReturn;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseReturn;
        private DevExpress.XtraGrid.Columns.GridColumn colStockIn;
        private DevExpress.XtraGrid.Columns.GridColumn colStockOut;
        private DevExpress.XtraGrid.Columns.GridColumn colOther;
        private DevExpress.XtraGrid.Columns.GridColumn colClosingStock;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseRate;
        private DevExpress.XtraGrid.Columns.GridColumn colCostValue;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private System.Windows.Forms.BindingSource stockInHandReportModelBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colHSN;
        private DevExpress.XtraGrid.Columns.GridColumn colBarCode;
    }
}