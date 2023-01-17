using System.Reflection;
using System;

namespace SFA.DAS.FrameworkHelpers
{
    public class ToString : System.Attribute
    {
        private readonly string _value;
        public ToString(string value)
        {
            _value = value;
        }
        public string Value
        {
            get { return _value; }
        }
    }

    public static class EnumToString
    {
        public static string GetStringValue(Enum value)
        {
            string output = null;
            
            Type type = value.GetType();
            
            FieldInfo fi = type.GetField(value.ToString());
            
            ToString[] attrs = fi.GetCustomAttributes(typeof(ToString), false) as ToString[];
            
            if (attrs.Length > 0) output = attrs[0].Value;

            return output;
        }
    }
}
