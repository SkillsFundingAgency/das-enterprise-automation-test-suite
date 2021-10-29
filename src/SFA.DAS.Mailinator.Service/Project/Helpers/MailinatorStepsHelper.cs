using SFA.DAS.Mailinator.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Mailinator.Service.Project.Helpers
{

    public class MailinatorStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;

        public MailinatorStepsHelper(ScenarioContext context)
        {
            _context = context;
            _tabHelper = context.Get<TabHelper>();
        }

        public void VerifyAccessCode(string email, string code)
        {
            _tabHelper.OpenInNewTab(UrlConfig.Mailinator_BaseUrl);

            new MailinatorLandingPage(_context).EnterEmailAndClickOnGoButton(email)
                .ClickOnEmail()
                .VerifyAccessCode(code);
        }

        public void VerifyLink(string email)
        {
            _tabHelper.OpenInNewTab(UrlConfig.Mailinator_BaseUrl);

            new MailinatorLandingPage(_context)
                .EnterEmailAndClickOnGoButton(email)
                .ClickOnEmail()
                .VerifyEmailLink();
        }

    }
}
