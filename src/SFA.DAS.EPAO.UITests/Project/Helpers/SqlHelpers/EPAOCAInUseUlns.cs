using System.Collections.Generic;

namespace SFA.DAS.EPAO.UITests.Project.Helpers.SqlHelpers
{
    internal static class EPAOCAInUseUlns
    {
        static readonly object _object = new object();

        private static readonly List<string> _ulns = new List<string>();

        internal static void RemoveInUseUln(string uln) => _ulns.Remove(uln);

        internal static bool IsNotInUseUln(string uln)
        {
            lock (_object)
            {
                if (!(_ulns.Contains(uln)))
                {
                    _ulns.Add(uln);
                    return true;
                }

                return false;
            }
        }
    }
}