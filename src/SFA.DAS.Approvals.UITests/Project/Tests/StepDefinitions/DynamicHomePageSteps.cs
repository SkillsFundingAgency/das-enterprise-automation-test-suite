using SFA.DAS.ProviderLogin.Service.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DynamicHomePageSteps
    {
        #region Helpers and Context
        private readonly ManageFundingEmployerStepsHelper _reservationStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper;
        private readonly ProviderConfig _config;
        private readonly ProviderLoginUser _login;
        #endregion

        public DynamicHomePageSteps(ScenarioContext context)
        {
            _reservationStepsHelper = new ManageFundingEmployerStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
            _config = context.GetProviderConfig<ProviderConfig>();
            _apprenticeHomePageStepsHelper = new ApprenticeHomePageStepsHelper(context);
            _login = new ProviderLoginUser { UserId = _config.UserId, Password = _config.Password, Ukprn = _config.Ukprn };
        }

        [Then(@"The nonlevyemployer continues to add an apprentice for reserved funding")]
        public void ThenTheNonLevyEmployerContinueToAddAnApprenticesForReservedFunding()
        {
            var addAnApprenitcePage = _reservationStepsHelper.GoToAddAnApprentices();

            _employerStepsHelper.DynamicHomePageStartToAddApprentice(addAnApprenitcePage);
        }

        [Then(@"The TrainingProvider approves apprentice by adding further details")]
        public void ThenTheTrainingProviderApprovesApprenticeByAddingFurtherDetails()
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(_login, true);

            _providerStepsHelper.DynamicHomePageProviderApproval();
        }

        [Then(@"The NonLevyEmployer Reviews and Approves the apprentice")]
        public void ThenTheNonLevyEmployerReviewsandApprovesTheApprentice()
        {
            _apprenticeHomePageStepsHelper.GotoEmployerHomePage();

            _employerStepsHelper.DynamicHomePageFinishToAddApprenticeJourney();
        }
    }
}