namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleInvoice
{
    partial class frmSaleInvoiceDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleInvoiceDashboard));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.saleInvoiceDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSaleOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemoType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleInvoiceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleInvoiceNoPrefixName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleInvoiceNoWithPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChallanNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChallanDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierReferenceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherReferenceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransportName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNofPackets = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDestination = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDispatchDocumentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceListName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdvanceAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSaleInvoiceNoPrefix = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleInvoiceDashboardViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rpgSaleMaster
            // 
            this.rpgSaleMaster.ItemLinks.Add(this.btnSaleInvoiceNoPrefix);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSaleInvoiceNoPrefix});
            // 
            // 
            // 
            this.ribbonControl1.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl1.SearchEditItem.EditWidth = 150;
            this.ribbonControl1.SearchEditItem.Id = -5000;
            this.ribbonControl1.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            // 
            // lcTitle
            // 
            this.lcTitle.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lcTitle.OptionsView.HighlightFocusedItem = true;
            // 
            // lcgDefaultFilterGroupBox
            // 
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(299, 55);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(299, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(1085, 55);
            this.lblFormCaption.Text = "Sale Invoice";
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
            this.gridControl1.DataSource = this.saleInvoiceDashboardViewModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(0, 214);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1384, 393);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // saleInvoiceDashboardViewModelBindingSource
            // 
            this.saleInvoiceDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceDashboardViewModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSaleOrderNo,
            this.colMemoType,
            this.colSaleInvoiceDate,
            this.colSaleInvoiceNoPrefixName,
            this.colSaleInvoiceNo,
            this.colSaleInvoiceNoWithPrefix,
            this.colCustomerName,
            this.colCustomerAddress,
            this.colCustomerCityName,
            this.colChallanNo,
            this.colChallanDate,
            this.colOrderNo,
            this.colOrderDate,
            this.colSupplierReferenceNo,
            this.colOtherReferenceNo,
            this.colTransportName,
            this.colNofPackets,
            this.colDestination,
            this.colDispatchDocumentNo,
            this.colDeliveryDate,
            this.colPriceListName,
            this.colNetAmt,
            this.colInvoiceMemo,
            this.colAdvanceAmt,
            this.colRecordState});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(1114, 183, 252, 295);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSaleOrderNo
            // 
            this.colSaleOrderNo.FieldName = "SaleOrderNo";
            this.colSaleOrderNo.MaxWidth = 125;
            this.colSaleOrderNo.MinWidth = 50;
            this.colSaleOrderNo.Name = "colSaleOrderNo";
            this.colSaleOrderNo.Width = 100;
            // 
            // colMemoType
            // 
            this.colMemoType.FieldName = "MemoType";
            this.colMemoType.MaxWidth = 125;
            this.colMemoType.MinWidth = 80;
            this.colMemoType.Name = "colMemoType";
            this.colMemoType.Visible = true;
            this.colMemoType.VisibleIndex = 0;
            this.colMemoType.Width = 80;
            // 
            // colSaleInvoiceDate
            // 
            this.colSaleInvoiceDate.FieldName = "SaleInvoiceDate";
            this.colSaleInvoiceDate.MaxWidth = 125;
            this.colSaleInvoiceDate.MinWidth = 90;
            this.colSaleInvoiceDate.Name = "colSaleInvoiceDate";
            this.colSaleInvoiceDate.Visible = true;
            this.colSaleInvoiceDate.VisibleIndex = 1;
            this.colSaleInvoiceDate.Width = 112;
            // 
            // colSaleInvoiceNoPrefixName
            // 
            this.colSaleInvoiceNoPrefixName.FieldName = "SaleInvoiceNoPrefixName";
            this.colSaleInvoiceNoPrefixName.MaxWidth = 150;
            this.colSaleInvoiceNoPrefixName.MinWidth = 50;
            this.colSaleInvoiceNoPrefixName.Name = "colSaleInvoiceNoPrefixName";
            this.colSaleInvoiceNoPrefixName.Width = 100;
            // 
            // colSaleInvoiceNo
            // 
            this.colSaleInvoiceNo.DisplayFormat.FormatString = "n0";
            this.colSaleInvoiceNo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaleInvoiceNo.FieldName = "SaleInvoiceNo";
            this.colSaleInvoiceNo.MaxWidth = 100;
            this.colSaleInvoiceNo.MinWidth = 50;
            this.colSaleInvoiceNo.Name = "colSaleInvoiceNo";
            // 
            // colSaleInvoiceNoWithPrefix
            // 
            this.colSaleInvoiceNoWithPrefix.FieldName = "SaleInvoiceNoWithPrefix";
            this.colSaleInvoiceNoWithPrefix.MaxWidth = 150;
            this.colSaleInvoiceNoWithPrefix.MinWidth = 50;
            this.colSaleInvoiceNoWithPrefix.Name = "colSaleInvoiceNoWithPrefix";
            this.colSaleInvoiceNoWithPrefix.OptionsColumn.ReadOnly = true;
            this.colSaleInvoiceNoWithPrefix.Visible = true;
            this.colSaleInvoiceNoWithPrefix.VisibleIndex = 2;
            this.colSaleInvoiceNoWithPrefix.Width = 124;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.MaxWidth = 500;
            this.colCustomerName.MinWidth = 100;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 3;
            this.colCustomerName.Width = 190;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.FieldName = "CustomerAddress";
            this.colCustomerAddress.MaxWidth = 500;
            this.colCustomerAddress.MinWidth = 100;
            this.colCustomerAddress.Name = "colCustomerAddress";
            this.colCustomerAddress.Visible = true;
            this.colCustomerAddress.VisibleIndex = 4;
            this.colCustomerAddress.Width = 254;
            // 
            // colCustomerCityName
            // 
            this.colCustomerCityName.FieldName = "CustomerCityName";
            this.colCustomerCityName.MaxWidth = 199;
            this.colCustomerCityName.MinWidth = 50;
            this.colCustomerCityName.Name = "colCustomerCityName";
            this.colCustomerCityName.Visible = true;
            this.colCustomerCityName.VisibleIndex = 5;
            this.colCustomerCityName.Width = 124;
            // 
            // colChallanNo
            // 
            this.colChallanNo.FieldName = "ChallanNo";
            this.colChallanNo.MaxWidth = 100;
            this.colChallanNo.MinWidth = 50;
            this.colChallanNo.Name = "colChallanNo";
            // 
            // colChallanDate
            // 
            this.colChallanDate.FieldName = "ChallanDate";
            this.colChallanDate.MaxWidth = 125;
            this.colChallanDate.MinWidth = 90;
            this.colChallanDate.Name = "colChallanDate";
            this.colChallanDate.Width = 90;
            // 
            // colOrderNo
            // 
            this.colOrderNo.FieldName = "OrderNo";
            this.colOrderNo.MaxWidth = 100;
            this.colOrderNo.MinWidth = 50;
            this.colOrderNo.Name = "colOrderNo";
            // 
            // colOrderDate
            // 
            this.colOrderDate.FieldName = "OrderDate";
            this.colOrderDate.MaxWidth = 125;
            this.colOrderDate.MinWidth = 90;
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.Width = 90;
            // 
            // colSupplierReferenceNo
            // 
            this.colSupplierReferenceNo.FieldName = "SupplierReferenceNo";
            this.colSupplierReferenceNo.MaxWidth = 125;
            this.colSupplierReferenceNo.MinWidth = 50;
            this.colSupplierReferenceNo.Name = "colSupplierReferenceNo";
            this.colSupplierReferenceNo.Width = 90;
            // 
            // colOtherReferenceNo
            // 
            this.colOtherReferenceNo.FieldName = "OtherReferenceNo";
            this.colOtherReferenceNo.MaxWidth = 125;
            this.colOtherReferenceNo.MinWidth = 50;
            this.colOtherReferenceNo.Name = "colOtherReferenceNo";
            this.colOtherReferenceNo.Width = 100;
            // 
            // colTransportName
            // 
            this.colTransportName.FieldName = "TransportName";
            this.colTransportName.MaxWidth = 150;
            this.colTransportName.MinWidth = 50;
            this.colTransportName.Name = "colTransportName";
            this.colTransportName.Width = 100;
            // 
            // colNofPackets
            // 
            this.colNofPackets.FieldName = "NofPackets";
            this.colNofPackets.MaxWidth = 100;
            this.colNofPackets.MinWidth = 50;
            this.colNofPackets.Name = "colNofPackets";
            this.colNofPackets.Width = 65;
            // 
            // colDestination
            // 
            this.colDestination.FieldName = "Destination";
            this.colDestination.MaxWidth = 150;
            this.colDestination.MinWidth = 50;
            this.colDestination.Name = "colDestination";
            this.colDestination.Width = 100;
            // 
            // colDispatchDocumentNo
            // 
            this.colDispatchDocumentNo.FieldName = "DispatchDocumentNo";
            this.colDispatchDocumentNo.MaxWidth = 125;
            this.colDispatchDocumentNo.MinWidth = 50;
            this.colDispatchDocumentNo.Name = "colDispatchDocumentNo";
            this.colDispatchDocumentNo.Width = 90;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.FieldName = "DeliveryDate";
            this.colDeliveryDate.MaxWidth = 125;
            this.colDeliveryDate.MinWidth = 50;
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.Width = 90;
            // 
            // colPriceListName
            // 
            this.colPriceListName.FieldName = "PriceListName";
            this.colPriceListName.MaxWidth = 150;
            this.colPriceListName.MinWidth = 50;
            this.colPriceListName.Name = "colPriceListName";
            this.colPriceListName.Width = 100;
            // 
            // colNetAmt
            // 
            this.colNetAmt.DisplayFormat.FormatString = "n2";
            this.colNetAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNetAmt.FieldName = "NetAmt";
            this.colNetAmt.MaxWidth = 125;
            this.colNetAmt.MinWidth = 100;
            this.colNetAmt.Name = "colNetAmt";
            this.colNetAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetAmt", "{0:n2}")});
            this.colNetAmt.Visible = true;
            this.colNetAmt.VisibleIndex = 6;
            this.colNetAmt.Width = 122;
            // 
            // colInvoiceMemo
            // 
            this.colInvoiceMemo.FieldName = "InvoiceMemo";
            this.colInvoiceMemo.MaxWidth = 500;
            this.colInvoiceMemo.MinWidth = 100;
            this.colInvoiceMemo.Name = "colInvoiceMemo";
            this.colInvoiceMemo.Visible = true;
            this.colInvoiceMemo.VisibleIndex = 8;
            this.colInvoiceMemo.Width = 135;
            // 
            // colAdvanceAmt
            // 
            this.colAdvanceAmt.DisplayFormat.FormatString = "n2";
            this.colAdvanceAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAdvanceAmt.FieldName = "AdvanceAmt";
            this.colAdvanceAmt.MaxWidth = 125;
            this.colAdvanceAmt.MinWidth = 60;
            this.colAdvanceAmt.Name = "colAdvanceAmt";
            this.colAdvanceAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AdvanceAmt", "{0:n2}")});
            this.colAdvanceAmt.Visible = true;
            this.colAdvanceAmt.VisibleIndex = 7;
            this.colAdvanceAmt.Width = 60;
            // 
            // colRecordState
            // 
            this.colRecordState.FieldName = "RecordState";
            this.colRecordState.MaxWidth = 100;
            this.colRecordState.MinWidth = 50;
            this.colRecordState.Name = "colRecordState";
            this.colRecordState.Visible = true;
            this.colRecordState.VisibleIndex = 9;
            this.colRecordState.Width = 100;
            // 
            // btnSaleInvoiceNoPrefix
            // 
            this.btnSaleInvoiceNoPrefix.Caption = "Sale Invoice No. Prefix";
            this.btnSaleInvoiceNoPrefix.Id = 57;
            this.btnSaleInvoiceNoPrefix.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaleInvoiceNoPrefix.ImageOptions.SvgImage")));
            this.btnSaleInvoiceNoPrefix.Name = "btnSaleInvoiceNoPrefix";
            this.btnSaleInvoiceNoPrefix.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnSaleInvoiceNoPrefix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaleInvoiceNoPrefix_ItemClick);
            // 
            // frmSaleInvoiceDashboard
            // 
            this.AllowDocumentPrintVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 630);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmSaleInvoiceDashboard.IconOptions.Icon")));
            this.Name = "frmSaleInvoiceDashboard";
            this.Text = "Sale Invoice";
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
            ((System.ComponentModel.ISupportInitialize)(this.saleInvoiceDashboardViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource saleInvoiceDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn colMemoType;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleInvoiceDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleInvoiceNoPrefixName;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleInvoiceNoWithPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCityName;
        private DevExpress.XtraGrid.Columns.GridColumn colChallanNo;
        private DevExpress.XtraGrid.Columns.GridColumn colChallanDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierReferenceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherReferenceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTransportName;
        private DevExpress.XtraGrid.Columns.GridColumn colNofPackets;
        private DevExpress.XtraGrid.Columns.GridColumn colDestination;
        private DevExpress.XtraGrid.Columns.GridColumn colDispatchDocumentNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceListName;
        private DevExpress.XtraGrid.Columns.GridColumn colNetAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colAdvanceAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
        private DevExpress.XtraBars.BarButtonItem btnSaleInvoiceNoPrefix;
    }
}