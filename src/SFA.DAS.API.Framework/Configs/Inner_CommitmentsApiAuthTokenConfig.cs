namespace SFA.DAS.API.Framework.Configs;

public class Inner_CommitmentsApiAuthTokenConfig : Inner_ApiAuthConfigUsingOAuth
{
    protected override string AppServiceName => "das-commitments-api";
}
