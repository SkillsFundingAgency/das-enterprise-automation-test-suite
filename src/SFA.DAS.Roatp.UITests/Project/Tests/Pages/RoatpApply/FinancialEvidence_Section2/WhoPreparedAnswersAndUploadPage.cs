using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class WhoPreparedAnswersAndUploadPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Who prepared the answers and uploads in this section?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AnEmployeeInYourOrganisationCheckbox => By.CssSelector("input[type='checkbox'][value='An employee in your organisation']");

        public WhoPreparedAnswersAndUploadPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AccountingReferenceDatePage SelectAnEmployeeInYourOrganisationOnWhoPreparedAnswersAndUploadPageAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(AnEmployeeInYourOrganisationCheckbox));
            Continue();
            return new AccountingReferenceDatePage(_context);
        }
    }
}
