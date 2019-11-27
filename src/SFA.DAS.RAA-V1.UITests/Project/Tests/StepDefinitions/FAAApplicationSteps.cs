using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAAApplicationSteps
    {
        private readonly FAAStepsHelper _faaStepsHelper;

        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        private FAA_HomePage _homePage;

        private FAA_SearchResultsPage _searchResults;

        public FAAApplicationSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _faaStepsHelper = new FAAStepsHelper(context);
        }

        [Given(@"the applicant is on the Find an Apprenticeship Page")]
        public void GivenTheApplicantIsOnTheFindAnApprenticeshipPage()
        {
            _homePage = _faaStepsHelper.GoToFAAHomePage(false);
        }

        [When(@"the applicant searches for a traineeship Vacancies '(.*)','(.*)','(.*)'")]
        public void WhenTheApplicantSearchesForATraineeshipVacancies(string location, string distance, string disabilityConfident)
        {
            _searchResults = _homePage
                .FindTraineeship()
                .SearchForAVacancy(location, distance, disabilityConfident);
        }

        [When(@"the applicant searches for the Vacancies '(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenTheApplicantSearchesForTheVacancies(string jobTitle, string location, string distance, string apprenticeshipLevel, string disabilityConfident)
        {
            _searchResults = _homePage
                .FindAnApprenticeship()
                .SearchForAVacancy(jobTitle, location, distance, apprenticeshipLevel, disabilityConfident);
        }

        [Then(@"the applicant fills the application form '(.*)','(.*)','(.*)' when a qualified vacancy is found")]
        public void ThenTheApplicantFillsTheApplicationFormWhenAnQualifiedVacancyIsFound(string qualificationDetails, string workExperience, string trainingCourse)
        {
            //The test will apply only when the Apply button is displayed.
            //The Apply scenario is already covered in E2E test scenarios, so its logical to skip apply functionality when qualified vacancy is not found.

            if (_searchResults.FoundVacancies())
            {
                if (CanApply())
                {
                    var applicationFormPage = new FAA_ApprenticeSummaryPage(_context).Apply();

                    _faaStepsHelper.ConfirmApplicationSubmission(applicationFormPage, qualificationDetails, workExperience, trainingCourse);
                }
            }
        }

        private bool CanApply()
        {
            if (_objectContext.IsApprenticeshipVacancyType())
            {
                return _searchResults.CanApplyApprenticeship();
            }
            else
            {
                return _searchResults.CanApplyTraineeship();
            }
        }
    }
}

