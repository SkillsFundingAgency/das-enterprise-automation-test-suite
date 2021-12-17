using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class CommitmentStatementTemplatePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation's commitment statement template";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        public CommitmentStatementTemplatePage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage YesForOrganisationsCommitmentStatementTemplateAndContinue()
        {
            UploadFile();
            return new ApplicationOverviewPage(context);
        }
    }
}
