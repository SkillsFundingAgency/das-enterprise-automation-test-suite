
namespace SFA.DAS.API.Framework.RestClients;

public interface IInner_ApiGetAuthToken
{
    public (string tokenType, string accessToken) GetAuthToken();
}
