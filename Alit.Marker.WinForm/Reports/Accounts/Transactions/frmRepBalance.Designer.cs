namespace Alit.Marker.WinForm.Reports.Accounts.Transactions
{
    partial class frmRepBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepBalance));
            this.deDateFrom = new Alit.WinformControls.DateEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.deDateTo = new Alit.WinformControls.DateEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.balanceReportViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAccountName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpeningBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesReturns = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseReturn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOther = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClosingBalance = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceReportViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            // 
            // 
            // 
            this.ribbonControl1.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl1.SearchEditItem.EditWidth = 150;
            this.ribbonControl1.SearchEditItem.Id = -5000;
            this.ribbonControl1.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.Size = new System.Drawing.Size(1208, 166);
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 507);
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1208, 24);
            // 
            // RootTitle
            // 
            this.RootTitle.Size = new System.Drawing.Size(1208, 61);
            // 
            // lcTitle
            // 
            this.lcTitle.Controls.Add(this.deDateTo);
            this.lcTitle.Controls.Add(this.deDateFrom);
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcTitle.OptionsView.HighlightFocusedItem = true;
            this.lcTitle.Size = new System.Drawing.Size(1208, 61);
            // 
            // lcgDefaultFilterGroupBox
            // 
            this.lcgDefaultFilterGroupBox.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(221, 61);
            this.lcgDefaultFilterGroupBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(221, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(987, 61);
            this.lblFormCaption.Text = "Balance Report";
            this.lblFormCaption.TextSize = new System.Drawing.Size(220, 38);
            // 
            // deDateFrom
            // 
            this.deDateFrom.EditValue = null;
            this.deDateFrom.EnterMoveNextControl = true;
            this.deDateFrom.Location = new System.Drawing.Point(91, 4);
            this.deDateFrom.MaximumSize = new System.Drawing.Size(125, 0);
            this.deDateFrom.MenuManager = this.ribbonControl1;
            this.deDateFrom.MinimumSize = new System.Drawing.Size(90, 0);
            this.deDateFrom.Name = "deDateFrom";
            this.deDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
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
            this.layoutControlItem1.Size = new System.Drawing.Size(195, 26);
            this.layoutControlItem1.Text = "Date From";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(61, 16);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // deDateTo
            // 
            this.deDateTo.EditValue = null;
            this.deDateTo.EnterMoveNextControl = true;
            this.deDateTo.Location = new System.Drawing.Point(91, 30);
            this.deDateTo.MaximumSize = new System.Drawing.Size(125, 0);
            this.deDateTo.MenuManager = this.ribbonControl1;
            this.deDateTo.MinimumSize = new System.Drawing.Size(90, 0);
            this.deDateTo.Name = "deDateTo";
            this.deDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
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
            this.layoutControlItem2.Size = new System.Drawing.Size(195, 30);
            this.layoutControlItem2.Text = "Date To";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(61, 16);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.balanceReportViewModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 227);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1208, 280);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // balanceReportViewModelBindingSource
            // 
            this.balanceReportViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Reports.Accounts.Transactions.BalanceReportViewModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAccountName,
            this.colAccountGroupName,
            this.colOpeningBalance,
            this.colSales,
            this.colSalesReturns,
            this.colPurchase,
            this.colPurchaseReturn,
            this.colReceived,
            this.colPaid,
            this.colOther,
            this.colClosingBalance});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colAccountName
            // 
            this.colAccountName.FieldName = "AccountName";
            this.colAccountName.MaxWidth = 500;
            this.colAccountName.MinWidth = 75;
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AccountName", "Total")});
            this.colAccountName.Visible = true;
            this.colAccountName.VisibleIndex = 0;
            this.colAccountName.Width = 148;
            // 
            // colAccountGroupName
            // 
            this.colAccountGroupName.FieldName = "AccountGroupName";
            this.colAccountGroupName.MaxWidth = 500;
            this.colAccountGroupName.MinWidth = 140;
            this.colAccountGroupName.Name = "colAccountGroupName";
            this.colAccountGroupName.Width = 180;
            // 
            // colOpeningBalance
            // 
            this.colOpeningBalance.DisplayFormat.FormatString = "{0:#,##0.00 DR;#,##0.00 CR;0.00 }";
            this.colOpeningBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOpeningBalance.FieldName = "OpeningBalance";
            this.colOpeningBalance.MaxWidth = 125;
            this.colOpeningBalance.MinWidth = 110;
            this.colOpeningBalance.Name = "colOpeningBalance";
            this.colOpeningBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OpeningBalance", "{0:#,##0.00 DR;#,##0.00 CR;0.00 }")});
            this.colOpeningBalance.Visible = true;
            this.colOpeningBalance.VisibleIndex = 1;
            this.colOpeningBalance.Width = 115;
            // 
            // colSales
            // 
            this.colSales.DisplayFormat.FormatString = "{0:#,##0.00 DR;#,##0.00 CR;0.00 }";
            this.colSales.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSales.FieldName = "Sales";
            this.colSales.MaxWidth = 125;
            this.colSales.MinWidth = 75;
            this.colSales.Name = "colSales";
            this.colSales.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Sales", "{0:#,##0.00 DR;#,##0.00 CR;0.00 }")});
            this.colSales.Visible = true;
            this.colSales.VisibleIndex = 2;
            this.colSales.Width = 115;
            // 
            // colSalesReturns
            // 
            this.colSalesReturns.DisplayFormat.FormatString = "{0:#,##0.00 DR;#,##0.00 CR;0.00 }";
            this.colSalesReturns.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSalesReturns.FieldName = "SalesReturns";
            this.colSalesReturns.MaxWidth = 125;
            this.colSalesReturns.MinWidth = 75;
            this.colSalesReturns.Name = "colSalesReturns";
            this.colSalesReturns.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SalesReturns", "{0:#,##0.00 DR;#,##0.00 CR;0.00 }")});
            this.colSalesReturns.Visible = true;
            this.colSalesReturns.VisibleIndex = 3;
            this.colSalesReturns.Width = 115;
            // 
            // colPurchase
            // 
            this.colPurchase.DisplayFormat.FormatString = "{0:#,##0.00 DR;#,##0.00 CR;0.00 }";
            this.colPurchase.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPurchase.FieldName = "Purchase";
            this.colPurchase.MaxWidth = 125;
            this.colPurchase.MinWidth = 75;
            this.colPurchase.Name = "colPurchase";
            this.colPurchase.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Purchase", "{0:#,##0.00 DR;#,##0.00 CR;0.00 }")});
            this.colPurchase.Visible = true;
            this.colPurchase.VisibleIndex = 6;
            this.colPurchase.Width = 115;
            // 
            // colPurchaseReturn
            // 
            this.colPurchaseReturn.DisplayFormat.FormatString = "{0:#,##0.00 DR;#,##0.00 CR;0.00 }";
            this.colPurchaseReturn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPurchaseReturn.FieldName = "PurchaseReturn";
            this.colPurchaseReturn.MaxWidth = 125;
            this.colPurchaseReturn.MinWidth = 75;
            this.colPurchaseReturn.Name = "colPurchaseReturn";
            this.colPurchaseReturn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PurchaseReturn", "{0:#,##0.00 DR;#,##0.00 CR;0.00 }")});
            this.colPurchaseReturn.Visible = true;
            this.colPurchaseReturn.VisibleIndex = 5;
            this.colPurchaseReturn.Width = 115;
            // 
            // colReceived
            // 
            this.colReceived.DisplayFormat.FormatString = "{0:#,##0.00 DR;#,##0.00 CR;0.00 }";
            this.colReceived.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colReceived.FieldName = "Received";
            this.colReceived.MaxWidth = 125;
            this.colReceived.MinWidth = 75;
            this.colReceived.Name = "colReceived";
            this.colReceived.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Received", "{0:#,##0.00 DR;#,##0.00 CR;0.00 }")});
            this.colReceived.Visible = true;
            this.colReceived.VisibleIndex = 4;
            this.colReceived.Width = 115;
            // 
            // colPaid
            // 
            this.colPaid.DisplayFormat.FormatString = "{0:#,##0.00 DR;#,##0.00 CR;0.00 }";
            this.colPaid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPaid.FieldName = "Paid";
            this.colPaid.MaxWidth = 125;
            this.colPaid.MinWidth = 75;
            this.colPaid.Name = "colPaid";
            this.colPaid.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Paid", "{0:#,##0.00 DR;#,##0.00 CR;0.00 }")});
            this.colPaid.Visible = true;
            this.colPaid.VisibleIndex = 7;
            this.colPaid.Width = 115;
            // 
            // colOther
            // 
            this.colOther.DisplayFormat.FormatString = "{0:#,##0.00 DR;#,##0.00 CR;0.00 }";
            this.colOther.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOther.FieldName = "Other";
            this.colOther.MaxWidth = 125;
            this.colOther.MinWidth = 75;
            this.colOther.Name = "colOther";
            this.colOther.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Other", "{0:#,##0.00 DR;#,##0.00 CR;0.00 }")});
            this.colOther.Visible = true;
            this.colOther.VisibleIndex = 8;
            this.colOther.Width = 115;
            // 
            // colClosingBalance
            // 
            this.colClosingBalance.DisplayFormat.FormatString = "{0:#,##0.00 DR;#,##0.00 CR;0.00 }";
            this.colClosingBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colClosingBalance.FieldName = "ClosingBalance";
            this.colClosingBalance.MaxWidth = 125;
            this.colClosingBalance.MinWidth = 110;
            this.colClosingBalance.Name = "colClosingBalance";
            this.colClosingBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClosingBalance", "{0:#,##0.00 DR;#,##0.00 CR;0.00 }")});
            this.colClosingBalance.Visible = true;
            this.colClosingBalance.VisibleIndex = 9;
            this.colClosingBalance.Width = 115;
            // 
            // frmRepBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 531);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmRepBalance.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmRepBalance";
            this.ShowDefaultFilter = true;
            this.Text = "Balance Report";
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
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceReportViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinformControls.DateEdit deDateTo;
        private WinformControls.DateEdit deDateFrom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource balanceReportViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountName;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colOpeningBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colClosingBalance;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraGrid.Columns.GridColumn colSales;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesReturns;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchase;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseReturn;
        private DevExpress.XtraGrid.Columns.GridColumn colReceived;
        private DevExpress.XtraGrid.Columns.GridColumn colPaid;
        private DevExpress.XtraGrid.Columns.GridColumn colOther;
    }
}