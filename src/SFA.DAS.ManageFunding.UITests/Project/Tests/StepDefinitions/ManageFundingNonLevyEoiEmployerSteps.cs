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
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        private MakingChangesPage _sucessMessage;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly EmployerReservationStepsHelper _reservationHelper;

        public ManageFundingNonLevyEoiEmployerSteps(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _context = context;
            _loginHelper = new EmployerPortalLoginHelper(context);
            _reservationHelper = new EmployerReservationStepsHelper(context);
        }

        [When(@"the Employer reserves funding for an apprenticeship course")]
        public void TheEmployerReservesFundingForAnApprenticeshipCourse()
        {
            _reservationHelper.CreateReservation();
        }

        [Then(@"Verify funding is successfully reserved")]
        public void VerifyFundingIsSuccessfullyReserved()
        {
            _sucessMessage.IsReserveFundingSuccessMessageUpdated();
        }


        [Given(@"the Employer has created a reservation")]
        public void GivenTheEmployerHasCreatedAReservation()
        {
            _loginHelper.Login(_context.GetUser<EoiUser>(), false);
            _reservationHelper.CreateReservation();
        }
    }
}
