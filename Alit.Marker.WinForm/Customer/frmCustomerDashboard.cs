using Alit.Marker.DAL.Customer;
using Alit.Marker.Model.Customer;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alit.Marker.WinForm.Template;

namespace Alit.Marker.WinForm.Customer
{
    public partial class frmCustomerDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmCustomerCRUD);
            }
        }

        DAL.Customer.CustomerOpeningBalanceDAL CustomerOpeningBalanceDALObj;

        public frmCustomerDashboard()
        {
            InitializeComponent();


            DashboardDALObj = new CustomerDAL();
            CustomerOpeningBalanceDALObj = new CustomerOpeningBalanceDAL();

            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
            
        }

        private void btnTransactionRegister_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Model.Customer.CustomerDashboardViewModel Row = null;
            if (DashboardGridView != null)
            {
                Row = (Model.Customer.CustomerDashboardViewModel)DashboardGridView.GetFocusedRow();
            }
            using (Reports.TransactionReports.frmRepTransactionRegister frm =
                new Reports.TransactionReports.frmRepTransactionRegister(Row?.CustomerID
                    , Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom
                    , DateTime.Now.Date))
            {
                frm.ShowDialog();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateRowState();
        }

        void UpdateRowState()
        {
            var Row = (CustomerDashboardViewModel)gridView1.GetFocusedRow();
            if (Row == null)
            {
                btnOpeningBalance.Enabled = false;
                btnDeleteOpeningBalance.Enabled = false;
            }
            else
            {
                btnOpeningBalance.Enabled = true;
                btnDeleteOpeningBalance.Enabled = (Row.OpeningBalanceID != null);
            }
        }

        private void btnOpeningBalance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Row = (CustomerDashboardViewModel)gridView1.GetFocusedRow();
            if(Row == null)
            {
                return;
            }

            CRUDMTemplateParas paras = new CRUDMTemplateParas();

            CustomerOpeningBalanceViewModel OpeningBalanceViewModel = null;
            if (Row.OpeningBalanceID != null)
            {
                OpeningBalanceViewModel = CustomerOpeningBalanceDALObj.GetViewModelByPrimeKey(Row.OpeningBalanceID.Value);
            }

            if (OpeningBalanceViewModel == null)
            {
                paras.FormDefaultUI = eFormCurrentUI.NewEntry;
            }
            else
            {
                paras.FormDefaultUI = eFormCurrentUI.Edit;
                paras.EditingRecord = OpeningBalanceViewModel;
            }

            using (frmCustomerOpeningBalance frm = new frmCustomerOpeningBalance(paras, Row.CustomerID))
            {
                if(frm.ShowDialog(this) == DialogResult.OK)
                {
                    ReloadDashboardData();
                    UpdateRowState();
                }
            }
        }

        private void btnDeleteOpeningBalance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // need to fetch user's permission for product opening stock
            //if (UserMenuPermission != null)
            //{
            //    if (!UserMenuPermission.CanDelete)
            //    {
            //        Alit.WinformControls.MessageBox.Show(this, "Can not delete. You don't have permission to delete records.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}

            var Row = (CustomerDashboardViewModel)gridView1.GetFocusedRow();
            if (Row == null || Row.OpeningBalanceID == null)
            {
                return;
            }

            long PrimeKeyID = Row.OpeningBalanceID.Value;
            var ValidationResult = CustomerOpeningBalanceDALObj.ValidateBeforeDelete(PrimeKeyID);

            if (ValidationResult.IsValidForDelete)
            {
                if (Alit.WinformControls.MessageBox.Show(this, "Are you sure ? Do you want to delete opening stock of selected product ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    DeletingParameter para = new DeletingParameter() { PrimeKeyID = PrimeKeyID };

                    ShowWaitForm();

                    para.DeletingResult = CustomerOpeningBalanceDALObj.DeleteRecord(PrimeKeyID);

                    CloseWaitForm();

                    AfterDeleteRecord(para);

                    if (para.DeletingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                    {
                        ReloadDashboardData();
                        UpdateRowState();
                    }
                }
            }
            else
            {
                Alit.WinformControls.MessageBox.Show(this, "Can not Delete.\r\n\r\n" + ValidationResult.ValidationMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnRecalculateCustomerBalance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmCalculateCustomerBalance frm = new frmCalculateCustomerBalance())
            {
                frm.ShowDialog();
            }
        }

        private void btnCity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Navigation.frmNavigationDashboard.ShowForm<City.City.frmCityGridCrud>();
        }

        private void btnState_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Navigation.frmNavigationDashboard.ShowForm<City.State.frmStateGridCRUD>();
        }

        private void btnCountry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Navigation.frmNavigationDashboard.ShowForm<City.Country.frmCountryGridCRUD>();
        }

        protected override GeneralizeReportGeneratorParameters GenerateDashboardPrintParas()
        {
            var res = base.GenerateDashboardPrintParas();
            res.Landscape = true;
            return res;
        }
    }
}
