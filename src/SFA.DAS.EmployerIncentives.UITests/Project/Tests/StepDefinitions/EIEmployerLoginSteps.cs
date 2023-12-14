using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class EIEmployerLoginSteps(ScenarioContext context)
    {
        [Given(@"the Employer logins using existing EI Levy Account to amend vrf")]
        public void GivenTheEmployerLoginsUsingExistingEILevyAccountToAmendVrf() => Login(context.GetUser<EIAmendVrfUser>());

        [Given(@"the Employer logins using existing EI Levy Account to add vrf")]
        public void GivenTheEmployerLoginsUsingExistingEILevyAccountToAddVrf() => ResetVrfDetails();

        [Given(@"the Employer logins using existing ei no application user")]
        public void GivenTheEmployerLoginsUsingExistingEiNoApplicationUser() => Login(context.GetUser<EINoApplicationUser>());

        [Given(@"the Employer logins using existing EI Levy Account to withdraw application")]
        public void GivenTheEmployerLoginsUsingExistingEILevyAccountToWithdrawApplication() => Login(context.GetUser<EIWithdrawLevyUser>());

        private HomePage Login(EasAccountUser loginUser) => new EmployerPortalLoginHelper(context).Login(loginUser, true);

        private HomePage ResetVrfDetails()
        {
            var homePage = Login(context.GetUser<EIAddVrfUser>());

            context.Get<EISqlHelper>().ResetVrfDetails(context.Get<ObjectContext>().GetDBAccountId());

            return homePage;
        }
    }
}