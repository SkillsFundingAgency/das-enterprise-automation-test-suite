using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.FrameworkHelpers
{
    public static class ListExtension
    {
        public static bool IsNoDataFound(this List<string[]> x) => IsNoDataFound(x.ListOfArrayToList(0));

        public static bool IsNoDataFound(this List<string> x) => (x.Count == 1 && string.IsNullOrEmpty(x[0]));

        public static string RandomOrDefault(this List<string> list)
        {
            var randomnNumber = new Random().Next(0, list.Count);

            return list.Count == 0  ? null : list[randomnNumber];
        }

        public static List<T> ListOfArrayToList<T>(this List<T[]> listarray, int index) where T : class
        {
            return listarray.Select(x => x[index]).ToList();
        }

        public static string ToString(this IEnumerable<string> list, string separator) => string.Join(separator, list);

        public static string ExceptionToString(this List<Exception> list) => string.Join(Environment.NewLine, list.Select(x => x.Message).ToList());
    }
}