using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class EditVacancyPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => "Edit advert dates";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        private static By EditClosingDate => By.CssSelector("a[data-automation='edit-closing-date']");

        private static By EditStartDate => By.CssSelector("a[data-automation='edit-start-date']");

        private static By Publish => By.CssSelector(".govuk-button.save-button");

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
