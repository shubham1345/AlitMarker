namespace Alit.Marker.WinForm.Customer
{
    partial class frmCustomerDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerDashboard));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.customerDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNameTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalanceAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMobileNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoneNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGSTNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpgReport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnTransactionRegister = new DevExpress.XtraBars.BarButtonItem();
            this.rpgOpeningBalance = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnOpeningBalance = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteOpeningBalance = new DevExpress.XtraBars.BarButtonItem();
            this.btnRecalculateCustomerBalance = new DevExpress.XtraBars.BarButtonItem();
            this.btnCity = new DevExpress.XtraBars.BarButtonItem();
            this.btnState = new DevExpress.XtraBars.BarButtonItem();
            this.btnCountry = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDashboardViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnTransactionRegister,
            this.btnOpeningBalance,
            this.btnDeleteOpeningBalance,
            this.btnRecalculateCustomerBalance,
            this.btnCity,
            this.btnState,
            this.btnCountry});
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
            // rpHome
            // 
            this.rpHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgOpeningBalance,
            this.rpgReport});
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
            this.lblFormCaption.Text = "Customer";
            this.lblFormCaption.TextSize = new System.Drawing.Size(141, 38);
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
            this.rpgMaster.ItemLinks.Add(this.btnCity, true);
            this.rpgMaster.ItemLinks.Add(this.btnState);
            this.rpgMaster.ItemLinks.Add(this.btnCountry);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.customerDashboardViewModelBindingSource;
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
            // customerDashboardViewModelBindingSource
            // 
            this.customerDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Customer.CustomerDashboardViewModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerNo,
            this.colCustomerNameTitle,
            this.colCustomerName,
            this.colCompanyName,
            this.colAddress,
            this.colCity,
            this.colBalanceAmt,
            this.colContactPerson,
            this.colMobileNo,
            this.colPhoneNo,
            this.colEMailID,
            this.colPAN,
            this.colGSTNo,
            this.colRecordState});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colCustomerNo
            // 
            this.colCustomerNo.FieldName = "CustomerNo";
            this.colCustomerNo.MaxWidth = 100;
            this.colCustomerNo.MinWidth = 40;
            this.colCustomerNo.Name = "colCustomerNo";
            this.colCustomerNo.Visible = true;
            this.colCustomerNo.VisibleIndex = 0;
            this.colCustomerNo.Width = 53;
            // 
            // colCustomerNameTitle
            // 
            this.colCustomerNameTitle.FieldName = "CustomerNameTitle";
            this.colCustomerNameTitle.MaxWidth = 100;
            this.colCustomerNameTitle.MinWidth = 40;
            this.colCustomerNameTitle.Name = "colCustomerNameTitle";
            this.colCustomerNameTitle.Visible = true;
            this.colCustomerNameTitle.VisibleIndex = 1;
            this.colCustomerNameTitle.Width = 46;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.MaxWidth = 300;
            this.colCustomerName.MinWidth = 100;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 2;
            this.colCustomerName.Width = 118;
            // 
            // colCompanyName
            // 
            this.colCompanyName.FieldName = "CompanyName";
            this.colCompanyName.MaxWidth = 300;
            this.colCompanyName.MinWidth = 100;
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 3;
            this.colCompanyName.Width = 118;
            // 
            // colAddress
            // 
            this.colAddress.FieldName = "Address";
            this.colAddress.MaxWidth = 300;
            this.colAddress.MinWidth = 100;
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 4;
            this.colAddress.Width = 100;
            // 
            // colCity
            // 
            this.colCity.FieldName = "City";
            this.colCity.MaxWidth = 199;
            this.colCity.MinWidth = 75;
            this.colCity.Name = "colCity";
            this.colCity.Visible = true;
            this.colCity.VisibleIndex = 5;
            this.colCity.Width = 77;
            // 
            // colBalanceAmt
            // 
            this.colBalanceAmt.DisplayFormat.FormatString = "n2";
            this.colBalanceAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBalanceAmt.FieldName = "BalanceAmt";
            this.colBalanceAmt.MaxWidth = 125;
            this.colBalanceAmt.MinWidth = 55;
            this.colBalanceAmt.Name = "colBalanceAmt";
            this.colBalanceAmt.Visible = true;
            this.colBalanceAmt.VisibleIndex = 6;
            this.colBalanceAmt.Width = 56;
            // 
            // colContactPerson
            // 
            this.colContactPerson.FieldName = "ContactPerson";
            this.colContactPerson.MaxWidth = 199;
            this.colContactPerson.MinWidth = 100;
            this.colContactPerson.Name = "colContactPerson";
            this.colContactPerson.Visible = true;
            this.colContactPerson.VisibleIndex = 7;
            this.colContactPerson.Width = 102;
            // 
            // colMobileNo
            // 
            this.colMobileNo.FieldName = "MobileNo";
            this.colMobileNo.MaxWidth = 120;
            this.colMobileNo.MinWidth = 75;
            this.colMobileNo.Name = "colMobileNo";
            this.colMobileNo.Visible = true;
            this.colMobileNo.VisibleIndex = 8;
            this.colMobileNo.Width = 88;
            // 
            // colPhoneNo
            // 
            this.colPhoneNo.FieldName = "PhoneNo";
            this.colPhoneNo.MaxWidth = 120;
            this.colPhoneNo.MinWidth = 75;
            this.colPhoneNo.Name = "colPhoneNo";
            this.colPhoneNo.Visible = true;
            this.colPhoneNo.VisibleIndex = 9;
            this.colPhoneNo.Width = 76;
            // 
            // colEMailID
            // 
            this.colEMailID.FieldName = "EMailID";
            this.colEMailID.MaxWidth = 199;
            this.colEMailID.MinWidth = 65;
            this.colEMailID.Name = "colEMailID";
            this.colEMailID.Visible = true;
            this.colEMailID.VisibleIndex = 10;
            this.colEMailID.Width = 65;
            // 
            // colPAN
            // 
            this.colPAN.FieldName = "PAN";
            this.colPAN.MaxWidth = 120;
            this.colPAN.MinWidth = 50;
            this.colPAN.Name = "colPAN";
            this.colPAN.Visible = true;
            this.colPAN.VisibleIndex = 11;
            this.colPAN.Width = 85;
            // 
            // colGSTNo
            // 
            this.colGSTNo.FieldName = "GSTNo";
            this.colGSTNo.MaxWidth = 120;
            this.colGSTNo.MinWidth = 50;
            this.colGSTNo.Name = "colGSTNo";
            this.colGSTNo.Visible = true;
            this.colGSTNo.VisibleIndex = 12;
            this.colGSTNo.Width = 99;
            // 
            // colRecordState
            // 
            this.colRecordState.FieldName = "RecordState";
            this.colRecordState.MaxWidth = 100;
            this.colRecordState.MinWidth = 40;
            this.colRecordState.Name = "colRecordState";
            this.colRecordState.Visible = true;
            this.colRecordState.VisibleIndex = 13;
            this.colRecordState.Width = 73;
            // 
            // rpgReport
            // 
            this.rpgReport.ItemLinks.Add(this.btnTransactionRegister);
            this.rpgReport.Name = "rpgReport";
            this.rpgReport.Text = "Report";
            // 
            // btnTransactionRegister
            // 
            this.btnTransactionRegister.Caption = "Transaction Register";
            this.btnTransactionRegister.Id = 50;
            this.btnTransactionRegister.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTransactionRegister.ImageOptions.SvgImage")));
            this.btnTransactionRegister.Name = "btnTransactionRegister";
            this.btnTransactionRegister.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTransactionRegister.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTransactionRegister_ItemClick);
            // 
            // rpgOpeningBalance
            // 
            this.rpgOpeningBalance.ItemLinks.Add(this.btnOpeningBalance);
            this.rpgOpeningBalance.ItemLinks.Add(this.btnDeleteOpeningBalance);
            this.rpgOpeningBalance.ItemLinks.Add(this.btnRecalculateCustomerBalance);
            this.rpgOpeningBalance.Name = "rpgOpeningBalance";
            this.rpgOpeningBalance.Text = "Opening Balance";
            // 
            // btnOpeningBalance
            // 
            this.btnOpeningBalance.Caption = "Opening Balance";
            this.btnOpeningBalance.Id = 51;
            this.btnOpeningBalance.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpeningBalance.ImageOptions.SvgImage")));
            this.btnOpeningBalance.Name = "btnOpeningBalance";
            this.btnOpeningBalance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpeningBalance_ItemClick);
            // 
            // btnDeleteOpeningBalance
            // 
            this.btnDeleteOpeningBalance.Caption = "Delete Opening Balance";
            this.btnDeleteOpeningBalance.Enabled = false;
            this.btnDeleteOpeningBalance.Id = 52;
            this.btnDeleteOpeningBalance.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDeleteOpeningBalance.ImageOptions.SvgImage")));
            this.btnDeleteOpeningBalance.Name = "btnDeleteOpeningBalance";
            this.btnDeleteOpeningBalance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeleteOpeningBalance_ItemClick);
            // 
            // btnRecalculateCustomerBalance
            // 
            this.btnRecalculateCustomerBalance.Caption = "Recalculate Balance";
            this.btnRecalculateCustomerBalance.Id = 53;
            this.btnRecalculateCustomerBalance.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRecalculateCustomerBalance.ImageOptions.SvgImage")));
            this.btnRecalculateCustomerBalance.Name = "btnRecalculateCustomerBalance";
            this.btnRecalculateCustomerBalance.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.btnRecalculateCustomerBalance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRecalculateCustomerBalance_ItemClick);
            // 
            // btnCity
            // 
            this.btnCity.Caption = "City";
            this.btnCity.Id = 54;
            this.btnCity.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCity.ImageOptions.SvgImage")));
            this.btnCity.Name = "btnCity";
            this.btnCity.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnCity.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCity_ItemClick);
            // 
            // btnState
            // 
            this.btnState.Caption = "State";
            this.btnState.Id = 56;
            this.btnState.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnState.ImageOptions.SvgImage")));
            this.btnState.Name = "btnState";
            this.btnState.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnState.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnState_ItemClick);
            // 
            // btnCountry
            // 
            this.btnCountry.Caption = "Country";
            this.btnCountry.Id = 57;
            this.btnCountry.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCountry.ImageOptions.SvgImage")));
            this.btnCountry.Name = "btnCountry";
            this.btnCountry.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnCountry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCountry_ItemClick);
            // 
            // frmCustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 630);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmCustomerDashboard.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmCustomerDashboard";
            this.Text = "Customer";
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
            ((System.ComponentModel.ISupportInitialize)(this.customerDashboardViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource customerDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNameTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colCity;
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colContactPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colMobileNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoneNo;
        private DevExpress.XtraGrid.Columns.GridColumn colEMailID;
        private DevExpress.XtraGrid.Columns.GridColumn colPAN;
        private DevExpress.XtraGrid.Columns.GridColumn colGSTNo;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
        private DevExpress.XtraBars.BarButtonItem btnTransactionRegister;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgReport;
        private DevExpress.XtraBars.BarButtonItem btnOpeningBalance;
        private DevExpress.XtraBars.BarButtonItem btnDeleteOpeningBalance;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgOpeningBalance;
        private DevExpress.XtraBars.BarButtonItem btnRecalculateCustomerBalance;
        private DevExpress.XtraBars.BarButtonItem btnCity;
        private DevExpress.XtraBars.BarButtonItem btnState;
        private DevExpress.XtraBars.BarButtonItem btnCountry;
    }
}