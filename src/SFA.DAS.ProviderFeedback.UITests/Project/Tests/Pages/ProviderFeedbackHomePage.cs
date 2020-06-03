using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProviderFeedbackHomePage : ProviderFeedbackBasePage
    {
        protected override string PageTitle => "Give feedback";

        private readonly ScenarioContext _context;

        private By StartButton => By.Id("service-start");

        public ProviderFeedbackHomePage(ScenarioContext context) : base(context) => _context = context;

        public ProviderFeedbackStrengths StartNow()
        {
            formCompletionHelper.ClickElement(StartButton);
            return new ProviderFeedbackStrengths(_context);
        }
    }
}