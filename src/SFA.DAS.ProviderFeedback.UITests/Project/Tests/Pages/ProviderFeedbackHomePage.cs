using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProviderFeedbackHomePage : ProviderFeedbackBasePage
    {
        protected override string PageTitle => "Give feedback";
        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        private readonly ScenarioContext _context;

        #region Locators
        private By StartButton => By.Id("service-start");
        #endregion

        public ProviderFeedbackHomePage(ScenarioContext context) : base(context) => _context = context;
    }
}
