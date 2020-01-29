using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class SubmitApplicationPage : RoatpBasePage
    {
        protected override string PageTitle => "Submit application on behalf of";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        private By ConfirmCheckBox => By.Id("ConfirmSubmitApplication");

        public SubmitApplicationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationSubmittedPage ConfirmAllAnswersAndSubmitApplication()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ConfirmCheckBox));
            Continue();
            return new ApplicationSubmittedPage(_context);
        }
    }
}
