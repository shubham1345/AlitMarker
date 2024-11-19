using Alit.Marker.DAL;
using Alit.Marker.DAL.ERP.Masters.AdditionalItems;
using Alit.Marker.Model;
using Alit.Marker.Model.TransactionsCommon;
using Alit.Marker.Model.ERP.Masters.AdditionalItems;
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

namespace Alit.Marker.WinForm.ERP.Masters.AdditionalItems
{
    public partial class frmAdditionalItemCRUD : Template.frmCRUDTemplate
    {
        AdditionalItemDAL DALObject;

        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new AdditionalItemDAL();
                }

                return DALObject;
            }
        }

        public frmAdditionalItemCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmAdditionalItemCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new AdditionalItemDAL();
        }

        #region Overriden Methods

        protected override void OnInitializeDefaultValues()
        {
            chkbCalculatePercReverseBack.Checked = false;
            chkbIsInclusive.Checked = false;
            lookupEditAccount1.Enabled = false;

            base.OnInitializeDefaultValues();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new AdditionalItemViewModel()
            {
                AdditionalItemID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                ItemName = txtItemName.Text,
                Nature = (eAdditionalItemNature)cmbItemNature.SelectedIndex,
                Perc = (decimal)txtPerc.EditValue,
                ItemType = (int)eAdditionalItemType.AdditionalItem,
                CalculateOn = (eCalculateOn)cmbCalculateOn.SelectedIndex,
                ReverseCalculatePercentage = chkbCalculatePercReverseBack.Checked,
                InclusiveTax = chkbIsInclusive.Checked,
                IsDefaultRecord = chkbDefaultRecord.Checked,
                DefaultRecordPriority = (int?)txtDefaultRecPrt.EditValue,
                MaintainAccount = chkMaintainAccount.Checked,
                AccountID = (chkMaintainAccount.Checked == true ? (long?)lookupEditAccount1.EditValue : null),
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            AdditionalItemViewModel EditingRecord = (AdditionalItemViewModel)RecordToFill;

            txtItemName.Text = EditingRecord.ItemName;
            cmbItemNature.SelectedIndex = (int)EditingRecord.Nature;
            txtPerc.EditValue = EditingRecord.Perc;
            chkbCalculatePercReverseBack.Checked = EditingRecord.ReverseCalculatePercentage;
            cmbCalculateOn.SelectedIndex = (int)EditingRecord.CalculateOn;
            chkbIsInclusive.Checked = EditingRecord.InclusiveTax;
            chkbDefaultRecord.Checked = EditingRecord.IsDefaultRecord;
            txtDefaultRecPrt.EditValue = EditingRecord.DefaultRecordPriority;
            chkMaintainAccount.Checked = EditingRecord.MaintainAccount;
            lookupEditAccount1.EditValue = EditingRecord.AccountID;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }
        #endregion

        private void chkMaintainAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMaintainAccount.Checked == false)
            {
                lookupEditAccount1.EditValue = null;
                lookupEditAccount1.Enabled = false;
                ErrorProvider.SetError(lookupEditAccount1, null);
            }
            else if (chkMaintainAccount.Checked == true)
            {
                lookupEditAccount1.Enabled = true;
            }
            lookupEditAccount1.Refresh();
        }

        #region Validation
        private void txtItemName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtItemName.Text))
            {
                ErrorProvider.SetError(txtItemName, "Please enter Item Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtItemName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtItemName, "Can not accept duplicate Item Name.");
            }
            else
            {
                ErrorProvider.SetError(txtItemName, null);
            }
        }

        private void cmbCalculateOn_Validating(object sender, CancelEventArgs e)
        {
            if (cmbCalculateOn.SelectedItem == null)
            {
                ErrorProvider.SetError(cmbCalculateOn, "Please select Calculate On");
            }
            else
            {
                ErrorProvider.SetError(cmbCalculateOn, null);
            }
        }

        private void lookupEditAccount1_Validating(object sender, CancelEventArgs e)
        {
            if (chkMaintainAccount.Checked == true && lookupEditAccount1.EditValue == null)
            {
                ErrorProvider.SetError(lookupEditAccount1, "Please select Account.");
            }
            else
            {
                ErrorProvider.SetError(lookupEditAccount1, null);
            }
        }
        #endregion

    }
}
