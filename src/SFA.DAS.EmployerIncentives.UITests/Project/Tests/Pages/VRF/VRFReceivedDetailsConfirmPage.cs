using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFReceivedDetailsConfirmPage : VRFBasePage
    {
        protected override string PageTitle => "We have received your details";

        protected override By PageHeader => By.XPath("//h1[text()='We have received your details']");

        #region Locators
        
        private By CaseIdSummary => By.CssSelector(".panel-gds p");
        private By ReturnToEasLink => By.CssSelector(".submission-message a");
        #endregion

        public VRFReceivedDetailsConfirmPage(ScenarioContext context) : base(context, false) => frameHelper.SwitchFrameAndAction(() => VerifyPage());

        public ApplicationCompletePage ReturnToEasApplicationCompletePage()
        {
            ReturnToEAS();
            return new ApplicationCompletePage(context);
        }

        public EIHubPage ReturnToEIHubPage()
        {
            ReturnToEAS();
            return new EIHubPage(context);
        }

        private void ReturnToEAS() => frameHelper.SwitchFrameAndAction(() => formCompletionHelper.ClickElement(ReturnToEasLink));
    }
}