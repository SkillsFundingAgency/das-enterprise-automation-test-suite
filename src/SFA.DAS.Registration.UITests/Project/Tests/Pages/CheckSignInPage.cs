using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CheckSignInPage : CheckPage
    {
        protected override string PageTitle { get; }

        protected override By Identifier => By.Id("EmailAddress");

        public CheckSignInPage(ScenarioContext context) : base(context)
        {  
        }
    }
}
