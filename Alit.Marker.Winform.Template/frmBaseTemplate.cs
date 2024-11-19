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
using Alit.Marker.Model;

namespace Alit.Marker.WinForm.Template
{
    public partial class frmBaseTemplate : DevExpress.XtraEditors.XtraForm
    {


        public frmBaseTemplate()
        {

        }
        
        #region Base Form
        int MenuID_;
        public int MenuID
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
                    var perm = CommonProperties.LoginInfo.UserPermission.FirstOrDefault(r => r.MenuOptionID == MenuID_);
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
                    if (CommonProperties.LoginInfo.LoggedinUser.SuperUser)
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

    }
}