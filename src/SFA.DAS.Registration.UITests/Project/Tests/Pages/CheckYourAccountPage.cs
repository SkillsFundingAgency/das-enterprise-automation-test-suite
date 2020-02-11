using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CheckYourAccountPage : CheckPage
    {
        protected override string PageTitle { get; }
        protected override By Identifier => By.Id("add_new_account");

        public CheckYourAccountPage(ScenarioContext context) : base(context) { }
    }
}
