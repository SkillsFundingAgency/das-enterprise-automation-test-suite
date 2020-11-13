using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class ComplaintsPolicyPage : ModeratorBasePage
    {
        protected override string PageTitle => "Complaints policy";
        private readonly ScenarioContext _context;

        public ComplaintsPolicyPage(ScenarioContext context) : base(context) => _context = context;

        public WebsiteLinkForTheCompliantsPolicyPage SelectPassAndContinueInComplaintsPolicyPage()
        {
            objectContext.SetIsUploadFile();
            SelectPassAndContinueToSubSection();
            return new WebsiteLinkForTheCompliantsPolicyPage(_context);
        }
    }
}