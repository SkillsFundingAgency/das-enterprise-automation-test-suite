using SFA.DAS.Configuration;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class ErrorMessagesTearDown
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public ErrorMessagesTearDown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [AfterScenario(Order = 14)]
        public void ReportErrorMessages()
        {
            var exception = _context.TestError;

            if (exception != null)
            {
                var messages = new List<string>();

                messages.AddRange(_objectContext.GetAfterScenarioExceptions().Select(x => x.Message));

                var url = _objectContext.GetUrl();

                if (url != string.Empty)
                {
                    messages.Add($"Url : {url}");
                }

                throw new Exception(string.Join(Environment.NewLine, messages));
            }
        }
    }
}
