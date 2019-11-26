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

        [Then(@"the applicant fills the application form '(.*)','(.*)' ,'(.*)'")]
        public void ThenTheApplicantFillsTheApplicationForm(string qualificationDetails, string workExperience, string trainingCourse)
        {
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

