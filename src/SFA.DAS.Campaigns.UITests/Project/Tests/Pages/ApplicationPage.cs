using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class ApplicationPage : ApprenticeshipBasePage
    {
        protected override string PageTitle => "APPLICATION";

        private By Heading => By.CssSelector("#main-content .heading-m");

        public ApplicationPage(ScenarioContext context) : base(context) => pageInteractionHelper.VerifyText(Heading, "SO, YOU'VE FOUND THE APPRENTICESHIP YOU'D LIKE TO APPLY FOR?");
    }
}
