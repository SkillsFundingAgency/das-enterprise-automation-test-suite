using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class EditApprenticePreApproval : EditAppretinceNameDobAndReference
    {
        protected EditApprenticePreApproval(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        public ApproveApprenticeDetailsPage EditApprenticePreApprovalAndSubmit()
        {
            EditApprenticeNameDobAndReference(editedApprenticeDataHelper.EmployerReference);
            return new ApproveApprenticeDetailsPage(context);
        }
    }
}