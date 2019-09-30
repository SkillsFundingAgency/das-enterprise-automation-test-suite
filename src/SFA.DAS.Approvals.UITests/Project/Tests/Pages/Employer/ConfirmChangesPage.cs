using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmChangesPage : BasePage
    {
        protected override string PageTitle => "Confirm changes";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By AcceptChangesOptions => By.CssSelector(".selection-button-radio");
        private By FinishButton => By.CssSelector(".button");

        public ConfirmChangesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ApprenticeDetailsPage AcceptChangesAndSubmit()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(AcceptChangesOptions, "changes-confirmed-true");
            _formCompletionHelper.ClickElement(FinishButton);
            return new ApprenticeDetailsPage(_context);
        }
    }
}