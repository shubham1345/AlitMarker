using Alit.Marker.DAL.Customer;
using Alit.Marker.DAL.Reports.TransationReports;
using Alit.Marker.Model.Customer;
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
using DevExpress.XtraGrid;

namespace Alit.Marker.WinForm.Reports.TransactionReports 
{
    public partial class frmRepTransactionRegister : Template.Report.frmGridReportTemplate
    {
        CustomerDAL CustomerDAL;
        List<CustomerLookUpListModel> dsCustomer;

        long? SelectedCustomerID { get; set; }
        DateTime? SelectedDateFrom { get; set; }
        DateTime? SelectedDateTo { get; set; }

        public frmRepTransactionRegister() : this(null, null, null)
        {
        }

        public frmRepTransactionRegister(long? CustomerID, DateTime? DateFrom, DateTime? DateTo)
        {
            InitializeComponent();

            ReportDALObj = new TransactionRegisterDAL();
            CustomerDAL = new CustomerDAL();

            SelectedCustomerID = CustomerID;
            SelectedDateFrom = DateFrom;
            SelectedDateTo = DateTo;

            ReportGridControl = gridControl1;
            ReportGridView = gridView1;
        }


        protected override void LoadLookupDataSource()
        {
            dsCustomer = CustomerDAL.GetLookupList();
            base.LoadLookupDataSource();
        }

        protected override void AssignLookupDataSource()
        {
            lueCustomer.Properties.ValueMember = "CustomerID";
            lueCustomer.Properties.DisplayMember = "CustomerName";
            lueCustomer.Properties.DataSource = dsCustomer;

            base.AssignLookupDataSource();
        }

        protected override void AssignFormValues()
        {
            lueCustomer.EditValue = SelectedCustomerID;

            if (SelectedDateFrom == null)
            {
                deDateFrom.DateTime = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom;
            }
            else
            {
                deDateFrom.DateTime = SelectedDateFrom.Value;
            }

            if (SelectedDateTo == null)
            {
                deDateTo.DateTime = DateTime.Now.Date.Add(new TimeSpan(23, 59, 59));
            }
            else
            {
                deDateTo.DateTime = SelectedDateTo.Value;
            }
            base.AssignFormValues();
        }

        protected override GeneralizeReportGeneratorParameters GenerateReportPrintParas()
        {
            var paras = base.GenerateReportPrintParas();
            //paras.Landscape = false;
            DateTime? DateFrom = (DateTime?)deDateFrom.EditValue;
            DateTime? DateTo = (DateTime?)deDateTo.EditValue;

            string Line2 = "Customer : " + lueCustomer.Text;

            if (DateFrom != null || DateTo != null)
            {
                Line2 += "\r\n";
                if (DateFrom != null)
                {
                    Line2 += "From " + DateFrom.Value.ToShortDateString();
                }
                if (DateTo != null)
                {
                    Line2 += (DateFrom != null ? " to " : "Up to ") + DateTo.Value.ToShortDateString();
                }
            }

            paras.PageHeaderLine2 = Line2;

            return paras;
        }

        protected override object[] GetReportDataSourceFilterParas()
        {
            return new object[]
            {
                (long?)lueCustomer.EditValue,
                (DateTime?)deDateFrom.EditValue,
                (DateTime?)deDateTo.EditValue,
            };
        }

        private void lueCustomer_Validating(object sender, CancelEventArgs e)
        {
            if (lueCustomer.EditValue == null)
            {
                ErrorProvider.SetError(lueCustomer, "Please select a customer.");
            }
            else
            {
                ErrorProvider.SetError(lueCustomer, "");
            }
        }

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if(e.Item is GridColumnSummaryItem
                && ((GridColumnSummaryItem)e.Item).FieldName == colBalance.FieldName
                && e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                e.TotalValue = (decimal)colAmountSale.SummaryItem.SummaryValue - (decimal)colAmountRecd.SummaryItem.SummaryValue;
            }
        }

        private void deDateFrom_Validating(object sender, CancelEventArgs e)
        {
            if(deDateFrom.EditValue == null)
            {
                ErrorProvider.SetError(deDateFrom, "Please enter date from");
            }
            else
            {
                ErrorProvider.SetError(deDateFrom, null);
            }
        }
    }
}
