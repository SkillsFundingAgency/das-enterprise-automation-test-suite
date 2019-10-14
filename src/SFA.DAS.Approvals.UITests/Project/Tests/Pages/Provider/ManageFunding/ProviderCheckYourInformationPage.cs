using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider.ManageFunding
{
    public class ProviderCheckYourInformationPage : BasePage
    {
        protected override string PageTitle => "Check your information";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By ConfirmButton => By.CssSelector(".govuk-button");

        public ProviderCheckYourInformationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        public ProviderMakingChangesPage ConfirmReserveFunding()
        {
            _formCompletionHelper.ClickElement(ConfirmButton);
            return new ProviderMakingChangesPage(_context);
        }

    }
}
