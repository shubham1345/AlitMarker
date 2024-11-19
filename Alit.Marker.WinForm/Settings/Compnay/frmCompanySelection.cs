using Alit.Marker.DAL.Settings.Compnay;
using Alit.Marker.DAL.Settings.FinancialPeriod;
using Alit.Marker.Model.Settings.Compnay;
using Alit.Marker.Model.Settings.FinancialPeriod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Alit.Marker.Model.Template;
using Alit.Marker.WinForm.Users;
using System.Threading.Tasks;
using System.Threading;

namespace Alit.Marker.WinForm.Settings.Compnay
{
    public partial class frmCompanySelection : Template.frmNormalTemplate
    {
        CompanyDAL CompanyDAL;
        List<CompanyLookupListModel> dsCompanyList;

        FinPeriodDAL FinPeriodDAL;
        List<FinPeriodLookupListModel> dsFinancialPeriod;

        long? DefaultCompanyID;
        long? DefaultFinPeriodID;

        #region COnstructor
        public frmCompanySelection() : this( null, null)
        {

        }
      
        public frmCompanySelection(long? defaultCompanyID, long? defaultFinPeriodID)
        {
            
            InitializeComponent();
            FinPeriodDAL = new FinPeriodDAL();
            CompanyDAL = new CompanyDAL();
            this.DefaultCompanyID = defaultCompanyID;
            this.DefaultFinPeriodID = defaultFinPeriodID;
            this.LoadCompleted += FrmCompanySelection_LoadCompleted; 
        }

       
        #endregion

        #region Overridden Methods
        protected override void OnLoadLookupDataSource()
        {
            dsCompanyList = CompanyDAL.GetLookupList();
        }

       
        protected override void OnAssignLookupDataSource()
        {
            LookupFinPeriod.Properties.ValueMember = "FinPeriodID";
            LookupFinPeriod.Properties.DisplayMember = "FinPeriodName";

            LookUpCompany.Properties.ValueMember = "CompanyID";
            LookUpCompany.Properties.DisplayMember = "CompanyName";
            LookUpCompany.Properties.DataSource = dsCompanyList;

            if (dsCompanyList != null && dsCompanyList.Count == 1)
            {
                LookUpCompany.EditValue = dsCompanyList.First().CompanyID;
                LookUpCompany.Enabled = false;
            }
            else
            {
                LookUpCompany.Enabled = true;
            }

        }

       protected override void OnAssignFormValues()
        {
            if (DefaultCompanyID != null)
            {
                LookUpCompany.EditValue = DefaultCompanyID;
            }if (DefaultFinPeriodID != null)
            {
                LookupFinPeriod.EditValue = DefaultFinPeriodID;
            }
            base.OnAssignFormValues();
        }


       
        private async void FrmCompanySelection_LoadCompleted(Template.frmNormalTemplate CRUDForm)
        {
            await Task.Run(() => { Thread.Sleep(400);});
            this.Activate();
        }

       
        protected override bool OnValidateBeforeSave()
        {
            if (LookUpCompany.EditValue == null)
            {
                Alit.WinformControls.MessageBox.Show(this, "Please select Company.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                if (LookUpCompany.Enabled == true)
                {
                    LookUpCompany.Focus();
                    return false;
                }
            }
            if (LookupFinPeriod.EditValue == null)
            {
                Alit.WinformControls.MessageBox.Show(this, "Please select Financial Period.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                if (lciFinPeriod.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
                {
                    LookupFinPeriod.Focus();
                    return false;
                }
            }

            return true;
        }
        protected override void OnSaveRecord(SavingParemeter Paras)
        {
            Paras.SavingResult = new SavingResult();
            Model.CommonProperties.LoginInfo.LoggedInCompany = CompanyDAL.GetCompanyDetail((long)LookUpCompany.EditValue);
            Model.CommonProperties.LoginInfo.LoggedInFinPeriod = FinPeriodDAL.GetDetailModel((long)LookupFinPeriod.EditValue);

            Paras.SavingResult.ExecutionResult = eExecutionResult.NotExecutedYet;
            base.OnSaveRecord(Paras);
        }
        protected override void OnAfterSaving(SavingParemeter Paras)
        {
            if (Paras.SavingResult != null && (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly ||
                Paras.SavingResult.ExecutionResult == eExecutionResult.NotExecutedYet))
            {
                this.DialogResult = DialogResult.OK;
            }
           
            base.OnAfterSaving(Paras);
        }
        #endregion

        #region events
        private void LookUpCompany_EditValueChanged(object sender, EventArgs e)
        {
            lciFinPeriod.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            if (LookUpCompany.EditValue == null)
            {
                LookupFinPeriod.Properties.DataSource = null;
            }
            else
            {
                dsFinancialPeriod = FinPeriodDAL.GetLookupList((long)LookUpCompany.EditValue);
                LookupFinPeriod.Properties.DataSource = dsFinancialPeriod;

                if (dsFinancialPeriod.Count == 1 && LookUpCompany.Enabled == false)
                {
                    LookupFinPeriod.EditValue = dsFinancialPeriod.First().FinPeriodID;
                    lciFinPeriod.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else
                {
                    LookupFinPeriod.EditValue = dsFinancialPeriod.OrderByDescending(r => r.FinPeriodFrom).First().FinPeriodID;
                }
            }
        }
        #endregion
    }
}
