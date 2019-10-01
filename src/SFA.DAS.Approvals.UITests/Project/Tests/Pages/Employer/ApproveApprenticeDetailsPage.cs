using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApproveApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => "Approve apprentice details";
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly ApprenticeCourseDataHelper _coursedataHelper;
        #endregion

        private By CohortApproveOptions => By.CssSelector(".govuk-radios__label");

        private By ContinueButton => By.CssSelector("#submitCohort button");

        public ApproveApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _coursedataHelper = context.Get<ApprenticeCourseDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ReviewYourCohortPage SubmitApproveAndSendToTrainingProvider()
        {
            SelectCohortApproveOptions("radio-approve")
            .Continue();
            return new ReviewYourCohortPage(_context);
        }

        public ReviewYourCohortPage ChangeRequestFromTrainingProvider()
        {
            SelectCohortApproveOptions("radio-send")
            .Continue();
            return new ReviewYourCohortPage(_context);
        }

        private ApproveApprenticeDetailsPage SelectCohortApproveOptions(string value)
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(CohortApproveOptions, value);
            return this;
        }

        private ApproveApprenticeDetailsPage Continue()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
            return this;
        }
    }

}