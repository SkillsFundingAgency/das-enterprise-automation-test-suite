using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EarningsReportSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;
        private readonly EarningsSqlDbHelper _earningsSqlDbHelper;

        public EarningsReportSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _providerCommonStepsHelper = new ProviderCommonStepsHelper(_context);
            _earningsSqlDbHelper = context.Get<EarningsSqlDbHelper>();
        }

        [Given(@"the provider logs into their account")]
        public void GivenTheProviderLogsIntoTheirAccount() => _providerCommonStepsHelper.GoToProviderHomePage(false);

        [When(@"provider is on Apprenticeship indicative earnings report page")]
        public void WhenProviderIsOnApprenticeshipIndicativeEarningsReportPage() => _providerCommonStepsHelper.GoToProviderHomePage(false).GoToApprenticeshipIndicativeEarningsReportPage();

        [Then(@"validate correct earnings numbers are displayed")]
        public void ThenValidateCorrectEarningsNumbersAreReported()
        {
            var appsIndicativeEarningsReportPage = new ProviderApprenticeshipIndicativeEarningsReportPage(_context);

            var earnings = _earningsSqlDbHelper.GetApprenticeshipIndicativeEarnings(_objectContext.Get("ukprn"));

            appsIndicativeEarningsReportPage.ValidateEarnings(earnings);

        }
    }
}