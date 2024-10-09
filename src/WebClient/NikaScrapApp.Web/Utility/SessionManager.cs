namespace NikaScrapApp.Web.Utility
{
    public static class SessionManager
    {
        private static Dictionary<string, object> _sessionStorage = new Dictionary<string, object>();

        public static void Set(string key, object value)
        {
            _sessionStorage[key] = value;
        }

        public static T Get<T>(string key)
        {
            if (_sessionStorage.TryGetValue(key, out var value))
            {
                return (T)value;
            }

            return default(T);
        }

        public static void Remove(string key)
        {
            _sessionStorage.Remove(key);
        }

        public static void Clear()
        {
            _sessionStorage.Clear();
        }

    }
}
