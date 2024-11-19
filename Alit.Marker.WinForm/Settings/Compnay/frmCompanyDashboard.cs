using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Settings.Compnay
{
    public partial class frmCompanyDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmCompanyCRUD);
            }
        }

        public frmCompanyDashboard()
        {
            InitializeComponent();

            DashboardDALObj = new DAL.Settings.Compnay.CompanyDAL();
            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }
        
        private void btnFinancialPeriod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Navigation.frmNavigationDashboard.ShowForm<Settings.FinancialPeriod.frmFinancialPeriodDashboard>();
        }

      
    }
}
