namespace SingletonPattern
{
    public class Singleton<T>
        where T : class, new()
    {
        private static object syncLock = new();
        private static T _instance;
        public static T Instance
        {
            get
            {
                lock (syncLock)         // Monitor.Enter(syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                }                       // Monitor.Exit(syncLock)

                return _instance;
            }
        }
    }
}