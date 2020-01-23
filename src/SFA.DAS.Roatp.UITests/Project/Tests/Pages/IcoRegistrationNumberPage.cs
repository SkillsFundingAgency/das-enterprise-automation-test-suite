using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class IcoRegistrationNumberPage : RoatpBasePage
    {
        protected override string PageTitle => "What is your organisation's Information Commissioner's Office (ICO) registration number?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By IcoNumberField => By.Id("YO-30");

        public IcoRegistrationNumberPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WebsitePage EnterIcoRegistrationNumberAndContinue()
        {
            formCompletionHelper.EnterText(IcoNumberField, applydataHelpers.IocNumber);
            Continue();
            return new WebsitePage(_context);
        }
    }
}
