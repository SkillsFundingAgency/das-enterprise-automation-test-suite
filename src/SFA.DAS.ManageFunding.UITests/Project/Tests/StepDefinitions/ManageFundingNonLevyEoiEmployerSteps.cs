using SFA.DAS.ManageFunding.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ManageFunding.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.ManageFunding.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManageFunding.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ManageFundingNonLevyEoiEmployerSteps
    {
        private MakingChangesPage _makingChangesPage;
        private readonly EmployerReservationStepsHelper _reservationHelper;

        public ManageFundingNonLevyEoiEmployerSteps(ScenarioContext context)
        {
            _reservationHelper = new EmployerReservationStepsHelper(context);
        }

        [Given(@"the Employer reserves funding for an apprenticeship course")]
        public void GivenTheEmployerReservesFundingForAnApprenticeshipCourse()
        {
            _makingChangesPage = _reservationHelper.CreateReservation();
        }

        [Then(@"the funding is successfully reserved")]
        public void ThenTheFundingIsSuccessfullyReserved()
        {
            _makingChangesPage.IsReserveFundingSuccessMessageUpdated();
        }

        [Given(@"the Employer has created a reservation")]
        public void GivenTheEmployerHasCreatedAReservation()
        {
            _makingChangesPage = _reservationHelper.CreateReservation();
        }

        [Then(@"the Employer can add the full apprentice details")]
        public void ThenTheEmployerCanAddTheFullApprenticeDetails()
        {
            _reservationHelper.AddAnApprentice(_makingChangesPage);
        }
    }
}
