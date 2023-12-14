using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class ComplaintsPolicyPage : AssessorBasePage
    {
        protected override string PageTitle => "Complaints policy";

        public ComplaintsPolicyPage(ScenarioContext context) : base(context) { }

        public WebsiteLinkForTheCompliantsPolicyPage SelectPassAndContinueInComplaintsPolicyPage()
        {
            SelectPassAndContinueToSubSection();
            return new WebsiteLinkForTheCompliantsPolicyPage(context);
        }
    }
}