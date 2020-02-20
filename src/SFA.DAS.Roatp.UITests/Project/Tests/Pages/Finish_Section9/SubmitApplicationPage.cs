using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.Finish_Section9
{
    public class SubmitApplicationPage : RoatpBasePage
    {
        protected override string PageTitle => "Submit application on behalf of";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ConfirmSubmitApplication => By.Id("ConfirmSubmitApplication");

        private By ConfirmFurtherInfoSubmitApplication => By.Id("ConfirmFurtherInfoSubmitApplication");

        public SubmitApplicationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationSubmittedPage ConfirmAllAnswersAndSubmitApplication()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ConfirmSubmitApplication));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ConfirmFurtherInfoSubmitApplication));
            Continue();
            return new ApplicationSubmittedPage(_context);
        }
    }
}
