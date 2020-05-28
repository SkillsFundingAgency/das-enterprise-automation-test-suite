using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_YourFeedbackPage : FAABasePage
    {
        protected override string PageTitle => "Your feedback";

        private By FeedbackText => By.CssSelector(".sfa-inset-yellow");
        private By SignOutLink => By.Id("signout-link");

        public FAA_YourFeedbackPage(ScenarioContext context) : base(context) { }

        public void VerifyReadFeedbackText()
        {
            pageInteractionHelper.VerifyText(FeedbackText, faadataHelper.OptionalMessage);
            formCompletionHelper.Click(SignOutLink);
        }
    }
}
