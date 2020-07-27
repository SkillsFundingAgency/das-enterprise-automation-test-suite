using NUnit.Framework;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.Apprentice;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.StepDefinitions
{
    [Binding]
    public class ApprenticeSteps
    {
        private readonly ScenarioContext _context;
        private readonly ApprenticeHelper _apprenticeHelper;
        private readonly ApprenticeRedundancyBasePage _apprenticeRedundancyBasePage;

        public ApprenticeSteps(ScenarioContext context)
        {
            _context = context;
            _apprenticeHelper = new ApprenticeHelper(context);
        }

        [Given(@"the Apprentice Completes Apprentice details form successfully")]
        public void GivenTheApprenticeCompletesApprenticeDetailsFormSuccessfully() => _apprenticeHelper.CompleteApprenticeForm_HappyPath(new MainLandingPage(_context));

        [Given(@"The Apprentice do not complete all the mandatory fields")]
        public void GivenTheApprenticeDoNotCompleteAllTheMandatoryFields() => _apprenticeHelper.ContinueWithoutAllMandatoryFieldsCompletedForApprenticeForm(new MainLandingPage(_context));

        [Then(@"Errors displayed for not completing the mandatory information on Apprentice Form")]
        public void ThenErrorsDisplayedForNotCompletingTheMandatoryInformationOnApprenticeForm()
        {
            List<string> expectedApprenticeErrorMessages = new List<string>
            {
                "Enter your first name",
                "Enter your last name",
                "Enter your email address",
                "Enter your phone number",
                "Enter your date of birth",
                "Select yes if you want to get updates from our apprenticeship service support team",
                "Select yes if we can contact you about taking part in a feedback session",
                "Enter your postcode",
                "Select where you're willing to work",
                "Enter your previous apprenticeship training",
                "Enter your employer",
                "Enter your employer's location",
                "Enter your training provider",
                "Enter how long is left on your apprenticeship",
                "Select all the apprenticeships you're interested in",
            };
            ApprenticeDetailsPage _apprenticeDetailsPage = new ApprenticeDetailsPage(_context);
            var actualMessages = _apprenticeDetailsPage.GetErrorMessages();

            Assert.IsTrue(expectedApprenticeErrorMessages.All(x => actualMessages.Contains(x)), $"Not all apprentice error messages are found");
        }

        [Given(@"the apprentice Lands on confirm apprentice details page")]
        public void GivenTheApprenticeLandsOnConfirmApprenticeDetailsPage() => _apprenticeHelper.NavigateToApprenticeDetailsPage(new MainLandingPage(_context));

        [Given(@"the apprentice can acess all the change links")]
        public void GivenTheApprenticeCanAcessAllTheChangeLinks() => _apprenticeHelper.VerifyApprenticeChangelinks(new Apprentice_CheckYourAnswersPage(_context));

        [When(@"the apprentice updates the previous apprenticeship details")]
        public void WhenTheApprenticeUpdatesThePreviousApprenticeshipDetails() => _apprenticeHelper.ClickChangeAndUpdatePreviousApprenticeshipDetails(new Apprentice_CheckYourAnswersPage(_context));

        [Then(@"changes made are reflected on confirm apprentice details page")]
        public void ThenChangesMadeAreReflectedOnConfirmApprenticeDetailsPage() => _apprenticeHelper.VerifyUpdatedPreviousApprenticeshipDetails(new Apprentice_CheckYourAnswersPage(_context));

    }
}
