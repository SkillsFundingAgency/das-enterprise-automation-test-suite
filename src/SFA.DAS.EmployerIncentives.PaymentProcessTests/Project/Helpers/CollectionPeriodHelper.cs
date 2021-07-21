using Newtonsoft.Json;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class CollectionPeriodHelper
    {
        private readonly EISqlHelper _sqlHelper;
        private readonly StopWatchHelper _stopWatchHelper;
        private (byte Number, short Year) _activePeriod;

        public (byte Number, short Year) ActivePeriod => _activePeriod;

        public CollectionPeriodHelper(ScenarioContext context)
        {
            _sqlHelper = context.Get<EISqlHelper>();
            _stopWatchHelper = context.Get<StopWatchHelper>();
        }

        public async Task SetActiveCollectionPeriod(byte periodNumber, short academicYear)
        {
            _activePeriod.Number = periodNumber;
            _activePeriod.Year = academicYear;

            _stopWatchHelper.StartStopWatch("SetActiveCollectionPeriod");
            await _sqlHelper.SetActiveCollectionPeriod(periodNumber, academicYear);
            _stopWatchHelper.StopStopWatch("SetActiveCollectionPeriod");
        }
    
    }

    public class StopWatchHelper
    {
        private readonly ConcurrentDictionary<string, StopWatchInstance> _stopWatches;

        public StopWatchHelper()
        {
            _stopWatches = new ConcurrentDictionary<string, StopWatchInstance>();
        }

        public void StartStopWatch(string caller)
        {
            var instance = _stopWatches.GetOrAdd(caller, new StopWatchInstance(caller));
            instance.Start();
        }

        public void StopStopWatch(string caller)
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
