using System;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers
{
    public class ConsolidateSupportDataHelper
    {
        public string SubmitAsNewComments => "Comment - Submit as New";

        public string SubmitAsOpenComments => "Comment - Submit as Open";

        public string SubmitAsPendingComments => "Comment - Submit as Pending";

        public string SubmitAsOnHoldComments => "Comment - Submit as On-Hold";

        public string SubmitAsSolvedComments => "Comment - Submit as Solved";

        public string Subject => $"Zendesk UI Testing";

        public string CommentBody => $"Created on";

        public string OrganisationName { get; set; }

        public string OrganisationUserName { get; set; }
    }
}
