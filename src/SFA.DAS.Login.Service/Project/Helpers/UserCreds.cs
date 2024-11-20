using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Login.Service.Project.Helpers;

public class UserCreds(string emailaddress, string password, int userIndex)
{
    public string EmailAddress { get; private set; } = emailaddress;

    public string IdOrUserRef { get; private set; } = password;

    internal int UserIndex { get; private set; } = userIndex;

    public List<AccountDetails> AccountDetails { get; private set; } = [];

    public override string ToString() => $"Email address:'{EmailAddress}', IdOrUserRef:'{IdOrUserRef}'{GetAccountDetails()}";

    private string GetAccountDetails() => AccountDetails.Count == 0 ? string.Empty : $",{Environment.NewLine}{string.Join(Environment.NewLine, AccountDetails.Select(a => a.ToString()))}";
}