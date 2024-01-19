using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class ComplaintsPolicyPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Complaints policy";

        public WebsiteLinkForTheCompliantsPolicyPage SelectPassAndContinueInComplaintsPolicyPage()
        {
            SelectPassAndContinueToSubSection();
            return new WebsiteLinkForTheCompliantsPolicyPage(context);
        }
    }
}