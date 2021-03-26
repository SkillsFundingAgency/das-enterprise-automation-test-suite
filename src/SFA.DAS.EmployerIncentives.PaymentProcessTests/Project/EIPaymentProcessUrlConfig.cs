using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project
{
    public static class EIPaymentProcessUrlConfig
    {
        public static string EI_PaymentsAppBaseUrl => $"https://das-{EnvironmentConfig.EnvironmentName}-empinc-pay-fa.azurewebsites.net";

        public static string EI_ApiStubBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-stub.apprenticeships.education.gov.uk/";
    }
}
