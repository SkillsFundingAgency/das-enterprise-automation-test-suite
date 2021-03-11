using NUnit.Framework;
using SFA.DAS.FindEPAO.UITests.Project.Helpers;
using SFA.DAS.FindEPAO.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.FindEPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]

    public class FindEPAOSteps
    {
        private readonly ScenarioContext _context;
        private readonly FindEPAOStepsHelper _findEPAOStepsHelper;
        private EPAOOrganisationsPage _ePAOOrganisationsPage;
        private EPAOOrganisationDetailsPage _ePAOOrganisationDetailsPage;
        private ZeroAssessmentOrganisationsPage _zeroAssessmentOrganisationsPage;
        private IntegratedAppreticeshipStandardPage _integratedAppreticeshipStandardPage;

        public FindEPAOSteps(ScenarioContext context)
        {
            _context = context;
            _findEPAOStepsHelper = new FindEPAOStepsHelper(_context);
        }

        [Given(@"the user searches a standard with '(.*)' term")]
        public void GivenTheUserSearchesAStandardWithTerm(string searchTerm) => _ePAOOrganisationsPage = _findEPAOStepsHelper.SearchForApprenticeshipStandard(searchTerm);

        [Given(@"the user searches a standard '(.*)' term with no EPAO")]
        public void GivenTheUserSearchesAStandardTermWithNoEPAO(string searchTerm) => _zeroAssessmentOrganisationsPage = _findEPAOStepsHelper.SearchForApprenticeshipStandardWithNoEPAO(searchTerm);

        [Given(@"the user searches a standard '(.*)' term with single EPAO")]
        public void GivenTheUserSearchesAStandardTermWithSingleEPAO(string searchTerm) => _ePAOOrganisationDetailsPage = _findEPAOStepsHelper.SearchForApprenticeshipStandardWithSingleEPAO(searchTerm);

        [Given(@"the user searches an integrated standard '(.*)' term")]
        public void GivenTheUserSearchesAnIntegratedStandardTerm(string searchTerm) => _integratedAppreticeshipStandardPage = _findEPAOStepsHelper.SearchForIntegratedApprenticeshipStandard(searchTerm);

        [Then(@"the user is able to click back to the search apprenticeship page")]
        public void WhenTheUserClicksBack() => _ePAOOrganisationDetailsPage.NavigateBackFromSingleEPAOOrganisationDetailsPage();

        [When(@"the user selects an EPAO from the list")]
        [Then(@"the user selects an EPAO from the list")]
        public void WhenTheUserSelectsAnEPAOFromTheList()
        {
            _ePAOOrganisationDetailsPage = _ePAOOrganisationsPage.SelectFirstEPAOOrganisationFromList();
        }

        [Then(@"the user is able to contact ESFA")]
        public void ThenTheUserIsAbleToContactESFA()
        {
            Assert.IsTrue(_zeroAssessmentOrganisationsPage.IsContactESFAButtonDisplayed());
        }

        [Then(@"the user is able to click back from integrated apprenticeship page")]
        public void ThenTheUserIsAbleToClickBackFromIntegratedApprenticeshipPage() => _integratedAppreticeshipStandardPage.NavigateBackFromIntegratedApprenticeshipsPage();

    }
}
