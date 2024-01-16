using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CheckYourAccountPage(ScenarioContext context) : CheckPage(context)
    {
        protected override string PageTitle { get; }
        protected override By Identifier => By.Id("add_new_account");
    }
}
