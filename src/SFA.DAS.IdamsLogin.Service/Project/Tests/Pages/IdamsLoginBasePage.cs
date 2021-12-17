using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages
{
    public abstract class IdamsLoginBasePage : VerifyBasePage
    {
        
        protected IdamsLoginBasePage(ScenarioContext context, bool verifypage = true): base(context)
        {
            if (verifypage) VerifyPage();
        }
    }
}
