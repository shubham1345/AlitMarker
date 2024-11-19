using Alit.Marker.DAL.Account.Transactions.Bank;
using Alit.Marker.Model.Account.Transactions.Bank;
using Alit.Marker.WinForm.Template;
using DevExpress.XtraGrid;
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

namespace Alit.Marker.WinForm.Account.Transactions.Bank
{
    public partial class frmBankReconciliation : Template.frmDashboardTemplate
    {
        BankReconciliationDAL DALObj;
        List<BankReconciliationDashboardViewModel> dsBankReconciliation { get { return (List<BankReconciliationDashboardViewModel>)DashboardDataSource; } }

        long AccountID;
        string AccountName;
        DateTime? DateFrom;
        DateTime? DateTo;
        bool IncludeReconciledRecords;
        decimal OpeningBankBalance = 0;

        public frmBankReconciliation()
        {
            InitializeComponent();

            DALObj = new BankReconciliationDAL();
            DashboardDALObj = DALObj;
            DashboardGridControl = gcBankReconciliation;
            DashboardGridView = gvBankReconciliation;

            gvBankReconciliation.OptionsBehavior.ReadOnly = false;
            gvBankReconciliation.OptionsBehavior.Editable = true;

            AllowEditVisible = false;
            AllowAddNewVisible = false;
            AllowDeleteVisible = false;
           
           //gvBankReconciliation.Columns["Reconciled"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[Active] = True");           
        }

        protected override void AssignFormValues()
        {
            deDateTo.DateTime = DateTime.Now.Date;
            deDateFrom.DateTime = deDateTo.DateTime.AddDays(-30);
            gvBankReconciliation.Columns["Reconciled"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[Active] = True");
            base.AssignFormValues();
        }

        protected override void AssignLookupDataSource()
        {
            lookupEditBookAccount1.AssignDataSource();
            base.AssignLookupDataSource();
        }

        protected override void LoadLookupDataSource()
        {
            lookupEditBookAccount1.LoadDataSource();
            base.LoadLookupDataSource();
        }

        protected override object[] GetDashboardDataSourceFilterParas()
        {
            AccountID = (long?)lookupEditBookAccount1.EditValue ?? 0;
            AccountName = lookupEditBookAccount1.Text;
            DateFrom = (DateTime?)deDateFrom.EditValue;
            DateTo = (DateTime?)deDateTo.EditValue;
            IncludeReconciledRecords = chkIncludeReconciled.Checked;

            return new object[]
            {
                AccountID,
                DateFrom,
                DateTo,
                IncludeReconciledRecords,
            };
        }

        protected override IEnumerable<IDashboardViewModel> GetDashboardDataSource(object[] FilterParas)
        {
            var DataSource = (List<BankReconciliationDashboardViewModel>)base.GetDashboardDataSource(FilterParas);
            OpeningBankBalance = DALObj.GetOpeningBankBalance(AccountID, DateFrom.Value);
            BookClosingBalance = DataSource.LastOrDefault()?.Balance ?? 0M;
            return DataSource;
        }

        private void gvBankReconciliation_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var Row = (BankReconciliationDashboardViewModel)gvBankReconciliation.GetFocusedRow();

            if (Row == null)
            {
                return;
            }

            if (e.Column == colReconciled || e.Column == colValueDate)
            {
                Row.Edited = true;
                gvBankReconciliation.RefreshRow(e.RowHandle);
                gvBankReconciliation.UpdateSummary();
            }
        }

        decimal BookClosingBalance = 0;
        private void gvBankReconciliation_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                GridColumnSummaryItem item = e.Item as GridColumnSummaryItem;
                if (item != null)
                {
                    if (item.FieldName == colBalance.FieldName)
                    {
                        switch (item.Tag.ToString())
                        {
                            case "BookBalance":
                                e.TotalValue = BookClosingBalance;
                                break;
                            case "BankBalance":
                                {
                                    decimal BankClosingBalance = (dsBankReconciliation?.Where(r => r.Reconciled == true)?.Sum(r => (decimal?)(r.DebitAmount + r.CreditAmount)) ?? 0M) + OpeningBankBalance;

                                    e.TotalValue = BankClosingBalance;
                                }
                                break;
                            case "Difference":
                                {
                                    decimal BankClosingBalance = (dsBankReconciliation?.Where(r => r.Reconciled == true)?.Sum(r => (decimal?)(r.DebitAmount + r.CreditAmount)) ?? 0M) + OpeningBankBalance;
                                    decimal Difference = BookClosingBalance - BankClosingBalance;

                                    e.TotalValue = Difference;
                                }
                                break;
                        }
                    }
                }
            }
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dsBankReconciliation == null || !dsBankReconciliation.Any(r => r.Edited))
            {
                return;
            }

            var res1 = DALObj.SaveRecord(dsBankReconciliation.Where(r => r.Edited).ToList());
        }

        private void chkIncludeReconciled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIncludeReconciled.Checked)
            {
                gvBankReconciliation.SetRowCellValue(GridControl.AutoFilterRowHandle, colReconciled, null);
            }
            else
            {
                gvBankReconciliation.SetRowCellValue(GridControl.AutoFilterRowHandle, colReconciled, false);
            }
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            gvBankReconciliation.PostEditor();
        }

        protected override GeneralizeReportGeneratorParameters GenerateDashboardPrintParas()
        {
            var paras = base.GenerateDashboardPrintParas();
            paras.Landscape = true;
            paras.PageHeaderLine2 = null;

            if (AccountName != null)
            {
                paras.PageHeaderLine2 += (!String.IsNullOrWhiteSpace(paras.PageHeaderLine2) ? "\r\n" : "") + $"Account Name : {AccountName}";
            }
            if (DateFrom != null)
            {
                paras.PageHeaderLine2 += (!String.IsNullOrWhiteSpace(paras.PageHeaderLine2) ? "\r\n" : "")
                    + "From " + DateFrom.Value.ToShortDateString();
            }
            if (DateTo != null)
            {
                paras.PageHeaderLine2 += (!String.IsNullOrWhiteSpace(paras.PageHeaderLine2) ? "" : "")
                    + (DateFrom != null ? " To " : "Up to ") + DateTo.Value.ToShortDateString();
            }
            paras.PageHeaderLine2 += (!String.IsNullOrWhiteSpace(paras.PageHeaderLine2) ? "" : "") +
                $"Reconciled transaction {(IncludeReconciledRecords ? "Included" : "Excluded")}";

            return paras;
        }

    }
}
