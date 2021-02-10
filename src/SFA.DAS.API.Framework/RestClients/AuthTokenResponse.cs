using Newtonsoft.Json;

namespace SFA.DAS.API.Framework.RestClients
{
    public class AuthTokenResponse
    {
        [JsonProperty("token_type")]
        public string Token_type { get; set; }

        [JsonProperty("expires_in")]
        public string Expires_in { get; set; }

        [JsonProperty("ext_expires_in")]
        public string Ext_expires_in { get; set; }

        [JsonProperty("expires_on")]
        public string Expires_on { get; set; }

        [JsonProperty("not_before")]
        public string Not_before { get; set; }

        [JsonProperty("resource")]
        public string resource { get; set; }

        [JsonProperty("access_token")]
        public string Access_token { get; set; }
    }
}
