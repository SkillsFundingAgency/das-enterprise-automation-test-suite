using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity
{
    public class AO_ApprovedStandardDetailsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Abattoir worker";
        private readonly TabHelper _tabHelper;

        #region Locators
        private By ApplyToAssessThisStandardButton => By.CssSelector(".govuk-button");
        #endregion

        public AO_ApprovedStandardDetailsPage(ScenarioContext context) : base(context)
        {
            _tabHelper = context.Get<TabHelper>();
            VerifyPage();
        }

        public void ClickApplyToThisStandardButton() => _tabHelper.OpenInNewTab(() => formCompletionHelper.Click(ApplyToAssessThisStandardButton));
    }
}
