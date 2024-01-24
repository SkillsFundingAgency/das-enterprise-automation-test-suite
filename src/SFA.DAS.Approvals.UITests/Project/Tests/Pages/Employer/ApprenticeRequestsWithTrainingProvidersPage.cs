using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeRequestsWithTrainingProvidersPage(ScenarioContext context) : ApprenticeRequestsSubPage(context)
    {
        protected override string PageTitle => "Apprentice requests";

        protected override bool TakeFullScreenShot => false;

        public ViewApprenticeDetailsPage SelectViewCurrentCohortDetails()
        {
            SelectCurrentCohortDetailsFromTable();

            return new ViewApprenticeDetailsPage(context);
        }
    }
}

