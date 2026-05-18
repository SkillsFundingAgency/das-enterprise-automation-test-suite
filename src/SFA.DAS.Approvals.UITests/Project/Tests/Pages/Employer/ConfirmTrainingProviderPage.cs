using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmTrainingProviderPage(ScenarioContext context) : ApprovalsBasePage(context, false)
    {
        protected override string PageTitle => "Confirm your training provider details";

        protected override bool TakeFullScreenShot => false;

        protected override By ContinueButton => By.Id("continue-button");

        public StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect()
        {
            VerifyPage(ContinueButton);
            SelectRadioOptionByForAttribute("UseThisProvider");
            Continue();
            return new StartAddingApprenticesPage(context);
        }
    }
}