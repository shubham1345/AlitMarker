using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.ExecuteUpdate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetFullPath(Path.GetDirectoryName(Application.ExecutablePath) + ".\\..\\Data"));
            //AppDomain.CurrentDomain.SetData("DataDirectory", @"D:\SyncedWithPC\AlitTech\Marker\Distribute\MMReshamwala\Marker1.0\Data");
            Application.Run(new frmExecuteUpdate());
        }
    }
}
