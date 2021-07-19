using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public static class ListExtension
    {
        public static string RandomOrDefault(this List<string> list)
        {
            var randomnNumber = new Random().Next(0, list.Count);
            return list.Count == 0  ? null : list[randomnNumber];
        }

        public static List<T> ListOfArrayToList<T>(this List<T[]> listarray, int index) where T : class
        {
            return listarray.Select(x => x[index]).ToList();
        }
    }
}