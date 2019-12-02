using NUnit.Framework;
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
        private FAA_ApprenticeSearchPage _apprenticeSearchPage;
        private FAA_TraineeshipSearchPage _traineeshipSearchPage;
        private FAA_SearchResultsPage _searchResultspage;
        private FAA_TraineeshipSearchResultsPage _traineeshipsearchResultsPage;

        public FAAApplicationSteps(ScenarioContext context)
        {
            _faaStepsHelper = new FAAStepsHelper(context);
        }

        [When(@"an applicant is on the Find an Apprenticeship Page")]
        public void WhenAnApplicantIsOnTheFindAnApprenticeshipPage()
        {
            _apprenticeSearchPage = _faaStepsHelper.GoToFAAHomePage(true)
                .FindAnApprenticeship();
        }

        [When(@"an applicant is on the Find an Traineeship Page")]
        public void WhenAnApplicantIsOnTheFindAnTraineeshipPage()
        {
            _traineeshipSearchPage = _faaStepsHelper.GoToFAAHomePage(true)
              .FindTraineeship();
        }

        [When(@"searched based on '(.*)'")]
        public void WhenSearchedBasedOn(string postCode)
        {
            _traineeshipsearchResultsPage = _traineeshipSearchPage.SearchForAVacancy(postCode, "No");
        }

        [Then(@"the traineeship can be found based on '(.*)','(.*)'")]
        public void ThenTheTraineeshipCanBeFoundBasedOn(string postCode, string distance)
        {
            _searchResultspage = _traineeshipsearchResultsPage
                 .SearchForAVacancy(postCode, distance, "Yes");

            Assert.AreEqual(true, _searchResultspage.FoundVacancies(), $"No traineeship found within '{distance}' of '{postCode}'");
        }

        [Then(@"the apprenticeship can be found based on '(.*)','(.*)'")]
        public void ThenTheApprenticeshipCanBeFoundBasedOn(string postCode, string distance)
        {
            _searchResultspage = _apprenticeSearchPage
                .SearchForAVacancy(postCode, distance, "All levels", "Yes");

            Assert.AreEqual(true, _searchResultspage.FoundVacancies(), $"No apprenticeship found within '{distance}' of '{postCode}'");
        }
    }
}

