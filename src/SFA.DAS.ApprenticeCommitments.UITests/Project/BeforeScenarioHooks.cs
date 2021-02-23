using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;

        public BeforeScenarioHooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 33)]
        public void SetUpHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();

            var _datahelper = new ApprenticeCommitmentsDataHelper(random);

            _context.Set(_datahelper);
        }
    }
}