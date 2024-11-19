
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
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix;
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix
{
    public partial class frmSaleInvoiceNoPrefixCRUD : Template.frmCRUDTemplate
    {
        SaleInvoiceNoPrefixDAL DALObject;

        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new SaleInvoiceNoPrefixDAL();
                }

                return DALObject;
            }
        }

        public frmSaleInvoiceNoPrefixCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmSaleInvoiceNoPrefixCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new SaleInvoiceNoPrefixDAL();
        }

        #region Overriden Method
        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new SaleInvoiceNoPrefixViewModel()
            {
                SaleInvoiceNoPrefixID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                PrefixName = txtSaleInvoiceNoPrefix.Text,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            SaleInvoiceNoPrefixViewModel EditingRecord = (SaleInvoiceNoPrefixViewModel)RecordToFill;

            txtSaleInvoiceNoPrefix.Text = EditingRecord.PrefixName;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }
        #endregion

        #region Validation
        private void txtPrefixName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSaleInvoiceNoPrefix.Text))
            {
                ErrorProvider.SetError(txtSaleInvoiceNoPrefix, "Please enter Prefix Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtSaleInvoiceNoPrefix.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtSaleInvoiceNoPrefix, "Can not accept duplicate Prefix Name.");
            }
            else
            {
                ErrorProvider.SetError(txtSaleInvoiceNoPrefix, null);
            }
        }
        #endregion
    }
}
