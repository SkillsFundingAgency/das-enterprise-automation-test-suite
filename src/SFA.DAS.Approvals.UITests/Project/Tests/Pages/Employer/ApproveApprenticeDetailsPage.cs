using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApproveApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => "ApproveAndNotifyTrainingProvider apprentice details";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#submitCohort button");

        public ApproveApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
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
            SelectRadioOptionByForAttribute(value);
            return this;
        }
    }
}