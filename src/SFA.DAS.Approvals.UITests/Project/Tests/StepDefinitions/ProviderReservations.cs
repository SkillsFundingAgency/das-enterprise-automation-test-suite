using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
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
        private readonly ProviderPermissionsConfig _config;
        private readonly ProviderLogin _login;

        public ProviderReservations(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetProviderPermissionConfig<ProviderPermissionsConfig>();
            _loginHelper = new EmployerPortalLoginHelper(_context);
            _providerStepsHelper = new ProviderStepsHelper(_context);
            _login = new ProviderLogin { Username = _config.AP_ProviderUserId, Password = _config.AP_ProviderPassword, Ukprn = _config.AP_ProviderUkprn };
        }

        [Given(@"An Employer has given create reservation permission to a provider")]
        public void GivenAnEmployerHasGivenCreateReservationPermissionToAProvider()
        {
            var homePage = _loginHelper.Login(_context.GetUser<EoiUser>());

            homePage.GoToYourOrganisationsAndAgreementsPage()
                .SetAgreementId();
        }

        [Then(@"Provider can make a reservation")]
        public void ThenProviderCanMakeAReservation()
        {
            _providerStepsHelper.GoToProviderHomePage(_login)
                .GoToProviderGetFunding()
                .StartReservedFunding()
                .ChooseAnEmployerNonLevyEOI()
                .ConfirmNonLevyEmployer()
                .AddTrainingCourseAndDate()
                .ConfirmReserveFunding()
                .VerifySucessMessage()
                .GoToHomePage();
        }
    }
}
