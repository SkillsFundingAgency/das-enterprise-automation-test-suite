using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer
{
    public abstract class ApproveVacancyBasePage(ScenarioContext context, bool verifypage = true) : VerifyDetailsBasePage(context, verifypage)
    {
        private static By ErrorsCheckboxes => By.Name("SelectedAutomatedQaResults");

        private static By ReviewerComment => By.CssSelector("#ReviewerComment");

        private static By TitleFieldIdentifiers => By.CssSelector("#SelectedFieldIdentifiers-Title");

        protected static By SubmitButton => By.CssSelector("#submit-button");

        private static By VacancyQALink => By.LinkText("Apprenticeship service vacancy QA");

        public QAReviewsPage Approve()
        {
            var errors = pageInteractionHelper.FindElements(ErrorsCheckboxes).ToList();

            foreach (var error in errors) UI.FrameworkHelpers.FormCompletionHelper.UnSelectCheckbox(error);

            Submit();

            return new QAReviewsPage(context);
        }

        public ApproveVacancyBasePage ReferTitle()
        {
            UI.FrameworkHelpers.FormCompletionHelper.SelectCheckbox(pageInteractionHelper.FindElement(TitleFieldIdentifiers));

            formCompletionHelper.EnterText(ReviewerComment, "Refered - Title requires edit");

            Submit();

            formCompletionHelper.Click(VacancyQALink);

            return this;
        }

        private void Submit() => formCompletionHelper.Click(SubmitButton);
    }
}
