using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FlexiPayments.E2ETests.Tests.StepDefinitions
{
    [Binding]
    public class EarningsReportSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderStepsHelper _providerStepsHelper;

        public EarningsReportSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(_context);
        }

        [Given(@"the provider logs into their account")]
        public void GivenTheProviderLogsIntoTheirAccount() => _providerStepsHelper.GoToProviderHomePage(false);

        [When(@"provider is on Apps indicative earnings report page")]
        public void WhenProviderIsOnAppsIndicativeEarningsReportPage() => _providerStepsHelper.GoToAppsIndicativeEarningsReportPage();

        [Then(@"validate correct earnings numbers are reported")]
        public void ThenValidateCorrectEarningsNumbersAreReported() => new ProviderAppsIndicativeEarningsReportPage(_context).ValidateUIElementsOnPage();

    }
}
