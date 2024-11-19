using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alit.Marker.Model;
using DevExpress.XtraReports.UI;

namespace Alit.Marker.WinForm.Reports.Customer
{
    public partial class frmCustomerList : Template.frmReportTemplate
    {
        DAL.Reports.Customer.CustomerListDAL DALObject;

        public frmCustomerList()
        {
            InitializeComponent();
            DALObject = new DAL.Reports.Customer.CustomerListDAL();

            HideParameterPanel();
        }

        public override void AssignFormValues()
        {
            this.ExecuteGenerateReport();
            base.AssignFormValues();
        }

        public override void GenerateReport(GenerateReportParameter Paras, ref XtraReport ReportSource)
        {
            Paras.GenerateReportResult = new Model.GenerateReportResult();

            this.ReportTitle = "Customer List";

            List<Model.Reports.Customer.CustomerListReportModel> ReportDS = DALObject.GetReportData();
            if (ReportDS.Count() > 0)
            {
                ReportSource = new Reports.Customer.rptCustomerList();
                ReportSource.DataSource = ReportDS;
                Paras.GenerateReportResult.ExecutionResult = Model.eExecutionResult.CommitedSucessfuly;
            }
            else
            {
                Paras.GenerateReportResult.ExecutionResult = Model.eExecutionResult.ValidationError;
                Paras.GenerateReportResult.ValidationError = "No record found to print";
            }

            base.GenerateReport(Paras, ref ReportSource);
        }
    }
}
