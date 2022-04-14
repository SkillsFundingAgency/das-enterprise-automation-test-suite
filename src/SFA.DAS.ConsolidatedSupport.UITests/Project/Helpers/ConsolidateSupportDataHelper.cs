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

        public string SubmitAsNewComments => $"{Comment} New";

        public string SubmitAsOpenComments => $"{Comment} Open";

        public string SubmitAsPendingComments => $"{Comment} Pending";

        public string SubmitAsOnHoldComments => $"{Comment} On-Hold";

        public string SubmitAsSolvedComments => $"{Comment} Solved";

        public string Subject { get; }

        public string CommentBody { get; }

        public string OrganisationName { get; set; }

        public string OrganisationUserName { get; set; }

        public string NewUserFullName => "JackReacher";

        public string NewUserEmail => $"{NewUserFullName}@{NewOrgDomain}";

        public string NewOrgNameWithOutSuffix => $"TestOrgJackReacher";

        public string NewOrgName => $"{NewOrgNameWithOutSuffix}{_suffix}";

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
