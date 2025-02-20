using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class HomePage(ScenarioContext context) : AppBasePage(context)
    {
            By signInButtonLocator = By.CssSelector("button.app-button");

        protected override string PageTitle => "Your Apprenticeship";

        public StubSignIn StubSignIn()
        {
            formCompletionHelper.Click(signInButtonLocator);
            return new StubSignIn(context);
        }
    }
}
