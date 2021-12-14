using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity
{
    public class AO_ApprovedStandardDetailsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Abattoir worker";

        #region Locators
        private By ApplyToAssessThisStandardButton => By.CssSelector("#main-content .govuk-button");
        #endregion

        public AO_ApprovedStandardDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public void ClickApplyToThisStandardButton() => tabHelper.OpenInNewTab(() => formCompletionHelper.Click(ApplyToAssessThisStandardButton));
    }
}
