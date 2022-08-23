namespace SFA.DAS.API.Framework.Configs;

public abstract class Inner_ApiBaseAuthConfig
{
    protected abstract string AppServiceName { get; }

    public string Tenant { get; set; }

    public string GetResource() => UriHelper.GetAbsoluteUri($"https://{Tenant}", AppServiceName);
}
