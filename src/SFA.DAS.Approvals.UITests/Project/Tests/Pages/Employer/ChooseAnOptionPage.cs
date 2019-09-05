using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ChooseAnOptionPage : BasePage
    {
        protected override string PageTitle => "Choose an option";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        private By CohortApproveOptions => By.CssSelector(".selection-button-radio");
        private By ContinueButton => By.Id("paymentPlan");

        public ChooseAnOptionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public MessageForYourTrainingProviderPage SubmitApproveAndSendToTrainingProvider()
        {
            SelectCohortApproveOptions("SaveStatus-ApproveAndSend")
            .Continue();
            return new MessageForYourTrainingProviderPage(_context);
        }

        public MessageForYourTrainingProviderPage SubmitSendToTrainingProviderForReview()
        {
            SelectCohortApproveOptions("SaveStatus-AmendAndSend")
            .Continue();
            return new MessageForYourTrainingProviderPage(_context);
        }

        public CohortApprovedPage SubmitApprove()
        {
            SelectCohortApproveOptions("SaveStatus-Approve")
            .Continue();
            return new CohortApprovedPage(_context);
        }

        private ChooseAnOptionPage SelectCohortApproveOptions(string value)
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(CohortApproveOptions, value);
            return this;
        }

        private ChooseAnOptionPage Continue()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
            return this;
        }
    }
}