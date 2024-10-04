using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        private readonly ObjectContext _objectcontext = context.Get<ObjectContext>();
        private CommitmentsSqlDataHelper commitmentsdatahelper;
        private RoatpV2SqlDataHelper roatpV2SqlDataHelper;
        private readonly DbConfig _dbConfig = context.Get<DbConfig>();
        private readonly string[] _tags = context.ScenarioInfo.Tags;

        [BeforeScenario(Order = 31)]
        public void SetUpDbHelpers()
        {
            commitmentsdatahelper = new CommitmentsSqlDataHelper(_objectcontext, _dbConfig);

            context.Set(commitmentsdatahelper);

            context.Set(new RofjaaDbSqlHelper(_objectcontext, _dbConfig));

            context.Set(new AccountsDbSqlHelper(_objectcontext, _dbConfig));

            context.Set(roatpV2SqlDataHelper = new RoatpV2SqlDataHelper(_objectcontext, _dbConfig));

            context.Set(new PublicSectorReportingDataHelper());

            context.Set(new PublicSectorReportingSqlDataHelper(_objectcontext, _dbConfig));

            context.Set(new ManageFundingEmployerStepsHelper(context));
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            if (new TestDataSetUpConfigurationHelper(context).NoNeedToSetUpConfiguration()) return;

            var apprenticeStatus = _tags.Contains("liveapprentice") ? ApprenticeStatus.Live :
                                   _tags.Contains("onemonthbeforecurrentacademicyearstartdate") ? ApprenticeStatus.OneMonthBeforeCurrentAcademicYearStartDate :
                                   _tags.Contains("currentacademicyearstartdate") ? ApprenticeStatus.CurrentAcademicYearStartDate :
                                   _tags.Contains("waitingtostartapprentice") ? ApprenticeStatus.WaitingToStart :
                                   _tags.Contains("startdateisfewmonthsbeforenow") ? ApprenticeStatus.StartDateIsFewMonthsBeforeNow : ApprenticeStatus.Random;

            List<(ApprenticeDataHelper apprenticeDataHelper, ApprenticeCourseDataHelper apprenticeCourseDataHelper)> listOfApprentices = SetProviderSpecificCourse(apprenticeStatus);

            context.Set<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>(listOfApprentices);

            var apprenticeDataHelper = listOfApprentices.FirstOrDefault().apprenticeDataHelper;

            context.Set(apprenticeDataHelper);

            context.Set(apprenticeDataHelper.apprenticePPIDataHelper);

            context.Set(new EditedApprenticeDataHelper(apprenticeDataHelper));

            var apprenticeCourseDataHelper = listOfApprentices.FirstOrDefault().apprenticeCourseDataHelper;

            context.Set(apprenticeCourseDataHelper);

            context.Set(new DataLockSqlHelper(_objectcontext, _dbConfig, apprenticeDataHelper, apprenticeCourseDataHelper));

        }

        private List<(ApprenticeDataHelper apprenticeDataHelper, ApprenticeCourseDataHelper apprenticeCourseDataHelper)> SetProviderSpecificCourse(ApprenticeStatus apprenticeStatus)
        {
            var randomCourseDataHelper = new RandomCourseDataHelper(_objectcontext, _dbConfig, GetLarsCode(), _tags);

            List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentices = [];

            listOfApprentices.Add((GetApprenticeDataHelper(), GetApprenticeCourseDataHelper(randomCourseDataHelper, apprenticeStatus)));

            listOfApprentices.Add((GetApprenticeDataHelper(), GetApprenticeCourseDataHelper(randomCourseDataHelper.AvailableCourses, apprenticeStatus)));

            return listOfApprentices;
        }

        private ApprenticeDataHelper GetApprenticeDataHelper() => new(new ApprenticePPIDataHelper(_tags, context.Get<MailosaurUser>()), _objectcontext, commitmentsdatahelper);

        private ApprenticeCourseDataHelper GetApprenticeCourseDataHelper(RandomCourseDataHelper randomCourseDataHelper, ApprenticeStatus apprenticeStatus) => new(randomCourseDataHelper, apprenticeStatus, _tags);

        private ApprenticeCourseDataHelper GetApprenticeCourseDataHelper(List<CourseDetails> availableCourses, ApprenticeStatus apprenticeStatus) => new(new RandomCourseDataHelper(availableCourses), apprenticeStatus, _tags);

        private List<string> GetLarsCode()
        {
            return true switch
            {
                bool _ when _tags.Contains("portableflexijob") => roatpV2SqlDataHelper.GetPortableFlexiJobLarsCode(context.GetPortableFlexiJobProviderConfig<PortableFlexiJobProviderConfig>()?.Ukprn),
                bool _ when _tags.Contains("limitingstandards") => roatpV2SqlDataHelper.GetCoursesthatProviderDeosNotOffer(context.GetProviderConfig<ProviderConfig>()?.Ukprn),
                _ => roatpV2SqlDataHelper.GetCoursesThatProviderDeosOffer(context.GetProviderConfig<ProviderConfig>()?.Ukprn),
            };
        }
    }
}
