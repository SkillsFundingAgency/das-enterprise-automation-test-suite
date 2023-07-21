using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.ServiceBusIntegrationTests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ValidationSteps
    {
        private readonly ScenarioContext _context;

        private ApprenticeDetailsPage apprenticeDetailsPage;

        public ValidationSteps(ScenarioContext context) => _context = context;

        [Then(@"the apprenticeship status changes to completed")]
        public void ThenTheApprenticeshipStatusChangesToCompleted() => apprenticeDetailsPage = ValidateCompletionStatus();

        [Then(@"Apprentice status and details cannot be changed except the planned training finish date")]
        public void ThenApprenticeStatusAndDetailsCannotBeChangedExceptThePlannedTrainingFinishDate() => ValidateApprenticeDetailsCanNoLongerBeChangedExceptEndDate(apprenticeDetailsPage);

        internal ApprenticeDetailsPage ValidateCompletionStatus()
        {
            string expectedCompletionDate = DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year;

            ApprenticeDetailsPage apprenticeDetailsPage = new ManageYourApprenticesPage(_context).SelectViewCurrentApprenticeDetails();

            apprenticeDetailsPage.VerifyApprenticeshipStatus("COMPLETED");

            Assert.AreEqual("Completion payment month", apprenticeDetailsPage.GetStatusDateTitle(), "Validate Completion Date Title");

            Assert.AreEqual(expectedCompletionDate, apprenticeDetailsPage.GetCompletionDate(), "Validate Completion Date");

            return apprenticeDetailsPage;
        }

        internal void ValidateApprenticeDetailsCanNoLongerBeChangedExceptEndDate(ApprenticeDetailsPage apprenticeDetailsPage)
        {
            Assert.IsFalse(apprenticeDetailsPage.IsEditApprenticeStatusLinkVisible());

            Assert.IsFalse(apprenticeDetailsPage.IsEditApprenticeDetailsLinkVisible());

            Assert.True(apprenticeDetailsPage.IsEditEndDateLinkVisible());
        }

    }
}
