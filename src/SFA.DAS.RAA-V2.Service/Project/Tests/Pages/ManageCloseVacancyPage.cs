using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ManageCloseVacancyPage : Raav2BasePage
    {
        protected override string PageTitle => $"Vacancy VAC{objectContext.GetVacancyReference()} - '{rAAV2DataHelper.VacancyTitle}' has been closed.";

        protected override By PageHeader => By.ClassName("das-notification__body");

        public ManageCloseVacancyPage(ScenarioContext context) : base(context) { }
    }
}
