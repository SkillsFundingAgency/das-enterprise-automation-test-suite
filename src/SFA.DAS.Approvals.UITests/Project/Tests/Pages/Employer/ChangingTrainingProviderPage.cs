using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ChangingTrainingProviderPage : ApprovalsBasePage
    {
        protected override By PageHeader => By.TagName("h1");
        protected override string PageTitle => "Changing training provider";

        protected override bool TakeFullScreenShot => false;

        protected override By ContinueButton => By.XPath("//a[contains(text(),'Continue')]");

        private By WarningText => By.TagName("strong");

        public ChangingTrainingProviderPage(ScenarioContext context) : base(context)  { }

        public EnterUkprnPage ClickOnContinueButton()
        {
            Continue();
            return new EnterUkprnPage(context);
        }

        public ThisApprenticeshipTrainingStopPage ValidateWarningAndClickOnContinueButton(string expectedText)
        {
            pageInteractionHelper.VerifyText(pageInteractionHelper.GetText(WarningText), expectedText);
            Continue();
            return new ThisApprenticeshipTrainingStopPage(context);
        }
    }
}
