using SFA.DAS.Mailinator.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers
{
    internal class AEDMailinatorStepsHelper
    {
        private readonly ScenarioContext _context;

        internal AEDMailinatorStepsHelper(ScenarioContext context) => _context = context;

        internal void OpenLink(string organisationEmailAddress) => new MailinatorStepsHelper(_context, organisationEmailAddress).OpenLink("https://");
    }
}
