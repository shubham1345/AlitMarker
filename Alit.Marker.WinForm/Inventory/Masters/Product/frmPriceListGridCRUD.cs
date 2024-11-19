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
using Alit.Marker.DAL.Inventory.Masters.Product;

namespace Alit.Marker.WinForm.Inventory.Masters.Product
{
    public partial class frmPriceListGridCRUD : Template.frmGridCRUDTemplate
    {
        PriceListDAL DALObject;
        public frmPriceListGridCRUD()
        {
            InitializeComponent();
            DALObject = new PriceListDAL();

            CrudGridControl = gcPriceList;
            CrudGridView = gvPriceList;
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            if (DALObject == null)
            {
                DALObject = new PriceListDAL();
            }
            return DALObject;
        }
    }
}
