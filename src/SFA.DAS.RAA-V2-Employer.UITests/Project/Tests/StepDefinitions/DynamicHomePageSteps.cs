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
        private readonly ApprovalsStepsHelper _stepsHelper;
        private readonly MFEmployerStepsHelper _reservationStepsHelper;
        private SuccessfullyReservedFundingPage _successfullyReservedFundingPage;
        
        public DynamicHomePageSteps(ScenarioContext context)
        {
            _stepsHelper = new ApprovalsStepsHelper(context);
            _reservationStepsHelper = new MFEmployerStepsHelper(context);
        }

        [Given(@"the user reserves funding from the dynamic home page")]
        public void GivenTheUserReservesFundingFromTheDynamicHomePage()
        {
            _stepsHelper.CreatesAccountAndSignAnAgreement();
            _successfullyReservedFundingPage = _reservationStepsHelper.CreateReservation(_reservationStepsHelper.GoToReserveFundingFromHomePagePanel());
            _successfullyReservedFundingPage = _successfullyReservedFundingPage.VerifySucessMessage();
            _successfullyReservedFundingPage.GoToHomePage().VerifyReserveFundingPanel();
        }
    }
}
