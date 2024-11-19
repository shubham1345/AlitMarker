namespace Alit.Marker.WinForm.ERP.Transaction.Sales
{
    partial class frmSaleDefaultDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleDefaultDashboard));
            this.rpgSaleMaster = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnNewCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.btnStockItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnTransport = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewAdditionalDiscountTax = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnTransactionRegister = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomerBalanceReport = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNewCustomer,
            this.btnStockItem,
            this.btnTransport,
            this.btnNewAdditionalDiscountTax,
            this.btnTransactionRegister,
            this.btnCustomerBalanceReport});
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonControl1.MaxItemId = 58;
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
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(30, 55);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(30, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(1354, 55);
            this.lblFormCaption.Text = "Sale";
            this.lblFormCaption.TextSize = new System.Drawing.Size(63, 38);
            // 
            // btnDocumentExportTo
            // 
            this.btnDocumentExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDocumentExportTo.ImageOptions.SvgImage")));
            // 
            // btnDashboardExportTo
            // 
            this.btnDashboardExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDashboardExportTo.ImageOptions.SvgImage")));
            // 
            // rpMaster
            // 
            this.rpMaster.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSaleMaster});
            // 
            // rpReports
            // 
            this.rpReports.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            // 
            // rpgSaleMaster
            // 
            this.rpgSaleMaster.ItemLinks.Add(this.btnNewCustomer);
            this.rpgSaleMaster.ItemLinks.Add(this.btnStockItem);
            this.rpgSaleMaster.ItemLinks.Add(this.btnTransport);
            this.rpgSaleMaster.ItemLinks.Add(this.btnNewAdditionalDiscountTax);
            this.rpgSaleMaster.Name = "rpgSaleMaster";
            this.rpgSaleMaster.Text = "Masters";
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Caption = "New Customer";
            this.btnNewCustomer.Id = 47;
            this.btnNewCustomer.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNewCustomer.ImageOptions.SvgImage")));
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNewCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewCustomer_ItemClick);
            // 
            // btnStockItem
            // 
            this.btnStockItem.Caption = "New Stock Item";
            this.btnStockItem.Id = 48;
            this.btnStockItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNewProduct.ImageOptions.SvgImage")));
            this.btnStockItem.Name = "btnStockItem";
            this.btnStockItem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnStockItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStockItem_ItemClick);
            // 
            // btnTransport
            // 
            this.btnTransport.Caption = "Transport";
            this.btnTransport.Id = 50;
            this.btnTransport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTransport.ImageOptions.SvgImage")));
            this.btnTransport.Name = "btnTransport";
            this.btnTransport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnTransport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTransport_ItemClick);
            // 
            // btnNewAdditionalDiscountTax
            // 
            this.btnNewAdditionalDiscountTax.Caption = "New Discount / Tax";
            this.btnNewAdditionalDiscountTax.Id = 51;
            this.btnNewAdditionalDiscountTax.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNewAdditionalDiscountTax.ImageOptions.SvgImage")));
            this.btnNewAdditionalDiscountTax.Name = "btnNewAdditionalDiscountTax";
            this.btnNewAdditionalDiscountTax.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnNewAdditionalDiscountTax.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewAdditionalDiscountTax_ItemClick);
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnTransactionRegister);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCustomerBalanceReport);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Report";
            // 
            // btnTransactionRegister
            // 
            this.btnTransactionRegister.Caption = "Transaction Register";
            this.btnTransactionRegister.Id = 56;
            this.btnTransactionRegister.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTransactionRegister.ImageOptions.SvgImage")));
            this.btnTransactionRegister.Name = "btnTransactionRegister";
            this.btnTransactionRegister.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.btnTransactionRegister.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTransactionRegister_ItemClick);
            // 
            // btnCustomerBalanceReport
            // 
            this.btnCustomerBalanceReport.Caption = "Balance Report";
            this.btnCustomerBalanceReport.Id = 57;
            this.btnCustomerBalanceReport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCustomerBalanceReport.ImageOptions.SvgImage")));
            this.btnCustomerBalanceReport.Name = "btnCustomerBalanceReport";
            this.btnCustomerBalanceReport.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.btnCustomerBalanceReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomerBalanceReport_ItemClick);
            // 
            // frmSaleDefaultDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 630);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmSaleDefaultDashboard.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSaleDefaultDashboard";
            this.Text = "Sale";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraBars.BarButtonItem btnNewCustomer;
        protected DevExpress.XtraBars.BarButtonItem btnStockItem;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSaleMaster;
        protected DevExpress.XtraBars.BarButtonItem btnTransport;
        protected DevExpress.XtraBars.BarButtonItem btnNewAdditionalDiscountTax;
        private DevExpress.XtraBars.BarButtonItem btnTransactionRegister;
        private DevExpress.XtraBars.BarButtonItem btnCustomerBalanceReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}