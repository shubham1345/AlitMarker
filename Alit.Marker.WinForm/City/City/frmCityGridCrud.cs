using Alit.Marker.DAL.City.City;
using Alit.Marker.DAL.City.State;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.City.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.City.City
{
    public partial class frmCityGridCrud : Template.frmGridCRUDTemplate
    {
        CityDAL DALObject;

        StateDAL StateDALObj;
        List<StateLookupListModel> dsState;

        public frmCityGridCrud()
        {
            InitializeComponent();

            DALObject = new CityDAL();
            StateDALObj = new StateDAL();

            CrudGridControl = gcCity;
            CrudGridView = gvCity;
        }

        protected override void LoadLookupDataSource()
        {
            dsState = StateDALObj.GetLookupList();
            base.LoadLookupDataSource();
        }

        protected override void AssignLookupDataSource()
        {
            repositoryItemlueStateCountry.ValueMember = "StateID";
            repositoryItemlueStateCountry.DisplayMember = "StateName";
            repositoryItemlueStateCountry.DataSource = dsState;

            base.AssignLookupDataSource();
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            return DALObject;
        }        
    }
}
