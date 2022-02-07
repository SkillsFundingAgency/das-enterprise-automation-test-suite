using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class AccountDetails
    {
        public string OrgName { get; internal set; }
        internal int AccountIndex { get; private set; }
        public string AccountId { get; internal set; }
        public string HashedId { get; internal set; }
        public string PublicHashedid { get; internal set; }
    }

    public class UserCreds
    {
        internal UserCreds(string emailaddress, string password, string orgName, int userIndex)
        {
            EmailAddress = emailaddress;
            Password = password;
            OrgName = orgName;
            UserIndex = userIndex;
        }

        public string EmailAddress { get; private set; }
        public string Password { get; private set; }
        public string OrgName { get; internal set; }
        internal int UserIndex { get; private set; }

        public List<AccountDetails> AccountDetails { get; private set; }

        public override string ToString() => 
            $"Email address:'{EmailAddress}', Password:'{Password}', {Environment.NewLine}" +
            $"{string.Join(Environment.NewLine, AccountDetails.Select(a => $"AccountDetails ({a.AccountIndex}) : Organisation Name : '{a.OrgName}', AccountId : '{a.AccountId}', HashedId : '{a.HashedId}', PublicHashedId : '{a.PublicHashedid}'"))}";    
    }
}