using System;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers
{
    public class ConsolidateSupportDataHelper
    {
        public string Subject => $"Zendesk UI Testing";// $"Zendesk UI Testing - {Guid.NewGuid()}";

        public string CommentBody => $"Created on"; // $"Created on {DateTime.Now}";
    }
}
