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
    }
}
