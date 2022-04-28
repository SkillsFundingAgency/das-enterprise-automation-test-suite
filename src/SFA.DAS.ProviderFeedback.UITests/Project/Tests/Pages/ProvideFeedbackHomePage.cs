using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProvideFeedbackHomePage : ProvideFeedbackBasePage
    {
        protected override string PageTitle => "Give feedback";

        private By StartButton => By.Id("service-start");

        public ProvideFeedbackHomePage(ScenarioContext context) : base(context) { } 

        public ProvideFeedbackStrengthsPage StartNow()
        {
            formCompletionHelper.ClickElement(StartButton);
            return new ProvideFeedbackStrengthsPage(context);
        }
    }
}