using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ResubmittedVacancyReferencePage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Advert resubmitted to ESFA";

        protected By ReturnToDashboard => By.LinkText("Return to dashboard");

        public ResubmittedVacancyReferencePage(ScenarioContext context) : base(context) { }
    
        public void ConfirmVacancyResubmission() => VerifyPanelTitle("Advert resubmitted to ESFA");
    }
}
