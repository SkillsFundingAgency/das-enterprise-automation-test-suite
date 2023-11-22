using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeRequestsWithTrainingProvidersPage : ApprenticeRequestsSubPage
    {
        protected override string PageTitle => "Apprentice requests";

        protected override bool TakeFullScreenShot => false;

        public ApprenticeRequestsWithTrainingProvidersPage(ScenarioContext context) : base(context)  { }

        public ViewApprenticeDetailsPage SelectViewCurrentCohortDetails()
        {
            SelectCurrentCohortDetailsFromTable();

            return new ViewApprenticeDetailsPage(context);
        }
    }
}

