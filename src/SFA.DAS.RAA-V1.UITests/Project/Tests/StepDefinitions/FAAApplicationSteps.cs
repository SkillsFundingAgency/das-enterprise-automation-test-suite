using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAAApplicationSteps
    {
        private readonly FAAStepsHelper _faaStepsHelper;

        private readonly ScenarioContext _context;

        private FAA_HomePage _homePage;

        private FAA_SearchResultsPage _searchResults;

        public FAAApplicationSteps(ScenarioContext context)
        {
            _context = context;
            _faaStepsHelper = new FAAStepsHelper(context);
        }

        [Given(@"the applicant is on the Find an Apprenticeship Page")]
        public void GivenTheApplicantIsOnTheFindAnApprenticeshipPage()
        {
            _homePage = _faaStepsHelper.GoToFAAHomePage();
        }

        [When(@"the applicant searches for the Vacancies '(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenTheApplicantSearchesForTheVacancies(string jobTitle, string location, string distance, string apprenticeshipLevel, string disabilityConfident)
        {
            _searchResults = _homePage
                                .FindAnApprenticeship()
                                .SearchForAVacancy(jobTitle, location, distance, apprenticeshipLevel, disabilityConfident);
        }

        [Then(@"the applicant fills the application form '(.*)','(.*)' ,'(.*)'")]
        public void ThenTheApplicantFillsTheApplicationForm(string qualificationDetails, string workExperience, string trainingCourse)
        {
            if (_searchResults.FoundVacancies())
            {
                if (_searchResults.CanApply())
                {
                    var applicationFormPage = new FAA_ApprenticeSummaryPage(_context).Apply();

                    _faaStepsHelper.ConfirmApplicationSubmission(applicationFormPage, qualificationDetails, workExperience, trainingCourse);
                }
            }
        }
    }
}

