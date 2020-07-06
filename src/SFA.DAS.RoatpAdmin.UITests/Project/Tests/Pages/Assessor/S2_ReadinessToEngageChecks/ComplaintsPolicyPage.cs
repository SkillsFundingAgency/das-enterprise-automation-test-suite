using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class ComplaintsPolicyPage : AssessorBasePage
    {
        protected override string PageTitle => "Complaints policy";
        private readonly ScenarioContext _context;

        public ComplaintsPolicyPage(ScenarioContext context) : base(context) => _context = context;

        public WebsiteLinkForTheCompliantsPolicyPage SelectPassAndContinueInComplaintsPolicyPage()
        {
            SelectPassAndContinueToSubSection();
            return new WebsiteLinkForTheCompliantsPolicyPage(_context);
        }
    }
}