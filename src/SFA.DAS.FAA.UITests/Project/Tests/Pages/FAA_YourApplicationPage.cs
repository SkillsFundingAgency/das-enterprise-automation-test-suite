using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_YourApplicationPage : BasePage
    {
        protected override string PageTitle => "Your application";
         
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By Status => By.CssSelector(".inl-block");

        public FAA_YourApplicationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }


        public FAA_WithDrawConfirmationPage Withdraw()
        {
            _formCompletionHelper.ClickLinkByText("Withdraw my application");
            return new FAA_WithDrawConfirmationPage(_context);
        }

        public string ApplicationStatus()
        {
            return _pageInteractionHelper.GetText(Status);
        }
    }
}
