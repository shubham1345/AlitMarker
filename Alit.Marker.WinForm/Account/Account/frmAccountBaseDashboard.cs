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
using Alit.Marker.DAL.Account.Account;
using Alit.Marker.Model.Account.Account;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.Data;
using Alit.Marker.WinForm.Reports.Accounts.Transactions;

namespace Alit.Marker.WinForm.Account.Account
{
    public partial class frmAccountBaseDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmAccountCRUD);
            }
        }

        List<AccountDashboardViewModel> dsAccunt;
        public frmAccountBaseDashboard() : this(eAccountFormType.Account)
        {

        }

        public frmAccountBaseDashboard(eAccountFormType eAccFormType)
        {
            InitializeComponent();

            DashboardDALObj = new AccountDAL();
            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;

            eAccountForm = eAccFormType;
            if (Model.Account.Account.eAccountFormType.Account == eAccountForm)
            {
                Text = "Account";
            }
            else if (Model.Account.Account.eAccountFormType.Customer == eAccountForm)
            {
                Text = "Customer";
                gridView1.OptionsView.ShowFooter = false;
            }
            else if (Model.Account.Account.eAccountFormType.Supplier == eAccountForm)
            {
                Text = "Supplier";
                gridView1.OptionsView.ShowFooter = false;
            }

        }

        eAccountFormType eAccountForm;

        protected override object[] GetAddNewFormParameters()
        {
            //return base.GetAddNewFormParameters();
            return new object[]
            {
               eAccountForm,
            };
        }

        protected override object[] GetDashboardDataSourceFilterParas()
        {
            //return base.GetDashboardDataSourceFilterParas();
            return new object[]
           {
               eAccountForm,
           };
        }

        protected override GeneralizeReportGeneratorParameters GenerateDashboardPrintParas()
        {
            var res = base.GenerateDashboardPrintParas();
            res.Landscape = true;
            return res;
        }

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (eAccountForm == eAccountFormType.Account)
            {
                dsAccunt = (List<AccountDashboardViewModel>)DashboardDataSource;
                if (dsAccunt == null) { return; }
                decimal DebitAmount = dsAccunt.Where(r => r.OpBalAmount > 0).Sum(r => r.OpBalAmount);
                decimal CreditAmount = dsAccunt.Where(r => r.OpBalAmount < 0).Sum(rr => rr.OpBalAmount);
                decimal? DifferenceAmount = DebitAmount - CreditAmount;

                GridView view = sender as GridView;
                if (e.IsTotalSummary && (e.Item as GridSummaryItem).FieldName == "OpBalAmount")
                {
                    GridSummaryItem item = e.Item as GridSummaryItem;
                    if (item.FieldName == "OpBalAmount")
                    {
                        switch (e.SummaryProcess)
                        {
                            case CustomSummaryProcess.Start:
                                DifferenceAmount = null;
                                break;

                            case CustomSummaryProcess.Calculate:
                                break;

                            case CustomSummaryProcess.Finalize:
                                if (item.Tag.ToString() == "DR")
                                {
                                    e.TotalValue = DebitAmount;
                                }
                                if (item.Tag.ToString() == "CR")
                                {
                                    e.TotalValue = Math.Abs(CreditAmount);
                                }
                                if (item.Tag.ToString() == "Diff")
                                {
                                    DifferenceAmount = DebitAmount + CreditAmount;
                                    if (DifferenceAmount != null && DifferenceAmount != 0M)
                                    {
                                        e.TotalValue = (decimal)DifferenceAmount;
                                    }
                                    else
                                    {
                                        e.TotalValue = null;
                                        item.DisplayFormat = null;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
        }

        private void btnLedger_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Row = (AccountDashboardViewModel)gridView1.GetFocusedRow();

            if (Row != null)
            {
                using (frmRepLedger frm = new frmRepLedger(Row.AccountID))
                {
                    frm.ShowDialog(this);
                }
            }
        }
    }
}
