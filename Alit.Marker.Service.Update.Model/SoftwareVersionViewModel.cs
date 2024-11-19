using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Alit.Marker.Service.Update.Model
{
    public class SoftwareVersionViewModel
    {
        public int SoftwareVersionID { get; set; }

        [DisplayName("Major Version")]
        public int MajorVersion { get; set; }

        [DisplayName("Minor Version")]
        public int MinorVersion { get; set; }

        public bool RequiredFileDownload { get; set; }
    }

    public class DatabaseUpdateScriptViewModel
    {
        public long dbUpdateScriptID { get; set; }
        public long SoftwareVersionID { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public string ScriptTitle { get; set; }
        public string dbScript { get; set; }
    }
}