using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.MailosaurAPI.Service;

[Binding, Scope(Tag = "mailosaur")]
public class Hooks(ScenarioContext context)
{
    private MailosaurApiHelper mailosaurApiHelper;
    private readonly TryCatchExceptionHelper _tryCatch = context.Get<TryCatchExceptionHelper>();

    [BeforeScenario(Order = 12)]
    public void SetUpMailosaurApiHelper() => context.Set(mailosaurApiHelper = new MailosaurApiHelper(context));

}