using SFA.DAS.MailinatorAPI.Service.Project.Helpers;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.MailinatorAPI.Service.Project;

[Binding, Scope(Tag = "testinator")]
public class Hooks
{
    private readonly ScenarioContext _context;
    private MailinatorApiHelper mailinatorApiHelper;
    private readonly TryCatchExceptionHelper _tryCatch;

    public Hooks(ScenarioContext context)
    {
        _context = context;
        _tryCatch = context.Get<TryCatchExceptionHelper>();
    }

    [BeforeScenario(Order = 12)]
    public void SetUpMailinatorApiHelpers() => _context.Set(mailinatorApiHelper = new MailinatorApiHelper(_context));

    [AfterScenario(Order = 22)]
    public void DeleteMessages()
    {
        if (_context.TestError != null) _tryCatch.AfterScenarioException(() => mailinatorApiHelper.DeleteInbox());
    }
}
