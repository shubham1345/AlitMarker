namespace Alit.Marker.WinForm.ERP.Transaction.Purchase.PurchaseReturn
{
    partial class frmPurchaseReturnDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseReturnDashboard));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.purchaseReturnDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMemoType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseReturnNoPrefixName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseReturnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseReturnNoWithPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseReturnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPurchaseReturnNoPrefix = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseReturnDashboardViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPurchaseReturnNoPrefix});
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
            this.lblFormCaption.Text = "Purchase Return";
            this.lblFormCaption.TextSize = new System.Drawing.Size(243, 38);
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
            this.rpgMaster.ItemLinks.Add(this.btnPurchaseReturnNoPrefix);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.purchaseReturnDashboardViewModelBindingSource;
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
            // purchaseReturnDashboardViewModelBindingSource
            // 
            this.purchaseReturnDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnDashboardViewModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMemoType,
            this.colPurchaseReturnNoPrefixName,
            this.colPurchaseReturnNo,
            this.colPurchaseReturnNoWithPrefix,
            this.colPurchaseReturnDate,
            this.colCustomerName,
            this.colCustomerAddress,
            this.colCustomerCityName,
            this.colNetAmt,
            this.colMemo,
            this.colRecordState});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colMemoType
            // 
            this.colMemoType.FieldName = "MemoType";
            this.colMemoType.MaxWidth = 90;
            this.colMemoType.MinWidth = 80;
            this.colMemoType.Name = "colMemoType";
            this.colMemoType.Visible = true;
            this.colMemoType.VisibleIndex = 0;
            this.colMemoType.Width = 80;
            // 
            // colPurchaseReturnNoPrefixName
            // 
            this.colPurchaseReturnNoPrefixName.FieldName = "PurchaseReturnNoPrefixName";
            this.colPurchaseReturnNoPrefixName.MaxWidth = 125;
            this.colPurchaseReturnNoPrefixName.MinWidth = 90;
            this.colPurchaseReturnNoPrefixName.Name = "colPurchaseReturnNoPrefixName";
            this.colPurchaseReturnNoPrefixName.Width = 90;
            // 
            // colPurchaseReturnNo
            // 
            this.colPurchaseReturnNo.FieldName = "PurchaseReturnNo";
            this.colPurchaseReturnNo.MaxWidth = 100;
            this.colPurchaseReturnNo.MinWidth = 50;
            this.colPurchaseReturnNo.Name = "colPurchaseReturnNo";
            this.colPurchaseReturnNo.Width = 100;
            // 
            // colPurchaseReturnNoWithPrefix
            // 
            this.colPurchaseReturnNoWithPrefix.CustomizationCaption = "P/R No. With Prefix";
            this.colPurchaseReturnNoWithPrefix.FieldName = "PurchaseReturnNoWithPrefix";
            this.colPurchaseReturnNoWithPrefix.MaxWidth = 125;
            this.colPurchaseReturnNoWithPrefix.MinWidth = 75;
            this.colPurchaseReturnNoWithPrefix.Name = "colPurchaseReturnNoWithPrefix";
            this.colPurchaseReturnNoWithPrefix.Visible = true;
            this.colPurchaseReturnNoWithPrefix.VisibleIndex = 1;
            this.colPurchaseReturnNoWithPrefix.Width = 101;
            // 
            // colPurchaseReturnDate
            // 
            this.colPurchaseReturnDate.FieldName = "PurchaseReturnDate";
            this.colPurchaseReturnDate.MaxWidth = 125;
            this.colPurchaseReturnDate.MinWidth = 80;
            this.colPurchaseReturnDate.Name = "colPurchaseReturnDate";
            this.colPurchaseReturnDate.Visible = true;
            this.colPurchaseReturnDate.VisibleIndex = 2;
            this.colPurchaseReturnDate.Width = 90;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.MaxWidth = 500;
            this.colCustomerName.MinWidth = 100;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 3;
            this.colCustomerName.Width = 253;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.FieldName = "CustomerAddress";
            this.colCustomerAddress.MaxWidth = 500;
            this.colCustomerAddress.MinWidth = 100;
            this.colCustomerAddress.Name = "colCustomerAddress";
            this.colCustomerAddress.Visible = true;
            this.colCustomerAddress.VisibleIndex = 4;
            this.colCustomerAddress.Width = 305;
            // 
            // colCustomerCityName
            // 
            this.colCustomerCityName.FieldName = "CustomerCityName";
            this.colCustomerCityName.MaxWidth = 200;
            this.colCustomerCityName.MinWidth = 75;
            this.colCustomerCityName.Name = "colCustomerCityName";
            this.colCustomerCityName.Visible = true;
            this.colCustomerCityName.VisibleIndex = 5;
            this.colCustomerCityName.Width = 152;
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
            this.colNetAmt.VisibleIndex = 6;
            this.colNetAmt.Width = 101;
            // 
            // colMemo
            // 
            this.colMemo.FieldName = "Memo";
            this.colMemo.MaxWidth = 500;
            this.colMemo.MinWidth = 50;
            this.colMemo.Name = "colMemo";
            this.colMemo.Visible = true;
            this.colMemo.VisibleIndex = 7;
            this.colMemo.Width = 203;
            // 
            // colRecordState
            // 
            this.colRecordState.FieldName = "RecordState";
            this.colRecordState.MaxWidth = 100;
            this.colRecordState.MinWidth = 50;
            this.colRecordState.Name = "colRecordState";
            this.colRecordState.Visible = true;
            this.colRecordState.VisibleIndex = 8;
            this.colRecordState.Width = 74;
            // 
            // btnPurchaseReturnNoPrefix
            // 
            this.btnPurchaseReturnNoPrefix.Caption = "Purchase Return No. Prefix";
            this.btnPurchaseReturnNoPrefix.Id = 47;
            this.btnPurchaseReturnNoPrefix.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPurchaseReturnNoPrefix.ImageOptions.SvgImage")));
            this.btnPurchaseReturnNoPrefix.Name = "btnPurchaseReturnNoPrefix";
            this.btnPurchaseReturnNoPrefix.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnPurchaseReturnNoPrefix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPurchaseReturnNoPrefix_ItemClick);
            // 
            // frmPurchaseReturnDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 630);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmPurchaseReturnDashboard.IconOptions.Icon")));
            this.Name = "frmPurchaseReturnDashboard";
            this.Text = "Purchase Return";
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
            ((System.ComponentModel.ISupportInitialize)(this.purchaseReturnDashboardViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource purchaseReturnDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseReturnNoPrefixName;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseReturnNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseReturnDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCityName;
        private DevExpress.XtraGrid.Columns.GridColumn colNetAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
        private DevExpress.XtraGrid.Columns.GridColumn colMemoType;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseReturnNoWithPrefix;
        private DevExpress.XtraBars.BarButtonItem btnPurchaseReturnNoPrefix;
    }
}