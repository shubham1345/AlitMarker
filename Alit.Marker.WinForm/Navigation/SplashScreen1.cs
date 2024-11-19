using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.Threading.Tasks;
using Alit.Marker.Model.Template;

namespace Alit.Marker.WinForm.Navigation
{
    public partial class SplashScreen1 : SplashScreen
    {
        public SplashScreen1()
        {
            InitializeComponent();
            this.labelControl1.Text = "Copyright © 2016-" + DateTime.Now.Year.ToString();

            lblApplicationName.Text = Model.CommonProperties.DevelopmentCompanyInfo.CompanyShortName
                + " " + Model.CommonProperties.DevelopmentCompanyInfo.ProductName
                + " " + Model.CommonProperties.DevelopmentCompanyInfo.ApplicationVersion;
        }

        #region Overrides

        protected override void OnParentInternalLoad()
        {
            base.OnParentInternalLoad();
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Application.DoEvents();
            var res = Task.Run(async () => { return await DAL.CommonFunctions.Reindex(); }).Result;
            if (res != null)
            {
                switch (res.ExecutionResult)
                {
                    //case eExecutionResult.CommitedSucessfuly:
                    //    Alit.WinformControls.ToastNotification.Show(this, "Record saved successfully");
                    //    if (!String.IsNullOrWhiteSpace(res.MessageAfterSave))
                    //    {
                    //        Alit.WinformControls.MessageBox.Show(this, res.MessageAfterSave, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //    this.DialogResult = DialogResult.OK;
                    //    break;

                    case eExecutionResult.ErrorWhileExecuting:
                        Alit.WinformControls.MessageBox.Show(this,
                            (res.Exception.Message.Length > 500 ? res.Exception.Message.Substring(0, 500) : res.Exception.Message),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case eExecutionResult.ValidationError:
                        Alit.WinformControls.MessageBox.Show(this, "Can not save, please check following validation issue.\r\n\r\n" + res.ValidationError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}