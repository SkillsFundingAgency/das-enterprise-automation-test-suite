using System;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmploymentStartDateSteps
    {
        private readonly ScenarioContext _context;
        private EINavigationHelper _eINavigationHelper;
        private WhenDidApprenticeJoinTheOrgPage _whenDidApprenticeJoinPage;

        public EmploymentStartDateSteps(ScenarioContext context)
        {
            _context = context;
            _eINavigationHelper = new EINavigationHelper(_context);
        }

        [Given(@"the Employer selects those apprentices on an incentive application")]
        public void GivenTheEmployerSelectsThoseApprenticesOnAnIncentiveApplication()
        {
            var qualificationQuestionPage = _eINavigationHelper.NavigateToEISelectApprenticesPage();
            _whenDidApprenticeJoinPage = qualificationQuestionPage.SelectYesAndContinueForEligibleApprenticesScenario().SubmitApprentices();
        }

        [Given(@"the Employer enters an employment start date of '(.*)' for the first learner")]
        public void GivenTheEmployerEntersAnEmploymentStartDateForTheFirstLearner(DateTime employmentStartDate)
        {
            _whenDidApprenticeJoinPage.EnterJoiningDate(0, employmentStartDate);
        }

        [Given(@"the Employer enters an employment start date of '(.*)' for the second learner")]
        public void GivenTheEmployerEntersAnEmploymentStartDateForTheSecondLearner(DateTime employmentStartDate)
        {
            _whenDidApprenticeJoinPage.EnterJoiningDate(1, employmentStartDate);
        }

        [When(@"the Employer selects Continue")]
        public void WhenTheEmployerSelectsContinue()
        {
            _whenDidApprenticeJoinPage.Continue();
        }

        [Then(@"Then the Confirm Apprenticeships page is displayed")]
        public void ThenTheConfirmApprenticeshipsPageIsDisplayed()
        {
            // Apparently this will verify the correct page has been displayed.
            var confirmApprenticesPage = new ConfirmApprenticesPage(_context);
        }
    }
}
