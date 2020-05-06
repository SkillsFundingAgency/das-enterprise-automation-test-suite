using System.Collections.Generic;

namespace SFA.DAS.ConfigurationBuilder
{
    public static class DictionaryExtension
    {
        public static void Replace<T>(this Dictionary<string, object> dictionary, T value) => dictionary.Replace(typeof(T).FullName, value);

        public static void Replace<T>(this Dictionary<string, object> dictionary, string key, T value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            { 
                dictionary.Add(key, value);
            }
        }
    }
}
