using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class AssesmentAndCertificationPage : ApprenticeBasePage
    {
        protected override string PageTitle => "ASSESSMENT AND CERTIFICATION";

        public AssesmentAndCertificationPage(ScenarioContext context) : base(context) { VerifyHeadings(); }

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(Heading1, "GET ASSESSED AND GET YOUR CERTIFICATE");
            pageInteractionHelper.VerifyText(Heading2, "COMPLETE YOUR APPRENTICESHIP");
        }
    }
}
