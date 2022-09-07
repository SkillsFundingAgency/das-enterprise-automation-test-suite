namespace SFA.DAS.API.Framework.RestClients;

public readonly record struct InnerApiOAuthModel
{
    public readonly record struct KeyValuePair(string Key, string Value)
    {
        public override string ToString() => $"{Key}={Value}";

    }

    public KeyValuePair ClientId { get; init; }

    public KeyValuePair ClientSecrets { get; init; }

    public static KeyValuePair Granttype => new("grant_type", "client_credentials");

    public KeyValuePair Resource { get; init; }

    public InnerApiOAuthModel(string clientId, string clientSecret, string resource)
    {
        ClientId = new KeyValuePair("client_id", clientId);
        ClientSecrets = new KeyValuePair("client_secret", clientSecret);
        Resource = new KeyValuePair("resource", resource);
    }

    public override string ToString() => $@"{ClientId}&{ClientSecrets}&{Granttype}&{Resource}";
}
