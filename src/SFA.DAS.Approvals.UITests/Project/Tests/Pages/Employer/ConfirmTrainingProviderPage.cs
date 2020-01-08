using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmTrainingProviderPage : BasePage
    {
        protected override string PageTitle => "Confirm training provider";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By ConfirmProviderDetailsOptions => By.CssSelector(".govuk-radios__label");

        public ConfirmTrainingProviderPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmProviderDetailsOptions, "UseThisProvider");
            Continue();
            return new StartAddingApprenticesPage(_context);
        }
    }
}