namespace Alit.Marker.WinForm.Reports.TransactionReports
{
    partial class frmRepCustomerBalanceReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepCustomerBalanceReport));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.customerBalanceReportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNameTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNameWithTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCityStateShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCityCountryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerPostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerAddressDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerMobileNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerPhoneNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerEMailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerWebsite = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerPAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerGSTNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerServiceTaxNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpeningBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleReturnAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseReturnAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecieptAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClosingBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deDateFrom = new Alit.WinformControls.DateEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.deDateTo = new Alit.WinformControls.DateEdit();
            this.txtSMSTemplate = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnSendSMS = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnTransactionRegister = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            this.lcTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBalanceReportModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMSTemplate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSendSMS,
            this.btnTransactionRegister});
            this.ribbonControl1.MaxItemId = 30;
            // 
            // 
            // 
            this.ribbonControl1.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl1.SearchEditItem.EditWidth = 150;
            this.ribbonControl1.SearchEditItem.Id = -5000;
            this.ribbonControl1.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.Size = new System.Drawing.Size(1346, 159);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1346, 23);
            // 
            // RootTitle
            // 
            this.RootTitle.Size = new System.Drawing.Size(1346, 61);
            // 
            // lcTitle
            // 
            this.lcTitle.Controls.Add(this.txtSMSTemplate);
            this.lcTitle.Controls.Add(this.deDateFrom);
            this.lcTitle.Controls.Add(this.deDateTo);
            this.lcTitle.OptionsView.HighlightFocusedItem = true;
            this.lcTitle.Size = new System.Drawing.Size(1346, 61);
            // 
            // lcgDefaultFilterGroupBox
            // 
            this.lcgDefaultFilterGroupBox.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(810, 61);
            this.lcgDefaultFilterGroupBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(810, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(536, 61);
            this.lblFormCaption.Text = "Customer Balance Report";
            this.lblFormCaption.TextSize = new System.Drawing.Size(369, 38);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.customerBalanceReportModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 220);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1346, 387);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // customerBalanceReportModelBindingSource
            // 
            this.customerBalanceReportModelBindingSource.DataSource = typeof(Alit.Marker.Model.Reports.TransationReports.CustomerBalanceReportModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerNo,
            this.colCustomerNameTitle,
            this.colCustomerName,
            this.colCompanyName,
            this.colCustomerNameWithTitle,
            this.colCustomerAddress,
            this.colCustomerCityName,
            this.colCustomerCityStateShortName,
            this.colCustomerCityCountryName,
            this.colCustomerPostCode,
            this.colCustomerAddressDetail,
            this.colCustomerMobileNo,
            this.colCustomerPhoneNo,
            this.colCustomerEMailID,
            this.colCustomerWebsite,
            this.colCustomerPAN,
            this.colCustomerGSTNo,
            this.colCustomerServiceTaxNo,
            this.colOpeningBalance,
            this.colSaleAmt,
            this.colSaleReturnAmt,
            this.colPurchaseAmt,
            this.colPurchaseReturnAmt,
            this.colRecieptAmt,
            this.colPaymentAmt,
            this.colClosingBalance});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(923, 501, 266, 274);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gridView1.OptionsSelection.CheckBoxSelectorField = "Select";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridView1_CustomSummaryCalculate);
            // 
            // colCustomerNo
            // 
            this.colCustomerNo.FieldName = "CustomerNo";
            this.colCustomerNo.MaxWidth = 100;
            this.colCustomerNo.MinWidth = 75;
            this.colCustomerNo.Name = "colCustomerNo";
            this.colCustomerNo.Visible = true;
            this.colCustomerNo.VisibleIndex = 1;
            // 
            // colCustomerNameTitle
            // 
            this.colCustomerNameTitle.FieldName = "CustomerNameTitle";
            this.colCustomerNameTitle.MaxWidth = 75;
            this.colCustomerNameTitle.MinWidth = 50;
            this.colCustomerNameTitle.Name = "colCustomerNameTitle";
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.MinWidth = 100;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Width = 100;
            // 
            // colCompanyName
            // 
            this.colCompanyName.FieldName = "CompanyName";
            this.colCompanyName.MaxWidth = 500;
            this.colCompanyName.MinWidth = 100;
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 3;
            this.colCompanyName.Width = 205;
            // 
            // colCustomerNameWithTitle
            // 
            this.colCustomerNameWithTitle.CustomizationCaption = "Customer Name with Title";
            this.colCustomerNameWithTitle.FieldName = "CustomerNameWithTitle";
            this.colCustomerNameWithTitle.MinWidth = 100;
            this.colCustomerNameWithTitle.Name = "colCustomerNameWithTitle";
            this.colCustomerNameWithTitle.OptionsColumn.ReadOnly = true;
            this.colCustomerNameWithTitle.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CustomerNameWithTitle", "{0} Records")});
            this.colCustomerNameWithTitle.Visible = true;
            this.colCustomerNameWithTitle.VisibleIndex = 2;
            this.colCustomerNameWithTitle.Width = 205;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.FieldName = "CustomerAddress";
            this.colCustomerAddress.MinWidth = 100;
            this.colCustomerAddress.Name = "colCustomerAddress";
            this.colCustomerAddress.Width = 100;
            // 
            // colCustomerCityName
            // 
            this.colCustomerCityName.FieldName = "CustomerCityName";
            this.colCustomerCityName.MaxWidth = 300;
            this.colCustomerCityName.MinWidth = 75;
            this.colCustomerCityName.Name = "colCustomerCityName";
            this.colCustomerCityName.Width = 100;
            // 
            // colCustomerCityStateShortName
            // 
            this.colCustomerCityStateShortName.FieldName = "CustomerCityStateShortName";
            this.colCustomerCityStateShortName.MaxWidth = 100;
            this.colCustomerCityStateShortName.MinWidth = 50;
            this.colCustomerCityStateShortName.Name = "colCustomerCityStateShortName";
            // 
            // colCustomerCityCountryName
            // 
            this.colCustomerCityCountryName.FieldName = "CustomerCityCountryName";
            this.colCustomerCityCountryName.MaxWidth = 200;
            this.colCustomerCityCountryName.MinWidth = 75;
            this.colCustomerCityCountryName.Name = "colCustomerCityCountryName";
            // 
            // colCustomerPostCode
            // 
            this.colCustomerPostCode.FieldName = "CustomerPostCode";
            this.colCustomerPostCode.MaxWidth = 100;
            this.colCustomerPostCode.MinWidth = 50;
            this.colCustomerPostCode.Name = "colCustomerPostCode";
            // 
            // colCustomerAddressDetail
            // 
            this.colCustomerAddressDetail.CustomizationCaption = "Full Address";
            this.colCustomerAddressDetail.FieldName = "CustomerAddressDetail";
            this.colCustomerAddressDetail.MinWidth = 100;
            this.colCustomerAddressDetail.Name = "colCustomerAddressDetail";
            this.colCustomerAddressDetail.OptionsColumn.ReadOnly = true;
            this.colCustomerAddressDetail.Visible = true;
            this.colCustomerAddressDetail.VisibleIndex = 4;
            this.colCustomerAddressDetail.Width = 205;
            // 
            // colCustomerMobileNo
            // 
            this.colCustomerMobileNo.FieldName = "CustomerMobileNo";
            this.colCustomerMobileNo.MaxWidth = 300;
            this.colCustomerMobileNo.MinWidth = 75;
            this.colCustomerMobileNo.Name = "colCustomerMobileNo";
            this.colCustomerMobileNo.Visible = true;
            this.colCustomerMobileNo.VisibleIndex = 5;
            this.colCustomerMobileNo.Width = 135;
            // 
            // colCustomerPhoneNo
            // 
            this.colCustomerPhoneNo.FieldName = "CustomerPhoneNo";
            this.colCustomerPhoneNo.MaxWidth = 300;
            this.colCustomerPhoneNo.MinWidth = 75;
            this.colCustomerPhoneNo.Name = "colCustomerPhoneNo";
            // 
            // colCustomerEMailID
            // 
            this.colCustomerEMailID.FieldName = "CustomerEMailID";
            this.colCustomerEMailID.MaxWidth = 300;
            this.colCustomerEMailID.MinWidth = 75;
            this.colCustomerEMailID.Name = "colCustomerEMailID";
            // 
            // colCustomerWebsite
            // 
            this.colCustomerWebsite.FieldName = "CustomerWebsite";
            this.colCustomerWebsite.MaxWidth = 300;
            this.colCustomerWebsite.MinWidth = 75;
            this.colCustomerWebsite.Name = "colCustomerWebsite";
            // 
            // colCustomerPAN
            // 
            this.colCustomerPAN.FieldName = "CustomerPAN";
            this.colCustomerPAN.MaxWidth = 150;
            this.colCustomerPAN.MinWidth = 75;
            this.colCustomerPAN.Name = "colCustomerPAN";
            // 
            // colCustomerGSTNo
            // 
            this.colCustomerGSTNo.FieldName = "CustomerGSTNo";
            this.colCustomerGSTNo.MaxWidth = 150;
            this.colCustomerGSTNo.MinWidth = 75;
            this.colCustomerGSTNo.Name = "colCustomerGSTNo";
            // 
            // colCustomerServiceTaxNo
            // 
            this.colCustomerServiceTaxNo.FieldName = "CustomerServiceTaxNo";
            this.colCustomerServiceTaxNo.MaxWidth = 150;
            this.colCustomerServiceTaxNo.MinWidth = 75;
            this.colCustomerServiceTaxNo.Name = "colCustomerServiceTaxNo";
            // 
            // colOpeningBalance
            // 
            this.colOpeningBalance.DisplayFormat.FormatString = "n2";
            this.colOpeningBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOpeningBalance.FieldName = "OpeningBalance";
            this.colOpeningBalance.MaxWidth = 125;
            this.colOpeningBalance.MinWidth = 75;
            this.colOpeningBalance.Name = "colOpeningBalance";
            this.colOpeningBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OpeningBalance", "{0:n2}")});
            this.colOpeningBalance.Visible = true;
            this.colOpeningBalance.VisibleIndex = 6;
            this.colOpeningBalance.Width = 125;
            // 
            // colSaleAmt
            // 
            this.colSaleAmt.DisplayFormat.FormatString = "n2";
            this.colSaleAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaleAmt.FieldName = "SaleAmt";
            this.colSaleAmt.MaxWidth = 125;
            this.colSaleAmt.MinWidth = 75;
            this.colSaleAmt.Name = "colSaleAmt";
            this.colSaleAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaleAmt", "{0:n2}")});
            this.colSaleAmt.Visible = true;
            this.colSaleAmt.VisibleIndex = 7;
            this.colSaleAmt.Width = 125;
            // 
            // colSaleReturnAmt
            // 
            this.colSaleReturnAmt.DisplayFormat.FormatString = "n2";
            this.colSaleReturnAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaleReturnAmt.FieldName = "SaleReturnAmt";
            this.colSaleReturnAmt.MaxWidth = 125;
            this.colSaleReturnAmt.MinWidth = 75;
            this.colSaleReturnAmt.Name = "colSaleReturnAmt";
            this.colSaleReturnAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaleReturnAmt", "{0:n2}")});
            // 
            // colPurchaseAmt
            // 
            this.colPurchaseAmt.DisplayFormat.FormatString = "n2";
            this.colPurchaseAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPurchaseAmt.FieldName = "PurchaseAmt";
            this.colPurchaseAmt.MaxWidth = 125;
            this.colPurchaseAmt.MinWidth = 75;
            this.colPurchaseAmt.Name = "colPurchaseAmt";
            this.colPurchaseAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PurchaseAmt", "{0:n2}")});
            // 
            // colPurchaseReturnAmt
            // 
            this.colPurchaseReturnAmt.DisplayFormat.FormatString = "n2";
            this.colPurchaseReturnAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPurchaseReturnAmt.FieldName = "PurchaseReturnAmt";
            this.colPurchaseReturnAmt.MaxWidth = 125;
            this.colPurchaseReturnAmt.MinWidth = 75;
            this.colPurchaseReturnAmt.Name = "colPurchaseReturnAmt";
            this.colPurchaseReturnAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PurchaseReturnAmt", "{0:n2}")});
            // 
            // colRecieptAmt
            // 
            this.colRecieptAmt.DisplayFormat.FormatString = "n2";
            this.colRecieptAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRecieptAmt.FieldName = "RecieptAmt";
            this.colRecieptAmt.MaxWidth = 125;
            this.colRecieptAmt.MinWidth = 75;
            this.colRecieptAmt.Name = "colRecieptAmt";
            this.colRecieptAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RecieptAmt", "{0:n2}")});
            this.colRecieptAmt.Visible = true;
            this.colRecieptAmt.VisibleIndex = 8;
            this.colRecieptAmt.Width = 125;
            // 
            // colPaymentAmt
            // 
            this.colPaymentAmt.DisplayFormat.FormatString = "n2";
            this.colPaymentAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPaymentAmt.FieldName = "PaymentAmt";
            this.colPaymentAmt.MaxWidth = 125;
            this.colPaymentAmt.MinWidth = 75;
            this.colPaymentAmt.Name = "colPaymentAmt";
            this.colPaymentAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PaymentAmt", "{0:n2}")});
            // 
            // colClosingBalance
            // 
            this.colClosingBalance.DisplayFormat.FormatString = "n2";
            this.colClosingBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colClosingBalance.FieldName = "ClosingBalance";
            this.colClosingBalance.MaxWidth = 125;
            this.colClosingBalance.MinWidth = 75;
            this.colClosingBalance.Name = "colClosingBalance";
            this.colClosingBalance.OptionsColumn.ReadOnly = true;
            this.colClosingBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ClosingBalance", "{0:n2}")});
            this.colClosingBalance.Visible = true;
            this.colClosingBalance.VisibleIndex = 9;
            this.colClosingBalance.Width = 125;
            // 
            // deDateFrom
            // 
            this.deDateFrom.EditValue = null;
            this.deDateFrom.EnterMoveNextControl = true;
            this.deDateFrom.Location = new System.Drawing.Point(142, 4);
            this.deDateFrom.MaximumSize = new System.Drawing.Size(125, 0);
            this.deDateFrom.MenuManager = this.ribbonControl1;
            this.deDateFrom.MinimumSize = new System.Drawing.Size(100, 0);
            this.deDateFrom.Name = "deDateFrom";
            this.deDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDateFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.deDateFrom.Size = new System.Drawing.Size(100, 22);
            this.deDateFrom.StyleController = this.lcTitle;
            this.deDateFrom.TabIndex = 4;
            this.deDateFrom.Validating += new System.ComponentModel.CancelEventHandler(this.deDateFrom_Validating);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deDateFrom;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(221, 26);
            this.layoutControlItem1.Text = "Date From";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(112, 0);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 52);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(164, 1);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(221, 4);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.deDateTo;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(221, 26);
            this.layoutControlItem2.Text = "Date To";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(112, 0);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // deDateTo
            // 
            this.deDateTo.EditValue = null;
            this.deDateTo.EnterMoveNextControl = true;
            this.deDateTo.Location = new System.Drawing.Point(142, 30);
            this.deDateTo.MaximumSize = new System.Drawing.Size(125, 0);
            this.deDateTo.MenuManager = this.ribbonControl1;
            this.deDateTo.MinimumSize = new System.Drawing.Size(100, 0);
            this.deDateTo.Name = "deDateTo";
            this.deDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.DisplayFormat.FormatString = "";
            this.deDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDateTo.Properties.EditFormat.FormatString = "";
            this.deDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDateTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.deDateTo.Size = new System.Drawing.Size(100, 22);
            this.deDateTo.StyleController = this.lcTitle;
            this.deDateTo.TabIndex = 5;
            // 
            // txtSMSTemplate
            // 
            this.txtSMSTemplate.Location = new System.Drawing.Point(331, 4);
            this.txtSMSTemplate.MaximumSize = new System.Drawing.Size(500, 0);
            this.txtSMSTemplate.MenuManager = this.ribbonControl1;
            this.txtSMSTemplate.Name = "txtSMSTemplate";
            this.txtSMSTemplate.Size = new System.Drawing.Size(474, 52);
            this.txtSMSTemplate.StyleController = this.lcTitle;
            this.txtSMSTemplate.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.layoutControlItem3.Control = this.txtSMSTemplate;
            this.layoutControlItem3.Location = new System.Drawing.Point(221, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(563, 56);
            this.layoutControlItem3.Text = "SMS Template";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(80, 0);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnSendSMS);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "SMS";
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.Caption = "Send SMS";
            this.btnSendSMS.Id = 28;
            this.btnSendSMS.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSendSMS.ImageOptions.SvgImage")));
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSendSMS_ItemClick);
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnTransactionRegister);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Report";
            // 
            // btnTransactionRegister
            // 
            this.btnTransactionRegister.Caption = "Transaction Register";
            this.btnTransactionRegister.Id = 29;
            this.btnTransactionRegister.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTransactionRegister.ImageOptions.SvgImage")));
            this.btnTransactionRegister.Name = "btnTransactionRegister";
            this.btnTransactionRegister.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTransactionRegister.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTransactionRegister_ItemClick);
            // 
            // frmRepCustomerBalanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 630);
            this.Controls.Add(this.gridControl1);
            //this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmRepCustomerBalanceReport.IconOptions.Icon")));
            this.Name = "frmRepCustomerBalanceReport";
            this.ShowDefaultFilter = true;
            this.Text = "Customer Balance Report";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.lcTitle, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).EndInit();
            this.lcTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBalanceReportModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMSTemplate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource customerBalanceReportModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNameTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNameWithTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCityName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCityStateShortName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCityCountryName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerPostCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerAddressDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerMobileNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerPhoneNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerEMailID;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerWebsite;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerPAN;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerGSTNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerServiceTaxNo;
        private DevExpress.XtraGrid.Columns.GridColumn colOpeningBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleReturnAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseReturnAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colRecieptAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colClosingBalance;
        private Alit.WinformControls.DateEdit deDateFrom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.MemoEdit txtSMSTemplate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.BarButtonItem btnSendSMS;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private Alit.WinformControls.DateEdit deDateTo;
        private DevExpress.XtraBars.BarButtonItem btnTransactionRegister;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
    }
}