using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ManageCloseVacancyPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => $"Advert VAC{objectContext.GetVacancyReference()} - '{rAADataHelper.VacancyTitle}' has been closed.";

        protected override string AccessibilityPageTitle => "Advert has been closed page";

        protected override By PageHeader => By.ClassName("govuk-notification-banner__heading");
    }
}
