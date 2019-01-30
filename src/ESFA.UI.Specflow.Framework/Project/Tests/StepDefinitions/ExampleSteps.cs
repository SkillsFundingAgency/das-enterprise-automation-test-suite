using System;
using BoDi;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.Pages;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.StepDefinitions
{
    [Binding]
    public class ExampleSteps
    {
        private IWebDriver WebDriver;

        public ExampleSteps(IWebDriver _webDriver)
        {
            WebDriver = _webDriver;
        }
               
        [Given(@"I navigate to GOV.UK home page and search for (.*)")]
        public void INavigateToGovUkHomePageAndSearchForText(String searchText)
        {
            WelcomeToGovUkPage welcomeToGovUkPage = new WelcomeToGovUkPage(WebDriver);
            welcomeToGovUkPage.EnterSearchTextAndSubmit(searchText);
        }

        [When(@"I click on DFE link")]
        public void ClickOnDfeLink()
        {
            SearchResultsPage searchResultsPage = new SearchResultsPage(WebDriver);
            searchResultsPage.ClickDfeLink();
        }

        [Then(@"I should be on DFE home page")]
        public void ShouldBeOnDfeHomePage()
        {
            DepartmentForEducationHomePage departmentForEducationHomePage = new DepartmentForEducationHomePage(WebDriver);         
            departmentForEducationHomePage.IsPageHeadingMacthing();            
        }
    }
}