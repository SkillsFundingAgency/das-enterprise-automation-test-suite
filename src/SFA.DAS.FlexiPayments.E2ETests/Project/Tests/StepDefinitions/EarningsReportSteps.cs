using Microsoft.Azure.Documents.SystemFunctions;
using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EarningsReportSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EarningsSqlDbHelper _earningsSqlDbHelper;

        public EarningsReportSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _providerStepsHelper = new ProviderStepsHelper(_context);
            _earningsSqlDbHelper = context.Get<EarningsSqlDbHelper>();
        }

        [Given(@"the provider logs into their account")]
        public void GivenTheProviderLogsIntoTheirAccount() => _providerStepsHelper.GoToProviderHomePage(false);

        [When(@"provider is on Apprenticeship indicative earnings report page")]
        public void WhenProviderIsOnApprenticeshipIndicativeEarningsReportPage() => _providerStepsHelper.GoToApprenticeshipIndicativeEarningsReportPage();

        [Then(@"validate correct earnings numbers are displayed")]
        public void ThenValidateCorrectEarningsNumbersAreReported()
        {
            var providerApprenticeshipIndicativeEarningsReportPage = new ProviderApprenticeshipIndicativeEarningsReportPage(_context);

            var earnings = _earningsSqlDbHelper.GetApprenticeshipIndicativeEarnings(_objectContext.Get("ukprn"));

            providerApprenticeshipIndicativeEarningsReportPage.ValidateEarnings(earnings.totalEarnings, earnings.levyEarnings, earnings.nonLevyEarnings);

        }
    }
}