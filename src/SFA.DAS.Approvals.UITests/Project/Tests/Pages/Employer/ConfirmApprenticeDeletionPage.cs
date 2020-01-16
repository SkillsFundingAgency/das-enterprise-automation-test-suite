using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmApprenticeDeletionPage : BasePage
    {
        protected override string PageTitle => "Delete the apprentice";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By ConfirmDeleteOptions => By.CssSelector(".govuk-radios__label");
        protected override By ContinueButton => By.CssSelector(".govuk-button");

        public ConfirmApprenticeDeletionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ReviewYourCohortPage ConfirmDeleteAndSubmit()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmDeleteOptions, "confirmDelete-true");
            Continue();
            return new ReviewYourCohortPage(_context);
        }
    }
}