using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class RegistrationDatahelpers
    {
        public RegistrationDatahelpers(string gatewayUsername, string password, string domainName)
        {
            RandomEmail = $"{gatewayUsername}@{domainName}";
            Password = password;
        }

        public string RandomEmail { get; }

        public string Password { get; }
    }
}
