using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class ComplaintsPolicyPage : ModeratorBasePage
    {
        protected override string PageTitle => "Complaints policy";
        private readonly ScenarioContext _context;

        public ComplaintsPolicyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            objectContext.SetIsUploadFile();
        }

        public WebsiteLinkForTheCompliantsPolicyPage SelectPassAndContinueInComplaintsPolicyPage()
        {
            SelectPassAndContinueToSubSection();
            return new WebsiteLinkForTheCompliantsPolicyPage(_context);
        }

        public WebsiteLinkForTheCompliantsPolicyPage SelectFailAndContinueInComplaintsPolicyPage()
        {
            SelectFailAndContinueToSubSection();
            return new WebsiteLinkForTheCompliantsPolicyPage(_context);
        }
    }
}