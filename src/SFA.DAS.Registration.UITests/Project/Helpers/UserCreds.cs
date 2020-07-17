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
        public string OrgName { get; private set; }
        internal int Index { get; private set; }
        public string Accountid { get; internal set; }

        public override string ToString() => $"Email address:{Reporttestdata(Accountid)}, Password:'{Password}', Organisation Name:'{OrgName}'";

        private string Reporttestdata(string accid) => string.IsNullOrEmpty(accid) ? $"'{EmailAddress}'" : $"{EmailAddress},{accid}";
    }
}
