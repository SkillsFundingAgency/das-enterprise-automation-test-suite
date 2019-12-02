using NUnit.Framework;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAAApprenticeshipApplicationSteps
    {
        private readonly FAAStepsHelper _faaStepsHelper;
        private FAA_ApprenticeSearchPage _apprenticeSearchPage;
        private FAA_ApprenticeSearchResultsPage _apprenticeSearchResultspage;

        public FAAApprenticeshipApplicationSteps(ScenarioContext context)
        {
            _faaStepsHelper = new FAAStepsHelper(context);
        }

        [When(@"an applicant is on the Find an Apprenticeship Page")]
        public void WhenAnApplicantIsOnTheFindAnApprenticeshipPage()
        {
            _apprenticeSearchPage = _faaStepsHelper.GoToFAAHomePage(true)
                .FindAnApprenticeship();
        }

        [Then(@"the apprenticeship can be found based on '(.*)','(.*)'")]
        public void ThenTheApprenticeshipCanBeFoundBasedOn(string postCode, string distance)
        {
            _apprenticeSearchResultspage = _apprenticeSearchPage
                .SearchForAVacancy(postCode, distance, "All levels", "Yes");

            Assert.AreEqual(true, _apprenticeSearchResultspage.FoundVacancies(), $"No apprenticeship found within '{distance}' of '{postCode}'");
        }
    }
}

