using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class ViewAllVacancyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Vacancies";

        private By CreateVacancyLink => By.CssSelector("a[data-automation='create-vacancy']");

        public ViewAllVacancyPage(ScenarioContext context) : base(context) => VerifyPage();

        public SelectEmployersPage CreateVacancy()
        {
            formCompletionHelper.Click(CreateVacancyLink);
            return new SelectEmployersPage(_context);
        }
    }
}
