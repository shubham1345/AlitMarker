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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Alit.Marker.Model.Template;
using Alit.Marker.DAL.Template;
using DevExpress.XtraPrinting;
using System.IO;
using System.Xml;

namespace Alit.Marker.WinForm.Template
{
    public partial class frmGridCRUDTemplate : XtraForm
    {
        #region Visibility Command Buttons

        bool AllowDeleteVisible_ = true;
        [DefaultValue(true)]
        [Description("Allow Delete Button to be visible")]
        public bool AllowDeleteVisible
        {
            get
            {
                return AllowDeleteVisible_;
            }
            set
            {
                if (value != AllowDeleteVisible_)
                {
                    AllowDeleteVisible_ = value;
                    if (btnDelete != null)
                    {
                        btnDelete.Visibility = btnDelete.Visibility =
                            (AllowDeleteVisible_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }


        bool AllowRefreshVisible_ = true;
        [DefaultValue(true)]
        [Description("Allow Refresh Button to be visible")]
        public bool AllowRefreshVisible
        {
            get
            {
                return AllowRefreshVisible_;
            }
            set
            {
                if (value != AllowRefreshVisible_)
                {
                    AllowRefreshVisible_ = value;
                    if (btnRefresh != null)
                    {
                        btnRefresh.Visibility = btnRefresh.Visibility =
                            (AllowRefreshVisible_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        //bool AllowExitVisible_ = true;
        //[DefaultValue(true)]
        //[Description("Allow Exit Button to be visible")]
        //public bool AllowExitVisible
        //{
        //    get
        //    {
        //        return AllowExitVisible_;
        //    }
        //    set
        //    {
        //        if (value != AllowExitVisible_)
        //        {
        //            AllowExitVisible_ = value;
        //            if (btnExit != null)
        //            {
        //                btnExit.Visibility =
        //                    (AllowExitVisible_ ?
        //                    DevExpress.XtraBars.BarItemVisibility.Always :
        //                    DevExpress.XtraBars.BarItemVisibility.Never);
        //            }
        //        }
        //    }
        //}

        bool AllowCrudGridPrintVisible_ = false;
        [DefaultValue(false)]
        [Description("Allow Print Button to be visible")]
        public bool AllowCrudGridPrintVisible
        {
            get
            {
                return AllowCrudGridPrintVisible_;
            }
            set
            {
                if (value != AllowCrudGridPrintVisible_)
                {
                    AllowCrudGridPrintVisible_ = value;
                    if (btnCrudGridPrint != null)
                    {
                        btnCrudGridPrint.Visibility =
                        btnCrudGridPrintPreview.Visibility =
                        btnCrudGridExportTo.Visibility = (AllowCrudGridPrintVisible_ ?
                                                            DevExpress.XtraBars.BarItemVisibility.Always :
                                                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        #endregion

        #region Editablity Command Buttons
        bool AllowAddNewEnable_ = true;
        [DefaultValue(true)]
        [Description("Allow AddNew Button to be Enable")]
        public bool AllowAddNewEnable
        {
            get
            {
                return AllowAddNewEnable_;
            }
            set
            {
                if (value != AllowAddNewEnable_)
                {
                    AllowAddNewEnable_ = value;
                    if (this.CrudGridView_ != null)
                    {
                        this.CrudGridView_.OptionsView.NewItemRowPosition = (AllowAddNewEnable_ ? NewItemRowPosition.Top : NewItemRowPosition.None);
                    }
                }
            }
        }

        bool AllowEditEnable_ = true;
        [DefaultValue(true)]
        [Description("Allow Edit Button to be Enable")]
        public bool AllowEditEnable
        {
            get
            {
                return AllowEditEnable_;
            }
            set
            {
                if (value != AllowEditEnable_)
                {
                    AllowEditEnable_ = value;
                    //if (btnEdit != null)
                    //{
                    //    btnEdit.Enabled = AllowEditEnable_;
                    //}
                }
            }
        }

        bool AllowDeleteEnable_ = true;
        [DefaultValue(true)]
        [Description("Allow Delete Button to be Enable")]
        public bool AllowDeleteEnable
        {
            get
            {
                return AllowDeleteEnable_;
            }
            set
            {
                if (value != AllowDeleteEnable_)
                {
                    AllowDeleteEnable_ = value;
                    if (btnDelete != null)
                    {
                        btnDelete.Enabled = AllowDeleteEnable_;
                    }
                }
            }
        }


        bool AllowRefreshEnable_ = true;
        [DefaultValue(true)]
        [Description("Allow Refresh Button to be Enable")]
        public bool AllowRefreshEnable
        {
            get
            {
                return AllowRefreshEnable_;
            }
            set
            {
                if (value != AllowRefreshEnable_)
                {
                    AllowRefreshEnable_ = value;
                    if (btnRefresh != null)
                    {
                        btnRefresh.Enabled = AllowRefreshEnable_;
                    }
                }
            }
        }

        //bool AllowExitEnable_ = true;
        //[DefaultValue(true)]
        //[Description("Allow Exit Button to be Enable")]
        //public bool AllowExitEnable
        //{
        //    get
        //    {
        //        return AllowExitEnable_;
        //    }
        //    set
        //    {
        //        if (value != AllowExitEnable_)
        //        {
        //            AllowExitEnable_ = value;
        //            if (btnExit != null)
        //            {
        //                btnExit.Enabled = AllowExitEnable_;
        //            }
        //        }
        //    }
        //}

        bool AllowPrintEnable_ = false;
        [DefaultValue(false)]
        [Description("Allow Print Button to be Enable")]
        public bool AllowPrintEnable
        {
            get
            {
                return AllowPrintEnable_;
            }
            set
            {
                if (value != AllowPrintEnable_)
                {
                    AllowPrintEnable_ = value;
                    if (btnCrudGridPrint != null)
                    {
                        btnCrudGridPrint.Enabled = btnCrudGridPrintPreview.Enabled = AllowPrintEnable_;
                    }
                }
            }
        }


        bool AllowLockVisible_ = false;
        [DefaultValue(false)]
        [Description("Allow Lock Button to be Visible")]
        public bool AllowLockVisible
        {
            get
            {
                return AllowLockVisible_;
            }
            set
            {
                if (value != AllowLockVisible_)
                {
                    AllowLockVisible_ = value;
                    if (btnLock != null)
                    {
                        btnLock.Visibility = (AllowLockVisible_ ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        bool AllowUnLockVisible_ = false;
        [DefaultValue(false)]
        [Description("Allow UnLock Button to be Visible")]
        public bool AllowUnLockVisible
        {
            get
            {
                return AllowUnLockVisible_;
            }
            set
            {
                if (value != AllowUnLockVisible_)
                {
                    AllowUnLockVisible_ = value;
                    if (btnUnLock != null)
                    {
                        btnUnLock.Visibility = (AllowUnLockVisible_ ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        bool AllowActivateVisible_ = false;
        [DefaultValue(false)]
        [Description("Allow Activate Button to be Visible")]
        public bool AllowActivateVisible
        {
            get
            {
                return AllowActivateVisible_;
            }
            set
            {
                if (value != AllowActivateVisible_)
                {
                    AllowActivateVisible_ = value;
                    if (btnActivate != null)
                    {
                        btnActivate.Visibility = (AllowActivateVisible_ ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        bool AllowDeactivateVisible_ = false;
        [DefaultValue(false)]
        [Description("Allow Deactivate Button to be Visible")]
        public bool AllowDeactivateVisible
        {
            get
            {
                return AllowDeactivateVisible_;
            }
            set
            {
                if (value != AllowDeactivateVisible_)
                {
                    AllowDeactivateVisible_ = value;
                    if (btnDeactivate != null)
                    {
                        btnDeactivate.Visibility = (AllowDeactivateVisible_ ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        #endregion

        #region Document Print Command Buttons
        bool AllowDocumentPrintAndExport_;
        [DefaultValue(false)]
        [Description("Allow to show document print & export command buttons")]

        public bool AllowDocumentPrintAndExport
        {
            get
            {
                return AllowDocumentPrintAndExport_;
            }
            set
            {
                if (AllowDocumentPrintAndExport_ != value)
                {
                    AllowDocumentPrintAndExport_ = value;
                    barDocumentPrint.Visible = AllowDocumentPrintAndExport_;
                }
            }
        }
        #endregion

        #region Base Form
        int MenuOptionID_;
        public int MenuOptionID
        {
            get
            {
                return MenuOptionID_;
            }
            set
            {

                if (MenuOptionID_ != value)
                {
                    MenuOptionID_ = value;

                    //DAL.Users.UserGroupDAL UGDALObj = new DAL.Users.UserGroupDAL();
                    var perm = Model.CommonProperties.LoginInfo.UserPermission.FirstOrDefault(r => r.MenuOptionID == MenuOptionID_);
                    if (perm != null)
                    {
                        UserMenuPermission = perm;
                    }
                    else
                    {
                        UserMenuPermission = new Model.Users.UserGroup.MenuOptionPermissionViewModel()
                        {
                            MenuOptionID = MenuOptionID_,
                            CanAdd = true,
                            CanDelete = true,
                            CanEdit = true,
                            CanView = true,
                            //CanPrint = true,
                        };
                    }
                    if (Model.CommonProperties.LoginInfo.LoggedinUser.SuperUser)
                    {
                        UserMenuPermission.CanAdd = true;
                        UserMenuPermission.CanEdit = true;
                        UserMenuPermission.CanDelete = true;
                        //UserMenuPermission.CanPrint = true;
                    }
                }
            }
        }

        public Model.Users.UserGroup.MenuOptionPermissionViewModel UserMenuPermission { get; set; }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            MemoryManagement.FlushMemory();
        }

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
        #endregion

        #region Crud Grid Control and Datasource
        public DAL.Template.IGridCRUDDAL CrudDALObj { get; set; }

        public IEnumerable<IGridCRUDViewModel> GridDataSource { get; set; }

        #endregion

        public virtual Type CrudFormType { get { return typeof(frmCRUDTemplate); } }

        public GridControl CrudGridControl { get; set; }

        GridView CrudGridView_;
        public GridView CrudGridView
        {
            get
            {
                return this.CrudGridView_;
            }
            set
            {
                this.CrudGridView_ = value;
                if (this.CrudGridView_ != null)
                {
                    this.CrudGridView.DetailHeight = 431;
                    //this.CrudGridView.GridControl = this.CrudGridControl;
                    this.CrudGridView.Name = "CrudGridView";
                    this.CrudGridView.OptionsBehavior.AutoExpandAllGroups = true;
                    this.CrudGridView.OptionsBehavior.FocusLeaveOnTab = true;
                    this.CrudGridView.OptionsNavigation.EnterMoveNextColumn = true;
                    this.CrudGridView.OptionsNavigation.UseTabKey = false;
                    this.CrudGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
                    this.CrudGridView.OptionsSelection.EnableAppearanceHideSelection = false;
                    this.CrudGridView.OptionsSelection.MultiSelect = true;
                    this.CrudGridView.OptionsView.AutoCalcPreviewLineCount = true;
                    this.CrudGridView_.OptionsView.NewItemRowPosition = (AllowAddNewEnable_ ? NewItemRowPosition.Top : NewItemRowPosition.None);
                    this.CrudGridView.OptionsView.ShowGroupPanel = false;
                    this.CrudGridView.OptionsView.ShowPreview = true;
                    this.CrudGridView.PreviewFieldName = "RowError";

                    CrudGridView.Appearance.FocusedCell.BackColor = CrudGridView.Appearance.SelectedRow.BackColor;
                    CrudGridView.Appearance.FocusedCell.ForeColor = CrudGridView.Appearance.SelectedRow.ForeColor;
                    CrudGridView.ShowFindPanel();
                    Font RegularFont = new Font("Arial", 10, FontStyle.Regular);
                    Font BoldFont = new Font("Arial", 10, FontStyle.Bold);
                    CrudGridView.AppearancePrint.Row.Font = RegularFont;
                    CrudGridView.AppearancePrint.HeaderPanel.Font = BoldFont;
                    CrudGridView.AppearancePrint.GroupFooter.Font = BoldFont;
                    CrudGridView.AppearancePrint.GroupFooter.Font = BoldFont;
                    CrudGridView.Appearance.FooterPanel.Font = BoldFont;
                    CrudGridView.Appearance.GroupRow.Font = BoldFont;
                    CrudGridView.Appearance.ViewCaption.Font = BoldFont;
                    CrudGridView.Appearance.Preview.ForeColor = Color.Red;

                    this.CrudGridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.CrudGridView_RowStyle);
                    this.CrudGridView.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.CrudGridView_ShowingEditor);
                    this.CrudGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.CrudGridView_FocusedRowChanged);
                    this.CrudGridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.CrudGridView_RowUpdated);

                }
            }
        }


        #region fields
        Dictionary<string, MemoryStream> GridGridViewDefaultLayoutStreams;
        protected BindingSource bindingSource;
        #endregion

        #region Contructor & destructure

        public frmGridCRUDTemplate()
        {
            GridGridViewDefaultLayoutStreams = new Dictionary<string, MemoryStream>();
            //--
            InitializeComponent();
            lblFormCaption.Text = this.Text;

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

            AllowEditEnable = false;
            AllowDeleteEnable = false;
            AllowCrudGridPrintVisible = false;
            AllowPrintEnable = false;

            CrudDALObj = GetGridCRUDDALObj();
            bindingSource = new BindingSource();

            ShowWaitForm();
        }

        ~frmGridCRUDTemplate()
        {
            foreach (var stream in GridGridViewDefaultLayoutStreams)
            {
                stream.Value.Close();
                stream.Value.Dispose();
            }
        }
        #endregion

        #region Parent Overriden Methods
        protected override void OnTextChanged(EventArgs e)
        {
            lblFormCaption.Text = this.Text;
            base.OnTextChanged(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            lblFormCaption.Text = this.Text;
            base.OnLoad(e);

            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                backgroundWorkerLoadInitialValues.RunWorkerAsync();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            SaveCrudGridLayout();
            base.OnClosing(e);
        }
        #endregion

        #region Events
        private void backgroundWorkerLoadInitialValues_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadFormValues();
            LoadLookupDataSource();
            //this.Invoke((MethodInvoker)delegate { LoadFormValues(); });
        }

        private void backgroundWorkerLoadInitialValues_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                AssignLookupDataSource();
                AssignFormValues();

                ReloadCrudData();

                foreach (DevExpress.XtraGrid.Views.Base.BaseView view in CrudGridControl.Views)
                {
                    MemoryStream stream = new MemoryStream();
                    view.SaveLayoutToStream(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    GridGridViewDefaultLayoutStreams.Add(view.Name, stream);
                }

                RestoreCrudGridLayout();
                CloseWaitForm();
            });
        }

        #region Grid View
        private void CrudGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ResetRowView(CrudGridView.GetFocusedRow());
        }


        private void btnResetCrudGridLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CrudGridControl != null)
            {
                foreach (DevExpress.XtraGrid.Views.Base.BaseView view in CrudGridControl.Views)
                {
                    if (GridGridViewDefaultLayoutStreams.ContainsKey(view.Name))
                    {
                        MemoryStream stream = GridGridViewDefaultLayoutStreams[view.Name];
                        view.RestoreLayoutFromStream(stream);
                        stream.Seek(0, System.IO.SeekOrigin.Begin);
                    }
                }
            }
        }

        private void CrudGridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            e.HighPriority = true;
            if (e.State.HasFlag(DevExpress.XtraGrid.Views.Base.GridRowCellState.Selected))
            {
                e.CombineAppearance(CrudGridView.Appearance.SelectedRow);
            }
            var Row = (IGridCRUDViewModel)CrudGridView.GetRow(e.RowHandle);
            if (Row != null)
            {
                if (!String.IsNullOrWhiteSpace(Row.RowError))
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                else
                {
                    switch (Row.RecordState)
                    {
                        case eRecordState.Locked:
                            e.Appearance.ForeColor = CommonPropperties.RecordStateForeColor_Locked_ForeColor;
                            e.Appearance.BackColor = CommonPropperties.RecordStateForeColor_Locked_BackColor;
                            break;
                        case eRecordState.Deactivated:
                            e.Appearance.ForeColor = CommonPropperties.RecordStateForeColor_Deactivated_ForeColor;
                            e.Appearance.BackColor = CommonPropperties.RecordStateForeColor_Deactivated_BackColor;
                            break;
                    }
                }
            }
        }

        private async void CrudGridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null)
            {
                return;
            }

            await PerformSaving((IGridCRUDViewModel)e.Row, e.RowHandle);

        }


        #endregion

        #region CRUD Operation events
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadLookupDataSource();
            AssignLookupDataSource();
            ReloadCrudData();
        }

        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UserMenuPermission != null)
            {
                if (!UserMenuPermission.CanDelete)
                {
                    Alit.WinformControls.MessageBox.Show(this, "Can not delete. You don't have permission to delete records.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            object SelectedRecord = CrudGridView.GetFocusedRow();
            if (SelectedRecord == null)
            {
                return;
            }

            BeforeDeleteValidationResult ValidationResult = null;
            if (SelectedRecord is IGridCRUDViewModel)
            {
                long PrimeKeyID = ((IGridCRUDViewModel)SelectedRecord).PrimeKeyID;

                ValidationResult = ValidateBeforeDelete(PrimeKeyID);

                if (ValidationResult.IsValidForDelete)
                {
                    if (Alit.WinformControls.MessageBox.Show(this, "Are you sure ? Do you want to delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        DeletingParameter para = new DeletingParameter() { PrimeKeyID = PrimeKeyID };

                        //
                        ShowWaitForm();
                        //beiProgressbar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        //ProgressBarSavingProcess.Stopped = false;

                        await Task.Run(() => DeleteRecord(para));

                        //ProgressBarSavingProcess.Stopped = true;
                        //beiProgressbar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        CloseWaitForm();
                        //

                        AfterDeleteRecord(para);

                        if (para.DeletingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                        {
                            bindingSource.Remove(SelectedRecord);
                            //ReloadCrudData();
                        }
                    }
                }
                else
                {
                    Alit.WinformControls.MessageBox.Show(this, "Can not Delete.\r\n\r\n" + ValidationResult.ValidationMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


        async Task<SavingParemeter> PerformSaving(IGridCRUDViewModel ViewModel, int RowHandle)
        {
            if (UserMenuPermission != null)
            {
                if (ViewModel.PrimeKeyID == 0 && !UserMenuPermission.CanAdd)
                {
                    Alit.WinformControls.MessageBox.Show(this, "Can not add new records. You don't have permission to save new records.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new SavingParemeter() { SavingResult = new SavingResult() { ExecutionResult = eExecutionResult.ValidationError, ValidationError = "Permission denied." } };
                }
                else if (ViewModel.PrimeKeyID != 0 && !UserMenuPermission.CanEdit)
                {
                    Alit.WinformControls.MessageBox.Show(this, "Can not edit. You don't have permission to edit records.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new SavingParemeter() { SavingResult = new SavingResult() { ExecutionResult = eExecutionResult.ValidationError, ValidationError = "Permission denied." } };
                }
            }

            if (!ValidateBeforeSave(ViewModel))
            {
                return null;
            }

            SavingParemeter savingParas = new SavingParemeter();
            ShowWaitForm();
            //try
            //{
            await Task.Run(() => SaveRecord(savingParas, ViewModel));
            //}
            //catch (Exception ex)
            //{
            //    beiProgressbar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    CloseWaitForm();

            //    throw ex;
            //}
            CloseWaitForm();
            //--
            AfterSaving(savingParas, ViewModel);
            //CrudGridView.RefreshRow(RowHandle);
            bindingSource.ResetCurrentItem();

            if (CrudGridView.FocusedRowHandle >= 0)
            {
                CrudGridView.MakeRowVisible(CrudGridView.FocusedRowHandle);
            }
            //--
            return savingParas;
        }

        #endregion

        #region Lock & UnLock, Activate & Deactivate
        private void btnLock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteLock();
        }

        private void btnUnLock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteUnLock();
        }

        private void btnDeactivate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteDeActivateRecord();
        }

        private void btnActivate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteActivateRecord();
        }
        #endregion

        #region Crud Print & Export
        private void btnCrudGridPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteCrudGridPrint();
        }

        private void btnCrudGridPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteCrudGridPrintPreview();
        }

        private void btnCrudGridExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteCrudGridExportToExcel();
        }

        private void btnCrudGridExportToPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteCrudGridExportToPDF();
        }

        private void btnCrudGridExportToWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteCrudGridExportToWord();
        }

        private void btnCrudGridExportToCSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteCrudGridExportToCSV();
        }

        private void btnCrudGridExportToText_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteCrudGridExportToText();
        }

        private void btnCrudGridExportToImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteCrudGridExportToImage();
        }
        #endregion

        #region Document Print & Export
        private void btnDocumentPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CrudGridView != null)
            {
                var Row = CrudGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IGridCRUDViewModel)
                {
                    DocumentPrintPreview(((IGridCRUDViewModel)Row).PrimeKeyID);
                }
            }
        }

        private void btnDocumentPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CrudGridView != null)
            {
                var Row = CrudGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IGridCRUDViewModel)
                {
                    DocumentPrint(((IGridCRUDViewModel)Row).PrimeKeyID);
                }
            }
        }

        private void btnDocumentExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CrudGridView != null)
            {
                var Row = CrudGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IGridCRUDViewModel)
                {
                    DocumentExportToExcel(((IGridCRUDViewModel)Row).PrimeKeyID);
                }
            }
        }

        private void btnDocumentExportToPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CrudGridView != null)
            {
                var Row = CrudGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IGridCRUDViewModel)
                {
                    DocumentExportToPDF(((IGridCRUDViewModel)Row).PrimeKeyID);
                }
            }
        }

        private void btnDocumentExportToWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CrudGridView != null)
            {
                var Row = CrudGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IGridCRUDViewModel)
                {
                    DocumentExportToWord(((IGridCRUDViewModel)Row).PrimeKeyID);
                }
            }
        }

        private void btnDocumentExportToCSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CrudGridView != null)
            {
                var Row = CrudGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IGridCRUDViewModel)
                {
                    DocumentExportToCSV(((IGridCRUDViewModel)Row).PrimeKeyID);
                }
            }
        }

        private void btnDocumentExportToText_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CrudGridView != null)
            {
                var Row = CrudGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IGridCRUDViewModel)
                {
                    DocumentExportToText(((IGridCRUDViewModel)Row).PrimeKeyID);
                }
            }
        }
        #endregion

        private void btnCloseForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Virtual Methods

        #region Form loading
        protected virtual IGridCRUDDAL GetGridCRUDDALObj() { return null; }

        protected virtual void LoadLookupDataSource() { }

        protected virtual void AssignLookupDataSource() { }

        /// <summary>
        /// Load/generate values that takes time to process like generating invoice number. 
        /// </summary>
        protected virtual void LoadFormValues() { }

        protected virtual void AssignFormValues() { }
        #endregion

        #region Reload Data 

        public virtual void ReloadCrudData(int? newPrimeKeyID = null)
        {
            if (CrudGridControl != null && CrudGridView != null)
            {
                long? LastFocusedRowPrimeKeyID = null;
                if (newPrimeKeyID != null)
                {
                    LastFocusedRowPrimeKeyID = newPrimeKeyID;
                }
                else
                {
                    var Row = CrudGridView.GetFocusedRow();
                    if (Row is IGridCRUDViewModel)
                    {
                        LastFocusedRowPrimeKeyID = ((IGridCRUDViewModel)CrudGridView.GetFocusedRow()).PrimeKeyID;
                    }
                }

                GridDataSource = GetCrudGridDataSource();
                bindingSource.DataSource = GridDataSource;
                CrudGridControl.DataSource = bindingSource;
                FormatCrudGridView(CrudGridView);

                if (LastFocusedRowPrimeKeyID != null && GridDataSource != null)
                {
                    int NewDataSourceRowIndex = GridDataSource.ToList().FindIndex(r => r.PrimeKeyID == LastFocusedRowPrimeKeyID);

                    CrudGridView.FocusedRowHandle = CrudGridView.GetRowHandle(NewDataSourceRowIndex);

                    CrudGridView.ClearSelection();
                    CrudGridView.SelectRange(CrudGridView.FocusedRowHandle, CrudGridView.FocusedRowHandle);
                }

                ResetRowView(CrudGridView.GetFocusedRow());
            }
        }

        protected virtual IEnumerable<IGridCRUDViewModel> GetCrudGridDataSource()
        {
            if (CrudDALObj == null)
            {
                CrudDALObj = GetGridCRUDDALObj();
            }
            if (CrudDALObj != null)
            {
                return CrudDALObj.GetViewModelList();
            }
            else
            {
                return null;
            }
        }

        protected virtual void FormatCrudGridView(GridView CrudGridView)
        {
            if (CrudGridView.Columns.Any(r => r.FieldName == "RecordState"))
            {
                CrudGridView.Columns["RecordState"].MaxWidth = 100;
                CrudGridView.Columns["RecordState"].MinWidth = 75;

                CrudGridView.Columns["RecordState"].AppearanceCell.FontSizeDelta = -1;
                CrudGridView.Columns["RecordState"].AppearanceCell.BackColor = Color.WhiteSmoke;
            }
            if (CrudGridView.Columns.Any(r => r.FieldName == "RowError"))
            {
                CrudGridView.Columns.Remove(CrudGridView.Columns["RowError"]);
            }
        }

        protected virtual void ResetRowView(object EditingRecord)
        {
            AllowLockVisible = false;
            AllowUnLockVisible = false;
            AllowActivateVisible = false;
            AllowDeactivateVisible = false;

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

            if (EditingRecord == null)
            {
                AllowDeleteEnable = false;
                AllowEditEnable = false;


                AllowLockVisible = false;
                AllowUnLockVisible = false;
                AllowActivateVisible = false;
                AllowDeactivateVisible = false;

                lblRecordNo.Caption = $"0 of " + CrudGridView.RowCount;
            }
            else
            {
                lblRecordNo.Caption = $"{CrudGridView.GetVisibleIndex(CrudGridView.FocusedRowHandle) + 1} of " + CrudGridView.RowCount;

                eRecordState RecordState = eRecordState.Active;
                if (EditingRecord is IGridCRUDViewModel)
                {
                    RecordState = ((IGridCRUDViewModel)EditingRecord).RecordState;
                }

                AllowEditEnable = (RecordState == eRecordState.Active);
                AllowDeleteEnable = (RecordState == eRecordState.Active);

                AllowCrudGridPrintVisible = true;
                AllowRefreshVisible = true;

                //if (EditingRecord is IGridCRUDViewModel)
                //{
                //    switch (((IGridCRUDViewModel)EditingRecord).RecordState)
                //    {
                //        case eRecordState.Active:
                //            AllowLockVisible = true;
                //            AllowDeactivateVisible = true;
                //            break;
                //        case eRecordState.Locked:
                //            AllowUnLockVisible = true;
                //            AllowDeactivateVisible = true;
                //            break;
                //        case eRecordState.Deactivated:
                //            AllowActivateVisible = true;
                //            break;
                //    }
                //}

                if (EditingRecord is IEditUserInfo)
                {
                    IEditUserInfo EditUserInfo = (IEditUserInfo)EditingRecord;

                    if (!String.IsNullOrWhiteSpace(EditUserInfo.CreatedUserName) || EditUserInfo.CreatedDateTime.HasValue)
                    {
                        lblCreatedBy.Caption = EditUserInfo.CreatedUserName ?? "";
                        lblCreatedAt.Caption = (EditUserInfo.CreatedDateTime.HasValue ? EditUserInfo.CreatedDateTime.Value.ToLongDateString() + " " +
                            EditUserInfo.CreatedDateTime.Value.ToShortTimeString() : "");

                        lblCreatedByCaption.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        lblCreatedBy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        lblCreatedAtCaption.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        lblCreatedAt.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    if (!String.IsNullOrWhiteSpace(EditUserInfo.EditedUserName) || EditUserInfo.EditedDateTime.HasValue)
                    {
                        lblEditedBy.Caption = EditUserInfo.EditedUserName ?? "";
                        lblEditedAt.Caption = (EditUserInfo.EditedDateTime.HasValue ? EditUserInfo.EditedDateTime.Value.ToLongDateString() + " " +
                            EditUserInfo.EditedDateTime.Value.ToShortTimeString() : "");

                        lblEditedByCaption.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        lblEditedBy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        lblEditedAt.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        lblEditedAtCaption.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                }
            }
        }

        protected virtual void RestoreCrudGridLayout()
        {
            // restore dashbaord grid layout
            foreach (DevExpress.XtraGrid.Views.Base.BaseView view in CrudGridControl.Views)
            {
                string filename = $@"{CommonPropperties.CrudGridLayoutFolder}\{this.Text}{view.Name}.layout";
                if (System.IO.File.Exists(filename))
                {
                    try
                    {
                        view.RestoreLayoutFromXml(filename);
                    }
                    catch (Exception ex)
                    {
                        ex = DAL.CommonFunctions.GetFinalError(ex);
                        MessageBox.Show(ex.Message);
                    }
                    //catch (XmlException) { }
                    //catch (DirectoryNotFoundException) { }
                    //catch (FileNotFoundException) { }
                }
            }

            // setting new row item position as per given setting, after restoring layout.
            this.CrudGridView_.OptionsView.NewItemRowPosition = (AllowAddNewEnable_ ? NewItemRowPosition.Top : NewItemRowPosition.None);
        }

        protected virtual void SaveCrudGridLayout()
        {
            if (CrudGridControl != null)
            {
                string Directory = $@"{CommonPropperties.CrudGridLayoutFolder}\";
                if (!System.IO.Directory.Exists(Directory))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(Directory);
                    }
                    catch (Exception)
                    { }
                }
                foreach (DevExpress.XtraGrid.Views.Base.BaseView view in CrudGridControl.Views)
                {
                    string filename = $@"{CommonPropperties.CrudGridLayoutFolder}\{this.Text}{view.Name}.layout";

                    view.SaveLayoutToXml(filename);
                }
            }
        }
        #endregion

        #region Deleting
        protected virtual BeforeDeleteValidationResult ValidateBeforeDelete(long PrimeKeyID)
        {
            if (CrudDALObj != null)
            {
                return CrudDALObj.ValidateBeforeDelete(PrimeKeyID);
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

        protected virtual void DeleteRecord(DeletingParameter Paras)
        {

            if (CrudDALObj != null)
            {
                Paras.DeletingResult = CrudDALObj.DeleteRecord(Paras.PrimeKeyID);
            }
        }

        protected virtual void AfterDeleteRecord(DeletingParameter Paras)
        {
            switch (Paras.DeletingResult.ExecutionResult)
            {
                case eExecutionResult.CommitedSucessfuly:
                    Alit.WinformControls.ToastNotification.Show(this, "Record deleted successfully");

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
        #endregion

        #region Lock & UnLock, Activate & Deactivate

        protected virtual BeforeUpdateRecordStateValidationResult ValidateBeforeUpdateRecordState(long PrimeKeyID, eRecordState oldState, eRecordState newState)
        {
            if (CrudDALObj != null)
            {
                return CrudDALObj.ValidateBeforeUpdateRecordState(PrimeKeyID, oldState, newState);
            }
            else
            {
                return new BeforeUpdateRecordStateValidationResult()
                {
                    IsValidForUpdate = false,
                    ValidationMessage = "Before update record state validation is not implemented"
                };
            }
        }

        public virtual void ExecuteLock()
        {
            if (CrudDALObj != null && CrudGridView != null)
            {
                var Row = (IGridCRUDViewModel)CrudGridView.GetFocusedRow();
                if (Row != null)
                {
                    var ValidationResult = ValidateBeforeUpdateRecordState(Row.PrimeKeyID, Row.RecordState, eRecordState.Locked);
                    if (ValidationResult != null && ValidationResult.IsValidForUpdate)
                    {
                        CrudGridView.CloseEditor();
                        var res = LockRecord(Row.PrimeKeyID);
                        if (res != null)
                        {
                            if (res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                            {
                                Row.RecordState = eRecordState.Locked;
                            }
                            AfterLockRecord(res);
                            ResetRowView(Row);
                            //ReloadCrudData();
                        }
                    }
                    else
                    {
                        Alit.WinformControls.MessageBox.Show(this, "Can not Lock.\r\n\r\n" + ValidationResult.ValidationMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        protected virtual SavingResult LockRecord(long PrimeKeyID)
        {
            return CrudDALObj.UpdateRecordState(PrimeKeyID, eRecordState.Locked);
        }

        protected virtual void AfterLockRecord(SavingResult LockRecordResult)
        {
            if (LockRecordResult != null)
            {
                switch (LockRecordResult.ExecutionResult)
                {
                    case eExecutionResult.CommitedSucessfuly:
                        Alit.WinformControls.ToastNotification.Show(this, "Record Locked successfully");

                        if (!String.IsNullOrWhiteSpace(LockRecordResult.MessageAfterSave))
                        {
                            Alit.WinformControls.MessageBox.Show(this, LockRecordResult.MessageAfterSave, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case eExecutionResult.ErrorWhileExecuting:
                        Alit.WinformControls.MessageBox.Show(this,
                            (LockRecordResult.Exception.Message.Length > 500 ? LockRecordResult.Exception.Message.Substring(0, 500) : LockRecordResult.Exception.Message),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                    case eExecutionResult.ValidationError:
                        Alit.WinformControls.MessageBox.Show(this, "Can not Lock, please check following validation issue.\r\n\r\n" + LockRecordResult.ValidationError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }


        public virtual void ExecuteUnLock()
        {
            if (CrudDALObj != null && CrudGridView != null)
            {
                var Row = (IGridCRUDViewModel)CrudGridView.GetFocusedRow();
                if (Row != null)
                {
                    var ValidationResult = ValidateBeforeUpdateRecordState(Row.PrimeKeyID, Row.RecordState, eRecordState.Active);
                    if (ValidationResult != null && ValidationResult.IsValidForUpdate)
                    {
                        CrudGridView.CloseEditor();
                        var res = UnLockRecord(Row.PrimeKeyID);
                        if (res != null)
                        {
                            if (res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                            {
                                Row.RecordState = eRecordState.Active;
                            }
                            AfterUnLockRecord(res);
                            ResetRowView(Row);
                            //ReloadCrudData();
                        }
                    }
                    else
                    {
                        Alit.WinformControls.MessageBox.Show(this, "Can not un-Lock.\r\n\r\n" + ValidationResult.ValidationMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        protected virtual SavingResult UnLockRecord(long PrimeKeyID)
        {
            return CrudDALObj.UpdateRecordState(PrimeKeyID, eRecordState.Active);
        }

        protected virtual void AfterUnLockRecord(SavingResult UnLockRecordResult)
        {
            if (UnLockRecordResult != null)
            {
                switch (UnLockRecordResult.ExecutionResult)
                {
                    case eExecutionResult.CommitedSucessfuly:
                        Alit.WinformControls.ToastNotification.Show(this, "Record un-Locked successfully");

                        if (!String.IsNullOrWhiteSpace(UnLockRecordResult.MessageAfterSave))
                        {
                            Alit.WinformControls.MessageBox.Show(this, UnLockRecordResult.MessageAfterSave, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case eExecutionResult.ErrorWhileExecuting:
                        Alit.WinformControls.MessageBox.Show(this,
                            (UnLockRecordResult.Exception.Message.Length > 500 ? UnLockRecordResult.Exception.Message.Substring(0, 500) : UnLockRecordResult.Exception.Message),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                    case eExecutionResult.ValidationError:
                        Alit.WinformControls.MessageBox.Show(this, "Can not un-Lock, please check following validation issue.\r\n\r\n" + UnLockRecordResult.ValidationError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }


        public virtual void ExecuteActivateRecord()
        {
            if (CrudDALObj != null && CrudGridView != null)
            {
                var Row = (IGridCRUDViewModel)CrudGridView.GetFocusedRow();
                if (Row != null)
                {
                    var ValidationResult = ValidateBeforeUpdateRecordState(Row.PrimeKeyID, Row.RecordState, eRecordState.Active);
                    if (ValidationResult != null && ValidationResult.IsValidForUpdate)
                    {
                        CrudGridView.CloseEditor();
                        var res = ActivateRecord(Row.PrimeKeyID);
                        if (res != null)
                        {
                            if (res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                            {
                                Row.RecordState = eRecordState.Active;
                            }
                            AfterActivateRecord(res);
                            ResetRowView(Row);
                            //ReloadCrudData();
                        }
                    }
                    else
                    {
                        Alit.WinformControls.MessageBox.Show(this, "Can not activate.\r\n\r\n" + ValidationResult.ValidationMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        protected virtual SavingResult ActivateRecord(long PrimeKeyID)
        {
            return CrudDALObj.UpdateRecordState(PrimeKeyID, eRecordState.Active);
        }

        protected virtual void AfterActivateRecord(SavingResult ActivateRecordResult)
        {
            if (ActivateRecordResult != null)
            {
                switch (ActivateRecordResult.ExecutionResult)
                {
                    case eExecutionResult.CommitedSucessfuly:
                        Alit.WinformControls.ToastNotification.Show(this, "Record activated successfully");

                        if (!String.IsNullOrWhiteSpace(ActivateRecordResult.MessageAfterSave))
                        {
                            Alit.WinformControls.MessageBox.Show(this, ActivateRecordResult.MessageAfterSave, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case eExecutionResult.ErrorWhileExecuting:
                        Alit.WinformControls.MessageBox.Show(this,
                            (ActivateRecordResult.Exception.Message.Length > 500 ? ActivateRecordResult.Exception.Message.Substring(0, 500) : ActivateRecordResult.Exception.Message),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                    case eExecutionResult.ValidationError:
                        Alit.WinformControls.MessageBox.Show(this, "Can not activate, please check following validation issue.\r\n\r\n" + ActivateRecordResult.ValidationError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }


        public virtual void ExecuteDeActivateRecord()
        {
            if (CrudDALObj != null && CrudGridView != null)
            {
                var Row = (IGridCRUDViewModel)CrudGridView.GetFocusedRow();
                if (Row != null)
                {
                    var ValidationResult = ValidateBeforeUpdateRecordState(Row.PrimeKeyID, Row.RecordState, eRecordState.Deactivated);
                    if (ValidationResult != null && ValidationResult.IsValidForUpdate)
                    {
                        CrudGridView.CloseEditor();
                        var res = DeActivateRecord(Row.PrimeKeyID);
                        if (res != null)
                        {
                            if (res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                            {
                                Row.RecordState = eRecordState.Deactivated;
                            }
                            AfterDeActivateRecord(res);
                            ResetRowView(Row);
                            //ReloadCrudData();
                        }
                    }
                    else
                    {
                        Alit.WinformControls.MessageBox.Show(this, "Can not de-activate.\r\n\r\n" + ValidationResult.ValidationMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        protected virtual SavingResult DeActivateRecord(long PrimeKeyID)
        {
            return CrudDALObj.UpdateRecordState(PrimeKeyID, eRecordState.Deactivated);
        }

        protected virtual void AfterDeActivateRecord(SavingResult DeActivateRecordResult)
        {
            if (DeActivateRecordResult != null)
            {
                switch (DeActivateRecordResult.ExecutionResult)
                {
                    case eExecutionResult.CommitedSucessfuly:
                        Alit.WinformControls.ToastNotification.Show(this, "Record deactivated successfully");

                        if (!String.IsNullOrWhiteSpace(DeActivateRecordResult.MessageAfterSave))
                        {
                            Alit.WinformControls.MessageBox.Show(this, DeActivateRecordResult.MessageAfterSave, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case eExecutionResult.ErrorWhileExecuting:
                        Alit.WinformControls.MessageBox.Show(this,
                            (DeActivateRecordResult.Exception.Message.Length > 500 ? DeActivateRecordResult.Exception.Message.Substring(0, 500) : DeActivateRecordResult.Exception.Message),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                    case eExecutionResult.ValidationError:
                        Alit.WinformControls.MessageBox.Show(this, "Can not de-activate, please check following validation issue.\r\n\r\n" + DeActivateRecordResult.ValidationError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }

        #endregion

        #region Crud Grid Print & Export

        protected virtual GeneralizeReportGeneratorParameters GenerateCrudGridPrintParas()
        {
            return new GeneralizeReportGeneratorParameters(CrudGridControl)
            {
                PageHeaderLine1 = this.Text,
                PageHeaderLine2 = CrudGridView.GetFilterDisplayText(CrudGridView.ActiveFilter),
            };
        }


        public virtual void ExecuteCrudGridPrintPreview()
        {
            if (CrudGridControl != null)
            {
                CrudGridPrintPreview(GenerateCrudGridPrintParas());
            }
        }
        protected virtual void CrudGridPrintPreview(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                {
                    ReportGenerator.PrintPreview();
                }
            }
        }


        public virtual void ExecuteCrudGridPrint()
        {
            if (CrudGridControl != null)
            {
                CrudGridPrint(GenerateCrudGridPrintParas());
            }
        }
        protected virtual void CrudGridPrint(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                {
                    ReportGenerator.Print();
                }
            }
        }


        public virtual void ExecuteCrudGridExportToExcel()
        {
            if (CrudGridControl != null)
            {
                CrudGridExportToExcel(GenerateCrudGridPrintParas());
            }
        }
        protected virtual void CrudGridExportToExcel(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel|*.xlsx";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                    {
                        ReportGenerator.ExportToExcel(sfd.FileName);
                    }

                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }


        public virtual void ExecuteCrudGridExportToPDF()
        {
            if (CrudGridControl != null)
            {
                CrudGridExportToPDF(GenerateCrudGridPrintParas());
            }
        }
        protected virtual void CrudGridExportToPDF(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Pdf|*.pdf";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                    {
                        ReportGenerator.ExportToPDF(sfd.FileName);
                    }

                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }


        public virtual void ExecuteCrudGridExportToWord()
        {
            if (CrudGridControl != null)
            {
                CrudGridExportToWord(GenerateCrudGridPrintParas());
            }
        }
        protected virtual void CrudGridExportToWord(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Word|*.docx";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                    {
                        ReportGenerator.ExportToWord(sfd.FileName);
                    }
                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }


        public virtual void ExecuteCrudGridExportToCSV()
        {
            if (CrudGridControl != null)
            {
                CrudGridExportToCSV(GenerateCrudGridPrintParas());
            }
        }
        protected virtual void CrudGridExportToCSV(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Csv|*.csv";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                    {
                        ReportGenerator.ExportToCSV(sfd.FileName);
                    }

                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }


        public virtual void ExecuteCrudGridExportToText()
        {
            if (CrudGridControl != null)
            {
                CrudGridExportToText(GenerateCrudGridPrintParas());
            }
        }
        protected virtual void CrudGridExportToText(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text|*.txt";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                    {
                        ReportGenerator.ExportToText(sfd.FileName);
                    }
                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }


        public virtual void ExecuteCrudGridExportToImage()
        {
            if (CrudGridControl != null)
            {
                CrudGridExportToImage(GenerateCrudGridPrintParas());
            }
        }
        protected virtual void CrudGridExportToImage(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Png Image|*.png";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                    {
                        ReportGenerator.ExportToImage(sfd.FileName);
                    }
                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }

        #endregion

        #region Document Print & Export

        protected virtual DevExpress.XtraReports.UI.XtraReport GeneratePrintDocument(long PrimeKeyID)
        {
            return null;
        }

        protected virtual void DocumentPrintPreview(long PrimeKeyID)
        {
            var Document = GeneratePrintDocument(PrimeKeyID);
            if (Document != null)
            {
                //using (Report.Template.frmReportViewer frmViewer = new Report.Template.frmReportViewer())
                //{
                //    frmViewer.ReportSource = Document;
                //    frmViewer.ShowDialog(this);
                //}
            }
        }

        protected virtual void DocumentPrint(long PrimeKeyID)
        {
            var Document = GeneratePrintDocument(PrimeKeyID);
            if (Document != null)
            {
                using (DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(Document))
                {
                    printTool.Print();
                }
            }
        }

        protected virtual void DocumentExportToExcel(long PrimeKeyID)
        {
            var Document = GeneratePrintDocument(PrimeKeyID);
            if (Document != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel|*.xlsx";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    Document.ExportToXlsx(sfd.FileName);

                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }

        protected virtual void DocumentExportToPDF(long PrimeKeyID)
        {
            var Document = GeneratePrintDocument(PrimeKeyID);
            if (Document != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Pdf|*.pdf";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    Document.ExportToPdf(sfd.FileName);

                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }

        protected virtual void DocumentExportToWord(long PrimeKeyID)
        {
            var Document = GeneratePrintDocument(PrimeKeyID);
            if (Document != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Word|*.docx";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    Document.ExportToDocx(sfd.FileName);

                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }

        protected virtual void DocumentExportToCSV(long PrimeKeyID)
        {
            var Document = GeneratePrintDocument(PrimeKeyID);
            if (Document != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Csv|*.csv";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    Document.ExportToCsv(sfd.FileName);

                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }

        protected virtual void DocumentExportToText(long PrimeKeyID)
        {
            var Document = GeneratePrintDocument(PrimeKeyID);
            if (Document != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text|*.txt";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    Document.ExportToText(sfd.FileName);

                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }

        #endregion

        #region CRUD Operations
        protected virtual bool ValidateBeforeSave(IGridCRUDViewModel ViewModel)
        {
            return true;
        }

        protected virtual void SaveRecord(SavingParemeter Paras, IGridCRUDViewModel ViewModel)
        {
            if (CrudDALObj != null)
            {
                Paras.SavingResult = CrudDALObj.SaveRecord(ViewModel);
            }
        }

        protected virtual void AfterSaving(SavingParemeter Paras, IGridCRUDViewModel ViewModel)
        {
            if (Paras.SavingResult != null)
            {
                switch (Paras.SavingResult.ExecutionResult)
                {
                    case eExecutionResult.CommitedSucessfuly:
                        ViewModel.RowError = null;
                        ViewModel.PrimeKeyID = Paras.SavingResult.PrimeKeyValue;
                        //    Alit.WinformControls.ToastNotification.Show(this, "Record saved successfully");
                        if (!String.IsNullOrWhiteSpace(Paras.SavingResult.MessageAfterSave))
                        {
                            Alit.WinformControls.MessageBox.Show(this, Paras.SavingResult.MessageAfterSave, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //    this.DialogResult = DialogResult.OK;
                        break;

                    case eExecutionResult.ErrorWhileExecuting:
                        ViewModel.RowError = (Paras.SavingResult.Exception.Message.Length > 500 ? Paras.SavingResult.Exception.Message.Substring(0, 500) : Paras.SavingResult.Exception.Message);
                        break;
                    case eExecutionResult.ValidationError:
                        ViewModel.RowError = "Can not save, please check following validation issue.\r\n\r\n" + Paras.SavingResult.ValidationError;
                        break;
                }
            }
        }
        #endregion

        #endregion

        private void CrudGridView_ShowingEditor(object sender, CancelEventArgs e)
        {
            var Row = (IGridCRUDViewModel)CrudGridView.GetFocusedRow();
            if (Row == null)
            {
                return;
            }
            if (Row.RecordState != eRecordState.Active)
            {
                e.Cancel = true;
            }
        }
    }
}