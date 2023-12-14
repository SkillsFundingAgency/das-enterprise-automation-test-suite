using NUnit.Framework;
using System.Threading.Tasks;

namespace SFA.DAS.FrameworkHelpers;

public static class WaitConfigurationHelper
{
    public class WaitHelper
    {
        private static WaitConfiguration Config => new();

        public static async Task WaitForIt(Func<bool> lookForIt, string textMessage)
        {
            var endTime = DateTime.Now.Add(Config.TimeToWait);

            int retryCount = 0;

            while (DateTime.Now <= endTime)
            {
                if (lookForIt()) return;

                TestContext.Progress.WriteLine($"Retry {retryCount++} - Waiting for the sql query to return valid data - '{textMessage}'");

                await Task.Delay(WaitConfiguration.TimeToPoll(retryCount));
            }
        }

        public class WaitConfiguration
        {
            public TimeSpan TimeToWait { get; set; } = TimeSpan.FromMinutes(5);
            public static TimeSpan TimeToPoll(int x) => TimeSpan.FromSeconds(5 * x);
        }
    }
}
