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
    public partial class frmDashboardTemplate : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Visibility Command Buttons
        bool AllowAddNewVisible_ = true;
        [DefaultValue(true)]
        [Description("Allow AddNew Button to be visible")]
        public bool AllowAddNewVisible
        {
            get
            {
                return AllowAddNewVisible_;
            }
            set
            {
                if (value != AllowAddNewVisible_)
                {
                    AllowAddNewVisible_ = value;
                    if (btnAddNew != null)
                    {
                        btnAddNew.Visibility =
                            (AllowAddNewVisible_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        bool AllowEditVisible_ = true;
        [DefaultValue(true)]
        [Description("Allow Edit Button to be visible")]
        public bool AllowEditVisible
        {
            get
            {
                return AllowEditVisible_;
            }
            set
            {
                if (value != AllowEditVisible_)
                {
                    AllowEditVisible_ = value;
                    if (btnEdit != null)
                    {
                        btnEdit.Visibility =
                            (AllowEditVisible_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

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
                    if (btnAddNew != null)
                    {
                        btnAddNew.Enabled = AllowAddNewEnable_;
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
                    if (btnEdit != null)
                    {
                        btnEdit.Enabled = AllowEditEnable_;
                    }
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

        #region Print and Export

        bool AllowDashboardPrintVisible_ = true;
        [DefaultValue(true)]
        [Description("Allow Dashboard Print and Export Button to be visible")]
        public bool AllowDashboardPrintVisible
        {
            get
            {
                return AllowDashboardPrintVisible_;
            }
            set
            {
                if (value != AllowDashboardPrintVisible_)
                {
                    AllowDashboardPrintVisible_ = value;
                    if (rpgPrintDashboard != null)
                    {
                        rpgPrintDashboard.Visible = AllowDashboardPrintVisible_;
                    }
                }
            }
        }


        bool AllowDocumentPrintVisible_ = false;
        [DefaultValue(false)]
        [Description("Allow Document Print & Export buttons to visible")]
        public bool AllowDocumentPrintVisible
        {
            get
            {
                return AllowDocumentPrintVisible_;
            }
            set
            {
                if (AllowDocumentPrintVisible_ != value)
                {
                    AllowDocumentPrintVisible_ = value;
                    rpgPrintDocument.Visible = AllowDocumentPrintVisible_;
                }
            }
        }
        #endregion

        #region Base Form
        int MenuID_;
        public int MenuOptionID
        {
            get
            {
                return MenuID_;
            }
            set
            {
                if (MenuID_ != value)
                {
                    MenuID_ = value;

                    //DAL.Users.UserGroupDAL UGDALObj = new DAL.Users.UserGroupDAL();
                    var perm = Model.CommonProperties.LoginInfo.UserPermission.FirstOrDefault(r => r.MenuOptionID == MenuID_);
                    if (perm != null)
                    {
                        UserMenuPermission = perm;
                    }
                    else
                    {
                        UserMenuPermission = new Model.Users.UserGroup.MenuOptionPermissionViewModel()
                        {
                            MenuOptionID = MenuID_,
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

        #region Dashboard Grid Control and Datasource
        public DAL.Template.IDashboardDAL DashboardDALObj { get; set; }

        public IEnumerable<IDashboardViewModel> DashboardDataSource { get; set; }

        GridControl DahboardGridControl_;
        public GridControl DashboardGridControl
        {
            get { return DahboardGridControl_; }
            set
            {
                if (DahboardGridControl_ != value)
                {
                    DahboardGridControl_ = value;
                }
            }
        }

        GridView DashboardGridView_;
        public GridView DashboardGridView
        {
            get { return DashboardGridView_; }
            set
            {
                if (DashboardGridView_ != value)
                {
                    if (DashboardGridView_ != null)
                    {
                        DashboardGridView_.FocusedRowChanged -= gvDashboardData_FocusedRowChanged;
                        DashboardGridView_.RowCellClick -= DashboardGridView_RowCellClick;
                    }

                    DashboardGridView_ = value;

                    if (DashboardGridView_ != null)
                    {
                        DashboardGridView_.FocusedRowChanged += gvDashboardData_FocusedRowChanged;
                        DashboardGridView_.RowCellClick += DashboardGridView_RowCellClick;

                        DashboardGridView_.OptionsBehavior.Editable = false;
                        DashboardGridView_.OptionsBehavior.FocusLeaveOnTab = true;
                        DashboardGridView_.OptionsNavigation.EnterMoveNextColumn = true;
                        DashboardGridView_.OptionsNavigation.UseTabKey = false;
                        DashboardGridView_.Appearance.FocusedCell.BackColor = DashboardGridView_.Appearance.SelectedRow.BackColor;
                        DashboardGridView_.Appearance.FocusedCell.ForeColor = DashboardGridView_.Appearance.SelectedRow.ForeColor;
                        DashboardGridView_.ShowFindPanel();
                        DashboardGridView_.OptionsView.ShowAutoFilterRow = true;
                        DashboardGridView_.OptionsBehavior.AutoExpandAllGroups = true;
                        DashboardGridView_.OptionsSelection.MultiSelect = true;
                        DashboardGridView_.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
                        DashboardGridView_.OptionsSelection.EnableAppearanceFocusedCell = false;
                        DashboardGridView_.OptionsSelection.EnableAppearanceHideSelection = false;
                        DashboardGridView_.OptionsDetail.DetailMode = DetailMode.Embedded;

                        DashboardGridView_.RowStyle += DashboardGridView_RowStyle;

                        Font RegularFont = new Font("Arial", 10, FontStyle.Regular);
                        Font BoldFont = new Font("Arial", 10, FontStyle.Bold);
                        DashboardGridView_.AppearancePrint.Row.Font = RegularFont;
                        DashboardGridView_.AppearancePrint.HeaderPanel.Font = BoldFont;
                        DashboardGridView_.AppearancePrint.GroupFooter.Font = BoldFont;
                        DashboardGridView_.AppearancePrint.GroupFooter.Font = BoldFont;
                        DashboardGridView_.Appearance.FooterPanel.Font = BoldFont;
                        DashboardGridView_.Appearance.GroupRow.Font = BoldFont;
                        DashboardGridView_.Appearance.ViewCaption.Font = BoldFont;

                        // to synchronize grid view layout with dashboard buttons and settings and properties
                        ShowDetailView = ShowDetailView;
                    }
                }
            }
        }

        bool ShowDefaultFilter_ = false;
        /// <summary>
        /// Shwo default filter group box
        /// </summary>
        [DefaultValue(false)]
        public bool ShowDefaultFilter
        {
            get
            {
                return ShowDefaultFilter_;
            }
            set
            {
                ShowDefaultFilter_ = value;
                if (ShowDefaultFilter_)
                {
                    lcgDefaultFilterGroupBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lcTitle.Height = 61;
                }
                else
                {
                    lcgDefaultFilterGroupBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lcTitle.Height = 45;
                }
            }
        }


        bool ShowGridViewDetailOptions_ = false;
        [DefaultValue(false)]
        [Description("If dashboard grid control contains shows multi level grid views (detail view) then assign true to show detail view relation buttons like show detail, expand and collaps buttons")]
        public bool ShowGridViewDetailOptions
        {
            get
            {
                return ShowGridViewDetailOptions_;
            }
            set
            {
                ShowGridViewDetailOptions_ = value;
                if (ShowGridViewDetailOptions_)
                {
                    btnShowDetails.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnExpandAllDetail.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnCollapsAllDetail.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    btnShowDetails.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnExpandAllDetail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnCollapsAllDetail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
        }

        bool ShowDetailView_ = false;
        [Description("true : Show detail view, If dashboard grid control contains shows multi level grid views (detail view).")]
        [DefaultValue(false)]
        public bool ShowDetailView
        {
            get { return ShowDetailView_; }
            set
            {
                ShowDetailView_ = value;
                if (DashboardGridView != null)
                {
                    btnShowDetails.DownChanged -= btnShowDetails_DownChanged;
                    btnShowDetails.Down = ShowDetailView_;
                    DashboardGridView.OptionsDetail.EnableMasterViewMode = ShowDetailView_;
                    DashboardGridView.OptionsPrint.PrintDetails = ShowDetailView_;
                    DashboardGridView.OptionsPrint.ExpandAllDetails = ShowDetailView_;
                    btnShowDetails.DownChanged += btnShowDetails_DownChanged;
                }
            }
        }
        #endregion

        public virtual Type CrudFormType { get { return typeof(frmCRUDTemplate); } }

        #region fields
        Dictionary<string, MemoryStream> DashboardGridViewDefaultLayoutStreams;
        #endregion

        #region Contructor & destructure

        public frmDashboardTemplate()
        {
            DashboardGridViewDefaultLayoutStreams = new Dictionary<string, MemoryStream>();
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
            AllowDashboardPrintVisible = true;
            AllowDocumentPrintVisible = false;

            DashboardDALObj = GetDashboardDALObj();

            ShowWaitForm();
        }

        ~frmDashboardTemplate()
        {
            foreach (var stream in DashboardGridViewDefaultLayoutStreams)
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
            SaveDashboardGridLayout();
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

                ReloadDashboardData();

                foreach (DevExpress.XtraGrid.Views.Base.BaseView view in DashboardGridControl.Views)
                {
                    MemoryStream stream = new MemoryStream();
                    view.SaveLayoutToStream(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    DashboardGridViewDefaultLayoutStreams.Add(view.Name, stream);
                }

                RestoreDashboardGridLayout();
                CloseWaitForm();
            });
        }

        #region Grid View
        private void gvDashboardData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ResetRowView(DashboardGridView.GetFocusedRow());
        }

        private void DashboardGridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Clicks > 1)
            {
                EditRecord();
            }
        }

        private void btnResetDashboardGridLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DashboardGridControl != null)
            {
                foreach (DevExpress.XtraGrid.Views.Base.BaseView view in DashboardGridControl.Views)
                {
                    if (DashboardGridViewDefaultLayoutStreams.ContainsKey(view.Name))
                    {
                        MemoryStream stream = DashboardGridViewDefaultLayoutStreams[view.Name];
                        view.RestoreLayoutFromStream(stream);
                        stream.Seek(0, System.IO.SeekOrigin.Begin);
                    }
                }
            }
        }

        private void DashboardGridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            e.HighPriority = true;
            if (e.State.HasFlag(DevExpress.XtraGrid.Views.Base.GridRowCellState.Selected))
            {
                e.CombineAppearance(DashboardGridView.Appearance.SelectedRow);
            }
            var Row = (IDashboardViewModel)DashboardGridView.GetRow(e.RowHandle);
            if (Row != null)
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
        #endregion

        #region CRUD Operation events
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadDashboardData();
        }

        private void btnAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddNewRecord();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditRecord();
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

            object SelectedRecord = DashboardGridView.GetFocusedRow();
            if (SelectedRecord == null)
            {
                return;
            }

            BeforeDeleteValidationResult ValidationResult = null;
            if (SelectedRecord is IDashboardViewModel)
            {
                long PrimeKeyID = ((IDashboardViewModel)SelectedRecord).PrimeKeyID;

                ValidationResult = ValidateBeforeDelete(PrimeKeyID);

                if (ValidationResult.IsValidForDelete)
                {
                    if (Alit.WinformControls.MessageBox.Show(this, "Are you sure ? Do you want to delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        DeletingParameter para = new DeletingParameter() { PrimeKeyID = PrimeKeyID };

                        //
                        ShowWaitForm();

                        await Task.Run(() => DeleteRecord(para));

                        CloseWaitForm();
                        //

                        AfterDeleteRecord(para);

                        if (para.DeletingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                        {
                            ReloadDashboardData();
                        }
                    }
                }
                else
                {
                    Alit.WinformControls.MessageBox.Show(this, "Can not Delete.\r\n\r\n" + ValidationResult.ValidationMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
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

        #region Dashboard Print & Export
        private void btnDashboardPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteDashboardPrint();
        }

        private void btnDashboardPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteDashboardPrintPreview();
        }

        private void btnDashboardExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteDashboardExportToExcel();
        }

        private void btnDashboardExportToPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteDashboardExportToPDF();
        }

        private void btnDashboardExportToWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteDashboardExportToWord();
        }

        private void btnDashboardExportToCSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteDashboardExportToCSV();
        }

        private void btnDashboardExportToText_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteDashboardExportToText();
        }

        private void btnDashboardExportToImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteDashboardExportToImage();
        }
        #endregion

        #region Document Print & Export
        private void btnDocumentPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DashboardGridView != null)
            {
                var Row = DashboardGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IDashboardViewModel)
                {
                    DocumentPrintPreview(((IDashboardViewModel)Row).PrimeKeyID);
                }
            }
        }

        private void btnDocumentPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DashboardGridView != null)
            {
                var Row = DashboardGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IDashboardViewModel)
                {
                    DocumentPrint(((IDashboardViewModel)Row).PrimeKeyID);
                }
            }
        }

        private void btnDocumentExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DashboardGridView != null)
            {
                var Row = DashboardGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IDashboardViewModel)
                {
                    DocumentExportToExcel(((IDashboardViewModel)Row).PrimeKeyID);
                }
            }
        }

        private void btnDocumentExportToPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DashboardGridView != null)
            {
                var Row = DashboardGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IDashboardViewModel)
                {
                    DocumentExportToPDF(((IDashboardViewModel)Row).PrimeKeyID);
                }
            }
        }

        private void btnDocumentExportToWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DashboardGridView != null)
            {
                var Row = DashboardGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IDashboardViewModel)
                {
                    DocumentExportToWord(((IDashboardViewModel)Row).PrimeKeyID);
                }
            }
        }

        private void btnDocumentExportToCSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DashboardGridView != null)
            {
                var Row = DashboardGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IDashboardViewModel)
                {
                    DocumentExportToCSV(((IDashboardViewModel)Row).PrimeKeyID);
                }
            }
        }

        private void btnDocumentExportToText_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DashboardGridView != null)
            {
                var Row = DashboardGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IDashboardViewModel)
                {
                    DocumentExportToText(((IDashboardViewModel)Row).PrimeKeyID);
                }
            }
        }

        private void btnDocumentExportToImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DashboardGridView != null)
            {
                var Row = DashboardGridView.GetFocusedRow();
                if (Row != null && Row is Model.Template.IDashboardViewModel)
                {
                    DocumentExportToImage(((IDashboardViewModel)Row).PrimeKeyID);
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

        #region form loading
        protected virtual IDashboardDAL GetDashboardDALObj() { return null; }

        protected virtual void LoadLookupDataSource() { }

        protected virtual void AssignLookupDataSource() { }

        /// <summary>
        /// Load/generate values that takes time to process like generating invoice number. 
        /// </summary>
        protected virtual void LoadFormValues() { }

        protected virtual void AssignFormValues() { }
        #endregion

        #region Reload Data 

        public virtual void ReloadDashboardData(long? newPrimeKeyID = null)
        {
            if (DashboardGridControl != null && DashboardGridView != null)
            {
                long? LastFocusedRowPrimeKeyID = null;
                if (newPrimeKeyID != null)
                {
                    LastFocusedRowPrimeKeyID = newPrimeKeyID;
                }
                else
                {
                    var Row = DashboardGridView.GetFocusedRow();
                    if (Row is IDashboardViewModel)
                    {
                        LastFocusedRowPrimeKeyID = ((IDashboardViewModel)DashboardGridView.GetFocusedRow()).PrimeKeyID;
                    }
                }

                DashboardDataSource = GetDashboardDataSource(GetDashboardDataSourceFilterParas());
                DashboardGridControl.DataSource = DashboardDataSource;
                FormatDashboardGridView(DashboardGridView);

                if (LastFocusedRowPrimeKeyID != null && DashboardDataSource != null)
                {
                    int NewDataSourceRowIndex = DashboardDataSource.ToList().FindIndex(r => r.PrimeKeyID == LastFocusedRowPrimeKeyID);

                    DashboardGridView.FocusedRowHandle = DashboardGridView.GetRowHandle(NewDataSourceRowIndex);

                    DashboardGridView.ClearSelection();
                    DashboardGridView.SelectRange(DashboardGridView.FocusedRowHandle, DashboardGridView.FocusedRowHandle);
                }

                ResetRowView(DashboardGridView.GetFocusedRow());
            }
        }

        protected virtual IEnumerable<IDashboardViewModel> GetDashboardDataSource(object[] FilterParas)
        {
            if (DashboardDALObj == null)
            {
                DashboardDALObj = GetDashboardDALObj();
            }
            if (DashboardDALObj != null)
            {
                return DashboardDALObj.GetDashboardData(FilterParas);
            }
            else
            {
                return null;
            }
        }

        protected virtual object[] GetDashboardDataSourceFilterParas()
        {
            return null;
        }

        protected virtual void FormatDashboardGridView(GridView DashboardGridView)
        {
            if (DashboardGridView.Columns.Any(r => r.FieldName == "RecordState"))
            {
                DashboardGridView.Columns["RecordState"].MaxWidth = 100;
                DashboardGridView.Columns["RecordState"].MinWidth = 75;

                DashboardGridView.Columns["RecordState"].AppearanceCell.FontSizeDelta = -1;
                DashboardGridView.Columns["RecordState"].AppearanceCell.BackColor = Color.WhiteSmoke;
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

                lblRecordNo.Caption = $"0 of " + DashboardGridView.RowCount;
            }
            else
            {
                lblRecordNo.Caption = $"{DashboardGridView.GetVisibleIndex(DashboardGridView.FocusedRowHandle) + 1} of " + DashboardGridView.RowCount;

                eRecordState RecordState = eRecordState.Active;
                if (EditingRecord is IDashboardViewModel)
                {
                    RecordState = ((IDashboardViewModel)EditingRecord).RecordState;
                }

                AllowEditEnable = (RecordState == eRecordState.Active);
                AllowDeleteEnable = (RecordState == eRecordState.Active);

                AllowDashboardPrintVisible = true;
                AllowRefreshVisible = true;

                //if (EditingRecord is IDashboardViewModel)
                //{
                //    switch (((IDashboardViewModel)EditingRecord).RecordState)
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

        protected virtual void RestoreDashboardGridLayout()
        {
            // restore dashbaord grid layout
            foreach (DevExpress.XtraGrid.Views.Base.BaseView view in DashboardGridControl.Views)
            {
                string filename = $@"{CommonPropperties.DashboardGridLayoutFolder}\{this.Text}{view.Name}.layout";
                if (System.IO.File.Exists(filename))
                {
                    try
                    {
                        view.RestoreLayoutFromXml(filename);
                        if (view is GridView)
                        {
                            var gridView = (GridView)view;

                            ShowDetailView = gridView.OptionsDetail.EnableMasterViewMode;
                        }
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
        }

        protected virtual void SaveDashboardGridLayout()
        {
            if (DashboardGridControl != null)
            {
                string Directory = $@"{CommonPropperties.DashboardGridLayoutFolder}\";
                if (!System.IO.Directory.Exists(Directory))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(Directory);
                    }
                    catch (Exception)
                    { }
                }
                foreach (DevExpress.XtraGrid.Views.Base.BaseView view in DashboardGridControl.Views)
                {
                    string filename = $@"{CommonPropperties.DashboardGridLayoutFolder}\{this.Text}{view.Name}.layout";

                    view.SaveLayoutToXml(filename);
                }
            }
        }
        #endregion

        #region Add new 
        protected virtual object[] GetAddNewFormParameters()
        {
            return null;
        }

        protected virtual void AddNewRecord()
        {
            if (CrudFormType == null)
            {
                Alit.WinformControls.MessageBox.Show(this, "Can not add new records. CrudFormType was not implemented.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                var CRUDMTemplateDefaultPara = new CRUDMTemplateParas() { FormDefaultUI = eFormCurrentUI.NewEntry };
                object[] CrudFormParas = null;
                object[] CustomParas = GetAddNewFormParameters();
                if (CustomParas != null)
                {
                    var list = new List<object> { CRUDMTemplateDefaultPara };
                    list.AddRange(CustomParas);
                    CrudFormParas = list.ToArray();
                }
                else
                {
                    CrudFormParas = new object[] { CRUDMTemplateDefaultPara };
                }
                frmCRUDTemplate newFrm = (frmCRUDTemplate)Activator.CreateInstance(CrudFormType, CrudFormParas);
                newFrm.WindowState = FormWindowState.Normal;
                newFrm.StartPosition = FormStartPosition.CenterScreen;

                if (newFrm.ShowDialog(this) == DialogResult.OK)
                {
                    AfterAddingRecord(newFrm.SaveResult);

                    ReloadDashboardData((newFrm.SaveResult?.PrimeKeyValue));
                }
            }
        }

        protected virtual void AfterAddingRecord(SavingResult SavingResult)
        {
        }

        #endregion

        #region Editing
        protected virtual void EditRecord()
        {
            //if(!btnEdit.Enabled || btnEdit.Visibility != DevExpress.XtraBars.BarItemVisibility.Always)
            //{
            //    return;
            //}
            var SelectedRecord = (IDashboardViewModel)DashboardGridView.GetFocusedRow();
            if (SelectedRecord == null)
            {
                return;
            }
            if (CrudFormType == null)
            {
                Alit.WinformControls.MessageBox.Show(this, "Can not edit. CrudFormType was not implemented.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                var CRUDMTemplateDefaultPara = new CRUDMTemplateParas() { FormDefaultUI = eFormCurrentUI.Edit, EditingRecord = SelectedRecord };
                object[] CrudFormParas = null;
                object[] CustomParas = GetAddNewFormParameters();
                if (CustomParas != null)
                {
                    var list = new List<object> { CRUDMTemplateDefaultPara };
                    list.AddRange(CustomParas);
                    CrudFormParas = list.ToArray();
                }
                else
                {
                    CrudFormParas = new object[] { CRUDMTemplateDefaultPara };
                }

                frmCRUDTemplate newFrm = (frmCRUDTemplate)Activator.CreateInstance(CrudFormType, CrudFormParas);

                newFrm.EditingRecord = SelectedRecord;
                newFrm.WindowState = FormWindowState.Normal;
                newFrm.StartPosition = FormStartPosition.CenterScreen;

                if (newFrm.ShowDialog(this) == DialogResult.OK)
                {
                    AfterEditRecord(newFrm.SaveResult);
                    ReloadDashboardData();
                }
            }
        }

        protected virtual void AfterEditRecord(SavingResult SavingResult)
        {
        }
        #endregion

        #region Deleting
        protected virtual BeforeDeleteValidationResult ValidateBeforeDelete(long PrimeKeyID)
        {
            if (DashboardDALObj != null)
            {
                return DashboardDALObj.ValidateBeforeDelete(PrimeKeyID);
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

            if (DashboardDALObj != null)
            {
                Paras.DeletingResult = DashboardDALObj.DeleteRecord(Paras.PrimeKeyID);
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
            if (DashboardDALObj != null)
            {
                return DashboardDALObj.ValidateBeforeUpdateRecordState(PrimeKeyID, oldState, newState);
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
            if (DashboardDALObj != null && DashboardGridView != null)
            {
                var Row = (IDashboardViewModel)DashboardGridView.GetFocusedRow();
                if (Row != null)
                {
                    var ValidationResult = ValidateBeforeUpdateRecordState(Row.PrimeKeyID, Row.RecordState, eRecordState.Locked);
                    if (ValidationResult != null && ValidationResult.IsValidForUpdate)
                    {
                        var res = LockRecord(Row.PrimeKeyID);
                        if (res != null)
                        {
                            AfterLockRecord(res);
                            ReloadDashboardData();
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
            return DashboardDALObj.UpdateRecordState(PrimeKeyID, eRecordState.Locked);
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
            if (DashboardDALObj != null && DashboardGridView != null)
            {
                var Row = (IDashboardViewModel)DashboardGridView.GetFocusedRow();
                if (Row != null)
                {
                    var ValidationResult = ValidateBeforeUpdateRecordState(Row.PrimeKeyID, Row.RecordState, eRecordState.Active);
                    if (ValidationResult != null && ValidationResult.IsValidForUpdate)
                    {
                        var res = UnLockRecord(Row.PrimeKeyID);
                        if (res != null)
                        {
                            AfterUnLockRecord(res);
                            ReloadDashboardData();
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
            return DashboardDALObj.UpdateRecordState(PrimeKeyID, eRecordState.Active);
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
            if (DashboardDALObj != null && DashboardGridView != null)
            {
                var Row = (IDashboardViewModel)DashboardGridView.GetFocusedRow();
                if (Row != null)
                {
                    var ValidationResult = ValidateBeforeUpdateRecordState(Row.PrimeKeyID, Row.RecordState, eRecordState.Active);
                    if (ValidationResult != null && ValidationResult.IsValidForUpdate)
                    {
                        var res = ActivateRecord(Row.PrimeKeyID);
                        if (res != null)
                        {
                            AfterActivateRecord(res);
                            ReloadDashboardData();
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
            return DashboardDALObj.UpdateRecordState(PrimeKeyID, eRecordState.Active);
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
            if (DashboardDALObj != null && DashboardGridView != null)
            {
                var Row = (IDashboardViewModel)DashboardGridView.GetFocusedRow();
                if (Row != null)
                {
                    var ValidationResult = ValidateBeforeUpdateRecordState(Row.PrimeKeyID, Row.RecordState, eRecordState.Deactivated);
                    if (ValidationResult != null && ValidationResult.IsValidForUpdate)
                    {
                        var res = DeActivateRecord(Row.PrimeKeyID);
                        if (res != null)
                        {
                            AfterDeActivateRecord(res);
                            ReloadDashboardData();
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
            return DashboardDALObj.UpdateRecordState(PrimeKeyID, eRecordState.Deactivated);
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

        #region Dashboard Print & Export

        protected virtual GeneralizeReportGeneratorParameters GenerateDashboardPrintParas()
        {
            //GeneralizeReportGeneratorParameters printParas = new GeneralizeReportGeneratorParameters();

            //// Assign a control to be printed by this link. 
            //printParas.DashboardPrintableComponentLink.Component = DashboardGridControl;
            //printParas.DashboardPrintableComponentLink.Margins = new System.Drawing.Printing.Margins(25, 25, 50, 35);
            //printParas.DashboardPrintableComponentLink.PaperKind = System.Drawing.Printing.PaperKind.A4;

            //var phf = (PageHeaderFooter)printParas.DashboardPrintableComponentLink.PageHeaderFooter;
            //phf.Header.Content.AddRange(new string[] { null, this.Text, null });
            //phf.Header.Font = new Font("Aria", 14, FontStyle.Bold);
            //phf.Header.LineAlignment = BrickAlignment.Far;

            //phf.Footer.Content.AddRange(new string[] { "[Page # of Pages #]", null, DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString() });
            //phf.Footer.Font = new Font("Arial", 9, FontStyle.Regular);
            //phf.Footer.LineAlignment = BrickAlignment.Near;

            //DashboardGridView.OptionsPrint.RtfReportHeader = DashboardGridView.GetFilterDisplayText(DashboardGridView.ActiveFilter);
            return new GeneralizeReportGeneratorParameters(DashboardGridControl)
            {
                PageHeaderLine1 = this.Text,
                PageHeaderLine2 = DashboardGridView.GetFilterDisplayText(DashboardGridView.ActiveFilter),
            };
        }


        public virtual void ExecuteDashboardPrintPreview()
        {
            if (DashboardGridControl != null)
            {
                DashboardPrintPreview(GenerateDashboardPrintParas());
            }
        }
        protected virtual void DashboardPrintPreview(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                {
                    ReportGenerator.PrintPreview();
                }
                //printParas.DashboardPrintableComponentLink.ShowRibbonPreviewDialog(Navigation.frmNavigationDashboard.Dashboard.defaultLookAndFeel1.LookAndFeel);
            }
        }


        public virtual void ExecuteDashboardPrint()
        {
            if (DashboardGridControl != null)
            {
                DashboardPrint(GenerateDashboardPrintParas());
            }
        }
        protected virtual void DashboardPrint(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                {
                    ReportGenerator.Print();
                }
            }
        }


        public virtual void ExecuteDashboardExportToExcel()
        {
            if (DashboardGridControl != null)
            {
                DashboardExportToExcel(GenerateDashboardPrintParas());
            }
        }
        protected virtual void DashboardExportToExcel(GeneralizeReportGeneratorParameters printParas)
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


        public virtual void ExecuteDashboardExportToPDF()
        {
            if (DashboardGridControl != null)
            {
                DashboardExportToPDF(GenerateDashboardPrintParas());
            }
        }
        protected virtual void DashboardExportToPDF(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Pdf|*.pdf";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    //printParas.DashboardPrintableComponentLink.ExportToPdf(sfd.FileName);
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


        public virtual void ExecuteDashboardExportToWord()
        {
            if (DashboardGridControl != null)
            {
                DashboardExportToWord(GenerateDashboardPrintParas());
            }
        }
        protected virtual void DashboardExportToWord(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Word|*.docx";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    //printParas.DashboardPrintableComponentLink.ExportToDocx(sfd.FileName);
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


        public virtual void ExecuteDashboardExportToCSV()
        {
            if (DashboardGridControl != null)
            {
                DashboardExportToCSV(GenerateDashboardPrintParas());
            }
        }
        protected virtual void DashboardExportToCSV(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Csv|*.csv";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    //printParas.DashboardPrintableComponentLink.ExportToCsv(sfd.FileName);
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


        public virtual void ExecuteDashboardExportToText()
        {
            if (DashboardGridControl != null)
            {
                DashboardExportToText(GenerateDashboardPrintParas());
            }
        }
        protected virtual void DashboardExportToText(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text|*.txt";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    //printParas.DashboardPrintableComponentLink.ExportToText(sfd.FileName);
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


        public virtual void ExecuteDashboardExportToImage()
        {
            if (DashboardGridControl != null)
            {
                DashboardExportToImage(GenerateDashboardPrintParas());
            }
        }
        protected virtual void DashboardExportToImage(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Png Image|*.png";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    //printParas.DashboardPrintableComponentLink.ExportToImage(sfd.FileName, new ImageExportOptions()
                    //{
                    //    ExportMode = ImageExportMode.SingleFile,
                    //    Format = System.Drawing.Imaging.ImageFormat.Png,
                    //    RetainBackgroundTransparency = false,
                    //});
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

        protected virtual void DocumentPrint(long PrimeKeyID)
        {
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

        protected virtual void DocumentExportToExcel(long PrimeKeyID)
        {
            ShowWaitForm();
            var Document = GeneratePrintDocument(PrimeKeyID);
            CloseWaitForm();

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
            ShowWaitForm();
            var Document = GeneratePrintDocument(PrimeKeyID);
            CloseWaitForm();

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
            ShowWaitForm();
            var Document = GeneratePrintDocument(PrimeKeyID);
            CloseWaitForm();

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
            ShowWaitForm();
            var Document = GeneratePrintDocument(PrimeKeyID);
            CloseWaitForm();

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
            ShowWaitForm();
            var Document = GeneratePrintDocument(PrimeKeyID);
            CloseWaitForm();

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

        protected virtual void DocumentExportToImage(long PrimeKeyID)
        {
            ShowWaitForm();
            var Document = GeneratePrintDocument(PrimeKeyID);
            CloseWaitForm();

            if (Document != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Image|*.png";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    Document.ExportToImage(sfd.FileName);

                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }

        #endregion

        #endregion

        #region Grid View - Master-Detail, Expand/Collaps
        private void btnShowDetails_DownChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowDetailView = btnShowDetails.Down;
        }


        private void btnExpandAllDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView View = DashboardGridView;
            View.BeginUpdate();
            try
            {
                int dataRowCount = View.DataRowCount;
                for (int rHandle = 0; rHandle < dataRowCount; rHandle++)
                {
                    View.SetMasterRowExpanded(rHandle, true);
                }
            }
            finally
            {
                View.EndUpdate();
            }
        }

        private void btnCollapsAllDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DashboardGridView.CollapseAllDetails();
        }

        #endregion
    }
}