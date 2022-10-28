using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class OverlappingTrainingDateRequestSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;

        public OverlappingTrainingDateRequestSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _providerStepsHelper = new ProviderStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _loginHelper = new EmployerPortalLoginHelper(context);
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
        }

        [Given(@"Employer and provider approve an apprentice")]
        public void GivenEmployerAndProviderApproveAnApprentice()
        {
            _loginHelper.Login(_context.GetUser<LevyUser>(), true);
            _objectContext.SetStartDate("01-06-2021");
            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(1);
            _employerStepsHelper.SetCohortReference(cohortReference);
            _providerStepsHelper.Approve();
        }

        [When(@"provider creates a draft apprentice which has an overlap")]
        public void WhenProviderCreatesADraftApprenticeWhichHasAnOverlap()
        {
            var reference = _objectContext.GetCohortReference();
            var uln =_commitmentsSqlDataHelper.GetApprenticeshipULN(reference);
            _objectContext.SetUlnForOLTD(uln);
            _objectContext.SetStartDate("01-10-2021");

            _providerStepsHelper.NavigateToProviderHomePage()
           .GotoSelectJourneyPage()
           .SelectAddManually()
           .SelectOptionCreateNewCohort()
           .ChooseAnEmployer("Levy")
           .ConfirmEmployer()
           .ProviderSelectsAStandard()
           .SubmitValidApprenticePersonalDetails()
           .SubmitApprenticeTrainingDetailsWithOverlappingTrainingDetails();
        }

        [When(@"provider selects all the information is correct")]
        public void WhenProviderSelectsAllTheInformationIsCorrect()
        {
            new ProviderOverlappingTrainingDateThereMayBeProblemPage(_context).SelectYesTheseDetailsAreCorrect();
        }

        [When(@"provider selects to contact the employer themselves")]
        public void WhenProviderSelectsToContactTheEmployerThemselves()
        {
            new ProviderAlreadyHasExistingApprenticeshipRecordPage(_context).SelectIWillAddApprenticesLater();
        }

        [Then(@"Vaidate not information is stored in database")]
        public void ThenVaidateNotInformationIsStoredInDatabase()
        {
            var uln = _objectContext.GetUlnForOLTD();
            var numberOfApprenticesWithUln = _commitmentsSqlDataHelper.GetApprenticeshipCountFromULN(uln);
            Assert.AreEqual(1, numberOfApprenticesWithUln);
        }
    }
}
