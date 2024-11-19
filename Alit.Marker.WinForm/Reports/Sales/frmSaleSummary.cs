using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Reports.Sales
{
    public partial class frmSaleSummary : Template.frmReportTemplate
    {
        DAL.Customer.CustomerDAL CustomerDAL;
        List<Model.Customer.CustomerLookUpListModel> CustomerList;

        public frmSaleSummary()
        {
            InitializeComponent();
            CustomerDAL = new DAL.Customer.CustomerDAL();
        }

        public override void LoadLookupDataSource()
        {
            CustomerList = CustomerDAL.GetLookUpList();
            CustomerList.Add(new Model.Customer.CustomerLookUpListModel()
            {
                CustomerID = -1,
                CustomerName = "(None)"
            });
            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupCustomer.Properties.ValueMember = "CustomerID";
            lookupCustomer.Properties.DisplayMember = "CustomerName";
            lookupCustomer.Properties.DataSource = CustomerList;

            base.AssignLookupDataSource();
        }

        public override void GenerateReport(Model.GenerateReportParameter Paras, ref XtraReport ReportSource)
        {
            DAL.Reports.Sales.SaleSummaryPrintDAL SInvDAL = new DAL.Reports.Sales.SaleSummaryPrintDAL();

            long? CustomerID = null;
            if (lookupCustomer.EditValue != null)
            {
                CustomerID = (long?)lookupCustomer.EditValue;
                if (CustomerID == -1)
                {
                    CustomerID = null;
                }

            }

            DateTime? DateFrom = (DateTime?)dteInvDateFrom.EditValue;
            DateTime? DateTo = (DateTime?)dtEditDateTo.EditValue;

            this.ReportTitle = "";
            if (DateFrom != null && DateTo != null)
            {
                this.ReportTitle = "From " + DateFrom.Value.ToShortDateString() + " To " + DateTo.Value.ToShortDateString();
            }
            else if (DateFrom != null)
            {
                this.ReportTitle = "From " + DateFrom.Value.ToShortDateString();
            }
            else if (DateTo != null)
            {
                this.ReportTitle = "Upto " + DateTo.Value.ToShortDateString();
            }
            else
            {
                this.ReportTitle = "";
            }
            this.ReportTitle = "Sale Summary " + this.ReportTitle;
            
            if(CustomerID != null)
            {
                this.ReportTitle += "\r\nFor " + lookupCustomer.Text;
            }

            ReportSource = new rptSaleSummary();
            ReportSource.DataSource = SInvDAL.GenerateReportData(DateFrom, DateTo, CustomerID);

            Paras.GenerateReportResult = new Model.GenerateReportResult();
            Paras.GenerateReportResult.ExecutionResult = Model.eExecutionResult.CommitedSucessfuly;
            base.GenerateReport(Paras, ref ReportSource);
        }

    }
}
