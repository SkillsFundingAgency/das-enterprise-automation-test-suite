using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer
{
    public abstract class ApproveVacancyBasePage : VerifyDetailsBasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By ErrorsCheckboxes => By.Name("SelectedAutomatedQaResults");

        private By ReviewerComment => By.CssSelector("#ReviewerComment");

        private By TitleFieldIdentifiers => By.CssSelector("#SelectedFieldIdentifiers-Title");

        protected By SubmitButton => By.CssSelector("#submit-button");

        public ApproveVacancyBasePage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public void Approve()
        {
            var errors = ErrorsCheckboxElements();

            foreach (var error in errors)
            {
                _formCompletionHelper.UnSelectCheckbox(error);
            }

            _formCompletionHelper.Click(SubmitButton);
            _pageInteractionHelper.WaitforURLToChange("reviews");
        }

        public void Refer()
        {
            var errors = ErrorsCheckboxElements();

            if (errors.Count == 0)
            {
                _formCompletionHelper.SelectCheckbox(_pageInteractionHelper.FindElement(TitleFieldIdentifiers));
            }

            _formCompletionHelper.EnterText(ReviewerComment, "Refered");
            _formCompletionHelper.Click(SubmitButton);
        }

        private List<IWebElement> ErrorsCheckboxElements() => _pageInteractionHelper.FindElements(ErrorsCheckboxes).ToList();
    }
}
