using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ProviderLogin.Service.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DynamicHomePageSteps
    {

        #region Helpers and Context
        private readonly MFEmployerStepsHelper _reservationStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ProviderConfig _config;
        private readonly ProviderLoginUser _login;
        #endregion

        public DynamicHomePageSteps(ScenarioContext context)
        {
            _reservationStepsHelper = new MFEmployerStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
            _config = context.GetProviderConfig<ProviderConfig>();
            _login = new ProviderLoginUser { Username = _config.UserId, Password = _config.Password, Ukprn = _config.Ukprn };
        }

        [Then(@"The nonlevyemployer continues to add an apprentice for reserved funding")]
        public void ThenTheNonLevyEmployerContinueToAddAnApprenticesForReservedFunding()
        {
            _reservationStepsHelper.GoToAddAnApprentices();
            _employerStepsHelper.DynamicHomePageStartToAddApprentice();
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
            _employerStepsHelper.GotoEmployerHomePage();
            _employerStepsHelper.DynamicHomePageFinishToAddApprenticeJourney();
        }
    }
}