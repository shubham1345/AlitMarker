namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleReturn
{
    partial class frmSaleReturnDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleReturnDashboard));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.saleReturnDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMemoType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleReturnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleReturnNoPrefixName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleReturnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleReturnNoWithPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceListName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleReturnMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSRNoPrefix = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleReturnDashboardViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSRNoPrefix});
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
            this.lblFormCaption.Text = "Sale Return";
            this.lblFormCaption.TextSize = new System.Drawing.Size(169, 38);
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
            this.rpgMaster.ItemLinks.Add(this.btnSRNoPrefix);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.saleReturnDashboardViewModelBindingSource;
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
            // saleReturnDashboardViewModelBindingSource
            // 
            this.saleReturnDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.ERP.Transaction.Sales.SaleReturn.SaleReturnDashboardViewModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMemoType,
            this.colSaleReturnDate,
            this.colSaleReturnNoPrefixName,
            this.colSaleReturnNo,
            this.colSaleReturnNoWithPrefix,
            this.colCustomerName,
            this.colCustomerAddress,
            this.colCustomerCityName,
            this.colPriceListName,
            this.colSaleReturnMemo,
            this.colNetAmt,
            this.colRecordState});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colMemoType
            // 
            this.colMemoType.FieldName = "MemoType";
            this.colMemoType.MaxWidth = 100;
            this.colMemoType.MinWidth = 50;
            this.colMemoType.Name = "colMemoType";
            this.colMemoType.Visible = true;
            this.colMemoType.VisibleIndex = 0;
            this.colMemoType.Width = 99;
            // 
            // colSaleReturnDate
            // 
            this.colSaleReturnDate.FieldName = "SaleReturnDate";
            this.colSaleReturnDate.MaxWidth = 125;
            this.colSaleReturnDate.MinWidth = 80;
            this.colSaleReturnDate.Name = "colSaleReturnDate";
            this.colSaleReturnDate.Visible = true;
            this.colSaleReturnDate.VisibleIndex = 1;
            this.colSaleReturnDate.Width = 99;
            // 
            // colSaleReturnNoPrefixName
            // 
            this.colSaleReturnNoPrefixName.FieldName = "SaleReturnNoPrefixName";
            this.colSaleReturnNoPrefixName.MaxWidth = 150;
            this.colSaleReturnNoPrefixName.MinWidth = 90;
            this.colSaleReturnNoPrefixName.Name = "colSaleReturnNoPrefixName";
            this.colSaleReturnNoPrefixName.Width = 90;
            // 
            // colSaleReturnNo
            // 
            this.colSaleReturnNo.FieldName = "SaleReturnNo";
            this.colSaleReturnNo.MaxWidth = 100;
            this.colSaleReturnNo.MinWidth = 60;
            this.colSaleReturnNo.Name = "colSaleReturnNo";
            // 
            // colSaleReturnNoWithPrefix
            // 
            this.colSaleReturnNoWithPrefix.FieldName = "SaleReturnNoWithPrefix";
            this.colSaleReturnNoWithPrefix.MaxWidth = 125;
            this.colSaleReturnNoWithPrefix.MinWidth = 60;
            this.colSaleReturnNoWithPrefix.Name = "colSaleReturnNoWithPrefix";
            this.colSaleReturnNoWithPrefix.OptionsColumn.ReadOnly = true;
            this.colSaleReturnNoWithPrefix.Visible = true;
            this.colSaleReturnNoWithPrefix.VisibleIndex = 2;
            this.colSaleReturnNoWithPrefix.Width = 60;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.MaxWidth = 500;
            this.colCustomerName.MinWidth = 100;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 3;
            this.colCustomerName.Width = 216;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.FieldName = "CustomerAddress";
            this.colCustomerAddress.MaxWidth = 500;
            this.colCustomerAddress.MinWidth = 100;
            this.colCustomerAddress.Name = "colCustomerAddress";
            this.colCustomerAddress.Visible = true;
            this.colCustomerAddress.VisibleIndex = 4;
            this.colCustomerAddress.Width = 310;
            // 
            // colCustomerCityName
            // 
            this.colCustomerCityName.FieldName = "CustomerCityName";
            this.colCustomerCityName.MaxWidth = 150;
            this.colCustomerCityName.MinWidth = 75;
            this.colCustomerCityName.Name = "colCustomerCityName";
            this.colCustomerCityName.Visible = true;
            this.colCustomerCityName.VisibleIndex = 5;
            this.colCustomerCityName.Width = 100;
            // 
            // colPriceListName
            // 
            this.colPriceListName.FieldName = "PriceListName";
            this.colPriceListName.MaxWidth = 150;
            this.colPriceListName.MinWidth = 65;
            this.colPriceListName.Name = "colPriceListName";
            this.colPriceListName.Width = 65;
            // 
            // colSaleReturnMemo
            // 
            this.colSaleReturnMemo.FieldName = "SaleReturnMemo";
            this.colSaleReturnMemo.MaxWidth = 500;
            this.colSaleReturnMemo.MinWidth = 100;
            this.colSaleReturnMemo.Name = "colSaleReturnMemo";
            this.colSaleReturnMemo.Visible = true;
            this.colSaleReturnMemo.VisibleIndex = 6;
            this.colSaleReturnMemo.Width = 205;
            // 
            // colNetAmt
            // 
            this.colNetAmt.DisplayFormat.FormatString = "n2";
            this.colNetAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNetAmt.FieldName = "NetAmt";
            this.colNetAmt.MaxWidth = 125;
            this.colNetAmt.MinWidth = 75;
            this.colNetAmt.Name = "colNetAmt";
            this.colNetAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetAmt", "{0:n2}")});
            this.colNetAmt.Visible = true;
            this.colNetAmt.VisibleIndex = 7;
            this.colNetAmt.Width = 125;
            // 
            // colRecordState
            // 
            this.colRecordState.FieldName = "RecordState";
            this.colRecordState.MaxWidth = 75;
            this.colRecordState.MinWidth = 24;
            this.colRecordState.Name = "colRecordState";
            this.colRecordState.Visible = true;
            this.colRecordState.VisibleIndex = 8;
            // 
            // btnSRNoPrefix
            // 
            this.btnSRNoPrefix.Caption = "S/R No. Prefix   ";
            this.btnSRNoPrefix.Id = 47;
            this.btnSRNoPrefix.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSRNoPrefix.ImageOptions.SvgImage")));
            this.btnSRNoPrefix.Name = "btnSRNoPrefix";
            this.btnSRNoPrefix.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnSRNoPrefix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSRNoPrefix_ItemClick);
            // 
            // frmSaleReturnDashboard
            // 
            this.AllowDocumentPrintVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 630);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmSaleReturnDashboard.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSaleReturnDashboard";
            this.Text = "Sale Return";
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
            ((System.ComponentModel.ISupportInitialize)(this.saleReturnDashboardViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource saleReturnDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colMemoType;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleReturnDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleReturnNoPrefixName;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleReturnNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleReturnNoWithPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCityName;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceListName;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleReturnMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colNetAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
        private DevExpress.XtraBars.BarButtonItem btnSRNoPrefix;
    }
}