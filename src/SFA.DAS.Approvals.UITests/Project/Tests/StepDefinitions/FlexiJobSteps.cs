using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public  class FlexiJobSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private HomePage _homePage;

        public FlexiJobSteps (ScenarioContext context)
        {
            _context = context;
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
        }

        [Given(@"an employer who is on Flexi-job agency register logins using exisiting Levy Account")]
        public void GivenAnEmployerWhoIsOnFlexi_JobAgencyRegisterLoginsUsingExisitingLevyAccount() => _homePage = _employerPortalLoginHelper.Login(_context.GetUser<FlexiJobUser>(), true);

        [Given(@"employer selects Flexi-job agency radio button on Select Delivery Model screen")]
        public void GivenEmployerSelectsFlexi_JobAgencyRadioButtonOnSelectDeliveryModelScreen()
        {
            _employerStepsHelper.FlexiEmployerAddsApprenticeAndSendsToProvider();
        }




    }
}
