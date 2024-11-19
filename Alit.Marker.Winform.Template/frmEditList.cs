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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Alit.Marker.WinForm.Template
{
    public partial class frmEditList : DevExpress.XtraEditors.XtraForm
    {
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

        public object EditListDataSource { get; set; }

        public object SelectedRecord { get; set; }

        public bool IsSelectButtonClicked { get; set; }

        public frmCRUDTemplate ParentCRUDForm { get; set; }

        public frmEditList(frmCRUDTemplate ParentForm) : this()
        {
            this.ParentCRUDForm = ParentForm;
        }

        public frmEditList()
        {
            InitializeComponent();

            this.Size = new System.Drawing.Size(
                Math.Max(Screen.PrimaryScreen.WorkingArea.Width - 100, this.Width),
                Math.Max(Screen.PrimaryScreen.WorkingArea.Height - 200, this.Height));

            DevExpress.XtraGrid.Views.Grid.GridView EditGrid = ((DevExpress.XtraGrid.Views.Grid.GridView)gridEditList.DefaultView);
            EditGrid.OptionsBehavior.Editable = false;
            EditGrid.OptionsSelection.EnableAppearanceFocusedCell = false;
            EditGrid.ShowFindPanel();
        }

        protected override void OnShown(EventArgs e)
        {
            IsSelectButtonClicked = false;
            SelectedRecord = null;
            base.OnShown(e);
        }
        
        public virtual void UpdateDataSource(object EditListDataSource)
        {
            this.EditListDataSource = EditListDataSource;
            gridEditList.DataSource = this.EditListDataSource;
        }

        private void btnSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SelectRecord(((DevExpress.XtraGrid.Views.Grid.GridView)gridEditList.FocusedView).GetFocusedRow());
        }

        private void SelectRecord(object SelectedRecord)
        {
            this.SelectedRecord = SelectedRecord;
            IsSelectButtonClicked = true;
            this.Hide();
        }
        
        private void gridEditList_DoubleClick(object sender, EventArgs e)
        {
            GridControl GridControl = (GridControl)sender;
            GridView view = (GridView)GridControl.FocusedView;

            Point pt = view.GridControl.PointToClient(Control.MousePosition);

            GridHitInfo info = view.CalcHitInfo(pt);

            if(info.InRow || info.InRowCell) 
            {
                SelectRecord(view.GetRow(info.RowHandle));
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateDataSource(ParentCRUDForm.GetEditListDataSource());
        }

        private void btnEscapeSetFocus_Enter(object sender, EventArgs e)
        {
            btnCancel.Links[0].Focus();
        }

        private void btnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(ParentCRUDForm != null)
            {
                object CurrentRow = ((DevExpress.XtraGrid.Views.Grid.GridView)gridEditList.FocusedView).GetFocusedRow();
                if (CurrentRow != null)
                {
                    ParentCRUDForm.DirectPrintPreview(CurrentRow);
                }
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ParentCRUDForm != null)
            {
                object CurrentRow = ((DevExpress.XtraGrid.Views.Grid.GridView)gridEditList.FocusedView).GetFocusedRow();
                if (CurrentRow != null)
                {
                    ParentCRUDForm.DirectPrint(CurrentRow);
                }
            }
        }
    }
}