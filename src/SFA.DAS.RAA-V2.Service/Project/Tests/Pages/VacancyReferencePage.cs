using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class VacancyReferencePage : RAAV2CSSBasePage
    {
        protected override By PageHeader => VacancyReferenceNumber;

        protected override string PageTitle => "VAC";

        protected By VacancyReferenceNumber => By.CssSelector(".govuk-panel--confirmation strong");

        public VacancyReferencePage(ScenarioContext context) : base(context) { }

        public void SetVacancyReference() => vacancyReferenceHelper.SetVacancyReference(VacancyReferenceNumber);
    }
}
