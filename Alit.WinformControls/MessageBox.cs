using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.WinformControls
{
    public static class MessageBox
    {
        public static string MessageBoxTitle { get; set; }

        public static DialogResult Show(string text)
        {
            return System.Windows.Forms.MessageBox.Show(DefaultOwner, text, MessageBoxTitle);
        }

        public static DialogResult Show(IWin32Window owner, string text)
        {
            return System.Windows.Forms.MessageBox.Show(owner, text, MessageBoxTitle);
        }

        public static DialogResult Show(string text, MessageBoxButtons buttons)
        {
            return System.Windows.Forms.MessageBox.Show(DefaultOwner, text, MessageBoxTitle, buttons);
        }

        public static DialogResult Show(IWin32Window owner, string text, MessageBoxButtons buttons)
        {
            return System.Windows.Forms.MessageBox.Show(owner, text, MessageBoxTitle, buttons);
        }

        public static DialogResult Show(string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return System.Windows.Forms.MessageBox.Show(DefaultOwner, text, MessageBoxTitle,
                buttons, icon);
        }

        public static DialogResult Show(IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return System.Windows.Forms.MessageBox.Show(owner, text, MessageBoxTitle,
                buttons, icon);
        }

        public static DialogResult Show(string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return System.Windows.Forms.MessageBox.Show(DefaultOwner, text, MessageBoxTitle,
                buttons, icon, defaultButton);
        }

        public static DialogResult Show(IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return System.Windows.Forms.MessageBox.Show(owner, text, MessageBoxTitle,
                buttons, icon, defaultButton);
        }

        public static DialogResult Show(string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        {
            return System.Windows.Forms.MessageBox.Show(DefaultOwner, text, MessageBoxTitle,
                buttons, icon, defaultButton, options);
        }

        public static DialogResult Show(IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        {
            return System.Windows.Forms.MessageBox.Show(owner, text, MessageBoxTitle,
                buttons, icon, defaultButton, options);
        }

        public static DialogResult Show(string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, bool displayHelpButton)
        {
            return System.Windows.Forms.MessageBox.Show(DefaultOwner, text, MessageBoxTitle,
                buttons, icon, defaultButton, options);
        }

        public static DialogResult Show(string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath)
        {
            return System.Windows.Forms.MessageBox.Show(DefaultOwner, text, MessageBoxTitle,
                buttons, icon, defaultButton, options, helpFilePath);
        }

        public static DialogResult Show(IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath)
        {
            return System.Windows.Forms.MessageBox.Show(owner, text, MessageBoxTitle,
                buttons, icon, defaultButton, options, helpFilePath);
        }

        public static DialogResult Show(string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator)
        {
            return System.Windows.Forms.MessageBox.Show(DefaultOwner, text, MessageBoxTitle,
                buttons, icon, defaultButton, options, helpFilePath, navigator);
        }

        public static DialogResult Show(string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, string keyword)
        {
            return System.Windows.Forms.MessageBox.Show(DefaultOwner, text, MessageBoxTitle,
                buttons, icon, defaultButton, options, helpFilePath);
        }

        public static DialogResult Show(IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator)
        {
            return System.Windows.Forms.MessageBox.Show(owner, text, MessageBoxTitle,
                buttons, icon, defaultButton, options, helpFilePath, navigator);
        }

        public static DialogResult Show(IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, string keyword)
        {
            return System.Windows.Forms.MessageBox.Show(owner, text, MessageBoxTitle,
                buttons, icon, defaultButton, options, helpFilePath);
        }

        public static DialogResult Show(string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator, object param)
        {
            return System.Windows.Forms.MessageBox.Show(DefaultOwner, text, MessageBoxTitle,
                buttons, icon, defaultButton, options, helpFilePath, navigator, param);
        }

        public static DialogResult Show(IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator, object param)
        {
            return System.Windows.Forms.MessageBox.Show(owner, text, MessageBoxTitle,
                buttons, icon, defaultButton, options, helpFilePath, navigator, param);
        }

        public static IWin32Window DefaultOwner
        {
            get;
            set;
        }
    }
}