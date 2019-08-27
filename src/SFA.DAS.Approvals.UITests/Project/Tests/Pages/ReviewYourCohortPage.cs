using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages
{
    public class ReviewYourCohortPage : BasePage
    {
        protected override string PageTitle => "Review your cohort";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        private By AddAnApprenticeButton => By.ClassName("button-secondary");
        private By SaveAndContinueButton => By.ClassName("finishEditingBtn");
        private By ContinueToApprovalButton => By.ClassName("finishEditingBtn");
        private By EditApprenticeLink => By.LinkText("Edit");
        private By DeleteCohortbutton => By.ClassName("delete-button");
        private By TotalCost => By.CssSelector("h2.short.bold-xlarge");

        public ReviewYourCohortPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal AddApprenticeDetailsPage SelectAddAnApprentice()
        {
            _formCompletionHelper.ClickElement(AddAnApprenticeButton);
            return new AddApprenticeDetailsPage(_context);
        }

        internal string ApprenticeTotalCost()
        {
            return _pageInteractionHelper.GetText(TotalCost);
        }
        internal ChooseAnOptionPage SaveAndContinue()
        {
            _formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ChooseAnOptionPage(_context);
        }
    }
}