using OpenQA.Selenium;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;
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
        private By GetHelpWithFindingATrainingProviderLink => By.LinkText("Share your interest");
        #endregion

        public ShareYourInterestWithTrainingProvidersPage ClickGetHelpWithFindingATrainingProviderLink()
        {
            formCompletionHelper.Click(GetHelpWithFindingATrainingProviderLink);
            return new ShareYourInterestWithTrainingProvidersPage(_context);
        }
        
    }
}
