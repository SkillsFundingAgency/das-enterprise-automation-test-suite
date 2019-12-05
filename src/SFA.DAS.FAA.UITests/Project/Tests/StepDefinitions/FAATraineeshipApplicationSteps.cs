using NUnit.Framework;
using SFA.DAS.FAA.UITests.Project.Helpers;
using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAATraineeshipApplicationSteps
    {
        private readonly FAAStepsHelper _faaStepsHelper;
        private FAA_TraineeshipSearchPage _traineeshipSearchPage;
        private FAA_TraineeshipSearchResultsPage _traineeshipSearchResultsPage;

        public FAATraineeshipApplicationSteps(ScenarioContext context)
        {
            _faaStepsHelper = new FAAStepsHelper(context);
        }

        [When(@"an applicant is on the Find an Traineeship Page")]
        public void WhenAnApplicantIsOnTheFindAnTraineeshipPage()
        {
            _traineeshipSearchPage = _faaStepsHelper.FindATraineeship();
        }

        [When(@"searched based on '(.*)'")]
        public void WhenSearchedBasedOn(string postCode)
        {
            _traineeshipSearchResultsPage = _traineeshipSearchPage.SearchForAVacancy(postCode);
        }

        [Then(@"the traineeship can be found based on '(.*)','(.*)'")]
        public void ThenTheTraineeshipCanBeFoundBasedOn(string postCode, string distance)
        {
            _traineeshipSearchResultsPage = _traineeshipSearchResultsPage
                 .SearchForAVacancy(postCode, distance);

            Assert.AreEqual(true, _traineeshipSearchResultsPage.FoundVacancies(), $"No traineeship found within '{distance}' of '{postCode}'");
        }
    }
}

