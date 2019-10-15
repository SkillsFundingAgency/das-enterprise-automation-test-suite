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

        private readonly EmployerPortalLoginHelper _loginHelper;

        public ProviderReservations(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _loginHelper = new EmployerPortalLoginHelper(_context);
        }

        [Given(@"An Employer has given create reservation permission to a provider")]
        public void GivenAnEmployerHasGivenCreateReservationPermissionToAProvider()
        {
            var homePage = _loginHelper.Login(_context.GetUser<EoiUser>());

            homePage.GoToYourOrganisationsAndAgreementsPage()
                .SetAgreementId();
        }

        [When(@"Provider login and makes a reservation")]
        public void WhenProviderLoginAndMakesAReservation()
        {
            throw new PendingStepException();
        }

        [Then(@"Funding is reserved successfully")]
        public void ThenFundingIsReservedSuccessfully()
        {
            throw new PendingStepException();
        }



    }
}
