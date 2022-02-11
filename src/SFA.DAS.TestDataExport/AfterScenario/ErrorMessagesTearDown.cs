using SFA.DAS.ConfigurationBuilder;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class ErrorMessagesTearDown
    {
        private readonly ScenarioContext _context;

        public ErrorMessagesTearDown(ScenarioContext context) => _context = context;

        [AfterScenario(Order = 102)]
        public void ReportErrorMessages()
        {
            if (_context.TestError != null) throw new Exception(string.Join(Environment.NewLine, _context.Get<ObjectContext>().GetAfterScenarioExceptions().Select(x => x?.Message)));
        }
    }
}