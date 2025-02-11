using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class WhoPreparedAnswersAndUploadPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Who prepared the answers and uploads in this section?";

        private static By AnEmployeeInYourOrganisationCheckbox => By.CssSelector("input[type='checkbox'][value='An employee in your organisation']");

        public WhoPreparedAnswersAndUploadPage(ScenarioContext context) : base(context) => VerifyPage();

        public AccountingReferenceDatePage SelectAnEmployeeInYourOrganisationOnWhoPreparedAnswersAndUploadPageAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(AnEmployeeInYourOrganisationCheckbox));
            Continue();
            return new AccountingReferenceDatePage(context);
        }
    }
}
