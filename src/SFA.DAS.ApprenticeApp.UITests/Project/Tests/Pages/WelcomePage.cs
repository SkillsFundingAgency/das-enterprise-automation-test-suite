using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class WelcomePage(ScenarioContext context) : AppBasePage(context)
    {
        protected static By startNow = By.CssSelector("a.govuk-button--start");
        protected override string PageTitle => "Welcome to the Your Apprenticeship app";
        public TasksBasePage StartNow()
        {
            formCompletionHelper.Click(startNow);
            return new TasksBasePage(context);
        }
    }
    
}
