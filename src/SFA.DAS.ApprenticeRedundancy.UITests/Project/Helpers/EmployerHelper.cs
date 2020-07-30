using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.EmployerDetails;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers
{
    public class EmployerHelper
    {
        private readonly ScenarioContext _context;

        public EmployerHelper(ScenarioContext context) => _context = context;
        internal EmployerConfirmationPage CompleteEmployerForm_HappyPath(MainLandingPage mainLandingPage)
        {
            mainLandingPage.NavigateToFindApprentices()
             .SelectEmployerStartnow()
                 .CompleteEmployersDetails()
                 .ConfirmEmployerAnswers();
            return new EmployerConfirmationPage(_context);
        }
        internal EmployerDetailsPage ContinueWithoutAllMandatoryFieldsCompletedForEmployerForm(MainLandingPage mainLandingPage)
        {
            mainLandingPage.NavigateToFindApprentices()
             .SelectEmployerStartnow()
             .ContinueToEmployerCheckAnswersPage();
            return new EmployerDetailsPage(_context);
        }
        internal Employer_CheckYourAnswersPage NavigateToEmployerDetailsPage(MainLandingPage mainLandingPage)
        {
            mainLandingPage.NavigateToFindApprentices()
                .SelectEmployerStartnow()
                .CompleteEmployersDetails();     
            return new Employer_CheckYourAnswersPage(_context);
        }
        internal Employer_CheckYourAnswersPage VerifyEmployerChangeLinks(Employer_CheckYourAnswersPage employer_CheckYourAnswersPage)
        {
            employer_CheckYourAnswersPage.ClickChangeOrganisationDetailsLink()
                .NavigateBackToEmployerCheckYourAnswersPage()
                .ClickChangeApprenticeLocationsLink()
                .NavigateBackToEmployerCheckYourAnswersPage()
                .ClickChangeApprenticeshipDetailsLink()
                .NavigateBackToEmployerCheckYourAnswersPage()
                .ClickChangeHowToApplyDetailsLink()
                .NavigateBackToEmployerCheckYourAnswersPage()
                .ClickChangeContactDetailsLink()
                .NavigateBackToEmployerCheckYourAnswersPage();
                return new Employer_CheckYourAnswersPage(_context);
        }
        internal Employer_CheckYourAnswersPage ClickChangeAndUpdateEmployerContactDetails(Employer_CheckYourAnswersPage employer_CheckYourAnswersPage)
        {
            employer_CheckYourAnswersPage.ClickChangeContactDetailsLink()
                .UpdateContactDetails();
            return new Employer_CheckYourAnswersPage(_context);
        }
        internal Employer_CheckYourAnswersPage VerifyUpdatedContactDetails(Employer_CheckYourAnswersPage employer_CheckYourAnswersPage)
        {
            employer_CheckYourAnswersPage.VerifyUpdatedContactDetails("Apprentice Test Smith Regression")
                .VerifyUpdatedContactNumber("ext (1234) +12343232")
                .VerifyUpdateSelectionForFeedback("No");
            return new Employer_CheckYourAnswersPage(_context);
        }
    }
}
