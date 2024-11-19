using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.City.City
{
    public class LookupEditCity : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmCityCRUD);
            }
        }

        private DAL.City.City.CityDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.City.City.CityDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "CityName";
            Properties.ValueMember = "CityID";
            Properties.PopupWidth = 700;
            Properties.DropDownRows = 15;

            base.AssignFormatProperties();
        }
    }
}
