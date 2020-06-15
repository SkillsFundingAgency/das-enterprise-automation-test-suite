using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages
{
    public abstract class IdamsLoginBasePage : BasePage
    {
        protected readonly FormCompletionHelper formCompletionHelper;

        protected IdamsLoginBasePage(ScenarioContext context, bool verifypage = true): base(context)
        {
            formCompletionHelper = context.Get<FormCompletionHelper>();
            if (verifypage) VerifyPage();
        }
    }
}
