using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ProviderGiveFeedbackPage(ScenarioContext context) : RaaBasePage(context)
    {
        private static By ConfirmButton => By.CssSelector("input[value='Confirm'][class='govuk-button']");

        protected override string PageTitle => $"Give feedback to {rAADataHelper.CandidateFullName}";

        protected override string AccessibilityPageTitle => "Give feedback to candidate page";

        public ProviderAreYouSureUnSuccessfulPage FeedbackForUnsuccessful()
        {
            var messsage = rAADataHelper.OptionalMessage;
            formCompletionHelper.EnterText(CandidateFeedback, messsage);
            formCompletionHelper.Click(ConfirmButton);
            return new ProviderAreYouSureUnSuccessfulPage(context, messsage);
        }
    }
}
