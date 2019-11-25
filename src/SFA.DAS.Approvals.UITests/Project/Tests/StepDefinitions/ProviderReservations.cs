using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderReservations
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ApprovalsConfig _config;
        private readonly ProviderLogin _login;
        private ProviderHomePage _providerHomePage;
		private ProviderAddApprenticeDetailsPage _providerAddApprenticeDetailsPage;
		private ProviderReviewYourCohortPage _providerReviewYourCohortPage;

        public ProviderReservations(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _loginHelper = new EmployerPortalLoginHelper(_context);
            _providerStepsHelper = new ProviderStepsHelper(_context);
            _employerStepsHelper = new EmployerStepsHelper(_context);
            _login = new ProviderLogin { Username = _config.AP_ProviderUserId, Password = _config.AP_ProviderPassword, Ukprn = _config.AP_ProviderUkprn };
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
