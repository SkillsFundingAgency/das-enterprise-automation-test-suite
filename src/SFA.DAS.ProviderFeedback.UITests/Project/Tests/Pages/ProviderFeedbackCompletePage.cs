using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProviderFeedbackCompletePage : ProviderFeedbackBasePage
    {
        protected override string PageTitle => "Feedback complete";
        protected override By PageHeader => By.ClassName("govuk-box-highlight");


        private By HaveConcerns => By.CssSelector("details summary");

        public ProviderFeedbackCompletePage(ScenarioContext context) : base(context) { }

        public void CanComplaint()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(HaveConcerns));

            formCompletionHelper.ClickLinkByText("make a formal complaint");
        }
    }
}