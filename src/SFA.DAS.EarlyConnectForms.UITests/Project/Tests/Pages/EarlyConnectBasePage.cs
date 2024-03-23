using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public abstract class EarlyConnectBasePage(ScenarioContext context) : VerifyBasePage(context)
    {
        protected static By getAnAdviser => By.CssSelector("#fiu-app-menu-link-2");
       // protected static By ContinueButton => By.CssSelector("#fiu-app-menu-link-3");
        protected static By BrowseApprenticeship => By.CssSelector("#fiu-app-menu-link-4");
        protected static By howApprenticeshipWork => By.CssSelector("#fiu-app-menu-link-4");
        protected static By findAnApprenticeship => By.CssSelector("#fiu-app-menu-link-4");
        
    }
}
