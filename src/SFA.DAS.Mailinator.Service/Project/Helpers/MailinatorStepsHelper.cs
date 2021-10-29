using SFA.DAS.Mailinator.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Mailinator.Service.Project.Helpers
{
    public class MailinatorStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        private readonly string _email;

        public MailinatorStepsHelper(ScenarioContext context, string email)
        {
            _context = context;
            _tabHelper = context.Get<TabHelper>();
            _email = email;
        }

        public void VerifyAccessCode(string code) => OpenEmail().VerifyAccessCode(code);

        public void OpenLink(string linktext)
        {
            var page = OpenEmail();

            _tabHelper.OpenInNewTab(() => page.OpenLink(linktext));
        }

        private MailinatorEmailPage OpenEmail()
        {
            _tabHelper.OpenInNewTab("https://www.mailinator.com/");

            return new MailinatorLandingPage(_context).EnterEmailAndClickOnGoButton(_email).OpenEmail();
        }
    }
}
