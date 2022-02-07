namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class UserCreds
    {
        internal UserCreds(string emailaddress, string password, string orgName, int index)
        {
            EmailAddress = emailaddress;
            Password = password;
            OrgName = orgName;
            Index = index;
        }

        public string EmailAddress { get; private set; }
        public string Password { get; private set; }
        public string OrgName { get; internal set; }
        internal int Index { get; private set; }
        public string AccountId { get; internal set; }
        public string HashedId { get; internal set; }
        public string PublicHashedid { get; internal set; }


        public override string ToString() =>
            $"Email address:'{EmailAddress}', " +
            $"Password:'{Password}', " +
            $"Organisation Name:'{OrgName}', " +
            $"AccountId:'{AccountId}', " +
            $"HashedId:'{HashedId}', " +
            $"PublicHashedId:'{PublicHashedid}'";
    }
}
