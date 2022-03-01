using System;
namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    public class BaseSteps
    {
        protected DateTime? ParseMonth(string relativeMonth)
        {
            var utcNow = DateTime.UtcNow;

            return !string.IsNullOrEmpty(relativeMonth)
                ? int.TryParse(relativeMonth, out int parsedRelativeMonth)
                    ? new DateTime(utcNow.Year, utcNow.Month, 1).AddMonths(parsedRelativeMonth)
                    : throw new Exception($"Unable to parse {nameof(relativeMonth)}:{relativeMonth} to int")
                : (DateTime?)null;
        }
    }
}
