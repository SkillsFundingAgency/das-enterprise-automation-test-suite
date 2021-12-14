using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_RecipientNamePage : EPAOAssesment_BasePage
    {
        protected override string PageTitle => "What is the recipient's name?";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");
        

        #region Locators
        private By RecipientNameTextBox => By.Name("Name");
        private By DepartmentTextBox => By.Name("Dept");
        #endregion

        public AS_RecipientNamePage(ScenarioContext context) : base(context) => VerifyPage();
        public AS_CheckAndSubmitAssessmentPage EnterRecipientDetailsAndContinue()
        {
            formCompletionHelper.EnterText(RecipientNameTextBox, "Mr Smith");
            formCompletionHelper.EnterText(DepartmentTextBox, "IT");
            Continue();
            return new AS_CheckAndSubmitAssessmentPage(context);
        }
    }
}
