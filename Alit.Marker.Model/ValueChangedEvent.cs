using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model
{
    public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

    public class ValueChangedEventArgs
    {
        public ValueChangedEventArgs(object NewValue, object OldValue)
        {
            this.NewValue = NewValue;
            this.OldValue = OldValue;
        }

        public object NewValue { get; private set; }
        public object OldValue { get; private set; }
    }
}