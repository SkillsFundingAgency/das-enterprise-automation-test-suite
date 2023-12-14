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

        internal static string InternalNote => "Internal note";

        internal static string PublicReply => "Public reply";

        internal static string SubmitAsWaitingForIncNum => $"{Comment} waiting for service incident number";

        internal static string SubmitAsNewComments => $"{Comment} New";

        internal static string SubmitAsOpenComments => $"{Comment} Open";

        internal static string SubmitAsPendingComments => $"{Comment} Pending";

        internal static string SubmitAsOnHoldComments => $"{Comment} On-Hold";

        internal static string SubmitAsSolvedComments => $"{Comment} Solved";

        internal string Subject { get; }

        internal string CommentBody { get; }

        internal string OrganisationName { get; set; }

        internal string OrganisationUserName { get; set; }

        internal static string NewUserFullName => "JackReacher";

        internal static string NewUserEmail => $"{NewUserFullName}@{NewOrgDomain}";

        internal static string NewOrgNameWithOutSuffix => $"TestOrgJackReacher";

        internal string NewOrgName => $"{NewOrgNameWithOutSuffix}{_suffix}";

        internal static string NewOrgDomain => "TestOrgJackReacher.com";

        internal static string Type => "Employer";

        internal static string Status => "Active";

        internal static string AccountManagerStatus => "National Account Managed";

        internal static string AddressLine1 => "Cheylesmore House";

        internal static string AddressLine2 => "5";

        internal static string AddressLine3 => "Quinton Road";

        internal static string City => "Coventry";

        internal static string County => "West Midlands";

        internal static string Postcode => "CV1 2WT";
    }
}
