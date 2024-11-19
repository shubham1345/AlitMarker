using Alit.Marker.Model;
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
using Alit.Marker.Model.Inventory.Masters.StockItemTaxCategory;
using Alit.Marker.DAL.Inventory.Masters.StockItemTaxCategory;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Inventory.Masters.StockItemTaxCategory
{
    public partial class frmStockItemTaxCategoryCRUD : Template.frmCRUDTemplate
    {
        StockItemTaxCategoryDAL DALObject;

        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new StockItemTaxCategoryDAL();
                }
                return DALObject;
            }
        }

        public frmStockItemTaxCategoryCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmStockItemTaxCategoryCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new StockItemTaxCategoryDAL();
        }

        #region Overriden Method

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new StockItemTaxCategoryViewModel()
            {
                ProductTaxCategoryName = txtProductTaxCategoryName.Text,
                IsInterstateTax = chkbInterStateTax.Checked,
                Applicable = cmbApplicable.SelectedIndex == 1,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            StockItemTaxCategoryViewModel EditingRecord = (StockItemTaxCategoryViewModel)RecordToFill;

            txtTaxIndex.EditValue = EditingRecord.TaxIndex;
            txtProductTaxCategoryName.Text = EditingRecord.ProductTaxCategoryName;
            chkbInterStateTax.Checked = EditingRecord.IsInterstateTax;
            cmbApplicable.SelectedIndex = (EditingRecord.Applicable ? 1 : 0);

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }
        #endregion

        #region Validation
        private void txtProductTaxCategoryName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtProductTaxCategoryName.Text))
            {
                ErrorProvider.SetError(txtProductTaxCategoryName, "Please enter Stock Item Tax Category Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtProductTaxCategoryName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtProductTaxCategoryName, "Can not accept duplicate Stock Item Tax Category Name.");
            }
            else
            {
                ErrorProvider.SetError(txtProductTaxCategoryName, null);
            }
        }
        #endregion
    }
}
