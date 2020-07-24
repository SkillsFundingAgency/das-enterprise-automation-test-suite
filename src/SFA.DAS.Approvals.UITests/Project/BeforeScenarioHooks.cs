using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectcontext;
        private ApprenticeDataHelper _datahelper;
        private readonly ApprovalsConfig _approvalsConfig;
        private readonly RegistrationConfig _registrationConfig;
        private readonly ProviderPermissionsConfig _providerPermissionsConfig;

        public BeforeScenarioHooks(ScenarioContext context)
        {
            _context = context;
            _objectcontext = context.Get<ObjectContext>();
            _approvalsConfig = context.GetApprovalsConfig<ApprovalsConfig>();
            _registrationConfig = context.GetRegistrationConfig<RegistrationConfig>();
            _providerPermissionsConfig = context.GetProviderPermissionConfig<ProviderPermissionsConfig>();
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();

            var commitmentsdatahelper = new CommitmentsSqlDataHelper(_approvalsConfig);

            _context.Set(commitmentsdatahelper);

            var providerPermissionsdatahelper = new ProviderPermissionsDatahelper(_providerPermissionsConfig);

            _context.Set(providerPermissionsdatahelper);

            _datahelper = new ApprenticeDataHelper(_objectcontext, random, commitmentsdatahelper);

            _context.Set(_datahelper);

            _context.Set(new EditedApprenticeDataHelper(random, _datahelper));

            var selectstandardcourse = _context.ScenarioInfo.Tags.Contains("selectstandardcourse");

            var randomCoursehelper = new RandomCourseDataHelper(random, selectstandardcourse);

            var apprenticeStatus = _context.Get<ApprenticeStatus>();

            var apprenticeCourseDataHelper = new ApprenticeCourseDataHelper(randomCoursehelper, apprenticeStatus);

            _context.Set(apprenticeCourseDataHelper);

            _context.Set(new EditedApprenticeCourseDataHelper(randomCoursehelper, apprenticeCourseDataHelper));

            _context.Set(new DataLockSqlHelper(_approvalsConfig, _datahelper, apprenticeCourseDataHelper));

            _context.Set(new AgreementIdSqlHelper(_registrationConfig));

            _context.Set(new PublicSectorReportingDataHelper(random));

            _context.Set(new PublicSectorReportingSqlDataHelper(_approvalsConfig));
        }
    }
}
