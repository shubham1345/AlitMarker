using Alit.Marker.DAL;
using Alit.Marker.DAL.City;
using Alit.Marker.DAL.Customer;
using Alit.Marker.Model;
using Alit.Marker.Model.City;
using Alit.Marker.Model.Customer;
using Alit.Marker.Model.Template;
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
using Alit.Marker.Model.ERP.Masters.Transport;
using Alit.Marker.DAL.ERP.Masters.Transport;
using Alit.Marker.Model.ERP.Transaction.Sales.SaleInvoice;
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleInvoice;
using Alit.Marker.Model.ERP.Transaction.Sales.SaleOrder;
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleOrder;
using Alit.Marker.Model.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix;
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.Model.Account.VoucherType;
using Alit.Marker.Model.Account.Group;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleInvoice
{
    public partial class frmSaleInvoiceCRUD : Template.frmCRUDTemplate
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

        public decimal RemainingAmt { get { return NetAmt - AdvanceAmt; } }

        public long? AdvanceOldRecieptID { get; set; }
        public decimal AdvanceOldAmt { get; set; }

        public bool IsProductRecordGAmtChanged;

        DateTime? OldInvalidDate;
        long? OldSaleInvoiceNoPrefixID;

        public long? DefaultUnitID;

        public bool ProductTaxCat1_IsInterstateSale;
        public bool ProductTaxCat2_IsInterstateSale;
        public bool ProductTaxCat3_IsInterstateSale;

        long OldSaleOrderID = 0;

        #endregion

        SaleInvoiceDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new SaleInvoiceDAL();
                }
                return DALObject;
            }
        }

        List<SaleInvoiceNoPrefixLookupListModel> PrefixListDS;

        DAL.Inventory.Masters.StockItem.StockItemDAL StockItemDAL;
        List<StockItemLookupListModel> ProductLookUpListDataSource;

        AdditionalItemDAL AdditionalItemsDAL;
        List<AdditionalItemLookupModel> AdditionalItemLookUpListDataSource;

        //TransportDAL TransportDAL;
        //List<TransportLookUpListModel> TransportListDS;

        SaleInvoiceNoPrefixDAL SIPrefixDAL;
        UnitDAL UnitDAL;
        PriceListDAL PriceListDAL;
        StockItemTaxCategoryDAL StockItemTaxCategoryDALObj;
        SaleOrderDAL SaleOrderDALObj;
        ////BindingList<SaleOrderLookupListModel> dsSaleOrder;
        //List<SaleOrderLookupListModel> dsSaleOrder;

        List<PriceListLookupListModel> PriceListDS;
        List<AdditionalItemLookupModel> TaxItemsDS;
        IEnumerable<UnitLookupListModel> UnitDS;

        List<VoucherTypeLookUpListModel> dsVoucherType;
        List<BookAccountLookUpListModel> dsSaleAccount;
        long AccountVoucherID;

        public frmSaleInvoiceCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmSaleInvoiceCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();

            // Initialize DAL objects
            DALObject = new SaleInvoiceDAL();
            SIPrefixDAL = new SaleInvoiceNoPrefixDAL();
            StockItemDAL = new DAL.Inventory.Masters.StockItem.StockItemDAL();
            SaleOrderDALObj = new SaleOrderDAL();
            PriceListDAL = new DAL.Inventory.Masters.Product.PriceListDAL();
            AdditionalItemsDAL = new AdditionalItemDAL();
            UnitDAL = new DAL.Inventory.Masters.Unit.UnitDAL();
            StockItemTaxCategoryDALObj = new StockItemTaxCategoryDAL();
            //TransportDAL = new TransportDAL();
            //--
            Control firstcontrol = null;
            if (CommonProperties.LoginInfo.SoftwareSettings.ActivateSaleOrder)
            {
                lciSaleOrder.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                firstcontrol = lookupSaleOrder;
            }
            else
            {
                lciSaleOrder.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            // Applying setting for Memo type
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceMemoTypeApplies != Model.Settings.ApplicationSettings.eSaleInvoiceMemoTypeApplies.CashCreditBoth)
            {
                lciMemoType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                //--
                if (firstcontrol == null)
                {
                    firstcontrol = deInvoiceDate;
                }
            }

            if (firstcontrol == null)
            {
                firstcontrol = cmbMemoType;
            }
            FirstControl = firstcontrol;

            // Apply settings for Invoice Number and prefix
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNo)
            {
                if (!Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoPrefix)
                {
                    lciInvoiceNoPrefix.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                if (!Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoAllowEdit)
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

            // Apply settings for Challan informations
            if (String.IsNullOrWhiteSpace(Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceChallanInfo))
            {
                lcgChallanInfo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                string ChallanInfos = "," + Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceChallanInfo + ",";

                if (!ChallanInfos.Contains("," + ((int)Model.Settings.ApplicationSettings.eSaleInvoiceChallanElements.ChallanNo).ToString() + ","))
                {
                    lciChallanNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                if (!ChallanInfos.Contains("," + ((int)Model.Settings.ApplicationSettings.eSaleInvoiceChallanElements.ChallanDate).ToString() + ","))
                {
                    lciChallanDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                if (!ChallanInfos.Contains("," + ((int)Model.Settings.ApplicationSettings.eSaleInvoiceChallanElements.OrderNo).ToString() + ","))
                {
                    lciOrderNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                if (!ChallanInfos.Contains("," + ((int)Model.Settings.ApplicationSettings.eSaleInvoiceChallanElements.OrderDate).ToString() + ","))
                {
                    lciOrderDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                if (!ChallanInfos.Contains("," + ((int)Model.Settings.ApplicationSettings.eSaleInvoiceChallanElements.SupplierRefNo).ToString() + ","))
                {
                    lciSupplierNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                if (!ChallanInfos.Contains("," + ((int)Model.Settings.ApplicationSettings.eSaleInvoiceChallanElements.OtherRefNo).ToString() + ","))
                {
                    lciOtherReferenceNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }

            // Apply setting for Dispatch information
            if (!Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDispatchInfo)
            {
                lcgDispatchInfo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
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

            //Amt Columns
            colGAmt.OptionsColumn.ReadOnly = !Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditGAmt;
            colGAmt.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditGAmt;
            colGAmt.OptionsColumn.AllowEdit = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditGAmt;
            colGAmt.OptionsColumn.AllowFocus = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditGAmt;
            colGAmt.Visible = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditGAmt;

            // adding events for Product and additional for list change to add some events in each records to control some functions
            //saleInvoiceProductDetailViewModelBindingSource.DataSource = new Model.Sales.SaleInvoiceProductDetailViewModel();
            saleInvoiceProductDetailViewModelBindingSource.ListChanged += saleInvoiceProductDetailViewModelBindingSource_ListChanged;
            saleInvoiceAdditionalsViewModelBindingSource.ListChanged += saleInvoiceAdditionalsViewModelBindingSource_ListChanged;

            //--
            if (CommonProperties.LoginInfo.SoftwareSettings.SMSActivated && CommonProperties.LoginInfo.SoftwareSettings.SMSSendInSaleInvoice)
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
                CommonProperties.LoginInfo.SoftwareSettings.SMSSendInSaleInvoice)
            {
                txtSMSSenderID.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSSaleInvoiceSenderID;
                memoSMS.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSSaleInvoiceTemplate;
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
            // SetFocusOnFirstControl();
            base.OnShown(e);
        }

        protected override void OnLoadLookupDataSource()
        {
            //if (CommonProperties.LoginInfo.SoftwareSettings.ActivateSaleOrder)
            //{
            //    LoadSaleOrderDS();
            //}
            //if (CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNo && CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoPrefix)
            //{
            //    LoadPrefixDS();
            //}

            //if (CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDispatchInfo)
            //{
            //    LoadTransportDS();
            //}

            //PriceListDS = PriceListDAL.GetLookupList();
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
            //if (CommonProperties.LoginInfo.SoftwareSettings.ActivateSaleOrder)
            //{
            //    AssignSaleOrderDS();
            //}

            //if (CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNo && CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoPrefix)
            //{
            //    AssignPrefixDS();

            //    lookUpInvPrefix.EditValueChanged -= lookUpInvPrefix_EditValueChanged;
            //    lookUpInvPrefix.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.DefaultSaleInvoiceNoPrefixID;
            //    lookUpInvPrefix.EditValueChanged += lookUpInvPrefix_EditValueChanged;
            //}

            //if (CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDispatchInfo)
            //{
            //    AssignTransportDS();
            //}

            AssignProductDS();

            //lookUpPriceList.Properties.ValueMember = "PriceListID";
            //lookUpPriceList.Properties.DisplayMember = "PriceListName";
            //lookUpPriceList.Properties.DataSource = PriceListDS;

            //if (PriceListDS.Count == 1)
            //{
            //    lciPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //    lcgPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //    lookUpPriceList.EditValue = PriceListDS.First().PriceListID;
            //}
            //else if (PriceListDS.Count > 0)
            //{
            //    lookUpPriceList.EditValue = PriceListDS.First().PriceListID;
            //}

            StockItemTaxCategoryViewModel TaxCat1 = StockItemTaxCategoryDALObj.GetViewModelByTaxIndex(1);
            if (TaxCat1 != null && TaxCat1.Applicable)
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
                gridViewProductDetail.Columns.Remove(colTax1);
            }

            StockItemTaxCategoryViewModel TaxCat2 = StockItemTaxCategoryDALObj.GetViewModelByTaxIndex(2);
            if (TaxCat2 != null && TaxCat2.Applicable)
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
                gridViewProductDetail.Columns.Remove(colTax2);
            }

            StockItemTaxCategoryViewModel TaxCat3 = StockItemTaxCategoryDALObj.GetViewModelByTaxIndex(3);
            if (TaxCat3 != null && TaxCat3.Applicable)
            {
                if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAddTaxColumn)
                {
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
                gridViewProductDetail.Columns.Remove(colTax3);
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
            //PrefixListDS = SIPrefixDAL.GetLookupList();
            if (ImmediateAssign)
            {
                LoadPrefixDS();
            }
        }

        void AssignPrefixDS()
        {
            lookUpInvPrefix.Properties.DisplayMember = "PrefixName";
            lookUpInvPrefix.Properties.ValueMember = "SaleInvoiceNoPrefixID";
            lookUpInvPrefix.Properties.DataSource = PrefixListDS;
        }


        //void LoadTransportDS(bool ImmediateAssign = false)
        //{
        //    TransportListDS = TransportDAL.GetLookupList();
        //    if (ImmediateAssign)
        //    {
        //        AssignTransportDS();
        //    }
        //}

        //void AssignTransportDS()
        //{
        //    lookupDispTransport.Properties.ValueMember = "TransportID";
        //    lookupDispTransport.Properties.DisplayMember = "TransportName";
        //    lookupDispTransport.Properties.DataSource = TransportListDS;
        //}


        void LoadProductDS(bool ImmediateAssign = false)
        {
            ProductLookUpListDataSource = StockItemDAL.GetLookupList();
            if (ImmediateAssign)
            {
                LoadProductDS();
            }
        }

        void AssignProductDS()
        {
            gridViewProductDetailLookUpProduct.DisplayMember = "ProductName";
            gridViewProductDetailLookUpProduct.ValueMember = "ProductName";
            gridViewProductDetailLookUpProduct.DataSource = ProductLookUpListDataSource;
            CommonFunctions.gridViewlookupProductSelection_ColumnFormat(gridViewProductDetailLookUpProduct);
        }

        //void LoadSaleOrderDS(long IncludeSaleOrderID = 0, bool ImmediateAssign = false)
        //{
        //    dsSaleOrder = new BindingList<SaleOrderLookupListModel>((List<SaleOrderLookupListModel>)SaleOrderDALObj.GetLookupListFinal(null, false, IncludeSaleOrderID));
        //    dsSaleOrder.Insert(0, new SaleOrderLookupListModel() { SaleOrderID = null, SaleOrderNo = null, CustomerName = "None" });

        //    if (ImmediateAssign)
        //    {
        //        AssignSaleOrderDS();
        //    }
        //}

        //void AssignSaleOrderDS()
        //{
        //    lookupSaleOrder.Properties.DisplayMember = "SaleOrderNo";
        //    lookupSaleOrder.Properties.ValueMember = "SaleOrderID";
        //    lookupSaleOrder.Properties.DataSource = dsSaleOrder;
        //}

        object SelectedInvPrefixID;
        object SelectedPriceListID;
        protected override void OnClearValues()
        {
            SelectedInvPrefixID = lookUpInvPrefix.EditValue;
            SelectedPriceListID = lookUpPriceList.EditValue;
            OldSaleOrderID = 0;
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


            lookupSaleOrder.EditValue = null;

            cmbMemoType.SelectedIndex = (int)Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDefaultMemoType;

            if (lcgCustomer.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
            {
                ucCustomerSelection1.CustomerID = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDefaultCustomerID ?? 0;
            }

            saleInvoiceProductDetailViewModelBindingSource.Clear();
            saleInvoiceAdditionalsViewModelBindingSource.Clear();

            OldInvalidDate = null;
            OldSaleInvoiceNoPrefixID = null;

            //--
            //--
            txtSMSSenderID.Text = Model.CommonProperties.LoginInfo.SoftwareSettings.SMSSaleInvoiceSenderID;
            memoSMS.Text = Model.CommonProperties.LoginInfo.SoftwareSettings.SMSSaleInvoiceTemplate;
            //--
            base.OnInitializeDefaultValues();

            lookUpInvPrefix.EditValueChanged -= lookUpInvPrefix_EditValueChanged;

            lookUpInvPrefix.EditValue = SelectedInvPrefixID;
            lookUpInvPrefix.EditValueChanged += lookUpInvPrefix_EditValueChanged;

            lookUpPriceList.EditValue = SelectedPriceListID;
            //lookUpInvPrefix.EditValue = SelectedInvPrefixID;

            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoAutoGenerate && FormCurrentUI == eFormCurrentUI.NewEntry)
            {
                GenerateNewInvoiceNumber();
            }

            PriceListDS = ((List<PriceListLookupListModel>)lookUpPriceList.Properties.DataSource).ToList();
            if (PriceListDS != null)
            {
                if (PriceListDS.Count == 1)
                {
                    lciPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lcgPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lookUpPriceList.EditValue = PriceListDS.FirstOrDefault().PriceListID;
                }
                else if (PriceListDS.Count > 0)
                {
                    lookUpPriceList.EditValue = PriceListDS.FirstOrDefault().PriceListID;
                }
            }

            if (lookUpPriceList.Properties.DataSource != null && ((List<PriceListLookupListModel>)lookUpPriceList.Properties.DataSource).Count == 1)
            {
                lcgPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lookUpPriceList.EditValue = ((List<PriceListLookupListModel>)lookUpPriceList.Properties.DataSource).FirstOrDefault().PriceListID;
            }
            else if (lookUpPriceList.Properties.DataSource != null && !lookUpPriceList.Visible)
            {
                lookUpPriceList.EditValue = ((List<PriceListLookupListModel>)lookUpPriceList.Properties.DataSource).FirstOrDefault().PriceListID;
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

            if (CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNo && CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoPrefix)
            {
                //AssignPrefixDS();
                PrefixListDS = ((List<SaleInvoiceNoPrefixLookupListModel>)lookUpInvPrefix.Properties.DataSource).ToList();

                lookUpInvPrefix.EditValueChanged -= lookUpInvPrefix_EditValueChanged;
                lookUpInvPrefix.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.DefaultSaleInvoiceNoPrefixID;
                lookUpInvPrefix.EditValueChanged += lookUpInvPrefix_EditValueChanged;
            }

            //if (!CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDispatchInfo)
            //{
            //    lookupDispTransport.Properties.DataSource = null;
            //}

            //if (!CommonProperties.LoginInfo.SoftwareSettings.ActivateSaleOrder)
            //{
            //    //dsSaleOrder = ((List<SaleOrderLookupListModel>)lookupSaleOrder.Properties.DataSource).ToList();
            //    //if (dsSaleOrder != null)
            //    //{
            //    //    dsSaleOrder.Insert(0, new SaleOrderLookupListModel() { SaleOrderID = null, SaleOrderNo = null, CustomerName = "None", OrderDate = null });
            //    //    lookupSaleOrder.Properties.DataSource = dsSaleOrder;
            //    //}
            //    lookupSaleOrder.Properties.DataSource = null;
            //}

            SetFocusOnFirstControl();
            RoundOffAmt = 0;
            NetAmt = 0;
            AdvanceAmt = 0;
        }

        void GenerateNewInvoiceNumber()
        {
            txtInvoiceNo.EditValue = DALObject.GenerateSaleInvoiceNo(
                (long?)(Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoPrefix ? lookUpInvPrefix.EditValue : null),
                (DateTime?)deInvoiceDate.EditValue).ToString();
            //txtInvoiceNo.Text = txtInvoiceNo.EditValue.ToString();
            txtInvoiceNo.Refresh();
        }

        protected override bool OnValidateBeforeSave()
        {
            decimal oldNetAmt = NetAmt;

            gridViewProductDetail.UpdateCurrentRow();
            gridViewAdditionals.UpdateCurrentRow();
            UpdateGrossAmt();

            if (oldNetAmt != NetAmt)
            {
                Application.DoEvents();
                if (Alit.WinformControls.MessageBox.Show("Net amount has been changed. Do you still want to save ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            SaleInvoiceViewModel ViewModel = new SaleInvoiceViewModel();

            ViewModel.SaleInvoiceID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0);
            ViewModel.MemoType = (eMemoType)cmbMemoType.SelectedIndex;
            ViewModel.SaleInvoiceDate = deInvoiceDate.DateTime;

            long SaleInvoiceNo = 0;
            long.TryParse(txtInvoiceNo.Text, out SaleInvoiceNo);
            ViewModel.SaleInvoiceNo = SaleInvoiceNo;

            if (CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoPrefix && lookUpInvPrefix.EditValue != null)
            {
                ViewModel.SaleInvoiceNoPrefixID = (long)lookUpInvPrefix.EditValue;
            }
            else
            {
                ViewModel.SaleInvoiceNoPrefixID = null;
            }

            ViewModel.CustomerAccountID = ucCustomerSelection1.CustomerID;
            ViewModel.SaleAccountID = (long)lookupEditSaleAccount.EditValue;
            ViewModel.VoucherTypeID = (long)lookupEditVoucherType1.EditValue;

            ViewModel.PriceListID = (long)lookUpPriceList.EditValue;

            ViewModel.SaleOrderID = (long?)lookupSaleOrder.EditValue;

            ViewModel.ChallanNo = txtChallanNo.Text;
            ViewModel.ChallanDate = (DateTime?)deChallanDate.EditValue;
            ViewModel.OrderNo = txtOrderNo.Text;
            ViewModel.OrderDate = (DateTime?)deOrderDate.EditValue;
            ViewModel.SupplierReferenceNo = txtSuppRefNo.Text;
            ViewModel.OtherReferenceNo = txtOtherRefNo.Text;

            ViewModel.NofPackets = txtNoOfPackets.Text;
            ViewModel.Destination = txtDispDestination.Text;
            ViewModel.DeliveryDate = (DateTime?)deDispDocDate.EditValue;
            ViewModel.DispatchDocumentNo = txtDispDocNo.Text;
            ViewModel.TransportID = (long?)lookupDispTransport.EditValue;

            //-- Price List
            ViewModel.PriceListID = (long)lookUpPriceList.EditValue;

            ViewModel.GrossAmt = GrossAmt;
            ViewModel.NetAmt = NetAmt;

            // No neecheck any setting here, because when calculating round off amt, it will check setting there.
            ViewModel.RoundOffAmt = RoundOffAmt;
            ViewModel.RoundOffAddLessID = CommonProperties.LoginInfo.SoftwareSettings.RoundOffAddLessID;

            ViewModel.InvoiceMemo = txtMemo.Text;

            ViewModel.ProductDetail = saleInvoiceProductDetailViewModelBindingSource.Cast<SaleInvoiceProductDetailViewModel>().Where(r => r.Quantity != 0).ToList();
            ViewModel.AdditionalItems = saleInvoiceAdditionalsViewModelBindingSource.Cast<SaleInvoiceAdditionalsViewModel>().Where(r => r.Amt != 0).ToList();

            if (CommonProperties.LoginInfo.SoftwareSettings.ApplyRoundOff && RoundOffAmt != 0)
            {
                ViewModel.AdditionalItems.Add(new SaleInvoiceAdditionalsViewModel()
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

            ViewModel.AdvanceAmt = AdvanceAmt;
            ViewModel.AdvanceOldAmt = AdvanceOldAmt;
            ViewModel.AdvanceOldRecieptID = AdvanceOldRecieptID;
            ViewModel.AccountVoucherID = AccountVoucherID;

            return ViewModel;
        }

        protected override void OnAfterSaving(SavingParemeter Paras)
        {
            if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                //if (lookUpInvPrefix.EditValue != null && (long)lookUpInvPrefix.EditValue == -1)
                //{
                //    LoadPrefixDS(true);
                //}
                LoadProductDS(true);


                //if (CommonProperties.LoginInfo.SoftwareSettings.SMSActivated 
                //    && CommonProperties.LoginInfo.SoftwareSettings.SMSSendInSaleInvoice 
                //    && chkbSendSMS.Checked)
                //{
                //    if (txtSMSMobileNos.Text == "")
                //    {
                //        Alit.WinformControls.MessageBox.Show("Can not send sms. Mobile number is not entered.");
                //    }
                //    else
                //    {
                //        Model.Reports.CustomerPrintDetailModel Customer = CustomerDAL.GetCustomerPrintModel(ViewModel.Sale.CustomerID);
                //        string PrefixName = "";
                //        if (lookUpInvPrefix.Visible)
                //        {
                //            PrefixName = lookUpInvPrefix.Text;
                //        }
                //        string Msg = "";
                //        Msg = memoSMS.Text.
                //            Replace("«InvoiceType»", ViewModel.Sale.InvoiceMemo).
                //            Replace("«SaleInvoiceNo»", ViewModel.Sale.SaleInvoiceNo.ToString()).
                //            Replace("«SaleInvoiceDate»", ViewModel.Sale.SaleInvoiceDate.ToShortDateString()).
                //            Replace("«Prefix»", PrefixName).
                //            Replace("«InvoiceNoWithPrefix»", PrefixName + (PrefixName.Length > 0 ? " " : "") + ViewModel.Sale.SaleInvoiceNo.ToString()).
                //            Replace("«CustomerNameTitle»", Customer.CustomerNameTitle).
                //            Replace("«CustomerName»", Customer.CustomerNameWithTitle).
                //            Replace("«CustomerNameWithCity»", Customer.CustomerCityStateShortName).
                //            Replace("«CustomerNameWithCityAdd»", Customer.CustomerNameWithTitle + " " + Customer.CustomerAddressDetail).
                //            Replace("«CustomerCity»", Customer.CustomerCityName).
                //            Replace("«CustomerAdd»", Customer.CustomerAddress).
                //            Replace("«CustomerBalance»", Customer.CustomerBalance.ToString("#0")).
                //            Replace("«NetAmt»", ViewModel.Sale.NetAmt.ToString());


                //        SMS.SMSHandler.SendSMS(txtSMSMobileNos.Text, txtSMSSenderID.Text, Msg, "Sale", Alit.Marker.Model.CommonProperties.LoginInfo.LoggedinUser.UserID);
                //    }
                //}
            }

            base.OnAfterSaving(Paras);
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            SaleInvoiceViewModel EditingRecord = (SaleInvoiceViewModel)RecordToFill;

            saleInvoiceProductDetailViewModelBindingSource.Clear();
            saleInvoiceAdditionalsViewModelBindingSource.Clear();

            //if (CommonProperties.LoginInfo.SoftwareSettings.ActivateSaleOrder)
            //{
            //    LoadSaleOrderDS(EditingRecord.SaleOrderID ?? 0);
            //    AssignSaleOrderDS();
            //}

            cmbMemoType.SelectedIndex = (int)EditingRecord.MemoType;

            OldInvalidDate = EditingRecord.SaleInvoiceDate;
            deInvoiceDate.EditValue = EditingRecord.SaleInvoiceDate;

            txtInvoiceNo.Text = EditingRecord.SaleInvoiceNo.ToString();

            OldSaleInvoiceNoPrefixID = EditingRecord.SaleInvoiceNoPrefixID;
            lookUpInvPrefix.EditValue = EditingRecord.SaleInvoiceNoPrefixID;

            OldSaleOrderID = EditingRecord.SaleOrderID ?? 0;

            ucCustomerSelection1.CustomerID = EditingRecord.CustomerAccountID;
            lookupEditSaleAccount.EditValue = EditingRecord.SaleAccountID;
            lookupEditVoucherType1.EditValue = EditingRecord.VoucherTypeID;

            lookupSaleOrder.EditValueChanged -= LookupSaleOrder_EditValueChanged;
            lookupSaleOrder.EditValue = EditingRecord.SaleOrderID;
            lookupSaleOrder.EditValueChanged += LookupSaleOrder_EditValueChanged;

            txtChallanNo.Text = EditingRecord.ChallanNo;
            deChallanDate.EditValue = EditingRecord.ChallanDate;
            txtOrderNo.Text = EditingRecord.OrderNo;
            deOrderDate.EditValue = EditingRecord.OrderDate;
            txtSuppRefNo.Text = EditingRecord.SupplierReferenceNo;
            txtOtherRefNo.Text = EditingRecord.OtherReferenceNo;

            txtNoOfPackets.Text = EditingRecord.NofPackets;
            txtDispDestination.Text = EditingRecord.Destination;
            deDispDocDate.EditValue = EditingRecord.DeliveryDate;
            txtDispDocNo.Text = EditingRecord.DispatchDocumentNo;

            lookUpPriceList.EditValue = EditingRecord.PriceListID;

            lookupDispTransport.EditValue = EditingRecord.TransportID;

            txtMemo.Text = EditingRecord.InvoiceMemo;
            AccountVoucherID = EditingRecord.AccountVoucherID;

            foreach (SaleInvoiceProductDetailViewModel SaleInvoiceProductDetailViewModel in EditingRecord.ProductDetail)
            {
                saleInvoiceProductDetailViewModelBindingSource.Add(SaleInvoiceProductDetailViewModel);
            }

            foreach (SaleInvoiceAdditionalsViewModel AdditionalView in EditingRecord.AdditionalItems.Where(r => r.RecordType != eAdditionalRecordType.RoundedOff))
            {
                saleInvoiceAdditionalsViewModelBindingSource.Add(AdditionalView);
            }
            //--

            RoundOffAmt = EditingRecord.RoundOffAmt;
            NetAmt = EditingRecord.NetAmt;

            txtAdvanceAmt.EditValue = EditingRecord.AdvanceAmt;
            AdvanceOldAmt = EditingRecord.AdvanceAmt;
            AdvanceOldRecieptID = EditingRecord.AdvanceOldRecieptID;

            gridViewProductDetail.UpdateSummary();
            gridViewAdditionals.UpdateSummary();

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        protected override XtraReport GeneratePrintDocument(long PrimeKeyID)
        {
            return frmSaleInvoiceDashboard.GenerateSaleInvoiceReport(PrimeKeyID);
        }

        #endregion

        #region Product Detail Grid

        void saleInvoiceProductDetailViewModelBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                SaleInvoiceProductDetailViewModel NewRecord = ((SaleInvoiceProductDetailViewModel)saleInvoiceProductDetailViewModelBindingSource.List[e.NewIndex]);

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
                gridViewProductDetail.UpdateTotalSummary();
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
            if (((SaleInvoiceProductDetailViewModel)sender).Tax1ID.HasValue)
            {
                UpdateTaxAmt(((SaleInvoiceProductDetailViewModel)sender).Tax1ID.Value);
            }
        }
        void NewRecord_Tax2AmtChanged(object sender, Model.ValueChangedEventArgs e)
        {
            if (((SaleInvoiceProductDetailViewModel)sender).Tax2ID.HasValue)
            {
                UpdateTaxAmt(((SaleInvoiceProductDetailViewModel)sender).Tax2ID.Value);
            }
        }
        void NewRecord_Tax3AmtChanged(object sender, Model.ValueChangedEventArgs e)
        {
            if (((SaleInvoiceProductDetailViewModel)sender).Tax3ID.HasValue)
            {
                UpdateTaxAmt(((SaleInvoiceProductDetailViewModel)sender).Tax3ID.Value);
            }
        }

        void NewRecord_NetAmtChanged(object sender, ValueChangedEventArgs e)
        {
            //gridViewProductDetail.UpdateSummary();
            //gridViewProductDetail.UpdateGroupSummary();
            //gridViewProductDetail.UpdateTotalSummary();
            gridViewProductDetail.PostEditor();
            gridViewProductDetail.UpdateCurrentRow();
            UpdateAdditionalsAmount(0);
        }

        private void gridViewProductDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            SaleInvoiceProductDetailViewModel CurrentRow = ((SaleInvoiceProductDetailViewModel)gridViewProductDetail.GetRow(e.RowHandle));
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
                    if (Product != null)
                    {
                        SelectProduct(StockItemDAL.GetViewModelByPrimeKey(Product.ProductID), CurrentRow);
                    }
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
            else if (e.Column == colGAmt)
            {
                if (e.Value != null)
                {
                    decimal NetAmt = (decimal)e.Value;
                    if (NetAmt != 0)
                    {
                        if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceGAmtEditReverseEffectOn == Model.Settings.ApplicationSettings.eSaleinvoiceGAmtEditReverseEffectOn.Rate)
                        {
                            CurrentRow.Rate = Math.Round(CurrentRow.GAmt / CurrentRow.Quantity, 2);
                        }
                        else
                        {
                            CurrentRow.Quantity = Math.Round(CurrentRow.GAmt / CurrentRow.Rate, 2);
                        }
                    }
                }
            }
        }

        public void SelectProduct(StockItemViewModel ProductViewModel, int RowHandel)
        {
            SelectProduct(ProductViewModel, (SaleInvoiceProductDetailViewModel)gridViewProductDetail.GetRow(RowHandel));
        }

        public void SelectProduct(StockItemViewModel ProductViewModel, SaleInvoiceProductDetailViewModel RowViewModel)
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
                    var RateRecord = ProductViewModel.SaleRate.FirstOrDefault(r => r.PriceListID == PriceListID);
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
            object Row = gridViewProductDetail.GetRow(e.RowHandle);
            if (Row != null)
            {
                SaleInvoiceProductDetailViewModel NewRecord = ((SaleInvoiceProductDetailViewModel)Row);
                //((SaleInvoiceProductDetailViewModel)Row).Rate = ColorRate;
                NewRecord.Quantity = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDefaultQuan;
                if (DefaultUnitID.HasValue) NewRecord.UnitID = DefaultUnitID.Value;
            }
        }

        private void gridViewProductDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (e.Row == null) return;
            SaleInvoiceProductDetailViewModel ProductRow = (SaleInvoiceProductDetailViewModel)e.Row;
            if (CommonProperties.LoginInfo.SoftwareSettings.MaintainProducts && ProductRow.ProductID == 0 && String.IsNullOrWhiteSpace(ProductRow.ProductName))
            {
                e.Valid = false;
                e.ErrorText = "Product no selected or product name not entered";
            }
            else
            {
                e.Valid = true;
                e.ErrorText = "";
            }
        }

        private void gridViewProductDetail_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            UpdateGrossAmt();
        }

        private void gridControlProductDetail_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider.SetError(gridControlProductDetail, "");
            if (CommonProperties.LoginInfo.SoftwareSettings.MaintainProducts)
            {
                if (saleInvoiceProductDetailViewModelBindingSource.Cast<SaleInvoiceProductDetailViewModel>().Count(r => r.ProductID == 0 && String.IsNullOrWhiteSpace(r.ProductName) && r.Quantity != 0) > 0)
                {
                    ErrorProvider.SetError(gridControlProductDetail, "Product is required. Please select a product.");
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

        #endregion

        /// <summary>
        /// After changing Gross Amt this method should exexute to update additional amout and net amount
        /// </summary>

        #region Methods
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
            foreach (var AddRecord in (IList<SaleInvoiceAdditionalsViewModel>)saleInvoiceAdditionalsViewModelBindingSource.List)
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
            NetAmt = Math.Round(UpdatedAmt + RoundOffAmt, CommonProperties.UIDataFormats.AmountDecimalLen);
        }

        void LoadSaleOrderInContent()
        {
            if (lookupSaleOrder.EditValue == null)
            {
                ucCustomerSelection1.Enabled = true;
            }
            if (!LookupSaleOrderValueChanged)
            {
                return;
            }
            LookupSaleOrderValueChanged = false;
            saleInvoiceProductDetailViewModelBindingSource.Clear();
            saleInvoiceAdditionalsViewModelBindingSource.Clear();
            UpdateGrossAmt();
            if (lookupSaleOrder.EditValue == null)
            {
                return;
            }
            if ((long)lookupSaleOrder.EditValue == -1)
            {
                lookupSaleOrder.EditValue = null;
                return;
            }
            long SaleOrderID = (long)lookupSaleOrder.EditValue;

            SaleOrderViewModel EditingRecord = SaleOrderDALObj.GetViewModelByPrimeKey(SaleOrderID);

            ucCustomerSelection1.CustomerID = EditingRecord.CustomerID;
            ucCustomerSelection1.Enabled = false;
            ErrorProvider.SetError(ucCustomerSelection1, null);
            //--
            txtMemo.Text = EditingRecord.OrderMemo;

            foreach (SaleOrderProductDetailViewModel SaleOrderProductViewModel in EditingRecord.ProductDetails)
            {
                StockItemLookupListModel Product = ProductLookUpListDataSource.FirstOrDefault(r => r.ProductID == SaleOrderProductViewModel.ProductID);
                if (Product == null)
                {
                    continue;
                }
                SaleInvoiceProductDetailViewModel ProductRecord = new SaleInvoiceProductDetailViewModel(true)
                {
                    //SaleDetailID = ProductSaveModel.SaleProductDetailID,
                    ProductID = SaleOrderProductViewModel.ProductID ?? 0,
                    ProductDescr = SaleOrderProductViewModel.ProductDescr,

                    Rate = SaleOrderProductViewModel.Rate,
                    UnitID = SaleOrderProductViewModel.UnitID,
                    DiscPerc = SaleOrderProductViewModel.DiscPerc,
                    DiscAmt = SaleOrderProductViewModel.DiscAmt,

                    Tax1ID = SaleOrderProductViewModel.Tax1ID,
                    Tax1Perc = SaleOrderProductViewModel.Tax1Perc,
                    Tax1Amt = SaleOrderProductViewModel.Tax1Amt,

                    Tax2ID = SaleOrderProductViewModel.Tax2ID,
                    Tax2Perc = SaleOrderProductViewModel.Tax2Perc,
                    Tax2Amt = SaleOrderProductViewModel.Tax2Amt,

                    Tax3ID = SaleOrderProductViewModel.Tax3ID,
                    Tax3Perc = SaleOrderProductViewModel.Tax3Perc,
                    Tax3Amt = SaleOrderProductViewModel.Tax3Amt,

                    GAmt = SaleOrderProductViewModel.GAmt,
                    NetAmt = SaleOrderProductViewModel.NetAmt,
                };

                if (SaleOrderProductViewModel.ProductID.HasValue)
                {
                    ProductRecord.ProductName = SaleOrderProductViewModel.ProductName;
                    ProductRecord.Barcode = SaleOrderProductViewModel.Barcode;
                    ProductRecord.PCode = SaleOrderProductViewModel.PCode;
                }

                saleInvoiceProductDetailViewModelBindingSource.Add(ProductRecord);
                ProductRecord.Quantity = SaleOrderProductViewModel.Quantity;

                ProductRecord.ResumeCalculationAndEventRaiser();
            }

            // not fetching round off record.
            foreach (SaleOrderAdditionalsViewModel AdditionalView in EditingRecord.AdditionalItems.Where(r => r.RecordType != eAdditionalRecordType.RoundedOff))
            {
                SaleInvoiceAdditionalsViewModel AdditionalItem = new SaleInvoiceAdditionalsViewModel(
                    AdditionalItemID: AdditionalView.AdditionalItemID,
                    AdditionalItemName: (AdditionalView.AdditionalItemID != null ? AdditionalView.AdditionalItemName : null),
                    suspendCalculationAndEventRaiser: true,
                    ItemDescr: AdditionalView.ItemDescr,
                    ItemNature: (eAdditionalItemNature)AdditionalView.ItemNature,
                    Perc: AdditionalView.Perc,
                    CalculatedOnAmt: AdditionalView.CalculatedOnAmt,
                    UpdatedAmt: AdditionalView.UpdatedAmt,
                    Amt: AdditionalView.Amt
                );
                AdditionalItem.ResumeCalculationAndEventRaiser();
                saleInvoiceAdditionalsViewModelBindingSource.Add(AdditionalItem);
            }
            ReSetTaxRecords();

            NetAmt = EditingRecord.NetAmt;

            gridViewProductDetail.UpdateSummary();
            gridViewAdditionals.UpdateSummary();
        }

        private void FillCustomerInfoInControls()
        {
            var SelectedCustomer = ucCustomerSelection1.GetSelectedRecord();
            if (SelectedCustomer != null)
            {
                if (lcgSMS.Visible)
                {
                    chkbSendSMS.EditValue = SelectedCustomer.AllowSendSMS;
                    txtSMSMobileNos.Text = SelectedCustomer.MobileNo;
                }
                if (SelectedCustomer.PriceListID != null)
                {
                    lookUpPriceList.EditValue = SelectedCustomer.PriceListID;
                }
            }

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
                SelectAdditionalItem(AddItem, (SaleInvoiceAdditionalsViewModel)gridViewAdditionals.GetRow(e.RowHandle));
            }
            else if (e.Column.FieldName == "Perc")
            {
                decimal Perc = 0;
                decimal.TryParse((e.Value ?? "0").ToString(), out Perc);
                if (Perc != 0)
                {
                    SaleInvoiceAdditionalsViewModel Row = (SaleInvoiceAdditionalsViewModel)gridViewAdditionals.GetRow(e.RowHandle);
                    if (Row.CalculatedOnAmt == 0)
                    {
                        Row.CalculatedOnAmt = GrossAmt;
                    }
                }
            }
        }

        void SelectAdditionalItem(AdditionalItemViewModel AddItem, SaleInvoiceAdditionalsViewModel RowViewModel)
        {
            if (RowViewModel == null) return;
            if (AddItem != null)
            {
                RowViewModel.AdditionalItemID = AddItem.AdditionalItemID;
                RowViewModel.AdditionalItemName = AddItem.ItemName;
                RowViewModel.ItemNature = AddItem.Nature;
                RowViewModel.IsInclusive = AddItem.InclusiveTax;
                RowViewModel.Perc = AddItem.Perc;
                RowViewModel.CalculateOn = (eCalculateOn)AddItem.CalculateOn;
                RowViewModel.CalculatePercRev = AddItem.ReverseCalculatePercentage;

                if (RowViewModel.CalculateOn == eCalculateOn.GrossAmt)
                {
                    RowViewModel.CalculatedOnAmt = GrossAmt;
                }
                else
                {
                    int RowIndex = saleInvoiceAdditionalsViewModelBindingSource.IndexOf(RowViewModel);
                    if (RowIndex == 0)
                    {
                        RowViewModel.CalculatedOnAmt = GrossAmt;
                    }
                    else
                    {
                        RowViewModel.CalculatedOnAmt = ((SaleInvoiceAdditionalsViewModel)saleInvoiceAdditionalsViewModelBindingSource[RowIndex - 1]).UpdatedAmt;
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

            if (ReloadBinding) saleInvoiceAdditionalsViewModelBindingSource.SuspendBinding();

            decimal UpdatedAmt = (FromRowIndex > 0 ? ((SaleInvoiceAdditionalsViewModel)saleInvoiceAdditionalsViewModelBindingSource[FromRowIndex - 1]).UpdatedAmt : GrossAmt);

            for (int RowIndex = FromRowIndex; RowIndex < saleInvoiceAdditionalsViewModelBindingSource.Count; RowIndex++)
            {
                var AddRecord = (SaleInvoiceAdditionalsViewModel)saleInvoiceAdditionalsViewModelBindingSource[RowIndex];

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
                                    AddRecord.CalculatedOnAmt = ((SaleInvoiceAdditionalsViewModel)saleInvoiceAdditionalsViewModelBindingSource[RowIndex - 1]).UpdatedAmt;
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
            NetAmt = Math.Round(UpdatedAmt + RoundOffAmt, CommonProperties.UIDataFormats.AmountDecimalLen);

            if (ReloadBinding)
            {
                saleInvoiceAdditionalsViewModelBindingSource.ResumeBinding();
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
            saleInvoiceAdditionalsViewModelBindingSource.SuspendBinding();
            if (TaxID != 0)
            {
                SaleInvoiceAdditionalsViewModel TaxRecord;
                TaxRecord = saleInvoiceAdditionalsViewModelBindingSource.Cast<SaleInvoiceAdditionalsViewModel>().FirstOrDefault(r => r.AdditionalItemID == TaxID);
                if (TaxRecord == null)
                {
                    AdditionalItemLookupModel TaxItem = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == TaxID);
                    AdditionalItemViewModel TaxMaster = null;
                    if (TaxItem.AdditionalItemID.HasValue)
                    {
                        TaxMaster = AdditionalItemsDAL.GetViewModelByPrimeKey(TaxItem.AdditionalItemID.Value);
                    }

                    TaxRecord = new SaleInvoiceAdditionalsViewModel()
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
                    saleInvoiceAdditionalsViewModelBindingSource.Add(TaxRecord);
                }
                else if (FormCurrentUI != eFormCurrentUI.NewEntry) // Condition added for editing and deleting. After record selection in edit window, in add/less window add/less tax record will exists but in additional  data source record will not be there. So that We have to add Tax master record in Additional lookup list.
                {
                    if (AdditionalItemLookUpListDataSource.FirstOrDefault(r => r.AdditionalItemID == TaxID) == null)
                    {
                        AdditionalItemLookupModel TaxItem = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == TaxID);
                        if (TaxItem != null && TaxItem.AdditionalItemID.HasValue)
                        {
                            AdditionalItemLookUpListDataSource.Add(TaxItem);
                        }
                    }
                }

                var ProductsOfSelectedTax = saleInvoiceProductDetailViewModelBindingSource.Cast<SaleInvoiceProductDetailViewModel>().Where(r => r.Tax1ID == TaxID || r.Tax2ID == TaxID || r.Tax3ID == TaxID);
                decimal TaxAmt = ProductsOfSelectedTax.Sum(r => (r.Tax1ID == TaxID ? r.Tax1Amt : 0) + (r.Tax2ID == TaxID ? r.Tax2Amt : 0) + (r.Tax3ID == TaxID ? r.Tax3Amt : 0));
                decimal CalculatedOnAmt = ProductsOfSelectedTax.Sum(r => r.NetAmt);

                TaxRecord.CalculatedOnAmt = CalculatedOnAmt;
                TaxRecord.Amt = TaxAmt;
                //TaxRecord.ItemDescr = TaxRecord.AdditionalItemName + " @ " + TaxRecord.CalculatedOnAmt.ToString(Model.CommonProperties.UIDataFormats.AmountFormat);

                UpdateAdditionalsAmount(0, true);
            }
            saleInvoiceAdditionalsViewModelBindingSource.ResumeBinding();
            gridViewAdditionals.LayoutChanged();
        }

        public void ReSetTaxRecords()
        {
            List<long> TaxSumm = (from R in
                                  saleInvoiceProductDetailViewModelBindingSource.Cast<SaleInvoiceProductDetailViewModel>()
                                  where R.Tax1ID != null
                                  group R by R.Tax1ID into GR
                                  select new { TaxID = GR.Key.Value }).Select<dynamic, long>(r => r.TaxID).ToList();

            long[] TaxSumm2 = (from R in
                                  saleInvoiceProductDetailViewModelBindingSource.Cast<SaleInvoiceProductDetailViewModel>()
                               where R.Tax2ID != null
                               group R by R.Tax2ID into GR
                               select new { TaxID = GR.Key.Value }).Select<dynamic, long>(r => r.TaxID).ToArray();
            if (TaxSumm2 != null && TaxSumm2.Count() > 0)
            {
                TaxSumm.AddRange(TaxSumm2);
            }

            long[] TaxSumm3 = (from R in
                                  saleInvoiceProductDetailViewModelBindingSource.Cast<SaleInvoiceProductDetailViewModel>()
                               where R.Tax3ID != null
                               group R by R.Tax3ID into GR
                               select new { TaxID = GR.Key.Value }).Select<dynamic, long>(r => r.TaxID).ToArray();

            if (TaxSumm3 != null && TaxSumm3.Count() > 0)
            {
                TaxSumm.AddRange(TaxSumm3);
            }

            var TaxRecordsToDelete = saleInvoiceAdditionalsViewModelBindingSource.Cast<SaleInvoiceAdditionalsViewModel>().Where(r =>
                r.RecordType == eAdditionalRecordType.Tax &&
                !TaxSumm.Contains(r.AdditionalItemID ?? 0)).ToList();

            foreach (var Record in TaxRecordsToDelete)
            {
                saleInvoiceAdditionalsViewModelBindingSource.Remove(Record);
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
                SaleInvoiceAdditionalsViewModel SIAVM = (SaleInvoiceAdditionalsViewModel)saleInvoiceAdditionalsViewModelBindingSource.List[e.NewIndex];
                SIAVM.AmtChanged -= frmSale_AdditionalItemAmtChanged;
                SIAVM.AmtChanged += frmSale_AdditionalItemAmtChanged;
                SIAVM.ItemNatureChanged -= SIAVM_ItemNatureChanged;
                SIAVM.ItemNatureChanged += SIAVM_ItemNatureChanged;
            }
            else if (e.ListChangedType == ListChangedType.Reset)
            {
                foreach (var item in saleInvoiceAdditionalsViewModelBindingSource)
                {
                    SaleInvoiceAdditionalsViewModel SIAVM = (SaleInvoiceAdditionalsViewModel)item;
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
            int RowIndex = saleInvoiceAdditionalsViewModelBindingSource.IndexOf(sender);
            UpdateAdditionalsAmount(RowIndex);
        }

        void frmSale_AdditionalItemAmtChanged(object sender, Model.ValueChangedEventArgs e)
        {
            int RowIndex = saleInvoiceAdditionalsViewModelBindingSource.IndexOf(sender);
            UpdateAdditionalsAmount(RowIndex);
        }

        #endregion

        #region Form Events
        private void deInvoiceDate_EditValueChanged(object sender, EventArgs e)
        {
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoAutoGenerate)
            {

                if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoSeries != null &&
                    (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoSeries.Contains("Date") ||
                    Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoSeries.Contains("MonthYear") ||
                    Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoSeries.Contains("Year")))
                {
                    if (OldInvalidDate != (DateTime?)deInvoiceDate.EditValue)
                    {
                        GenerateNewInvoiceNumber();
                    }
                    OldInvalidDate = (DateTime?)deInvoiceDate.EditValue;
                }
            }
        }

        private void ucCustomerSelection1_CustomerIDChanged(object sender, EventArgs e)
        {
            FillCustomerInfoInControls();
        }

        private void lookUpInvPrefix_EditValueChanged(object sender, EventArgs e)
        {
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoAutoGenerate &&
                (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoSeries ?? "").Contains("Prefix"))
            {
                if (OldSaleInvoiceNoPrefixID != (long?)lookUpInvPrefix.EditValue)
                {
                    GenerateNewInvoiceNumber();
                }
                OldSaleInvoiceNoPrefixID = (long?)lookUpInvPrefix.EditValue;
            }
        }

        private void barbtnGridAddRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridViewProductDetail.GridControl.ContainsFocus)
            {
                if (gridViewProductDetail.GetVisibleIndex(gridViewProductDetail.FocusedRowHandle) < (gridViewProductDetail.RowCount - 1))
                {
                    int newInex = saleInvoiceProductDetailViewModelBindingSource.IndexOf(saleInvoiceProductDetailViewModelBindingSource.Current);
                    newInex = Math.Max(Math.Min(newInex, saleInvoiceProductDetailViewModelBindingSource.Count - 1), 0);
                    saleInvoiceProductDetailViewModelBindingSource.Insert(newInex, new SaleInvoiceProductDetailViewModel());
                }
                else
                {
                    gridViewProductDetail.AddNewRow();
                }
            }
            else if (gridViewAdditionals.GridControl.ContainsFocus)
            {
                if (gridViewAdditionals.GetVisibleIndex(gridViewAdditionals.FocusedRowHandle) < (gridViewAdditionals.RowCount - 1))
                {
                    int newInex = saleInvoiceAdditionalsViewModelBindingSource.IndexOf(saleInvoiceAdditionalsViewModelBindingSource.Current);
                    newInex = Math.Max(Math.Min(newInex, saleInvoiceAdditionalsViewModelBindingSource.Count - 1), 0);
                    saleInvoiceAdditionalsViewModelBindingSource.Insert(newInex, new SaleInvoiceAdditionalsViewModel());
                }
                else
                {
                    gridViewAdditionals.AddNewRow();
                }
            }
        }

        private void barBtnGridDeleteRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridViewProductDetail.GridControl.ContainsFocus)
            {
                GridView view = gridViewProductDetail;

                if (view == null || view.SelectedRowsCount == 0) return;

                SaleInvoiceProductDetailViewModel[] rows = new SaleInvoiceProductDetailViewModel[view.SelectedRowsCount];
                int[] SelectedRowsHandles = view.GetSelectedRows();

                for (int i = 0; i < view.SelectedRowsCount; i++)
                {
                    rows[i] = (SaleInvoiceProductDetailViewModel)view.GetRow(SelectedRowsHandles[i]);
                }


                view.BeginUpdate();

                foreach (SaleInvoiceProductDetailViewModel row in rows)
                {
                    saleInvoiceProductDetailViewModelBindingSource.List.Remove(row);
                }

                view.EndUpdate();
            }
            else
            {
                GridView view = gridViewAdditionals;

                if (view == null || view.SelectedRowsCount == 0) return;

                SaleInvoiceAdditionalsViewModel[] rows = new SaleInvoiceAdditionalsViewModel[view.SelectedRowsCount];
                int[] SelectedRowsHandles = view.GetSelectedRows();

                for (int i = 0; i < view.SelectedRowsCount; i++)
                {
                    rows[i] = (SaleInvoiceAdditionalsViewModel)view.GetRow(SelectedRowsHandles[i]);
                }


                view.BeginUpdate();

                foreach (SaleInvoiceAdditionalsViewModel row in rows)
                {
                    saleInvoiceAdditionalsViewModelBindingSource.List.Remove(row);
                }

                view.EndUpdate();
            }
        }

        bool LookupSaleOrderValueChanged;
        private void LookupSaleOrder_EditValueChanged(object sender, EventArgs e)
        {
            LookupSaleOrderValueChanged = true;
        }

        private void lookupSaleOrder_Enter(object sender, EventArgs e)
        {
            LookupSaleOrderValueChanged = false;
        }

        private void lookupSaleOrder_Leave(object sender, EventArgs e)
        {
            LoadSaleOrderInContent();
        }

        private void lookupSaleOrder_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (e.CloseMode != PopupCloseMode.Cancel)
            {
                LoadSaleOrderInContent();
            }
        }

        private void lookupSaleOrder_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Search)
            //{
            //    Template.frmEditList frmSearchSaleOrder = new Template.frmEditList();
            //    frmSearchSaleOrder.UpdateDataSource(SaleOrderDALObj.GetPendingSaleOrders(OldSaleOrderID));
            //    frmSearchSaleOrder.Text = "Select Sale Order";
            //    frmSearchSaleOrder.ShowDialog(this);
            //    if (frmSearchSaleOrder.SelectedRecord != null)
            //    {
            //        lookupSaleOrder.EditValue = ((SaleOrderLookupListModel)frmSearchSaleOrder.SelectedRecord).SaleOrderID;
            //    }
            //}
            //else if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Redo)
            //{
            //    LoadSaleOrderDS();
            //    lookupSaleOrder.ShowPopup();
            //}
        }

        private void cmbMemoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((eMemoType)cmbMemoType.SelectedIndex == eMemoType.Cash)
            {
                txtAdvanceAmt.EditValue = 0M;
                txtAdvanceAmt.Enabled = false;

                ucCustomerSelection1.LookupEditAccountFilter.AccountGroupTypeFilter = new eAccountGroupType[] { eAccountGroupType.CashInHand };
            }
            else
            {
                txtAdvanceAmt.Enabled = true;
                ucCustomerSelection1.LookupEditAccountFilter.AccountGroupTypeFilter = new eAccountGroupType[] { eAccountGroupType.SundryDebtors };
            }
            ucCustomerSelection1.LookupEditAccountFilter.ReloadDataSource();
            ucCustomerSelection1.LookupEditAccountFilter.EditValue = null;
        }

        private void repositoryItembtnDeleteRowPDetail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Row = gridViewProductDetail.GetFocusedRow();
            if (Row == null)
            {
                return;
            }
            saleInvoiceProductDetailViewModelBindingSource.Remove(Row);
        }

        private void repositoryItembtnDeleteRowAdditional_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Row = gridViewAdditionals.GetFocusedRow();

            if (Row == null)
            {
                return;
            }
            saleInvoiceAdditionalsViewModelBindingSource.Remove(Row);
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
                (EditingRecord != null && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                    (long?)(Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoPrefix ? lookUpInvPrefix.EditValue : null),
                    (DateTime?)deInvoiceDate.EditValue))
            {
                ErrorProvider.SetError(txtInvoiceNo, "Can not accept duplicate Invoice Number.");
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
                ErrorProvider.SetError(deInvoiceDate, "Receipt Date is required.");
            }
            else
            {
                DateTime dt = (DateTime)deInvoiceDate.EditValue;

                if (dt < CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom || dt > CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo)
                {
                    ErrorProvider.SetError(deInvoiceDate, "Date should be with in current financial period that started from " + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.ToShortDateString() + (CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.HasValue ? " Upto " + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.ToShortDateString() : ""));
                }
                else
                {
                    ErrorProvider.SetError(deInvoiceDate, null);
                }
            }
        }

        private void lookUpInvPrefix_Validating(object sender, CancelEventArgs e)
        {
            if ((lookUpInvPrefix.EditValue == null || (long)lookUpInvPrefix.EditValue == -1) && String.IsNullOrWhiteSpace(lookUpInvPrefix.Text))
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
                ErrorProvider.SetError(txtSMSMobileNos, "Please enter mobile number.");
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

        #endregion

        private void lookupSaleOrder_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
            {
                lookupSaleOrder.EditValue = null;
                if (ucCustomerSelection1.Enabled == false)
                {
                    ucCustomerSelection1.Enabled = true;
                    //ucCustomerSelection1.LookupEditFilter.EditValue = null;
                }
            }
        }

        private void lookupDispTransport_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
            {
                lookupDispTransport.EditValue = null;
            }
        }
    }
}
