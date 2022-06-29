using System.Threading;
using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class ViewAllVacancyPage : Raav2BasePage
    {
        protected override string PageTitle => "Vacancies";

        private By CreateVacancyLink => By.CssSelector("a[data-automation='create-vacancy']");
        private By SearchBox => By.CssSelector("div.das-autocomplete-wrap");

        public ViewAllVacancyPage(ScenarioContext context) : base(context,false) { }

        public CreateAVacancyPage CreateVacancy()
        {
            //Waiting for traineeship page to appear from login
            Thread.Sleep(3000);
            
            if (pageInteractionHelper.IsElementDisplayed(SearchBox))
            {
                formCompletionHelper.Click(CreateVacancyLink);    
            }
            return new CreateAVacancyPage(context);
        }
    }
}
