using NUnit.Framework;
using Polly;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.TestDataExport.Helper;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.FlexiPayments.E2ETests.Tests.StepDefinitions
{
    [Binding]
    public class FlexiPaymentsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public FlexiPaymentsSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [Given(@"the learner has training code ""([^""]*)"", date of birth ""([^""]*)"", start date ""([^""]*)"", end date ""([^""]*)"" and agreed price ""([^""]*)""")]
        public void GivenTheLearnerHasTrainingCodeDateOfBirthStartDateEndDateAndAgreedPrice(string trainingCode, DateTime dob, DateTime actulStartDate, DateTime plannedEndDate, string agreedPrice)
        {
            var apprenticeDatahelper = new ApprenticeDataHelper(new ApprenticePPIDataHelper(dob), _objectContext, _context.Get<CommitmentsSqlDataHelper>(), agreedPrice);

            var apprenticeCourseDataHelper = new ApprenticeCourseDataHelper(new RandomCourseDataHelper(), ApprenticeStatus.Live, actulStartDate, plannedEndDate, trainingCode);

            _context.Replace<ApprenticeDataHelper>(apprenticeDatahelper);
            _context.Replace<ApprenticeCourseDataHelper>(apprenticeCourseDataHelper);
        }
    }
}
