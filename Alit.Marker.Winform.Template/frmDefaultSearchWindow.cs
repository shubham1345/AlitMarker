using Alit.Marker.Model.Template;
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

namespace Alit.Marker.WinForm.Template
{
    public partial class frmDefaultSearchWindow : frmSearchWindowTemplate
    {
        private frmDefaultSearchWindow() : this(null, null, null, null, null) { }

        public frmDefaultSearchWindow(Type crudFormType, ILookupListDAL lookupDALObj, IEnumerable<ILookupListViewModel> dsLookup, ILookupListViewModel defaultFocusedRow, string WindowCaption) 
            : base(crudFormType, lookupDALObj, dsLookup, defaultFocusedRow, WindowCaption)
        {
            InitializeComponent();
            this.SearchGridControl = gcSearch;
            this.SearchGridView = gvSearch;
        }
    }
}
