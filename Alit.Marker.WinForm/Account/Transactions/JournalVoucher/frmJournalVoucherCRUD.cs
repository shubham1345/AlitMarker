using Alit.Marker.DAL.Account.Account;
using Alit.Marker.DAL.Account.Transactions.JournalVoucher;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.Model.Account.Group;
using Alit.Marker.Model.Account.Transactions.JournalVoucher;
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

namespace Alit.Marker.WinForm.Account.Transactions.JournalVoucher
{
    public partial class frmJournalVoucherCRUD : Template.frmCRUDTemplate
    {
        JournalVoucherDAL DALObject;
        AccountDAL AccountDAL;

        List<AccountLookUpListModel> dsAccount;
        List<JournalVoucherDetailViewModel> dsJournalVoucher;
        List<VoucherTypeLookUpListModel> dsVoucherType;

        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new JournalVoucherDAL();
                }
                return DALObject;
            }
        }

        long AccountVoucherID;

        public frmJournalVoucherCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmJournalVoucherCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();

            DALObject = new JournalVoucherDAL();
            AccountDAL = new AccountDAL();

            dsJournalVoucher = new List<JournalVoucherDetailViewModel>();
            journalVoucherDetailViewModelBindingSource.DataSource = dsJournalVoucher;
        }

        #region Overriden Methods
        protected override void OnLoadLookupDataSource()
        {
            dsAccount = AccountDAL.GetLookupListFinal();
            
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
            btnEditJournalVoucherNo.EditValue = DALObject.GetMaxJournalVoucherNo();
            deJournalVoucherDate.DateTime = DateTime.Now;
            AssignVoucherType();
            base.OnAssignFormValues();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new JournalVoucherViewModel()
            {
                JournalVoucherID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                JournalVoucherNo = (int)btnEditJournalVoucherNo.EditValue,
                JournalVoucherDate = (DateTime)deJournalVoucherDate.EditValue,
                Narration = meNarration.Text,
                VoucherTypeID = (long)lookupEditVoucherType1.EditValue,
                //JVDetails = journalVoucherDetailViewModelBindingSource.Cast<JournalVoucherDetailViewModel>().ToList(),
                AccountVoucherID = AccountVoucherID,
                JVDetails = dsJournalVoucher,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            JournalVoucherViewModel EditingRecord = (JournalVoucherViewModel)RecordToFill;

            btnEditJournalVoucherNo.EditValue = EditingRecord.JournalVoucherNo;
            deJournalVoucherDate.EditValue = EditingRecord.JournalVoucherDate;
            meNarration.EditValue = EditingRecord.Narration;
            lookupEditVoucherType1.EditValue = EditingRecord.VoucherTypeID;
            meNarration.Text = EditingRecord.Narration;
            AccountVoucherID = EditingRecord.AccountVoucherID;

            dsJournalVoucher = EditingRecord.JVDetails;
            journalVoucherDetailViewModelBindingSource.DataSource = dsJournalVoucher;
            //journalVoucherDetailViewModelBindingSource.DataSource = EditingRecord.JVDetails;
            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        protected override bool OnValidateBeforeSave()
        {
            gvJournalVoucher.PostEditor();
            gvJournalVoucher.RefreshData();
            gvJournalVoucher.UpdateCurrentRow();
            //gvJournalVoucher.UpdateSummary();

            //if (dsJournalVoucher.Count(r => r.AccountID == 0 && (r.DebitAmount != 0 || r.CreditAmount != 0)) == 0)
            if (dsJournalVoucher.Count() == 0)
            {
                MessageBox.Show("Please enter Journal Voucher Detail.", "Saving.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (dsJournalVoucher.Count(r => r.DebitAmount != 0 && r.CreditAmount != 0) > 0)
            {
                MessageBox.Show("Please enter only Debit Amount or Credit Amount.", "Saving.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            //if ((decimal?)colDebitAmount.SummaryItem.SummaryValue != (decimal?)colCreditAmount.SummaryItem.SummaryValue)
            if ((decimal)colDebitAmount.SummaryItem.SummaryValue != (decimal)colCreditAmount.SummaryItem.SummaryValue)
            {
                MessageBox.Show("Can not save Debit and Credit Total must match.", "Saving.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            string Error = dsJournalVoucher.FirstOrDefault(r => !String.IsNullOrWhiteSpace(r.RowError))?.RowError;

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

        void ValidateRow(JournalVoucherDetailViewModel Row)
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
                //if (Row.Amount == 0)
                //{
                //    Row.RowError = "Please enter Amount.";
                //}
            }
        }

        #endregion

        #region Form Events
        private void gvJournalVoucher_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var Row = (JournalVoucherDetailViewModel)gvJournalVoucher.GetFocusedRow();
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
            var Row = gvJournalVoucher.GetFocusedRow();
            if (Row == null)
            {
                return;
            }
            journalVoucherDetailViewModelBindingSource.Remove(Row);
        }
        #endregion

        #region Validation

        private void deJournalVoucherDate_Validating(object sender, CancelEventArgs e)
        {
            if (deJournalVoucherDate.EditValue == null)
            {
                ErrorProvider.SetError(deJournalVoucherDate, "Please enter Journal Voucher Date.");
            }
            else
            {
                ErrorProvider.SetError(deJournalVoucherDate, null);
            }
        }

        private void gvJournalVoucher_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            ValidateRow((JournalVoucherDetailViewModel)e.Row);
        }

        private void btnEditJournalVoucherNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            btnEditJournalVoucherNo.EditValue = DALObject.GetMaxJournalVoucherNo().ToString();
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
