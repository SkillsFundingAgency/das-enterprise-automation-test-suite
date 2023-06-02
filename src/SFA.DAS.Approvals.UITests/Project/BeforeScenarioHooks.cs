using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectcontext;
        private CommitmentsSqlDataHelper commitmentsdatahelper;
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

            commitmentsdatahelper = new CommitmentsSqlDataHelper(_dbConfig);

            _context.Set(commitmentsdatahelper);

            _context.Set(new ProviderPermissionsSqlDbHelper(_dbConfig));

            _context.Set(new RofjaaDbSqlHelper(_dbConfig));

            _context.Set(new AccountsDbSqlHelper(_dbConfig));

            _context.Set(new PublicSectorReportingDataHelper());

            _context.Set(new PublicSectorReportingSqlDataHelper(_dbConfig));

            _context.Set(new ManageFundingEmployerStepsHelper(_context));


            List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentices = new();

            (ApprenticeDataHelper apprenticeDataHelper, ApprenticeCourseDataHelper apprenticeCourseDataHelper, bool additionaldata) = SetProviderSpecificCourse(apprenticeStatus);

            listOfApprentices.Add((apprenticeDataHelper, apprenticeCourseDataHelper));

            if (additionaldata) listOfApprentices.Add((GetApprenticeDataHelper(), GetApprenticeCourseDataHelper(ApprenticeStatus.Live)));

            _context.Set(listOfApprentices);

            _context.Set(apprenticeDataHelper);

            _context.Set(new EditedApprenticeDataHelper(apprenticeDataHelper));

            _context.Set(apprenticeCourseDataHelper);

            _context.Set(new DataLockSqlHelper(_dbConfig, apprenticeDataHelper, apprenticeCourseDataHelper, _context.ScenarioInfo.Title));

        }

        private (ApprenticeDataHelper apprenticeDataHelper, ApprenticeCourseDataHelper apprenticeCourseDataHelper, bool additionalApprentice) SetProviderSpecificCourse(ApprenticeStatus apprenticeStatus)
        {
            if (_tags.Contains("portableflexijob"))
            {
                var larsCode = new RoatpV2SqlDataHelper(_dbConfig).GetPortableFlexiJobLarsCode(_context.GetPortableFlexiJobProviderConfig<PortableFlexiJobProviderConfig>()?.Ukprn);

                return (GetApprenticeDataHelper(), new(new RandomCourseDataHelper(_dbConfig, larsCode), apprenticeStatus), false);

            }
            else if (_tags.Contains("limitingstandards"))
            {
                var larsCode = new RoatpV2SqlDataHelper(_dbConfig).GetCourseProviderDeosNotOffer(_context.GetProviderConfig<ProviderConfig>()?.Ukprn);

                return (GetApprenticeDataHelper(), new(new RandomCourseDataHelper(_dbConfig, larsCode), apprenticeStatus), false);
            }
            else
            {
                return (GetApprenticeDataHelper(), GetApprenticeCourseDataHelper(apprenticeStatus), true);
            }
        }

        private ApprenticeDataHelper GetApprenticeDataHelper() => new(new ApprenticePPIDataHelper(_tags), _objectcontext, commitmentsdatahelper);

        private ApprenticeCourseDataHelper GetApprenticeCourseDataHelper(ApprenticeStatus apprenticeStatus) => new(new RandomCourseDataHelper(_dbConfig, _tags.Contains("selectstandardwithmultipleoptions")), apprenticeStatus);
    }
}