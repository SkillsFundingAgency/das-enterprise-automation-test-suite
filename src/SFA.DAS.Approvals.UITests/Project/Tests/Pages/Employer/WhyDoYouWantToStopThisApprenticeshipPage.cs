using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public enum StopApprentice
    {
        [ToString("Apprentice left my employment")]
        LeftEmployer = 0,
        [ToString("Change to training provider")]
        ChangeTrainingProvider = 1,
        [ToString("Apprentice has withdrawn from training")]
        Withdrawn = 2
    }


    public class WhyDoYouWantToStopThisApprenticeshipPage : ApprovalsBasePage        
    {
        protected override string PageTitle => "Why do you want to stop this apprenticeship?";
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Save and continue')]");

        public WhyDoYouWantToStopThisApprenticeshipPage(ScenarioContext context) : base(context) { }

        public ThisApprenticeshipTrainingStopPage SelectedReasonToStop(StopApprentice reason)
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, EnumToString.GetStringValue(reason));
            Continue();
            return new ThisApprenticeshipTrainingStopPage(context);
        }
    }
}
