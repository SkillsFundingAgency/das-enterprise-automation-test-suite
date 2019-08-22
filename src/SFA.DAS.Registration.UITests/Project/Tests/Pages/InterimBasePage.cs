using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public abstract class InterimBasePage : Navigate
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InterimBasePage(ScenarioContext context) : base(context)
        {

        }

        public HomePage GoToHomePage()
        {
            return new HomePage(_context, true);
        }

        public HomePage GoToHomePageUsingUrl()
        {
            return new HomePage(_context, true);
        }

        public HomePage HomePage()
        {
            return new HomePage(_context);
        }

        public AboutYourAgreementPage AboutYourAgreementPage()
        {
            return new AboutYourAgreementPage(_context);
        }

        public AboutYourAgreementPage GoToAboutYourAgreementPage()
        {
            return new AboutYourAgreementPage(_context, true);
        }
    }
}