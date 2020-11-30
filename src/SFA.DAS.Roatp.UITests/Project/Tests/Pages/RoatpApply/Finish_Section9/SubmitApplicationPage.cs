using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.Finish_Section9
{
    public class SubmitApplicationPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "TEST";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ConfirmSubmitApplication => By.Id("ConfirmSubmitApplication");
        private By ConfirmFurtherInfoSubmitApplication => By.Id("ConfirmFurtherInfoSubmitApplication");
        private By ConfirmFurtherCommunicationSubmitApplication = By.Id("ConfirmFurtherCommunicationSubmitApplication");

        public SubmitApplicationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationSubmittedPage ConfirmAllAnswersAndSubmitApplication()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ConfirmSubmitApplication));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ConfirmFurtherInfoSubmitApplication));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ConfirmFurtherCommunicationSubmitApplication));
            Continue();
            return new ApplicationSubmittedPage(_context);
        }
    }
}
