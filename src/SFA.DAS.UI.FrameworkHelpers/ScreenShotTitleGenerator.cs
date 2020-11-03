using System;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class ScreenShotTitleGenerator
    {
        private int _count;

        public ScreenShotTitleGenerator(int start) => _count = start;

        public string GetNextCount() => $"{(++_count).ToString("D2")}_{DateTime.Now:fffff}";
    }
}
