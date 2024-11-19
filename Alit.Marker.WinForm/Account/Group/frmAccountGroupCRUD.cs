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
using Alit.Marker.Model.Account.Group;

namespace Alit.Marker.WinForm.Account.Group
{
    public partial class frmAccountGroupCRUD : Template.frmCRUDTemplate
    {
        DAL.Account.Group.AccountGroupDAL DALObject;
        List<AccountGroupTypeLookupListModel> dsAccountGroupType;

        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new DAL.Account.Group.AccountGroupDAL();
                }

                return DALObject;
            }
        }

        public frmAccountGroupCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmAccountGroupCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new DAL.Account.Group.AccountGroupDAL();
        }
        
        #region Overriden Method

        protected override void OnAssignLookupDataSource()
        {
            base.OnAssignLookupDataSource();
            dsAccountGroupType = (List<AccountGroupTypeLookupListModel>)lookupEditAccountGroupType1.Properties.DataSource;
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new AccountGroupViewModel()
            {
                AccountGroupID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                AccountGroupName = txtGroupName.Text,
                ParentGroupID = (long?)lookupEditAccountGroup1.EditValue,
                AccountGroupNature = (lookupEditAccountGroup1.EditValue != null ? null : (eAccountGroupNature?)cmbGroupNature.SelectedIndex),
                EffectsGrossProfit = (lookupEditAccountGroup1.EditValue != null ? null : (bool?)(cmbEffectGrossProfit.SelectedIndex == 0)),
                GroupTypeID = (eAccountGroupType)lookupEditAccountGroupType1.EditValue,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            AccountGroupViewModel ViewModel = (AccountGroupViewModel)RecordToFill;
            txtGroupName.Text = ViewModel.AccountGroupName;
            lookupEditAccountGroup1.EditValue = ViewModel.ParentGroupID;
            cmbGroupNature.SelectedIndex = (ViewModel.AccountGroupNature != null ? (int)ViewModel.AccountGroupNature : -1);
            cmbEffectGrossProfit.SelectedIndex = (ViewModel.EffectsGrossProfit == null ? -1 : (bool)ViewModel.EffectsGrossProfit ? 1 : 0);
            lookupEditAccountGroupType1.EditValue = ViewModel.GroupTypeID;

            return base.OnFillSelectedRecordInContent(RecordToFill);
        }

        #endregion

        #region 
        private void lookupEditAccountGroup1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
            {
                lookupEditAccountGroup1.EditValue = null;
            }
        }

        private void lookupEditAccountGroup1_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupEditAccountGroup1.EditValue == null)
            {
                lookupEditAccountGroupType1.ReadOnly = false;
                lookupEditAccountGroupType1.TabStop = true;
            }
            else
            {
                //lookupEditAccountGroupType1.EditValue = null;
                lookupEditAccountGroupType1.ReadOnly = true;
                lookupEditAccountGroupType1.TabStop = false;

                var dsParentAccountGroup = (List<AccountGroupLookupListModel>)lookupEditAccountGroup1.Properties.DataSource;

                if (dsParentAccountGroup != null)
                {
                    lookupEditAccountGroupType1.EditValue = dsParentAccountGroup.FirstOrDefault(r => r.AccountGroupID == (long)lookupEditAccountGroup1.EditValue).GroupTypeID;
                }
            }
        }

        private void cmbGroupNature_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbGroupNature.SelectedItem != null)
            {
                lookupEditAccountGroupType1.Properties.DataSource = (dsAccountGroupType.Where(r => r.AccountGroupNature == (eAccountGroupNature)cmbGroupNature.SelectedIndex)).ToList();
            }
        }
        #endregion

        #region validation

        private void txtGroupName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtGroupName.Text))
            {
                ErrorProvider.SetError(txtGroupName, "Please enter Account Group Name.");
            }
            else if (DALObject.CheckDuplicate(txtGroupName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtGroupName, "Can not accept duplicate Account Group Name.");
            }
            else
            {
                ErrorProvider.SetError(txtGroupName, null);
            }
        }

        private void cmbEffectGrossProfit_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEditAccountGroup1.EditValue == null && cmbEffectGrossProfit.SelectedIndex == -1)
            {
                ErrorProvider.SetError(cmbEffectGrossProfit, "Please select Effects Gross Profit.");
            }
            else
            {
                ErrorProvider.SetError(cmbEffectGrossProfit, null);
            }
        }

        private void cmbGroupNature_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEditAccountGroup1.EditValue == null && cmbGroupNature.SelectedIndex == -1)
            {
                ErrorProvider.SetError(cmbGroupNature, "Please select Group Nature.");
            }
            else
            {
                ErrorProvider.SetError(cmbGroupNature, null);
            }
        }

        private void lookupEditAccountGroup1_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEditAccountGroup1.EditValue != null && (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null && (long)lookupEditAccountGroup1.EditValue == EditingRecord.PrimeKeyID))
            {
                ErrorProvider.SetError(lookupEditAccountGroup1, "Parent and Account Group can not be same.");
            }
            else if (lookupEditAccountGroup1.EditValue != null && DALObject.CheckParentIsnull(FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0))
            {
                ErrorProvider.SetError(lookupEditAccountGroup1, "Can not select Parent because this Account Group is selected in other Account Group as Parent Account group.");
            }
            else
            {
                ErrorProvider.SetError(lookupEditAccountGroup1, null);
            }
        }

        private void lookupEditAccountGroupType1_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEditAccountGroup1.EditValue == null && lookupEditAccountGroupType1.EditValue == null)
            {
                ErrorProvider.SetError(lookupEditAccountGroupType1, "Please select Group Type.");
            }
            else
            {
                ErrorProvider.SetError(lookupEditAccountGroupType1, null);
            }
        }

        #endregion
    }
}
