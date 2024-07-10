using OpenQA.Selenium;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Tests.Pages
{
    public class ViewAllVacancyPage(ScenarioContext context) : RaaBasePage(context, true)
    {
        protected override string PageTitle => "Your vacancies";

        private static By CreateVacancyLink => By.CssSelector("a[data-automation='create-vacancy']");
        private static By SearchBox => By.CssSelector("div.das-autocomplete-wrap");

        public CreateAVacancyPage CreateVacancy()
        {
            if (pageInteractionHelper.IsElementDisplayed(SearchBox))
            {
                formCompletionHelper.Click(CreateVacancyLink);
            }
            return new CreateAVacancyPage(context);
        }
    }
}
