using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;
using System.Threading.Tasks;

namespace SFA.DAS.MailosaurAPI.Service;

[Binding]
public class Hooks(ScenarioContext context)
{
    private MailosaurApiHelper mailosaurApiHelper;

    private readonly TryCatchExceptionHelper _tryCatch = context.Get<TryCatchExceptionHelper>();

    [BeforeScenario(Order = 12)]
    public void SetUpMailosaurApiHelper() => context.Set(mailosaurApiHelper = new MailosaurApiHelper(context));

    [AfterScenario(Order = 22)]
    public async Task DeleteMessages()
    {
        if (context.TestError == null) await Task.Run(() => _tryCatch.AfterScenarioException(async () => await mailosaurApiHelper.DeleteInbox()));
    }
}