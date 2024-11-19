using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Settings.Compnay
{
    public class LookupEditCompany : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmCompanyCRUD);
            }
        }

        private DAL.Settings.Compnay.CompanyDAL DALObj;
        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Settings.Compnay.CompanyDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "CompanyName";
            Properties.ValueMember = "CompanyID";
            base.AssignFormatProperties();
        }
    }
}
