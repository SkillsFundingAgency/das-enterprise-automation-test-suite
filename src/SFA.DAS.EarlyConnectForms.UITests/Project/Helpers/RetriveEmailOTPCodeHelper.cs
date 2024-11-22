using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Helpers
{
    public class RetriveEmailOTPCodeHelper(ScenarioContext context)
    {
        public string AuthCode { get; set; }

        public string GetOPT()
        {
            var email = context.Get<EarlyConnectDataHelper>().Email;
            AuthCode = context.Get<MailosaurApiHelper>().GetCodeInEmail(email, "Confirm your email address – Department for education", "Your confirmation code is:");
            return AuthCode;
        }
    }
}
