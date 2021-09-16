using System;
using System.Collections.Generic;
using NUnit.Framework;
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
        private List<DateTime> employmentStartDates = new List<DateTime>();
        private NotEligibleShutterPage _notEligibleShutterPage;

        public EmploymentStartDateSteps(ScenarioContext context)
        {
            _context = context;
            _eINavigationHelper = new EINavigationHelper(_context);
        }

        [Given(@"the Employer selects those apprentices on an incentive application")]
        [Given(@"the Employer selects the apprentice on an incentive application")]
        public void GivenTheEmployerSelectsThoseApprenticesOnAnIncentiveApplication()
        {
            var qualificationQuestionPage = _eINavigationHelper.NavigateToEISelectApprenticesPage();
            _whenDidApprenticeJoinPage = qualificationQuestionPage.SelectYesAndContinueForEligibleApprenticesScenario().SubmitApprentices();
        }

        [Given(@"the Employer enters an employment start date of '(.*)' for the first learner")]
        public void GivenTheEmployerEntersAnEmploymentStartDateForTheFirstLearner(DateTime employmentStartDate)
        {
            _whenDidApprenticeJoinPage.EnterJoiningDate(0, employmentStartDate);
            employmentStartDates.Add(employmentStartDate);
        }

        [Given(@"the Employer enters an employment start date of '(.*)' for the second learner")]
        public void GivenTheEmployerEntersAnEmploymentStartDateForTheSecondLearner(DateTime employmentStartDate)
        {
            _whenDidApprenticeJoinPage.EnterJoiningDate(1, employmentStartDate);
            employmentStartDates.Add(employmentStartDate);
        }

        [When(@"the Employer selects Continue")]
        public void WhenTheEmployerSelectsContinue()
        {
            _whenDidApprenticeJoinPage.Continue();
        }

        [Then(@"the Confirm Apprenticeships page is displayed")]
        public void ThenTheConfirmApprenticeshipsPageIsDisplayed()
        {
            // Apparently this will verify the correct page has been displayed.
            var confirmApprenticesPage = new ConfirmApprenticesPage(_context);
        }

        [Then(@"the Ineligible Employment Start Date page is displayed")]
        public void ThenTheIneligibleEmploymentStartDatePageIsDisplayed()
        {
            _notEligibleShutterPage = new NotEligibleShutterPage(_context);

            Assert.AreEqual(employmentStartDates.Count, _notEligibleShutterPage.NumberOfIneligibleApprenticeships);
            CollectionAssert.AreEquivalent(employmentStartDates, _notEligibleShutterPage.EmploymentStartDates);
        }

        [Then(@"the Cancel Application button is displayed")]
        public void ThenTheCancelApplicationButtonIsDisplayed()
        {
            Assert.IsTrue(_notEligibleShutterPage.CancelApplicationButtonExists);
            Assert.IsTrue(_notEligibleShutterPage.ContinueApplicationButtonExists);
        }
    }
}
