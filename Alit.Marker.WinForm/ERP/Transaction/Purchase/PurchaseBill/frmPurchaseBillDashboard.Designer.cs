namespace Alit.Marker.WinForm.ERP.Transaction.Purchase.PurchaseBill
{
    partial class frmPurchaseBillDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseBillDashboard));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.purchaseBillDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMemoType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseBillNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseBillDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseReceiptNoPrefixName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseReceiptDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseReceiptNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseReceiptNoWithPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseBillMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPurchaseReceiptNoPrefix = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBillDashboardViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPurchaseReceiptNoPrefix});
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
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(28, 55);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(28, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(1356, 55);
            this.lblFormCaption.Text = "Purchase Bill";
            // 
            // btnDocumentExportTo
            // 
            this.btnDocumentExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDocumentExportTo.ImageOptions.SvgImage")));
            // 
            // btnDashboardExportTo
            // 
            this.btnDashboardExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDashboardExportTo.ImageOptions.SvgImage")));
            // 
            // rpgMaster
            // 
            this.rpgMaster.ItemLinks.Add(this.btnPurchaseReceiptNoPrefix);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.purchaseBillDashboardViewModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 221);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1384, 385);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // purchaseBillDashboardViewModelBindingSource
            // 
            this.purchaseBillDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.ERP.Transaction.Purchase.PurchaseBill.PurchaseBillDashboardViewModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMemoType,
            this.colPurchaseBillNo,
            this.colPurchaseBillDate,
            this.colPurchaseReceiptNoPrefixName,
            this.colPurchaseReceiptDate,
            this.colPurchaseReceiptNo,
            this.colPurchaseReceiptNoWithPrefix,
            this.colCustomerName,
            this.colCustomerAddress,
            this.colCustomerCityName,
            this.colNetAmt,
            this.colPurchaseBillMemo,
            this.colRecordState});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
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
            this.colMemoType.Width = 50;
            // 
            // colPurchaseBillNo
            // 
            this.colPurchaseBillNo.FieldName = "PurchaseBillNo";
            this.colPurchaseBillNo.MaxWidth = 150;
            this.colPurchaseBillNo.MinWidth = 50;
            this.colPurchaseBillNo.Name = "colPurchaseBillNo";
            this.colPurchaseBillNo.Visible = true;
            this.colPurchaseBillNo.VisibleIndex = 2;
            this.colPurchaseBillNo.Width = 50;
            // 
            // colPurchaseBillDate
            // 
            this.colPurchaseBillDate.FieldName = "PurchaseBillDate";
            this.colPurchaseBillDate.MaxWidth = 125;
            this.colPurchaseBillDate.MinWidth = 80;
            this.colPurchaseBillDate.Name = "colPurchaseBillDate";
            this.colPurchaseBillDate.Visible = true;
            this.colPurchaseBillDate.VisibleIndex = 1;
            this.colPurchaseBillDate.Width = 80;
            // 
            // colPurchaseReceiptNoPrefixName
            // 
            this.colPurchaseReceiptNoPrefixName.FieldName = "PurchaseReceiptNoPrefixName";
            this.colPurchaseReceiptNoPrefixName.MaxWidth = 150;
            this.colPurchaseReceiptNoPrefixName.MinWidth = 50;
            this.colPurchaseReceiptNoPrefixName.Name = "colPurchaseReceiptNoPrefixName";
            // 
            // colPurchaseReceiptDate
            // 
            this.colPurchaseReceiptDate.FieldName = "PurchaseReceiptDate";
            this.colPurchaseReceiptDate.MaxWidth = 125;
            this.colPurchaseReceiptDate.MinWidth = 80;
            this.colPurchaseReceiptDate.Name = "colPurchaseReceiptDate";
            this.colPurchaseReceiptDate.Visible = true;
            this.colPurchaseReceiptDate.VisibleIndex = 3;
            this.colPurchaseReceiptDate.Width = 80;
            // 
            // colPurchaseReceiptNo
            // 
            this.colPurchaseReceiptNo.FieldName = "PurchaseReceiptNo";
            this.colPurchaseReceiptNo.MaxWidth = 100;
            this.colPurchaseReceiptNo.MinWidth = 65;
            this.colPurchaseReceiptNo.Name = "colPurchaseReceiptNo";
            this.colPurchaseReceiptNo.Width = 65;
            // 
            // colPurchaseReceiptNoWithPrefix
            // 
            this.colPurchaseReceiptNoWithPrefix.FieldName = "PurchaseReceiptNoWithPrefix";
            this.colPurchaseReceiptNoWithPrefix.MaxWidth = 150;
            this.colPurchaseReceiptNoWithPrefix.MinWidth = 75;
            this.colPurchaseReceiptNoWithPrefix.Name = "colPurchaseReceiptNoWithPrefix";
            this.colPurchaseReceiptNoWithPrefix.Visible = true;
            this.colPurchaseReceiptNoWithPrefix.VisibleIndex = 4;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.MaxWidth = 500;
            this.colCustomerName.MinWidth = 100;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 5;
            this.colCustomerName.Width = 320;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.FieldName = "CustomerAddress";
            this.colCustomerAddress.MaxWidth = 500;
            this.colCustomerAddress.MinWidth = 100;
            this.colCustomerAddress.Name = "colCustomerAddress";
            this.colCustomerAddress.Width = 158;
            // 
            // colCustomerCityName
            // 
            this.colCustomerCityName.FieldName = "CustomerCityName";
            this.colCustomerCityName.MaxWidth = 500;
            this.colCustomerCityName.MinWidth = 75;
            this.colCustomerCityName.Name = "colCustomerCityName";
            this.colCustomerCityName.Visible = true;
            this.colCustomerCityName.VisibleIndex = 6;
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
            // 
            // colPurchaseBillMemo
            // 
            this.colPurchaseBillMemo.FieldName = "PurchaseBillMemo";
            this.colPurchaseBillMemo.MaxWidth = 500;
            this.colPurchaseBillMemo.MinWidth = 75;
            this.colPurchaseBillMemo.Name = "colPurchaseBillMemo";
            this.colPurchaseBillMemo.Visible = true;
            this.colPurchaseBillMemo.VisibleIndex = 8;
            // 
            // colRecordState
            // 
            this.colRecordState.FieldName = "RecordState";
            this.colRecordState.MaxWidth = 100;
            this.colRecordState.MinWidth = 50;
            this.colRecordState.Name = "colRecordState";
            this.colRecordState.Visible = true;
            this.colRecordState.VisibleIndex = 9;
            this.colRecordState.Width = 50;
            // 
            // btnPurchaseReceiptNoPrefix
            // 
            this.btnPurchaseReceiptNoPrefix.Caption = "P.R. No. Prefix";
            this.btnPurchaseReceiptNoPrefix.Id = 47;
            this.btnPurchaseReceiptNoPrefix.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPurchaseReceiptNoPrefix.ImageOptions.SvgImage")));
            this.btnPurchaseReceiptNoPrefix.Name = "btnPurchaseReceiptNoPrefix";
            this.btnPurchaseReceiptNoPrefix.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnPurchaseReceiptNoPrefix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPurchaseReceiptNoPrefix_ItemClick);
            // 
            // frmPurchaseBillDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 630);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmPurchaseBillDashboard.IconOptions.Icon")));
            this.Name = "frmPurchaseBillDashboard";
            this.Text = "Purchase Bill";
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
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBillDashboardViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource purchaseBillDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colMemoType;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseBillNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseBillDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseReceiptNoPrefixName;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseReceiptNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseReceiptDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCityName;
        private DevExpress.XtraGrid.Columns.GridColumn colNetAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseBillMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseReceiptNoWithPrefix;
        private DevExpress.XtraBars.BarButtonItem btnPurchaseReceiptNoPrefix;
    }
}