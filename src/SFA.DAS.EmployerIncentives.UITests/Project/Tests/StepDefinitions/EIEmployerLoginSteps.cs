using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class EIEmployerLoginSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;

        public EIEmployerLoginSteps(ScenarioContext context)
        {
            _context = context;
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
        }

        [Given(@"the Employer logins using existing EI Levy Account")]
        [When(@"the Employer logins using existing EI Levy Account")]
        public void GivenTheEmployerLoginsUsingExistingEILevyAccount() => _employerPortalLoginHelper.Login(_context.GetUser<EILevyUser>(), true);

        [Given(@"the Employer logins using existing Version4AgreementUser Account")]
        public void GivenTheEmployerLoginsUsingExistingVersion4AgreementUserAccount() => SetOrgAndLogin(_context.GetUser<Version4AgreementUser>());

        [Given(@"the Employer logins using existing Version5AgreementUser Account")]
        public void GivenTheEmployerLoginsUsingExistingVersion5AgreementUserAccount() => SetOrgAndLogin(_context.GetUser<Version5AgreementUser>());

        private void SetOrgAndLogin(LoginUserWithSpecificOrg loginUser)
        {
            _context.Get<ObjectContext>().UpdateOrganisationName(loginUser.OrganisationName);
            _employerPortalLoginHelper.Login(loginUser, true);
        }
    }
}
