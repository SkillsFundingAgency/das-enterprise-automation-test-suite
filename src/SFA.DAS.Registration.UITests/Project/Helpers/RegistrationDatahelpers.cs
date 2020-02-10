namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class RegistrationDatahelpers
    {
        public RegistrationDatahelpers(string gatewayUsername, string password)
        {
            RandomEmail = $"{gatewayUsername}@gmail.com";
            Password = password;
        }

        public string RandomEmail { get; }
        public string Password { get; }
        public string CompanyTypeOrg => "AUTOMATION & OPTIMISATION LTD";
        public string PublicSectorTypeOrg => "Royal School Hampstead";
        public string CharityTypeOrg => "ALLHALLOWS CHARITY";
    }
}
