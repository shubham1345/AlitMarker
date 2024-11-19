namespace Alit.Marker.WinForm.Inventory.Masters.StockItem
{
    partial class frmStockItemDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockItemDashboard));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.productDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHSNCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnOpeningStock = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteOpeningStock = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnStockInHand = new DevExpress.XtraBars.BarButtonItem();
            this.btnStockLedger = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpeningStok = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDashboardViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnOpeningStock,
            this.btnDeleteOpeningStock,
            this.btnStockInHand,
            this.btnStockLedger,
            this.btnOpeningStok});
            this.ribbonControl1.MaxItemId = 56;
            // 
            // 
            // 
            this.ribbonControl1.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl1.SearchEditItem.EditWidth = 150;
            this.ribbonControl1.SearchEditItem.Id = -5000;
            this.ribbonControl1.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            // 
            // rpHome
            // 
            this.rpHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
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
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(298, 55);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(298, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(1086, 55);
            this.lblFormCaption.Text = "Stock Item";
            this.lblFormCaption.TextSize = new System.Drawing.Size(152, 38);
            // 
            // btnDocumentExportTo
            // 
            this.btnDocumentExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDocumentExportTo.ImageOptions.SvgImage")));
            // 
            // btnDashboardExportTo
            // 
            this.btnDashboardExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDashboardExportTo.ImageOptions.SvgImage")));
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.productDashboardViewModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 214);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1384, 393);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // productDashboardViewModelBindingSource
            // 
            this.productDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Inventory.Masters.StockItem.StockItemDashboardViewModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPCode,
            this.colBarcode,
            this.colHSNCode,
            this.colProductName,
            this.colCurrentStock,
            this.colUnitName,
            this.colRecordState});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(1049, 432, 252, 296);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
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
            // colBarcode
            // 
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.MaxWidth = 150;
            this.colBarcode.MinWidth = 60;
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 1;
            this.colBarcode.Width = 60;
            // 
            // colHSNCode
            // 
            this.colHSNCode.FieldName = "HSNCode";
            this.colHSNCode.MaxWidth = 150;
            this.colHSNCode.MinWidth = 75;
            this.colHSNCode.Name = "colHSNCode";
            this.colHSNCode.Visible = true;
            this.colHSNCode.VisibleIndex = 2;
            // 
            // colProductName
            // 
            this.colProductName.FieldName = "ProductName";
            this.colProductName.MaxWidth = 500;
            this.colProductName.MinWidth = 100;
            this.colProductName.Name = "colProductName";
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 3;
            this.colProductName.Width = 270;
            // 
            // colCurrentStock
            // 
            this.colCurrentStock.DisplayFormat.FormatString = "n2";
            this.colCurrentStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCurrentStock.FieldName = "CurrentStock";
            this.colCurrentStock.MaxWidth = 125;
            this.colCurrentStock.MinWidth = 60;
            this.colCurrentStock.Name = "colCurrentStock";
            this.colCurrentStock.Visible = true;
            this.colCurrentStock.VisibleIndex = 4;
            this.colCurrentStock.Width = 60;
            // 
            // colUnitName
            // 
            this.colUnitName.FieldName = "UnitName";
            this.colUnitName.MaxWidth = 100;
            this.colUnitName.MinWidth = 50;
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.Visible = true;
            this.colUnitName.VisibleIndex = 5;
            this.colUnitName.Width = 50;
            // 
            // colRecordState
            // 
            this.colRecordState.FieldName = "RecordState";
            this.colRecordState.MaxWidth = 100;
            this.colRecordState.MinWidth = 30;
            this.colRecordState.Name = "colRecordState";
            this.colRecordState.Visible = true;
            this.colRecordState.VisibleIndex = 6;
            // 
            // btnOpeningStock
            // 
            this.btnOpeningStock.Caption = "Opening Stock";
            this.btnOpeningStock.Id = 51;
            this.btnOpeningStock.Name = "btnOpeningStock";
            this.btnOpeningStock.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnOpeningStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpeningStock_ItemClick);
            // 
            // btnDeleteOpeningStock
            // 
            this.btnDeleteOpeningStock.Caption = "Delete Opening Stock";
            this.btnDeleteOpeningStock.Id = 52;
            this.btnDeleteOpeningStock.Name = "btnDeleteOpeningStock";
            this.btnDeleteOpeningStock.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDeleteOpeningStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeleteOpeningStock_ItemClick);
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnStockInHand);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnStockLedger);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Report";
            // 
            // btnStockInHand
            // 
            this.btnStockInHand.Caption = "Stock In Hand";
            this.btnStockInHand.Id = 53;
            this.btnStockInHand.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnStockInHand.ImageOptions.SvgImage")));
            this.btnStockInHand.Name = "btnStockInHand";
            this.btnStockInHand.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.btnStockInHand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStockInHand_ItemClick);
            // 
            // btnStockLedger
            // 
            this.btnStockLedger.Caption = "Stock Ledger";
            this.btnStockLedger.Id = 54;
            this.btnStockLedger.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnStockLedger.ImageOptions.SvgImage")));
            this.btnStockLedger.Name = "btnStockLedger";
            this.btnStockLedger.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.btnStockLedger.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStockLedger_ItemClick);
            // 
            // btnOpeningStok
            // 
            this.btnOpeningStok.Caption = "Opening Stock";
            this.btnOpeningStok.Id = 55;
            this.btnOpeningStok.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpeningStok.ImageOptions.SvgImage")));
            this.btnOpeningStok.Name = "btnOpeningStok";
            this.btnOpeningStok.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.btnOpeningStok.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpeningStok_ItemClick);
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnOpeningStok);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Transaction";
            // 
            // frmStockItemDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 630);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmStockItemDashboard.IconOptions.Icon")));
            this.Name = "frmStockItemDashboard";
            this.Text = "Stock Item";
            this.Load += new System.EventHandler(this.frmStockItemDashboard_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.productDashboardViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource productDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentStock;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
        private DevExpress.XtraGrid.Columns.GridColumn colHSNCode;
        private DevExpress.XtraBars.BarButtonItem btnOpeningStock;
        private DevExpress.XtraBars.BarButtonItem btnDeleteOpeningStock;
        private DevExpress.XtraBars.BarButtonItem btnStockInHand;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnStockLedger;
        private DevExpress.XtraBars.BarButtonItem btnOpeningStok;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}