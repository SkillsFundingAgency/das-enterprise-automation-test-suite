using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProvideFeedbackCompletePage : ProvideFeedbackBasePage
    {
        protected override string PageTitle => "Feedback complete";
        protected override By PageHeader => By.CssSelector(".govuk-panel__title");


        private By HaveConcerns => By.CssSelector("details summary");

        public ProvideFeedbackCompletePage(ScenarioContext context) : base(context) { }

        public void CanComplaint()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(HaveConcerns));

            formCompletionHelper.ClickLinkByText("make a formal complaint");
        }
    }
}