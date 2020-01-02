using System;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAODataHelper
    {
        public EPAODataHelper()
        {
            GetCurrentDay = DateTime.Now.Day;
            GetCurrentMonth = DateTime.Now.Month;
            GetCurrentYear = DateTime.Now.Year;
        }

        public int GetCurrentDay { get; }

        public int GetCurrentMonth { get; }

        public int GetCurrentYear { get; }
    }
}
