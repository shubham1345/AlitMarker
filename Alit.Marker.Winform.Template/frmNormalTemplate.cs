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
using Alit.Marker.Model.Template;

namespace Alit.Marker.WinForm.Template
{
    public partial class frmNormalTemplate : frmBaseTemplate
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

        bool AllowRefresh_ = false;
        [DefaultValue(false)]
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
            OnLoadFormValues();
            OnLoadLookupDataSource();
        }

        private void backgroundWorkerLoadInitialValues_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                OnAssignLookupDataSource();
                OnAssignFormValues();
                CloseWaitForm();
                SetFocusOnFirstControl();
                OnLoadCompleted();
            });
        }

        public void ResetFormView()
        {
            OnClearValues();

            this.ErrorProvider.Clear();

            if (FirstControl != null) FirstControl.Focus();
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

        #region Virtual Methods

        public delegate bool ValidateBeforeSaveEventHandler(frmNormalTemplate CRUDForm);
        public event ValidateBeforeSaveEventHandler ValidateBeforeSave;
        protected virtual bool OnValidateBeforeSave()
        {
            return ValidateBeforeSave?.Invoke(this) ?? true;
        }

        public delegate void SaveRecordEventHandler(frmNormalTemplate CRUDForm, SavingParemeter Paras);
        public event SaveRecordEventHandler SaveRecord;
        protected virtual void OnSaveRecord(SavingParemeter Paras)
        {
            SaveRecord?.Invoke(this, Paras);
        }

        public event SaveRecordEventHandler AfterSaving;
        protected virtual void OnAfterSaving(SavingParemeter Paras)
        {
            AfterSaving?.Invoke(this, Paras);
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
                        this.DialogResult = DialogResult.OK;
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

        protected virtual void OnCloseForm()
        {
            this.Close();
        }

        public delegate void NormalFormEventHandler(frmNormalTemplate CRUDForm);
        public event NormalFormEventHandler BeforeClearValues;
        public event NormalFormEventHandler AfterClearValues;
        /// <summary>
        /// Clear control values or set it to default values. It is for refresh form values
        /// </summary>
        protected virtual void OnClearValues()
        {
            BeforeClearValues?.Invoke(this);
            frmCRUDTemplate.ClearValues(panelContent);
            AfterClearValues?.Invoke(this);
        }

        public event NormalFormEventHandler InitializeDefaultValues;
        protected virtual void OnInitializeDefaultValues() { InitializeDefaultValues?.Invoke(this); }

        public event NormalFormEventHandler LoadLookupDataSource;
        protected virtual void OnLoadLookupDataSource() { LoadLookupDataSource?.Invoke(this); }

        public event NormalFormEventHandler AssignLookupDataSource;
        protected virtual void OnAssignLookupDataSource() { AssignLookupDataSource?.Invoke(this); }

        public event NormalFormEventHandler LoadFormValues;
        /// <summary>
        /// Load/generate values that takes time to process like generating invoice number. 
        /// </summary>
        protected virtual void OnLoadFormValues() { LoadFormValues?.Invoke(this); }

        public event NormalFormEventHandler AssignFormValues;
        protected virtual void OnAssignFormValues() { AssignFormValues?.Invoke(this); }

        public event NormalFormEventHandler LoadCompleted;
        protected virtual void OnLoadCompleted() { LoadCompleted?.Invoke(this); }

        #endregion

        #region Action Methods

        private async void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await PerformSaving();
        }

        public async Task PerformSaving()
        {
            if (!ProcessValidationFormControls())
            {
                if (FirstControl != null && FirstControl.CanFocus)
                {
                    FirstControl.Focus();
                }
                return;
            }

            if (!OnValidateBeforeSave())
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
            await Task.Run(() => OnSaveRecord(savingParas));
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
            OnAfterSaving(savingParas);
            //--
            if (savingParas.SavingResult != null && savingParas.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                ResetFormView();
            }
            FirstControl.Focus();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnCloseForm();
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

    }
}