using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class AccountDetails
    {
        internal int AccountIndex { get; private set; }
        public string OrgName { get; private set; }
        public string AccountId { get; private set; }
        public string HashedId { get; private set; }
        public string PublicHashedid { get; internal set; }

        internal AccountDetails(string accountId, string hashedId, string orgName, string publicHashedId, int index)
        {
            AccountIndex = index;
            AccountId = accountId;
            HashedId = hashedId;
            OrgName = orgName;
            PublicHashedid = publicHashedId;
        }

        public override string ToString() => $"AccountDetails ({AccountIndex}) : Organisation Name : '{OrgName}', AccountId : '{AccountId}', HashedId : '{HashedId}', PublicHashedId : '{PublicHashedid}'";
    }

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
}