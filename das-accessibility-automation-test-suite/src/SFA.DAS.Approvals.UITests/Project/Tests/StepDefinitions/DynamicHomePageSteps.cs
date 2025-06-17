using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DynamicHomePageSteps
    {
        #region Helpers and Context
        private readonly ManageFundingEmployerStepsHelper _reservationStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;
        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper;
        private readonly ProviderConfig _config;
        private readonly ProviderLoginUser _login;
        #endregion

        public DynamicHomePageSteps(ScenarioContext context)
        {
            _reservationStepsHelper = new ManageFundingEmployerStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);
            _config = context.GetProviderConfig<ProviderConfig>();
            _apprenticeHomePageStepsHelper = new ApprenticeHomePageStepsHelper(context);
            _login = new ProviderLoginUser { Username = _config.Username, Password = _config.Password, Ukprn = _config.Ukprn };
        }

        [Then(@"The nonlevyemployer continues to add an apprentice for reserved funding")]
        public void ThenTheNonLevyEmployerContinueToAddAnApprenticesForReservedFunding()
        {
            var addAnApprenitcePage = _reservationStepsHelper.GoToAddAnApprentices();

            EmployerStepsHelper.DynamicHomePageStartToAddApprentice(addAnApprenitcePage);
        }

        [Then(@"The TrainingProvider approves apprentice by adding further details")]
        public void ThenTheTrainingProviderApprovesApprenticeByAddingFurtherDetails()
        {
            var approvalsProviderHomePage = _providerCommonStepsHelper.GoToProviderHomePage(_login, true);

            approvalsProviderHomePage.GoToApprenticeRequestsPage().GoToCohortsToReviewPage().SelectViewCurrentCohortDetails().SelectEditApprentice(0).EnterUlnAndSave(true).SubmitApprove();
        }

        [Then(@"The NonLevyEmployer Reviews and Approves the apprentice")]
        public void ThenTheNonLevyEmployerReviewsandApprovesTheApprentice()
        {
            _apprenticeHomePageStepsHelper.GotoEmployerHomePage();

            _employerStepsHelper.DynamicHomePageFinishToAddApprenticeJourney();
        }
    }
}