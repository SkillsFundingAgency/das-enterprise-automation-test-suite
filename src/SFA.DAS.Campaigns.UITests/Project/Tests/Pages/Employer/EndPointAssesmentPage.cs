using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EndPointAssesmentPage : EmployerBasePage
    {
        protected override string PageTitle => "ASSESSMENT AND CERTIFICATION";

        public EndPointAssesmentPage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(Heading1, "ASSESSMENT");
            pageInteractionHelper.VerifyText(Heading2, "WHERE TO FIND AN END-POINT ASSESSMENT ORGANISATION");
            pageInteractionHelper.VerifyText(Heading3, "CERTIFICATION");
        }
    }
}

