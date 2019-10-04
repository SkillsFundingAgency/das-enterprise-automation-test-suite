using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmCohortDeletionPage : BasePage
    {
        private ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;

        public ConfirmCohortDeletionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        protected override string PageTitle => "Confirm cohort deletion";

        private By ConfirmDeleteOptions => By.CssSelector(".selection-button-radio");
        private By ContinueButton => By.CssSelector(".button");

        public void ConfirmDeleteAndSubmit()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmDeleteOptions, "Data_DeleteConfirmed-True");
            _formCompletionHelper.ClickElement(ContinueButton);
        }
    }
}