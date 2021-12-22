using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Helpers
{
    public class OrchestratorStatusResponse
    {
        public string RuntimeStatus { get; set; }
        public string CustomStatus { get; set; }
        public string Output { get; set; }
    }
}
