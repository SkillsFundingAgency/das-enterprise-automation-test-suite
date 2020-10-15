using System;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers
{
    public class ConsolidateSupportDataHelper
    {
        public ConsolidateSupportDataHelper()
        {
            Subject = $"Zendesk UI Testing {Guid.NewGuid()}";
            CommentBody = $"Created on {DateTime.Now}";
        }

        public string SubmitAsNewComments => "Comment - Submit as New";

        public string SubmitAsOpenComments => "Comment - Submit as Open";

        public string SubmitAsPendingComments => "Comment - Submit as Pending";

        public string SubmitAsOnHoldComments => "Comment - Submit as On-Hold";

        public string SubmitAsSolvedComments => "Comment - Submit as Solved";

        public string Subject { get; }

        public string CommentBody { get; }

        public string OrganisationName { get; set; }

        public string OrganisationUserName { get; set; }
    }
}
