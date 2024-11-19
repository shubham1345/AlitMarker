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

namespace Alit.Marker.WinForm.Template.Report
{
    public partial class frmReportViewer : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public XtraReport ReportSource
        {
            get
            {
                return (XtraReport)documentViewer1.DocumentSource;
            }
            set
            {
                documentViewer1.DocumentSource = value;
                documentViewer1.Refresh();
                value.CreateDocument();
            }
        }

        public frmReportViewer()
        {
            InitializeComponent();
            ShowWaitForm();
        }

        private async void btnRefreshReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await ExecuteGenerateReport();
        }

        protected async virtual Task ExecuteGenerateReport()
        {
            if (!ProcessValidationFormControls())
            {
                return;
            }

            if (!ValidateBeforeGenerateReport())
            {
                // it's implementing class responsibiliy to set focus on appropriate control.
                return;
            }
            ShowWaitForm();

            var rs = await Task.Run(() => GenerateReport());

            this.ReportSource = rs;

            CloseWaitForm();

            AfterGenerateReport();
        }

        protected virtual XtraReport GenerateReport()
        {
            return null;
        }

        protected virtual void AfterGenerateReport()
        {

        }


        /// <summary>
        /// Re-execute validation of all controls on form and show validation error message of all controls in one message, if any.
        /// </summary>
        /// <returns>false = has error, true = no error</returns>
        public bool ProcessValidationFormControls()
        {
            WinForm.Template.frmCRUDTemplate.CallValidatingEvent(this);

            string ErrorText = this.ErrorProvider.GetAllErrorText();
            if (!String.IsNullOrEmpty(ErrorText))
            {
                Alit.WinformControls.MessageBox.Show(this, "Can not generate report. Please fix following errors:\r\n\r\n" + ErrorText,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (ErrorProvider.ErrorList != null && ErrorProvider.ErrorList.Count > 0)
                {
                    //SetFocusOnFirstControl();
                }
                return false;
            }
            return true;
        }

        protected virtual bool ValidateBeforeGenerateReport()
        {
            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            if(Template.CommonPropperties.IsRunTime)
            {
                this.AcquireMaximumScreensize();
            }
            base.OnLoad(e);
            backgroundWorkerLoadInitialValues.RunWorkerAsync();
        }

        private void backgroundWorkerLoadInitialValues_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!this.Disposing && !this.IsDisposed)
            {
                LoadFormValues();
            }

            if (!this.Disposing && !this.IsDisposed)
            {
                LoadLookupDataSource();
            }

        }

        private void backgroundWorkerLoadInitialValues_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!this.Disposing && !this.IsDisposed)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (!this.Disposing && !this.IsDisposed)
                    {
                        AssignLookupDataSource();
                    }
                    if (!this.Disposing && !this.IsDisposed)
                    {
                        AssignFormValues();
                    }
                    if (!this.Disposing && !this.IsDisposed)
                    {
                        CloseWaitForm();
                    }
                    /*SetFocusOnFirstControl();*/
                });
            }
        }


        public virtual void LoadLookupDataSource() { }

        public virtual void AssignLookupDataSource() { }

        /// <summary>
        /// Load/generate values that takes time to process like generating invoice number. 
        /// </summary>
        public virtual void LoadFormValues() { }

        public virtual void AssignFormValues() { }


        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManagerMain;
        public void ShowWaitForm()
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                this.splashScreenManagerMain = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(frmWait), true, true, true);
                this.splashScreenManagerMain.ShowWaitForm();
            }
        }
        public void CloseWaitForm()
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                if (this.splashScreenManagerMain == null) return;
                this.splashScreenManagerMain.CloseWaitForm();
                this.splashScreenManagerMain.Dispose();
                this.splashScreenManagerMain = null;
            }
        }

        private void ribbonControl1_Merge_1(object sender, DevExpress.XtraBars.Ribbon.RibbonMergeEventArgs e)
        {
            DevExpress.XtraBars.Ribbon.RibbonControl control = e.MergeOwner;//((DevExpress.XtraBars.Ribbon.RibbonControl)sender);
            control.SelectedPage = control.MergedPages.FirstOrDefault(r => r.Text == "Print Preview");
        }
    }
}
