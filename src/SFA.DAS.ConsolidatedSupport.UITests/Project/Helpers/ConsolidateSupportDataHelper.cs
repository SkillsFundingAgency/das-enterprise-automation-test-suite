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

        public string NewUserFullName => "JackReacher";

        public string NewUserEmail => $"{NewUserFullName}@{NewOrgDomain}";

        public string NewOrgName => "TestOrgJackReacher";

        public string NewOrgDomain => "TestOrgJackReacher.com";

        public string Type => "Employer";

        public string Status => "Active";

        public string AccountManagerStatus => "National Account Managed";

        public string AddressLine1 => "Cheylesmore House";

        public string AddressLine2 => "5";

        public string AddressLine3 => "Quinton Road";

        public string City => "Coventry";

        public string County => "West Midlands";

        public string Postcode => "CV1 2WT";
    }
}
