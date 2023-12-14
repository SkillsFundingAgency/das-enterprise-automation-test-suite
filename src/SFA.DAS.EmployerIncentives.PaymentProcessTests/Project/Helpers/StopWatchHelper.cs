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
            if (_stopWatches.TryGetValue(caller, out StopWatchInstance instance))
            {
                instance.Stop();
            }
        }

        private class StopWatchInstance(string caller)
        {
            private readonly Stopwatch _stopwatch = new();

            public void Start()
            {
                _stopwatch.Restart();
                Console.WriteLine($@"[{caller}] started");
            }

            public void Stop()
            {
                Console.WriteLine($@"[{caller}] finished in {_stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }
}
