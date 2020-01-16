using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmCohortDeletionPage : BasePage
    {
        protected override string PageTitle => "Confirm deletion";
        
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By ConfirmDeleteOptions => By.CssSelector(".selection-button-radio");
        protected override By ContinueButton => By.CssSelector(".button");

        public ConfirmCohortDeletionPage(ScenarioContext context) : base(context)
        {
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public void ConfirmDeleteAndSubmit()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmDeleteOptions, "confirm-yes");
            Continue();
        }
    }
}