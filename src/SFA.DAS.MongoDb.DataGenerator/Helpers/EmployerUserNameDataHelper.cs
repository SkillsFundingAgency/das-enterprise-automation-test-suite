using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public class EmployerUserNameDataHelper : BaseDataHelper
    {
        public EmployerUserNameDataHelper(string[] tags)
        {
            LevyOrNonLevy = tags.Contains("addlevyfunds") || tags.Contains("addtransferslevyfunds") ? "LE" : "NL";

            UserNamePrefix = tags.Any(x => x.ContainsCompareCaseInsensitive("perftest")) ? "PerfTest" : tags.Contains("providerleadregistration") ? "Plr" : "Test";
            EmpRefDigits = DateTimeToNanoSeconds;
            
            GatewayUsername = GenerateRandomUserName();
            GatewayPassword = "password";
        }

        public string LevyOrNonLevy { get; }

        public string EmpRefDigits { get; }

        public string GatewayUsername { get; }

        public string GatewayPassword { get; }

        private string GenerateRandomUserName() => $"{LevyOrNonLevy}_{UserNamePrefix}_{NextNumber}_{DateTimeToSeconds}{EmpRefDigits}";
    }
}
