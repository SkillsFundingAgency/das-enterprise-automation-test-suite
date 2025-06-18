using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class GetApprenticeshipAdviserPage(ScenarioContext context) : VerifyBasePage(context)
    {
        protected override string PageTitle => "Get an apprenticeship adviser";
        private static By GetAnAdvisorButton => By.CssSelector("button[type='submit']");
        public GetApprenticeshipAdviserPage GoToEmailAddressPage()
        {
            formCompletionHelper.Click(GetAnAdvisorButton);
            return new GetApprenticeshipAdviserPage(context);
        }
    }
}
