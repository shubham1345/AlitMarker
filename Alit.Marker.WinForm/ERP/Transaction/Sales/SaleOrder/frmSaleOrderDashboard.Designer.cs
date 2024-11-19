namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleOrder
{
    partial class frmSaleOrderDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleOrderDashboard));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.saleOrderDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSaleOrderNoPrefixName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleOrderNoWithPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCompleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSaleOrderNoPrefix = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleOrderDashboardViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSaleOrderNoPrefix});
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
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(467, 55);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(467, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(917, 55);
            this.lblFormCaption.Text = "Sale Order";
            this.lblFormCaption.TextSize = new System.Drawing.Size(156, 38);
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
            this.rpgMaster.ItemLinks.Add(this.btnSaleOrderNoPrefix);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.saleOrderDashboardViewModelBindingSource;
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
            // saleOrderDashboardViewModelBindingSource
            // 
            this.saleOrderDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.ERP.Transaction.Sales.SaleOrder.SaleOrderDashboardViewModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSaleOrderNoPrefixName,
            this.colSaleOrderNo,
            this.colSaleOrderNoWithPrefix,
            this.colOrderDate,
            this.colCustomerName,
            this.colCustomerAddress,
            this.colCustomerCityName,
            this.colNetAmt,
            this.colOrderMemo,
            this.colIsCompleted,
            this.colRecordState});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSaleOrderNoPrefixName
            // 
            this.colSaleOrderNoPrefixName.FieldName = "SaleOrderNoPrefixName";
            this.colSaleOrderNoPrefixName.MaxWidth = 150;
            this.colSaleOrderNoPrefixName.MinWidth = 105;
            this.colSaleOrderNoPrefixName.Name = "colSaleOrderNoPrefixName";
            this.colSaleOrderNoPrefixName.Width = 108;
            // 
            // colSaleOrderNo
            // 
            this.colSaleOrderNo.FieldName = "SaleOrderNo";
            this.colSaleOrderNo.MaxWidth = 100;
            this.colSaleOrderNo.MinWidth = 65;
            this.colSaleOrderNo.Name = "colSaleOrderNo";
            this.colSaleOrderNo.Width = 65;
            // 
            // colSaleOrderNoWithPrefix
            // 
            this.colSaleOrderNoWithPrefix.FieldName = "SaleOrderNoWithPrefix";
            this.colSaleOrderNoWithPrefix.MaxWidth = 150;
            this.colSaleOrderNoWithPrefix.MinWidth = 70;
            this.colSaleOrderNoWithPrefix.Name = "colSaleOrderNoWithPrefix";
            this.colSaleOrderNoWithPrefix.Visible = true;
            this.colSaleOrderNoWithPrefix.VisibleIndex = 1;
            this.colSaleOrderNoWithPrefix.Width = 70;
            // 
            // colOrderDate
            // 
            this.colOrderDate.FieldName = "OrderDate";
            this.colOrderDate.MaxWidth = 125;
            this.colOrderDate.MinWidth = 80;
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.Visible = true;
            this.colOrderDate.VisibleIndex = 0;
            this.colOrderDate.Width = 103;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.MaxWidth = 500;
            this.colCustomerName.MinWidth = 100;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 2;
            this.colCustomerName.Width = 314;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.FieldName = "CustomerAddress";
            this.colCustomerAddress.MaxWidth = 500;
            this.colCustomerAddress.MinWidth = 100;
            this.colCustomerAddress.Name = "colCustomerAddress";
            this.colCustomerAddress.Visible = true;
            this.colCustomerAddress.VisibleIndex = 3;
            this.colCustomerAddress.Width = 367;
            // 
            // colCustomerCityName
            // 
            this.colCustomerCityName.FieldName = "CustomerCityName";
            this.colCustomerCityName.MaxWidth = 300;
            this.colCustomerCityName.MinWidth = 75;
            this.colCustomerCityName.Name = "colCustomerCityName";
            this.colCustomerCityName.Visible = true;
            this.colCustomerCityName.VisibleIndex = 4;
            this.colCustomerCityName.Width = 104;
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
            this.colNetAmt.VisibleIndex = 5;
            this.colNetAmt.Width = 104;
            // 
            // colOrderMemo
            // 
            this.colOrderMemo.FieldName = "OrderMemo";
            this.colOrderMemo.MaxWidth = 500;
            this.colOrderMemo.MinWidth = 50;
            this.colOrderMemo.Name = "colOrderMemo";
            this.colOrderMemo.Visible = true;
            this.colOrderMemo.VisibleIndex = 6;
            this.colOrderMemo.Width = 157;
            // 
            // colIsCompleted
            // 
            this.colIsCompleted.FieldName = "IsCompleted";
            this.colIsCompleted.MaxWidth = 75;
            this.colIsCompleted.MinWidth = 75;
            this.colIsCompleted.Name = "colIsCompleted";
            this.colIsCompleted.Visible = true;
            this.colIsCompleted.VisibleIndex = 7;
            // 
            // colRecordState
            // 
            this.colRecordState.FieldName = "RecordState";
            this.colRecordState.MaxWidth = 75;
            this.colRecordState.MinWidth = 30;
            this.colRecordState.Name = "colRecordState";
            this.colRecordState.Visible = true;
            this.colRecordState.VisibleIndex = 8;
            // 
            // btnSaleOrderNoPrefix
            // 
            this.btnSaleOrderNoPrefix.Caption = "Sale Order No. Prefix";
            this.btnSaleOrderNoPrefix.Id = 47;
            this.btnSaleOrderNoPrefix.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaleOrderNoPrefix.ImageOptions.SvgImage")));
            this.btnSaleOrderNoPrefix.Name = "btnSaleOrderNoPrefix";
            this.btnSaleOrderNoPrefix.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnSaleOrderNoPrefix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // frmSaleOrderDashboard
            // 
            this.AllowDocumentPrintVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 630);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmSaleOrderDashboard.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSaleOrderDashboard";
            this.Text = "Sale Order";
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
            ((System.ComponentModel.ISupportInitialize)(this.saleOrderDashboardViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource saleOrderDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCityName;
        private DevExpress.XtraGrid.Columns.GridColumn colNetAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCompleted;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleOrderNoPrefixName;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleOrderNoWithPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderMemo;
        private DevExpress.XtraBars.BarButtonItem btnSaleOrderNoPrefix;
    }
}