using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages
{
    public class AEDIndexPage : AEDBasePage
    {
        protected override string PageTitle => "Training providers for";
        protected override By PageHeader => By.ClassName("govuk-caption-xl");

        private readonly ScenarioContext _context;
        public AEDIndexPage(ScenarioContext context) : base(context) => _context = context;

        #region Locators
        private By GetHelpWithFindingATrainingProviderLink => By.LinkText("Get help with finding a training provider");
        #endregion

        public GetHelpWithFindingATrainingProviderPage ClickGetHelpWithFindingATrainingProviderLink()
        {
            formCompletionHelper.Click(GetHelpWithFindingATrainingProviderLink);
            return new GetHelpWithFindingATrainingProviderPage(_context);
        }
    }
}
