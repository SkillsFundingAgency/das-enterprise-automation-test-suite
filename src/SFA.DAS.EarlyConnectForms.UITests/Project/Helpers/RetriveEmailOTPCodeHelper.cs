using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Helpers
{
    public class RetriveEmailOTPCodeHelper
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;

        public RetriveEmailOTPCodeHelper(ScenarioContext context)
        {
            _context = context;
            _tabHelper = context.Get<TabHelper>();
        }

        public string GetOPT()
        {
            var email = _context.Get<EarlyConnectDataHelper>().Email;
            _tabHelper.OpenInNewTab(_context.Get<MailosaurApiHelper>().GetCodeInEmail(email, "Confirm your email address – Department for education", "Your confirmation code is:"));
            return email;
        }
    }
}
