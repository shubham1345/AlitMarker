using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.ERP.Masters.Transport
{
    public class LookupEditTransport : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmTransportCRUD);
            }
        }

        DAL.ERP.Masters.Transport.TransportDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.ERP.Masters.Transport.TransportDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "TransportName";
            Properties.ValueMember = "TransportID";
            base.AssignFormatProperties();
        }
    }
}
