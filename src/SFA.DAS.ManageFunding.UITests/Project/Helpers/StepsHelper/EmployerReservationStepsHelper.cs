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
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        private readonly RegistrationConfig _registrationConfig;
        private readonly EmployerPortalLoginHelper _loginHelper;

        internal EmployerReservationStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _registrationConfig = _context.GetRegistrationConfig<RegistrationConfig>();
            _loginHelper = new EmployerPortalLoginHelper(_context);
        }

        internal MakingChangesPage CreateReservation()
        {
             return new YourFundingReservationsHomePage(_context).OpenYourFundingReservations()
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

        internal void AddAnApprentice()
        {
            new MakingChangesPage(_context).AddApprentice();
        }
    }
}
