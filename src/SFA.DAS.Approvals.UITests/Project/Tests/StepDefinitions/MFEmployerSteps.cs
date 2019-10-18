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
        private MakingChangesPage _makingChangesPage;
        private readonly ScenarioContext _context;
        private readonly MFEmployerStepsHelper _reservationStepsHelper;

        public MFEmployerSteps(ScenarioContext context)
        {
            _context = context;
            _reservationStepsHelper = new MFEmployerStepsHelper(context);
        }

        [When(@"the Employer reserves funding for an apprenticeship course")]
        public void WhenTheEmployerReservesFundingForAnApprenticeshipCourse()
        {
            var doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage = _reservationStepsHelper.GoToReserveFunding();

            _makingChangesPage = _reservationStepsHelper.CreateReservation(doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage);
        }

        [Then(@"the funding is successfully reserved")]
        public void ThenTheFundingIsSuccessfullyReserved()
        {
            _makingChangesPage = _makingChangesPage.VerifySucessMessage();
        }

        [Then(@"the funding can be deleted")]
        public void ThenTheFundingCanBeDeleted()
        {
            _makingChangesPage.GoToHomePage();

            new YourFundingReservationsHomePage(_context)
                .OpenYourFundingReservations()
                .DeleteTheReservedFunding()
                .YesDeleteThisReservation();
        }
    }
}
