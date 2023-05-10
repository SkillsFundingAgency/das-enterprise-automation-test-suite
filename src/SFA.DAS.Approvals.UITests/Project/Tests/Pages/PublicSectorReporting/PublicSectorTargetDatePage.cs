using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class PublicSectorTargetDatePage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "public sector apprenticeship target data";

        protected override By ContinueButton => By.CssSelector("#report-create-start");

        public PublicSectorTargetDatePage(ScenarioContext context) : base(context)  { }

        public IsYourOrganisationALocalAuthorityPage Start()
        {
            Continue();
            return new IsYourOrganisationALocalAuthorityPage(context);
        }
    }
}