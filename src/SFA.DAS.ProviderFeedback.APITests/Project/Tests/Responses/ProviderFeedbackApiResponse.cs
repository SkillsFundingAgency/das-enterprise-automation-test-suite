namespace SFA.DAS.ProviderFeedback.APITests.Project.Tests.Responses
{
    public class ProviderFeedbackApiResponse
    {
        public ProviderFeedback ProviderFeedback { get; set; }
    }

    public class ProviderFeedback
    {
        public string ProviderId { get; set; }
        public EmployerFeedback EmployerFeedback { get; set; }
        public ApprenticeFeedback ApprenticeFeedback { get; set; }
    }

    public class EmployerFeedback
    {
        public int TotalEmployerResponses { get; set; }
        public int TotalFeedbackRating { get; set; }
    }
    public class ApprenticeFeedback
    {
        public int TotalApprenticeResponses { get; set; }
        public int TotalFeedbackRating { get; set; }  
    }
}
