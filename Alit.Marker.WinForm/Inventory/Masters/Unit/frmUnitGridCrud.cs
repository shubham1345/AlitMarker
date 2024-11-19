using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alit.Marker.DAL.Template;
using Alit.Marker.DAL.Inventory.Masters.Unit;

namespace Alit.Marker.WinForm.Inventory.Masters.Unit
{
    public partial class frmUnitGridCrud : Template.frmGridCRUDTemplate
    {
        UnitDAL DALObject;

        public frmUnitGridCrud()
        {
            InitializeComponent();
            DALObject = new UnitDAL();

            CrudGridControl = gcUnit;
            CrudGridView = gvUnit;
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            if(DALObject == null)
            {
                DALObject = new UnitDAL();
            }
            return DALObject;
        }
    }
}
