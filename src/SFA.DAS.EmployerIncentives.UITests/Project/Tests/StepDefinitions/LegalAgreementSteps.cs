using System;
using System.Collections.Generic;
using System.Text;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class LegalAgreementSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private QualificationQuestionPage _qualificationQuestionPage;

        public LegalAgreementSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [When(@"the Employer Initiates EI Application journey for version 4 legal agreement account")]

        public void TheEmployerInitiatesEIApplicationJourneyForSingleEntityAccount()
        {
            var homePageFinancesSection = new HomePageFinancesSection(_context);
            _qualificationQuestionPage = homePageFinancesSection.NavigateToEIHubPage().ClickApplyLinkOnEIHubPage().ClickStartNowButtonInEIApplyPage();
         }

        [Then(@"the Employer is shown the legal agreement shutter page")]
        public void ThenTheEmployerIsShownTheLegalAgreementShutterPage()
        {
            _qualificationQuestionPage
                .SelectYesAndContinueForEligibleApprenticesScenario()
                .SubmitApprentices()
                .ConfirmApprenticesForVersion4LegalAgreement()
                .ViewLegalAgreement();
        }

    }
}
