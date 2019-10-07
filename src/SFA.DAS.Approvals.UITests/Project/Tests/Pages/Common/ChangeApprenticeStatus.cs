using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class ChangeApprenticeStatus : BasePage
    {
        private By ConfirmResumeOptions => By.CssSelector(".selection-button-radio");
        private By ConfirmButton => By.CssSelector(".button");

        private readonly FormCompletionHelper _formCompletionHelper;

        public ChangeApprenticeStatus(ScenarioContext context) : base(context)
        {
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public void SelectYesAndConfirm()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmResumeOptions, "ChangeConfirmed-True");
            _formCompletionHelper.ClickElement(ConfirmButton, true);
        }
    }
}