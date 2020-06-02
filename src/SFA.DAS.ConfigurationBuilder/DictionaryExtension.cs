using System.Collections.Generic;
using TechTalk.SpecFlow;

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

        public static T GetValue<T>(this SpecFlowContext context) => context.TryGetValue<T>(out var value) ? value : default;

        public static T GetValue<T>(this Dictionary<string, object> context, string key) => context.TryGetValue(key, out var value) ? (T)value : default;
    }
}
