using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity
{
    public class AO_ApprovedStandardDetailsPage : BasePage
    {
        protected override string PageTitle => "Abattoir worker";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly TabHelper _tabHelper;
        #endregion

        #region Locators
        private By ApplyToAssessThisStandardButton => By.CssSelector(".govuk-button");
        #endregion

        public AO_ApprovedStandardDetailsPage(ScenarioContext context) : base(context)
        {
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _tabHelper = context.Get<TabHelper>();
            VerifyPage();
        }

        public void ClickApplyToThisStandardButton() => _tabHelper.OpenInNewtab(() => _formCompletionHelper.Click(ApplyToAssessThisStandardButton));
    }
}
