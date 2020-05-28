using NUnit.Framework;
using SFA.DAS.FAA.UITests.Project.Helpers;
using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAAFindApplicationSteps
    {
        private readonly FAAStepsHelper _faaStepsHelper;
        private FAA_ApprenticeSearchPage _apprenticeSearchPage;
        private FAA_ApprenticeSearchResultsPage _apprenticeSearchResultspage;
        private FAA_TraineeshipSearchPage _traineeshipSearchPage;

        public FAAFindApplicationSteps(ScenarioContext context) => _faaStepsHelper = new FAAStepsHelper(context);

        [Given(@"an applicant is on the Find an Apprenticeship Page")]
        [When(@"an applicant is on the Find an Apprenticeship Page")]
        public void WhenAnApplicantIsOnTheFindAnApprenticeshipPage() => _apprenticeSearchPage = _faaStepsHelper.FindAnApprenticeship();

        [When(@"the apprenticeship can be found based on '(.*)','(.*)'")]
        [Then(@"the apprenticeship can be found based on '(.*)','(.*)'")]
        public void ThenTheApprenticeshipCanBeFoundBasedOn(string locationPostCode, string searchCriteriaOrDistance) =>
            _apprenticeSearchPage = _apprenticeSearchPage.SearchForAVacancy(locationPostCode, searchCriteriaOrDistance, "All levels", "Yes")
            .CheckVacancyIsDisplayedBasedOnSearchCriteria(locationPostCode, searchCriteriaOrDistance).ClickOnSearchAgainLink();

        [When(@"the candidate search for Nationwide Vacancies '(.*)','(.*)'")]
        public void WhenTheCandidateSearchForNationwideVacancies(string postCode, string distance)
        {
            _apprenticeSearchResultspage = _apprenticeSearchPage.SearchForAVacancy(postCode, distance, "All levels", "Yes");
            Assert.AreEqual(true, _apprenticeSearchResultspage.FoundVacancies(), $"No apprenticeship found within '{distance}' of '{postCode}'");
        }

        [Given(@"an applicant is on the Find an Traineeship Page")]
        [When(@"an applicant is on the Find an Traineeship Page")]
        public void WhenAnApplicantIsOnTheFindAnTraineeshipPage() => _traineeshipSearchPage = _faaStepsHelper.FindATraineeship();

        [Then(@"the traineeship is found based on location search of '(.*)'")]
        public void ThenTheTraineeshipIsFoundBasedOnLocationSearch(string postCode) => _traineeshipSearchPage.SearchForAVacancy(postCode).CheckVacancyIsDisplayed(postCode);

        [Then(@"the Sort results is changed by closing date and distance is not displayed on the vacancies")]
        public void ThenTheSortResultsIsChangedByClosingDateAndDistanceIsJotDisplayedOnTheVacancies() => _faaStepsHelper.CheckNationWideVacancies();
    }
}

