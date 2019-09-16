using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmApprenticeshipStopPage : BasePage
    {

        protected override string PageTitle => "Confirm apprenticeship stop";
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By ChangeTypeOptions => By.CssSelector(".selection-button-radio");
        private By ContinueButton => By.CssSelector(".button");

        public ConfirmApprenticeshipStopPage(ScenarioContext context) : base(context) 
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ApprenticeDetailsPage SelectYesandConfirm()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ChangeTypeOptions, "ChangeConfirmed-True");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ApprenticeDetailsPage(_context);
        }

    }
}