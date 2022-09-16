using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class EditVacancyPage : Raav2BasePage
    {
        protected override string PageTitle => "Edit advert dates";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        private By EditClosingDate => By.CssSelector("a[data-automation='edit-closing-date']");

        private By EditStartDate => By.CssSelector("a[data-automation='edit-start-date']");

        private By Publish => By.CssSelector(".govuk-button.save-button");

        public EditVacancyPage(ScenarioContext context) : base(context) { }

        public EditVacancyDatesPage EditVacancyCloseDate()
        {
            formCompletionHelper.Click(EditClosingDate);
            return new EditVacancyDatesPage(context);
        }

        public EditVacancyDatesPage EditVacancyStartDate()
        {
            formCompletionHelper.Click(EditStartDate);
            return new EditVacancyDatesPage(context);
        }

        public EditVacancyConfirmationPage PublishVacancy()
        {
            formCompletionHelper.Click(Publish);
            return new EditVacancyConfirmationPage(context);
        }
    }
}
