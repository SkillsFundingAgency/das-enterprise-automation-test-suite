using SFA.DAS.FrameworkHelpers;
using System;
using System.Linq;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public class DataHelper
    {
        private readonly DateTime _dateTime;

        public DataHelper(string[] tags)
        {
            LevyOrNonLevy = tags.Contains("addlevyfunds") || tags.Contains("addtransferslevyfunds") ? "LE" : "NL";

            UserNamePrefix = tags.Any(x => x.ContainsCompareCaseInsensitive("perftest")) ? "PerfTest" : tags.Contains("providerleadregistration") ? "Plr" : "Test";
            _dateTime = DateTime.Now;
            EmpRefDigits = _dateTime.ToNanoSeconds();
            NextNumber = NextNumberGenerator.GetNextCount();
            GatewayUsername = GenerateRandomUserName();
            GatewayPassword = "password";
        }

        public string LevyOrNonLevy { get; }

        public string EmpRefDigits { get; }

        public int NextNumber { get; }

        public string GatewayUsername { get; }

        public string GatewayPassword { get; }

        private string UserNamePrefix { get; }

        private string GenerateRandomUserName() => $"{LevyOrNonLevy}_{UserNamePrefix}_{NextNumber}_{_dateTime.ToSeconds()}{EmpRefDigits}";        
    }
}
