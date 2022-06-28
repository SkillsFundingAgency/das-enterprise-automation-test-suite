using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAT_Provider.UITests.Project.Tests.Pages
{
    public class CreateAVacancyPage : Raav2BasePage
    {
        protected override string PageTitle => "Create a vacancy";

        public CreateAVacancyPage(ScenarioContext context) : base(context) { }
        public SelectEmployersPage StartNow()
        {
            Continue();
            return new SelectEmployersPage(context);
        }
    }
}
