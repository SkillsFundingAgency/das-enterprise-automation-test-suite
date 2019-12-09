using System;
using System.Collections.Generic;

namespace SFA.DAS.RAA_V2.UITests.Project.Helpers
{
    public static class ListExtension
    {
        public static string RandomOrDefault(this List<string> list)
        {
            var randomnNumber = new Random().Next(0, list.Count);
            return list.Count == 0  ? null : list[randomnNumber];
        }
    }
}