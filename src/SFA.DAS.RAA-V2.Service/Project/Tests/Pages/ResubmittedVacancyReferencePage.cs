using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ResubmittedVacancyReferencePage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Advert resubmitted for approval";

        public ResubmittedVacancyReferencePage(ScenarioContext context) : base(context) { }
    }
}
