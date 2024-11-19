using Alit.Marker.DAL.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model;
using Alit.Marker.Model.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix;
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

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix
{
    public partial class frmSaleReturnNoPrefixCRUD : Template.frmCRUDTemplate
    {
        SaleReturnNoPrefixDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new SaleReturnNoPrefixDAL();
                }

                return DALObject;
            }
        }
        
        public frmSaleReturnNoPrefixCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmSaleReturnNoPrefixCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new SaleReturnNoPrefixDAL();
        }

        #region Overriden Method
        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new SaleReturnNoPrefixViewModel()
            {
                SaleReturnNoPrefixID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                PrefixName = txtSaleReturnNoPrefix.Text,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            SaleReturnNoPrefixViewModel EditingRecord = (SaleReturnNoPrefixViewModel)RecordToFill;

            txtSaleReturnNoPrefix.Text = EditingRecord.PrefixName;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }
        #endregion

        #region Validation
        private void txtPrefixName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSaleReturnNoPrefix.Text))
            {
                ErrorProvider.SetError(txtSaleReturnNoPrefix, "Please enter Prefix Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtSaleReturnNoPrefix.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtSaleReturnNoPrefix, "Can not accept duplicate Prefix Name.");
            }
            else
            {
                ErrorProvider.SetError(txtSaleReturnNoPrefix, null);
            }
        }
        #endregion
        
    }
}
