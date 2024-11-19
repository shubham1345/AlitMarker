using Alit.Marker.WinForm.Settings.Compnay;
using Alit.Marker.WinForm.Settings.FinancialPeriod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Settings.FinancialPeriod
{
    public partial class frmFinancialPeriodDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmFinancialPeriodCRUD);
            }
        }

        public frmFinancialPeriodDashboard()
        {
            InitializeComponent();

            DashboardDALObj = new DAL.Settings.FinancialPeriod.FinPeriodDAL();
            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }

        protected override object[] GetDashboardDataSourceFilterParas()
        {
            return new object[] { Model.CommonProperties.LoginInfo.LoggedInFinPeriod.CompanyID };
        }

        private void btnCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Navigation.frmNavigationDashboard.ShowForm<frmCompanyDashboard>();
        }
    }
}
