using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Inventory.Masters.Unit
{
    public class LookupEditUnit : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmUnitCRUD);
            }
        }

        private DAL.Inventory.Masters.Unit.UnitDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Inventory.Masters.Unit.UnitDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "UnitName";
            Properties.ValueMember = "UnitID";
            base.AssignFormatProperties();
        }
    }
}
