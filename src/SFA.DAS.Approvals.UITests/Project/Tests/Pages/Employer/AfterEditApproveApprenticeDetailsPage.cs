using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AfterEditApproveApprenticeDetailsPage : BasePage
    {
       protected override string PageTitle => "Approve apprentice details";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion
        private By ApproveApprenticeSaveAndSubmit => By.Id("continue-button");
        protected override By ContinueButton => By.Id("continue-button");
        public AfterEditApproveApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        internal NotificationSentToTrainingProviderPage DynamicHomePageChangeRequestFromTrainingProvider()
        {
            SelectRadioOptionByForAttribute("radio-send");
            _formCompletionHelper.ClickElement(ApproveApprenticeSaveAndSubmit);
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
