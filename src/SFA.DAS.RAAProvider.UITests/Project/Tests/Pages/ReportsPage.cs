using SFA.DAS.RAA.Service.Project.Tests.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAAProvider.UITests.Project.Tests.Pages
{
    public class ReportsPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Reports";
    }
}
