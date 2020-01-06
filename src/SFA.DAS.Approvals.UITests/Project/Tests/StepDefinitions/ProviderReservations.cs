using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.ProviderLogin.Service;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderReservations
    {
        private readonly ScenarioContext _context;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly ProviderConfig _config;
        private readonly ProviderLoginUser _login;
		private ProviderAddApprenticeDetailsPage _providerAddApprenticeDetailsPage;
		private ProviderReviewYourCohortPage _providerReviewYourCohortPage;

        public ProviderReservations(ScenarioContext context)
        {
            _context = context;
            _config = context.GetProviderConfig<ProviderConfig>();
            _loginHelper = new EmployerPortalLoginHelper(_context);
            _providerStepsHelper = new ProviderStepsHelper(_context);
            _login = new ProviderLoginUser { Username = _config.UserId, Password = _config.Password, Ukprn = _config.Ukprn };
        }

        [Given(@"An Employer has given create reservation permission to a provider")]
        public void GivenAnEmployerHasGivenCreateReservationPermissionToAProvider()
        {
            var homePage = _loginHelper.Login(_context.GetUser<EoiUser>());

            homePage.GoToYourOrganisationsAndAgreementsPage()
                .SetAgreementId();
        }

        [When(@"Provider creates a reservation and adds (.*) apprentices and approves the cohort and sends to Employer to approve")]
        public void WhenProviderCreatesAReservationAndAddsApprenticeSAndApprovesTheCohortAndSendsToEmployerToApprove(int numberOfApprentices)
        {
			_providerAddApprenticeDetailsPage = _providerStepsHelper.ProviderMakeReservation(_login);

			_providerReviewYourCohortPage = _providerStepsHelper.AddApprentice(_providerAddApprenticeDetailsPage, numberOfApprentices);

            _providerReviewYourCohortPage.SelectSaveAndContinue()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }

        [Then(@"Provider can make a reservation")]
        public void ThenProviderCanMakeAReservation()
        {
			_providerAddApprenticeDetailsPage = _providerStepsHelper.ProviderMakeReservation(_login);
        }

        [Then(@"Provider can add an apprentice")]
        public void ThenProviderCanAddAnApprentice()
        {
            _providerReviewYourCohortPage = _providerStepsHelper.AddApprentice(_providerAddApprenticeDetailsPage, 1);
        }

        [Then(@"Provider can edit an apprentice")]
        public void ThenProviderCanEditAnApprentice()
        {
            _providerReviewYourCohortPage = _providerStepsHelper.EditApprentice(_providerReviewYourCohortPage);
        }

        [Then(@"Provider can delete an apprentice")]
        public void ThenProviderCanDeleteAnApprentice()
        {
            _providerReviewYourCohortPage = _providerStepsHelper.DeleteApprentice(_providerReviewYourCohortPage);
        }

        [Then(@"Provider can delete the funding")]
        public void ThenProvidercanDeleteTheFunding()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToManageYourFunding()
                .DeleteTheReservedFunding()
                .YesDeleteThisReservation();
        }
    }
}
