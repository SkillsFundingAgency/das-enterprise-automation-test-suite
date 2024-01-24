using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class VacancyReferencePage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override By PageHeader => VacancyReferenceNumber;

        protected override string PageTitle => "VAC";

        private static By VacancyConfirmationSelector => By.CssSelector(".govuk-panel--confirmation");

        protected static By VacancyReferenceNumber => By.CssSelector(".govuk-panel--confirmation strong");

        public VacancyReferencePage SetVacancyReference()
        {
            vacancyReferenceHelper.SetVacancyReference(VacancyReferenceNumber);
            return this;
        }

        public string GetConfirmationMessage() => pageInteractionHelper.GetText(VacancyConfirmationSelector);
    }
}
