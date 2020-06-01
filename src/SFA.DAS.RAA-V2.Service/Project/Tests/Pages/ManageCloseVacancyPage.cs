using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ManageCloseVacancyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => $"Vacancy VAC{objectContext.GetVacancyReference()} - '{dataHelper.VacancyTitle}' has been closed.";

        protected override By PageHeader => By.CssSelector(".info-summary");

        public ManageCloseVacancyPage(ScenarioContext context) : base(context) { }
    }
}
