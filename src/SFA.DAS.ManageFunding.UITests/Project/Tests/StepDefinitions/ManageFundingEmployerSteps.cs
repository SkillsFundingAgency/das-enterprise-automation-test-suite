using SFA.DAS.ManageFunding.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.ManageFunding.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManageFunding.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ManageFundingEmployerSteps
    {
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        private MakingChangesPage _sucessMessage;

        public ManageFundingEmployerSteps(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _context = context;
        }

        [When(@"the Employer reserves funding for an apprenticeship course")]
        public void TheEmployerReservesFundingForAnApprenticeshipCourse()
        {
            _sucessMessage = new YourFundingReservationsHomePage(_context).OpenYourFundingReservations()
                .ClickReserveMoreFundingLink()
                .ClickReserveFundingButton()
                .ClickYesRadioButton()
                .EnterSelectForACourseAndSubmit()
                .ClickSaveAndContinueButton()
                .ClickMonthRadioButton()
                .ClickSaveAndContinueButton()
                .ClickYesReserveFundingNowRadioButton()
                .ClickConfirmButton();
        }

        [Then(@"Verify funding is successfully reserved")]
        public void VerifyFundingIsSuccessfullyReserved()
        {
            _sucessMessage.IsReserveFundingSuccessMessageUpdated();
        }
    }
}
