using Alit.Marker.DAL.Template;
using Alit.Marker.Model;
using Alit.Marker.Model.City.Country;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.City.State
{
    public partial class frmStateGridCRUD : Template.frmGridCRUDTemplate
    {
        DAL.City.State.StateDAL DALObject;

        DAL.City.Country.CountryDAL CountryDAL;
        List<CountryLookupModel> dsCountry;

        public frmStateGridCRUD()
        {
            InitializeComponent();

            DALObject = new DAL.City.State.StateDAL();
            CountryDAL = new DAL.City.Country.CountryDAL();

            CrudGridControl = gcState;
            CrudGridView = gvState;
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            return DALObject;
        }

        protected override void LoadLookupDataSource()
        {
            dsCountry = CountryDAL.GetLookupList();

            base.LoadLookupDataSource();
        }

        protected override void AssignLookupDataSource()
        {
            repositoryItemlueCountry.ValueMember = "CountryID";
            repositoryItemlueCountry.DisplayMember = "CountryName";
            repositoryItemlueCountry.DataSource = dsCountry;

            base.AssignLookupDataSource();
        }        
    }
}
