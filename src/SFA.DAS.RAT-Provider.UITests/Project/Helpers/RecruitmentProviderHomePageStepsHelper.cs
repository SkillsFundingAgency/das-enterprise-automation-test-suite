using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.RAT_Provider.UITests.Project.Tests.Pages;
using SFA.DAS.ProviderLogin.Service.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

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
