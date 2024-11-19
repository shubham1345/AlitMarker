using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.ExecuteUpdate
{
    public static class CommonFunctions
    {
    }

    public static class CommonProperties
    {
        public const string CheckUpdateAPIBaseAddress = "http://markeradmin.alittech.com/api/"; // "http://localhost:61796/api/"; //
        public const string GetLatestVersionNumberAPIAddress = "CheckUpdate/GetLatestVersionNumber";
        public const string GetFTPAddress = "CheckUpdate/GetFTPAddress";
        public const string GetNextRequiredFileDownloadUpdateVersion = "CheckUpdate/GetNextRequiredFileVersions";
        public const string GetNextVersions = "CheckUpdate/GetNextVersions";
        public const string GetDatabaseUpdateScript = "CheckUpdate/GetDatabaseUpdateScript";
    }
}
