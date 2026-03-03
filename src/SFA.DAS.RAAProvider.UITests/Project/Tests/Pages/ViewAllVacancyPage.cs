using OpenQA.Selenium;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Tests.Pages
{
    public class ViewAllVacancyPage(ScenarioContext context) : RaaBasePage(context, true)
    {
        protected override string PageTitle => "All vacancies";


        
    }
}
