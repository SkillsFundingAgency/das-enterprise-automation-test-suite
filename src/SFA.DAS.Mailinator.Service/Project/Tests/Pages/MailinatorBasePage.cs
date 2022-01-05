using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Mailinator.Service.Project.Tests.Pages
{
    public abstract class MailinatorBasePage : VerifyBasePage
    {
        protected MailinatorBasePage(ScenarioContext context, bool verifyPage = true) : base(context) { if (verifyPage) VerifyPage(); }
    }
}
