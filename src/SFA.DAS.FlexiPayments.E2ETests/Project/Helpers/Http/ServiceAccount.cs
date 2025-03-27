using System.Text.Json.Serialization;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.Http
{
    public class ServiceAccount
    {
        [JsonPropertyName("sub")]
        public string? Sub { get; set; }
    }

}
