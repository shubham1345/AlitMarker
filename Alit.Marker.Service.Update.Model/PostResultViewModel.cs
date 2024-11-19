using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alit.Marker.Service.Update.Model
{
    public class  PostResultViewModel<T>
    {
        public bool Success { get; set; }

        public T ResultObject { get; set; }

        public string ErrorMessage { get; set; }

        public string ValidationMessage { get; set; }
    }
}