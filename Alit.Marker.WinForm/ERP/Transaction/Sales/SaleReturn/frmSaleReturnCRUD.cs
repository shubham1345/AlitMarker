using Alit.Marker.DAL;
using Alit.Marker.Model;
using Alit.Marker.Model.Customer;
using Alit.Marker.Model.TransactionsCommon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alit.Marker.Model.Template;
using Alit.Marker.DAL.Template;
using DevExpress.XtraReports.UI;
using Alit.Marker.DAL.Inventory.Masters.Product;
using Alit.Marker.Model.Inventory.Masters.Product;
using Alit.Marker.Model.Inventory.Masters.Unit;
using Alit.Marker.DAL.Inventory.Masters.Unit;
using Alit.Marker.Model.Inventory.Masters.StockItem;
using Alit.Marker.Model.Inventory.Masters.StockItemTaxCategory;
using Alit.Marker.DAL.Inventory.Masters.StockItemTaxCategory;
using Alit.Marker.Model.ERP.Masters.AdditionalItems;
using Alit.Marker.DAL.ERP.Masters.AdditionalItems;
using Alit.Marker.Model.ERP.Transaction.Sales.SaleReturn;
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleReturn;
using Alit.Marker.Model.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix;
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.Model.Account.VoucherType;
using Alit.Marker.Model.Account.Group;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleReturn
{
    public partial class frmSaleReturnCRUD : Template.frmCRUDTemplate
    {
        #region Property
        public decimal GrossAmt
        {
            get
            {
                return (colNetAmt.SummaryItem.SummaryValue == null ? 0 : (decimal)colNetAmt.SummaryItem.SummaryValue);
            }
        }

        public decimal RoundOffAmt
        {
            get
            {
                decimal amt = 0;
                decimal.TryParse(txtRoundOff.Text, out amt);
                return amt;
            }
            set
            {
                txtRoundOff.Text = value.ToString();
            }
        }

        public decimal NetAmt
        {
            get
            {
                decimal namt = 0;
                decimal.TryParse(txtNetAmt.Text, out namt);
                return namt;
            }
            set
            {
                txtNetAmt.Text = value.ToString();
            }
        }

        public decimal AdvanceAmt
        {
            get
            {
                decimal v = 0;
                decimal.TryParse(txtAdvanceAmt.Text, out v);
                return v;
            }
            set
            {
                txtAdvanceAmt.Text = value.ToString();
            }
        }

        public long AdvanceOldRecieptID { get; set; }
        public decimal AdvanceOldAmt { get; set; }

        public bool IsProductRecordGAmtChanged;

        DateTime? OldInvalidDate;
        long? OldSaleReturnNoPrefixID;

        public long? DefaultUnitID;

        public bool ProductTaxCat1_IsInterstateSale;
        public bool ProductTaxCat2_IsInterstateSale;
        public bool ProductTaxCat3_IsInterstateSale;

        #endregion

        SaleReturnDAL DALObject;

        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new SaleReturnDAL();
                }
                return DALObject;
            }
        }

        List<SaleReturnNoPrefixLookupListModel> PrefixListDS;

        DAL.Inventory.Masters.StockItem.StockItemDAL StockItemDAL;
        List<StockItemLookupListModel> ProductLookUpListDataSource;
        StockItemLookupListModel NewProduct;

        AdditionalItemDAL AdditionalItemsDAL;
        List<AdditionalItemLookupModel> AdditionalItemLookUpListDataSource;

        UnitDAL UnitDAL;
        PriceListDAL PriceListDAL;

        StockItemTaxCategoryDAL ProductTaxCategoryDALObj;
        SaleReturnNoPrefixDAL SaleReturnNoPrefixDAL;

        List<PriceListLookupListModel> PriceListDS;
        List<AdditionalItemLookupModel> TaxItemsDS;
        IEnumerable<UnitLookupListModel> UnitDS;

        List<VoucherTypeLookUpListModel> dsVoucherType;
        List<BookAccountLookUpListModel> dsSaleAccount;

        long AccountVoucherID;

        public frmSaleReturnCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmSaleReturnCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();

            // Initialize DAL objects
            DALObject = new SaleReturnDAL();
            SaleReturnNoPrefixDAL = new SaleReturnNoPrefixDAL();
            StockItemDAL = new DAL.Inventory.Masters.StockItem.StockItemDAL();
            PriceListDAL = new DAL.Inventory.Masters.Product.PriceListDAL();
            AdditionalItemsDAL = new AdditionalItemDAL();
            UnitDAL = new DAL.Inventory.Masters.Unit.UnitDAL();
            ProductTaxCategoryDALObj = new StockItemTaxCategoryDAL();

            //

            // Applying setting for Memo type
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceMemoTypeApplies != Model.Settings.ApplicationSettings.eSaleInvoiceMemoTypeApplies.CashCreditBoth)
            {
                lciMemoType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                FirstControl = deInvoiceDate;
            }
            else
            {
                FirstControl = cmbMemoType;
            }

            // Apply settings for Invoice Number and prefix
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNo)
            {
                if (!Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoPrefix)
                {
                    lciInvoiceNoPrefix.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                if (!Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoAllowEdit)
                {
                    txtInvoiceNo.Enabled = false;
                }
            }
            else
            {
                lciInvoiceNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciInvoiceNoPrefix.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            // Applying Setting for Customer
            if (!Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAskCustomer)
            {
                lcgCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }


            // Applying Settings for Product selection and Product details

            if (!Model.CommonProperties.LoginInfo.SoftwareSettings.MaintainProducts)
            {
                colProductNo.Visible = false;
                colBarcode.Visible = false;
                colProductName.Visible = false;
            }
            else
            {
                colProductNo.Visible = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceProductSelectionByProductCode;
                colBarcode.Visible = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceProductSelectionByBarcode;
                colProductName.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceProductSelectionByProductName;

                if (Model.CommonProperties.LoginInfo.SoftwareSettings.MaintainProducts &&
                    !Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceProductSelectionByProductCode &&
                    !Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceProductSelectionByBarcode)
                {
                    colProductName.Visible = true;
                }
            }

            colProductDescr.Visible = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditProductDescr;

            colQuantity.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnQuan;

            colRate.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnRate;
            colRate.OptionsColumn.AllowFocus = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditRate;
            colRate.OptionsColumn.ReadOnly = !Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditRate;

            colUnitName.Visible = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAddUnitColumn;
            colUnitName.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnUnit;

            colDiscPerc.Visible = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAddDiscountColumn;
            colDiscPerc.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnDisc;

            // adding events for Product and additional for list change to add some events in each records to control some functions
            saleReturnProductDetailViewModelBindingSource.ListChanged += saleInvoiceProductDetailViewModelBindingSource_ListChanged;
            saleReturnAdditionalsViewModelBindingSource.ListChanged += saleInvoiceAdditionalsViewModelBindingSource_ListChanged;

            //--
            gridViewProductDetailLookUpProduct.ProcessNewValue += gridViewProductDetailLookUpProduct_ProcessNewValue;

            //--
            if (CommonProperties.LoginInfo.SoftwareSettings.SMSActivated && CommonProperties.LoginInfo.SoftwareSettings.SMSSendInSaleReturn)
            {
                lcgSMS.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                chkbSendSMS.Checked = false;
                txtSMSMobileNos.DataBindings.Add("Enabled", chkbSendSMS, "Checked");
                txtSMSSenderID.DataBindings.Add("Enabled", chkbSendSMS, "Checked");
                memoSMS.DataBindings.Add("Enabled", chkbSendSMS, "Checked");
            }
            else
            {
                lcgSMS.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //--
            if (CommonProperties.LoginInfo.SoftwareSettings.SMSActivated &&
                CommonProperties.LoginInfo.SoftwareSettings.SMSSendInSaleReturn)
            {
                txtSMSSenderID.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSSaleReturnSenderID;
                memoSMS.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSSaleReturnTemplate;
            }

            if (CommonProperties.LoginInfo.SoftwareSettings.ApplyRoundOff)
            {
                lciRoundOff.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lciRoundOff.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        #region Template Methods

        protected override void OnShown(EventArgs e)
        {
            //SetFocusOnFirstControl();
            base.OnShown(e);
            //int x = 0;
            //int y = 1 / x;
        }

        protected override void OnLoadLookupDataSource()
        {
            LoadPrefixDS();

            PriceListDS = PriceListDAL.GetLookupList();
            LoadProductDS();

            UnitDS = UnitDAL.GetLookupList();
            if (UnitDS.Count() > 0)
            {
                DefaultUnitID = UnitDS.OrderBy(r => r.UnitName).First().UnitID;
            }

            TaxItemsDS = AdditionalItemsDAL.GetLookupListFinal(eAdditionalItemType.Tax);
            TaxItemsDS.Add(new AdditionalItemLookupModel()
            {
                AdditionalItemID = null,
                AddnitionalItemName = "None",
                Perc = 0
            });

            AdditionalItemLookUpListDataSource = AdditionalItemsDAL.GetLookupListFinal(eAdditionalItemType.AdditionalItem);

            base.OnLoadLookupDataSource();
        }

        protected override void OnAssignLookupDataSource()
        {

            AssignPrefixDS();
            lookUpInvPrefix.EditValueChanged -= lookUpInvPrefix_EditValueChanged;
            lookUpInvPrefix.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.DefaultSaleReturnNoPrefixID;
            lookUpInvPrefix.EditValueChanged += lookUpInvPrefix_EditValueChanged;

            AssignProductDS();

            lookUpPriceList.Properties.ValueMember = "PriceListID";
            lookUpPriceList.Properties.DisplayMember = "PriceListName";
            lookUpPriceList.Properties.DataSource = PriceListDS;

            if (PriceListDS.Count == 1)
            {
                lciPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lcgPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lookUpPriceList.EditValue = PriceListDS.First().PriceListID;
            }
            else if (PriceListDS.Count > 0)
            {
                lookUpPriceList.EditValue = PriceListDS.First().PriceListID;
            }


            StockItemTaxCategoryViewModel TaxCat1 = ProductTaxCategoryDALObj.GetViewModelByTaxIndex(1);
            if (TaxCat1 != null)
            {
                if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAddTaxColumn)
                {
                    colTax1.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnTax;
                }
                else
                {
                    colTax1.Visible = false;
                }
                colTax1.Caption = TaxCat1.ProductTaxCategoryName;
                ProductTaxCat1_IsInterstateSale = TaxCat1.IsInterstateTax;

                gridViewProductDetaiLookUpTax1.DisplayMember = "AddnitionalItemName";
                gridViewProductDetaiLookUpTax1.ValueMember = "AdditionalItemID";
                gridViewProductDetaiLookUpTax1.DataSource = TaxItemsDS.Where(r => r.AdditionalItemID == null || r.ProductTaxCategoryID == 1);
            }
            else
            {
                gvProductDetail.Columns.Remove(colTax1);
            }

            StockItemTaxCategoryViewModel TaxCat2 = ProductTaxCategoryDALObj.GetViewModelByTaxIndex(2);
            if (TaxCat2 != null)
            {
                if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAddTaxColumn)
                {
                    colTax2.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnTax;
                }
                else
                {
                    colTax2.Visible = false;
                }
                colTax2.Caption = TaxCat2.ProductTaxCategoryName;
                ProductTaxCat2_IsInterstateSale = TaxCat2.IsInterstateTax;

                gridViewProductDetaiLookUpTax2.DisplayMember = "AddnitionalItemName";
                gridViewProductDetaiLookUpTax2.ValueMember = "AdditionalItemID";
                gridViewProductDetaiLookUpTax2.DataSource = TaxItemsDS.Where(r => r.AdditionalItemID == null || r.ProductTaxCategoryID == 2);
            }
            else
            {
                gvProductDetail.Columns.Remove(colTax2);
            }

            StockItemTaxCategoryViewModel TaxCat3 = ProductTaxCategoryDALObj.GetViewModelByTaxIndex(3);
            if (TaxCat3 != null)
            {
                if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAddTaxColumn)
                {
                    colTax3.Visible = true;
                    colTax3.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnTax;
                }
                else
                {
                    colTax3.Visible = false;
                }
                colTax3.Caption = TaxCat3.ProductTaxCategoryName;
                ProductTaxCat3_IsInterstateSale = TaxCat3.IsInterstateTax;

                gridViewProductDetaiLookUpTax3.DisplayMember = "AddnitionalItemName";
                gridViewProductDetaiLookUpTax3.ValueMember = "AdditionalItemID";
                gridViewProductDetaiLookUpTax3.DataSource = TaxItemsDS.Where(r => r.AdditionalItemID == null || r.ProductTaxCategoryID == 3);
            }
            else
            {
                gvProductDetail.Columns.Remove(colTax3);
            }

            gridviewProductDetailLookupUnitName.ValueMember = "UnitID";
            gridviewProductDetailLookupUnitName.DisplayMember = "UnitName";
            gridviewProductDetailLookupUnitName.DataSource = UnitDS;

            gridviewAddLookUpAddItemMaster.DisplayMember = "AddnitionalItemName";
            gridviewAddLookUpAddItemMaster.ValueMember = "AddnitionalItemName";
            gridviewAddLookUpAddItemMaster.DataSource = AdditionalItemLookUpListDataSource;

            base.OnAssignLookupDataSource();
        }

        protected override void OnAssignFormValues()
        {
            if (DateTime.Now.Date < CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom)
            {
                deInvoiceDate.EditValue = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.Date;
            }
            else if (CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.HasValue && DateTime.Now.Date > CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value)
            {
                deInvoiceDate.EditValue = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.Date;
            }
            else
            {
                deInvoiceDate.EditValue = DateTime.Now.Date;
            }

            base.OnAssignFormValues();
        }

        void LoadPrefixDS(bool ImmediateAssign = false)
        {
            PrefixListDS = (List<SaleReturnNoPrefixLookupListModel>)SaleReturnNoPrefixDAL.GetLookupList();

            if (ImmediateAssign)
            {
                AssignPrefixDS();
            }
        }
        void AssignPrefixDS()
        {
            lookUpInvPrefix.Properties.DisplayMember = "PrefixName";
            lookUpInvPrefix.Properties.ValueMember = "SaleReturnNoPrefixID";
            lookUpInvPrefix.Properties.DataSource = PrefixListDS;
        }

        void LoadProductDS(bool ImmediateAssign = false)
        {
            NewProduct = new StockItemLookupListModel()
            {
                ProductID = -1,
                PCode = 0,
                Barcode = "New"
            };

            ProductLookUpListDataSource = StockItemDAL.GetLookupList();
            ProductLookUpListDataSource.Insert(0, NewProduct);

            if (ImmediateAssign)
            {
                AssignProductDS();
            }
        }

        void AssignProductDS()
        {
            gridViewProductDetailLookUpProduct.DisplayMember = "ProductName";
            gridViewProductDetailLookUpProduct.ValueMember = "ProductName";
            gridViewProductDetailLookUpProduct.DataSource = ProductLookUpListDataSource;
            CommonFunctions.gridViewlookupProductSelection_ColumnFormat(gridViewProductDetailLookUpProduct);
        }

        object SelectedInvPrefixID;
        object SelectedPriceListID;
        protected override void OnClearValues()
        {
            SelectedInvPrefixID = lookUpInvPrefix.EditValue;
            SelectedPriceListID = lookUpPriceList.EditValue;
            chkbSendSMS.Checked = false;
            base.OnClearValues();
        }

        protected override void OnInitializeDefaultValues()
        {
            if (DateTime.Now.Date < CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom)
            {
                deInvoiceDate.EditValue = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.Date;
            }
            else if (CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.HasValue && DateTime.Now.Date > CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value)
            {
                deInvoiceDate.EditValue = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.Date;
            }
            else
            {
                deInvoiceDate.EditValue = DateTime.Now.Date;
            }


            cmbMemoType.SelectedIndex = (int)Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDefaultMemoType;

            if (lcgCustomer.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
            {
                ucCustomerSelection1.CustomerID = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDefaultCustomerID ?? 0;
            }

            saleReturnProductDetailViewModelBindingSource.Clear();
            saleReturnAdditionalsViewModelBindingSource.Clear();

            OldInvalidDate = null;
            OldSaleReturnNoPrefixID = null;

            //--
            //--
            txtSMSSenderID.Text = Model.CommonProperties.LoginInfo.SoftwareSettings.SMSSaleReturnSenderID;
            memoSMS.Text = Model.CommonProperties.LoginInfo.SoftwareSettings.SMSSaleReturnTemplate;
            //--
            base.OnInitializeDefaultValues();

            lookUpInvPrefix.EditValueChanged -= lookUpInvPrefix_EditValueChanged;
            lookUpInvPrefix.EditValue = SelectedInvPrefixID;
            lookUpInvPrefix.EditValueChanged += lookUpInvPrefix_EditValueChanged;

            lookUpPriceList.EditValue = SelectedPriceListID;
            //lookUpInvPrefix.EditValue = SelectedInvPrefixID;

            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoAutoGenerate && FormCurrentUI == eFormCurrentUI.NewEntry)
            {
                GenerateNewInvoiceNumber();
            }

            if (lookUpPriceList.Properties.DataSource != null && ((List<PriceListLookupListModel>)lookUpPriceList.Properties.DataSource).Count == 1)
            {
                lcgPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lookUpPriceList.EditValue = ((List<PriceListLookupListModel>)lookUpPriceList.Properties.DataSource).First().PriceListID;
            }
            else if (lookUpPriceList.Properties.DataSource != null && !lookUpPriceList.Visible)
            {
                lookUpPriceList.EditValue = ((List<PriceListLookupListModel>)lookUpPriceList.Properties.DataSource).First().PriceListID;
            }

            dsVoucherType = ((List<VoucherTypeLookUpListModel>)lookupEditVoucherType1.Properties.DataSource).ToList();
            if (dsVoucherType != null)
            {
                if (dsVoucherType.Count == 1)
                {
                    lciVoucherType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else
                {
                    FirstControl = lookupEditVoucherType1;
                }
                lookupEditVoucherType1.EditValue = dsVoucherType.FirstOrDefault()?.VoucherTypeID;
            }

            dsSaleAccount = ((List<BookAccountLookUpListModel>)lookupEditSaleAccount.Properties.DataSource).ToList();
            if (dsSaleAccount != null && dsSaleAccount.Count > 0)
            {
                if (dsSaleAccount.Count == 1)
                {
                    lciSaleAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                lookupEditSaleAccount.EditValue = dsSaleAccount.FirstOrDefault().AccountID;
            }

            SetFocusOnFirstControl();
            RoundOffAmt = 0;
            NetAmt = 0;
        }

        void GenerateNewInvoiceNumber()
        {
            txtInvoiceNo.EditValue = DALObject.GenerateSaleReturnNo(
                (long?)(Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoPrefix ? lookUpInvPrefix.EditValue : null),
                (DateTime?)deInvoiceDate.EditValue);
            //txtInvoiceNo.Text = txtInvoiceNo.EditValue.ToString();
            txtInvoiceNo.Refresh();
        }

        protected override bool OnValidateBeforeSave()
        {

            gvProductDetail.UpdateCurrentRow();
            gridViewAdditionals.UpdateCurrentRow();
            UpdateGrossAmt();

            return base.OnValidateBeforeSave();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            SaleReturnViewModel ViewModel = new SaleReturnViewModel();

            ViewModel.SaleReturnID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0);
            ViewModel.MemoType = (eMemoType)cmbMemoType.SelectedIndex;
            ViewModel.SaleReturnDate = (DateTime)deInvoiceDate.EditValue;

            long SaleReturnNo = 0;
            long.TryParse(txtInvoiceNo.Text, out SaleReturnNo);
            ViewModel.SaleReturnNo = SaleReturnNo;

            ViewModel.SaleReturnNoPrefixID = (long?)lookUpInvPrefix.EditValue;

            ViewModel.CustomerAccountID = ucCustomerSelection1.CustomerID;
            ViewModel.SaleAccountID = (long)lookupEditSaleAccount.EditValue;
            ViewModel.VoucherTypeID = (long)lookupEditVoucherType1.EditValue;
            ViewModel.AccountVoucherID = AccountVoucherID;

            ViewModel.PriceListID = (long)lookUpPriceList.EditValue;

            ViewModel.GrossAmt = GrossAmt;
            ViewModel.NetAmt = NetAmt;

            ViewModel.RoundOffAmt = RoundOffAmt;
            ViewModel.RoundOffAddLessID = CommonProperties.LoginInfo.SoftwareSettings.RoundOffAddLessID;

            ViewModel.SaleReturnMemo = txtMemo.Text;

            ViewModel.ProductDetails = (List<SaleReturnProductDetailViewModel>)saleReturnProductDetailViewModelBindingSource.Cast<SaleReturnProductDetailViewModel>().Where(r => r.Quantity != 0).ToList();
            ViewModel.AdditionalItems = (List<SaleReturnAdditionalsViewModel>)saleReturnAdditionalsViewModelBindingSource.Cast<SaleReturnAdditionalsViewModel>().Where(r => r.Amt != 0).ToList();

            if (CommonProperties.LoginInfo.SoftwareSettings.ApplyRoundOff && ViewModel.RoundOffAmt != 0)
            {
                ViewModel.AdditionalItems.Add(new SaleReturnAdditionalsViewModel()
                {
                    AdditionalItemID = ViewModel.RoundOffAddLessID,
                    ItemDescr = "Round off",
                    ItemNature = (ViewModel.RoundOffAmt < 0 ? eAdditionalItemNature.Less : eAdditionalItemNature.Add),
                    Perc = 0,
                    Amt = Math.Abs(ViewModel.RoundOffAmt),
                    CalculatedOnAmt = ViewModel.NetAmt - ViewModel.RoundOffAmt,
                    UpdatedAmt = ViewModel.NetAmt - ViewModel.RoundOffAmt,
                    CalculateOn = eCalculateOn.UpdatedAmt,
                    IsInclusive = false,
                    RecordType = eAdditionalRecordType.RoundedOff,
                    CalculatePercRev = false,
                });
            }

            return ViewModel;
        }

        protected override void OnAfterSaving(SavingParemeter Paras)
        {
            if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                if (lookUpInvPrefix.EditValue != null && (long)lookUpInvPrefix.EditValue == -1)
                {
                    LoadPrefixDS(true);
                }
                LoadProductDS(true);
            }

            //if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            //{
            //    if (CommonProperties.LoginInfo.SoftwareSettings.SMSActivated && CommonProperties.LoginInfo.SoftwareSettings.SMSSendInSaleReturn && chkbSendSMS.Checked)
            //    {
            //        if (txtSMSMobileNos.Text == "")
            //        {
            //            Alit.WinformControls.MessageBox.Show("Can not send sms. Mobile number is not entered.");
            //        }
            //        else
            //        {
            //            Model.Reports.CustomerPrintDetailModel Customer = CustomerDAL.GetCustomerPrintModel(ViewModel.SaleReturn.CustomerID);
            //            string PrefixName = "";
            //            if (lookUpInvPrefix.Visible)
            //            {
            //                PrefixName = lookUpInvPrefix.Text;
            //            }
            //            string Msg = "";
            //            Msg = memoSMS.Text.
            //                Replace("«MemoType»", ViewModel.SaleReturn.SaleReturnMemo).
            //                Replace("«SaleReturnNo»", ViewModel.SaleReturn.SaleReturnNo.ToString()).
            //                Replace("«SaleReturnDate»", ViewModel.SaleReturn.SaleReturnDate.ToShortDateString()).
            //                Replace("«Prefix»", PrefixName).
            //                Replace("«SaleReturnNoWithPrefix»", PrefixName + (PrefixName.Length > 0 ? " " : "") + ViewModel.SaleReturn.SaleReturnNo.ToString()).
            //                Replace("«CustomerNameTitle»", Customer.CustomerNameTitle).
            //                Replace("«CustomerName»", Customer.CustomerNameWithTitle).
            //                Replace("«CustomerNameWithCity»", Customer.CustomerCityStateShortName).
            //                Replace("«CustomerNameWithCityAdd»", Customer.CustomerNameWithTitle + " " + Customer.CustomerAddressDetail).
            //                Replace("«CustomerCity»", Customer.CustomerCityName).
            //                Replace("«CustomerAdd»", Customer.CustomerAddress).
            //                Replace("«CustomerBalance»", Customer.CustomerBalance.ToString("#0")).
            //                Replace("«NetAmt»", ViewModel.SaleReturn.NetAmt.ToString());


            //            SMS.SMSHandler.SendSMS(txtSMSMobileNos.Text, txtSMSSenderID.Text, Msg, "Sale", Alit.Marker.Model.CommonProperties.LoginInfo.LoggedinUser.UserID);
            //        }
            //    }
            //}

            base.OnAfterSaving(Paras);
        }

        protected override XtraReport GeneratePrintDocument(long PrimeKeyID)
        {
            return WinForm.ERP.Transaction.Sales.SaleReturn.frmSaleReturnDashboard.GenerateSaleReturnPrintDocument(PrimeKeyID);
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            saleReturnProductDetailViewModelBindingSource.Clear();
            saleReturnAdditionalsViewModelBindingSource.Clear();

            SaleReturnViewModel EditingRecord = (SaleReturnViewModel)RecordToFill;

            cmbMemoType.SelectedIndex = (int)EditingRecord.MemoType;

            OldInvalidDate = EditingRecord.SaleReturnDate;
            deInvoiceDate.EditValue = EditingRecord.SaleReturnDate;

            txtInvoiceNo.Text = EditingRecord.SaleReturnNo.ToString();

            OldSaleReturnNoPrefixID = EditingRecord.SaleReturnNoPrefixID;
            lookUpInvPrefix.EditValue = EditingRecord.SaleReturnNoPrefixID;

            ucCustomerSelection1.CustomerID = EditingRecord.CustomerAccountID;
            lookupEditSaleAccount.EditValue = EditingRecord.SaleAccountID;
            lookupEditVoucherType1.EditValue = EditingRecord.VoucherTypeID;
            AccountVoucherID = EditingRecord.AccountVoucherID;

            lookUpPriceList.EditValue = EditingRecord.PriceListID;

            txtMemo.Text = EditingRecord.SaleReturnMemo;

            foreach (SaleReturnProductDetailViewModel SaleInvoiceProductDetailViewModel in EditingRecord.ProductDetails)
            {
                saleReturnProductDetailViewModelBindingSource.Add(SaleInvoiceProductDetailViewModel);
            }

            foreach (SaleReturnAdditionalsViewModel AdditionalView in EditingRecord.AdditionalItems.Where(r => r.RecordType != eAdditionalRecordType.RoundedOff))
            {
                saleReturnAdditionalsViewModelBindingSource.Add(AdditionalView);
            }
            //--

            RoundOffAmt = EditingRecord.RoundOffAmt;
            NetAmt = EditingRecord.NetAmt;

            gvProductDetail.UpdateSummary();
            gridViewAdditionals.UpdateSummary();

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }


        #endregion

        #region Methods
        public void FillCustomerInfoInControls()
        {
            AccountLookUpListModel SelectedCustomer = ucCustomerSelection1.GetSelectedRecord();
            if (SelectedCustomer != null)
            {
                lookUpPriceList.EditValue = SelectedCustomer.PriceListID;

                if (lcgSMS.Visible)
                {
                    chkbSendSMS.EditValue = SelectedCustomer.AllowSendSMS;
                }
            }
        }

        /// <summary>
        /// After changing Gross Amt this method should exexute to update additional amout and net amount
        /// </summary>

        public void UpdateGrossAmt()
        {
            UpdateAdditionalsAmount(0);
        }

        public void CalculateRoundOffAmt(decimal UpdatedAmt)
        {
            if (CommonProperties.LoginInfo.SoftwareSettings.ApplyRoundOff && CommonProperties.LoginInfo.SoftwareSettings.RoundOffAddLessID != null)
            {
                RoundOffAmt = Math.Round(UpdatedAmt, 0) - Math.Round(UpdatedAmt, CommonProperties.UIDataFormats.AmountDecimalLen);
            }
            else
            {
                RoundOffAmt = 0;
            }
        }

        public void UpdateAdditionalItemsUpdatedAmount()
        {
            decimal UpdatedAmt = GrossAmt;
            foreach (var AddRecord in (IList<SaleReturnAdditionalsViewModel>)saleReturnAdditionalsViewModelBindingSource.List)
            {
                if (AddRecord.ItemNature == eAdditionalItemNature.Less)
                {
                    UpdatedAmt -= AddRecord.Amt;
                }
                else
                {
                    UpdatedAmt += AddRecord.Amt;
                }
                AddRecord.UpdatedAmt = UpdatedAmt;
            }

            CalculateRoundOffAmt(UpdatedAmt);
            NetAmt = Math.Round(UpdatedAmt + RoundOffAmt, CommonProperties.UIDataFormats.AmountDecimalLen);//.ToString(Model.CommonProperties.UIDataFormats.AmountFormat);
        }

        #endregion

        #region Events 

        private void deInvoiceDate_EditValueChanged(object sender, EventArgs e)
        {
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoAutoGenerate)
            {

                if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoSeries != null &&
                    (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoSeries.Contains("Date") ||
                    Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoSeries.Contains("MonthYear") ||
                    Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoSeries.Contains("Year")))
                {
                    if (OldInvalidDate != (DateTime?)deInvoiceDate.EditValue)
                    {
                        GenerateNewInvoiceNumber();
                    }
                    OldInvalidDate = (DateTime?)deInvoiceDate.EditValue;
                }
            }
        }

        private void lookupCustomer_EditValueChanged(object sender, EventArgs e)
        {
            FillCustomerInfoInControls();
        }

        private void lookUpInvPrefix_EditValueChanged(object sender, EventArgs e)
        {
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoAutoGenerate &&
                (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoSeries ?? "").Contains("Prefix"))
            {
                if (OldSaleReturnNoPrefixID != (long?)lookUpInvPrefix.EditValue)
                {
                    GenerateNewInvoiceNumber();
                }
                OldSaleReturnNoPrefixID = (long?)lookUpInvPrefix.EditValue;
            }
        }

        private void barbtnGridAddRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvProductDetail.GridControl.ContainsFocus)
            {
                if (gvProductDetail.GetVisibleIndex(gvProductDetail.FocusedRowHandle) < (gvProductDetail.RowCount - 1))
                {
                    int newInex = saleReturnProductDetailViewModelBindingSource.IndexOf(saleReturnProductDetailViewModelBindingSource.Current);
                    newInex = Math.Max(Math.Min(newInex, saleReturnProductDetailViewModelBindingSource.Count - 1), 0);
                    saleReturnProductDetailViewModelBindingSource.Insert(newInex, new SaleReturnProductDetailViewModel());
                }
                else
                {
                    gvProductDetail.AddNewRow();
                }
            }
            else if (gridViewAdditionals.GridControl.ContainsFocus)
            {
                if (gridViewAdditionals.GetVisibleIndex(gridViewAdditionals.FocusedRowHandle) < (gridViewAdditionals.RowCount - 1))
                {
                    int newInex = saleReturnAdditionalsViewModelBindingSource.IndexOf(saleReturnAdditionalsViewModelBindingSource.Current);
                    newInex = Math.Max(Math.Min(newInex, saleReturnAdditionalsViewModelBindingSource.Count - 1), 0);
                    saleReturnAdditionalsViewModelBindingSource.Insert(newInex, new SaleReturnAdditionalsViewModel());
                }
                else
                {
                    gridViewAdditionals.AddNewRow();
                }
            }
        }

        private void barBtnGridDeleteRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvProductDetail.GridControl.ContainsFocus)
            {
                GridView view = gvProductDetail;

                if (view == null || view.SelectedRowsCount == 0) return;

                SaleReturnProductDetailViewModel[] rows = new SaleReturnProductDetailViewModel[view.SelectedRowsCount];
                int[] SelectedRowsHandles = view.GetSelectedRows();

                for (int i = 0; i < view.SelectedRowsCount; i++)
                {
                    rows[i] = (SaleReturnProductDetailViewModel)view.GetRow(SelectedRowsHandles[i]);
                }


                view.BeginUpdate();

                foreach (SaleReturnProductDetailViewModel row in rows)
                {
                    saleReturnProductDetailViewModelBindingSource.List.Remove(row);
                }

                view.EndUpdate();
            }
            else
            {
                GridView view = gridViewAdditionals;

                if (view == null || view.SelectedRowsCount == 0) return;

                SaleReturnAdditionalsViewModel[] rows = new SaleReturnAdditionalsViewModel[view.SelectedRowsCount];
                int[] SelectedRowsHandles = view.GetSelectedRows();

                for (int i = 0; i < view.SelectedRowsCount; i++)
                {
                    rows[i] = (SaleReturnAdditionalsViewModel)view.GetRow(SelectedRowsHandles[i]);
                }


                view.BeginUpdate();

                foreach (SaleReturnAdditionalsViewModel row in rows)
                {
                    saleReturnAdditionalsViewModelBindingSource.List.Remove(row);
                }

                view.EndUpdate();
            }
        }

        #endregion

        #region Product Detail Grid

        void saleInvoiceProductDetailViewModelBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                SaleReturnProductDetailViewModel NewRecord = ((SaleReturnProductDetailViewModel)saleReturnProductDetailViewModelBindingSource.List[e.NewIndex]);

                //NewRecord.Quantity = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDefaultQuan;
                //if (DefaultUnitID.HasValue) NewRecord.UnitID = DefaultUnitID.Value;

                NewRecord.GAmtChanged += frmSale_GAmtChanged;
                NewRecord.NetAmtChanged += NewRecord_NetAmtChanged;

                NewRecord.Tax1AmtChanged += NewRecord_Tax1AmtChanged;
                NewRecord.Tax2AmtChanged += NewRecord_Tax2AmtChanged;
                NewRecord.Tax3AmtChanged += NewRecord_Tax3AmtChanged;

                NewRecord.Tax1IDChanged += NewRecord_Tax1IDChanged;
                NewRecord.Tax2IDChanged += NewRecord_Tax2IDChanged;
                NewRecord.Tax3IDChanged += NewRecord_Tax3IDChanged;
            }
            else if (e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemMoved)
            {
                gvProductDetail.UpdateTotalSummary();
                ReSetTaxRecords();
                UpdateAdditionalItemsUpdatedAmount();
            }
        }

        void frmSale_GAmtChanged(object sender, Model.ValueChangedEventArgs e)
        {
            IsProductRecordGAmtChanged = true;
        }
        void NewRecord_Tax1IDChanged(object sender, Model.ValueChangedEventArgs e)
        {
            //ReSetTaxRecords();
        }
        void NewRecord_Tax2IDChanged(object sender, Model.ValueChangedEventArgs e)
        {
            //ReSetTaxRecords();
        }
        void NewRecord_Tax3IDChanged(object sender, Model.ValueChangedEventArgs e)
        {
            //ReSetTaxRecords();
        }

        void NewRecord_Tax1AmtChanged(object sender, Model.ValueChangedEventArgs e)
        {
            if (((SaleReturnProductDetailViewModel)sender).Tax1ID.HasValue)
            {
                UpdateTaxAmt(((SaleReturnProductDetailViewModel)sender).Tax1ID.Value);
            }
        }
        void NewRecord_Tax2AmtChanged(object sender, Model.ValueChangedEventArgs e)
        {
            if (((SaleReturnProductDetailViewModel)sender).Tax2ID.HasValue)
            {
                UpdateTaxAmt(((SaleReturnProductDetailViewModel)sender).Tax2ID.Value);
            }
        }
        void NewRecord_Tax3AmtChanged(object sender, Model.ValueChangedEventArgs e)
        {
            if (((SaleReturnProductDetailViewModel)sender).Tax3ID.HasValue)
            {
                UpdateTaxAmt(((SaleReturnProductDetailViewModel)sender).Tax3ID.Value);
            }
        }

        void NewRecord_NetAmtChanged(object sender, ValueChangedEventArgs e)
        {
            //gridViewProductDetail.UpdateTotalSummary();
            gvProductDetail.PostEditor();
            gvProductDetail.UpdateCurrentRow();
            UpdateAdditionalsAmount(0);
        }

        private void gridViewProductDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            SaleReturnProductDetailViewModel CurrentRow = ((SaleReturnProductDetailViewModel)gvProductDetail.GetRow(e.RowHandle));
            if (e.Column.FieldName == "PCode")
            {
                long PCode = 0;
                if (e.Value != null)
                {
                    if (!long.TryParse(e.Value.ToString(), out PCode))
                    {
                        return;
                    }

                    SelectProduct(StockItemDAL.GetViewModelByPCode(PCode), CurrentRow);
                }
            }
            else if (e.Column.FieldName == "Barcode")
            {
                if (e.Value != null)
                {
                    SelectProduct(StockItemDAL.GetViewModelByBarcode(e.Value.ToString()), CurrentRow);
                }
            }
            else if (e.Column.FieldName == "ProductName")
            {
                if (e.Value != null)
                {
                    string ProductName = e.Value.ToString();
                    StockItemLookupListModel Product = ProductLookUpListDataSource.FirstOrDefault(r => r.ProductName == ProductName);
                    SelectProduct(StockItemDAL.GetViewModelByPrimeKey(Product.ProductID), CurrentRow);
                }
            }
            else if (e.Column.FieldName == "Tax1ID")
            {
                if (e.Value == null)
                {
                    CurrentRow.Tax1ID = 0;
                    CurrentRow.Tax1Amt = 0;
                    CurrentRow.Tax1Perc = 0;
                }
                else
                {
                    long TaxID = (long)e.Value;
                    AdditionalItemLookupModel TaxItem = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == TaxID);
                    if (TaxItem != null)
                    {
                        //CurrentRow.TaxInclusive = TaxItem.IsInclusive;
                        CurrentRow.Tax1Perc = TaxItem.Perc;
                    }
                    else
                    {
                        CurrentRow.Tax1Perc = 0;
                        //CurrentRow.TaxInclusive = false;
                    }
                }
                ReSetTaxRecords();
            }
            else if (e.Column.FieldName == "Tax2ID")
            {
                if (e.Value == null)
                {
                    CurrentRow.Tax2ID = 0;
                    CurrentRow.Tax2Amt = 0;
                    CurrentRow.Tax2Perc = 0;
                }
                else
                {
                    long TaxID = (long)e.Value;
                    AdditionalItemLookupModel TaxItem = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == TaxID);
                    if (TaxItem != null)
                    {
                        //CurrentRow.TaxInclusive = TaxItem.IsInclusive;
                        CurrentRow.Tax2Perc = TaxItem.Perc;
                    }
                    else
                    {
                        CurrentRow.Tax2Perc = 0;
                        //CurrentRow.TaxInclusive = false;
                    }
                }
                ReSetTaxRecords();
            }
            else if (e.Column.FieldName == "Tax3ID")
            {
                if (e.Value == null)
                {
                    CurrentRow.Tax3ID = 0;
                    CurrentRow.Tax3Amt = 0;
                    CurrentRow.Tax3Perc = 0;
                }
                else
                {
                    long TaxID = (long)e.Value;
                    AdditionalItemLookupModel TaxItem = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == TaxID);
                    if (TaxItem != null)
                    {
                        //CurrentRow.TaxInclusive = TaxItem.IsInclusive;
                        CurrentRow.Tax3Perc = TaxItem.Perc;
                    }
                    else
                    {
                        CurrentRow.Tax3Perc = 0;
                        //CurrentRow.TaxInclusive = false;
                    }
                }
                ReSetTaxRecords();
            }
        }

        public void SelectProduct(StockItemViewModel ProductViewModel, int RowHandel)
        {
            SelectProduct(ProductViewModel, (SaleReturnProductDetailViewModel)gvProductDetail.GetRow(RowHandel));
        }

        public void SelectProduct(StockItemViewModel ProductViewModel, SaleReturnProductDetailViewModel RowViewModel)
        {
            if (ProductViewModel == null)
            {
                RowViewModel.ProductID = 0;
                RowViewModel.PCode = 0;
                RowViewModel.Barcode = "";
                RowViewModel.ProductName = "";
                RowViewModel.ProductDescr = "";
                RowViewModel.Rate = 0;
                RowViewModel.UnitID = 0;
            }
            else
            {
                RowViewModel.ProductID = ProductViewModel.ProductID;
                RowViewModel.PCode = ProductViewModel.PCode;
                RowViewModel.Barcode = ProductViewModel.Barcode;
                RowViewModel.ProductName = ProductViewModel.ProductName;
                RowViewModel.ProductDescr = ProductViewModel.ProdDescr;

                RowViewModel.UnitID = ProductViewModel.UnitID;

                RowViewModel.Rate = 0;
                RowViewModel.DiscPerc = 0;

                if (lookUpPriceList.EditValue != null)
                {
                    long PriceListID = (long)lookUpPriceList.EditValue;
                    StockItemRateViewModel RateRecord = ProductViewModel.SaleRate.FirstOrDefault(r => r.PriceListID == PriceListID);
                    if (RateRecord != null)
                    {
                        RowViewModel.Rate = RateRecord.Rate;
                        RowViewModel.DiscPerc = RateRecord.DiscountPerc;
                    }
                }

                AccountLookUpListModel SelectedCustomer = ucCustomerSelection1.GetSelectedRecord();
                long CompanyStateID = Model.CommonProperties.LoginInfo.LoggedInCompany.City.StateID ?? 0;

                long CustomerStateID = 0;
                if (SelectedCustomer != null && SelectedCustomer.AccountID != -1)
                {
                    CustomerStateID = SelectedCustomer.StateID;
                }

                bool IsInterstateSale = (CompanyStateID != CustomerStateID);

                if ((ProductTaxCat1_IsInterstateSale && IsInterstateSale) || (!ProductTaxCat1_IsInterstateSale && !IsInterstateSale))
                {
                    RowViewModel.Tax1ID = ProductViewModel.Tax1ID;
                }

                if ((ProductTaxCat2_IsInterstateSale && IsInterstateSale) || (!ProductTaxCat2_IsInterstateSale && !IsInterstateSale))
                {
                    RowViewModel.Tax2ID = ProductViewModel.Tax2ID;
                }

                if ((ProductTaxCat3_IsInterstateSale && IsInterstateSale) || (!ProductTaxCat3_IsInterstateSale && !IsInterstateSale))
                {
                    RowViewModel.Tax3ID = ProductViewModel.Tax3ID;
                }

                if (RowViewModel.Tax1ID != null)
                {
                    var tax = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == (RowViewModel.Tax1ID ?? 0));
                    if (tax != null)
                    {
                        RowViewModel.Tax1Perc = tax.Perc;
                    }
                    else
                    {
                        RowViewModel.Tax1Perc = 0;
                    }
                }
                else
                {
                    RowViewModel.Tax1Perc = 0;
                }


                if (RowViewModel.Tax2ID != null)
                {
                    var tax = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == (RowViewModel.Tax2ID ?? 0));
                    if (tax != null)
                    {
                        RowViewModel.Tax2Perc = tax.Perc;
                    }
                    else
                    {
                        RowViewModel.Tax2Perc = 0;
                    }
                }
                else
                {
                    RowViewModel.Tax2Perc = 0;
                }


                if (RowViewModel.Tax3ID != null)
                {
                    var tax = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == (RowViewModel.Tax3ID ?? 0));
                    if (tax != null)
                    {
                        RowViewModel.Tax3Perc = tax.Perc;
                    }
                    else
                    {
                        RowViewModel.Tax3Perc = 0;
                    }
                }
                else
                {
                    RowViewModel.Tax3Perc = 0;
                }

                if (RowViewModel.Tax1ID != null || RowViewModel.Tax2ID != null || RowViewModel.Tax3ID != null)
                {
                    ReSetTaxRecords();
                    if (RowViewModel.Tax1ID.HasValue) UpdateTaxAmt(RowViewModel.Tax1ID ?? 0);
                    if (RowViewModel.Tax2ID.HasValue) UpdateTaxAmt(RowViewModel.Tax2ID ?? 0);
                    if (RowViewModel.Tax3ID.HasValue) UpdateTaxAmt(RowViewModel.Tax3ID ?? 0);
                }
                //RowViewModel.TaxID = ProductSaveModel.TaxPerc;
            }
        }

        private void gridViewProductDetail_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            object Row = gvProductDetail.GetRow(e.RowHandle);
            if (Row != null)
            {
                SaleReturnProductDetailViewModel NewRecord = ((SaleReturnProductDetailViewModel)Row);
                //((SaleInvoiceProductDetailViewModel)Row).Rate = ColorRate;
                NewRecord.Quantity = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDefaultQuan;
                if (DefaultUnitID.HasValue) NewRecord.UnitID = DefaultUnitID.Value;
            }
        }

        private void gridViewProductDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (e.Row == null) return;
            SaleReturnProductDetailViewModel ProductRow = (SaleReturnProductDetailViewModel)e.Row;
            if (CommonProperties.LoginInfo.SoftwareSettings.MaintainProducts && ProductRow.ProductID == 0 && String.IsNullOrWhiteSpace(ProductRow.ProductName))
            {
                e.Valid = false;
                e.ErrorText = "Product no selected or Product name not entered";
            }
            else
            {
                e.Valid = true;
                e.ErrorText = "";
            }
        }

        void gridViewProductDetailLookUpProduct_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            NewProduct.ProductName = (e.DisplayValue != null ? e.DisplayValue.ToString() : "");
            ((LookUpEdit)sender).EditValue = -1;
            e.Handled = true;
        }

        private void gridViewProductDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SaleReturnProductDetailViewModel AttachedObj = (SaleReturnProductDetailViewModel)gvProductDetail.GetRow(e.FocusedRowHandle);
            if (AttachedObj != null && AttachedObj.ProductID == -1)
            {
                NewProduct.ProductName = AttachedObj.ProductName;
            }
            //object ProductID = gridViewProductDetail.GetRowCellValue(e.FocusedRowHandle, "ProductID");
            //long ProductIDLong = 0;
            //if (ProductID == null || (ProductID != null && long.TryParse(ProductID.ToString(), out ProductIDLong) && ProductIDLong == -1))
            //{
            //    object ProductName = gridViewProductDetail.GetRowCellValue(e.FocusedRowHandle, "ProductName");
            //    if (ProductName != null)
            //    {
            //        NewProduct.ProductName = ProductName.ToString();
            //    }
            //}
        }

        private void gridViewProductDetail_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            UpdateGrossAmt();
        }

        private void gridControlProductDetail_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider.SetError(gcProductDetail, "");
            if (CommonProperties.LoginInfo.SoftwareSettings.MaintainProducts)
            {
                if (saleReturnProductDetailViewModelBindingSource.Cast<SaleReturnProductDetailViewModel>().Count(r => r.ProductID == 0 && String.IsNullOrWhiteSpace(r.ProductName) && r.Quantity != 0) > 0)
                {
                    ErrorProvider.SetError(gcProductDetail, "Product is required. Please select a Product from list or enter Product name.");
                }
            }
        }

        private void gridViewProductDetail_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;

            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

            if (hitInfo.InRow)
            {

                view.FocusedRowHandle = hitInfo.RowHandle;
                Point GridLocation = view.GridControl.PointToScreen(e.Point);

                popupMenuGridShortCut.ShowPopup(new Point()
                {
                    X = GridLocation.X, // + e.Point.X
                    Y = GridLocation.Y // + e.Point.Y
                });
            }
        }

        private void repositoryItembtnDeleteRowPDetail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Row = gvProductDetail.GetFocusedRow();
            if (Row == null)
            {
                return;
            }

            saleReturnProductDetailViewModelBindingSource.Remove(Row);
        }

        #endregion

        #region Additional Items

        private void gridViewAdditionals_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "AdditionalItemName")
            {
                AdditionalItemViewModel AddItem = null;
                if (e.Value != null)
                {
                    string AddItemName = e.Value.ToString();

                    AdditionalItemLookupModel AddItemLookupObj = AdditionalItemLookUpListDataSource.FirstOrDefault(r => r.AddnitionalItemName == AddItemName);
                    if (AddItemLookupObj != null)
                    {
                        AddItem = AdditionalItemsDAL.GetViewModelByPrimeKey(AddItemLookupObj.AdditionalItemID.Value);
                    }
                }
                SelectAdditionalItem(AddItem, (SaleReturnAdditionalsViewModel)gridViewAdditionals.GetRow(e.RowHandle));
            }
            else if (e.Column.FieldName == "Perc")
            {
                decimal Perc = 0;
                decimal.TryParse((e.Value ?? "0").ToString(), out Perc);
                if (Perc != 0)
                {
                    SaleReturnAdditionalsViewModel Row = (SaleReturnAdditionalsViewModel)gridViewAdditionals.GetRow(e.RowHandle);
                    if (Row.CalculatedOnAmt == 0)
                    {
                        Row.CalculatedOnAmt = GrossAmt;
                    }
                }
            }
        }

        void SelectAdditionalItem(AdditionalItemViewModel AddItem, SaleReturnAdditionalsViewModel RowViewModel)
        {
            if (RowViewModel == null) return;
            if (AddItem != null)
            {
                RowViewModel.AdditionalItemID = AddItem.AdditionalItemID;
                RowViewModel.AdditionalItemName = AddItem.ItemName;
                RowViewModel.ItemNature = (eAdditionalItemNature)AddItem.Nature;
                RowViewModel.IsInclusive = AddItem.InclusiveTax;
                RowViewModel.Perc = AddItem.Perc;
                RowViewModel.CalculateOn = AddItem.CalculateOn;
                RowViewModel.CalculatePercRev = AddItem.ReverseCalculatePercentage;

                if (RowViewModel.CalculateOn == eCalculateOn.GrossAmt)
                {
                    RowViewModel.CalculatedOnAmt = GrossAmt;
                }
                else
                {
                    int RowIndex = saleReturnAdditionalsViewModelBindingSource.IndexOf(RowViewModel);
                    if (RowIndex == 0)
                    {
                        RowViewModel.CalculatedOnAmt = GrossAmt;
                    }
                    else
                    {
                        RowViewModel.CalculatedOnAmt = ((SaleReturnAdditionalsViewModel)saleReturnAdditionalsViewModelBindingSource[RowIndex - 1]).UpdatedAmt;
                    }
                }
            }
            else
            {
                RowViewModel.AdditionalItemID = 0;
                RowViewModel.AdditionalItemName = "";
                RowViewModel.ItemDescr = "";
                RowViewModel.Perc = 0;
                RowViewModel.Amt = 0;
                RowViewModel.CalculateOn = eCalculateOn.GrossAmt;
            }
        }

        bool SuppressUpdateAdditionalsAmount = false;
        [Description("Updates additional items calculate on amount, Amount and Updated Amount. Also Updates Net Amount Value")]
        public void UpdateAdditionalsAmount(int FromRowIndex, bool ReloadBinding = false)
        {
            if (SuppressUpdateAdditionalsAmount) return;
            SuppressUpdateAdditionalsAmount = true;

            if (ReloadBinding) saleReturnAdditionalsViewModelBindingSource.SuspendBinding();

            decimal UpdatedAmt = (FromRowIndex > 0 ? ((SaleReturnAdditionalsViewModel)saleReturnAdditionalsViewModelBindingSource[FromRowIndex - 1]).UpdatedAmt : GrossAmt);

            for (int RowIndex = FromRowIndex; RowIndex < saleReturnAdditionalsViewModelBindingSource.Count; RowIndex++)
            {
                var AddRecord = (SaleReturnAdditionalsViewModel)saleReturnAdditionalsViewModelBindingSource[RowIndex];

                /// updates CalculateOnAmt in the records where CalculateOn is not none and where user has entered some perc rate.
                if ((AddRecord.RecordType != eAdditionalRecordType.Tax) && (AddRecord.CalculateOn != eCalculateOn.None || AddRecord.Perc != 0))
                {
                    if (AddRecord.AdditionalItemID != null && AddRecord.AdditionalItemID != 0) // if user has selected any additional master record
                    {
                        AdditionalItemViewModel AddItemMaster = AdditionalItemsDAL.GetViewModelByPrimeKey(AddRecord.AdditionalItemID.Value);
                        if (AddItemMaster != null)
                        {
                            if (AddItemMaster.CalculateOn == eCalculateOn.UpdatedAmt)
                            {
                                if (RowIndex == 0)
                                {
                                    AddRecord.CalculatedOnAmt = GrossAmt;
                                }
                                else
                                {
                                    AddRecord.CalculatedOnAmt = ((SaleReturnAdditionalsViewModel)saleReturnAdditionalsViewModelBindingSource[RowIndex - 1]).UpdatedAmt;
                                }
                            }
                            else
                            {
                                AddRecord.CalculatedOnAmt = GrossAmt;
                            }
                        }
                    } // when user has not selected any additional master record but has entered some pecentage then move gross amt in calculatedOnAmt
                    else if (AddRecord.Perc != 0)
                    {
                        AddRecord.CalculatedOnAmt = GrossAmt;
                    }
                }

                if (AddRecord.ItemNature == eAdditionalItemNature.Less)
                {
                    UpdatedAmt -= AddRecord.Amt;
                }
                else
                {
                    UpdatedAmt += AddRecord.Amt;
                }
                AddRecord.UpdatedAmt = UpdatedAmt;
            }

            CalculateRoundOffAmt(UpdatedAmt);
            NetAmt = Math.Round(UpdatedAmt + RoundOffAmt, CommonProperties.UIDataFormats.AmountDecimalLen);//.ToString(Model.CommonProperties.UIDataFormats.AmountFormat);

            //txtNetAmt.EditValue = null;
            //txtNetAmt.EditValue = UpdatedAmt;//.ToString(Model.CommonProperties.UIDataFormats.AmountFormat);

            if (ReloadBinding)
            {
                saleReturnAdditionalsViewModelBindingSource.ResumeBinding();
                gridViewAdditionals.RefreshData();
            }
            else
            {
                //gridViewAdditionals.RefreshData();
                gridViewAdditionals.LayoutChanged();
            }

            SuppressUpdateAdditionalsAmount = false;
        }

        public void UpdateTaxAmt(long TaxID)
        {
            saleReturnAdditionalsViewModelBindingSource.SuspendBinding();
            if (TaxID != 0)
            {
                SaleReturnAdditionalsViewModel TaxRecord;
                TaxRecord = saleReturnAdditionalsViewModelBindingSource.Cast<SaleReturnAdditionalsViewModel>().FirstOrDefault(r => r.AdditionalItemID == TaxID);
                if (TaxRecord == null)
                {
                    AdditionalItemLookupModel TaxItem = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == TaxID);
                    AdditionalItemViewModel TaxMaster = null;
                    if (TaxItem.AdditionalItemID.HasValue)
                    {
                        TaxMaster = AdditionalItemsDAL.GetViewModelByPrimeKey(TaxItem.AdditionalItemID.Value);
                    }

                    TaxRecord = new SaleReturnAdditionalsViewModel()
                    {
                        AdditionalItemID = TaxID,
                        AdditionalItemName = TaxItem.AddnitionalItemName,
                        Perc = TaxItem.Perc,
                        RecordType = eAdditionalRecordType.Tax,
                        CalculateOn = eCalculateOn.None,
                        CalculatePercRev = TaxMaster.ReverseCalculatePercentage,
                        ItemNature = TaxMaster.Nature
                    };
                    if (AdditionalItemLookUpListDataSource.FirstOrDefault(r => r.AdditionalItemID == TaxID) == null)
                    {
                        AdditionalItemLookUpListDataSource.Add(TaxItem);
                    }
                    saleReturnAdditionalsViewModelBindingSource.Add(TaxRecord);
                }
                else if (FormCurrentUI != eFormCurrentUI.NewEntry) // Condition added for editing and deleting. After record selection in edit window, in add/less window add/less tax record will exists but in additional lookup data source record will not be there. So that We have to add Tax master record in Additional lookup list.
                {
                    if (AdditionalItemLookUpListDataSource.FirstOrDefault(r => r.AdditionalItemID == TaxID) == null)
                    {
                        AdditionalItemLookupModel TaxItem = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == TaxID);
                        AdditionalItemViewModel TaxMaster = null;
                        if (TaxItem.AdditionalItemID.HasValue)
                        {
                            TaxMaster = AdditionalItemsDAL.GetViewModelByPrimeKey(TaxItem.AdditionalItemID.Value);
                        }
                        TaxRecord = new SaleReturnAdditionalsViewModel()
                        {
                            AdditionalItemID = TaxID,
                            AdditionalItemName = TaxItem.AddnitionalItemName,
                            Perc = TaxItem.Perc,
                            RecordType = eAdditionalRecordType.Tax,
                            CalculateOn = eCalculateOn.None,
                            CalculatePercRev = TaxMaster.ReverseCalculatePercentage,
                            ItemNature = TaxMaster.Nature,
                        };

                        AdditionalItemLookUpListDataSource.Add(TaxItem);
                    }
                }

                var ProductsOfSelectedTax = saleReturnProductDetailViewModelBindingSource.Cast<SaleReturnProductDetailViewModel>().Where(r => r.Tax1ID == TaxID || r.Tax2ID == TaxID || r.Tax3ID == TaxID);
                decimal TaxAmt = ProductsOfSelectedTax.Sum(r => (r.Tax1ID == TaxID ? r.Tax1Amt : 0) + (r.Tax2ID == TaxID ? r.Tax2Amt : 0) + (r.Tax3ID == TaxID ? r.Tax3Amt : 0));
                decimal CalculatedOnAmt = ProductsOfSelectedTax.Sum(r => r.NetAmt);

                TaxRecord.CalculatedOnAmt = CalculatedOnAmt;
                TaxRecord.Amt = TaxAmt;
                //TaxRecord.ItemDescr = TaxRecord.AdditionalItemName + " @ " + TaxRecord.CalculatedOnAmt.ToString(Model.CommonProperties.UIDataFormats.AmountFormat);

                UpdateAdditionalsAmount(0, true);
            }
            saleReturnAdditionalsViewModelBindingSource.ResumeBinding();
            gridViewAdditionals.LayoutChanged();
        }

        public void ReSetTaxRecords()
        {
            List<long> TaxSumm = (from R in
                                  saleReturnProductDetailViewModelBindingSource.Cast<SaleReturnProductDetailViewModel>()
                                  where R.Tax1ID != null
                                  group R by R.Tax1ID into GR
                                  select new { TaxID = GR.Key.Value }).Select<dynamic, long>(r => r.TaxID).ToList();

            long[] TaxSumm2 = (from R in
                                  saleReturnProductDetailViewModelBindingSource.Cast<SaleReturnProductDetailViewModel>()
                               where R.Tax2ID != null
                               group R by R.Tax2ID into GR
                               select new { TaxID = GR.Key.Value }).Select<dynamic, long>(r => r.TaxID).ToArray();
            if (TaxSumm2 != null && TaxSumm2.Count() > 0)
            {
                TaxSumm.AddRange(TaxSumm2);
            }

            long[] TaxSumm3 = (from R in
                                  saleReturnProductDetailViewModelBindingSource.Cast<SaleReturnProductDetailViewModel>()
                               where R.Tax3ID != null
                               group R by R.Tax3ID into GR
                               select new { TaxID = GR.Key.Value }).Select<dynamic, long>(r => r.TaxID).ToArray();

            if (TaxSumm3 != null && TaxSumm3.Count() > 0)
            {
                TaxSumm.AddRange(TaxSumm3);
            }

            var TaxRecordsToDelete = saleReturnAdditionalsViewModelBindingSource.Cast<SaleReturnAdditionalsViewModel>().Where(r =>
                r.RecordType == eAdditionalRecordType.Tax &&
                !TaxSumm.Contains(r.AdditionalItemID ?? 0)).ToList();

            foreach (var Record in TaxRecordsToDelete)
            {
                saleReturnAdditionalsViewModelBindingSource.Remove(Record);
                AdditionalItemLookupModel TaxItem = AdditionalItemLookUpListDataSource.FirstOrDefault(r => r.AdditionalItemID == Record.AdditionalItemID);
                if (TaxItem != null)
                {
                    AdditionalItemLookUpListDataSource.Remove(TaxItem);
                }
            }

            foreach (var TaxID in TaxSumm)
            {
                UpdateTaxAmt(TaxID);
            }
            UpdateAdditionalsAmount(0, true);
        }

        void saleInvoiceAdditionalsViewModelBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                SaleReturnAdditionalsViewModel SIAVM = (SaleReturnAdditionalsViewModel)saleReturnAdditionalsViewModelBindingSource.List[e.NewIndex];
                SIAVM.AmtChanged -= frmSale_AdditionalItemAmtChanged;
                SIAVM.AmtChanged += frmSale_AdditionalItemAmtChanged;
                SIAVM.ItemNatureChanged -= SIAVM_ItemNatureChanged;
                SIAVM.ItemNatureChanged += SIAVM_ItemNatureChanged;
            }
            else if (e.ListChangedType == ListChangedType.Reset)
            {
                foreach (var item in saleReturnAdditionalsViewModelBindingSource)
                {
                    SaleReturnAdditionalsViewModel SIAVM = (SaleReturnAdditionalsViewModel)item;
                    SIAVM.AmtChanged -= frmSale_AdditionalItemAmtChanged;
                    SIAVM.ItemNatureChanged -= SIAVM_ItemNatureChanged;
                }
            }
            else if (e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemMoved)
            {
                UpdateAdditionalsAmount(0);
            }
        }

        void SIAVM_ItemNatureChanged(object sender, ValueChangedEventArgs e)
        {
            int RowIndex = saleReturnAdditionalsViewModelBindingSource.IndexOf(sender);
            UpdateAdditionalsAmount(RowIndex);
        }

        void frmSale_AdditionalItemAmtChanged(object sender, Model.ValueChangedEventArgs e)
        {
            int RowIndex = saleReturnAdditionalsViewModelBindingSource.IndexOf(sender);
            UpdateAdditionalsAmount(RowIndex);
        }

        private void repositoryItembtnDeleteRowAdditional_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Row = gridViewAdditionals.GetFocusedRow();
            if (Row == null)
            {
                return;
            }

            saleReturnAdditionalsViewModelBindingSource.Remove(Row);
        }

        #endregion

        #region Validation
        private void txtInvoiceNo_Validating(object sender, CancelEventArgs e)
        {
            long InvNo;
            if (txtInvoiceNo.EditValue == null || !long.TryParse(txtInvoiceNo.EditValue.ToString(), out InvNo) || InvNo == 0)
            {
                ErrorProvider.SetError(txtInvoiceNo, "Blank, invalid or zero not accepted in Invoice Number.");
            }
            else if (DALObject.IsDuplicateRecord(InvNo,
                (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                    (long?)(Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoPrefix ? lookUpInvPrefix.EditValue : null),
                    (DateTime?)deInvoiceDate.EditValue))
            {
                ErrorProvider.SetError(txtInvoiceNo, "Can not accept duplicate Sale Return Number.");
            }
            else
            {
                ErrorProvider.SetError(txtInvoiceNo, null);
            }
        }

        private void deInvoiceDate_Validating(object sender, CancelEventArgs e)
        {
            if (deInvoiceDate.EditValue == null)
            {
                ErrorProvider.SetError(deInvoiceDate, "Receipt date is required.");
            }
            else
            {
                DateTime dt = (DateTime)deInvoiceDate.EditValue;

                if (dt < CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom || dt > CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo)
                {
                    ErrorProvider.SetError(deInvoiceDate, "Date should be with in current financial period that started from " + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.ToShortDateString() + (CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.HasValue ? " upto " + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.ToShortDateString() : ""));
                }
                else
                {
                    ErrorProvider.SetError(deInvoiceDate, null);
                }
            }
        }

        private void lookupCustomer_Validating(object sender, CancelEventArgs e)
        {
            if (ucCustomerSelection1.CustomerID == 0)
            {
                ErrorProvider.SetError(ucCustomerSelection1, "Please select or enter Customer Name.");
            }
            else
            {
                ErrorProvider.SetError(ucCustomerSelection1, null);
            }
        }

        private void lookUpInvPrefix_Validating(object sender, CancelEventArgs e)
        {
            if ((lookUpInvPrefix.EditValue == null || (long)lookUpInvPrefix.EditValue == -1) && (String.IsNullOrWhiteSpace(lookUpInvPrefix.Text) || lookUpInvPrefix.Text == lookUpInvPrefix.Properties.NullText))
            {
                ErrorProvider.SetError(lookUpInvPrefix, "Please select or enter Prefix.");
            }
            else
            {
                ErrorProvider.SetError(lookUpInvPrefix, null);
            }
        }

        private void txtSMSSenderID_Validating(object sender, CancelEventArgs e)
        {
            if (chkbSendSMS.Checked && txtSMSSenderID.Text.Length != 6)
            {
                ErrorProvider.SetError(txtSMSSenderID, "SMS sender id must be 6 chars long.");
            }
            else
            {
                ErrorProvider.SetError(txtSMSSenderID, null);
            }
        }

        private void txtSMSMobileNos_Validating(object sender, CancelEventArgs e)
        {
            if (chkbSendSMS.Checked && txtSMSMobileNos.Text.Length == 0)
            {
                ErrorProvider.SetError(txtSMSMobileNos, "Please enter Mobile Number.");
            }
            else
            {
                ErrorProvider.SetError(txtSMSMobileNos, null);
                //--
                string[] Nos = txtSMSMobileNos.Text.Split(',');
                foreach (string No in Nos)
                {
                    if (No.Trim().Length != 10)
                    {
                        ErrorProvider.SetError(txtSMSMobileNos, "Mobile No(s) should entered in 10 digits. Invalid mobile numbers are not accepted.");
                    }
                }
            }
        }


        private void lookupEditVoucherType1_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEditVoucherType1.EditValue == null)
            {
                ErrorProvider.SetError(lookupEditVoucherType1, "Please select Voucher Type.");
            }
            else
            {
                ErrorProvider.SetError(lookupEditVoucherType1, null);
            }
        }

        private void lookupEditSaleAccount_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEditSaleAccount.EditValue == null)
            {
                ErrorProvider.SetError(lookupEditSaleAccount, "Please select Sale Account.");
            }
            else
            {
                ErrorProvider.SetError(lookupEditSaleAccount, null);
            }
        }

        #endregion

        private void cmbMemoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((eMemoType)cmbMemoType.SelectedIndex == eMemoType.Cash)
            {
                ucCustomerSelection1.LookupEditAccountFilter.AccountGroupTypeFilter = new eAccountGroupType[] { eAccountGroupType.CashInHand };
            }
            else
            {
                ucCustomerSelection1.LookupEditAccountFilter.AccountGroupTypeFilter = new eAccountGroupType[] { eAccountGroupType.SundryDebtors };
            }
            ucCustomerSelection1.LookupEditAccountFilter.ReloadDataSource();
            ucCustomerSelection1.LookupEditAccountFilter.EditValue = null;
        }
    }
}
