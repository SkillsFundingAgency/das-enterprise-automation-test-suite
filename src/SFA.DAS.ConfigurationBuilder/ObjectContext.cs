using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.ConfigurationBuilder
{
    public class ObjectContext
    {
        private readonly Dictionary<string, object> _objects;

        public ObjectContext() => _objects = new Dictionary<string, object>();

        #region Getters

        public string Get(string key) => _objects.TryGetValue(key, out var value) ? value.ToString() : string.Empty;

        public T Get<T>() => Get<T>(typeof(T).FullName);

        public T Get<T>(string key) => _objects.GetValue<T>(key);

        public IEnumerable<T> GetAll<T>() => _objects.Values.OfType<T>();

        public Dictionary<string,object> GetAll() => _objects;

        #endregion

        #region Setters

        public void Set<T>(string key, T value) => _objects.Add(key, value);

        public void Update<T>(T value) => Update<T>(typeof(T).FullName, value);

        public void Update<T>(string key, T value)
        {
            if (KeyExists<T>(key))
            {
                _objects[key] = value;
            }
            else
            {
                throw new Exception("Object key does not exist and cannot be updated");
            }
        }

        public void Replace<T>(T value) => Replace<T>(typeof(T).FullName, value);

        public void Replace<T>(string key, T value) => _objects.Replace(key, value);

        #endregion

        public bool KeyExists<T>(string key) => _objects.ContainsKey(key);

        public void Remove(string key) => _objects.Remove(key);
    }
}
