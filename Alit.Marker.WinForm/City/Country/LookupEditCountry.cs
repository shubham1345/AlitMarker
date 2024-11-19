using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.City.Country
{
    public class LookupEditCountry : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmCountryCRUD);
            }
        }

        private DAL.City.Country.CountryDAL DALObj;
        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.City.Country.CountryDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "CountryName";
            Properties.ValueMember = "CountryID";
            base.AssignFormatProperties();
        }
    }
}
