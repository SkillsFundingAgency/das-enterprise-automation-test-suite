using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmTrainingProviderPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm training provider";
        protected override By ContinueButton => By.Id("continue-button");

        public ConfirmTrainingProviderPage(ScenarioContext context): base(context)  { }

        public StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect()
        {
            SelectRadioOptionByForAttribute("UseThisProvider");
            Continue();
            return new StartAddingApprenticesPage(context);
        }
    }
}