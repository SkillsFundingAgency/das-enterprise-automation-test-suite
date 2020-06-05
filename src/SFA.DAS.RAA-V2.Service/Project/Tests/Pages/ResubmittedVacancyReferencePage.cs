using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ResubmittedVacancyReferencePage : RAAV2CSSBasePage
    {

        protected override string PageTitle => vacancyTitleDataHelper.VacancyTitle;

        protected By ReturnToDashboard => By.LinkText("Return to dashboard");
        protected By VacancyResubmissionText => By.ClassName("govuk-panel__title");

        public ResubmittedVacancyReferencePage(ScenarioContext context) : base(context) { }
    
        public void ConfirmVacancyResubmission() => pageInteractionHelper.VerifyText(VacancyResubmissionText, "Vacancy resubmitted for approval");
    }
}
