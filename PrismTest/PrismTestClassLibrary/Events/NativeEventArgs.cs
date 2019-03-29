using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismTestClassLibrary.Events
{
    public class NativeEventArgs : EventArgs
    {
        public string Message { get; set; }

        public NativeEventArgs(string message)
        {
            Message = message;
        }
    }

    public class NativeEvent : PubSubEvent<NativeEventArgs> { }
}
