using SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers
{
    public abstract class ProviderBaseStepsHelper
    {
        protected readonly ScenarioContext _context;

        public ProviderBaseStepsHelper(ScenarioContext context) => _context = context;

        protected RecruitmentHomePage GoToRecruitmentHomePage(bool newTab) => new RecruitmentProviderHomePageStepsHelper(_context).GoToRecruitmentProviderHomePage(newTab);
    }
}