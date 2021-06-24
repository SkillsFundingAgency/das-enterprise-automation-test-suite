using System;
using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using NUnit.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Transfers.UITests.Project.Helpers;

namespace SFA.DAS.Transfers.UITests.Project.Tests.StepDefinitions
{


    [Binding]
    public class LevyTransfersSteps
    {
        private readonly ScenarioContext _context;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly ObjectContext _objectContext;
        private readonly TransfersEmployerStepsHelper _employerStepsHelper;
        private readonly TransfersProviderStepsHelper _providerStepsHelper;
        private readonly TransfersUser _transfersUser;
        private readonly LevyUser _levyUser;
        private HomePage _homePage;

        private readonly string _sender;
        private readonly string _receiver;

        public LevyTransfersSteps(ScenarioContext context)
        {
            _context = context;
            _transfersUser = context.GetUser<TransfersUser>();
            _levyUser = context.GetUser<LevyUser>();
            _sender = _transfersUser.OrganisationName;
            _receiver = _transfersUser.SecondOrganisationName;
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context, _transfersUser);
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _employerStepsHelper = new TransfersEmployerStepsHelper(context);
            _providerStepsHelper = new TransfersProviderStepsHelper(context);
            _objectContext = context.Get<ObjectContext>();


        }

        [Given(@"I am logged in as a Levy Payer")]
        public void GivenIAmLoggedInAsALevyPayer() => _homePage = _employerPortalLoginHelper.Login(_levyUser, true);
        //_context.GetUser<LevyUser>()

        [Given(@"I am on the Manage Apprenticeships Page")]
        public void GivenIAmOnTheManageApprenticeshipsPage()
        {
            Console.WriteLine("Test OK");
        }

        [When(@"I click on view my transfers")]
        public void WhenIClickOnViewMyTransfers()
        {
            Console.WriteLine("Test OK");
        }

        [Then(@"I am taken to the View Transfers Page")]
        public void ThenIAmTakenToTheViewTransfersPage()
        {
            Console.WriteLine("Test OK");
        }
    }
}


