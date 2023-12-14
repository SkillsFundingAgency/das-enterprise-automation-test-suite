using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ManageCloseVacancyPage : Raav2BasePage
    {
        protected override string PageTitle => $"Advert VAC{objectContext.GetVacancyReference()} - '{rAAV2DataHelper.VacancyTitle}' has been closed.";

        protected override string AccessibilityPageTitle => "Advert has been closed page";

        protected override By PageHeader => By.ClassName("govuk-notification-banner__heading");

        public ManageCloseVacancyPage(ScenarioContext context) : base(context) { }
    }
}
