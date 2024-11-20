namespace SFA.DAS.Login.Service.Project.Helpers;

public class AccountDetails
{
    internal int AccountIndex { get; private set; }
    public string OrgName { get; private set; }
    public string AccountId { get; private set; }
    public string HashedId { get; private set; }
    public string PublicHashedid { get; private set; }
    public string Alename { get; private set; }
    public string Aleid { get; private set; }
    public string AleAccountid { get; private set; }
    public string AleAgreementid { get; private set; }

    public AccountDetails(int index, string accountId, string hashedId, string orgName, string publicHashedId, string alename, string aleid, string aleAccountid, string aleAgreementid)
    {
        AccountIndex = index;
        AccountId = accountId;
        HashedId = hashedId;
        OrgName = orgName;
        PublicHashedid = publicHashedId;
        Alename = alename;
        Aleid = aleid;
        AleAccountid = aleAccountid;
        AleAgreementid = aleAgreementid;
    }

    public override string ToString() => $@"AccountDetails ({AccountIndex}) : Organisation Name : '{OrgName}', AccountId : '{AccountId}', HashedId : '{HashedId}', PublicHashedId : '{PublicHashedid}', 
                                                Alename : '{Alename}', Aleid : '{Aleid}', AleAccountid : '{AleAccountid}', AleAgreementid : '{AleAgreementid}'";
}
