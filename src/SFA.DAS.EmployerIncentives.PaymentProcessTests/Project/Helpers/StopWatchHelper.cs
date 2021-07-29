using System;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class StopWatchHelper
    {
        private readonly ConcurrentDictionary<string, StopWatchInstance> _stopWatches;

        public StopWatchHelper()
        {
            _stopWatches = new ConcurrentDictionary<string, StopWatchInstance>();
        }

        public void Start(string caller)
        {
            var instance = _stopWatches.GetOrAdd(caller, new StopWatchInstance(caller));
            instance.Start();
        }

        public void Stop(string caller)
        {
            if(_stopWatches.TryGetValue(caller, out StopWatchInstance instance))
            {
                instance.Stop();
            }
        }

        private class StopWatchInstance
        {
            private readonly Stopwatch _stopwatch;
            private readonly string _caller;

            public StopWatchInstance(string caller)
            {
                _stopwatch = new Stopwatch();
                _caller = caller;
            }

            public void Start()
            {
                _stopwatch.Restart();
                Console.WriteLine($@"[{_caller}] started");
            }

            public void Stop()
            {
                Console.WriteLine($@"[{_caller}] finished in {_stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }
}
