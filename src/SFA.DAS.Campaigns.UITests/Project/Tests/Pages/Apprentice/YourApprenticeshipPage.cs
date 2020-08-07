using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class YourApprenticeshipPage : ApprenticeBasePage
    {
        protected override string PageTitle => "STARTING YOUR APPRENTICESHIP";

        private readonly By _subHeading1 = By.XPath("//h2[contains(@class, 'heading-m') and contains(text(), 'Training providers')]");

        public YourApprenticeshipPage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(_subHeading1, "TRAINING PROVIDERS");
        }
    }
}
