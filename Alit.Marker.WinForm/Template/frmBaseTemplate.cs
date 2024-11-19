using Alit.Marker.Model;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.WinForm.Template
{
    public class BaseTemplate : XtraForm
    {
        long MenuOptionID_;
        public long MenuOptionID
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
                    var perm = CommonProperties.LoginInfo.UserPermission.FirstOrDefault(r => r.MenuOptionID == MenuOptionID_);
                    if (perm != null)
                    {
                        MenuOptionPermission = perm;
                    }
                    else
                    {
                        MenuOptionPermission = new Model.Users.MenuOptionPermissionViewModel()
                        {
                            MenuOptionID = MenuOptionID_
                        };
                    }
                    if (CommonProperties.LoginInfo.LoggedinUser.SuperUser)
                    {
                        MenuOptionPermission.CanAdd = true;
                        MenuOptionPermission.CanEdit = true;
                        MenuOptionPermission.CanDelete = true;
                    }
                }
            }
        }

        public Model.Users.MenuOptionPermissionViewModel MenuOptionPermission { get; set; }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            MemoryManagement.FlushMemory();
        }
    }
}
