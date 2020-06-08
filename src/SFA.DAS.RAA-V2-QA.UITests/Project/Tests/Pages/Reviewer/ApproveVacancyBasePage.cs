using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer
{
    public abstract class ApproveVacancyBasePage : VerifyDetailsBasePage
    {
        private By ErrorsCheckboxes => By.Name("SelectedAutomatedQaResults");

        private By ReviewerComment => By.CssSelector("#ReviewerComment");

        private By TitleFieldIdentifiers => By.CssSelector("#SelectedFieldIdentifiers-Title");

        protected By SubmitButton => By.CssSelector("#submit-button");

        private By VacancyQALink => By.LinkText("Vacancy QA");

        public ApproveVacancyBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }
        
        public void Approve()
        {
            var errors = ErrorsCheckboxElements();

            foreach (var error in errors)
            {
                formCompletionHelper.UnSelectCheckbox(error);
            }

            formCompletionHelper.Click(SubmitButton);
            pageInteractionHelper.WaitforURLToChange("reviews");
        }

        public void Refer()
        {
            var errors = ErrorsCheckboxElements();

            if (errors.Count == 0)
            {
                formCompletionHelper.SelectCheckbox(pageInteractionHelper.FindElement(TitleFieldIdentifiers));
            }

            formCompletionHelper.EnterText(ReviewerComment, "Refered");
            formCompletionHelper.Click(SubmitButton);
            formCompletionHelper.Click(VacancyQALink);
        }

        private List<IWebElement> ErrorsCheckboxElements() => pageInteractionHelper.FindElements(ErrorsCheckboxes).ToList();
    }
}
