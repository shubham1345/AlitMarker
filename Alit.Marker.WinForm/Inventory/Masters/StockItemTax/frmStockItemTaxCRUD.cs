using Alit.Marker.DAL;
using Alit.Marker.DAL.Inventory.Masters.StockItemTax;
using Alit.Marker.DAL.Inventory.Masters.StockItemTaxCategory;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model;
using Alit.Marker.Model.Inventory.Masters.StockItemTax;
using Alit.Marker.Model.Inventory.Masters.StockItemTaxCategory;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Inventory.Masters.StockItemTax
{
    public partial class frmStockItemTaxCRUD : Template.frmCRUDTemplate
    {
        StockItemTaxDAL DALObject;
        //AdditionalItemDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new StockItemTaxDAL();
                }

                return DALObject;
            }
        }

        StockItemTaxCategoryDAL SITaxCatDALObj;
        List<StockItemTaxCategoryLookUpListModel> dsStockItemTax;

        public frmStockItemTaxCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmStockItemTaxCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new StockItemTaxDAL();
            SITaxCatDALObj = new StockItemTaxCategoryDAL();
        }

        #region Overriden Method
        protected override void OnLoadLookupDataSource()
        {
            dsStockItemTax = SITaxCatDALObj.GetLookUpList();

            base.OnLoadLookupDataSource();
        }

        protected override void OnAssignLookupDataSource()
        {
            lookupProductTaxCategory.Properties.DisplayMember = "ProductTaxCategoryName";
            lookupProductTaxCategory.Properties.ValueMember = "ProductTaxCategoryID";
            lookupProductTaxCategory.Properties.DataSource = dsStockItemTax;

            base.OnAssignLookupDataSource();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new StockItemTaxViewModel()
            {
                AdditionalItemID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID: 0),
                ItemName = txtTaxName.Text,
                Perc = (decimal)txtPerc.EditValue,
                ProductTaxCategoryID = (long)lookupProductTaxCategory.EditValue,
            };

        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            StockItemTaxViewModel EditingRecord = (StockItemTaxViewModel)RecordToFill;

            txtTaxName.Text = EditingRecord.ItemName;
            txtPerc.EditValue= EditingRecord.Perc;
            chkbIsInclusive.Checked = EditingRecord.InclusiveTax;
            lookupProductTaxCategory.EditValue = EditingRecord.ProductTaxCategoryID;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        #endregion

        #region Validation
        private void txtTaxName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtTaxName.Text))
            {
                ErrorProvider.SetError(txtTaxName, "Please enter Tax Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtTaxName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtTaxName, "Can not accept duplicate Tax Name.");
            }
            else
            {
                ErrorProvider.SetError(txtTaxName, null);
            }
        }

        private void lookupProductTaxCategory_Validating(object sender, CancelEventArgs e)
        {
            if (lookupProductTaxCategory.EditValue == null)
            {
                ErrorProvider.SetError(lookupProductTaxCategory, "Please select a Category.");
            }
            else
            {
                ErrorProvider.SetError(lookupProductTaxCategory, null);
            }
        }
        #endregion
        
    }
}
