using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmApprenticeDeletionPage : BasePage
    {
        protected override string PageTitle => "Delete the apprentice";
        protected override By ContinueButton => By.Id("continue-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        public ConfirmApprenticeDeletionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ReviewYourCohortPage ConfirmDeleteAndSubmit()
        {
            SelectRadioOptionByForAttribute("confirmDelete-true");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ReviewYourCohortPage(_context);
        }
    }
}