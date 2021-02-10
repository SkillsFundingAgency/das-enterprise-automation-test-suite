using System;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers.Requests
{
    public class SubmitIncentiveApplicationRequest
    {
        public Guid IncentiveApplicationId { get; set; }
        public long AccountId { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string SubmittedByEmail { get; set; }
        public string SubmittedByName { get; set; }
    }
}
