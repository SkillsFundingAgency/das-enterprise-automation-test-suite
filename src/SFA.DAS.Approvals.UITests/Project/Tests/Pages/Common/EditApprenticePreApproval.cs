using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class EditApprenticePreApproval : EditAppretinceNameDobAndReference
    {
        private readonly ScenarioContext _context;

        protected EditApprenticePreApproval(ScenarioContext context, bool verifypage = true) : base(context, verifypage) => _context = context;

        public ReviewYourCohortPage EditApprenticePreApprovalAndSubmit()
        {
            EditApprenticeNameDobAndReference(editedApprenticeDataHelper.EmployerReference);
            return new ReviewYourCohortPage(_context);
        }
    }
}