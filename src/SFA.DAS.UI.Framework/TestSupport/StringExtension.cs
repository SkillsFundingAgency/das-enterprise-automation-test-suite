using System.Text.RegularExpressions;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public static class StringExtension
    {
        public static bool CompareToIgnoreCase(this string strA, string strB)
        {
            return string.Compare(strA.RemoveSpace(), strB, true) == 0;
        }

        public static string RemoveSpace(this string s)
        {
           return Regex.Replace(s, @"\s+", string.Empty);
        }
    }
}
