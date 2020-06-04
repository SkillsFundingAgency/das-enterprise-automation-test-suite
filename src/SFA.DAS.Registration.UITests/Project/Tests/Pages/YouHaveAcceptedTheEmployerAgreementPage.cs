using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YouHaveAcceptedTheEmployerAgreementPage : RegistrationBasePage
    {
        protected override string PageTitle => "You’ve accepted the employer agreement";
        private readonly ScenarioContext _context;

        protected override By ContinueButton => By.LinkText("View your account");
        private By DownloadYourAcceptedAgreementLink => By.LinkText("Download your accepted agreement");

        public YouHaveAcceptedTheEmployerAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
            VerifyPage(DownloadYourAcceptedAgreementLink);
        }

        public HomePage ClickOnViewYourAccountButton()
        {
            formCompletionHelper.Click(ContinueButton);
            return new HomePage(_context);
        }
    }
}
