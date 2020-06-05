using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AfterEditApproveApprenticeDetailsPage : ApprovalsBasePage
    {
       protected override string PageTitle => "Approve apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ApproveApprenticeSaveAndSubmit => By.Id("continue-button");
        protected override By ContinueButton => By.Id("continue-button");

        public AfterEditApproveApprenticeDetailsPage(ScenarioContext context) : base(context) => _context = context; 

        internal NotificationSentToTrainingProviderPage DynamicHomePageChangeRequestFromTrainingProvider()
        {
            SelectRadioOptionByForAttribute("radio-send");
            formCompletionHelper.ClickElement(ApproveApprenticeSaveAndSubmit);
            return new NotificationSentToTrainingProviderPage(_context);
        }
        public ApprenticeDetailsApprovedPage ApproveAndNotifyTrainingProvider()
        {
            SelectRadioOptionByForAttribute("radio-approve");
            Continue();
            return new ApprenticeDetailsApprovedPage(_context);
        }
    }
}
