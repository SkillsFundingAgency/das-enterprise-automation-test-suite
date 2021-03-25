using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class CommitmentStatementTemplatePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Do you agree to use ESFA's commitment statement template?";


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
            SelectRadioOptionByText("Yes");
            Continue();
            return new ApplicationOverviewPage(_context);
        }
        public CommitmentStatementTemplateShutterPage NoForOrganisationsCommitmentStatementTemplateAndContinue()
        {
            SelectRadioOptionByText("No");
            Continue();
            return new CommitmentStatementTemplateShutterPage(_context);
        }
    }
}
