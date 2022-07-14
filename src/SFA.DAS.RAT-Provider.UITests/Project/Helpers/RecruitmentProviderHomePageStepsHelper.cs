using SFA.DAS.ProviderLogin.Service.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.RAT_Provider.UITests.Project.Tests.Pages;
using SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages;

namespace SFA.DAS.RAT_Provider.UITests.Project.Helpers
{
    public class RecruitmentProviderHomePageStepsHelper
    {
        private readonly ScenarioContext _context;

        public RecruitmentProviderHomePageStepsHelper(ScenarioContext context) => _context = context;

        public TraineeshipProviderHomePage GoToTraineeshipRecruitmentProviderHomePage(bool newTab)
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(newTab);

            return new TraineeshipProviderHomePage(_context, true);
        }
    }
}
