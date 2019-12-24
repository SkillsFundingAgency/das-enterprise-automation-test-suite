using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ReviewChangesPage : BasePage
    {
        protected override string PageTitle => "Review changes";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        public ReviewChangesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        private By ConfirmChangesOptions => By.CssSelector(".selection-button-radio");
        protected override By ContinueButton => By.CssSelector(".button");

        public EditedApprenticeDetailsPage SelectApproveChangesAndSubmit()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmChangesOptions, "changes-approve-true");
            Continue();
            return new EditedApprenticeDetailsPage(_context);
        }

        public ApprenticeDetailsPage SelectRejectChangesAndSubmit()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmChangesOptions, "changes-approve-false");
            Continue();
            return new ApprenticeDetailsPage(_context);
        }
    }
}