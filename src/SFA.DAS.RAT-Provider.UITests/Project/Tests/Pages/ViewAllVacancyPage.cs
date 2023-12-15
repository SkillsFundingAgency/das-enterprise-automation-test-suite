using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAT_Provider.UITests.Project.Tests.Pages
{
    public class ViewAllVacancyPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => "Your vacancies";

        private static By CreateVacancyLink => By.CssSelector("a[data-automation='create-vacancy']");

        public CreateAVacancyPage CreateVacancy()
        {
            formCompletionHelper.Click(CreateVacancyLink);
            return new CreateAVacancyPage(context);
        }
    }
}
