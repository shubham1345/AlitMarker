using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Template
{
    public interface ICRUDViewModel
    {
        long PrimeKeyID { get; set; }
    }

    public interface IEditUserInfo
    {
        DateTime? CreatedDateTime { get; set; }

        long? CreatedUserID { get; set; }

        string CreatedUserName { get; set; }

        DateTime? EditedDateTime { get; set; }

        long? EditedUserID { get; set; }

        string EditedUserName { get; set; }
    }
}
