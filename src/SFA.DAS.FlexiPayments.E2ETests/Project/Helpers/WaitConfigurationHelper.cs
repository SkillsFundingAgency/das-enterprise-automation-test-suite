using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers
{
    public static class WaitConfigurationHelper
    {
        public class WaitHelper
        {
            private static WaitConfiguration Config => new WaitConfiguration();

            public static async Task WaitForIt(Func<bool> lookForIt, string failText)
            {
                var endTime = DateTime.Now.Add(Config.TimeToWait);

                while (DateTime.Now <= endTime)
                {
                    if (lookForIt()) return;

                    await Task.Delay(Config.TimeToPause);
                }

                Assert.Fail($"{failText}  Time: {DateTime.Now:G}.");
            }

            public static async Task WaitForUnexpected(Func<bool> findUnexpected, string failText)
            {
                var endTime = DateTime.Now.Add(Config.TimeToWait);
                while (DateTime.Now < endTime)
                {
                    if (findUnexpected())
                    {
                        Assert.Fail($"{failText} Time: {DateTime.Now:G}.");
                    }

                    await Task.Delay(Config.TimeToPause);
                }
            }

            public class WaitConfiguration
            {
                public TimeSpan TimeToWait { get; set; } = TimeSpan.FromMinutes(1);
                public TimeSpan TimeToPause { get; set; } = TimeSpan.FromMilliseconds(10);
            }
        }
    }
}
