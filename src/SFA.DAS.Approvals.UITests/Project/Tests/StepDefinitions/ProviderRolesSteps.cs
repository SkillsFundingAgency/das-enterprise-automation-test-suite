using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Login.Service.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service;


namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRolesSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;

        public ProviderRolesSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(context);
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(context);
        }

        [Given(@"the provider logs in as '(.*)'")]
        public void GivenTheProviderLogsInAs(string User)
        {

            ProviderLoginUser login = new ProviderLoginUser();

            if (User.Equals("Contributor"))
            {
                login.Username = _context.GetUser<ProviderContributorUser>().Username;
                login.Password = _context.GetUser<ProviderContributorUser>().Password;
            }
            else if (User.Equals("Super Contributor"))
            {
                login.Username = _context.GetUser<ProviderSuperContributorUser>().Username;
                login.Password = _context.GetUser<ProviderSuperContributorUser>().Password;
            }
            else if (User.Equals("Account Owner"))
            {
                login.Username = _context.GetUser<ProviderAccountOwnerUser>().Username;
                login.Password = _context.GetUser<ProviderAccountOwnerUser>().Password;
            }

            _providerHomePageStepsHelper.GoToProviderHomePage1(login,false);
        }

        [Then(@"the user can create reservation")]
        public void ThenTheUserCanCreateReservation()
        {
            _providerStepsHelper.MakeReservation();                  
        }

        [Given(@"the user can delete reservation")]
        public void GivenTheUserCanDeleteReservation()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToManageYourFunding()
                .DeleteTheReservedFunding()
                .YesDeleteThisReservation();
        }

        [Then(@"the user can add an apprentice")]
        public void ThenTheUserCanAddAnApprentice()
        {
        }

        [Given(@"the provider logs in as a viewer")]
        public void GivenTheProviderLogsinAsAViewer()
        {
            ProviderLoginUser login = new ProviderLoginUser();
            _providerHomePageStepsHelper.LoginAsViewer(login);
        }

        [Then(@"the user can not reserve the funding")]
        public void ThenTheUserCanNotReserveTheFunding()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .ClickToReserveFunding()
                .GoBackToTheServiceHomePage();
        }

 
        [Then(@"the user can not delete the reservation")]
        public void ThenTheUserCanNotDeleteTheReservation()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToManageYourFunding()
                .ClickToDeleteReservation()
                .GoBackToTheServiceHomePage();
        }

        [Then(@"the user can not add an apprentice")]
        public void ThenTheUserCanNotAddAnApprentice()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToManageYourFunding()
                .ClickToAddAnApprenticeForaReservation()
                .GoBackToTheServiceHomePage();
        }

    }
}
