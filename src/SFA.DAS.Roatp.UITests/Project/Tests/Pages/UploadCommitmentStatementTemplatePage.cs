using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class UploadCommitmentStatementTemplatePage : RoatpBasePage
    {
        protected override string PageTitle => "Upload your organisation's commitment statement template";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public UploadCommitmentStatementTemplatePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApplicationOverviewPage OrganisationsCommitmentStatementTemplateFileUploadAndContinue()
        {
            UploadFile();
            return new ApplicationOverviewPage(_context);
        }
    }

}
