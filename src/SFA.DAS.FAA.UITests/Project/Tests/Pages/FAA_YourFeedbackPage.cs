using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_YourFeedbackPage(ScenarioContext context) : FAABasePage(context)
    {
        protected override string PageTitle => "Your feedback";

        private static By FeedbackText => By.CssSelector(".sfa-inset-yellow");
        private static By SignOutLink => By.Id("signout-link");

        public void VerifyReadFeedbackText()
        {
            pageInteractionHelper.VerifyText(FeedbackText, faaDataHelper.OptionalMessage);
            formCompletionHelper.Click(SignOutLink);
        }
    }
}
