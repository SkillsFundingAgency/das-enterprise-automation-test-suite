using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ResumeApprenticePage : BasePage
    {
        protected override string PageTitle => "Resume apprentice";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By ConfirmResumeOptions => By.CssSelector(".selection-button-radio");
        private By ConfirmButton => By.CssSelector(".button");

        public ResumeApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ApprenticeDetailsPage SelectYesAndConfirm()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmResumeOptions, "ChangeConfirmed-True");
            _formCompletionHelper.ClickElement(ConfirmButton);
            return new ApprenticeDetailsPage(_context);
        }
    }
}