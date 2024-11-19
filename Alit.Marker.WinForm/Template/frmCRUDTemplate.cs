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
using DevExpress.XtraGrid.Views.Grid;

namespace Alit.Marker.WinForm.Template
{
    public partial class frmCRUDTemplate : BaseTemplate
    {
        bool AllowNewEntryUI_ = true;
        [DefaultValue(true)]
        [Description("Allow New Entry UI Button to be visible")]
        public bool AllowNewEntryUI
        {
            get { return AllowNewEntryUI_; }
            set
            {
                if(value != AllowNewEntryUI_)
                {
                    AllowNewEntryUI_ = value;
                    //if(btnUINewEntry != null)
                    //{
                    //    btnUINewEntry.Visibility =
                    //        (AllowNewEntryUI_ ?
                    //        DevExpress.XtraBars.BarItemVisibility.Always :
                    //        DevExpress.XtraBars.BarItemVisibility.Never);
                    //}
                }
            }
        }

        bool AllowEditUI_ = true;
        [DefaultValue(true)]
        [Description("Allow Edit UI Button to be visible")]
        public bool AllowEditUI
        {
            get
            {
                return AllowEditUI_;
            }
            set
            {
                if (value != AllowEditUI_)
                {
                    AllowEditUI_ = value;
                    //if (btnUIEdit != null)
                    //{
                    //    btnUIEdit.Visibility =
                    //        (AllowEditUI_ ?
                    //        DevExpress.XtraBars.BarItemVisibility.Always :
                    //        DevExpress.XtraBars.BarItemVisibility.Never);
                    //}
                }
            }
        }

        bool AllowDeleteUI_ = true;
        [DefaultValue(true)]
        [Description("Allow Delete UI Button to be visible")]
        public bool AllowDeleteUI
        {
            get
            {
                return AllowDeleteUI_;
            }
            set
            {
                if (value != AllowDeleteUI_)
                {
                    AllowDeleteUI_ = value;
                    //if (btnUIDelete != null)
                    //{
                    //    btnUIDelete.Visibility =
                    //        (AllowDeleteUI_ ?
                    //        DevExpress.XtraBars.BarItemVisibility.Always :
                    //        DevExpress.XtraBars.BarItemVisibility.Never);
                    //}
                }
            }
        }

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
                    //if (btnSave != null)
                    //{
                    //    btnSave.Visibility =
                    //        (AllowSave_ ?
                    //        DevExpress.XtraBars.BarItemVisibility.Always :
                    //        DevExpress.XtraBars.BarItemVisibility.Never);
                    //}
                }
            }
        }

        bool AllowDelete_ = true;
        [DefaultValue(true)]
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
                        barBtnDelete.Visibility = btnDelete.Visibility =
                            (AllowDelete_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        bool AllowSearch_ = true;
        [DefaultValue(true)]
        [Description("Allow Search Button to be visible")]
        public bool AllowSearch
        {
            get
            {
                return AllowSearch_;
            }
            set
            {
                if (value != AllowSearch_)
                {
                    AllowSearch_ = value;
                    if (btnSearch != null)
                    {
                        barBtnSearch.Visibility = btnSearch.Visibility =
                            (AllowSearch_ ?
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
                        barBtnNew.Visibility = btnRefresh.Visibility =
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
                        barBtnPrint.Visibility = barBtnPrintPreview.Visibility = btnPrint.Visibility = btnPrintPreview.Visibility = (AllowPrint_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        eFormAllowedUIs FormAllowedUIs_ = eFormAllowedUIs.Display | eFormAllowedUIs.NewEntry | eFormAllowedUIs.Edit | eFormAllowedUIs.Delete;
        public eFormAllowedUIs FormAllowedUIs
        {
            get { return FormAllowedUIs_; }
            
            private set
            {
                FormAllowedUIs_ = value;
            }
        }

        public eFormCurrentUI FormCurrentUI { get; private set; }
        public eFormCurrentUI FormDefaultUI { get; private set; }
        
        /// <summary>
        /// Show Form As Normal CRUD form or dialogue form for a specific UI
        /// </summary>
        public eShowFormAs ShowFormAs { get; private set; }

        /// <summary>
        /// Is form shown as a dialogue form for a specific UI.
        /// </summary>
        public bool IsSpecificUIDialogue { get { return ShowFormAs != eShowFormAs.RegularForm; } }

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

        public virtual frmEditList EditListForm { get; set; }

        public bool ForceToReloadEditListDataSourceNextTime { get; set; }

        public object EditRecordDataSource 
        { 
            get
            {
                if (EditListForm == null) return null;
                return EditListForm.SelectedRecord;
            }
        }

        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManagerMain;

        //public event EventHandler ViewModelChanged;

        //ViewModelType ViewModel_;
        //public ViewModelType ViewModel
        //{
        //    get { return ViewModel_; }
        //    private set
        //    {
        //        ViewModel_ = value;
        //        OnViewModelChanged();
        //    }
        //}

        //protected virtual void OnViewModelChanged()
        //{
        //    if (ViewModelChanged != null)
        //    {
        //        ViewModelChanged(ViewModel, new EventArgs());
        //    }
        //}

        //public System.Windows.Forms.BindingSource ViewBindingSource { get; private set; }

        public frmCRUDTemplate()
            : this(new CRUDMTemplateParas())
        {

        }

        public frmCRUDTemplate(CRUDMTemplateParas Paras)
        {
            this.FormDefaultUI = Paras.FormDefaultUI;
            this.FormAllowedUIs = Paras.FormAllowedUIs;
            this.ShowFormAs = Paras.ShowFormAs;

            InitializeComponent();
            lblFormCaption.Caption = "";

            lblCreateAt.Caption = "";
            lblCreateAt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lblEditedAt.Caption = "";
            lblEditedAt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            lblFormCaption.Caption = this.Text;

            ShowWaitForm();
            InitializeUIButtons();
        }

        protected override void OnLoad(EventArgs e)
        {
            lblFormCaption.Caption = this.Text;
            base.OnLoad(e);

            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                backgroundWorkerLoadInitialValues.RunWorkerAsync();
            }
        }

        public void SetFormInitialView(eFormCurrentUI NewAction)
        {
            if (FirstControl != null) FirstControl.Focus();
            FormCurrentUI = NewAction;
            //this.lblFormCaption.Caption = this.Text;
            UpdateFormCaption();
            InitializeDefaultValues();
        }

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

        private void backgroundWorkerLoadInitialValues_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadFormValues();
            LoadLookupDataSource();
            //this.Invoke((MethodInvoker)delegate { LoadFormValues(); });
        }

        private void backgroundWorkerLoadInitialValues_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate { AssignLookupDataSource(); AssignFormValues(); SetFormInitialView(FormDefaultUI); CloseWaitForm(); });
        }

        public void ResetFormView(eFormCurrentUI NewAction)
        {
            ResetFormView(NewAction, null);
        }
        public void ResetFormView(eFormCurrentUI NewAction, object EditingObjectPara)
        {
            FormCurrentUI = NewAction;
            UpdateFormCaption();

            //btnUINewEntry.Checked = (NewAction == eFormCurrentUI.NewEntry);
            //btnUIEdit.Checked = (NewAction == eFormCurrentUI.Edit);
            //btnUIDelete.Checked = (NewAction == eFormCurrentUI.Delete);

            AllowDelete = false; 
            ClearValues();
            InitializeDefaultValues();

            lblCreateAt.Caption = "";
            lblCreateAt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lblEditedAt.Caption = "";
            lblEditedAt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (NewAction == eFormCurrentUI.Edit || NewAction == eFormCurrentUI.Delete)
            {
                object EditingRecord = null;
                if (EditingObjectPara != null)
                {
                    EditingRecord = EditingObjectPara;
                }
                else
                {
                    EditingRecord = ShowEditListForm();
                }
                if (EditingRecord != null)
                {
                    //--
                    if(EditingRecord is EditUserInfo)
                    {
                        EditUserInfo edituser = (EditUserInfo)EditingRecord;
                        if (!String.IsNullOrWhiteSpace(edituser.CreatedUserName) || edituser.CreatedDateTime.HasValue)
                        {
                            lblCreateAt.Caption = string.Format("Create by {0} at {1}", edituser.CreatedUserName ?? "", (edituser.CreatedDateTime.HasValue ? edituser.CreatedDateTime.Value.ToLongDateString() + " " + edituser.CreatedDateTime.Value.ToShortTimeString() : ""));
                            lblCreateAt.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        }
                        if (!String.IsNullOrWhiteSpace(edituser.EditedUserName) || edituser.EditedDateTime.HasValue)
                        {
                            lblEditedAt.Caption = string.Format("Edited by {0} at {1}", edituser.EditedUserName ?? "", (edituser.EditedDateTime.HasValue ? edituser.EditedDateTime.Value.ToLongDateString() + " " + edituser.EditedDateTime.Value.ToShortTimeString() : ""));
                            lblEditedAt.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        }
                    }
                    //--
                    FillSelectedRecordInContent(EditingRecord);

                    // if Editing UI and delete is allowed
                    if(NewAction == eFormCurrentUI.Edit && AllowDeleteUI)
                    {
                        AllowDelete = true;
                    }
                    else if(NewAction == eFormCurrentUI.Delete)
                    {
                        btnDelete.PerformClick();
                    }
                }
                else
                {
                    if (EditListForm.IsSelectButtonClicked)
                    {
                        Alit.WinformControls.MessageBox.Show(this, "Can not " + (NewAction == eFormCurrentUI.Delete ? "delete" : "edit") + ". Record not found.");
                    }
                    if (AllowNewEntryUI)
                    {
                        ResetFormView(eFormCurrentUI.NewEntry);
                        return;
                    }
                    else
                    {
                        this.Close();
                        return;
                    }
                }
            }

            this.ErrorProvider.Clear();

            SetFocusOnFirstControl();
        }

        /// <summary>
        /// Set UI buttons visibility as per settings
        /// </summary>
        void InitializeUIButtons()
        {
            if (this.ShowFormAs == eShowFormAs.RegularForm)
            {
                AllowNewEntryUI = FormAllowedUIs_.HasFlag(eFormAllowedUIs.NewEntry);
                AllowEditUI = FormAllowedUIs_.HasFlag(eFormAllowedUIs.Edit);

                if (FormAllowedUIs_.HasFlag(eFormAllowedUIs.Delete))
                {
                    AllowDeleteUI = true;
                    AllowDelete = true;
                }
                else
                {
                    AllowDeleteUI = false;
                    AllowDelete = false;
                }

                AllowSearch = (AllowEditUI || AllowDeleteUI);
            }
            else
            {
                AllowNewEntryUI = (this.ShowFormAs == eShowFormAs.NewEntryDialogue);
                AllowEditUI = (this.ShowFormAs == eShowFormAs.EditDialogue);

                if (this.ShowFormAs == eShowFormAs.DeleteDialogue)
                {
                    AllowDeleteUI = true;
                    AllowDelete = true;
                }
                else
                {
                    AllowDeleteUI = false;
                    AllowDelete = false;
                }

                //switch (this.ShowFormAs)
                //{
                //    case eShowFormAs.NewEntryDialogue:
                //        btnUINewEntry.Checked = true;
                //        btnUINewEntry.Enabled = false;
                //        break;
                //    case eShowFormAs.EditDialogue:
                //        btnUIEdit.Checked = true;
                //        btnUIEdit.Enabled = false;
                //        break;
                //    case eShowFormAs.DeleteDialogue:
                //        btnUIDelete.Checked = true;
                //        btnUIDelete.Enabled = false;
                //        break;
                //}

                AllowSearch = false;
                AllowRefresh = false;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
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

        #region Virtual Methods

        public virtual bool ValidateBeforeSave()
        {
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
                        //Alit.WinformControls.ToastNotification.Show(this, "Record saved successfully");
                        ForceToReloadEditListDataSourceNextTime = true;
                        if(!String.IsNullOrWhiteSpace(Paras.SavingResult.MessageAfterSave))
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

        public virtual BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return new BeforeDeleteValidationResult()
            {
                IsValidForDelete = false,
                ValidationMessage = "Before delete validation is not implemented"
            };
        }

        public virtual void DeleteRecord(DeletingParameter Paras)
        {

        }

        public virtual void AfterDeleteRecord(DeletingParameter Paras)
        {
            switch (Paras.DeletingResult.ExecutionResult)
            {
                case eExecutionResult.CommitedSucessfuly:
                    //Alit.WinformControls.ToastNotification.Show(this, "Record deleted successfully");
                    ForceToReloadEditListDataSourceNextTime = true;
                    if (!String.IsNullOrWhiteSpace(Paras.DeletingResult.MessageAfterSave))
                    {
                        Alit.WinformControls.MessageBox.Show(this, Paras.DeletingResult.MessageAfterSave, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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

        /// <summary>
        /// Clear control values or set it to default values. It is for refresh form values
        /// </summary>
        public virtual void ClearValues()
        {
            ClearValues(panelContent);
        }

        public static void ClearValues(Control ParentControl)
        {
            foreach (Control Cnt in ParentControl.Controls)
            {
                if (Cnt.HasChildren)
                {
                    ClearValues(Cnt);
                }
                else if( (Cnt is LookUpEdit) || (Cnt.Parent is LookUpEdit)) 
                {
                    if ((Cnt.Parent is LookUpEdit))
                    {
                        LookUpEdit LookupControl = (LookUpEdit)Cnt.Parent;
                        LookupControl.EditValue = null;
                    }
                }
                else if (Cnt is DateEdit || Cnt.Parent is DateEdit) { }
                else if (Cnt is CheckEdit || Cnt.Parent is CheckEdit) { }
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
                //else if (Cnt is TextBox)
                //{
                //    Cnt.Text = "";
                //}
                //else if (Cnt is ComboBox)
                //{
                //    ComboBox cmb = (ComboBox)Cnt;

                //    if (cmb.DropDownStyle == ComboBoxStyle.DropDownList)
                //    {
                //        if (cmb.Items.Count > 0) cmb.SelectedIndex = 0;
                //        else cmb.SelectedIndex = -1;
                //    }
                //    else
                //    {
                //        cmb.SelectedIndex = -1;
                //        cmb.Text = "";
                //    }
                //}
                //else if (Cnt is MaskedTextBox)
                //{
                //    ((MaskedTextBox)Cnt).Clear();
                //}
            }
        }

        public virtual void InitializeDefaultValues() { }

        public virtual void LoadLookupDataSource() { }
        public virtual void AssignLookupDataSource() { }

        /// <summary>
        /// After set a view like entry/edit/search. Form current view can be access by "this.CurrentView"
        /// </summary>
        public virtual void AfterSetView() { }

        /// <summary>
        /// Load/generate values that takes time to process like generating invoice number. 
        /// </summary>
        public virtual void LoadFormValues() { }

        public virtual void AssignFormValues() { }

        public virtual void InitializeEditListForm()
        {
            EditListForm = new frmEditList(this);
            EditListForm.AllowPrint = this.AllowPrint;
        }
        
        /// <summary>
        /// Show Edit List Form and will return selected record object
        /// </summary>
        /// <returns></returns>
        public virtual object ShowEditListForm()
        {
            ShowWaitForm();

            //DateTime t = DateTime.Now.AddSeconds(5);
            //while (t > DateTime.Now) { }
            if (EditListForm == null) InitializeEditListForm();

            if (EditListForm != null)
            {
                if (EditListForm.EditListDataSource == null || ForceToReloadEditListDataSourceNextTime)
                {
                    ForceToReloadEditListDataSourceNextTime = false;
                    EditListForm.UpdateDataSource(GetEditListDataSource());
                    FormatEditListGridView((GridView)EditListForm.gridEditList.MainView);
                }

                CloseWaitForm();
                EditListForm.ShowDialog(this);

                if (EditListForm.IsSelectButtonClicked)
                {
                    return EditListForm.SelectedRecord;
                }
            }
            CloseWaitForm();
            return null;
        }

        public virtual object GetEditListDataSource()
        {
            return null;
        }
        public virtual void FormatEditListGridView(GridView EditListGrid)
        {

        }

        /// <summary>
        /// Fill information of selected record in display grid. Occures when row selection will change.
        /// </summary>
        /// <param name="RecordIndex">Selected Row's Index</param>
        public virtual void FillSelectedRecordInContent(object RecordToFill)
        {

        }

        #endregion

        #region Action Methods

        async Task<SavingParemeter> PerformSaving()
        {
            if (MenuOptionPermission != null)
            {
                if (FormCurrentUI == eFormCurrentUI.NewEntry && !MenuOptionPermission.CanAdd)
                {
                    Alit.WinformControls.MessageBox.Show(this, "Can not add new records. You don't have permission to save new records.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetFocusOnFirstControl();
                    return new SavingParemeter() { SavingResult = new SavingResult() { ExecutionResult = eExecutionResult.ValidationError, ValidationError = "Permission denied." } };
                }
                else if (FormCurrentUI == eFormCurrentUI.Edit && !MenuOptionPermission.CanEdit)
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

            if (!ValidateBeforeSave())
            {
                // it's implementing class responsibiliy to set focus on appropriate control.
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

            //--
            AfterSaving(savingParas);
            //--
            return savingParas;
        }

        private async void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SavingParemeter savingParas = await PerformSaving();

            if (savingParas != null && savingParas.SavingResult != null && savingParas.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                //ClearValues();
                //ResetFormView(FormCurrentUI);
                ResetFormView(FormDefaultUI);
            }
            SetFocusOnFirstControl();
        }

        private async void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool HasPermissionToSave = true;
            if (MenuOptionPermission != null)
            {
                if (FormCurrentUI == eFormCurrentUI.NewEntry && !MenuOptionPermission.CanAdd)
                {
                    Alit.WinformControls.MessageBox.Show(this, "Can not add new records. You don't have permission to save new records.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetFocusOnFirstControl();
                    return;
                }
                else if (FormCurrentUI == eFormCurrentUI.Edit && !MenuOptionPermission.CanEdit)
                {
                    HasPermissionToSave = false;
                }
            }

            if (HasPermissionToSave && (FormCurrentUI == eFormCurrentUI.NewEntry || Alit.WinformControls.MessageBox.Show(this, "Do you want to save before print ? \r\n Please note : if you choose 'No' then changes will not reflect in print.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
            {
                SavingParemeter savingParas = await PerformSaving();

                if (savingParas.SavingResult != null && savingParas.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                {
                    ExecuteDirectPrint(savingParas.SavingResult.PrimeKeyValue);
                    ResetFormView(FormDefaultUI);
                }
            }
            else
            {
                ExecuteDirectPrint(EditRecordDataSource);
                ResetFormView(FormDefaultUI);
            }
            //--
            SetFocusOnFirstControl();
        }

        private async void btnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool HasPermissionToSave = true;
            if (MenuOptionPermission != null)
            {
                if (FormCurrentUI == eFormCurrentUI.NewEntry && !MenuOptionPermission.CanAdd)
                {
                    Alit.WinformControls.MessageBox.Show(this, "Can not add new records. You don't have permission to save new records.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetFocusOnFirstControl();
                    return;
                }
                else if (FormCurrentUI == eFormCurrentUI.Edit && !MenuOptionPermission.CanEdit)
                {
                    HasPermissionToSave = false;
                }
            }

            if (HasPermissionToSave && (FormCurrentUI == eFormCurrentUI.NewEntry || Alit.WinformControls.MessageBox.Show(this, "Do you want to save before print ? \r\n Please note : if you choose 'No' then changes will not reflect in print preview.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
            {
                SavingParemeter savingParas = await PerformSaving();

                if (savingParas.SavingResult != null && savingParas.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                {
                    ExecuteDirectPrintPreview(savingParas.SavingResult.PrimeKeyValue);
                    ResetFormView(FormDefaultUI);
                }
            }
            else
            {
                ExecuteDirectPrintPreview(EditRecordDataSource);
                ResetFormView(FormDefaultUI);
            }
            //--
            FirstControl.Focus();
        }


        public void ExecuteDirectPrintPreview(object PrintParaValue)
        {
            DirectPrintPreview(PrintParaValue);
        }

        public void ExecuteDirectPrint(object PrintParaValue)
        {
            DirectPrint(PrintParaValue);
        }

        public virtual void DirectPrintPreview(object PrintParaValue)
        {

        }

        public virtual void DirectPrint(object PrintParaValue)
        {

        }

        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MenuOptionPermission != null)
            {
                if (!MenuOptionPermission.CanDelete)
                {
                    Alit.WinformControls.MessageBox.Show(this, "Can not delete. You don't have permission to delete records.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetFocusOnFirstControl();
                    return;
                }
            }

            BeforeDeleteValidationResult ValidationResult = ValidateBeforeDelete();
            if (ValidationResult.IsValidForDelete)
            {
                if (Alit.WinformControls.MessageBox.Show(this, "Are you sure ? Do you want to delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    DeletingParameter para = new DeletingParameter();

                    //
                    ShowWaitForm();
                    beiProgressbar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    ProgressBarSavingProcess.Stopped = false;
                    //try
                    //{
                    await Task.Run(() => DeleteRecord(para) );
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

                    AfterDeleteRecord(para);
                    if (para.DeletingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                    {
                        ForceToReloadEditListDataSourceNextTime = true;
                        //ResetFormView(FormCurrentUI);
                        ResetFormView(FormDefaultUI);
                    }
                }
                //else
                //{
                    //ResetFormView(FormDefaultUI);
                    //ResetFormView(FormCurrentUI);
                    //btnUIDelete.PerformClick();
                //}
            }
            else
            {
                Alit.WinformControls.MessageBox.Show(this, "Can not Delete.\r\n\r\n" + ValidationResult.ValidationMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //ResetFormView(FormCurrentUI);
                //ResetFormView(FormDefaultUI);
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadLookupDataSource();
            AssignLookupDataSource();
            ResetFormView(eFormCurrentUI.NewEntry);
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (AllowEditUI || AllowDeleteUI)
            {
                ResetFormView((AllowEditUI ? eFormCurrentUI.Edit : eFormCurrentUI.Delete));
            }
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
            //barFormFooter.ItemLinks[0].Focus();
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

        private void btnCloseForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }

    #region Supporting Classes

    public class MemoryManagement
    {
        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet =
        CharSet.Ansi, SetLastError = true)]

        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int
        maximumWorkingSetSize);

        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
    }

#endregion
}