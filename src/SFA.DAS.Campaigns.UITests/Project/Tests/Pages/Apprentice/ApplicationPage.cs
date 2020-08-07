using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApplicationPage : ApprenticeBasePage
    {
        protected override string PageTitle => "APPLICATION PROCESS";

        private By Heading => By.CssSelector("#main-content .heading-m");

        public ApplicationPage(ScenarioContext context) : base(context) => pageInteractionHelper.VerifyText(Heading, "WHILE YOU WAIT");
    }
}
