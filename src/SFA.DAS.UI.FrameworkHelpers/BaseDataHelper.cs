using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public abstract class BaseDataHelper
    {
        protected BaseDataHelper()
        {
            var dateTime = DateTime.Now;
            DateTimeToSeconds = dateTime.ToSeconds();
            DateTimeToNanoSeconds = dateTime.ToNanoSeconds();
            NextNumber = NextNumberGenerator.GetNextCount();
        }

        public string UserNamePrefix { get; protected set; }

        public int NextNumber { get; }

        protected string DateTimeToSeconds { get; }

        protected string DateTimeToNanoSeconds { get; }

    }
}
