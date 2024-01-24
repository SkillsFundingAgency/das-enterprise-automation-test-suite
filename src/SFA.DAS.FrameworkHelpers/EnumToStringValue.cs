using System.Reflection;

namespace SFA.DAS.FrameworkHelpers
{
    [AttributeUsage(AttributeTargets.All)]
    public class ToString(string value) : System.Attribute
    {
        public string Value
        {
            get { return value; }
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
