using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Quark.Tools
{
    public static class Enum<T> where T : struct, IComparable, IFormattable, IConvertible
    {
        static Enum()
        {
            Debug.Assert(typeof(T).IsEnum, string.Format("The class ({0}) must be an enum", typeof(T).FullName));
        }

        public static int Length
        {
            get { return Enum.GetValues(typeof(T)).Length; }
        }

        public static T Parse(string input)
        {
            return (T)Enum.Parse(typeof(T), input, true);
        }

        public static bool TryParse(string input, out T? result)
        {
            result = null;
            if (string.IsNullOrEmpty(input) || !Enum.IsDefined(typeof(T), input))
            {
                return false;
            }
            result = (T)Enum.Parse(typeof(T), input, true);
            return true;
        }

        public static bool TryParse(string input, out T result)
        {
            T? temp;
            if (TryParse(input, out temp))
            {
                result = temp.Value;
                return true;
            }
            result = default(T);
            return false;
        }

        public static T[] GetValues()
        {
            var array = Enum.GetValues(typeof(T));
            return (T[])array;
        }

        public static U[] GetValues<U>()
        {
            var array = Enum.GetValues(typeof(T));
            return (U[])array;
        }

        public static string GetName(int value)
        {
            return Enum.GetName(typeof(T), value);
        }

        public static string GetName(long value)
        {
            return Enum.GetName(typeof(T), value);
        }

        public static string[] GetNames()
        {
            return Enum.GetNames(typeof(T));
        }

        static string GetName(T value)
        {
            return Enum.GetName(typeof(T), value);
        }

        public static string GetDescription(T value)
        {
            var attribute = Reflection.GetAttributeOnValue<DescriptionAttribute>(value);
            return attribute != null ? attribute.Description : GetName(value);
        }

        public static string GetDescription(int value)
        {
            return GetDescription((T)((object)value));
        }

        public static string GetDescription(long value)
        {
            return GetDescription((T)((object)value));
        }

        public static string GetDescription(string name)
        {
            return GetDescription(Parse(name));
        }

        public static string[] GetDescriptions()
        {
            return GetValues().Select(v => GetDescription(v)).ToArray();
        }

        public static KeyValuePair<T, string>[] GetValueAndDescriptionPairs()
        {
            return GetValues().Select(v => new KeyValuePair<T, string>(v, GetDescription(v))).ToArray();
        }

        #region Reflection

        internal static class Reflection
        {
            public static U GetAttributeOnValue<U>(T value) where U : Attribute
            {
                string name = GetName(value);
                Type type = typeof(T);
                MemberInfo[] members = type.GetMember(name, BindingFlags.Public | BindingFlags.Static);
                if (members != null && members.Length > 0)
                {
                    return Attribute.GetCustomAttribute(members[0], typeof(U)) as U;
                }

                return null;
            }
        }

        #endregion
    }
}