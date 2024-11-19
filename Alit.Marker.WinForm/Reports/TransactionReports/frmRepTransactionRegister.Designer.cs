namespace Alit.Marker.WinForm.Reports.TransactionReports
{
    partial class frmRepTransactionRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepTransactionRegister));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.repTransactionRegisterReportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTransactionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionNoPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionNoWithPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmountSale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmountRecd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deDateFrom = new Alit.WinformControls.DateEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.deDateTo = new Alit.WinformControls.DateEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueCustomer = new Alit.WinformControls.LookUpEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            this.lcTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTransactionRegisterReportModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
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
            this.ribbonControl1.Size = new System.Drawing.Size(1174, 159);
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 463);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1174, 23);
            // 
            // RootTitle
            // 
            this.RootTitle.Size = new System.Drawing.Size(1174, 61);
            // 
            // lcTitle
            // 
            this.lcTitle.Controls.Add(this.lueCustomer);
            this.lcTitle.Controls.Add(this.deDateTo);
            this.lcTitle.Controls.Add(this.deDateFrom);
            this.lcTitle.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lcTitle.OptionsView.HighlightFocusedItem = true;
            this.lcTitle.Size = new System.Drawing.Size(1174, 61);
            // 
            // lcgDefaultFilterGroupBox
            // 
            this.lcgDefaultFilterGroupBox.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(577, 61);
            this.lcgDefaultFilterGroupBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(577, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(597, 61);
            this.lblFormCaption.Text = "Transaction Register";
            this.lblFormCaption.TextSize = new System.Drawing.Size(299, 38);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.repTransactionRegisterReportModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(0, 220);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1174, 243);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // repTransactionRegisterReportModelBindingSource
            // 
            this.repTransactionRegisterReportModelBindingSource.DataSource = typeof(Alit.Marker.Model.Reports.TransationReports.TransactionRegisterReportModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTransactionType,
            this.colTransactionDate,
            this.colTransactionNoPrefix,
            this.colTransactionNo,
            this.colTransactionNoWithPrefix,
            this.colDescr,
            this.colCustomerName,
            this.colAmountSale,
            this.colAmountRecd,
            this.colBalance});
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridView1_CustomSummaryCalculate);
            // 
            // colTransactionType
            // 
            this.colTransactionType.FieldName = "TransactionType";
            this.colTransactionType.MaxWidth = 87;
            this.colTransactionType.MinWidth = 47;
            this.colTransactionType.Name = "colTransactionType";
            this.colTransactionType.Visible = true;
            this.colTransactionType.VisibleIndex = 0;
            this.colTransactionType.Width = 87;
            // 
            // colTransactionDate
            // 
            this.colTransactionDate.FieldName = "TransactionDate";
            this.colTransactionDate.MaxWidth = 117;
            this.colTransactionDate.MinWidth = 87;
            this.colTransactionDate.Name = "colTransactionDate";
            this.colTransactionDate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "TransactionDate", "{0} Records")});
            this.colTransactionDate.Visible = true;
            this.colTransactionDate.VisibleIndex = 1;
            this.colTransactionDate.Width = 87;
            // 
            // colTransactionNoPrefix
            // 
            this.colTransactionNoPrefix.FieldName = "TransactionNoPrefix";
            this.colTransactionNoPrefix.MaxWidth = 175;
            this.colTransactionNoPrefix.MinWidth = 87;
            this.colTransactionNoPrefix.Name = "colTransactionNoPrefix";
            this.colTransactionNoPrefix.Width = 87;
            // 
            // colTransactionNo
            // 
            this.colTransactionNo.FieldName = "TransactionNo";
            this.colTransactionNo.MaxWidth = 117;
            this.colTransactionNo.MinWidth = 87;
            this.colTransactionNo.Name = "colTransactionNo";
            this.colTransactionNo.Width = 87;
            // 
            // colTransactionNoWithPrefix
            // 
            this.colTransactionNoWithPrefix.CustomizationCaption = "Transaction No. With Prefix";
            this.colTransactionNoWithPrefix.FieldName = "TransactionNoWithPrefix";
            this.colTransactionNoWithPrefix.MaxWidth = 175;
            this.colTransactionNoWithPrefix.MinWidth = 87;
            this.colTransactionNoWithPrefix.Name = "colTransactionNoWithPrefix";
            this.colTransactionNoWithPrefix.OptionsColumn.ReadOnly = true;
            this.colTransactionNoWithPrefix.Visible = true;
            this.colTransactionNoWithPrefix.VisibleIndex = 2;
            this.colTransactionNoWithPrefix.Width = 87;
            // 
            // colDescr
            // 
            this.colDescr.FieldName = "Descr";
            this.colDescr.MinWidth = 117;
            this.colDescr.Name = "colDescr";
            this.colDescr.Visible = true;
            this.colDescr.VisibleIndex = 3;
            this.colDescr.Width = 696;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.MaxWidth = 350;
            this.colCustomerName.MinWidth = 117;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Width = 233;
            // 
            // colAmountSale
            // 
            this.colAmountSale.DisplayFormat.FormatString = "n2";
            this.colAmountSale.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmountSale.FieldName = "AmountSale";
            this.colAmountSale.MaxWidth = 146;
            this.colAmountSale.MinWidth = 87;
            this.colAmountSale.Name = "colAmountSale";
            this.colAmountSale.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountSale", "{0:n2}")});
            this.colAmountSale.Visible = true;
            this.colAmountSale.VisibleIndex = 4;
            this.colAmountSale.Width = 117;
            // 
            // colAmountRecd
            // 
            this.colAmountRecd.DisplayFormat.FormatString = "n2";
            this.colAmountRecd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmountRecd.FieldName = "AmountRecd";
            this.colAmountRecd.MaxWidth = 146;
            this.colAmountRecd.MinWidth = 87;
            this.colAmountRecd.Name = "colAmountRecd";
            this.colAmountRecd.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountRecd", "{0:n2}")});
            this.colAmountRecd.Visible = true;
            this.colAmountRecd.VisibleIndex = 5;
            this.colAmountRecd.Width = 117;
            // 
            // colBalance
            // 
            this.colBalance.DisplayFormat.FormatString = "n2";
            this.colBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBalance.FieldName = "Balance";
            this.colBalance.MaxWidth = 146;
            this.colBalance.MinWidth = 87;
            this.colBalance.Name = "colBalance";
            this.colBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Balance", "{0:n2}")});
            this.colBalance.Visible = true;
            this.colBalance.VisibleIndex = 6;
            this.colBalance.Width = 117;
            // 
            // deDateFrom
            // 
            this.deDateFrom.EditValue = null;
            this.deDateFrom.EnterMoveNextControl = true;
            this.deDateFrom.Location = new System.Drawing.Point(131, 4);
            this.deDateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deDateFrom.MaximumSize = new System.Drawing.Size(146, 0);
            this.deDateFrom.MenuManager = this.ribbonControl1;
            this.deDateFrom.MinimumSize = new System.Drawing.Size(117, 0);
            this.deDateFrom.Name = "deDateFrom";
            this.deDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDateFrom.Size = new System.Drawing.Size(117, 22);
            this.deDateFrom.StyleController = this.lcTitle;
            this.deDateFrom.TabIndex = 4;
            this.deDateFrom.Validating += new System.ComponentModel.CancelEventHandler(this.deDateFrom_Validating);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deDateFrom;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(227, 26);
            this.layoutControlItem1.Text = "Date From";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(101, 0);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // deDateTo
            // 
            this.deDateTo.EditValue = null;
            this.deDateTo.EnterMoveNextControl = true;
            this.deDateTo.Location = new System.Drawing.Point(131, 30);
            this.deDateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deDateTo.MaximumSize = new System.Drawing.Size(146, 0);
            this.deDateTo.MenuManager = this.ribbonControl1;
            this.deDateTo.MinimumSize = new System.Drawing.Size(117, 0);
            this.deDateTo.Name = "deDateTo";
            this.deDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDateTo.Size = new System.Drawing.Size(117, 22);
            this.deDateTo.StyleController = this.lcTitle;
            this.deDateTo.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.deDateTo;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(227, 30);
            this.layoutControlItem2.Text = "Date To";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(101, 0);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // lueCustomer
            // 
            this.lueCustomer.EnterMoveNextControl = true;
            this.lueCustomer.Location = new System.Drawing.Point(252, 23);
            this.lueCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lueCustomer.MaximumSize = new System.Drawing.Size(583, 0);
            this.lueCustomer.MenuManager = this.ribbonControl1;
            this.lueCustomer.MinimumSize = new System.Drawing.Size(117, 0);
            this.lueCustomer.Name = "lueCustomer";
            this.lueCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCustomer.Properties.NullText = "Select";
            this.lueCustomer.Size = new System.Drawing.Size(320, 22);
            this.lueCustomer.StyleController = this.lcTitle;
            this.lueCustomer.TabIndex = 6;
            this.lueCustomer.Validating += new System.ComponentModel.CancelEventHandler(this.lueCustomer_Validating);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lueCustomer;
            this.layoutControlItem3.Location = new System.Drawing.Point(227, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(324, 45);
            this.layoutControlItem3.Text = "Customer";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(299, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(227, 45);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(19, 2);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(324, 11);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmRepTransactionRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 486);
            this.Controls.Add(this.gridControl1);
            //this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmRepTransactionRegister.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmRepTransactionRegister";
            this.ShowDefaultFilter = true;
            this.Text = "Transaction Register";
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTransactionRegisterReportModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private WinformControls.LookUpEdit lueCustomer;
        private WinformControls.DateEdit deDateTo;
        private WinformControls.DateEdit deDateFrom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource repTransactionRegisterReportModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionType;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionNoPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionNoWithPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colDescr;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colAmountSale;
        private DevExpress.XtraGrid.Columns.GridColumn colAmountRecd;
        private DevExpress.XtraGrid.Columns.GridColumn colBalance;
    }
}