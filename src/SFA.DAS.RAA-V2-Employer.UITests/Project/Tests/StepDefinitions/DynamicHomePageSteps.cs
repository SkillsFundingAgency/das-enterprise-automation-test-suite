using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DynamicHomePageSteps
    {
        private readonly ScenarioContext _context;
        private readonly ApprovalsStepsHelper _stepsHelper;
        private readonly RegistrationDataHelper _registrationDataHelper;
        private readonly MFEmployerStepsHelper _reservationStepsHelper;
        private SuccessfullyReservedFundingPage _successfullyReservedFundingPage;
        private readonly ObjectContext _objectContext;
        public DynamicHomePageSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _stepsHelper = new ApprovalsStepsHelper(context);
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            _reservationStepsHelper = new MFEmployerStepsHelper(context);

        }

        [Given(@"the user reserves funding from the dynamic home page")]
        public void GivenTheUserReservesFundingFromTheDynamicHomePage()
        {
            _stepsHelper.CreatesAccountAndSignAnAgreement();
            _successfullyReservedFundingPage = _reservationStepsHelper.CreateReservation(_reservationStepsHelper.GoToReserveFundingFromHomePagePanel());
            _successfullyReservedFundingPage.VerifySucessMessage();
            _successfullyReservedFundingPage.GoToHomePage().VerifyReserveFundingPanel();
        }

        [When(@"the Employer reserves funding for an apprenticeship course from reserved home page panel")]
        public void WhenTheEmployerReservesFundingForAnApprenticeshipCourseFromReservedHomePagePanel()
        {
            _successfullyReservedFundingPage = _reservationStepsHelper.CreateReservation(_reservationStepsHelper.GoToReserveFundingFromHomePagePanel());
        }

        [Then(@"the funding is reserved successfully")]
        public void ThenTheFundingIsReservedSuccessfully()
        {
            _successfullyReservedFundingPage.VerifySucessMessage();
        }

        [Then(@"the new reserved funding panel is shown to employer on the dynamic homepage")]
        public void ThenTheNewReservedFundingPanelIsShownToEmployerOnTheDynamicHomepage()
        {
            _successfullyReservedFundingPage.GoToHomePage().VerifyReserveFundingPanel();
        }
    }
}
