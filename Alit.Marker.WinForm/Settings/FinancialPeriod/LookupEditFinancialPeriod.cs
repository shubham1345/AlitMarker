using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Settings.FinancialPeriod
{
    public class LookupEditFinancialPeriod : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmFinancialPeriodCRUD);
            }
        }

        DAL.Settings.FinancialPeriod.FinPeriodDAL DALObj;
        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Settings.FinancialPeriod.FinPeriodDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "FinPeriodName";
            Properties.ValueMember = "FinPeriodID";
            base.AssignFormatProperties();
        }
    }
}
