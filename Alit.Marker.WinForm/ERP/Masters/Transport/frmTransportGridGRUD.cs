using Alit.Marker.DAL.ERP.Masters.Transport;
using Alit.Marker.DAL.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.ERP.Masters.Transport
{
    public partial class frmTransportGridGRUD : Template.frmGridCRUDTemplate
    {
        TransportDAL DALObject;

        public frmTransportGridGRUD()
        {
            InitializeComponent();
            DALObject = new TransportDAL();

            CrudGridControl = gcTransport;
            CrudGridView = gvTransport;
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            return DALObject;
        }
    }
}
