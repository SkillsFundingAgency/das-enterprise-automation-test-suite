using NUnit.Framework;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.EmployerDetails;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.StepDefinitions
{
    [Binding]
    public class EmployerSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerHelper _employerHelper;

        public EmployerSteps(ScenarioContext context) 
        {   _context = context;
            _employerHelper = new EmployerHelper(context);
        }     

        [Given(@"the Employer Completes Employer details form successfully")]
        public void GivenTheEmployerCompletesEmployerDetailsFormSuccessfully() => _employerHelper.CompleteEmployerForm_HappyPath(new MainLandingPage(_context));

        [Given(@"The Employer do not complete all the mandatory fields")]
        public void GivenTheEmployerDoNotCompleteAllTheMandatoryFields() => _employerHelper.ContinueWithoutAllMandatoryFieldsCompletedForEmployerForm(new MainLandingPage(_context));

        [Then(@"Errors displayed for not completing the mandatory information on Employer Form")]
        public void ThenErrorsDisplayedForNotCompletingTheMandatoryInformationOnEmployerForm()
        {
            List<string> expectedEmployerErrorMessages = new List<string>
            {
               "Enter your organisation's name",
               "Enter your email address",
               "Select the locations where you're interested in taking on an apprentice",
               "Select the type of apprenticeships you're interested in",
               "Enter more detail about the apprenticeship",
               "Enter your first name",
               "Enter your last name",
               "Enter your phone number",
               "Select yes if we can contact you about taking part in a feedback session",
            };
            EmployerDetailsPage _employerDetailsPage = new EmployerDetailsPage(_context);
            var actualMessages = _employerDetailsPage.GetErrorMessages();

            Assert.IsTrue(expectedEmployerErrorMessages.All(x => actualMessages.Contains(x)), $"Not all employer error messages are found");
        }
        [Given(@"the employer lands on check your answers employer details page")]
        public void GivenTheEmployerLandsOnCheckYourAnswersEmployerDetailsPage() => _employerHelper.NavigateToEmployerDetailsPage(new MainLandingPage(_context));
        
        [Given(@"the employer can access all the change links")]
        public void GivenTheEmployerCanAccessAllTheChangeLinks() => _employerHelper.VerifyEmployerChangeLinks(new Employer_CheckYourAnswersPage(_context));

        [When(@"the employer updates the contact details")]
        public void WhenTheEmployerUpdatesTheContactDetails() => _employerHelper.ClickChangeAndUpdateEmployerContactDetails(new Employer_CheckYourAnswersPage(_context));

        [Then(@"changes made are reflected on confirm employer details page")]
        public void ThenChangesMadeAreReflectedOnConfirmEmployerDetailsPage() => _employerHelper.VerifyUpdatedContactDetails(new Employer_CheckYourAnswersPage(_context));

    }
}
