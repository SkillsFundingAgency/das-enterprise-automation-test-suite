using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers.BulkUpload;
using TechTalk.SpecFlow.Assist;
using Polly;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    internal class OverLappingTrainingDatesSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        protected readonly ApprenticeCourseDataHelper _apprenticeCourseDataHelper;
        private readonly EmployerPortalLoginHelper _employerLoginHelper;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;

        private readonly ProviderConfig _config;
        private readonly ProviderLoginUser _providerLogin;

        private ProviderApproveApprenticeDetailsPage _providerApproveApprenticeDetailsPage;
        private ProviderAddPersonalDetailsPage _providerAddApprenticeDetailsPage;

        private string uln;

        public OverLappingTrainingDatesSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _apprenticeCourseDataHelper = context.GetValue<ApprenticeCourseDataHelper>();
            _providerStepsHelper = new ProviderStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _employerLoginHelper = new EmployerPortalLoginHelper(context);
            _config = context.GetProviderConfig<ProviderConfig>();
            _providerStepsHelper = new ProviderStepsHelper(_context);
            _providerLogin = new ProviderLoginUser { UserId = _config.UserId, Password = _config.Password, Ukprn = _config.Ukprn };

            uln = RandomDataGenerator.GenerateRandomUln();
        }

        [Given(@"a live apprentice record exists with startdate of <(.*)> months and endDate of <\+(.*)> months from current date")]
        public void GivenALiveApprenticeRecordExistsWithStartdateOfMonthsAndEndDateOfMonthsFromCurrentDate(int startDateFromNow, int endDateFromNow)
        {
            _apprenticeCourseDataHelper.CourseStartDate = DateTime.Now.AddMonths(startDateFromNow);
            _apprenticeCourseDataHelper.SetLiveApprenticeEndDate(DateTime.Now.AddMonths(endDateFromNow));
            _dataHelper.UpdateCurrentApprenticUln(uln);

            _employerLoginHelper.Login(_context.GetUser<LevyUser>(), true);
            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(1);
            _employerStepsHelper.SetCohortReference(cohortReference);
            _providerStepsHelper.Approve();
        }

        [When(@"Provider tries to add a new apprentice using details from table below")]
        public void WhenProviderTriesToAddANewApprenticeUsingDetailsFromTableBelow(Table table)
        {
            // _providerStepsHelper.Login(_providerLogin);

            var apprenticeshipDetails = table.CreateSet<OltdApprenticeDetails>();

            foreach (var apprenticeship in apprenticeshipDetails)
            {
                _apprenticeCourseDataHelper.CourseStartDate = DateTime.Now.AddMonths(apprenticeship.NewStartDate);
                _apprenticeCourseDataHelper.SetLiveApprenticeEndDate(DateTime.Now.AddMonths(apprenticeship.NewEndDate));

                var uln = RandomDataGenerator.GenerateRandomUln();
                _dataHelper.UpdateCurrentApprenticUln(uln);

                _providerStepsHelper.AddApprentice(1).SubmitApprove();
            }
        }
    }
}