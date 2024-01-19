using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers
{
    public class RecruitmentProviderHomePageStepsHelper(ScenarioContext context)
    {
        public RecruitmentHomePage GoToRecruitmentProviderHomePage(bool newTab)
        {
            new ProviderHomePageStepsHelper(context).GoToProviderHomePage(newTab);

            return new RecruitmentHomePage(context, true);
        }
    }
}