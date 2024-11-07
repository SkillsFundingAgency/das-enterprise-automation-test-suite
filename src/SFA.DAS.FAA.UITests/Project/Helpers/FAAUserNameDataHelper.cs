namespace SFA.DAS.FAA.UITests.Project.Helpers
{
    public class FAAUserNameDataHelper : BaseDataHelper
    {
        public FAAUserNameDataHelper(string emailDomain)
        {
            UserNamePrefix = "FaaUser";
            FaaNewUserEmail = $"{UserNamePrefix}_{NextNumber}_{DateTimeToSeconds}{DateTimeToNanoSeconds}@{emailDomain}";
            FaaNewUserPassword = $"{Guid.NewGuid()}";

            var randomPersonNameHelper = new RandomPersonNameHelper();

            FirstName = randomPersonNameHelper.FirstName;
            LastName = randomPersonNameHelper.LastName;
        }

        public string FaaNewUserEmail { get; }

        public string FaaNewUserPassword { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string FaaNewUserMobilePhone { get; init; } = $"07{RandomDataGenerator.GenerateRandomNumber(9)}";

        public DateTime FaaNewUserDob { get; init; } = new(RandomDataGenerator.GenerateRandomDobYear(), RandomDataGenerator.GenerateRandomMonth(), RandomDataGenerator.GenerateRandomDateOfMonth());

        public string FaaNewUserPostCode { get; init; } = RandomDataGenerator.RandomPostCode();
    }
}
