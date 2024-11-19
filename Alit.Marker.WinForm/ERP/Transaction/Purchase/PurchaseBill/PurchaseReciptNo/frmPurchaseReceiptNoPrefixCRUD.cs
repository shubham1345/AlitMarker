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
using Alit.Marker.Model.ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo;
using Alit.Marker.DAL.ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo;

namespace Alit.Marker.WinForm.ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo
{
    public partial class frmPurchaseReceiptNoPrefixCRUD : Template.frmCRUDTemplate
    {
        PurchaseReceiptNoPrefixDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new PurchaseReceiptNoPrefixDAL();
                }

                return DALObject;
            }
        }

        public frmPurchaseReceiptNoPrefixCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmPurchaseReceiptNoPrefixCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new PurchaseReceiptNoPrefixDAL();
        }

        #region Overriden Method
        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new PurchaseReceiptNoPrefixViewModel()
            {
                PurchaseReceiptNoPrefixID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                PrefixName = txtPurchaseReceiptNoPrefix.Text,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            PurchaseReceiptNoPrefixViewModel EditingRecord = (PurchaseReceiptNoPrefixViewModel)RecordToFill;

            txtPurchaseReceiptNoPrefix.Text = EditingRecord.PrefixName;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }
        #endregion

        #region Validation
        private void txtPrefixName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPurchaseReceiptNoPrefix.Text))
            {
                ErrorProvider.SetError(txtPurchaseReceiptNoPrefix, "Please enter Prefix Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtPurchaseReceiptNoPrefix.Text, 
                (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord == null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtPurchaseReceiptNoPrefix, "Can not accept duplicate Prefix Name.");
            }
            else
            {
                ErrorProvider.SetError(txtPurchaseReceiptNoPrefix, null);
            }
        }
        #endregion
    }
}
