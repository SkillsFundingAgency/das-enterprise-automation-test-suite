using System;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class ScreenShotTitleGenerator
    {
        private int count;

        public ScreenShotTitleGenerator(int start)
        {
            count = start;
        }

        public string GetNextCount()
        {
            return $"{(++count).ToString("D2")}_{DateTime.Now:fffff}";
        }
    }
}
