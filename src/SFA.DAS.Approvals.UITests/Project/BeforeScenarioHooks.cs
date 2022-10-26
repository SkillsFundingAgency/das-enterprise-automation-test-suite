using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectcontext;
        private ApprenticeDataHelper _datahelper;
        private readonly DbConfig _dbConfig;
        private readonly string[] _tags;

        public BeforeScenarioHooks(ScenarioContext context)
        {
            _context = context;
            _objectcontext = context.Get<ObjectContext>();
            _dbConfig = context.Get<DbConfig>();
            _tags = context.ScenarioInfo.Tags;
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var apprenticeStatus = _tags.Contains("liveapprentice") ? ApprenticeStatus.Live :
                                   _tags.Contains("onemonthbeforecurrentacademicyearstartdate") ? ApprenticeStatus.OneMonthBeforeCurrentAcademicYearStartDate :
                                   _tags.Contains("currentacademicyearstartdate") ? ApprenticeStatus.CurrentAcademicYearStartDate :
                                   _tags.Contains("waitingtostartapprentice") ? ApprenticeStatus.WaitingToStart : ApprenticeStatus.Random;

            var commitmentsdatahelper = new CommitmentsSqlDataHelper(_dbConfig);

            _context.Set(commitmentsdatahelper);

            _context.Set(new ProviderPermissionsSqlDbHelper(_dbConfig));

            _datahelper = new ApprenticeDataHelper(_context.Get<ApprenticePPIDataHelper>(), _objectcontext, commitmentsdatahelper);

            _context.Set(_datahelper);

            _context.Set(new EditedApprenticeDataHelper(_datahelper));

            var roatpV2SqlDataHelper = new RoatpV2SqlDataHelper(_dbConfig, _context.GetPortableFlexiJobProviderConfig<PortableFlexiJobProviderConfig>()?.Ukprn);

            var randomCoursehelper = new RandomCourseDataHelper(new CrsSqlhelper(_dbConfig), roatpV2SqlDataHelper, _tags);

            var apprenticeCourseDataHelper = new ApprenticeCourseDataHelper(randomCoursehelper, apprenticeStatus);

            _context.Set(apprenticeCourseDataHelper);

            _context.Set(new DataLockSqlHelper(_dbConfig, _datahelper, apprenticeCourseDataHelper, _context.ScenarioInfo.Title));

            _context.Set(new AccountsDbSqlHelper(_dbConfig));

            _context.Set(new PublicSectorReportingDataHelper());

            _context.Set(new PublicSectorReportingSqlDataHelper(_dbConfig));

            _context.Set(new ManageFundingEmployerStepsHelper(_context));
        }
    }
}