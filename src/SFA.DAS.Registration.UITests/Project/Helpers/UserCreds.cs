namespace SFA.DAS.Registration.UITests.Project.Helpers;

public class UserCreds
{
    internal UserCreds(string emailaddress, string password, int userIndex)
    {
        EmailAddress = emailaddress;
        IdOrUserRef = password;
        UserIndex = userIndex;
        AccountDetails = [];
    }

    public string EmailAddress { get; private set; }
    public string IdOrUserRef { get; private set; }
    internal int UserIndex { get; private set; }

    public List<AccountDetails> AccountDetails { get; private set; }

    public override string ToString() => $"Email address:'{EmailAddress}', IdOrUserRef:'{IdOrUserRef}'{GetAccountDetails()}";

    private string GetAccountDetails() => AccountDetails.Count == 0 ? string.Empty : $",{Environment.NewLine}{string.Join(Environment.NewLine, AccountDetails.Select(a => a.ToString()))}";
}