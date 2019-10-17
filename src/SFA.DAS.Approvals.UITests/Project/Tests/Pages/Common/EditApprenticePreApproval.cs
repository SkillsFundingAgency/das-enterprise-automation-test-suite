using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class EditApprenticePreApproval : EditAppretinceNameDobAndReference
    {
        private readonly ScenarioContext _context;

        public EditApprenticePreApproval(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ReviewYourCohortPage EditApprenticePreApprovalAndSubmit()
        {
            EditApprenticeNameDobAndReference(dataHelper.EmployerReference);
            return new ReviewYourCohortPage(_context);
        }
    }
}