using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.WinForm.TransactionsCommon
{
    public class AdditionalItemDetailGridViewController
    {
        public GridView AdditionalItemDetailGridView { get; private set; }

        public AdditionalItemDetailGridViewController(GridView additionalItemDetailGridView)
        {
            AdditionalItemDetailGridView = additionalItemDetailGridView;
        }
    }
}
