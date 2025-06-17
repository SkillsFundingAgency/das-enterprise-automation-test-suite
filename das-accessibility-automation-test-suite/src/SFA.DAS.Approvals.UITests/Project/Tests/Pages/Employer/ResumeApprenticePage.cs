using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ResumeApprenticePage(ScenarioContext context) : ChangeApprenticeStatus(context)
    {
        protected override string PageTitle => "Resume apprenticeship";

        public new ApprenticeDetailsPage SelectYesAndConfirm()
        {
            base.SelectYesAndConfirm();
            return new ApprenticeDetailsPage(context);
        }
    }
}