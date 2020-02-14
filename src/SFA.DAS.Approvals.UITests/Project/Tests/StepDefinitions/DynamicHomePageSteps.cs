using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    class DynamicHomePageSteps
    {
        private readonly ScenarioContext _context;
        private readonly MFEmployerStepsHelper _reservationStepsHelper;
        private SuccessfullyReservedFundingPage _successfullyReservedFundingPage;
        private readonly DynamicHomePage _dynamicHomePage;

        public DynamicHomePageSteps(ScenarioContext context)
        {
            _context = context;
            _reservationStepsHelper = new MFEmployerStepsHelper(context);
        }

        [When(@"the Employer reserves funding for an apprenticeship course from reserved panel")]
        public void WhenTheEmployerReservesFundingForAnApprenticeshipCourseFromReservedPanel()
        {
            _reservationStepsHelper.ClickToReserveFunding()
             
                .ClickYesRadioButton()
                .EnterSelectForACourseAndSubmit()
                .ClickSaveAndContinueButton()
                .ClickMonthRadioButton()
                .ClickSaveAndContinueButton()
                .ClickYesReserveFundingNowRadioButton()
                .ClickConfirmButton();


        }

        [Then(@"the new reserved funding panel is shown to employer on the homepage")]
        public void ThenTheNewReservedFundingPanelIsShownToEmployerOnTheHomepage()
        {

        }

        [Then(@"the new reserved funding panel is shown to employer on the homepage")]
        public void ThenTheNewReservedFundingPanelIsShownToEmployerOnTheHomepage()
        {
            
        }

    }
}
