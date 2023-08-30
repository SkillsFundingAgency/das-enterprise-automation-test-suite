using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class ViewAllVacancyPage : Raav2BasePage
    {
        protected override string PageTitle => "Your vacancies";

        private static By CreateVacancyLink => By.CssSelector("a[data-automation='create-vacancy']");
        private static By SearchBox => By.CssSelector("div.das-autocomplete-wrap");

        public ViewAllVacancyPage(ScenarioContext context) : base(context, true) { }

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
