using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static SFA.DAS.RAA.Service.Project.Tests.Pages.ProviderMakeApplicationsUnsuccessfulBasePage;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ProviderGiveFeedbackToMutlipleApplicants(ScenarioContext context) : RaaBasePage(context)
    {
        private static By ConfirmButton => By.CssSelector("input[value='Confirm'][class='govuk-button']");
        protected override string PageTitle => $"Give feedback to the unsuccessful applicant";
        protected override string AccessibilityPageTitle => "Give feedback to the unsuccessful applicant";

        public ProviderAreYouSureMultiUnSuccessfulPage FeedbackForMultipleUnsuccessful()
        {
            var messsage = rAADataHelper.OptionalMessage;
            formCompletionHelper.EnterText(MultipleCandidateFeedback, messsage);
            formCompletionHelper.Click(ConfirmButton);
            return new ProviderAreYouSureMultiUnSuccessfulPage(context, messsage);
        }
    }
}
