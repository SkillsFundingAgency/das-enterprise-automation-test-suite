using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditedApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => editedApprenticeDataHelper.ApprenticeEditedFullName;

        public EditedApprenticeDetailsPage(ScenarioContext context) : base(context) { }
    }
}