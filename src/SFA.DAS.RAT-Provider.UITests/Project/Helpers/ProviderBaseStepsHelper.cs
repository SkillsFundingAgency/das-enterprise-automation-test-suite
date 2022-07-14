using SFA.DAS.RAT_Provider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAT_Provider.UITests.Project.Helpers
{
    public abstract class ProviderBaseStepsHelper
    {
        protected readonly ScenarioContext _context;

        public ProviderBaseStepsHelper(ScenarioContext context) => _context = context;

        protected TraineeshipRecruitHomePage GoToTraineeshipHomePage(bool newTab) => new RecruitmentTraineeshipsProviderHomePageStepsHelper(_context).GoToTraineeshipRecruitmentProviderHomePage(newTab);
    }
}
