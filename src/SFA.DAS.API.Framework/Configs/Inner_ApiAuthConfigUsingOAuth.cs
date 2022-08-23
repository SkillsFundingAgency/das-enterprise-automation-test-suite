namespace SFA.DAS.API.Framework.Configs;

public abstract class Inner_ApiAuthConfigUsingOAuth : Inner_ApiBaseAuthConfig
{
    public string ClientId { get; set; }

    public string ClientSecrets { get; set; }

    public static string GrantType => "client_credentials";
}
