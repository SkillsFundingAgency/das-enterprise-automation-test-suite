using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ComplaintsAndAppealsPolicyPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Complaints and appeals policy";

        private readonly ScenarioContext _context;

        public AS_ComplaintsAndAppealsPolicyPage(ScenarioContext context) : base(context) => _context = context;

        public AS_FairAccessPage UploadComplaintsPolicy()
        {
            UploadFile();
            return new AS_FairAccessPage(_context);
        }

    }
}
