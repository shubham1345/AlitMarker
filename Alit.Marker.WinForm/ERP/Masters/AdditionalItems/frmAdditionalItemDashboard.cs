using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.ERP.Masters.AdditionalItems
{
    public partial class frmAdditionalItemDashboard : Template.frmDashboardTemplate
    {

        public override Type CrudFormType
        {
            get
            {
                return typeof(frmAdditionalItemCRUD);
            }
        }

        public frmAdditionalItemDashboard()
        {
            InitializeComponent();

            DashboardDALObj = new DAL.ERP.Masters.AdditionalItems.AdditionalItemDAL();
            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }

        protected override void ResetRowView(object EditingRecord)
        {
            base.ResetRowView(EditingRecord);
        }
    }
}
