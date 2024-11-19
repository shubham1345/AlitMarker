using Alit.Marker.DAL.Account.Account;
using Alit.Marker.DAL.Account.Transactions.ContraVoucher;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.Model.Account.Group;
using Alit.Marker.Model.Account.Transactions.ContraVoucher;
using Alit.Marker.Model.Account.VoucherType;
using Alit.Marker.Model.Template;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Account.Transactions.ContraVoucher
{
    public partial class frmContraVoucherCRUD : Template.frmCRUDTemplate
    {
        ContraVoucherDAL DALObject;
        AccountDAL AccountDAL;

        List<AccountLookUpListModel> dsAccount;
        List<ContraVoucherDetailViewModel> dsContraVoucher;
        List<VoucherTypeLookUpListModel> dsVoucherType;

        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new ContraVoucherDAL();
                }
                return DALObject;
            }
        }

        long AccountVoucherID;

        public frmContraVoucherCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmContraVoucherCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();

            DALObject = new ContraVoucherDAL();
            AccountDAL = new AccountDAL();

            dsContraVoucher = new List<ContraVoucherDetailViewModel>();
            ContraVoucherDetailViewModelBindingSource.DataSource = dsContraVoucher;
        }

        #region Overriden Methods
        protected override void OnLoadLookupDataSource()
        {
            eAccountGroupType[] AccountGroupTypes = new eAccountGroupType[] { eAccountGroupType.CashInHand, eAccountGroupType.BankAccounts };
            dsAccount = AccountDAL.GetLookupListFinal(AccountGroupTypes);
            base.OnLoadLookupDataSource();
        }

        protected override void OnAssignLookupDataSource()
        {
            repositoryItemlueAccount.DisplayMember = "AccountName";
            repositoryItemlueAccount.ValueMember = "AccountID";
            repositoryItemlueAccount.DataSource = dsAccount;
            base.OnAssignLookupDataSource();
        }

        protected override void OnAssignFormValues()
        {
            btnEditContraVoucherNo.EditValue = DALObject.GetMaxContraVoucherNo();
            deContraVoucherDate.DateTime = DateTime.Now;
            AssignVoucherType();
            base.OnAssignFormValues();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new ContraVoucherViewModel()
            {
                ContraVoucherID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                ContraVoucherNo = (int)btnEditContraVoucherNo.EditValue,
                ContraVoucherDate = (DateTime)deContraVoucherDate.EditValue,
                Narration = meNarration.Text,
                VoucherTypeID = (long)lookupEditVoucherType1.EditValue,
                AccountVoucherID = AccountVoucherID,
                CVDetails = dsContraVoucher,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            ContraVoucherViewModel EditingRecord = (ContraVoucherViewModel)RecordToFill;

            btnEditContraVoucherNo.EditValue = EditingRecord.ContraVoucherNo;
            deContraVoucherDate.EditValue = EditingRecord.ContraVoucherDate;
            meNarration.EditValue = EditingRecord.Narration;
            lookupEditVoucherType1.EditValue = EditingRecord.VoucherTypeID;
            meNarration.Text = EditingRecord.Narration;
            AccountVoucherID = EditingRecord.AccountVoucherID;

            dsContraVoucher = EditingRecord.CVDetails;
            ContraVoucherDetailViewModelBindingSource.DataSource = dsContraVoucher;
            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        protected override bool OnValidateBeforeSave()
        {
            gvContraVoucher.PostEditor();
            gvContraVoucher.RefreshData();
            gvContraVoucher.UpdateCurrentRow();

            if (dsContraVoucher.Count() == 0)
            {
                MessageBox.Show("Please enter Contra Voucher Detail.", "Saving.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (dsContraVoucher.Count(r => r.DebitAmount != 0 && r.CreditAmount != 0) > 0)
            {
                MessageBox.Show("Please enter only Debit Amount or Credit Amount.", "Saving.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            
            if ((decimal)colDebitAmount.SummaryItem.SummaryValue != (decimal)colCreditAmount.SummaryItem.SummaryValue)
            {
                MessageBox.Show("Can not save Debit and Credit Total must match.", "Saving.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            string Error = dsContraVoucher.FirstOrDefault(r => !String.IsNullOrWhiteSpace(r.RowError))?.RowError;

            if (!string.IsNullOrWhiteSpace(Error))
            {
                MessageBox.Show(Error, "Saving.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return base.OnValidateBeforeSave();
        }
        #endregion

        #region Methods

        void AssignVoucherType()
        {
            dsVoucherType = ((List<VoucherTypeLookUpListModel>)lookupEditVoucherType1.Properties.DataSource).ToList();
            if (dsVoucherType != null)
            {
                if (dsVoucherType.Count == 1)
                {
                    lcgVoucherType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lookupEditVoucherType1.EditValue = dsVoucherType.FirstOrDefault().VoucherTypeID;
                }
                else if (dsVoucherType.Count > 0)
                {
                    lookupEditVoucherType1.EditValue = dsVoucherType.FirstOrDefault().VoucherTypeID;
                }
            }
        }

        void ValidateRow(ContraVoucherDetailViewModel Row)
        {
            Row.RowError = null;
            if (Row == null)
            {
                return;
            }

            if (Row.RowError == null)
            {
                if (Row.AccountID == 0)
                {
                    Row.RowError = "Please select Account.";
                }
                if (Row.DebitAmount == 0 && Row.CreditAmount == 0)
                {
                    Row.RowError = (!string.IsNullOrWhiteSpace(Row.RowError) ? (Row.RowError + "\r\n" + "Please enter Debit Amount or Credit Amount.") : "Please enter Debit Amount or Credit Amount.");
                }
                if (Row.DebitAmount > 0 && Row.CreditAmount > 0)
                {
                    Row.RowError = (!string.IsNullOrWhiteSpace(Row.RowError) ? (Row.RowError + "\r\n" + "Please enter only Debit Amount or Credit Amount.") : "Please enter only Debit Amount or Credit Amount.");
                }
            }
        }

        #endregion

        #region Form Events
        private void gvContraVoucher_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var Row = (ContraVoucherDetailViewModel)gvContraVoucher.GetFocusedRow();
            if (Row == null)
            {
                return;
            }

            if (e.Column == colDebitAmount && Row.DebitAmount > 0)
            {
                Row.CreditAmount = 0M;
            }
            else if (e.Column == colCreditAmount && Row.CreditAmount > 0)
            {
                Row.DebitAmount = 0M;
            }
        }

        private void repositoryItembtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Row = gvContraVoucher.GetFocusedRow();
            if (Row == null)
            {
                return;
            }
            ContraVoucherDetailViewModelBindingSource.Remove(Row);
        }
        #endregion

        #region Validation

        private void deContraVoucherDate_Validating(object sender, CancelEventArgs e)
        {
            if (deContraVoucherDate.EditValue == null)
            {
                ErrorProvider.SetError(deContraVoucherDate, "Please enter Contra Voucher Date.");
            }
            else
            {
                ErrorProvider.SetError(deContraVoucherDate, null);
            }
        }

        private void gvContraVoucher_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            ValidateRow((ContraVoucherDetailViewModel)e.Row);
        }

        private void btnEditContraVoucherNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            btnEditContraVoucherNo.EditValue = DALObject.GetMaxContraVoucherNo().ToString();
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

    }
}
