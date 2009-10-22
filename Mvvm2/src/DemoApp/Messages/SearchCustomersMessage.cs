using System;
using System.Reflection;
using Quark.Tools.Wpf.Events;

namespace DemoApp.Messages
{
    public class SearchCustomersMessage : IMessage
    {
        public PropertyInfo Property { get; set; }

        public string Condition { get; set; }

        public string Value { get; set; }
    }
}