using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.RAT_Provider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAT_Provider.UITests.Project.Helpers
{
    public class RecruitmentTraineeshipsProviderHomePageStepsHelper
    {
        private readonly ScenarioContext _context;

        public RecruitmentTraineeshipsProviderHomePageStepsHelper(ScenarioContext context) => _context = context;

        public TraineeshipRecruitHomePage GoToTraineeshipRecruitmentProviderHomePage(bool newTab)
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(newTab);

            return new TraineeshipRecruitHomePage(_context, false).GoToTraineeshipHomePage();
        }
    }
}