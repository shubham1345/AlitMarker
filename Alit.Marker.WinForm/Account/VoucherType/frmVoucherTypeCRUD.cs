using Alit.Marker.DAL.Template;
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
using Alit.Marker.Model.Account.VoucherType;

namespace Alit.Marker.WinForm.Account.VoucherType
{
    public partial class frmVoucherTypeCRUD : Template.frmCRUDTemplate
    {
        DAL.Account.VoucherType.VoucherTypeDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new DAL.Account.VoucherType.VoucherTypeDAL();
                }

                return DALObject;
            }
        }

        public frmVoucherTypeCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmVoucherTypeCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new DAL.Account.VoucherType.VoucherTypeDAL();
        }

        #region Overriden Method

        protected override void OnInitializeDefaultValues()
        {
            cmbPrimaryVoucherType.SelectedIndex = 0;
            base.OnInitializeDefaultValues();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new VoucherTypeViewModel()
            {
                VoucherTypeID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                VoucherTypeName = txtVoucherTypeName.Text,
                PrimaryVoucherType = (ePrimaryVoucherType)cmbPrimaryVoucherType.SelectedIndex,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            VoucherTypeViewModel ViewModel = (VoucherTypeViewModel)RecordToFill;
            txtVoucherTypeName.Text = ViewModel.VoucherTypeName;
            cmbPrimaryVoucherType.SelectedIndex = (int)ViewModel.PrimaryVoucherType;

            return base.OnFillSelectedRecordInContent(RecordToFill);
        }
        #endregion

        #region Validation

        private void txtVoucherTypeName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVoucherTypeName.Text))
            {
                ErrorProvider.SetError(txtVoucherTypeName, "Please enter Voucher Type Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtVoucherTypeName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtVoucherTypeName, "Can not accept duplicate Voucher Type Name.");
            }
            else
            {
                ErrorProvider.SetError(txtVoucherTypeName, null);
            }
        }

        #endregion
    }
}
