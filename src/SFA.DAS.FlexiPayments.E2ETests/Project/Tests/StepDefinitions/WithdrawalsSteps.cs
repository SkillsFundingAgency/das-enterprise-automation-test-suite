using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.Http;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{
    [Binding]
    public class WithdrawalsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext objectContext;
        private readonly ApprenticeshipsSqlDbHelper _apprenticeshipsSqlDbHelper;

        public WithdrawalsSteps(ScenarioContext context)
        {
            _context = context;
            objectContext = context.Get<ObjectContext>();
            _apprenticeshipsSqlDbHelper = context.Get<ApprenticeshipsSqlDbHelper>();
        }

        [When(@"a withdrawal is recorded with reason as (WithdrawFromBeta|WithdrawDuringLearning)")]
        public async Task AWithdrawalIsRecordedWithReason(string reason)
        {
            var apprenticeshipsClient = new ApprenticeshipsClient(_context);

            var providerConfig = _context.GetProviderConfig<ProviderConfig>();
            var uln = objectContext.GetULNKeyInformations().FirstOrDefault().uln;

            var body = new WithdrawApprenticeshipRequestBody
            {
                UKPRN = long.Parse(providerConfig.Ukprn),
                ULN = uln,
                Reason = reason,
                ReasonText = "",
                LastDayOfLearning = DateTime.Now,
                ProviderApprovedBy = providerConfig.Name + " - Payments Simplification E2E Tests"
            };
            await apprenticeshipsClient.WithdrawApprenticeship(body);
        }
    }
}
