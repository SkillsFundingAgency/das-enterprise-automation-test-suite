using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeshipRecordStoppedPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Apprenticeship record stopped";
        protected override By ContinueButton => By.Id("continue-button");

        public EnterUkprnPage ClickOnContinueButton()
        {
            Continue();
            return new EnterUkprnPage(context);
        }

    }
}
