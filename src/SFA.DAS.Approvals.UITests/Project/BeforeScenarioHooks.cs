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


            List<(ApprenticeDataHelper apprenticeDataHelper, ApprenticeCourseDataHelper apprenticeCourseDataHelper)> listOfApprentices = SetProviderSpecificCourse(apprenticeStatus);

            _context.Set(listOfApprentices);

            var apprenticeDataHelper = listOfApprentices.FirstOrDefault().apprenticeDataHelper;

            _context.Set(apprenticeDataHelper);

            _context.Set(new EditedApprenticeDataHelper(apprenticeDataHelper));

            var apprenticeCourseDataHelper = listOfApprentices.FirstOrDefault().apprenticeCourseDataHelper;

            _context.Set(apprenticeCourseDataHelper);

            _context.Set(new DataLockSqlHelper(_dbConfig, apprenticeDataHelper, apprenticeCourseDataHelper, _context.ScenarioInfo.Title));

        }

        private List<(ApprenticeDataHelper apprenticeDataHelper, ApprenticeCourseDataHelper apprenticeCourseDataHelper)> SetProviderSpecificCourse(ApprenticeStatus apprenticeStatus)
        {
            List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentices = new();

            var roatpV2SqlDataHelper = new RoatpV2SqlDataHelper(_dbConfig);

            if (_tags.Contains("portableflexijob"))
            {
                var larsCode = roatpV2SqlDataHelper.GetPortableFlexiJobLarsCode(_context.GetPortableFlexiJobProviderConfig<PortableFlexiJobProviderConfig>()?.Ukprn);

                listOfApprentices.Add((GetApprenticeDataHelper(), GetApprenticeCourseDataHelper(larsCode, apprenticeStatus)));

            }
            else if (_tags.Contains("limitingstandards"))
            {
                var larsCode = roatpV2SqlDataHelper.GetCoursesthatProviderDeosNotOffer(_context.GetProviderConfig<ProviderConfig>()?.Ukprn);

                listOfApprentices.Add((GetApprenticeDataHelper(), GetApprenticeCourseDataHelper(larsCode, apprenticeStatus)));
            }
            else
            {
                var larsCode = roatpV2SqlDataHelper.GetCoursesThatProviderDeosOffer(_context.GetProviderConfig<ProviderConfig>()?.Ukprn);

                listOfApprentices.Add((GetApprenticeDataHelper(), GetApprenticeCourseDataHelper(larsCode, apprenticeStatus)));

                listOfApprentices.Add((GetApprenticeDataHelper(), GetApprenticeCourseDataHelper(larsCode, apprenticeStatus)));
            }

            return listOfApprentices;
        }

        private ApprenticeDataHelper GetApprenticeDataHelper() => new(new ApprenticePPIDataHelper(_tags), _objectcontext, commitmentsdatahelper);

        private ApprenticeCourseDataHelper GetApprenticeCourseDataHelper(List<string> larsCode, ApprenticeStatus apprenticeStatus) => new(new RandomCourseDataHelper(_dbConfig, larsCode, _tags.Contains("selectstandardwithmultipleoptions")), apprenticeStatus);
    }
}