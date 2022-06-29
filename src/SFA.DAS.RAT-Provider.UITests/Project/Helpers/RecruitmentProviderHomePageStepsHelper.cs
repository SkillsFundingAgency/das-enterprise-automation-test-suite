using SFA.DAS.ProviderLogin.Service.Helpers;
using TechTalk.SpecFlow;
using RecruitmentHomePage = SFA.DAS.RAT_Provider.UITests.Project.Tests.Pages.RecruitmentHomePage;

namespace SFA.DAS.RAT_Provider.UITests.Project.Helpers
{
    public class RecruitmentProviderHomePageStepsHelper
    {
        private readonly ScenarioContext _context;

        public RecruitmentProviderHomePageStepsHelper(ScenarioContext context) => _context = context;

        public RecruitmentHomePage GoToRecruitmentProviderHomePage(bool newTab)
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(newTab);

            return new RecruitmentHomePage(_context, true);
        }
    }
}
