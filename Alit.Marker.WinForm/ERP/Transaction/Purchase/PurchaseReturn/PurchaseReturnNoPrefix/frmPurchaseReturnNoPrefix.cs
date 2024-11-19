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
using Alit.Marker.Model.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix;
using Alit.Marker.DAL.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix;

namespace Alit.Marker.WinForm.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix
{
    public partial class frmPurchaseReturnNoPrefix : Template.frmCRUDTemplate
    {
        PurchaseReturnNoPrefixDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new PurchaseReturnNoPrefixDAL();
                }

                return DALObject;
            }
        }

        public frmPurchaseReturnNoPrefix() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry })
        { }

        public frmPurchaseReturnNoPrefix(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new PurchaseReturnNoPrefixDAL();
        }

        #region Overriden Method
        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new PurchaseReturnNoPrefixViewModel()
            {
                PurchaseReturnNoPrefixID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                PrefixName = txtPurchaseReturnNoPrefix.Text,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            PurchaseReturnNoPrefixViewModel EditingRecord = (PurchaseReturnNoPrefixViewModel)RecordToFill;

            txtPurchaseReturnNoPrefix.Text = EditingRecord.PrefixName;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }
        #endregion

        #region Validation
        private void txtPrefixName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPurchaseReturnNoPrefix.Text))
            {
                ErrorProvider.SetError(txtPurchaseReturnNoPrefix, "Please enter Prefix Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtPurchaseReturnNoPrefix.Text,
                (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtPurchaseReturnNoPrefix, "Can not accept duplicate Prefix Name.");
            }
            else
            {
                ErrorProvider.SetError(txtPurchaseReturnNoPrefix, null);
            }
        }
        #endregion
    }
}
