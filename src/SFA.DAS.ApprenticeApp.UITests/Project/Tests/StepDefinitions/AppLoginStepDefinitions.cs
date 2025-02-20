using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;
using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AppLoginStepDefinitions(ScenarioContext context, IWebDriver driver)
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _driver;
        private CookiePage _cookiePage;
        private HomePage _homePage;


        [Given(@"the apprentice has logged into the app")]
        public void GivenTheApprenticeHasLoggedIntoTheApp()
        {
           _cookiePage.AccessHomePage();
        }
    }
}
