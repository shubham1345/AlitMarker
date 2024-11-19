
namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleOrder
{
    partial class frmSaleOrderCRUD
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleOrderCRUD));
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.layoutControlMain = new Alit.WinformControls.myLayoutControl();
            this.ucCustomerSelection1 = new Alit.Marker.WinForm.Customer.ucCustomerSelectionOld();
            this.txtRoundOff = new Alit.WinformControls.TextEdit();
            this.chkbSendSMS = new DevExpress.XtraEditors.CheckEdit();
            this.txtSMSSenderID = new DevExpress.XtraEditors.TextEdit();
            this.txtSMSMobileNos = new DevExpress.XtraEditors.TextEdit();
            this.memoSMS = new DevExpress.XtraEditors.MemoEdit();
            this.txtMemo = new Alit.WinformControls.MemoEdit();
            this.txtNetAmt = new Alit.WinformControls.TextEdit();
            this.gridControlAdditionals = new DevExpress.XtraGrid.GridControl();
            this.SaleOrderAdditionalsViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewAdditionals = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAdditionalsID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdditionalItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdditionalItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridviewAddLookUpAddItemMaster = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colItemDescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemNature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewAdditionalsCmbNature = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colPerc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewAdditionalsTxtAmt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colUpdatedAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeleteRowAdditional = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItembtnDeleteRowAdditional = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.lookUpPriceList = new Alit.Marker.WinForm.Inventory.Masters.Product.LookupEditPriceList();
            this.gridControlProductDetail = new DevExpress.XtraGrid.GridControl();
            this.SaleOrderProductDetailViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewProductDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewProductDetailtxtPCode = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewProductDetailLookUpProduct = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ProductSelectionViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colProductDescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewProductDetailProdDescr = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewProductDetailtxtQuan = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridviewProductDetailLookupUnitName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colGAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewProductDetaitxtAmt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colDiscPerc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewProductDetailPerc = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colDiscAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTax1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewProductDetaiLookUpTax1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTax2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewProductDetaiLookUpTax2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTax3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewProductDetaiLookUpTax3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNetAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeletRow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItembtnDeleteRowPDetail = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridViewProductDetailtxtBarcode = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridViewProductDetailtxtProductName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtSaleOrderNo = new Alit.WinformControls.TextEdit();
            this.deInvoiceDate = new Alit.WinformControls.DateEdit();
            this.lookUpInvPrefix = new Alit.WinformControls.LookUpEdit();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgFooter = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgAddLess = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgNetAmt = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciRoundOff = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgMemoAndSMS = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgSMS = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgMemo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblFooterSeparator = new DevExpress.XtraLayout.SimpleLabelItem();
            this.lcgInvoiceNo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciSaleOrderNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSaleOrderNoPrefix = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgPriceList = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciPriceList = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgCustomer = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.customerLookUpListModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.popupMenuGridShortCut = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barbtnGridAddRow = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnGridDeleteRow = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBase1)).BeginInit();
            this.panelBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).BeginInit();
            this.layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoundOff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkbSendSMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMSSenderID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMSMobileNos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoSMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetAmt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAdditionals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleOrderAdditionalsViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdditionals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewAddLookUpAddItemMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdditionalsCmbNature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdditionalsTxtAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItembtnDeleteRowAdditional)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpPriceList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleOrderProductDetailViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetailtxtPCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetailLookUpProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductSelectionViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetailProdDescr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetailtxtQuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewProductDetailLookupUnitName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetaitxtAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetailPerc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetaiLookUpTax1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetaiLookUpTax2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetaiLookUpTax3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItembtnDeleteRowPDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetailtxtBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetailtxtProductName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaleOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deInvoiceDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deInvoiceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpInvPrefix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgAddLess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgNetAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRoundOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMemoAndSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFooterSeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgInvoiceNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSaleOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSaleOrderNoPrefix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerLookUpListModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuGridShortCut)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBase1
            // 
            this.panelBase1.Size = new System.Drawing.Size(1184, 684);
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.layoutControlMain);
            this.panelContent.Location = new System.Drawing.Point(0, 26);
            this.panelContent.Size = new System.Drawing.Size(1184, 624);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // layoutControlMain
            // 
            this.layoutControlMain.Controls.Add(this.ucCustomerSelection1);
            this.layoutControlMain.Controls.Add(this.txtRoundOff);
            this.layoutControlMain.Controls.Add(this.chkbSendSMS);
            this.layoutControlMain.Controls.Add(this.txtSMSSenderID);
            this.layoutControlMain.Controls.Add(this.txtSMSMobileNos);
            this.layoutControlMain.Controls.Add(this.memoSMS);
            this.layoutControlMain.Controls.Add(this.txtMemo);
            this.layoutControlMain.Controls.Add(this.txtNetAmt);
            this.layoutControlMain.Controls.Add(this.gridControlAdditionals);
            this.layoutControlMain.Controls.Add(this.lookUpPriceList);
            this.layoutControlMain.Controls.Add(this.gridControlProductDetail);
            this.layoutControlMain.Controls.Add(this.txtSaleOrderNo);
            this.layoutControlMain.Controls.Add(this.deInvoiceDate);
            this.layoutControlMain.Controls.Add(this.lookUpInvPrefix);
            this.layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlMain.Location = new System.Drawing.Point(2, 2);
            this.layoutControlMain.Name = "layoutControlMain";
            this.layoutControlMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(198, 43, 841, 479);
            this.layoutControlMain.Root = this.lcgMain;
            this.layoutControlMain.Size = new System.Drawing.Size(1180, 620);
            this.layoutControlMain.TabIndex = 0;
            this.layoutControlMain.Text = "layoutControl1";
            // 
            // ucCustomerSelection1
            // 
            this.ucCustomerSelection1.CustomerID = ((long)(0));
            this.ucCustomerSelection1.Location = new System.Drawing.Point(15, 46);
            this.ucCustomerSelection1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucCustomerSelection1.MinimumSize = new System.Drawing.Size(0, 28);
            this.ucCustomerSelection1.Name = "ucCustomerSelection1";
            this.ucCustomerSelection1.Size = new System.Drawing.Size(864, 28);
            this.ucCustomerSelection1.TabIndex = 45;
            this.ucCustomerSelection1.CustomerIDChanged += new System.EventHandler(this.ucCustomerSelection1_CustomerIDChanged);
            this.ucCustomerSelection1.Validating += new System.ComponentModel.CancelEventHandler(this.lookupCustomer_Validating);
            // 
            // txtRoundOff
            // 
            this.txtRoundOff.EnterMoveNextControl = true;
            this.txtRoundOff.Location = new System.Drawing.Point(905, 587);
            this.txtRoundOff.MaximumSize = new System.Drawing.Size(100, 0);
            this.txtRoundOff.MenuManager = this.barManager1;
            this.txtRoundOff.MinimumSize = new System.Drawing.Size(50, 0);
            this.txtRoundOff.Name = "txtRoundOff";
            this.txtRoundOff.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRoundOff.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtRoundOff.Properties.Mask.EditMask = "n2";
            this.txtRoundOff.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRoundOff.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtRoundOff.Properties.NullText = "0.00";
            this.txtRoundOff.Properties.ReadOnly = true;
            this.txtRoundOff.Size = new System.Drawing.Size(100, 22);
            this.txtRoundOff.StyleController = this.layoutControlMain;
            this.txtRoundOff.TabIndex = 44;
            // 
            // chkbSendSMS
            // 
            this.chkbSendSMS.EnterMoveNextControl = true;
            this.chkbSendSMS.Location = new System.Drawing.Point(314, 435);
            this.chkbSendSMS.MenuManager = this.barManager1;
            this.chkbSendSMS.Name = "chkbSendSMS";
            this.chkbSendSMS.Properties.Caption = "Send SMS";
            this.chkbSendSMS.Size = new System.Drawing.Size(87, 20);
            this.chkbSendSMS.StyleController = this.layoutControlMain;
            this.chkbSendSMS.TabIndex = 43;
            // 
            // txtSMSSenderID
            // 
            this.txtSMSSenderID.Location = new System.Drawing.Point(467, 435);
            this.txtSMSSenderID.MenuManager = this.barManager1;
            this.txtSMSSenderID.Name = "txtSMSSenderID";
            this.txtSMSSenderID.Properties.MaxLength = 6;
            this.txtSMSSenderID.Size = new System.Drawing.Size(138, 22);
            this.txtSMSSenderID.StyleController = this.layoutControlMain;
            this.txtSMSSenderID.TabIndex = 42;
            this.txtSMSSenderID.Validating += new System.ComponentModel.CancelEventHandler(this.txtSMSSenderID_Validating);
            // 
            // txtSMSMobileNos
            // 
            this.txtSMSMobileNos.Location = new System.Drawing.Point(384, 461);
            this.txtSMSMobileNos.MenuManager = this.barManager1;
            this.txtSMSMobileNos.Name = "txtSMSMobileNos";
            this.txtSMSMobileNos.Size = new System.Drawing.Size(221, 22);
            this.txtSMSMobileNos.StyleController = this.layoutControlMain;
            this.txtSMSMobileNos.TabIndex = 41;
            this.txtSMSMobileNos.Validating += new System.ComponentModel.CancelEventHandler(this.txtSMSMobileNos_Validating);
            // 
            // memoSMS
            // 
            this.memoSMS.Location = new System.Drawing.Point(314, 487);
            this.memoSMS.MenuManager = this.barManager1;
            this.memoSMS.Name = "memoSMS";
            this.memoSMS.Size = new System.Drawing.Size(291, 125);
            this.memoSMS.StyleController = this.layoutControlMain;
            this.memoSMS.TabIndex = 40;
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(18, 438);
            this.txtMemo.MenuManager = this.barManager1;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Properties.MaxLength = 1000;
            this.txtMemo.Size = new System.Drawing.Size(283, 171);
            this.txtMemo.StyleController = this.layoutControlMain;
            this.txtMemo.TabIndex = 33;
            this.txtMemo.TabStop = false;
            // 
            // txtNetAmt
            // 
            this.txtNetAmt.EnterMoveNextControl = true;
            this.txtNetAmt.Location = new System.Drawing.Point(1062, 587);
            this.txtNetAmt.MaximumSize = new System.Drawing.Size(100, 0);
            this.txtNetAmt.MenuManager = this.barManager1;
            this.txtNetAmt.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtNetAmt.Name = "txtNetAmt";
            this.txtNetAmt.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNetAmt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtNetAmt.Properties.Mask.EditMask = "n2";
            this.txtNetAmt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNetAmt.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtNetAmt.Properties.NullText = "0.00";
            this.txtNetAmt.Properties.ReadOnly = true;
            this.txtNetAmt.Size = new System.Drawing.Size(100, 22);
            this.txtNetAmt.StyleController = this.layoutControlMain;
            this.txtNetAmt.TabIndex = 35;
            this.txtNetAmt.TabStop = false;
            // 
            // gridControlAdditionals
            // 
            this.gridControlAdditionals.DataSource = this.SaleOrderAdditionalsViewModelBindingSource;
            this.gridControlAdditionals.Location = new System.Drawing.Point(618, 437);
            this.gridControlAdditionals.MainView = this.gridViewAdditionals;
            this.gridControlAdditionals.MaximumSize = new System.Drawing.Size(1000, 150);
            this.gridControlAdditionals.MenuManager = this.barManager1;
            this.gridControlAdditionals.MinimumSize = new System.Drawing.Size(300, 70);
            this.gridControlAdditionals.Name = "gridControlAdditionals";
            this.gridControlAdditionals.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridViewAdditionalsCmbNature,
            this.gridViewAdditionalsTxtAmt,
            this.gridviewAddLookUpAddItemMaster,
            this.repositoryItembtnDeleteRowAdditional});
            this.gridControlAdditionals.Size = new System.Drawing.Size(544, 146);
            this.gridControlAdditionals.TabIndex = 32;
            this.gridControlAdditionals.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAdditionals});
            // 
            // SaleOrderAdditionalsViewModelBindingSource
            // 
            this.SaleOrderAdditionalsViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.ERP.Transaction.Sales.SaleOrder.SaleOrderAdditionalsViewModel);
            // 
            // gridViewAdditionals
            // 
            this.gridViewAdditionals.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAdditionalsID,
            this.colAdditionalItemID,
            this.colAdditionalItemName,
            this.colItemDescr,
            this.colItemNature,
            this.colPerc,
            this.colAmt,
            this.colUpdatedAmt,
            this.colRecordType,
            this.colDeleteRowAdditional});
            this.gridViewAdditionals.GridControl = this.gridControlAdditionals;
            this.gridViewAdditionals.Name = "gridViewAdditionals";
            this.gridViewAdditionals.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewAdditionals.OptionsNavigation.UseTabKey = false;
            this.gridViewAdditionals.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewAdditionals.OptionsView.ShowGroupPanel = false;
            this.gridViewAdditionals.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewAdditionals_CellValueChanged);
            // 
            // colAdditionalsID
            // 
            this.colAdditionalsID.FieldName = "AdditionalsID";
            this.colAdditionalsID.Name = "colAdditionalsID";
            // 
            // colAdditionalItemID
            // 
            this.colAdditionalItemID.FieldName = "AdditionalItemID";
            this.colAdditionalItemID.Name = "colAdditionalItemID";
            this.colAdditionalItemID.Width = 100;
            // 
            // colAdditionalItemName
            // 
            this.colAdditionalItemName.ColumnEdit = this.gridviewAddLookUpAddItemMaster;
            this.colAdditionalItemName.FieldName = "AdditionalItemName";
            this.colAdditionalItemName.MaxWidth = 500;
            this.colAdditionalItemName.MinWidth = 55;
            this.colAdditionalItemName.Name = "colAdditionalItemName";
            this.colAdditionalItemName.Visible = true;
            this.colAdditionalItemName.VisibleIndex = 0;
            this.colAdditionalItemName.Width = 154;
            // 
            // gridviewAddLookUpAddItemMaster
            // 
            this.gridviewAddLookUpAddItemMaster.AutoHeight = false;
            this.gridviewAddLookUpAddItemMaster.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridviewAddLookUpAddItemMaster.Name = "gridviewAddLookUpAddItemMaster";
            this.gridviewAddLookUpAddItemMaster.NullText = "";
            this.gridviewAddLookUpAddItemMaster.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // colItemDescr
            // 
            this.colItemDescr.FieldName = "ItemDescr";
            this.colItemDescr.MaxWidth = 1000;
            this.colItemDescr.MinWidth = 90;
            this.colItemDescr.Name = "colItemDescr";
            this.colItemDescr.Visible = true;
            this.colItemDescr.VisibleIndex = 1;
            this.colItemDescr.Width = 241;
            // 
            // colItemNature
            // 
            this.colItemNature.Caption = "+/-";
            this.colItemNature.ColumnEdit = this.gridViewAdditionalsCmbNature;
            this.colItemNature.FieldName = "ItemNature";
            this.colItemNature.MaxWidth = 50;
            this.colItemNature.MinWidth = 50;
            this.colItemNature.Name = "colItemNature";
            this.colItemNature.Visible = true;
            this.colItemNature.VisibleIndex = 2;
            this.colItemNature.Width = 50;
            // 
            // gridViewAdditionalsCmbNature
            // 
            this.gridViewAdditionalsCmbNature.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewAdditionalsCmbNature.AutoHeight = false;
            this.gridViewAdditionalsCmbNature.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.gridViewAdditionalsCmbNature.DropDownRows = 2;
            this.gridViewAdditionalsCmbNature.Items.AddRange(new object[] {
            "Add",
            "Less"});
            this.gridViewAdditionalsCmbNature.Name = "gridViewAdditionalsCmbNature";
            this.gridViewAdditionalsCmbNature.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colPerc
            // 
            this.colPerc.ColumnEdit = this.repositoryItemTextEdit1;
            this.colPerc.FieldName = "Perc";
            this.colPerc.MaxWidth = 70;
            this.colPerc.Name = "colPerc";
            this.colPerc.Width = 20;
            // 
            // colAmt
            // 
            this.colAmt.ColumnEdit = this.gridViewAdditionalsTxtAmt;
            this.colAmt.DisplayFormat.FormatString = "n2";
            this.colAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmt.FieldName = "Amt";
            this.colAmt.MaxWidth = 100;
            this.colAmt.MinWidth = 75;
            this.colAmt.Name = "colAmt";
            this.colAmt.Visible = true;
            this.colAmt.VisibleIndex = 3;
            this.colAmt.Width = 93;
            // 
            // gridViewAdditionalsTxtAmt
            // 
            this.gridViewAdditionalsTxtAmt.AutoHeight = false;
            this.gridViewAdditionalsTxtAmt.DisplayFormat.FormatString = "n2";
            this.gridViewAdditionalsTxtAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridViewAdditionalsTxtAmt.Mask.EditMask = "n2";
            this.gridViewAdditionalsTxtAmt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.gridViewAdditionalsTxtAmt.Mask.UseMaskAsDisplayFormat = true;
            this.gridViewAdditionalsTxtAmt.Name = "gridViewAdditionalsTxtAmt";
            // 
            // colUpdatedAmt
            // 
            this.colUpdatedAmt.FieldName = "UpdatedAmt";
            this.colUpdatedAmt.Name = "colUpdatedAmt";
            // 
            // colRecordType
            // 
            this.colRecordType.FieldName = "RecordType";
            this.colRecordType.Name = "colRecordType";
            // 
            // colDeleteRowAdditional
            // 
            this.colDeleteRowAdditional.ColumnEdit = this.repositoryItembtnDeleteRowAdditional;
            this.colDeleteRowAdditional.MaxWidth = 20;
            this.colDeleteRowAdditional.Name = "colDeleteRowAdditional";
            this.colDeleteRowAdditional.OptionsColumn.TabStop = false;
            this.colDeleteRowAdditional.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colDeleteRowAdditional.Visible = true;
            this.colDeleteRowAdditional.VisibleIndex = 4;
            this.colDeleteRowAdditional.Width = 20;
            // 
            // repositoryItembtnDeleteRowAdditional
            // 
            this.repositoryItembtnDeleteRowAdditional.AutoHeight = false;
            this.repositoryItembtnDeleteRowAdditional.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)});
            this.repositoryItembtnDeleteRowAdditional.Name = "repositoryItembtnDeleteRowAdditional";
            this.repositoryItembtnDeleteRowAdditional.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItembtnDeleteRowAdditional_ButtonClick);
            // 
            // lookUpPriceList
            // 
            this.lookUpPriceList.EnterMoveNextControl = true;
            this.lookUpPriceList.Location = new System.Drawing.Point(952, 49);
            this.lookUpPriceList.MaximumSize = new System.Drawing.Size(200, 0);
            this.lookUpPriceList.MenuManager = this.barManager1;
            this.lookUpPriceList.MinimumSize = new System.Drawing.Size(150, 0);
            this.lookUpPriceList.Name = "lookUpPriceList";
            this.lookUpPriceList.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lookUpPriceList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.lookUpPriceList.Properties.NullText = "Select";
            this.lookUpPriceList.Size = new System.Drawing.Size(200, 22);
            this.lookUpPriceList.StyleController = this.layoutControlMain;
            this.lookUpPriceList.TabIndex = 18;
            this.lookUpPriceList.TabStop = false;
            // 
            // gridControlProductDetail
            // 
            this.gridControlProductDetail.DataSource = this.SaleOrderProductDetailViewModelBindingSource;
            this.gridControlProductDetail.Location = new System.Drawing.Point(12, 81);
            this.gridControlProductDetail.MainView = this.gridViewProductDetail;
            this.gridControlProductDetail.MenuManager = this.barManager1;
            this.gridControlProductDetail.MinimumSize = new System.Drawing.Size(0, 150);
            this.gridControlProductDetail.Name = "gridControlProductDetail";
            this.gridControlProductDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridViewProductDetailtxtPCode,
            this.gridViewProductDetailtxtBarcode,
            this.gridViewProductDetailtxtProductName,
            this.gridViewProductDetailtxtQuan,
            this.gridViewProductDetailPerc,
            this.gridViewProductDetaitxtAmt,
            this.gridViewProductDetailProdDescr,
            this.gridViewProductDetailLookUpProduct,
            this.gridviewProductDetailLookupUnitName,
            this.gridViewProductDetaiLookUpTax1,
            this.gridViewProductDetaiLookUpTax2,
            this.gridViewProductDetaiLookUpTax3,
            this.repositoryItembtnDeleteRowPDetail});
            this.gridControlProductDetail.ShowOnlyPredefinedDetails = true;
            this.gridControlProductDetail.Size = new System.Drawing.Size(1156, 325);
            this.gridControlProductDetail.TabIndex = 30;
            this.gridControlProductDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProductDetail});
            this.gridControlProductDetail.Validating += new System.ComponentModel.CancelEventHandler(this.gridControlProductDetail_Validating);
            // 
            // SaleOrderProductDetailViewModelBindingSource
            // 
            this.SaleOrderProductDetailViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.ERP.Transaction.Sales.SaleOrder.SaleOrderProductDetailViewModel);
            // 
            // gridViewProductDetail
            // 
            this.gridViewProductDetail.ActiveFilterEnabled = false;
            this.gridViewProductDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductNo,
            this.colBarcode,
            this.colProductName,
            this.colProductDescr,
            this.colQuantity,
            this.colRate,
            this.colUnitName,
            this.colGAmt,
            this.colDiscPerc,
            this.colDiscAmt,
            this.colTax1,
            this.colTax2,
            this.colTax3,
            this.colNetAmt,
            this.colDeletRow});
            this.gridViewProductDetail.GridControl = this.gridControlProductDetail;
            this.gridViewProductDetail.Name = "gridViewProductDetail";
            this.gridViewProductDetail.NewItemRowText = "New";
            this.gridViewProductDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewProductDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewProductDetail.OptionsCustomization.AllowFilter = false;
            this.gridViewProductDetail.OptionsCustomization.AllowGroup = false;
            this.gridViewProductDetail.OptionsCustomization.AllowSort = false;
            this.gridViewProductDetail.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewProductDetail.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewProductDetail.OptionsNavigation.UseTabKey = false;
            this.gridViewProductDetail.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridViewProductDetail.OptionsSelection.UseIndicatorForSelection = false;
            this.gridViewProductDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewProductDetail.OptionsView.ShowFooter = true;
            this.gridViewProductDetail.OptionsView.ShowGroupPanel = false;
            this.gridViewProductDetail.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridViewProductDetail_PopupMenuShowing);
            this.gridViewProductDetail.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewProductDetail_InitNewRow);
            this.gridViewProductDetail.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewProductDetail_FocusedRowChanged);
            this.gridViewProductDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewProductDetail_CellValueChanged);
            this.gridViewProductDetail.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridViewProductDetail_BeforeLeaveRow);
            this.gridViewProductDetail.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridViewProductDetail_ValidateRow);
            // 
            // colProductNo
            // 
            this.colProductNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colProductNo.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colProductNo.ColumnEdit = this.gridViewProductDetailtxtPCode;
            this.colProductNo.FieldName = "PCode";
            this.colProductNo.MaxWidth = 100;
            this.colProductNo.MinWidth = 55;
            this.colProductNo.Name = "colProductNo";
            this.colProductNo.Visible = true;
            this.colProductNo.VisibleIndex = 0;
            this.colProductNo.Width = 96;
            // 
            // gridViewProductDetailtxtPCode
            // 
            this.gridViewProductDetailtxtPCode.AutoHeight = false;
            this.gridViewProductDetailtxtPCode.Mask.EditMask = "#########0";
            this.gridViewProductDetailtxtPCode.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.gridViewProductDetailtxtPCode.Name = "gridViewProductDetailtxtPCode";
            // 
            // colBarcode
            // 
            this.colBarcode.AppearanceHeader.Options.UseTextOptions = true;
            this.colBarcode.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.MaxWidth = 100;
            this.colBarcode.MinWidth = 60;
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 1;
            this.colBarcode.Width = 96;
            // 
            // colProductName
            // 
            this.colProductName.AppearanceHeader.Options.UseTextOptions = true;
            this.colProductName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colProductName.ColumnEdit = this.gridViewProductDetailLookUpProduct;
            this.colProductName.FieldName = "ProductName";
            this.colProductName.MaxWidth = 1000;
            this.colProductName.MinWidth = 100;
            this.colProductName.Name = "colProductName";
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 2;
            this.colProductName.Width = 189;
            // 
            // gridViewProductDetailLookUpProduct
            // 
            this.gridViewProductDetailLookUpProduct.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridViewProductDetailLookUpProduct.DataSource = this.ProductSelectionViewModelBindingSource;
            this.gridViewProductDetailLookUpProduct.Name = "gridViewProductDetailLookUpProduct";
            this.gridViewProductDetailLookUpProduct.NullText = "";
            this.gridViewProductDetailLookUpProduct.PopupWidth = 600;
            this.gridViewProductDetailLookUpProduct.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // ProductSelectionViewModelBindingSource
            // 
            this.ProductSelectionViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Inventory.Masters.StockItem.StockItemLookupListModel);
            // 
            // colProductDescr
            // 
            this.colProductDescr.AppearanceHeader.Options.UseTextOptions = true;
            this.colProductDescr.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colProductDescr.ColumnEdit = this.gridViewProductDetailProdDescr;
            this.colProductDescr.FieldName = "ProductDescr";
            this.colProductDescr.MaxWidth = 1000;
            this.colProductDescr.MinWidth = 80;
            this.colProductDescr.Name = "colProductDescr";
            this.colProductDescr.Visible = true;
            this.colProductDescr.VisibleIndex = 3;
            this.colProductDescr.Width = 104;
            // 
            // gridViewProductDetailProdDescr
            // 
            this.gridViewProductDetailProdDescr.AutoHeight = false;
            this.gridViewProductDetailProdDescr.MaxLength = 100;
            this.gridViewProductDetailProdDescr.Name = "gridViewProductDetailProdDescr";
            // 
            // colQuantity
            // 
            this.colQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colQuantity.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colQuantity.Caption = "Qty";
            this.colQuantity.ColumnEdit = this.gridViewProductDetailtxtQuan;
            this.colQuantity.DisplayFormat.FormatString = "n2";
            this.colQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MaxWidth = 100;
            this.colQuantity.MinWidth = 55;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.TabStop = false;
            this.colQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:n2}")});
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 4;
            this.colQuantity.Width = 96;
            // 
            // gridViewProductDetailtxtQuan
            // 
            this.gridViewProductDetailtxtQuan.AutoHeight = false;
            this.gridViewProductDetailtxtQuan.Mask.EditMask = "n2";
            this.gridViewProductDetailtxtQuan.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.gridViewProductDetailtxtQuan.Mask.UseMaskAsDisplayFormat = true;
            this.gridViewProductDetailtxtQuan.MaxLength = 12;
            this.gridViewProductDetailtxtQuan.Name = "gridViewProductDetailtxtQuan";
            // 
            // colRate
            // 
            this.colRate.AppearanceHeader.Options.UseTextOptions = true;
            this.colRate.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colRate.ColumnEdit = this.gridViewProductDetailtxtQuan;
            this.colRate.DisplayFormat.FormatString = "#############0.00";
            this.colRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRate.FieldName = "Rate";
            this.colRate.MaxWidth = 100;
            this.colRate.MinWidth = 55;
            this.colRate.Name = "colRate";
            this.colRate.Visible = true;
            this.colRate.VisibleIndex = 5;
            this.colRate.Width = 72;
            // 
            // colUnitName
            // 
            this.colUnitName.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnitName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colUnitName.Caption = "Unit";
            this.colUnitName.ColumnEdit = this.gridviewProductDetailLookupUnitName;
            this.colUnitName.FieldName = "UnitID";
            this.colUnitName.MaxWidth = 500;
            this.colUnitName.MinWidth = 55;
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.Visible = true;
            this.colUnitName.VisibleIndex = 6;
            this.colUnitName.Width = 72;
            // 
            // gridviewProductDetailLookupUnitName
            // 
            this.gridviewProductDetailLookupUnitName.AutoHeight = false;
            this.gridviewProductDetailLookupUnitName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridviewProductDetailLookupUnitName.Name = "gridviewProductDetailLookupUnitName";
            this.gridviewProductDetailLookupUnitName.NullText = "Unit";
            // 
            // colGAmt
            // 
            this.colGAmt.AppearanceHeader.Options.UseTextOptions = true;
            this.colGAmt.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colGAmt.ColumnEdit = this.gridViewProductDetaitxtAmt;
            this.colGAmt.DisplayFormat.FormatString = "#############0.00";
            this.colGAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGAmt.FieldName = "GAmt";
            this.colGAmt.MaxWidth = 100;
            this.colGAmt.Name = "colGAmt";
            this.colGAmt.OptionsColumn.ReadOnly = true;
            this.colGAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GAmt", "{0:0.00}")});
            this.colGAmt.Width = 61;
            // 
            // gridViewProductDetaitxtAmt
            // 
            this.gridViewProductDetaitxtAmt.AutoHeight = false;
            this.gridViewProductDetaitxtAmt.Mask.EditMask = "n2";
            this.gridViewProductDetaitxtAmt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.gridViewProductDetaitxtAmt.Mask.UseMaskAsDisplayFormat = true;
            this.gridViewProductDetaitxtAmt.MaxLength = 10;
            this.gridViewProductDetaitxtAmt.Name = "gridViewProductDetaitxtAmt";
            // 
            // colDiscPerc
            // 
            this.colDiscPerc.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiscPerc.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colDiscPerc.ColumnEdit = this.gridViewProductDetailPerc;
            this.colDiscPerc.DisplayFormat.FormatString = "##0.00";
            this.colDiscPerc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiscPerc.FieldName = "DiscPerc";
            this.colDiscPerc.MaxWidth = 100;
            this.colDiscPerc.MinWidth = 55;
            this.colDiscPerc.Name = "colDiscPerc";
            this.colDiscPerc.Visible = true;
            this.colDiscPerc.VisibleIndex = 7;
            this.colDiscPerc.Width = 58;
            // 
            // gridViewProductDetailPerc
            // 
            this.gridViewProductDetailPerc.AutoHeight = false;
            this.gridViewProductDetailPerc.Mask.BeepOnError = true;
            this.gridViewProductDetailPerc.Mask.EditMask = "p";
            this.gridViewProductDetailPerc.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.gridViewProductDetailPerc.Mask.UseMaskAsDisplayFormat = true;
            this.gridViewProductDetailPerc.MaxLength = 10;
            this.gridViewProductDetailPerc.Name = "gridViewProductDetailPerc";
            // 
            // colDiscAmt
            // 
            this.colDiscAmt.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiscAmt.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colDiscAmt.ColumnEdit = this.gridViewProductDetaitxtAmt;
            this.colDiscAmt.DisplayFormat.FormatString = "#############0.00";
            this.colDiscAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiscAmt.FieldName = "DiscAmt";
            this.colDiscAmt.MaxWidth = 100;
            this.colDiscAmt.Name = "colDiscAmt";
            this.colDiscAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DiscAmt", "{0:n2}")});
            this.colDiscAmt.Width = 52;
            // 
            // colTax1
            // 
            this.colTax1.Caption = "Tax 1";
            this.colTax1.ColumnEdit = this.gridViewProductDetaiLookUpTax1;
            this.colTax1.FieldName = "Tax1ID";
            this.colTax1.MaxWidth = 100;
            this.colTax1.MinWidth = 55;
            this.colTax1.Name = "colTax1";
            this.colTax1.Visible = true;
            this.colTax1.VisibleIndex = 8;
            this.colTax1.Width = 68;
            // 
            // gridViewProductDetaiLookUpTax1
            // 
            this.gridViewProductDetaiLookUpTax1.AutoHeight = false;
            this.gridViewProductDetaiLookUpTax1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridViewProductDetaiLookUpTax1.Name = "gridViewProductDetaiLookUpTax1";
            this.gridViewProductDetaiLookUpTax1.NullText = "None";
            // 
            // colTax2
            // 
            this.colTax2.Caption = "Tax 2";
            this.colTax2.ColumnEdit = this.gridViewProductDetaiLookUpTax2;
            this.colTax2.FieldName = "Tax2ID";
            this.colTax2.MaxWidth = 100;
            this.colTax2.MinWidth = 55;
            this.colTax2.Name = "colTax2";
            this.colTax2.Visible = true;
            this.colTax2.VisibleIndex = 9;
            this.colTax2.Width = 68;
            // 
            // gridViewProductDetaiLookUpTax2
            // 
            this.gridViewProductDetaiLookUpTax2.AutoHeight = false;
            this.gridViewProductDetaiLookUpTax2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridViewProductDetaiLookUpTax2.Name = "gridViewProductDetaiLookUpTax2";
            this.gridViewProductDetaiLookUpTax2.NullText = "None";
            // 
            // colTax3
            // 
            this.colTax3.Caption = "Tax 3";
            this.colTax3.ColumnEdit = this.gridViewProductDetaiLookUpTax3;
            this.colTax3.FieldName = "Tax3ID";
            this.colTax3.MaxWidth = 100;
            this.colTax3.MinWidth = 55;
            this.colTax3.Name = "colTax3";
            this.colTax3.Visible = true;
            this.colTax3.VisibleIndex = 10;
            this.colTax3.Width = 92;
            // 
            // gridViewProductDetaiLookUpTax3
            // 
            this.gridViewProductDetaiLookUpTax3.AutoHeight = false;
            this.gridViewProductDetaiLookUpTax3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridViewProductDetaiLookUpTax3.Name = "gridViewProductDetaiLookUpTax3";
            this.gridViewProductDetaiLookUpTax3.NullText = "None";
            // 
            // colNetAmt
            // 
            this.colNetAmt.AppearanceHeader.Options.UseTextOptions = true;
            this.colNetAmt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNetAmt.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colNetAmt.DisplayFormat.FormatString = "n2";
            this.colNetAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNetAmt.FieldName = "NetAmt";
            this.colNetAmt.MaxWidth = 100;
            this.colNetAmt.MinWidth = 75;
            this.colNetAmt.Name = "colNetAmt";
            this.colNetAmt.OptionsColumn.AllowEdit = false;
            this.colNetAmt.OptionsColumn.AllowFocus = false;
            this.colNetAmt.OptionsColumn.ReadOnly = true;
            this.colNetAmt.OptionsColumn.TabStop = false;
            this.colNetAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetAmt", "{0:n2}")});
            this.colNetAmt.Visible = true;
            this.colNetAmt.VisibleIndex = 11;
            this.colNetAmt.Width = 100;
            // 
            // colDeletRow
            // 
            this.colDeletRow.ColumnEdit = this.repositoryItembtnDeleteRowPDetail;
            this.colDeletRow.MaxWidth = 20;
            this.colDeletRow.Name = "colDeletRow";
            this.colDeletRow.OptionsColumn.TabStop = false;
            this.colDeletRow.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colDeletRow.Visible = true;
            this.colDeletRow.VisibleIndex = 12;
            this.colDeletRow.Width = 20;
            // 
            // repositoryItembtnDeleteRowPDetail
            // 
            this.repositoryItembtnDeleteRowPDetail.AutoHeight = false;
            this.repositoryItembtnDeleteRowPDetail.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)});
            this.repositoryItembtnDeleteRowPDetail.Name = "repositoryItembtnDeleteRowPDetail";
            this.repositoryItembtnDeleteRowPDetail.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItembtnDeleteRowPDetail_ButtonClick);
            // 
            // gridViewProductDetailtxtBarcode
            // 
            this.gridViewProductDetailtxtBarcode.MaxLength = 1000;
            this.gridViewProductDetailtxtBarcode.Name = "gridViewProductDetailtxtBarcode";
            // 
            // gridViewProductDetailtxtProductName
            // 
            this.gridViewProductDetailtxtProductName.AutoHeight = false;
            this.gridViewProductDetailtxtProductName.MaxLength = 50;
            this.gridViewProductDetailtxtProductName.Name = "gridViewProductDetailtxtProductName";
            // 
            // txtSaleOrderNo
            // 
            this.txtSaleOrderNo.EditValue = 0;
            this.txtSaleOrderNo.EnterMoveNextControl = true;
            this.txtSaleOrderNo.Location = new System.Drawing.Point(589, 11);
            this.txtSaleOrderNo.MaximumSize = new System.Drawing.Size(100, 0);
            this.txtSaleOrderNo.MenuManager = this.barManager1;
            this.txtSaleOrderNo.MinimumSize = new System.Drawing.Size(50, 0);
            this.txtSaleOrderNo.Name = "txtSaleOrderNo";
            this.txtSaleOrderNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSaleOrderNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtSaleOrderNo.Properties.Mask.EditMask = "n0";
            this.txtSaleOrderNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSaleOrderNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtSaleOrderNo.Size = new System.Drawing.Size(100, 22);
            this.txtSaleOrderNo.StyleController = this.layoutControlMain;
            this.txtSaleOrderNo.TabIndex = 14;
            this.txtSaleOrderNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtSaleOrderNo_Validating);
            // 
            // deInvoiceDate
            // 
            this.deInvoiceDate.EditValue = null;
            this.deInvoiceDate.EnterMoveNextControl = true;
            this.deInvoiceDate.Location = new System.Drawing.Point(50, 11);
            this.deInvoiceDate.MaximumSize = new System.Drawing.Size(150, 0);
            this.deInvoiceDate.MenuManager = this.barManager1;
            this.deInvoiceDate.MinimumSize = new System.Drawing.Size(50, 0);
            this.deInvoiceDate.Name = "deInvoiceDate";
            this.deInvoiceDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deInvoiceDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deInvoiceDate.Size = new System.Drawing.Size(150, 22);
            this.deInvoiceDate.StyleController = this.layoutControlMain;
            this.deInvoiceDate.TabIndex = 12;
            this.deInvoiceDate.TabStop = false;
            this.deInvoiceDate.EditValueChanged += new System.EventHandler(this.deInvoiceDate_EditValueChanged);
            this.deInvoiceDate.Validating += new System.ComponentModel.CancelEventHandler(this.deInvoiceDate_Validating);
            // 
            // lookUpInvPrefix
            // 
            this.lookUpInvPrefix.EnterMoveNextControl = true;
            this.lookUpInvPrefix.Location = new System.Drawing.Point(242, 11);
            this.lookUpInvPrefix.MaximumSize = new System.Drawing.Size(500, 0);
            this.lookUpInvPrefix.MenuManager = this.barManager1;
            this.lookUpInvPrefix.MinimumSize = new System.Drawing.Size(50, 0);
            this.lookUpInvPrefix.Name = "lookUpInvPrefix";
            this.lookUpInvPrefix.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.lookUpInvPrefix.Properties.MaxLength = 10;
            this.lookUpInvPrefix.Properties.NullText = "";
            this.lookUpInvPrefix.Size = new System.Drawing.Size(265, 22);
            this.lookUpInvPrefix.StyleController = this.layoutControlMain;
            this.lookUpInvPrefix.TabIndex = 13;
            this.lookUpInvPrefix.EditValueChanged += new System.EventHandler(this.lookUpInvPrefix_EditValueChanged);
            this.lookUpInvPrefix.Validating += new System.ComponentModel.CancelEventHandler(this.lookUpInvPrefix_Validating);
            // 
            // lcgMain
            // 
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem23,
            this.lcgFooter,
            this.lcgInvoiceNo,
            this.lcgPriceList,
            this.lcgCustomer,
            this.emptySpaceItem4});
            this.lcgMain.Name = "lcgMain";
            this.lcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 3, 3);
            this.lcgMain.Size = new System.Drawing.Size(1180, 620);
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.gridControlProductDetail;
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 76);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(1160, 329);
            this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem23.TextVisible = false;
            // 
            // lcgFooter
            // 
            this.lcgFooter.GroupBordersVisible = false;
            this.lcgFooter.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgAddLess,
            this.lcgMemoAndSMS,
            this.lblFooterSeparator});
            this.lcgFooter.Location = new System.Drawing.Point(0, 405);
            this.lcgFooter.Name = "lcgFooter";
            this.lcgFooter.Size = new System.Drawing.Size(1160, 209);
            this.lcgFooter.TextVisible = false;
            // 
            // lcgAddLess
            // 
            this.lcgAddLess.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem24,
            this.lcgNetAmt});
            this.lcgAddLess.Location = new System.Drawing.Point(600, 0);
            this.lcgAddLess.Name = "lcgAddLess";
            this.lcgAddLess.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lcgAddLess.Size = new System.Drawing.Size(560, 209);
            this.lcgAddLess.Text = "Additional Items (Tax/Discount)";
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.gridControlAdditionals;
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(548, 150);
            this.layoutControlItem24.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem24.TextVisible = false;
            // 
            // lcgNetAmt
            // 
            this.lcgNetAmt.GroupBordersVisible = false;
            this.lcgNetAmt.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem26,
            this.emptySpaceItem2,
            this.lciRoundOff});
            this.lcgNetAmt.Location = new System.Drawing.Point(0, 150);
            this.lcgNetAmt.Name = "lcgNetAmt";
            this.lcgNetAmt.Size = new System.Drawing.Size(548, 26);
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.txtNetAmt;
            this.layoutControlItem26.Location = new System.Drawing.Point(391, 0);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(157, 26);
            this.layoutControlItem26.Text = "Net Amt";
            this.layoutControlItem26.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem26.TextSize = new System.Drawing.Size(48, 16);
            this.layoutControlItem26.TextToControlDistance = 5;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(226, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciRoundOff
            // 
            this.lciRoundOff.Control = this.txtRoundOff;
            this.lciRoundOff.Location = new System.Drawing.Point(226, 0);
            this.lciRoundOff.Name = "lciRoundOff";
            this.lciRoundOff.Size = new System.Drawing.Size(165, 26);
            this.lciRoundOff.Text = "Round Off";
            this.lciRoundOff.TextSize = new System.Drawing.Size(58, 16);
            // 
            // lcgMemoAndSMS
            // 
            this.lcgMemoAndSMS.GroupBordersVisible = false;
            this.lcgMemoAndSMS.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgSMS,
            this.lcgMemo});
            this.lcgMemoAndSMS.Location = new System.Drawing.Point(0, 1);
            this.lcgMemoAndSMS.Name = "lcgMemoAndSMS";
            this.lcgMemoAndSMS.Size = new System.Drawing.Size(600, 208);
            // 
            // lcgSMS
            // 
            this.lcgSMS.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem25,
            this.layoutControlItem29,
            this.layoutControlItem3,
            this.layoutControlItem30});
            this.lcgSMS.Location = new System.Drawing.Point(299, 0);
            this.lcgSMS.Name = "lcgSMS";
            this.lcgSMS.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgSMS.Size = new System.Drawing.Size(301, 208);
            this.lcgSMS.Text = "SMS";
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.memoSMS;
            this.layoutControlItem25.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(295, 129);
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.txtSMSSenderID;
            this.layoutControlItem29.Location = new System.Drawing.Point(91, 0);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(204, 26);
            this.layoutControlItem29.Text = "Sender ID";
            this.layoutControlItem29.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem29.TextSize = new System.Drawing.Size(57, 16);
            this.layoutControlItem29.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chkbSendSMS;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(91, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.txtSMSMobileNos;
            this.layoutControlItem30.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(295, 26);
            this.layoutControlItem30.Text = "Mobile Nos";
            this.layoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(65, 16);
            this.layoutControlItem30.TextToControlDistance = 5;
            // 
            // lcgMemo
            // 
            this.lcgMemo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem27});
            this.lcgMemo.Location = new System.Drawing.Point(0, 0);
            this.lcgMemo.Name = "lcgMemo";
            this.lcgMemo.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lcgMemo.Size = new System.Drawing.Size(299, 208);
            this.lcgMemo.Text = "Memo";
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.txtMemo;
            this.layoutControlItem27.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem27.MinSize = new System.Drawing.Size(14, 20);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(287, 175);
            this.layoutControlItem27.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem27.Text = "Memo";
            this.layoutControlItem27.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem27.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextToControlDistance = 0;
            this.layoutControlItem27.TextVisible = false;
            // 
            // lblFooterSeparator
            // 
            this.lblFooterSeparator.AllowHotTrack = false;
            this.lblFooterSeparator.Location = new System.Drawing.Point(0, 0);
            this.lblFooterSeparator.MaxSize = new System.Drawing.Size(0, 1);
            this.lblFooterSeparator.MinSize = new System.Drawing.Size(7, 1);
            this.lblFooterSeparator.Name = "lblFooterSeparator";
            this.lblFooterSeparator.Size = new System.Drawing.Size(600, 1);
            this.lblFooterSeparator.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lblFooterSeparator.Text = " ";
            this.lblFooterSeparator.TextSize = new System.Drawing.Size(58, 16);
            // 
            // lcgInvoiceNo
            // 
            this.lcgInvoiceNo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciSaleOrderNo,
            this.lciSaleOrderNoPrefix,
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.lcgInvoiceNo.Location = new System.Drawing.Point(0, 0);
            this.lcgInvoiceNo.Name = "lcgInvoiceNo";
            this.lcgInvoiceNo.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lcgInvoiceNo.Size = new System.Drawing.Size(1160, 38);
            this.lcgInvoiceNo.Text = "Order No";
            this.lcgInvoiceNo.TextVisible = false;
            // 
            // lciSaleOrderNo
            // 
            this.lciSaleOrderNo.Control = this.txtSaleOrderNo;
            this.lciSaleOrderNo.Location = new System.Drawing.Point(493, 0);
            this.lciSaleOrderNo.Name = "lciSaleOrderNo";
            this.lciSaleOrderNo.Size = new System.Drawing.Size(182, 26);
            this.lciSaleOrderNo.Text = "Sale Order #";
            this.lciSaleOrderNo.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciSaleOrderNo.TextSize = new System.Drawing.Size(73, 16);
            this.lciSaleOrderNo.TextToControlDistance = 5;
            // 
            // lciSaleOrderNoPrefix
            // 
            this.lciSaleOrderNoPrefix.Control = this.lookUpInvPrefix;
            this.lciSaleOrderNoPrefix.Location = new System.Drawing.Point(186, 0);
            this.lciSaleOrderNoPrefix.Name = "lciSaleOrderNoPrefix";
            this.lciSaleOrderNoPrefix.Size = new System.Drawing.Size(307, 26);
            this.lciSaleOrderNoPrefix.Text = "Prefix";
            this.lciSaleOrderNoPrefix.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciSaleOrderNoPrefix.TextSize = new System.Drawing.Size(33, 16);
            this.lciSaleOrderNoPrefix.TextToControlDistance = 5;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deInvoiceDate;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(186, 26);
            this.layoutControlItem1.Text = "Date";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(27, 16);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(675, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(473, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgPriceList
            // 
            this.lcgPriceList.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciPriceList});
            this.lcgPriceList.Location = new System.Drawing.Point(874, 38);
            this.lcgPriceList.Name = "lcgPriceList";
            this.lcgPriceList.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lcgPriceList.Size = new System.Drawing.Size(276, 38);
            this.lcgPriceList.Text = "Price List";
            this.lcgPriceList.TextVisible = false;
            // 
            // lciPriceList
            // 
            this.lciPriceList.Control = this.lookUpPriceList;
            this.lciPriceList.Location = new System.Drawing.Point(0, 0);
            this.lciPriceList.Name = "lciPriceList";
            this.lciPriceList.Size = new System.Drawing.Size(264, 26);
            this.lciPriceList.Text = "Price List";
            this.lciPriceList.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciPriceList.TextSize = new System.Drawing.Size(55, 16);
            this.lciPriceList.TextToControlDistance = 5;
            // 
            // lcgCustomer
            // 
            this.lcgCustomer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7});
            this.lcgCustomer.Location = new System.Drawing.Point(0, 38);
            this.lcgCustomer.Name = "lcgCustomer";
            this.lcgCustomer.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgCustomer.Size = new System.Drawing.Size(874, 38);
            this.lcgCustomer.Text = "Select Customer";
            this.lcgCustomer.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.ucCustomerSelection1;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(868, 32);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(1150, 38);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(10, 38);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // customerLookUpListModelBindingSource
            // 
            this.customerLookUpListModelBindingSource.DataSource = typeof(Alit.Marker.Model.Customer.CustomerLookUpListModel);
            // 
            // popupMenuGridShortCut
            // 
            this.popupMenuGridShortCut.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnGridAddRow),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnGridDeleteRow)});
            this.popupMenuGridShortCut.Manager = this.barManager1;
            this.popupMenuGridShortCut.Name = "popupMenuGridShortCut";
            // 
            // barbtnGridAddRow
            // 
            this.barbtnGridAddRow.Caption = "Add Row";
            this.barbtnGridAddRow.Id = 16;
            this.barbtnGridAddRow.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.barbtnGridAddRow.Name = "barbtnGridAddRow";
            this.barbtnGridAddRow.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.barbtnGridAddRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnGridAddRow_ItemClick);
            // 
            // barBtnGridDeleteRow
            // 
            this.barBtnGridDeleteRow.Caption = "Delete Row";
            this.barBtnGridDeleteRow.Id = 17;
            this.barBtnGridDeleteRow.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
            this.barBtnGridDeleteRow.Name = "barBtnGridDeleteRow";
            this.barBtnGridDeleteRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnGridDeleteRow_ItemClick);
            // 
            // frmSaleOrderCRUD
            // 
            this.AllowPrint = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 684);
            this.FirstControl = this.layoutControlMain;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmSaleOrderCRUD.IconOptions.Icon")));
            this.Name = "frmSaleOrderCRUD";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.Text = "Sale Order";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBase1)).EndInit();
            this.panelBase1.ResumeLayout(false);
            this.panelBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).EndInit();
            this.layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRoundOff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkbSendSMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMSSenderID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMSMobileNos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoSMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetAmt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAdditionals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleOrderAdditionalsViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdditionals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewAddLookUpAddItemMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdditionalsCmbNature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdditionalsTxtAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItembtnDeleteRowAdditional)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpPriceList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleOrderProductDetailViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetailtxtPCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetailLookUpProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductSelectionViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetailProdDescr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetailtxtQuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewProductDetailLookupUnitName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetaitxtAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetailPerc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetaiLookUpTax1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetaiLookUpTax2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetaiLookUpTax3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItembtnDeleteRowPDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetailtxtBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductDetailtxtProductName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaleOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deInvoiceDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deInvoiceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpInvPrefix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgAddLess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgNetAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRoundOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMemoAndSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFooterSeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgInvoiceNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSaleOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSaleOrderNoPrefix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerLookUpListModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuGridShortCut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Alit.WinformControls.myLayoutControl layoutControlMain;
        private Alit.WinformControls.DateEdit deInvoiceDate;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private Alit.WinformControls.TextEdit txtSaleOrderNo;
        private System.Windows.Forms.BindingSource customerLookUpListModelBindingSource;
        private DevExpress.XtraGrid.GridControl gridControlProductDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProductDetail;
        private System.Windows.Forms.BindingSource SaleOrderProductDetailViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colProductNo;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colProductDescr;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colRate;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn colGAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscPerc;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colNetAmt;
        private Alit.Marker.WinForm.Inventory.Masters.Product.LookupEditPriceList lookUpPriceList;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridViewProductDetailtxtPCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridViewProductDetailtxtProductName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gridViewProductDetailtxtBarcode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridViewProductDetailtxtQuan;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridViewProductDetailPerc;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridViewProductDetaitxtAmt;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridViewProductDetailProdDescr;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridViewProductDetailLookUpProduct;
        private DevExpress.XtraGrid.GridControl gridControlAdditionals;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAdditionals;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private System.Windows.Forms.BindingSource SaleOrderAdditionalsViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colAdditionalsID;
        private DevExpress.XtraGrid.Columns.GridColumn colAdditionalItemID;
        private DevExpress.XtraGrid.Columns.GridColumn colItemDescr;
        private DevExpress.XtraGrid.Columns.GridColumn colItemNature;
        private DevExpress.XtraGrid.Columns.GridColumn colPerc;
        private DevExpress.XtraGrid.Columns.GridColumn colAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox gridViewAdditionalsCmbNature;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gridViewAdditionalsTxtAmt;
        private Alit.WinformControls.TextEdit txtNetAmt;
        private Alit.WinformControls.MemoEdit txtMemo;
        private System.Windows.Forms.BindingSource ProductSelectionViewModelBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem lciPriceList;
        private DevExpress.XtraLayout.LayoutControlGroup lcgPriceList;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridviewProductDetailLookupUnitName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridviewAddLookUpAddItemMaster;
        private DevExpress.XtraGrid.Columns.GridColumn colAdditionalItemName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlGroup lcgFooter;
        private DevExpress.XtraLayout.LayoutControlGroup lcgAddLess;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraBars.PopupMenu popupMenuGridShortCut;
        private DevExpress.XtraBars.BarButtonItem barbtnGridAddRow;
        private DevExpress.XtraBars.BarButtonItem barBtnGridDeleteRow;
        private DevExpress.XtraLayout.LayoutControlGroup lcgNetAmt;
        
        private DevExpress.XtraEditors.MemoEdit memoSMS;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlGroup lcgSMS;
        private DevExpress.XtraEditors.TextEdit txtSMSSenderID;
        private DevExpress.XtraEditors.TextEdit txtSMSMobileNos;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraEditors.CheckEdit chkbSendSMS;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;

        private DevExpress.XtraGrid.Columns.GridColumn colTax1;
        private DevExpress.XtraGrid.Columns.GridColumn colTax2;
        private DevExpress.XtraGrid.Columns.GridColumn colTax3;

        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridViewProductDetaiLookUpTax1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridViewProductDetaiLookUpTax2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridViewProductDetaiLookUpTax3;
        private DevExpress.XtraLayout.LayoutControlGroup lcgCustomer;
        private DevExpress.XtraLayout.LayoutControlGroup lcgInvoiceNo;
        private DevExpress.XtraLayout.LayoutControlItem lciSaleOrderNo;
        private DevExpress.XtraLayout.LayoutControlItem lciSaleOrderNoPrefix;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMemoAndSMS;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMemo;
        private DevExpress.XtraLayout.SimpleLabelItem lblFooterSeparator;
        private WinformControls.TextEdit txtRoundOff;
        private DevExpress.XtraLayout.LayoutControlItem lciRoundOff;
        private Customer.ucCustomerSelectionOld ucCustomerSelection1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;

        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletRow;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItembtnDeleteRowPDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colDeleteRowAdditional;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItembtnDeleteRowAdditional;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private WinformControls.LookUpEdit lookUpInvPrefix;
    }
}