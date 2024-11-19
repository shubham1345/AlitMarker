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
using DevExpress.XtraGrid.Views.Grid;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Template;

namespace Alit.Marker.WinForm.Template
{
    public partial class frmCRUDTemplate : frmBaseTemplate
    {
        #region Properties

        bool AllowSave_ = false;
        [DefaultValue(false)]
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

        bool AllowDelete_ = false;
        [DefaultValue(false)]
        [Description("Allow Delete Button to be visible")]
        public bool AllowDelete
        {
            get
            {
                return AllowDelete_;
            }
            set
            {
                if (value != AllowDelete_)
                {
                    AllowDelete_ = value;
                    if (btnDelete != null)
                    {
                        btnDelete.Visibility = btnDelete.Visibility =
                            (AllowDelete_ ?
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

        bool AllowExit_ = false;
        [DefaultValue(false)]
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

        bool AllowPrint_ = false;
        [DefaultValue(false)]
        [Description("Allow Print Button to be visible")]
        public bool AllowPrint
        {
            get
            {
                return AllowPrint_;
            }
            set
            {
                if (value != AllowPrint_)
                {
                    AllowPrint_ = value;
                    if (btnPrint != null)
                    {
                        btnPrint.Visibility = btnPrintPreview.Visibility = (AllowPrint_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        bool AllowRecordStateVisible_ = false;
        [DefaultValue(false)]
        [Description("Allow Record State to be visible")]
        public bool AllowRecordStateVisible
        {
            get
            {
                return AllowRecordStateVisible_;
            }
            set
            {
                if (value != AllowRecordStateVisible_)
                {
                    AllowRecordStateVisible_ = value;
                    if (lblRecordState != null)
                    {
                        lblRecordState.Visibility = (AllowRecordStateVisible_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        eRecordState RecordState_;
        public eRecordState RecordState
        {
            get
            {
                return RecordState_;
            }

            set
            {
                RecordState_ = value;
                switch (RecordState_)
                {
                    case eRecordState.Active:
                        lblRecordState.Caption = "Active";
                        //lblRecordState.ItemAppearance.Normal.ForeColor = RecordStateForeColor_Active;
                        break;
                    case eRecordState.Locked:
                        lblRecordState.Caption = "Locked";
                        lblRecordState.ItemAppearance.Normal.ForeColor = CommonPropperties.RecordStateForeColor_Locked_ForeColor;
                        lblRecordState.ItemAppearance.Normal.BackColor = CommonPropperties.RecordStateForeColor_Locked_BackColor;
                        break;
                    case eRecordState.Deactivated:
                        lblRecordState.Caption = "Deactivated";
                        lblRecordState.ItemAppearance.Normal.ForeColor = CommonPropperties.RecordStateForeColor_Deactivated_ForeColor;
                        lblRecordState.ItemAppearance.Normal.BackColor = CommonPropperties.RecordStateForeColor_Deactivated_BackColor;
                        break;
                }
            }
        }

        public eFormCurrentUI FormCurrentUI { get; private set; }

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

        public IDashboardViewModel EditingRecord { get; set; }

        public SavingResult SaveResult { get; set; }

        /// <summary>
        /// if true it will set CRUD form size as per the screen size, with margin of 50 on all sides.
        /// </summary>
        public bool AcquireMaximumScreenSize { get; set; }
        #endregion

        #region Fields
        protected virtual DAL.Template.ICRUDDAL CrudDALObj { get; }
        #endregion

        #region Constructor

        public frmCRUDTemplate()
                : this(new CRUDMTemplateParas())
        {

        }

        public frmCRUDTemplate(CRUDMTemplateParas Paras)
        {
            this.FormCurrentUI = Paras.FormDefaultUI;
            this.EditingRecord = Paras.EditingRecord;

            //--
            InitializeComponent();
            //--

            if (FormCurrentUI == eFormCurrentUI.Edit || FormCurrentUI == eFormCurrentUI.Delete)
            {
                AllowRecordStateVisible = true;
                if (Paras != null && Paras.EditingRecord != null)
                {
                    RecordState = Paras.EditingRecord.RecordState;
                }
                else
                {
                    RecordState = eRecordState.Active;
                }
            }
            else
            {
                AllowRecordStateVisible = false;
            }
        }
        #endregion

        #region Form Load 

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                lblFormCaption.Caption = this.Text;
                UpdateFormCaption();

                if (FormCurrentUI == eFormCurrentUI.Edit || FormCurrentUI == eFormCurrentUI.Delete)
                {
                    if (EditingRecord is EditUserInfo)
                    {
                        var edituser = (EditUserInfo)EditingRecord;
                        if (!String.IsNullOrWhiteSpace(edituser.CreatedUserName) || edituser.CreatedDateTime.HasValue)
                        {
                            lblCreatedBy.Caption = edituser.CreatedUserName ?? "";
                            lblCreatedAt.Caption = (edituser.CreatedDateTime.HasValue ? edituser.CreatedDateTime.Value.ToLongDateString() + " " +
                                edituser.CreatedDateTime.Value.ToShortTimeString() : "");

                            lblCreatedByCaption.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            lblCreatedBy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            lblCreatedAtCaption.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            lblCreatedAt.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        }
                        else
                        {
                            lblCreatedBy.Caption = "";
                            lblCreatedAt.Caption = "";
                        }

                        if (!String.IsNullOrWhiteSpace(edituser.EditedUserName) || edituser.EditedDateTime.HasValue)
                        {
                            lblEditedBy.Caption = edituser.EditedUserName ?? "";
                            lblEditedAt.Caption = (edituser.EditedDateTime.HasValue ? edituser.EditedDateTime.Value.ToLongDateString() + " " +
                                edituser.EditedDateTime.Value.ToShortTimeString() : "");

                            lblEditedByCaption.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            lblEditedBy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            lblEditedAt.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            lblEditedAtCaption.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        }
                        else
                        {
                            lblEditedBy.Caption = "";
                            lblEditedAt.Caption = "";
                        }
                    }
                }
                else
                {
                    lblCreatedByCaption.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    lblCreatedBy.Caption = "";
                    lblCreatedBy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    lblCreatedAtCaption.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    lblCreatedAt.Caption = "";
                    lblCreatedAt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    lblEditedByCaption.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    lblEditedBy.Caption = "";
                    lblEditedBy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    lblEditedAtCaption.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    lblEditedAt.Caption = "";
                    lblEditedAt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                beiProgressbar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                ShowWaitForm();


                backgroundWorkerLoadInitialValues.RunWorkerAsync();
            }
        }

        private void backgroundWorkerLoadInitialValues_DoWork(object sender, DoWorkEventArgs e)
        {
            OnLoadFormValues();
            OnLoadLookupDataSource();
        }

        private void backgroundWorkerLoadInitialValues_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool CloseForm = false;
            this.Invoke((MethodInvoker)delegate
            {
                OnAssignLookupDataSource();
                OnAssignFormValues();
                OnInitializeDefaultValues();

                if (FormCurrentUI == eFormCurrentUI.Edit || FormCurrentUI == eFormCurrentUI.Delete)
                {
                    if (EditingRecord == null)
                    {
                        Alit.WinformControls.MessageBox.Show(this, "Record was not selected.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        CloseForm = true;
                    }
                    else
                    {
                        var ViewModel = OnGetViewModelForEditing(EditingRecord);
                        if (ViewModel == null)
                        {
                            Alit.WinformControls.MessageBox.Show(this, "Record was not found.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            CloseForm = true;
                        }
                        else
                        {
                            var res = OnFillSelectedRecordInContent(ViewModel);

                            if (res == eFillSelectedRecordInContentFlag.SelectionSourceNotAvailable)
                            {
                                Alit.WinformControls.MessageBox.Show(this, "No record was selected.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                CloseForm = true;
                            }
                            else if (res == eFillSelectedRecordInContentFlag.SelectedRecordNotFoundInDatabase)
                            {
                                Alit.WinformControls.MessageBox.Show(this, "Selected record was not found. May be it was deleted over network by other users.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                CloseForm = true;
                            }
                        }
                    }
                }
                CloseWaitForm();
            });

            if (CloseForm)
            {
                this.Close();
            }
            else
            {
                if (FormCurrentUI == eFormCurrentUI.NewEntry || FormCurrentUI == eFormCurrentUI.Edit)
                {
                    AllowSave = (RecordState == eRecordState.Active);
                    //AllowRefresh = (RecordState == eRecordState.Active); 
                }
                if (FormCurrentUI == eFormCurrentUI.Delete)
                {
                    AllowDelete = true;
                }
                SetFocusOnFirstControl();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (AcquireMaximumScreenSize) //&& Program.IsRuntime)
            {
                var ActiveScreen = Screen.FromHandle(this.Handle);
                if (ActiveScreen != null)
                {
                    this.Location = new Point(ActiveScreen.WorkingArea.X + 50, ActiveScreen.WorkingArea.Y + 50);
                    this.Size = new Size(ActiveScreen.WorkingArea.Width - 100, ActiveScreen.WorkingArea.Height - 100);
                }
            }
        }
        #endregion

        #region Virtual Methods
        public delegate bool ValidateBeforeSaveEventHandler(frmCRUDTemplate CRUDForm);
        public event ValidateBeforeSaveEventHandler ValidateBeforeSave;
        protected virtual bool OnValidateBeforeSave()
        {
            return ValidateBeforeSave?.Invoke(this) ?? true;
        }

        public delegate void SaveRecordEventHandler(frmCRUDTemplate CRUDForm, SavingParemeter Paras);
        public event SaveRecordEventHandler SaveRecord;
        protected virtual void OnSaveRecord(SavingParemeter Paras)
        {
            if (CrudDALObj != null)
            {
                SaveRecord?.Invoke(this, Paras);
                Paras.SavingResult = CrudDALObj.SaveRecord(OnGetViewModelForSaving());
            }
        }

        protected virtual ICRUDViewModel OnGetViewModelForSaving()
        {
            return null;
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

        public delegate BeforeDeleteValidationResult ValidateBeforeDeleteEventHandler(frmCRUDTemplate CRUDForm, long DeletingRecordID);
        public event ValidateBeforeDeleteEventHandler ValidateBeforeDelete;
        protected virtual BeforeDeleteValidationResult OnValidateBeforeDelete(long DeletingRecordID)
        {
            ValidateBeforeDelete?.Invoke(this, DeletingRecordID);
            if (CrudDALObj != null)
            {
                return CrudDALObj.ValidateBeforeDelete(DeletingRecordID);
            }
            else
            {
                return new BeforeDeleteValidationResult()
                {
                    IsValidForDelete = false,
                    ValidationMessage = "Before delete validation is not implemented"
                };
            }
        }

        public delegate void DeleteRecordEventHandler(frmCRUDTemplate CRUDForm, DeletingParameter Paras);
        public event DeleteRecordEventHandler DeleteRecord;
        protected virtual void OnDeleteRecord(DeletingParameter Paras)
        {
            DeleteRecord?.Invoke(this, Paras);
            if (CrudDALObj != null)
            {
                Paras.DeletingResult = CrudDALObj.DeleteRecord(Paras.PrimeKeyID);
            }
            else
            {
                throw new Exception("Delete Record method was not implemented.");
            }
        }

        public event DeleteRecordEventHandler AfterDeleteRecord;
        protected virtual void OnAfterDeleteRecord(DeletingParameter Paras)
        {
            AfterDeleteRecord.Invoke(this, Paras);
            switch (Paras.DeletingResult.ExecutionResult)
            {
                case eExecutionResult.CommitedSucessfuly:
                    Alit.WinformControls.ToastNotification.Show(this, "Record deleted successfully");

                    if (!String.IsNullOrWhiteSpace(Paras.DeletingResult.MessageAfterSave))
                    {
                        Alit.WinformControls.MessageBox.Show(this, Paras.DeletingResult.MessageAfterSave, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                    break;

                case eExecutionResult.ErrorWhileExecuting:
                    Alit.WinformControls.MessageBox.Show(this,
                        (Paras.DeletingResult.Exception.Message.Length > 500 ? Paras.DeletingResult.Exception.Message.Substring(0, 500) : Paras.DeletingResult.Exception.Message),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
                case eExecutionResult.ValidationError:
                    Alit.WinformControls.MessageBox.Show(this, "Can not delete, please check following validation issue.\r\n\r\n" + Paras.DeletingResult.ValidationError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        public delegate void CrudFormEventHandler(frmCRUDTemplate CRUDForm);
        public event CrudFormEventHandler BeforeClearValues;
        public event CrudFormEventHandler AfterClearValues;
        /// <summary>
        /// Clear control values or set it to default values. It is for refresh form values
        /// </summary>
        protected virtual void OnClearValues()
        {
            BeforeClearValues?.Invoke(this);
            ClearValues(panelContent);
            AfterClearValues?.Invoke(this);
        }

        public static void ClearValues(Control ParentControl)
        {
            foreach (Control Cnt in ParentControl.Controls)
            {
                if (Cnt.HasChildren)
                {
                    ClearValues(Cnt);
                }
                else if ((Cnt is LookUpEdit) || (Cnt.Parent is LookUpEdit))
                {
                    if ((Cnt.Parent is LookUpEdit))
                    {
                        LookUpEdit LookupControl = (LookUpEdit)Cnt.Parent;
                        LookupControl.EditValue = null;
                    }
                }
                else if (Cnt is DateEdit || Cnt.Parent is DateEdit) { }
                else if (Cnt is CheckEdit || Cnt.Parent is CheckEdit) { }
                else if (Cnt is SimpleButton || Cnt.Parent is SimpleButton) { }
                else if (Cnt is TextEdit || Cnt.Parent is TextEdit)
                {
                    if (Cnt is TextEdit)
                    {

                    }
                    else if (Cnt.Parent is TextEdit)
                    {
                        ((TextEdit)Cnt.Parent).EditValue = null;
                    }
                }
                else
                {
                    Cnt.ResetText();
                }
            }
        }

        public event CrudFormEventHandler InitializeDefaultValues;
        protected virtual void OnInitializeDefaultValues() { InitializeDefaultValues?.Invoke(this); }

        public event CrudFormEventHandler LoadLookupDataSource;
        protected virtual void OnLoadLookupDataSource() { LoadLookupDataSource?.Invoke(this); }

        public event CrudFormEventHandler AssignLookupDataSource;
        protected virtual void OnAssignLookupDataSource() { AssignLookupDataSource?.Invoke(this); }

        public event CrudFormEventHandler LoadFormValues;
        /// <summary>
        /// Load/generate values that takes time to process like generating invoice number. 
        /// </summary>
        protected virtual void OnLoadFormValues() { LoadFormValues?.Invoke(this); }

        public event CrudFormEventHandler AssignFormValues;
        protected virtual void OnAssignFormValues() { AssignFormValues?.Invoke(this); }

        protected virtual ICRUDViewModel OnGetViewModelForEditing(IDashboardViewModel SelectedRecord)
        {
            if (CrudDALObj != null && SelectedRecord != null)
            {
                return CrudDALObj.GetCRUDViewModelByPrimeKey(SelectedRecord.PrimeKeyID);
            }
            return null;
        }


        public delegate eFillSelectedRecordInContentFlag FillSelectedRecordInContentEventHandler(frmCRUDTemplate CRUDForm, ICRUDViewModel RecordToFill);
        public event FillSelectedRecordInContentEventHandler FillSelectedRecordInContent;
        protected virtual eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            return FillSelectedRecordInContent?.Invoke(this, RecordToFill) ?? eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        public delegate void PrintEventHandler(frmCRUDTemplate CRUDForm, long PrimeKeyID);
        public event PrintEventHandler DirectPrintPreview;
        protected virtual void OnDirectPrintPreview(long PrimeKeyID)
        {
            DirectPrintPreview?.Invoke(this, PrimeKeyID);

            ShowWaitForm();
            var Document = GeneratePrintDocument(PrimeKeyID);
            CloseWaitForm();
            if (Document != null)
            {
                using (Template.Report.frmReportViewer frmViewer = new Template.Report.frmReportViewer())
                {
                    frmViewer.ReportSource = Document;
                    frmViewer.ShowDialog(this);
                }
            }
        }

        public event PrintEventHandler DirectPrint;
        protected virtual void OnDirectPrint(long PrimeKeyID)
        {
            DirectPrint?.Invoke(this, PrimeKeyID);

            ShowWaitForm();
            var Document = GeneratePrintDocument(PrimeKeyID);
            CloseWaitForm();

            if (Document != null)
            {
                using (DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(Document))
                {
                    printTool.Print();
                }
            }
        }


        protected virtual DevExpress.XtraReports.UI.XtraReport GeneratePrintDocument(long PrimeKeyID)
        {
            return null;
        }
        #endregion

        #region Action Methods

        async Task<SavingParemeter> PerformSaving()
        {
            if (UserMenuPermission != null)
            {
                if (FormCurrentUI == eFormCurrentUI.NewEntry && !UserMenuPermission.CanAdd)
                {
                    Alit.WinformControls.MessageBox.Show(this, "Can not add new records. You don't have permission to save new records.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetFocusOnFirstControl();
                    return new SavingParemeter() { SavingResult = new SavingResult() { ExecutionResult = eExecutionResult.ValidationError, ValidationError = "Permission denied." } };
                }
                else if (FormCurrentUI == eFormCurrentUI.Edit && !UserMenuPermission.CanEdit)
                {
                    Alit.WinformControls.MessageBox.Show(this, "Can not edit. You don't have permission to edit records.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetFocusOnFirstControl();
                    return new SavingParemeter() { SavingResult = new SavingResult() { ExecutionResult = eExecutionResult.ValidationError, ValidationError = "Permission denied." } };
                }
            }

            if (!ProcessValidationFormControls())
            {
                if (FirstControl != null && FirstControl.CanFocus)
                {
                    FirstControl.Focus();
                }
                return new SavingParemeter() { SavingResult = new SavingResult() { ExecutionResult = eExecutionResult.ValidationError, ValidationError = "Validation error." } }; ;
            }

            if (!OnValidateBeforeSave())
            {
                // it's implementing class responsibility to set focus on appropriate control.
                return null;
            }

            SavingParemeter savingParas = new SavingParemeter();
            if (FormCurrentUI == eFormCurrentUI.Edit)
            {
                savingParas.SavingInterface = SavingParemeter.eSavingInterface.Update;
            }
            else
            {
                savingParas.SavingInterface = SavingParemeter.eSavingInterface.AddNew;
            }

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
            SaveResult = savingParas.SavingResult;
            ProgressBarSavingProcess.Stopped = true;
            beiProgressbar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            CloseWaitForm();

            //--
            OnAfterSaving(savingParas);
            //--
            return savingParas;
        }


        private async void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SavingParemeter savingParas = await PerformSaving();
            this.SaveResult = savingParas?.SavingResult;
            if (savingParas != null && savingParas.SavingResult != null && savingParas.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                this.Close();
            }
            else
            {
                SetFocusOnFirstControl();
            }
        }

        private async void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool HasPermissionToSave = true;
            if (UserMenuPermission != null)
            {
                if (FormCurrentUI == eFormCurrentUI.NewEntry && !UserMenuPermission.CanAdd)
                {
                    Alit.WinformControls.MessageBox.Show(this, "Can not add new records. You don't have permission to save new records.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetFocusOnFirstControl();
                    return;
                }
                else if (FormCurrentUI == eFormCurrentUI.Edit && !UserMenuPermission.CanEdit)
                {
                    HasPermissionToSave = false;
                }
            }

            if (HasPermissionToSave && (FormCurrentUI == eFormCurrentUI.NewEntry || Alit.WinformControls.MessageBox.Show(this, "Do you want to save before print ? \r\n Please note : if you choose 'No' then changes will not reflect in print.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
            {
                SavingParemeter savingParas = await PerformSaving();

                if (savingParas.SavingResult != null && savingParas.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                {
                    this.SaveResult = savingParas.SavingResult;
                    OnDirectPrint(savingParas.SavingResult.PrimeKeyValue);
                    this.Close();
                }
            }
            else
            {
                OnDirectPrint(EditingRecord.PrimeKeyID);
                this.Close();
            }
            //--
            SetFocusOnFirstControl();
        }

        private async void btnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool HasPermissionToSave = true;
            if (UserMenuPermission != null)
            {
                if (FormCurrentUI == eFormCurrentUI.NewEntry && !UserMenuPermission.CanAdd)
                {
                    Alit.WinformControls.MessageBox.Show(this, "Can not add new records. You don't have permission to save new records.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetFocusOnFirstControl();
                    return;
                }
                else if (FormCurrentUI == eFormCurrentUI.Edit && !UserMenuPermission.CanEdit)
                {
                    HasPermissionToSave = false;
                }
            }

            if (HasPermissionToSave && (FormCurrentUI == eFormCurrentUI.NewEntry || Alit.WinformControls.MessageBox.Show(this, "Do you want to save before print ? \r\n Please note : if you choose 'No' then changes will not reflect in print preview.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
            {
                SavingParemeter savingParas = await PerformSaving();

                if (savingParas.SavingResult != null && savingParas.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                {
                    this.SaveResult = savingParas.SavingResult;
                    OnDirectPrintPreview(savingParas.SavingResult.PrimeKeyValue);
                    this.Close();
                }
            }
            else
            {
                OnDirectPrintPreview(EditingRecord.PrimeKeyID);
                this.Close();
            }
            //--
            FirstControl.Focus();
        }


        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await ExecuteDelete();
        }

        async Task ExecuteDelete()
        {
            if (UserMenuPermission != null)
            {
                if (!UserMenuPermission.CanDelete)
                {
                    Alit.WinformControls.MessageBox.Show(this, "Can not delete. You don't have permission to delete records.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetFocusOnFirstControl();
                    return;
                }
            }

            long DeletingID = 0;
            if (CrudDALObj != null && EditingRecord != null && EditingRecord is IDashboardViewModel)
            {
                DeletingID = EditingRecord.PrimeKeyID;
            }
            else
            {
                Alit.WinformControls.MessageBox.Show(this, "No record selected to delete.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BeforeDeleteValidationResult ValidationResult = OnValidateBeforeDelete(DeletingID);
            if (ValidationResult.IsValidForDelete)
            {
                if (Alit.WinformControls.MessageBox.Show(this, "Are you sure ? Do you want to delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    DeletingParameter para = new DeletingParameter();

                    //
                    ShowWaitForm();
                    beiProgressbar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    ProgressBarSavingProcess.Stopped = false;

                    await Task.Run(() => OnDeleteRecord(para));

                    ProgressBarSavingProcess.Stopped = true;
                    beiProgressbar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    CloseWaitForm();
                    //

                    OnAfterDeleteRecord(para);
                    if (para.DeletingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                Alit.WinformControls.MessageBox.Show(this, "Can not Delete.\r\n\r\n" + ValidationResult.ValidationMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnLoadLookupDataSource();
            OnAssignLookupDataSource();
            ClearValues(panelContent);
            SetFocusOnFirstControl();
        }

        private void btnSetSaveFocus_Enter(object sender, EventArgs e)
        {
            //barFormFooter.ItemLinks[0].Focus();
            btnSave.Links[0].Focus();
        }

        private void btnSetExitFocus_Click(object sender, EventArgs e)
        {
            btnExit.Links[0].Focus();
        }


        #endregion

        #region Methods
        void UpdateFormCaption()
        {
            switch (FormCurrentUI)
            {
                case eFormCurrentUI.NewEntry:
                    lblCurrentViewCaption.Caption = "New";
                    lblCurrentViewCaption.ItemAppearance.Normal.ForeColor = Color.RoyalBlue;
                    break;
                case eFormCurrentUI.Edit:
                    lblCurrentViewCaption.Caption = "Edit";
                    lblCurrentViewCaption.ItemAppearance.Normal.ForeColor = Color.Teal;
                    break;
                case eFormCurrentUI.Delete:
                    lblCurrentViewCaption.Caption = "Delete";
                    lblCurrentViewCaption.ItemAppearance.Normal.ForeColor = Color.DarkRed;
                    break;
                default:
                    lblCurrentViewCaption.Caption = "Display";
                    lblCurrentViewCaption.ItemAppearance.Normal.ForeColor = lblCurrentViewCaption.ItemAppearance.Hovered.ForeColor;
                    break;
            }
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

        public static void CallValidatingEvent(Control ControlToValidation)
        {
            IEnumerable<Control> ControlList = ControlToValidation.Controls.OfType<Control>();
            if (ControlList != null)
            {
                Type ControlType = typeof(Control);
                foreach (Control Cont in ControlList)
                {
                    if (Cont.Enabled && Cont.Visible)
                    {
                        Delegate DelValid = GetEventHandler(ControlType, Cont, "Validating");
                        if (DelValid != null)
                        {
                            DelValid.DynamicInvoke(Cont, new CancelEventArgs());
                        }
                        if (Cont.HasChildren)
                        {
                            CallValidatingEvent(Cont);
                        }
                    }
                }
            }
        }

        public static Delegate GetEventHandler(Type EventClass, object obj, string eventName)
        {
            Delegate retDelegate = null;
            FieldInfo fi = EventClass.GetField("Event" + eventName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            if (fi != null)
            {
                object value = fi.GetValue(obj);
                if (value is Delegate)
                    retDelegate = (Delegate)value;
                else if (value != null) // value may be just object
                {
                    PropertyInfo pi = obj.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (pi != null)
                    {
                        EventHandlerList eventHandlers = pi.GetValue(obj) as EventHandlerList;
                        if (eventHandlers != null)
                        {
                            retDelegate = eventHandlers[value];
                        }
                    }
                }
            }
            return retDelegate;
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
        #endregion
    }
}