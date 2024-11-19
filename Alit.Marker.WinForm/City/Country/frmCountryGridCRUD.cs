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
using Alit.Marker.Model.City;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.City.Country
{
    public partial class frmCountryGridCRUD : Template.frmGridCRUDTemplate
    {
        DAL.City.Country.CountryDAL DALObject;

        public frmCountryGridCRUD()
        {
            InitializeComponent();
            DALObject = new DAL.City.Country.CountryDAL();

            this.CrudGridControl = gridControl1;
            this.CrudGridView = gridView1;
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            return DALObject;
        }        
    }
}
