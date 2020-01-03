using OpenQA.Selenium;
using SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Common;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer
{
    public abstract class ApproveVacancyBasePage : VerifyDetailsBasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        protected By ErrorsCheckboxs => By.Name("SelectedAutomatedQaResults");

        protected By SubmitButton => By.CssSelector("#submit-button");

        public ApproveVacancyBasePage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public void Approve()
        {
            var errors = _pageInteractionHelper.FindElements(ErrorsCheckboxs);

            foreach (var error in errors)
            {
                _formCompletionHelper.UnSelectCheckbox(error);
            }

            _formCompletionHelper.Click(SubmitButton);
        }

    }
}
