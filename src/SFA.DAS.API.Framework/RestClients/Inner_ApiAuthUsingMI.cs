
namespace SFA.DAS.API.Framework.RestClients;

public class Inner_ApiAuthUsingMI : IInner_ApiGetAuthToken
{
    private readonly Inner_ApiAuthConfigUsingMI _config;

    private string AccessToken;

    private DateTime AcquiredTime;

    public Inner_ApiAuthUsingMI(Inner_ApiAuthConfigUsingMI config) 
    {
        _config = config;
        AccessToken = string.Empty;
        AcquiredTime = DateTime.MinValue;
    } 

    public (string tokenType, string accessToken) GetAuthToken() 
    {
        if (string.IsNullOrEmpty(AccessToken) || (DateTime.Now > AcquiredTime.AddMinutes(50)))
        {
            AccessToken = AzureTokenService.GetAppServiceAuthToken(_config.GetResource());
            AcquiredTime = DateTime.Now;
        }

        return ("Bearer", AccessToken);
    } 
}
