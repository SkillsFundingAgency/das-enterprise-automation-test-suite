using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers
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