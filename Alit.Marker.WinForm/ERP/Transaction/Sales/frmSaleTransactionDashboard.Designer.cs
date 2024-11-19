namespace Alit.Marker.WinForm.ERP.Transaction.Sales
{
    partial class frmSaleTransactionDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleTransactionDashboard));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.saleTransactionDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRecordType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemoType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrefixName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionNoWithPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceListName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdvanceAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpgSaleTransactions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnNewSaleInvoice = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewSaleOrder = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewSaleReturn = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleTransactionDashboardViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNewSaleInvoice,
            this.btnNewSaleOrder,
            this.btnNewSaleReturn});
            this.ribbonControl1.MaxItemId = 59;
            // 
            // 
            // 
            this.ribbonControl1.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl1.SearchEditItem.EditWidth = 150;
            this.ribbonControl1.SearchEditItem.Id = -5000;
            this.ribbonControl1.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.Size = new System.Drawing.Size(1727, 166);
            // 
            // rpHome
            // 
            this.rpHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSaleTransactions});
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1727, 24);
            // 
            // RootTitle
            // 
            this.RootTitle.Size = new System.Drawing.Size(1727, 55);
            // 
            // lcTitle
            // 
            this.lcTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lcTitle.OptionsView.HighlightFocusedItem = true;
            this.lcTitle.Size = new System.Drawing.Size(1727, 55);
            // 
            // lcgDefaultFilterGroupBox
            // 
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(373, 55);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(373, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(1354, 55);
            this.lblFormCaption.Text = "Sale Transaction";
            this.lblFormCaption.TextSize = new System.Drawing.Size(241, 38);
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
            // gridControl1
            // 
            this.gridControl1.DataSource = this.saleTransactionDashboardViewModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(0, 221);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1727, 385);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // saleTransactionDashboardViewModelBindingSource
            // 
            this.saleTransactionDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.ERP.Transaction.Sales.SaleTransactionDashboardViewModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRecordType,
            this.colMemoType,
            this.colTransactionDate,
            this.colPrefixName,
            this.colTransactionNo,
            this.colTransactionNoWithPrefix,
            this.colCustomerName,
            this.colCustomerAddress,
            this.colCustomerCityName,
            this.colPriceListName,
            this.colNetAmt,
            this.colMemo,
            this.colAdvanceAmt,
            this.colRecordState});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colRecordType
            // 
            this.colRecordType.FieldName = "RecordTypeDisplay";
            this.colRecordType.MaxWidth = 125;
            this.colRecordType.MinWidth = 50;
            this.colRecordType.Name = "colRecordType";
            this.colRecordType.Visible = true;
            this.colRecordType.VisibleIndex = 0;
            this.colRecordType.Width = 70;
            // 
            // colMemoType
            // 
            this.colMemoType.FieldName = "MemoType";
            this.colMemoType.MaxWidth = 100;
            this.colMemoType.MinWidth = 50;
            this.colMemoType.Name = "colMemoType";
            this.colMemoType.Visible = true;
            this.colMemoType.VisibleIndex = 3;
            this.colMemoType.Width = 84;
            // 
            // colTransactionDate
            // 
            this.colTransactionDate.FieldName = "TransactionDate";
            this.colTransactionDate.MaxWidth = 100;
            this.colTransactionDate.MinWidth = 90;
            this.colTransactionDate.Name = "colTransactionDate";
            this.colTransactionDate.Visible = true;
            this.colTransactionDate.VisibleIndex = 1;
            this.colTransactionDate.Width = 94;
            // 
            // colPrefixName
            // 
            this.colPrefixName.FieldName = "PrefixName";
            this.colPrefixName.MaxWidth = 100;
            this.colPrefixName.MinWidth = 50;
            this.colPrefixName.Name = "colPrefixName";
            this.colPrefixName.Width = 76;
            // 
            // colTransactionNo
            // 
            this.colTransactionNo.FieldName = "TransactionNo";
            this.colTransactionNo.MaxWidth = 100;
            this.colTransactionNo.MinWidth = 50;
            this.colTransactionNo.Name = "colTransactionNo";
            // 
            // colTransactionNoWithPrefix
            // 
            this.colTransactionNoWithPrefix.CustomizationCaption = "Transaction No. With Prefix";
            this.colTransactionNoWithPrefix.FieldName = "TransactionNoWithPrefix";
            this.colTransactionNoWithPrefix.MaxWidth = 150;
            this.colTransactionNoWithPrefix.MinWidth = 75;
            this.colTransactionNoWithPrefix.Name = "colTransactionNoWithPrefix";
            this.colTransactionNoWithPrefix.OptionsColumn.ReadOnly = true;
            this.colTransactionNoWithPrefix.Visible = true;
            this.colTransactionNoWithPrefix.VisibleIndex = 2;
            this.colTransactionNoWithPrefix.Width = 94;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.MaxWidth = 500;
            this.colCustomerName.MinWidth = 100;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 4;
            this.colCustomerName.Width = 291;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.FieldName = "CustomerAddress";
            this.colCustomerAddress.MaxWidth = 500;
            this.colCustomerAddress.MinWidth = 100;
            this.colCustomerAddress.Name = "colCustomerAddress";
            this.colCustomerAddress.Visible = true;
            this.colCustomerAddress.VisibleIndex = 5;
            this.colCustomerAddress.Width = 467;
            // 
            // colCustomerCityName
            // 
            this.colCustomerCityName.FieldName = "CustomerCityName";
            this.colCustomerCityName.MaxWidth = 300;
            this.colCustomerCityName.MinWidth = 50;
            this.colCustomerCityName.Name = "colCustomerCityName";
            this.colCustomerCityName.Visible = true;
            this.colCustomerCityName.VisibleIndex = 6;
            this.colCustomerCityName.Width = 94;
            // 
            // colPriceListName
            // 
            this.colPriceListName.FieldName = "PriceListName";
            this.colPriceListName.MaxWidth = 100;
            this.colPriceListName.MinWidth = 50;
            this.colPriceListName.Name = "colPriceListName";
            this.colPriceListName.Visible = true;
            this.colPriceListName.VisibleIndex = 7;
            this.colPriceListName.Width = 70;
            // 
            // colNetAmt
            // 
            this.colNetAmt.DisplayFormat.FormatString = "n2";
            this.colNetAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNetAmt.FieldName = "NetAmt";
            this.colNetAmt.MaxWidth = 125;
            this.colNetAmt.MinWidth = 75;
            this.colNetAmt.Name = "colNetAmt";
            this.colNetAmt.Visible = true;
            this.colNetAmt.VisibleIndex = 8;
            this.colNetAmt.Width = 100;
            // 
            // colMemo
            // 
            this.colMemo.FieldName = "Memo";
            this.colMemo.MaxWidth = 500;
            this.colMemo.MinWidth = 100;
            this.colMemo.Name = "colMemo";
            this.colMemo.Visible = true;
            this.colMemo.VisibleIndex = 9;
            this.colMemo.Width = 186;
            // 
            // colAdvanceAmt
            // 
            this.colAdvanceAmt.DisplayFormat.FormatString = "n2";
            this.colAdvanceAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAdvanceAmt.FieldName = "AdvanceAmt";
            this.colAdvanceAmt.MaxWidth = 125;
            this.colAdvanceAmt.MinWidth = 75;
            this.colAdvanceAmt.Name = "colAdvanceAmt";
            this.colAdvanceAmt.Visible = true;
            this.colAdvanceAmt.VisibleIndex = 10;
            this.colAdvanceAmt.Width = 100;
            // 
            // colRecordState
            // 
            this.colRecordState.FieldName = "RecordState";
            this.colRecordState.MaxWidth = 100;
            this.colRecordState.MinWidth = 50;
            this.colRecordState.Name = "colRecordState";
            this.colRecordState.Visible = true;
            this.colRecordState.VisibleIndex = 11;
            this.colRecordState.Width = 52;
            // 
            // rpgSaleTransactions
            // 
            this.rpgSaleTransactions.ItemLinks.Add(this.btnNewSaleInvoice);
            this.rpgSaleTransactions.ItemLinks.Add(this.btnNewSaleOrder);
            this.rpgSaleTransactions.ItemLinks.Add(this.btnNewSaleReturn);
            this.rpgSaleTransactions.Name = "rpgSaleTransactions";
            this.rpgSaleTransactions.Text = "Transactions";
            // 
            // btnNewSaleInvoice
            // 
            this.btnNewSaleInvoice.Caption = "New Invoice";
            this.btnNewSaleInvoice.Id = 53;
            this.btnNewSaleInvoice.Name = "btnNewSaleInvoice";
            this.btnNewSaleInvoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewSaleInvoice_ItemClick);
            // 
            // btnNewSaleOrder
            // 
            this.btnNewSaleOrder.Caption = "New Order";
            this.btnNewSaleOrder.Id = 54;
            this.btnNewSaleOrder.Name = "btnNewSaleOrder";
            this.btnNewSaleOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewSaleOrder_ItemClick);
            // 
            // btnNewSaleReturn
            // 
            this.btnNewSaleReturn.Caption = "New Sale Return";
            this.btnNewSaleReturn.Id = 55;
            this.btnNewSaleReturn.Name = "btnNewSaleReturn";
            this.btnNewSaleReturn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewSaleReturn_ItemClick);
            // 
            // frmSaleTransactionDashboard
            // 
            this.AllowDocumentPrintVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1727, 630);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmSaleTransactionDashboard.IconOptions.Icon")));
            this.Name = "frmSaleTransactionDashboard";
            this.Text = "Sale Transaction";
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
            ((System.ComponentModel.ISupportInitialize)(this.saleTransactionDashboardViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem btnNewSaleInvoice;
        private DevExpress.XtraBars.BarButtonItem btnNewSaleOrder;
        private DevExpress.XtraBars.BarButtonItem btnNewSaleReturn;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSaleTransactions;
        private System.Windows.Forms.BindingSource saleTransactionDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordType;
        private DevExpress.XtraGrid.Columns.GridColumn colMemoType;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPrefixName;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionNoWithPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCityName;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceListName;
        private DevExpress.XtraGrid.Columns.GridColumn colNetAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colAdvanceAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
    }
}