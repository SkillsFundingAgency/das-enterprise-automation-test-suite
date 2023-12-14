using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers
{
    public class ConsolidateSupportDataHelper
    {
        private readonly string _suffix;

        private static readonly string CanBeDeleted = "Can Be Deleted";

        public ConsolidateSupportDataHelper()
        {
            _suffix = DateTime.Now.ToSeconds();

            Subject = $"Zendesk UI Testing {CanBeDeleted} {Guid.NewGuid()}_{_suffix}";

            CommentBody = $"{CanBeDeleted} created on {_suffix}";
        }

        private static readonly string Comment = $" {CanBeDeleted}, Comment - Submit as";

        internal string InternalNote => "Internal note";

        internal string PublicReply => "Public reply";

        internal string SubmitAsWaitingForIncNum => $"{Comment} waiting for service incident number";

        internal string SubmitAsNewComments => $"{Comment} New";

        internal string SubmitAsOpenComments => $"{Comment} Open";

        internal string SubmitAsPendingComments => $"{Comment} Pending";

        internal string SubmitAsOnHoldComments => $"{Comment} On-Hold";

        internal string SubmitAsSolvedComments => $"{Comment} Solved";

        internal string Subject { get; }

        internal string CommentBody { get; }

        internal string OrganisationName { get; set; }

        internal string OrganisationUserName { get; set; }

        internal string NewUserFullName => "JackReacher";

        internal string NewUserEmail => $"{NewUserFullName}@{NewOrgDomain}";

        internal string NewOrgNameWithOutSuffix => $"TestOrgJackReacher";

        internal string NewOrgName => $"{NewOrgNameWithOutSuffix}{_suffix}";

        internal string NewOrgDomain => "TestOrgJackReacher.com";

        internal string Type => "Employer";

        internal string Status => "Active";

        internal string AccountManagerStatus => "National Account Managed";

        internal string AddressLine1 => "Cheylesmore House";

        internal string AddressLine2 => "5";

        internal string AddressLine3 => "Quinton Road";

        internal string City => "Coventry";

        internal string County => "West Midlands";

        internal string Postcode => "CV1 2WT";
    }
}
