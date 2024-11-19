using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.WinformControls
{
    [ToolboxItem(true)]
    public class ErrorProvider : DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider	
    {
        public ErrorProvider()
            : base()
        {
            ErrorList = new Dictionary<Control, string>();
        }
        public ErrorProvider(System.ComponentModel.IContainer container)
            : base(container)
        {
            ErrorList = new Dictionary<Control, string>();
        }
        public ErrorProvider(System.Windows.Forms.ContainerControl ParentControl)
            : base(ParentControl)
        {
            ErrorList = new Dictionary<Control, string>();
        }

        public Dictionary<Control, string> ErrorList { get; private set; }

        public new void SetError(Control control, string value)
        {
            if (control != null)
            {
                // Setting error
                if (!String.IsNullOrWhiteSpace(value))
                {
                    // new error 
                    if (!ErrorList.ContainsKey(control))
                    {
                        ErrorList.Add(control, value);
                        SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
                    }
                    else // updating error
                    {
                        ErrorList[control] = value;
                    }
                }
                else if (ErrorList.ContainsKey(control)) // Error exists and Remove it from list
                {
                    ErrorList.Remove(control);
                }
            }
            base.SetError(control, value);
        }

        public void Clear()
        {
            if (ErrorList != null) ErrorList.Clear();
            //base.Clear();
            base.ClearErrors();
        }

        public string GetAllErrorText()
        {
            string ErrorText = String.Empty;
            foreach (string err in ErrorList.Values)
            {
                ErrorText += (ErrorText != String.Empty ? "\r\n" : "") + err;
            }
            return ErrorText;
        }

        protected override void Dispose(bool disposing)
        {
            if (ErrorList != null)
            {
                ErrorList.Clear();
                ErrorList = null;
            }
            base.Dispose(disposing);
        }
    }
}
