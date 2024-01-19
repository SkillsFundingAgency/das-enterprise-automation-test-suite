using SFA.DAS.MailinatorAPI.Service.Project.Helpers;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.MailinatorAPI.Service.Project;

[Binding, Scope(Tag = "testinator")]
public class Hooks(ScenarioContext context)
{
    private MailinatorApiHelper mailinatorApiHelper;
    private readonly TryCatchExceptionHelper _tryCatch = context.Get<TryCatchExceptionHelper>();

    [BeforeScenario(Order = 12)]
    public void SetUpMailinatorApiHelpers() => context.Set(mailinatorApiHelper = new MailinatorApiHelper(context, true));

    [AfterScenario(Order = 22)]
    public void DeleteMessages()
    {
        if (context.TestError != null) _tryCatch.AfterScenarioException(() => mailinatorApiHelper.DeleteInbox());
    }
}
