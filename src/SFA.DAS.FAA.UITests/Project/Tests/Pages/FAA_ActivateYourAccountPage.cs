using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ActivateYourAccountPage : FAABasePage
    {
        protected override string PageTitle => "Activate your account";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ActivationCode => By.Id("ActivationCode");
        private By ActivateAccount => By.Id("activate-button");
        private By SignOut => By.Id("signout-link");
        
        public FAA_ActivateYourAccountPage(ScenarioContext context) : base(context) => _context = context;

        public FAA_ActivateYourAccountPage2 EnterActivationCode()
        {
            _formCompletionHelper.EnterText(ActivationCode, _faadataHelper.ActivationCode);
            _formCompletionHelper.Click(ActivateAccount);
            _pageInteractionHelper.WaitforURLToChange("tellusmore");
            return new FAA_ActivateYourAccountPage2(_context);
        }

        public FAA_SignInPage ClickSignOut()
        {
            _formCompletionHelper.Click(SignOut);
            return new FAA_SignInPage(_context);
        }
    }
}