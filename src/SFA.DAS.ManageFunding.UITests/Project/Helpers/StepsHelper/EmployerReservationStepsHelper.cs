using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ManageFunding.UITests.Project.Tests.Pages;
using SFA.DAS.ManageFunding.UITests.Project.Tests.Pages.Employer;

namespace SFA.DAS.ManageFunding.UITests.Project.Helpers.StepsHelper
{
    internal class EmployerReservationStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _loginHelper;
        
        internal EmployerReservationStepsHelper(ScenarioContext context)
        {
            _context = context;
            _loginHelper = new EmployerPortalLoginHelper(_context);
        }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage LoginAndReserveFunding()
        {
            _loginHelper.Login(_context.GetUser<EoiUser>(), false);

            return new YourFundingReservationsHomePage(_context).OpenYourFundingReservations()
                .ClickReserveMoreFundingLink()
                .ClickReserveFundingButton();
        }

        public MakingChangesPage CreateReservation()
        {
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context)
                .ClickYesRadioButton()
                .EnterSelectForACourseAndSubmit()
                .ClickSaveAndContinueButton()
                .ClickMonthRadioButton()
                .ClickSaveAndContinueButton()
                .ClickYesReserveFundingNowRadioButton()
                .ClickConfirmButton();
        }

        internal void AddAnApprentice(MakingChangesPage makingChangesPage)
        {
            makingChangesPage.AddApprentice();
        }
    }
}
