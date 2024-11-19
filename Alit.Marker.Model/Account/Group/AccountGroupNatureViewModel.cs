using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Account.Group
{
    public enum eAccountGroupNature
    {

        /// <summary>
        /// Credit side of Profit & Loss Account or Trading Account
        /// </summary>
        Income = 0,

        /// <summary>
        /// Debit side of Profit & Loss Account or Trading Account
        /// </summary>
        Expences = 1,

        /// <summary>
        /// Credit side of Balance sheet (liablities)
        /// </summary>
        Liablities = 2,

        /// <summary>
        /// Debit side of Balance Sheet (Assets)
        /// </summary>
        Asset = 3,
    }
}
