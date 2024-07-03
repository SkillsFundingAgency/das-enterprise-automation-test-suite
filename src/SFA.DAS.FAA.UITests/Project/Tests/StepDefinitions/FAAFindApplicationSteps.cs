using NUnit.Framework;
using SFA.DAS.FAA.UITests.Project.Helpers;
using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAAFindApplicationSteps(ScenarioContext context)
    {
        private readonly FAAStepsHelper _faaStepsHelper = new(context);
        private FAA_ApprenticeSearchPage _apprenticeSearchPage;
        private FAA_ApprenticeSearchResultsPage _apprenticeSearchResultspage;

        [Given(@"an applicant is on the Find an Apprenticeship Page")]
        [When(@"an applicant is on the Find an Apprenticeship Page")]
        public void WhenAnApplicantIsOnTheFindAnApprenticeshipPage() => _apprenticeSearchPage = _faaStepsHelper.FindAnApprenticeship();

        [When(@"the candidate search for Nationwide Vacancies '(.*)','(.*)'")]
        public void WhenTheCandidateSearchForNationwideVacancies(string postCode, string distance)
        {
            _apprenticeSearchResultspage = _apprenticeSearchPage.SearchForAVacancy(postCode, distance, "All levels", "Yes");
            Assert.AreEqual(true, _apprenticeSearchResultspage.FoundVacancies(), $"No apprenticeship found within '{distance}' of '{postCode}'");
        }

        [Then(@"the Sort results is changed by closing date and distance is not displayed on the vacancies")]
        public void ThenTheSortResultsIsChangedByClosingDateAndDistanceIsJotDisplayedOnTheVacancies() => _faaStepsHelper.CheckNationWideVacancies();
    }
}

