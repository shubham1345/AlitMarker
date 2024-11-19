namespace Alit.Marker.WinForm.Account.Transactions.Receipt
{
    partial class frmReceiptDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceiptDashboard));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.receiptDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReceiptDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceiptNoPrefixName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceiptNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleInvoiceNoWithPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModeOfPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChequeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnReceiptNoPrefix = new DevExpress.XtraBars.BarButtonItem();
            this.colAccountName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDashboardViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnReceiptNoPrefix});
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonControl1.MaxItemId = 48;
            // 
            // 
            // 
            this.ribbonControl1.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl1.SearchEditItem.EditWidth = 150;
            this.ribbonControl1.SearchEditItem.Id = -5000;
            this.ribbonControl1.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            // 
            // lcTitle
            // 
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcTitle.OptionsView.HighlightFocusedItem = true;
            // 
            // lcgDefaultFilterGroupBox
            // 
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(33, 55);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(33, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(1351, 55);
            this.lblFormCaption.Text = "Receipt";
            this.lblFormCaption.TextSize = new System.Drawing.Size(109, 38);
            // 
            // btnDocumentExportTo
            // 
            this.btnDocumentExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDocumentExportTo.ImageOptions.SvgImage")));
            // 
            // btnDashboardExportTo
            // 
            this.btnDashboardExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDashboardExportTo.ImageOptions.SvgImage")));
            // 
            // rpgPrintDocument
            // 
            this.rpgPrintDocument.Visible = true;
            // 
            // rpgMaster
            // 
            this.rpgMaster.ItemLinks.Add(this.btnReceiptNoPrefix);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.receiptDashboardViewModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(0, 221);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1384, 385);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // receiptDashboardViewModelBindingSource
            // 
            this.receiptDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Account.Transactions.Receipt.ReceiptDashboardViewModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReceiptDate,
            this.colReceiptNoPrefixName,
            this.colReceiptNo,
            this.colSaleInvoiceNoWithPrefix,
            this.colAccountName,
            this.colAccountAddress,
            this.colAccountCityName,
            this.colAmount,
            this.colModeOfPayment,
            this.colRemarks,
            this.colBankBranchName,
            this.colBankName,
            this.colChequeNo,
            this.colRecordState});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colReceiptDate
            // 
            this.colReceiptDate.FieldName = "ReceiptDate";
            this.colReceiptDate.MaxWidth = 125;
            this.colReceiptDate.MinWidth = 80;
            this.colReceiptDate.Name = "colReceiptDate";
            this.colReceiptDate.Visible = true;
            this.colReceiptDate.VisibleIndex = 0;
            this.colReceiptDate.Width = 125;
            // 
            // colReceiptNoPrefixName
            // 
            this.colReceiptNoPrefixName.FieldName = "ReceiptNoPrefixName";
            this.colReceiptNoPrefixName.MaxWidth = 150;
            this.colReceiptNoPrefixName.MinWidth = 50;
            this.colReceiptNoPrefixName.Name = "colReceiptNoPrefixName";
            this.colReceiptNoPrefixName.Width = 80;
            // 
            // colReceiptNo
            // 
            this.colReceiptNo.FieldName = "ReceiptNo";
            this.colReceiptNo.MaxWidth = 100;
            this.colReceiptNo.MinWidth = 75;
            this.colReceiptNo.Name = "colReceiptNo";
            // 
            // colSaleInvoiceNoWithPrefix
            // 
            this.colSaleInvoiceNoWithPrefix.CustomizationCaption = "Receipt No. With Prefix";
            this.colSaleInvoiceNoWithPrefix.FieldName = "SaleInvoiceNoWithPrefix";
            this.colSaleInvoiceNoWithPrefix.MaxWidth = 125;
            this.colSaleInvoiceNoWithPrefix.MinWidth = 80;
            this.colSaleInvoiceNoWithPrefix.Name = "colSaleInvoiceNoWithPrefix";
            this.colSaleInvoiceNoWithPrefix.OptionsColumn.ReadOnly = true;
            this.colSaleInvoiceNoWithPrefix.Visible = true;
            this.colSaleInvoiceNoWithPrefix.VisibleIndex = 1;
            this.colSaleInvoiceNoWithPrefix.Width = 114;
            // 
            // colAmount
            // 
            this.colAmount.DisplayFormat.FormatString = "n2";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.FieldName = "Amount";
            this.colAmount.MaxWidth = 125;
            this.colAmount.MinWidth = 75;
            this.colAmount.Name = "colAmount";
            this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n2}")});
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 4;
            this.colAmount.Width = 107;
            // 
            // colModeOfPayment
            // 
            this.colModeOfPayment.FieldName = "ModeOfPayment";
            this.colModeOfPayment.MaxWidth = 125;
            this.colModeOfPayment.MinWidth = 100;
            this.colModeOfPayment.Name = "colModeOfPayment";
            this.colModeOfPayment.Visible = true;
            this.colModeOfPayment.VisibleIndex = 5;
            this.colModeOfPayment.Width = 102;
            // 
            // colRemarks
            // 
            this.colRemarks.FieldName = "Remarks";
            this.colRemarks.MaxWidth = 500;
            this.colRemarks.MinWidth = 75;
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.Visible = true;
            this.colRemarks.VisibleIndex = 6;
            this.colRemarks.Width = 95;
            // 
            // colBankBranchName
            // 
            this.colBankBranchName.FieldName = "BankBranchName";
            this.colBankBranchName.MaxWidth = 500;
            this.colBankBranchName.MinWidth = 90;
            this.colBankBranchName.Name = "colBankBranchName";
            this.colBankBranchName.Visible = true;
            this.colBankBranchName.VisibleIndex = 7;
            this.colBankBranchName.Width = 116;
            // 
            // colBankName
            // 
            this.colBankName.FieldName = "BankName";
            this.colBankName.MaxWidth = 500;
            this.colBankName.MinWidth = 80;
            this.colBankName.Name = "colBankName";
            this.colBankName.Visible = true;
            this.colBankName.VisibleIndex = 8;
            this.colBankName.Width = 101;
            // 
            // colChequeNo
            // 
            this.colChequeNo.FieldName = "ChequeNo";
            this.colChequeNo.MaxWidth = 500;
            this.colChequeNo.MinWidth = 90;
            this.colChequeNo.Name = "colChequeNo";
            this.colChequeNo.Visible = true;
            this.colChequeNo.VisibleIndex = 9;
            this.colChequeNo.Width = 173;
            // 
            // colRecordState
            // 
            this.colRecordState.FieldName = "RecordState";
            this.colRecordState.MaxWidth = 100;
            this.colRecordState.MinWidth = 50;
            this.colRecordState.Name = "colRecordState";
            this.colRecordState.Visible = true;
            this.colRecordState.VisibleIndex = 10;
            this.colRecordState.Width = 99;
            // 
            // btnReceiptNoPrefix
            // 
            this.btnReceiptNoPrefix.Caption = "Receipt No. Prefix";
            this.btnReceiptNoPrefix.Id = 47;
            this.btnReceiptNoPrefix.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnReceiptNoPrefix.ImageOptions.SvgImage")));
            this.btnReceiptNoPrefix.Name = "btnReceiptNoPrefix";
            this.btnReceiptNoPrefix.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnReceiptNoPrefix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReceiptNoPrefix_ItemClick_1);
            // 
            // colAccountName
            // 
            this.colAccountName.FieldName = "AccountName";
            this.colAccountName.MaxWidth = 500;
            this.colAccountName.MinWidth = 100;
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.Visible = true;
            this.colAccountName.VisibleIndex = 2;
            this.colAccountName.Width = 118;
            // 
            // colAccountAddress
            // 
            this.colAccountAddress.FieldName = "AccountAddress";
            this.colAccountAddress.MaxWidth = 500;
            this.colAccountAddress.MinWidth = 100;
            this.colAccountAddress.Name = "colAccountAddress";
            this.colAccountAddress.Width = 150;
            // 
            // colAccountCityName
            // 
            this.colAccountCityName.FieldName = "AccountCityName";
            this.colAccountCityName.MaxWidth = 200;
            this.colAccountCityName.MinWidth = 75;
            this.colAccountCityName.Name = "colAccountCityName";
            this.colAccountCityName.Visible = true;
            this.colAccountCityName.VisibleIndex = 3;
            this.colAccountCityName.Width = 102;
            // 
            // frmReceiptDashboard
            // 
            this.AllowDocumentPrintVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 630);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmReceiptDashboard.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmReceiptDashboard";
            this.Text = "Receipt";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.lcTitle, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDashboardViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource receiptDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiptDate;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiptNoPrefixName;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiptNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleInvoiceNoWithPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colModeOfPayment;
        private DevExpress.XtraGrid.Columns.GridColumn colRemarks;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
        private DevExpress.XtraBars.BarButtonItem btnReceiptNoPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colBankBranchName;
        private DevExpress.XtraGrid.Columns.GridColumn colBankName;
        private DevExpress.XtraGrid.Columns.GridColumn colChequeNo;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountName;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountCityName;
    }
}