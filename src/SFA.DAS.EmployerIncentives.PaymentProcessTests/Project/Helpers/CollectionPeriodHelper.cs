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

            _stopWatchHelper.Start("SetActiveCollectionPeriod");
            await _sqlHelper.SetActiveCollectionPeriod(periodNumber, academicYear);
            _stopWatchHelper.Stop("SetActiveCollectionPeriod");
        }    
    }
}
