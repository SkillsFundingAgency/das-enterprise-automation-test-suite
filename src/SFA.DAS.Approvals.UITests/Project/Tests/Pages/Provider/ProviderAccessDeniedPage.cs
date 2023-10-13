using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages
{
    public class ProviderAccessDeniedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "You need a different service role to view this page";

        private static By GoBackToHomePage => By.LinkText("homepage of this service.");

        public ProviderAccessDeniedPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApprovalsProviderHomePage GoBackToTheServiceHomePage()
        {
            formCompletionHelper.ClickElement(GoBackToHomePage);
            return new ApprovalsProviderHomePage(context);
        }
    }
}
