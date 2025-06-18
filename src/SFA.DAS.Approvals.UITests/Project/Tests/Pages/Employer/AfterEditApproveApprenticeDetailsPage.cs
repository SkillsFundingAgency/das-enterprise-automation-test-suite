using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AfterEditApproveApprenticeDetailsPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Approve apprentice details";

        private static By ApproveApprenticeSaveAndSubmit => By.Id("continue-button");
        protected override By ContinueButton => By.Id("continue-button");

        internal NotificationSentToTrainingProviderPage DynamicHomePageChangeRequestFromTrainingProvider()
        {
            SelectRadioOptionByForAttribute("radio-send");
            formCompletionHelper.ClickElement(ApproveApprenticeSaveAndSubmit);
            return new NotificationSentToTrainingProviderPage(context);
        }

        public ApprenticeDetailsApprovedPage ApproveAndNotifyTrainingProvider()
        {
            SelectRadioOptionByForAttribute("radio-approve");
            Continue();
            return new ApprenticeDetailsApprovedPage(context);
        }
    }
}
