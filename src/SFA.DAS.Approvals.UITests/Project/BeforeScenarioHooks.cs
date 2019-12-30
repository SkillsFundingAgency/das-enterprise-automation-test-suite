using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Configuration;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectcontext;
        private ApprenticeDataHelper _datahelper;
        private readonly ApprovalsConfig _approvalsConfig;
        private readonly ProviderPermissionsConfig _providerPermissionsConfig;
        private readonly SqlDatabaseConnectionHelper _sqlDatabaseConnectionHelper;

        public BeforeScenarioHooks(ScenarioContext context)
        {
            _context = context;
            _objectcontext = context.Get<ObjectContext>();
            _approvalsConfig = context.GetApprovalsConfig<ApprovalsConfig>();
            _providerPermissionsConfig = context.GetProviderPermissionConfig<ProviderPermissionsConfig>();
            _sqlDatabaseConnectionHelper = context.Get<SqlDatabaseConnectionHelper>();
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();

            var apprenticeStatus = _context.ScenarioInfo.Tags.Contains("liveapprentice") ? ApprenticeStatus.Live :
                                   _context.ScenarioInfo.Tags.Contains("currentacademicyearstartdate") ? ApprenticeStatus.CurrentAcademicYearStartDate :
                                   _context.ScenarioInfo.Tags.Contains("waitingtostartapprentice") ? ApprenticeStatus.WaitingToStart : ApprenticeStatus.Random;

            var commitmentsdatahelper = new CommitmentsDataHelper(_approvalsConfig, _sqlDatabaseConnectionHelper);

            _context.Set(commitmentsdatahelper);

            var providerPermissionsdatahelper = new ProviderPermissionsDatahelper(_providerPermissionsConfig, _sqlDatabaseConnectionHelper);

            _context.Set(providerPermissionsdatahelper);

            _datahelper = new ApprenticeDataHelper(_objectcontext, random, commitmentsdatahelper);

            _context.Set(_datahelper);

            _context.Set(new EditedApprenticeDataHelper(random, _datahelper));

            var isTransfersFunds = _context.ScenarioInfo.Tags.Contains("transfersfunds");

            var randomCoursehelper = new RandomCourseHelper(random, isTransfersFunds);

            var apprenticeCourseDataHelper = new ApprenticeCourseDataHelper(randomCoursehelper, apprenticeStatus);

            _context.Set(apprenticeCourseDataHelper);

            _context.Set(new EditedApprenticeCourseDataHelper(randomCoursehelper, apprenticeCourseDataHelper));

            _context.Set(new DlockDataHelper(_approvalsConfig, new FileHelper(), _datahelper, apprenticeCourseDataHelper, _sqlDatabaseConnectionHelper));
        }
    }
}
