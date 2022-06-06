using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerWithMultipleAccountsUserSteps
    {
        private readonly ObjectContext _objectContext;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly EmployerWithMultipleAccountsUser _employerWithMultipleAccountsUser;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;

        public EmployerWithMultipleAccountsUserSteps(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _employerStepsHelper = new EmployerStepsHelper(context);
            _employerWithMultipleAccountsUser = context.GetUser<EmployerWithMultipleAccountsUser>();
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context, _employerWithMultipleAccountsUser);
        }

        [Given(@"the Employer1 logins using existing Levy Account")]
        public void ThenEmployer1LogIns() => _multipleAccountsLoginHelper.Login(_employerWithMultipleAccountsUser, true);

        [Given(@"the Employer2 logins")]
        public void ThenEmployer2LogIns()
        {
            _objectContext.UpdateOrganisationName(_employerWithMultipleAccountsUser.SecondOrganisationName);
            _employerStepsHelper.GoToEmployerApprenticesHomePage();
        }

        [Given(@"the Employer3 logins")]
        [Then(@"the Employer3 logins")]
        public void ThenEmployer3LogIns()
        {
            _objectContext.UpdateOrganisationName(_employerWithMultipleAccountsUser.ThirdOrganisationName);
            _employerStepsHelper.GoToEmployerApprenticesHomePage();
        }
    }
}
