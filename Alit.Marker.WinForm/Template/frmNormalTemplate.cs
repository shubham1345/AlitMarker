using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;
using System.Reflection;

using Alit.Marker.Model;

namespace Alit.Marker.WinForm.Template
{
    public partial class frmNormalTemplate : BaseTemplate
    {
        bool AllowSave_ = true;
        [DefaultValue(true)]
        [Description("Allow Save Button to be visible")]
        public bool AllowSave
        {
            get
            {
                return AllowSave_;
            }
            set
            {
                if (value != AllowSave_)
                {
                    AllowSave_ = value;
                    if (btnSave != null)
                    {
                        btnSave.Visibility =
                            (AllowSave_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        bool AllowRefresh_ = true;
        [DefaultValue(true)]
        [Description("Allow Refresh Button to be visible")]
        public bool AllowRefresh
        {
            get
            {
                return AllowRefresh_;
            }
            set
            {
                if (value != AllowRefresh_)
                {
                    AllowRefresh_ = value;
                    if (btnRefresh != null)
                    {
                        btnRefresh.Visibility =
                            (AllowRefresh_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        bool AllowExit_ = true;
        [DefaultValue(true)]
        [Description("Allow Exit Button to be visible")]
        public bool AllowExit
        {
            get
            {
                return AllowExit_;
            }
            set
            {
                if (value != AllowExit_)
                {
                    AllowExit_ = value;
                    if (btnExit != null)
                    {
                        btnExit.Visibility =
                            (AllowExit_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        private Control FirstControl_;
        [DefaultValue(null)]
        public Control FirstControl
        {
            get
            {
                if (FirstControl_ == null)
                {
                    FirstControl_ = this.panelContent.Controls.Cast<Control>().FirstOrDefault(r => r.Enabled && r.CanFocus);
                }
                return FirstControl_;
            }
            set
            {
                FirstControl_ = value;
            }
        }

        string SaveButtonCaption_;
        public string SaveButtonCaption
        {
            get { return SaveButtonCaption_; }
            set
            {
                if (SaveButtonCaption_ != value)
                {
                    SaveButtonCaption_ = value;
                    btnSave.Caption = SaveButtonCaption_;
                }
            }
        }

        string ExitButtonCaption_;
        public string ExitButtonCaption
        {
            get { return ExitButtonCaption_; }
            set
            {
                if (ExitButtonCaption_ != value)
                {
                    ExitButtonCaption_ = value;
                    btnExit.Caption = ExitButtonCaption_;
                }
            }
        }

        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManagerMain;

        public frmNormalTemplate()
        {
            InitializeComponent();

            SaveButtonCaption_ = btnSave.Caption;
            ExitButtonCaption_ = btnExit.Caption;

            ShowWaitForm();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (FirstControl != null) FirstControl.Focus();

            base.OnLoad(e);
            backgroundWorkerLoadInitialValues.RunWorkerAsync();
        }

        private void backgroundWorkerLoadInitialValues_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadFormValues();
            LoadLookupDataSource();
        }

        private void backgroundWorkerLoadInitialValues_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate { AssignLookupDataSource(); AssignFormValues(); CloseWaitForm(); });
        }

        public void ResetFormView()
        {
            ClearValues();

            this.ErrorProvider.Clear();

            if (FirstControl != null) FirstControl.Focus();
        }

        #region Virtual Methods

        public virtual bool ValidateBeforeSave()
        {
            return true;
        }

        /// <summary>
        /// Re-execute validation of all controls on form and show validation error message of all controls in one message, if any.
        /// </summary>
        /// <returns>false = has error, true = no error</returns>
        public bool ProcessValidationFormControls()
        {
            frmCRUDTemplate.CallValidatingEvent(this);

            string ErrorText = ErrorProvider.GetAllErrorText();
            if (!String.IsNullOrEmpty(ErrorText))
            {
                Alit.WinformControls.MessageBox.Show(this, "Can not save. Please fix following errors:\r\n\r\n" + ErrorText,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (ErrorProvider.ErrorList != null && ErrorProvider.ErrorList.Count > 0)
                {
                    SetFocusOnFirstControl();
                }
                return false;
            }
            return true;
        }

        public virtual void SaveRecord(SavingParemeter Paras)
        {
        }

        public virtual void AfterSaving(SavingParemeter Paras)
        {
            if (Paras.SavingResult != null)
            {
                switch (Paras.SavingResult.ExecutionResult)
                {
                    case eExecutionResult.CommitedSucessfuly:
                        Alit.WinformControls.ToastNotification.Show(this, "Record saved successfully");
                        if (!String.IsNullOrWhiteSpace(Paras.SavingResult.MessageAfterSave))
                        {
                            Alit.WinformControls.MessageBox.Show(this, Paras.SavingResult.MessageAfterSave, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case eExecutionResult.ErrorWhileExecuting:
                        Alit.WinformControls.MessageBox.Show(this,
                            (Paras.SavingResult.Exception.Message.Length > 500 ? Paras.SavingResult.Exception.Message.Substring(0, 500) : Paras.SavingResult.Exception.Message),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case eExecutionResult.ValidationError:
                        Alit.WinformControls.MessageBox.Show(this, "Can not save, please check following validation issue.\r\n\r\n" + Paras.SavingResult.ValidationError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }

        //public virtual BeforeDeleteValidationResult ValidateBeforeDelete()
        //{
        //    return new BeforeDeleteValidationResult()
        //    {
        //        IsValidForDelete = false,
        //        ValidationMessage = "Before delete validation is not implemented"
        //    };
        //}

        //public virtual void DeleteRecord(DeletingParameter Paras)
        //{

        //}

        //public virtual void AfterDeleteRecord(DeletingParameter Paras)
        //{
        //    switch (Paras.DeletingResult.ExecutionResult)
        //    {
        //        case eExecutionResult.CommitedSucessfuly:
        //            //Alit.WinformControls.ToastNotification.Show(this, "Record deleted successfully");
        //            if (!String.IsNullOrWhiteSpace(Paras.DeletingResult.MessageAfterSave))
        //            {
        //                Alit.WinformControls.MessageBox.Show(this, Paras.DeletingResult.MessageAfterSave, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            break;

        //        case eExecutionResult.ErrorWhileExecuting:
        //            Alit.WinformControls.MessageBox.Show(this,
        //                (Paras.DeletingResult.Exception.Message.Length > 500 ? Paras.DeletingResult.Exception.Message.Substring(0, 500) : Paras.DeletingResult.Exception.Message),
        //                MessageBoxButtons.OK, MessageBoxIcon.Error);

        //            break;
        //        case eExecutionResult.ValidationError:
        //            Alit.WinformControls.MessageBox.Show(this, "Can not delete, please check following validation issue.\r\n\r\n" + Paras.DeletingResult.ValidationError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            break;
        //    }
        //}

        public virtual void CloseForm()
        {
            this.Close();
        }

        /// <summary>
        /// Clear control values or set it to default values. It is for refresh form values
        /// </summary>
        public virtual void ClearValues()
        {
            frmCRUDTemplate.ClearValues(panelContent);
            
            //Template.MemoryManagement.FlushMemory();
        }

        /// <summary>
        /// After set a view like entry/edit/search. Form current view can be access by "this.CurrentView"
        /// </summary>
        public virtual void AfterSetView()
        {

        }
        public virtual void LoadLookupDataSource() { }
        public virtual void AssignLookupDataSource() { }

        /// <summary>
        /// Load/generate values that takes time to process like generating invoice number. 
        /// </summary>
        public virtual void LoadFormValues() { }

        public virtual void AssignFormValues() { }

        #endregion

        #region Action Methods

        private async void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (!ProcessValidationFormControls())
            {
                if (FirstControl != null && FirstControl.CanFocus)
                {
                    FirstControl.Focus();
                }
                return;
            }

            if(!ValidateBeforeSave())
            {
                // it's implementing class responsibiliy to set focus on appropriate control.
                return;
            }

            SavingParemeter savingParas = new SavingParemeter();
            savingParas.SavingInterface = SavingParemeter.eSavingInterface.AddNew;

            //
            ShowWaitForm();
            beiProgressbar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            ProgressBarSavingProcess.Stopped = false;
            //try
            //{
            await Task.Run(() => SaveRecord(savingParas));
            //}
            //catch (Exception ex)
            //{
            //    beiProgressbar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    CloseWaitForm();

            //    throw ex;
            //}
            ProgressBarSavingProcess.Stopped = true;
            beiProgressbar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            CloseWaitForm();
            //

            //--
            AfterSaving(savingParas);
            //--
            if (savingParas.SavingResult != null && savingParas.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                ResetFormView();
            }
            FirstControl.Focus();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseForm();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetFormView();
        }

        public void SetFocusOnFirstControl()
        {
            if (FirstControl != null)
            {
                FirstControl.Focus();
            }
            else
            {
                panelContent.Focus();
                SendKeys.SendWait("{Tab}");
            }
        }

        private void btnSetSaveFocus_Enter(object sender, EventArgs e)
        {
            btnSave.Links[0].Focus();
        }

        private void btnSetExitFocus_Click(object sender, EventArgs e)
        {
            btnExit.Links[0].Focus();
        }
        #endregion

        public void ShowWaitForm()
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                this.splashScreenManagerMain = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Alit.Marker.WinForm.Template.frmWait), true, true, true);
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
    }
}