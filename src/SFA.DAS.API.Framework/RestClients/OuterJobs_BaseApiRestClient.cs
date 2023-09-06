namespace SFA.DAS.API.Framework.RestClients;

public abstract class OuterJobs_BaseApiRestClient : Outer_BaseApiRestClient
{
    protected override string ApiName => "/api";

    public OuterJobs_BaseApiRestClient(ObjectContext objectContext, string code) : base(objectContext, code)
    {

    }

    protected override void AddAuthHeaders() { }

    protected override void AddParameter() => restRequest.AddParameter("code", ApiAuthKey, ParameterType.QueryString);
}
