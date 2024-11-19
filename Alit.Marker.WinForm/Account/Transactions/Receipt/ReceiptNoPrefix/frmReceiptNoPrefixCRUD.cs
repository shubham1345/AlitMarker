using Alit.Marker.DAL.Template;
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
using Alit.Marker.Model.Account.Transactions.Receipt.ReceiptNoPrefix;
using Alit.Marker.DAL.Account.Transactions.Receipt.ReceiptNoPrefix;

namespace Alit.Marker.WinForm.Account.Transactions.Receipt.ReceiptNoPrefix
{
    public partial class frmReceiptNoPrefixCRUD : Template.frmCRUDTemplate
    {
        ReceiptNoPrefixDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new ReceiptNoPrefixDAL();
                }

                return DALObject;
            }
        }

        public frmReceiptNoPrefixCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmReceiptNoPrefixCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new ReceiptNoPrefixDAL();
        }

        #region Overriden Methods
        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new ReceiptNoPrefixViewModel()
            {
                ReceiptNoPrefixID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord == null ? EditingRecord.PrimeKeyID : 0),
                PrefixName = txtReceiptNoPrefix.Text,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            ReceiptNoPrefixViewModel EditingRecord = (ReceiptNoPrefixViewModel)RecordToFill;

            txtReceiptNoPrefix.Text = EditingRecord.PrefixName;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }
        #endregion

        #region Validation
        private void txtPrefixName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtReceiptNoPrefix.Text))
            {
                ErrorProvider.SetError(txtReceiptNoPrefix, "Please enter Prefix Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtReceiptNoPrefix.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtReceiptNoPrefix, "Can not accept duplicate Prefix Name.");
            }
            else
            {
                ErrorProvider.SetError(txtReceiptNoPrefix, null);
            }
        }
        #endregion
    }
}
