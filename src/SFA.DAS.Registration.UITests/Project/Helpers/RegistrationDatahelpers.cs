using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class RegistrationDatahelpers
    {
        public RegistrationDatahelpers(string gatewayUsername, string domainName)
        {
            RandomEmail = $"{gatewayUsername}@{domainName}";
        }

        public string RandomEmail { get; }
    }
}
