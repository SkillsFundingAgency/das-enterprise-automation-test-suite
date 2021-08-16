using System;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class ScreenShotTitleGenerator
    {
        public int count;

        public ScreenShotTitleGenerator(int start) => count = start;

        public string GetNextCount() => $"{(++count).ToString("D2")}_{DateTime.Now:fffff}";
    }
}
