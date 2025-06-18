using SFA.DAS.RAAProvider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Helpers
{
    public abstract class ProviderBaseStepsHelper(ScenarioContext context)
    {
        protected readonly ScenarioContext _context = context;

        protected RecruitmentHomePage GoToRecruitmentHomePage(bool newTab) => new RecruitmentProviderHomePageStepsHelper(_context).GoToRecruitmentProviderHomePage(newTab);
    }
}