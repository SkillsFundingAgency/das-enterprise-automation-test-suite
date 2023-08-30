using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer
{
    public abstract class ApproveVacancyBasePage : VerifyDetailsBasePage
    {
        private static By ErrorsCheckboxes => By.Name("SelectedAutomatedQaResults");

        private static By ReviewerComment => By.CssSelector("#ReviewerComment");

        private static By TitleFieldIdentifiers => By.CssSelector("#SelectedFieldIdentifiers-Title");

        protected static By SubmitButton => By.CssSelector("#submit-button");

        private static By VacancyQALink => By.LinkText("Apprenticeship service vacancy QA");

        public ApproveVacancyBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        public QAReviewsPage Approve()
        {
            var errors = pageInteractionHelper.FindElements(ErrorsCheckboxes).ToList();

            foreach (var error in errors) formCompletionHelper.UnSelectCheckbox(error);

            Submit();

            return new QAReviewsPage(context);
        }

        public void ReferTitle()
        {
            formCompletionHelper.SelectCheckbox(pageInteractionHelper.FindElement(TitleFieldIdentifiers));

            formCompletionHelper.EnterText(ReviewerComment, "Refered - Title requires edit");

            Submit();

            formCompletionHelper.Click(VacancyQALink);
        }

        private void Submit() => formCompletionHelper.Click(SubmitButton);
    }
}
