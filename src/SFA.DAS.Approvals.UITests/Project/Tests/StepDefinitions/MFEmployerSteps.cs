using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MFEmployerSteps
    {
        private SuccessfullyReservedFundingPage _successfullyReservedFundingPage;
        private YourFundingReservationsPage _yourFundingReservationsPage;
        private readonly ScenarioContext _context;
        private readonly MFEmployerStepsHelper _reservationStepsHelper;

        public MFEmployerSteps(ScenarioContext context)
        {
            _context = context;
            _reservationStepsHelper = new MFEmployerStepsHelper(context);
        }

        [Then(@"The new reserved funding panel is shown to nonlevyemployer on the homepage")]
        public void ThenTheNewReservedFundingPanelIsShownToNonLevyEmployerOnTheHomepage() => _successfullyReservedFundingPage.GoToHomePage().VerifyReserveFundingPanel();

        [When(@"The NonLevyEmployer reserves funding for an apprenticeship course from reserved panel")]
        public void WhenTheNonLevyEmployerReservesFundingForAnApprenticeshipCourseFromReservedPanel() => _successfullyReservedFundingPage = _reservationStepsHelper.CreateReservation(_reservationStepsHelper.GoToReserveFundingFromHomePagePanel());

        [When(@"the Employer reserves funding for an apprenticeship course")]
        public void WhenTheEmployerReservesFundingForAnApprenticeshipCourse() => _successfullyReservedFundingPage = _reservationStepsHelper.CreateReservation(_reservationStepsHelper.GoToReserveFunding());

        [Then(@"The funding is successfully reserved")]
        public void ThenTheFundingIsSuccessfullyReserved() => _successfullyReservedFundingPage.VerifySucessMessage();
        
        [When(@"the Employer deletes all unused funding for an apprenticeship course")]
        public void WhenTheEmployerDeletesAllUnusedFundingForAnApprenticeshipCourse() => _yourFundingReservationsPage = _reservationStepsHelper.DeleteAllUnusedFunding();

        [Then(@"all the unused funding are successfully deleted")]
        public void ThenAllTheUnusedFundingAreSuccessfullyDeleted() => Assert.IsFalse(_yourFundingReservationsPage.CheckIfDeleteLinkIsPresent(), $"Delete link is present in the Manage Reservations page");
    }
}