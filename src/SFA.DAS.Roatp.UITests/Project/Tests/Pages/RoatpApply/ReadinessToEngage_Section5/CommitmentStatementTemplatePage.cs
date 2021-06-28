using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class CommitmentStatementTemplatePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation's commitment statement template";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public CommitmentStatementTemplatePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage YesForOrganisationsCommitmentStatementTemplateAndContinue()
        {
            UploadFile();
            return new ApplicationOverviewPage(_context);
        }
    }
}
