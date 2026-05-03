using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonDesignPattern
{
    public class LogSingleton
    {
        private static LogSingleton _instance;
        private static int _index;
        private static readonly object _lock = new object();
        private LogSingleton(int index)
        {
            _index = index;
        }
        public static LogSingleton GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        var random = new Random();
                        _instance = new LogSingleton(random.Next(1, 4));
                    }
                }
            }

            return _instance;
        }

        //private static readonly Lazy<LogSingleton> _instance = new(() => new LogSingleton());
        //public static LogSingleton GetInstance() => _instance.Value;

        //private static int _index;
        //private LogSingleton()
        //{
        //    var random = new Random();
        //    _index = random.Next(1, 4);
        //}
        public void Log()
        {
            Console.WriteLine($"This is the log with number {_index}");
        }
    }
}
