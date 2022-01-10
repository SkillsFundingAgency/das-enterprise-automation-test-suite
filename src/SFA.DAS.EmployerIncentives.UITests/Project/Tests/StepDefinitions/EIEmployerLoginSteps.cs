using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using System.Linq;
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

        [Given(@"the Employer logins using existing Unsigned NonLevy Account")]
        public void GivenTheEmployerLoginsUsingExistingUnsignedNonLevyAccount() => Login(_context.GetUser<EINonLevyUnsignedUser>());

        [Given(@"the Employer logins using existing EI Levy Account")]
        [When(@"the Employer logins using existing EI Levy Account")]
        public void TheEmployerLoginsUsingExistingEILevyAccount() => Login(_context.GetUser<EILevyUser>());

        [Given(@"the Employer logins using existing EI Levy Account to withdraw application")]
        public void GivenTheEmployerLoginsUsingExistingEILevyAccountToWithdrawApplication() => Login(_context.GetUser<EIWithdrawLevyUser>());

        [Given(@"the Employer logins using existing Version4AgreementUser Account")]
        public void GivenTheEmployerLoginsUsingExistingVersion4AgreementUserAccount() => SetOrgAndLogin(_context.GetUser<Version4AgreementUser>());

        [Given(@"the Employer logins using existing Version5AgreementUser Account")]
        public void GivenTheEmployerLoginsUsingExistingVersion5AgreementUserAccount() => SetOrgAndLogin(_context.GetUser<Version5AgreementUser>());

        [Given(@"the Employer logins using existing Version6AgreementUser Account")]
        public void GivenTheEmployerLoginsUsingExistingVersion6AgreementUserAccount() => SetOrgAndLogin(_context.GetUser<Version6AgreementUser>());

        [Given(@"the Employer logins using existing Version7AgreementUser Account")]
        public void GivenTheEmployerLoginsUsingExistingVersion7AgreementUserAccount() => Login(_context.GetUser<Version7AgreementUser>());

        private void SetOrgAndLogin(EasAccountUser loginUser)
        {
            _context.Get<ObjectContext>().UpdateOrganisationName(loginUser.OrganisationName);
            _employerPortalLoginHelper.Login(loginUser, true);
        }

        private HomePage Login(EasAccountUser user)
        {
            RemoveExistingApplications(user); 
            
            return _employerPortalLoginHelper.Login(user, true);
        }

        public void RemoveExistingApplications(EasAccountUser user)
        {
            if (_context.ScenarioInfo.Tags.Contains("deleteincentiveapplication"))
                _context.Get<EISqlHelper>().DeleteIncentiveApplication(_context.Get<RegistrationSqlDataHelper>().GetAccountIds(user.Username).accountId);
        }

    }
}
