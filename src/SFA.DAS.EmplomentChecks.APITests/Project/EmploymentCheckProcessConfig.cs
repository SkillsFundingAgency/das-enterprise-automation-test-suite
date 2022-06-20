namespace SFA.DAS.EmploymentChecks.APITests.Project
{
    public class EmploymentCheckProcessConfig
    {
        public string EC_ServiceBusConnectionString { get; set; }
        public string EC_ApiStubBaseUrl { get; set; }
        public string LearningTransportStorageDirectory { get; set; }
        public string EC_FunctionsBaseUrl { get; set; }
        public string EC_FunctionsAuthenticationCode { get; set; }
    }
}
