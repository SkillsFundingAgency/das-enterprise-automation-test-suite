using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProviderFeedbackHomePage : ProviderFeedbackBasePage
    {
        protected override string PageTitle => "Give feedback";

        private By StartButton => By.Id("service-start");

        public ProviderFeedbackHomePage(ScenarioContext context) : base(context) { } 

        public ProviderFeedbackStrengthsPage StartNow()
        {
            formCompletionHelper.ClickElement(StartButton);
            return new ProviderFeedbackStrengthsPage(context);
        }
    }
}