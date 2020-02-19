using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class DynamicHomePageSteps
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private MFEmployerStepsHelper _reservationStepsHelper;
        private DynamicHomePage _dynamicHomePage;
        #endregion

        public DynamicHomePageSteps(ScenarioContext context)
        {
            _context = context;
            _reservationStepsHelper = new MFEmployerStepsHelper(context);
            _dynamicHomePage = new DynamicHomePage(context);
        }

        [When(@"the Employer reserves funding for an apprenticeship course from reserved panel")]
        public void WhenTheEmployerReservesFundingForAnApprenticeshipCourseFromReservedPanel()
        {
            var doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage = _reservationStepsHelper.GoToReserveFundingFromHomePage();
            _reservationStepsHelper.CreateReservation(doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage);
        }

        [Then(@"the new reserved funding panel is shown to employer on the homepage")]
        public void ThenTheNewReservedFundingPanelIsShownToEmployerOnTheHomepage()
        {
            _reservationStepsHelper.GoToDynamicHomePage();
            _dynamicHomePage.VerifyReserveFundingPanel();
        }
        [Then(@"the employer continue to add an apprentices for reserved funding")]
        public void ThenTheEmployerContinueToAddAnApprenticesForReservedFunding()
        {
            _reservationStepsHelper.GoToAddAnApprentices();
        }

    }
}
