using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_YourApplicationPage : FAABasePage
    {
        protected override string PageTitle => "Your application";
         
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Status => By.CssSelector(".inl-block");

        public FAA_YourApplicationPage(ScenarioContext context) : base(context) => _context = context;

        public FAA_WithDrawConfirmationPage Withdraw()
        {
            _formCompletionHelper.ClickLinkByText("Withdraw my application");
            return new FAA_WithDrawConfirmationPage(_context);
        }

        public string ApplicationStatus() => _pageInteractionHelper.GetText(Status);
    }
}
