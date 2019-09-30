using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ReviewYourCohortPage : ReviewYourCohort
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

        public ReviewYourCohortPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public EditTransfersApprenticeDetailsPage SelectEditApprentice(int apprenticeNumber = 0)
        {
            var editApprenticeLinks = _pageInteractionHelper.FindElements(EditApprenticeLink);
            _formCompletionHelper.ClickElement(editApprenticeLinks[apprenticeNumber]);
            return new EditTransfersApprenticeDetailsPage(_context);
        }

        public AddApprenticeDetailsPage SelectAddAnApprentice()
        {
            ClickElement(AddAnApprenticeButton);
            return new AddApprenticeDetailsPage(_context);
        }

        public ChooseAnOptionPage SelectContinueToApproval()
        {
            ClickElement(ContinueToApprovalButton);
            return new ChooseAnOptionPage(_context);
        }

        public ChooseAnOptionPage SaveAndContinue()
        {
            ClickElement(SaveAndContinueButton);
            return new ChooseAnOptionPage(_context);
        }

        private void ClickElement(By locator)
        {
            _formCompletionHelper.ClickElement(locator, true);
        }
    }
}