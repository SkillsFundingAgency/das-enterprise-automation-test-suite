using System;
using System.Threading.Tasks;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class CollectionCalendarHelper(ScenarioContext context)
    {
        private readonly EISqlHelper _sqlHelper = context.Get<EISqlHelper>();
        private readonly StopWatchHelper _stopWatchHelper = context.Get<StopWatchHelper>();
        private (byte Number, short Year) _activePeriod;

        public (byte Number, short Year) ActivePeriod => _activePeriod;

        public async Task SetActiveCollectionPeriod(byte periodNumber, short academicYear)
        {
            _activePeriod.Number = periodNumber;
            _activePeriod.Year = academicYear;

            _stopWatchHelper.Start("SetActiveCollectionPeriod");
            await _sqlHelper.SetActiveCollectionPeriod(periodNumber, academicYear);
            _stopWatchHelper.Stop("SetActiveCollectionPeriod");
        }

        public async Task SetNextActiveCollectionPeriod()
        {
            switch (_activePeriod.Number)
            {
                case 12 when _activePeriod.Year != 2021:
                    throw new Exception("Unexpected Academic Year rollover");
                case 12 when _activePeriod.Year == 2021:
                    await SetActiveCollectionPeriod((byte) 1, 2122);
                    break;
                default:
                    await SetActiveCollectionPeriod((byte) (_activePeriod.Number + 1), _activePeriod.Year);
                    break;
            }
        }

        public async Task Reset()
        {
            await _sqlHelper.ResetCalendar();
        }

        public CollectionCalendarPeriod GetActiveCollectionPeriod()
        {
            return _sqlHelper.GetFromDatabase<CollectionCalendarPeriod>(p => p.Active);
        }
    }
}
